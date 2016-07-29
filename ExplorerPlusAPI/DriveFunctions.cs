using System;
using System.IO;
using System.Management;
using System.Text;

namespace ExplorerPlus.API
{
    public static class DriveFunctions
    {
        //Konstanten
        public const string DRIVE_VOLUMELABEL_STD_HDD = "Lokaler Datenträger";
        public const string DRIVE_VOLUMELABEL_STD_EXT = "USB-Laufwerk";
        public const string DRIVE_VOLUMELABEL_STD_OPT = "Optisches Laufwerk";
        public const string DRIVE_VOLUMELABEL_STD_NET = "Netzlaufwerk";
        public const string DRIVE_VOLUMELABEL_STD_HDD_DESC = "Festplattenlaufwerk";
        public const string DRIVE_VOLUMELABEL_STD_SSD_DESC = "SSD-Laufwerk";

        //Fürs Management
        private static ManagementClass driveinfodata = new ManagementClass("Win32_DiskDrive"); //Stellt Informationen zur Hardware bereit
        private static ManagementClass drivepartdata = new ManagementClass("Win32_DiskPartition"); //Stellt Informationen zu den Partitionen bereit
        private static ManagementClass drivelocdata = new ManagementClass("Win32_LogicalDisk"); //Stellt Informationen zu den Laufwerken bereit

        #region PublicMethods
        public static object GetUNCPath(string driveletter)
        {
            if (!string.IsNullOrEmpty(driveletter))
            {
                StringBuilder uncPathBuf = new StringBuilder(259);
                int unccap = uncPathBuf.Capacity;
                int err = WinAPI.WNetGetConnection(driveletter, uncPathBuf, ref unccap);
                //Ab hier wird drivename zusammengesetzt
                if (err == 0)
                {
                    string temppath = uncPathBuf.ToString().Substring(0, uncPathBuf.ToString().Length);
                    int lb = temppath.LastIndexOf("\\");
                    return temppath.Substring(lb + 1) + " (" + temppath.Substring(0, lb) + ")";
                }
            }
            return "";
        }

        /// <summary>
        /// Gibt den Namen des Drives aus, zudem der Diskindex gehört
        /// </summary>
        /// <param name="diskindex"></param>
        /// <returns></returns>
        public static string GetDriveModelName(int diskindex)
        {
            string filter = "Disk #";
            ManagementScope scope = new ManagementScope("\\root\\cimv2");
            ObjectQuery query = new ObjectQuery("select * from Win32_DiskPartition");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection drives = searcher.Get();
            foreach (ManagementObject current in drives)
            {
                ObjectQuery associators = new ObjectQuery("ASSOCIATORS OF {Win32_DiskPartition.DeviceID=\"" + current["deviceid"] + "\"} where assocclass=Win32_DiskDriveToDiskPartition");
                searcher = new ManagementObjectSearcher(scope, associators);
                ManagementObjectCollection disks = searcher.Get();
                foreach (ManagementObject disk in disks)
                {
                    //Wenn der DiskIndex übereinstimmt
                    if (Convert.ToString(current["deviceid"]).Substring(Convert.ToString(current["deviceid"]).IndexOf(filter) + filter.Length, 1) == diskindex.ToString())
                    {
                        return Convert.ToString(disk["Model"]);
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// Gibt Partitions- und Diskindex zurück (0 = Diskindex; 1 = Partitionsindex)
        /// </summary>
        /// <param name="driveletter">Der Laufwerksbuchstabe</param>
        /// <returns></returns>
        public static int[] GetPartitionData(string driveletter)
        {
            int[] data = new int[2]; //es sind nur 2 Informationen
            string info = GetDrivePartitionData(driveletter); //Informationen erhalten
            data[0] = Convert.ToInt32(info.Substring(0 + 6, 1));
            data[1] = Convert.ToInt32(info.Substring(info.IndexOf("Partition #") + 11));
            return data;
        }

        /// <summary>
        /// Beschriftung der Partition erhalten
        /// </summary>
        /// <param name="driveletter">Der Laufwerksbuchstabe</param>
        /// <returns></returns>
        public static string GetVolumeLabel(char driveletter)
        {
            DriveInfo drvinfo = new DriveInfo(driveletter.ToString());
            if (drvinfo.IsReady)
            {
                string drivename = "";
                if (drvinfo.DriveType == DriveType.Fixed & string.IsNullOrEmpty(drvinfo.VolumeLabel))
                {
                    drivename = DRIVE_VOLUMELABEL_STD_HDD;
                }
                else if (drvinfo.DriveType == DriveType.Removable & string.IsNullOrEmpty(drvinfo.VolumeLabel))
                {
                    drivename = DRIVE_VOLUMELABEL_STD_EXT;
                }
                else if (drvinfo.DriveType == DriveType.Network)
                {
                    drivename = GetUNCPath(drvinfo.Name.Substring(0, 2)).ToString();
                }
                else
                {
                    drivename = drvinfo.VolumeLabel;
                }
                return drivename; 
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Gibt Partitions- und Diskindex zurück (0 = Diskindex; 1 = Partitionsindex)
        /// </summary>
        /// <param name="driveletter">Der Laufwerksbuchstabe</param>
        /// <returns></returns>
        public static ulong[] GetPartitionSizeData(char driveletter)
        {
            ManagementObjectCollection locdrive = drivelocdata.GetInstances(); //Die benötigten Daten findet man dort
            foreach (ManagementObject obj in locdrive )
            {
                if (obj["deviceid"].ToString().Substring(0,1) == driveletter.ToString()) //wenn das Drive gefunden wurde
                {
                    //Der Array wird erstellt und speichert folgende Informationen
                    //0 = Gesamtgröße der Partition
                    //1 = Freier Speicher
                    //2 = Genutzer Speicher (berechnet)
                    ulong[] data = new ulong[3];
                    data[0] = Convert.ToUInt64(obj["Size"]);
                    data[1] = Convert.ToUInt64(obj["FreeSpace"]);
                    data[2] = data[0] - data[1]; //Berechnet
                    return data;
                }
            }
            return null; //Sollte in der Regel nicht vorkommen
        }

        /// <summary>
        /// Prüft, ob das angegebene Laufwerk eine SSD ist
        /// </summary>
        /// <param name="driveletter">Der Laufwerksbuchstabe</param>
        /// <returns></returns>
        public static bool IsSSD(char driveletter)
        {
            int di = GetPartitionData(driveletter.ToString())[0];
            string res = SSD.HasNoSeekPenalty((byte)di); //Result erhalten
            if (res.Contains("Result") == true && res.Contains("NO SEEK"))
                return true; //Es ist eine SSD
            else
                return false; //Es ist keine SSD
        }

        /// <summary>
        /// Prüft, ob das angegebene Laufwerk eine SSD ist
        /// </summary>
        /// <param name="diskindex">Der Drive-Index</param>
        /// <returns></returns>
        public static bool IsSSD(int diskindex)
        {
            string res = SSD.HasNoSeekPenalty((byte)diskindex); //Result erhalten
            if (res.Contains("Result") == true && res.Contains("NO SEEK"))
                return true; //Es ist eine SSD
            else
                return false; //Es ist keine SSD
        }
        #endregion

        #region PrivateFunctions
        /// <summary>
        /// Gibt die Partitionsdaten aus dem WMI zurück (nutzt Win32_LogicalDiskToPartition, um die Partition zu ermitteln)
        /// http://bytes.com/topic/net/answers/509395-how-get-hard-disk-number-drive-letter#post1981641
        /// </summary>
        /// <param name="driveletter"></param>
        private static string GetDrivePartitionData(string driveletter)
        {
            ManagementScope scope = new ManagementScope("\\root\\cimv2");
            ObjectQuery query = new ObjectQuery("select * from Win32_DiskPartition");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection drives = searcher.Get();
            foreach (ManagementObject current in drives)
            {
                ObjectQuery associators = new ObjectQuery("ASSOCIATORS OF {Win32_DiskPartition.DeviceID=\"" + current["deviceid"] + "\"} where assocclass=Win32_LogicalDiskToPartition");
                searcher = new ManagementObjectSearcher(scope, associators);
                ManagementObjectCollection disks = searcher.Get();
                foreach (ManagementObject disk in disks)
                {
                    //Wenn der Buchstabe übereinstimmt
                    if (Convert.ToString(disk["deviceid"]).Substring(0, 1) == driveletter)
                    {
                        return Convert.ToString(current["deviceid"]);
                    }
                }
            }
            return "";
        }
        #endregion
    }
}
