using System;
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
        /// Sollte in einem zusätzlichen Thread ausgeführt werden, damit das Programm nicht
        /// ausgebremst wird
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

        /// <summary>
        /// Prüft, ob am Ende des Pfades der Backslash vorhanden ist. Wenn nicht, wird dieser angehangen
        /// </summary>
        /// <param name="dirpath">Der zu überprüfende Ordnerpfad</param>
        /// <returns></returns>
        public static string CorrectPath(string dirpath)
        {
            if (dirpath.Substring(dirpath.Length - 1, 1) != @"\")
                return dirpath + @"\";
            else
                return dirpath;
        }

        /// <summary>
        /// Gibt den Parent-Pfad des Verzeichnisses zurück.
        /// </summary>
        /// <param name="directorypath">Das Verzeichnis, wo der Parent-Pfad ermittelt werden soll</param>
        /// <returns></returns>
        public static string GetParentPath(string directorypath)
        {
            if (directorypath.Substring(directorypath.Length - 1, 1) == @"\") //Wenn das letzte Zeichen ein "\" ist, soll es entfernt werden
                directorypath = directorypath.Substring(0, directorypath.Length - 1);

            int pathbreak = directorypath.LastIndexOf(@"\"); //Die letzte Position des Zeichens "\" erhalten
            if (pathbreak == -1)
                return directorypath;
            else
                return directorypath.Substring(0, pathbreak + 1);
        }
    }
}
