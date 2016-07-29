using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ExplorerPlus.API
{
    public static class FTP
    {
        public static List<string> GetFilesInDirectory(string url)
        {
            var request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            List<string> l = new List<string>();
            using (var response = (FtpWebResponse)request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    while (!reader.EndOfStream)
                    {
                        l.Add(reader.ReadLine());                        
                    }
                }
            }
            return l;
        }

        public static List<string> GetFilesInDirectory(string url, string username, string password)
        {
            var request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            request.Credentials = new NetworkCredential(username, password);
            List<string> l = new List<string>();
            using (var response = (FtpWebResponse)request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    while (!reader.EndOfStream)
                    {
                        l.Add(reader.ReadLine());
                    }
                }
            }
            return l;
        }
    }
}
