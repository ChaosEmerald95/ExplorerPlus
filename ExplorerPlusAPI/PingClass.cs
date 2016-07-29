using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;

namespace ExplorerPlus.API
{
    public delegate void NetworkPingEventHandler(List<string> iplist);

    public class PingClass
    {
        private const int PING_ATTEMPTS = 1; //Wie oft gepingt werden soll

        private List<string> iplist = new List<string>();
        public event NetworkPingEventHandler PingListCompleted;

        private static string NetworkGateway()
        {
            string ip = null;

            foreach (NetworkInterface f in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (f.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (GatewayIPAddressInformation d in f.GetIPProperties().GatewayAddresses)
                    {
                        if (d.Address.AddressFamily == AddressFamily.InterNetwork)
                            ip = d.Address.ToString();
                    }
                }
            }
            return ip;
        }

        public void Ping_all()
        {
            string gate_ip = NetworkGateway();

            //Extracting and pinging all other ip's.
            string[] array = gate_ip.Split('.');

            for (int i = 2; i <= 254; i++)
            {
                string ping_var = array[0] + "." + array[1] + "." + array[2] + "." + i;

                //time in milliseconds           
                //Damit auch mit einem Event die Liste zurückgegeben werden kann, muss 
                //an die Methode Ping noch ein weiterer Parameter übergeben werden. Wenn
                //i 254 ist, soll ein ganz anderes PingComplete-Event stattfinden
                if (i == 254)
                    Ping(ping_var, PING_ATTEMPTS, 10000, true);
                else
                    Ping(ping_var, PING_ATTEMPTS, 10000);
            }
        }

        private void Ping(string host, int attempts, int timeout, bool lastadress = false)
        {
            for (int i = 0; i < attempts; i++)
            {
                new Thread(delegate ()
                {
                    try
                    {
                        System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
                        if (lastadress == true)
                            ping.PingCompleted += new PingCompletedEventHandler(LastPingCompleted);
                        else
                            ping.PingCompleted += new PingCompletedEventHandler(PingCompleted);
                        System.Diagnostics.Debug.Print("Ping to " + host);
                        ping.SendAsync(host, timeout, host);
                    }
                    catch
                    {
                        // Do nothing and let it try again until the attempts are exausted.
                        // Exceptions are thrown for normal ping failurs like address lookup
                        // failed.  For this reason we are supressing errors.
                    }
                }).Start();
            }
        }

        private void PingCompleted(object sender, PingCompletedEventArgs e)
        {
            string ip = (string)e.UserState;
            if (e.Reply != null && e.Reply.Status == IPStatus.Success)
            {
                System.Diagnostics.Debug.Print("Ping Complete for " + ip);
                iplist.Add(ip);
            }
        }

        private void LastPingCompleted(object sender, PingCompletedEventArgs e)
        {
            string ip = (string)e.UserState;
            if (e.Reply != null && e.Reply.Status == IPStatus.Success)
            {
                iplist.Add(ip);
            }
            if (PingListCompleted != null)
                PingListCompleted(iplist);
        }
    }
}
