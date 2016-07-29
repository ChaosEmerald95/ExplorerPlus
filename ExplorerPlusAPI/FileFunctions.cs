using Microsoft.Win32;
using System;
using System.Text;

namespace ExplorerPlus.API
{
    public static class FileFunctions
    {
        #region PublicMethods
        public static string GetFileTypeDescription(string extension)
        {
            if (string.IsNullOrEmpty(extension))
                return "Datei";

            string readValue = null;
            try
            {
                readValue = Registry.GetValue("HKEY_CLASSES_ROOT\\" + extension, "", "").ToString();
                if (!string.IsNullOrEmpty(readValue))
                {
                    string desc = Registry.GetValue("HKEY_CLASSES_ROOT\\" + readValue, "", "").ToString();
                    try
                    {
                        //Wenn der Wert FriendlyTypeName vorhanden ist, wird diese Funktion bis zum Ende ausgeführt
                        string dec = Registry.GetValue("HKEY_CLASSES_ROOT\\" + readValue, "FriendlyTypeName", "").ToString();
                        //desc = GetStringResourceFromFile(dec);
                        desc = ExplorerPlus.Extra.StringResource.GetStringResourceFromFile(dec).ToString(); //Zwischenlösung, bis Code in C# gefixt ist
                    }
                    catch
                    {
                    }
                    return desc;
                }
                return extension.Substring(1).ToUpper() + "-Datei";
            }
            catch
            {
                return extension.Substring(1).ToUpper() + "-Datei";
            }
        }

        /// <summary>
        /// Quelle: http://stackoverflow.com/questions/9454836/vb-net-c-sharp-code-to-access-target-path-of-link-lnk-files-produces-some-wr
        /// </summary>
        /// <returns></returns>
        public static string GetTargetPath(string lnkPath)
        {
            dynamic shl = new Shell32.Shell();
            // Move this to class scope
            lnkPath = System.IO.Path.GetFullPath(lnkPath);
            dynamic dir = shl.NameSpace(System.IO.Path.GetDirectoryName(lnkPath));
            dynamic itm = dir.Items().Item(System.IO.Path.GetFileName(lnkPath));
            dynamic lnk = (Shell32.ShellLinkObject)itm.GetLink;
            return lnk.Target.Path;
        }

        /// <summary>
        /// Gibt den Dateipfad zurück, der mit der Shortcut verlinkt wurde (mit weiteren Änderungen)
        /// </summary>
        /// <param name="linkpath"></param>
        /// <returns></returns>
        public static string GetShortcutPath(string linkpath)
        {
            string target = GetTargetPath(linkpath); //Den Pfad durch die Methode getTargetPath erhalten

            //Nun werden alle GUID's mit dem richtigen Pfad überschrieben, wenn diese gefunden wurde
            target = ReplaceGUID(target);

            //Nun kommen die Ausnahmen. Manchmal enthalten die Shortcuts anderen Text, der speziell
            //ersetzt werden muss
            //Wenn es eine Verknüpfung auf Visual Studio ist
            if (target.Contains("VisualStudio.") == true)
            {
                target = "C:\\Program Files (x86)\\Microsoft Visual Studio " + target.Substring(13) + "\\Common7\\IDE\\devenv.exe";
            }

            //Bugfix, wenn trotz des richtigen Pfades z.B. statt "Program Files" "Program Files (x86)" gelesen wird
            if (System.IO.File.Exists(target) == false)
            {
                if (target.Contains("Program Files (x86)") == true)
                {
                    target = target.Replace("Program Files (x86)", "Program Files");
                }
                else {
                    target = target.Replace("Program Files", "Program Files (x86)");
                }
            }
            return target;
        }

        /// <summary>
        /// Gibt die String-Ressource einer Datei zurück
        /// </summary>
        /// <param name="dec">Der Dateipfad zu der Datei</param>
        /// <returns></returns>
        public static string GetStringResourceFromFile(string dec)
        {
            //Dateipfad ermitteln und alle Kommas entfernen
            dec = dec.Replace("@", "");
            //Da manche ein @-Zeichen haben, muss es entfernt werden
            string np = dec.Substring(0, dec.LastIndexOf(","));
            int komman = Convert.ToInt32(dec.Substring(dec.LastIndexOf(",") + 1).Trim());
            //Kein File.Exists, da auch Kommas im Pfad drin stecken
            string desc = "";
            IntPtr lb = WinAPI.LoadLibrary(np);
            try
            {
                int realnb = Math.Abs(komman);
                desc = GetStringResource(lb, realnb);
                bool result = WinAPI.FreeLibrary(lb);
            }
            catch
            {
            }
            return desc;
        }
        #endregion

        #region PrivateMethods
        #region "StringResourceLoad"
        private static string GetStringResource(IntPtr handle, int resourceId)
        {
            StringBuilder buffer = new StringBuilder(8192);
            //Buffer for output from LoadString()
            int length = WinAPI.LoadString(handle, resourceId, buffer, buffer.Capacity);

            return buffer.ToString(0, length);
            //Return the part of the buffer that was used.
        }
        #endregion

        private static string ReplaceGUIDText(string text, string replace)
        {
            return text.Replace(text.Substring(0, text.IndexOf("}") + 1), replace);
        }

        /// <summary>
        /// Ersetzt alle GUID durch den richtigen Pfad
        /// </summary>
        /// <param name="path">Der Pfad zur Datei</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private static string ReplaceGUID(string path)
        {
            string ptemp = path;
            if (ptemp.Contains(PathGUID.APPDATALOW))
            {
                ReplaceGUIDText(PathGUID.APPDATALOW,"C:\\Users\\%User%\\AppData\\LocalLow");
            }
            if (ptemp.Contains(PathGUID.PROGRAMFILESX64))
            {
                ReplaceGUIDText(PathGUID.PROGRAMFILESX64, "C:\\Program Files");
            }
            if (ptemp.Contains(PathGUID.PROGRAMFILESX86))
            {
                ReplaceGUIDText(PathGUID.PROGRAMFILESX86, "C:\\Program Files (x86)");
            }
            if (ptemp.Contains(PathGUID.VIDEOS))
            {
                ReplaceGUIDText(PathGUID.VIDEOS, "C:\\Users\\%User%\\Videos");
            }
            if (ptemp.Contains(PathGUID.WINDOWS))
            {
                ReplaceGUIDText(PathGUID.WINDOWS, "C:\\Windows");
            }
            return ptemp;
        }
        #endregion
    }

    public static class PathGUID
    {
        public const string ADDNEWPROGRAM = "DE61D971-5EBC-4F02-A3A9-6C82895E5C04";
        public const string ADMINTOOLS = "724EF170-A42D-4FEF-9F26-B60E846FBA4F";
        public const string APPDATALOW = "A520A1A4-1780-4FF6-BD18-167343C5AF16";
        public const string APPUPDATES = "A305CE99-F527-492B-8B1A-7E76FA98D6E4";
        public const string CDBURNING = "9E52AB10-F80D-49DF-ACB8-4330F5687855";
        public const string CHANGEREMOVEPROGRAMS = "DF7266AC-9274-4867-8D55-3BD661DE872D";
        public const string COMMONADMINTOOLS = "D0384E7D-BAC3-4797-8F14-CBA229B392B5";
        public const string COMMONOEMLINKS = "C1BAE2D0-10DF-4334-BEDD-7AA20B227A9D";
        public const string COMMONPROGRAMS = "0139D44E-6AFE-49F2-8690-3DAFCAE6FFB8";
        public const string COMMONSTARTMENU = "A4115719-D62E-491D-AA7C-E74B8BE3B067";
        public const string COMMONSTARTUP = "82A5EA35-D9CD-47C5-9629-E15D2F714E6E";
        public const string COMMONTEMPLATES = "B94237E7-57AC-4347-9151-B08C6C32D1F7";
        public const string COMPUTER = "0AC0837C-BBF8-452A-850D-79D08E667CA7";
        public const string CONFLICT = "4BFEFB45-347D-4006-A5BE-AC0CB0567192";
        public const string CONNECTIONS = "6F0CD92B-2E97-45D1-88FF-B0D186B8DEDD";
        public const string CONTACTS = "56784854-C6CB-462B-8169-88E350ACB882";
        public const string CONTROLPANEL = "82A74AEB-AEB4-465C-A014-D097EE346D63";
        public const string COOKIES = "2B0F765D-C0E9-4171-908E-08A611B84FF6";
        public const string DESKTOP = "B4BFCC3A-DB2C-424C-B029-7FE99A87C641";
        public const string DOCUMENTS = "FDD39AD0-238F-46AF-ADB4-6C85480369C7";
        public const string DOWNLOADS = "374DE290-123F-4565-9164-39C4925E467B";
        public const string FAVORITEN = "1777F761-68AD-4D8A-87BD-30B759FA33DD";
        public const string FONTS = "FD228CB7-AE11-4AE3-864C-16F3910AB8FE";
        public const string GAMES = "CAC52C1A-B53D-4EDC-92D7-6B2E8AC19434";
        public const string GAMETASKS = "054FAE61-4DD8-4787-80B6-090220C4B700";
        public const string HISTORY = "D9DC8A3B-B784-432E-A781-5A1130A75963";
        public const string INTERNET = "4D9F7874-4E0C-4904-967B-40B0D20C3E4B";
        public const string INTERNETCACHE = "352481E8-33BE-4251-BA85-6007CAEDCF9D";
        public const string LINKS = "BFB9D5E0-C6A9-404C-B2B2-AE6DB6AF4968";
        public const string LOCALAPPDATA = "F1B32785-6FBA-4FCF-9D55-7B8E7F157091";
        public const string LOCALIZEDRESOURCESDIR = "2A00375E-224C-49DE-B8D1-440DF7EF3DDC";
        public const string MUSIC = "4BD8D571-6D19-48D3-BE97-422220080E43";
        public const string NETHOOD = "C5ABBF53-E17F-4121-8900-86626FC2C973";
        public const string NETWORK = "D20BEEC4-5CA8-4905-AE3B-BF251EA09B53";
        public const string ORIGINALIMAGES = "2C36C0AA-5812-4B87-BFD0-4CD0DFB19B39";
        public const string PHOTOALBUMS = "69D2CF90-FC33-4FB7-9A0C-EBB0F0FCB43C";
        public const string PICTURES = "33E28130-4E1E-4676-835A-98395C3BC3BB";
        public const string PLAYLISTS = "DE92C1C7-837F-4F69-A3BB-86E631204A23";
        public const string PRINTERS = "76FC4E2D-D6AD-4519-A663-37BD56068185";
        public const string PRINTHOOD = "9274BD8D-CFD1-41C3-B35E-B13F55A758F4";
        public const string PROFIL = "5E6C858F-0E22-4760-9AFE-EA3317B67173";
        public const string PROGRAMDATA = "62AB5D82-FDC1-4DC3-A9DD-070D1D495D97";
        public const string PROGRAMFILES = "905E63B6-C1BF-494E-B29C-65B732D3D21A";
        public const string PROGRAMFILESCOMMON = "F7F1ED05-9F6D-47A2-AAAE-29D317C6F066";
        public const string PROGRAMFILESCOMMONX64 = "6365D5A7-0F0D-45E5-87F6-0DA56B6A4F7D";
        public const string PROGRAMFILESCOMMONX86 = "DE974D24-D9C6-4D3E-BF91-F4455120B917";
        public const string PROGRAMFILESX64 = "6D809377-6AF0-444B-8957-A3773F02200E";
        public const string PROGRAMFILESX86 = "7C5A40EF-A0FB-4BFC-874A-C0F2E0B9FA8E";
        public const string PROGRAMME = "A77F5D77-2E2B-44C3-A6A2-ABA601054A51";
        public const string PPUBLIC = "DFDF76A2-C82A-4D63-906A-5644AC457385";
        public const string PUBLICDESKTOP = "C4AA340D-F20F-4863-AFEF-F87EF2E6BA25";
        public const string PUBLICDOCUMENTS = "ED4824AF-DCE4-45A8-81E2-FC7965083634";
        public const string PUBLICDOWNLOADS = "3D644C9B-1FB8-4F30-9B45-F670235F79C0";
        public const string PUBLICGAMETASKS = "DEBF2536-E1A8-4C59-B6A2-414586476AEA";
        public const string PUBLICMUSIC = "3214FAB5-9757-4298-BB61-92A9DEAA44FF";
        public const string PUBLICPICTURES = "B6EBFB86-6907-413C-9AF7-4FC2ABF07CC5";
        public const string PUBLICVIDEOS = "2400183A-6185-49FB-A2D8-4A392A602BA3";
        public const string QUICKLAUNCH = "52A4F021-7B75-48A9-9F6B-4B87A210BC8F";
        public const string RECENT = "AE50C081-EBD2-438A-8655-8A092E34987A";
        public const string RECORDEDTV = "BD85E001-112E-431E-983B-7B15AC09FFF1";
        public const string RECYCLEBIN = "B7534046-3ECB-4C18-BE4E-64CD4CB7D6AC";
        public const string RESOURCEDIR = "8AD10C31-2ADB-4296-A8F7-E4701232C972";
        public const string ROAMINGAPPDATA = "3EB685DB-65F9-4CF6-A03A-E3EF65729F3D";
        public const string SAMPLEMUSIC = "B250C668-F57D-4EE1-A63C-290EE7D1AA1F";
        public const string SAMPLEPICTURES = "C4900540-2379-4C75-844B-64E6FAF8716B";
        public const string SAMPLEPLAYLISTS = "15CA69B3-30EE-49C1-ACE1-6B5EC372AFB5";
        public const string SAMPLEVIDEOS = "859EAD94-2E85-48AD-A71A-0969CB56A6CD";
        public const string SAVEDGAMES = "4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4";
        public const string SAVEDSEARCHES = "7D1D3A04-DEBB-4115-95CF-2F29DA2920DA";
        public const string SEARCH_CSC = "EE32E446-31CA-4ABA-814F-A5EBD2FD6D5E";
        public const string SEARCH_MAPI = "98EC0E18-2098-4D44-8644-66979315A281";
        public const string SEARCHHOME = "190337D1-B8CA-4121-A639-6D472D16972A";
        public const string SENDTO = "8983036C-27C0-404B-8F08-102D10DCFD74";
        public const string SIDEBARDEFAULTPARTS = "7B396E54-9EC5-4300-BE0A-2482EBAE1A26";
        public const string SIDEBARPARTS = "A75D362E-50FC-4FB7-AC2C-A8BEAA314493";
        public const string STARTMENU = "625B53C3-AB48-4EC1-BA1F-A1EF4146FC19";
        public const string STARTUP = "B97D20BB-F46A-4C97-BA10-5E3608430854";
        public const string SYNCMANAGER = "43668BF8-C14E-49B2-97C9-747784D784B7";
        public const string SYNCRESULTS = "289A9A43-BE44-4057-A41B-587A76D7E7F9";
        public const string SYNCSETUP = "0F214138-B1D3-4A90-BBA9-27CBC0C5389A";
        public const string SYSTEM = "1AC14E77-02E7-4E5D-B744-2EB1AE5198B7";
        public const string SYSTEMX86 = "D65231B0-B2F1-4857-A4CE-A8E7C6EA7D27";
        public const string VORLAGEN = "A63293E8-664E-48DB-A079-DF759E0509F7";
        public const string TREEPROPERTIES = "5B3749AD-B49F-49C1-83EB-15370FBD4882";
        public const string USERPROFILES = "0762D272-C50A-4BB0-A382-697DCD729B80";
        public const string USERSFILES = "F3CE0F7C-4901-4ACC-8648-D5D44B04EF8F";
        public const string VIDEOS = "18989B1D-99B5-455B-841C-AB7C74E4DDFC";
        public const string WINDOWS = "F38BF404-1D43-42F2-9305-67DE0B28FC23";
    }
}
