using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ExplorerPlus.API
{
    public static class SSD
    {
        //https://social.msdn.microsoft.com/Forums/vstudio/en-US/29996b90-092d-4c91-a2e6-3ae889c0f76c/how-to-detect-ssd-drive-and-its-partition-letter?forum=vbgeneral

        // For CreateFile to get handle to drive
        private const uint GENERIC_READ = 0x80000000;
        private const uint GENERIC_WRITE = 0x40000000;
        private const uint FILE_SHARE_READ = 0x1;
        private const uint FILE_SHARE_WRITE = 0x2;
        private const uint OPEN_EXISTING = 3;
        private const uint FILE_ATTRIBUTE_NORMAL = 0x80;

        // For control codes
        private const uint FILE_DEVICE_MASS_STORAGE = 0x2d;
        private const uint IOCTL_STORAGE_BASE = FILE_DEVICE_MASS_STORAGE;
        private const uint FILE_DEVICE_CONTROLLER = 0x4;
        private const uint IOCTL_SCSI_BASE = FILE_DEVICE_CONTROLLER;
        private const uint METHOD_BUFFERED = 0;
        private const uint FILE_ANY_ACCESS = 0;
        private const uint FILE_READ_ACCESS = 0x1;

        private const uint FILE_WRITE_ACCESS = 0x2;
        private static uint CTL_CODE(uint DeviceType, uint Function, uint Method, uint Access)
        {
            return ((DeviceType << 16) | (Access << 14) | (Function << 2) | Method);
        }

        // For DeviceIoControl to check no seek penalty
        private const uint StorageDeviceSeekPenaltyProperty = 7;
        private const uint PropertyStandardQuery = 0;
        private const uint ATA_FLAGS_DATA_IN = 0x2;
        private const uint FORMAT_MESSAGE_FROM_SYSTEM = 0x1000;

        /// <summary>
        /// Check, if Drive has NoSeekPenalty. If it's true, then it is a SSD
        /// </summary>
        /// <param name="diskindex">The Drive-Index</param>
        /// <returns></returns>
        public static string HasNoSeekPenalty(byte diskindex)
        {
            string sDrive = @"\\.\PhysicalDrive" + diskindex.ToString();

            SafeFileHandle hDrive = WinAPI.CreateFileW(sDrive, 0, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
            // No access to drive

            if (hDrive == null || hDrive.IsInvalid)
            {
                string message = GetErrorMessage(Marshal.GetLastWin32Error());
                return "CreateFile failed. " + message;
            }

            uint IOCTL_STORAGE_QUERY_PROPERTY = CTL_CODE(IOCTL_STORAGE_BASE, 0x500, METHOD_BUFFERED, FILE_ANY_ACCESS);
            // From winioctl.h

            WinAPI.STORAGE_PROPERTY_QUERY query_seek_penalty = new WinAPI.STORAGE_PROPERTY_QUERY();
            query_seek_penalty.PropertyId = StorageDeviceSeekPenaltyProperty;
            query_seek_penalty.QueryType = PropertyStandardQuery;

            WinAPI.DEVICE_SEEK_PENALTY_DESCRIPTOR query_seek_penalty_desc = new WinAPI.DEVICE_SEEK_PENALTY_DESCRIPTOR();

            uint returned_query_seek_penalty_size = 0;

            bool query_seek_penalty_result = WinAPI.DeviceIoControl(hDrive, IOCTL_STORAGE_QUERY_PROPERTY, ref query_seek_penalty, Convert.ToUInt32(Marshal.SizeOf(query_seek_penalty)), ref query_seek_penalty_desc, Convert.ToUInt32(Marshal.SizeOf(query_seek_penalty_desc)), ref returned_query_seek_penalty_size, IntPtr.Zero);

            hDrive.Close();

            if (query_seek_penalty_result == false)
            {
                string message = GetErrorMessage(Marshal.GetLastWin32Error());
                return "DeviceIoControl failed. " + message;
            }
            else {
                if (query_seek_penalty_desc.IncursSeekPenalty == false)
                {
                    return "Result: This drive has NO SEEK penalty.";
                }
                else {
                    return "Result: This drive has SEEK penalty.";
                }
            }
        }

        /// <summary>
        /// Get the Media Rotation Rate of the Harddrive. If the Result is 1 then it is a SSD
        /// !This method needs Administrator-Rights. Set this in app.manifest!
        /// </summary>
        /// <param name="diskindex">The Drive-Index</param>
        /// <returns></returns>
        public static string HasNominalMediaRotationRate(byte diskindex)
        {
            string sDrive = @"\\.\PhysicalDrive" + diskindex.ToString();

            SafeFileHandle hDrive = WinAPI.CreateFileW(sDrive, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
            // Administrative privilege is required

            if (hDrive == null || hDrive.IsInvalid)
            {
                string message = GetErrorMessage(Marshal.GetLastWin32Error());
                return "CreateFile failed. " + message;
            }

            uint IOCTL_ATA_PASS_THROUGH = CTL_CODE(IOCTL_SCSI_BASE, 0x40b, METHOD_BUFFERED, FILE_READ_ACCESS | FILE_WRITE_ACCESS);
            // From ntddscsi.h

            WinAPI.ATAIdentifyDeviceQuery id_query = new WinAPI.ATAIdentifyDeviceQuery();
            id_query.data = new ushort[256];

            id_query.header.Length = Convert.ToUInt16(Marshal.SizeOf(id_query.header));
            id_query.header.AtaFlags = Convert.ToUInt16(ATA_FLAGS_DATA_IN);
            id_query.header.DataTransferLength = Convert.ToUInt32(id_query.data.Length * 2);
            // Size of "data" in bytes
            id_query.header.TimeOutValue = 3;
            // Sec
            id_query.header.DataBufferOffset = (IntPtr)Marshal.OffsetOf(typeof(WinAPI.ATAIdentifyDeviceQuery), "data");
            id_query.header.PreviousTaskFile = new byte[8];
            id_query.header.CurrentTaskFile = new byte[8];
            id_query.header.CurrentTaskFile[6] = 0xec;
            // ATA IDENTIFY DEVICE

            uint retval_size = 0;

            bool result = WinAPI.DeviceIoControl(hDrive, IOCTL_ATA_PASS_THROUGH, ref id_query, Convert.ToUInt32(Marshal.SizeOf(id_query)), ref id_query, Convert.ToUInt32(Marshal.SizeOf(id_query)), ref retval_size, IntPtr.Zero);

            hDrive.Close();

            if (result == false)
            {
                string message = GetErrorMessage(Marshal.GetLastWin32Error());
                return "DeviceIoControl failed. " + message;
            }
            else {
                // Word index of nominal media rotation rate
                // (1 means non-rotate device)
                const int kNominalMediaRotRateWordIndex = 217;

                if (id_query.data[kNominalMediaRotRateWordIndex] == 1)
                {
                    return "Result: This drive is NON-ROTATE device.";
                }
                else {
                    return "Result: This drive is ROTATE device.";
                }
            }
        }

        private static string GetErrorMessage(int code)
        {
            StringBuilder message = new StringBuilder(255);
            WinAPI.FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, IntPtr.Zero, Convert.ToUInt32(code), 0, message, Convert.ToUInt32(message.Capacity), IntPtr.Zero);
            return message.ToString();
        }
    }
}
