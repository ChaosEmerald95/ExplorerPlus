using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace ExplorerPlus.API
{
    public static class LocalNetworkFunctions
    {
        const uint MAX_PREFERRED_LENGTH = 0xFFFFFFFF;
        const int NERR_Success = 0;

        /// <summary>
        /// Gibt die IP des PCs zurück
        /// </summary>
        /// <param name="machinename">Der HostName des PCs</param>
        /// <returns></returns>
        public static string GetIPAdressFromMachineName(string machinename)
        {
            IPHostEntry host = Dns.GetHostEntry(machinename);
            foreach(IPAddress ip in host.AddressList )
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork )
                {
                    return ip.ToString();
                }
            }
            return "";
        }

        /// <summary>
        /// Gibt eine Liste aller Netzwerkordner eines PCs zurück
        /// </summary>
        /// <param name="server"></param>
        /// <returns></returns>
        public static List<string> GetListOfSharedFolders(string server)
        {
            WinAPI.SHARE_INFO_1[] netshare = EnumNetShares(server);
            List<string> list = new List<string>();
            foreach (WinAPI.SHARE_INFO_1 entry in netshare)
            {
                list.Add(entry.shi1_netname);
            }
            return list;
        }

        private static WinAPI.SHARE_INFO_1[] EnumNetShares(string Server)
        {
            List<WinAPI.SHARE_INFO_1> ShareInfos = new List<WinAPI.SHARE_INFO_1>();
            int entriesread = 0;
            int totalentries = 0;
            int resume_handle = 0;
            int nStructSize = Marshal.SizeOf(typeof(WinAPI.SHARE_INFO_1));
            IntPtr bufPtr = IntPtr.Zero;
            StringBuilder server = new StringBuilder(Server);
            int ret = WinAPI.NetShareEnum(server, 1, ref bufPtr, MAX_PREFERRED_LENGTH, ref entriesread, ref totalentries, ref resume_handle);
            if (ret == NERR_Success)
            {
                IntPtr currentPtr = bufPtr;
                for (int i = 0; i < entriesread; i++)
                {
                    WinAPI.SHARE_INFO_1 shi1 = (WinAPI.SHARE_INFO_1)Marshal.PtrToStructure(currentPtr, typeof(WinAPI.SHARE_INFO_1));
                    ShareInfos.Add(shi1);
                    //Remember, 64-bit systems have 64-bit pointers. Using ToInt32 will cause an ArithmeticOverview exception.
                    //Use ToInt64 if you need to.
                    currentPtr = new IntPtr(currentPtr.ToInt32() + nStructSize);
                }
                WinAPI.NetApiBufferFree(bufPtr);
                return ShareInfos.ToArray();
            }
            else
            {
                ShareInfos.Add(new WinAPI.SHARE_INFO_1("ERROR=" + ret.ToString(), 10, string.Empty));
                return ShareInfos.ToArray();
            }
        }

        public static string GetHostName(string ipAddress)
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry(ipAddress);
                if (entry != null)
                {
                    return entry.HostName;
                }
            }
            catch (SocketException)
            {
                // MessageBox.Show(e.Message.ToString());
            }
            return null;
        }
    }
}
