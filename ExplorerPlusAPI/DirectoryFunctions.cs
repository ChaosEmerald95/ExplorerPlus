using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExplorerPlus.API
{
    public static class DirectoryFunctions
    {
        /// <summary>
        /// Prüft, ob der Pfad noch weitere Unterordner besitzt
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool HasSubDirectories(string path)
        {
            try
            {
                DirectoryInfo dirinfo = new DirectoryInfo(path);
                if (dirinfo.GetDirectories().Length > 0)
                    return true;
                else return false;
            }
            catch { return false; }
        }

        /// <summary>
        /// Gibt die Größe des Ordners in Byte zurück
        /// Quelle: http://www.freevbcode.com/ShowCode.asp?ID=4287
        /// </summary>
        /// <param name="DirPath"></param>
        /// <param name="IncludeSubFolders"></param>
        /// <returns></returns>
        public static long GetFolderSize(string DirPath, bool IncludeSubFolders = true)
        {
            long lngDirSize = 0;
            FileInfo objFileInfo = null;
            DirectoryInfo objDir = new DirectoryInfo(DirPath);
            DirectoryInfo objSubFolder = null;
            try
            {
                //add length of each file
                foreach (FileInfo objFileInfo_loopVariable in objDir.GetFiles())
                {
                    objFileInfo = objFileInfo_loopVariable;
                    lngDirSize += objFileInfo.Length;
                }
                //call recursively to get sub folders
                //if you don't want this set optional
                //parameter to false 
                if (IncludeSubFolders)
                {
                    foreach (DirectoryInfo objSubFolder_loopVariable in objDir.GetDirectories())
                    {
                        objSubFolder = objSubFolder_loopVariable;
                        try
                        {
                            lngDirSize += GetFolderSize(objSubFolder.FullName);
                        }
                        catch (UnauthorizedAccessException)
                        {
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return lngDirSize;
        }
    }
}
