using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerPlus.API
{
    public static class WinAPI
    {
        [DllImport("mpr.dll", EntryPoint = "WNetGetConnectionA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int WNetGetConnection(string localName, System.Text.StringBuilder remoteName, ref int length);

        [DllImport("shell32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr SHGetFileInfo(string pszPath, int dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, int uFlags);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "LoadLibrary", ExactSpelling = true)]
        public static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int LoadString(IntPtr hInstance, int uID, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpBuffer, int nBufferMax);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("shell32.dll", EntryPoint = "ExtractIconA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr ExtractIcon(int hInst, string lpszExeFileName, int nIconIndex);

        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion, out IntPtr piSmallVersion, int amountIcons);

        [DllImport("Netapi32.dll", CharSet = CharSet.Auto, SetLastError = true), SuppressUnmanagedCodeSecurityAttribute]
        public static extern int NetServerEnum(string ServerNane, int dwLevel, ref IntPtr pBuf, int dwPrefMaxLen, out int dwEntriesRead, out int dwTotalEntries, int dwServerType, string domain, out int dwResumeHandle);

        [DllImport("Netapi32.dll", SetLastError = true), SuppressUnmanagedCodeSecurityAttribute]
        public static extern int NetApiBufferFree(IntPtr pBuf);

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode)]
        public static extern int NetShareEnum(StringBuilder ServerName, int level, ref IntPtr bufPtr, uint prefmaxlen, ref int entriesread, ref int totalentries, ref int resume_handle);

        #region Structures
        public struct SHFILEINFO
        {
            // : icon
            public IntPtr hIcon;
            // : icondex
            public int iIcon;
            // : SFGAO_ flags
            public int dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct _SERVER_INFO_100
        {
            internal int sv100_platform_id;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string sv100_name;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SHARE_INFO_1
        {
            public string shi1_netname;
            public uint shi1_type;
            public string shi1_remark;
            public SHARE_INFO_1(string sharename, uint sharetype, string remark)
            {
                this.shi1_netname = sharename;
                this.shi1_type = sharetype;
                this.shi1_remark = remark;
            }
            public override string ToString()
            {
                return shi1_netname;
            }
        }
        #endregion


        #region Enumerators
        public enum NetError : uint
        {
            NERR_Success = 0,
            NERR_BASE = 2100,
            NERR_UnknownDevDir = (NERR_BASE + 16),
            NERR_DuplicateShare = (NERR_BASE + 18),
            NERR_BufTooSmall = (NERR_BASE + 23),
        }
        public enum SHARE_TYPE : uint
        {
            STYPE_DISKTREE = 0,
            STYPE_PRINTQ = 1,
            STYPE_DEVICE = 2,
            STYPE_IPC = 3,
            STYPE_SPECIAL = 0x80000000,
        }
        #endregion
    }
}
