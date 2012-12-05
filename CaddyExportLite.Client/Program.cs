using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaddyExportLite.Client;

namespace CaddyExportLite.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var hubConnectionURL = Properties.Settings.Default.HubConnectionURL;
            var clientGUID = Properties.Settings.Default.ClientGUID;

            if (hubConnectionURL != null)
            {
                if (clientGUID != null)
                {
                    var theHubServerConnection = new HubServerConnection(hubConnectionURL, clientGUID);

                    string line = null;
                    while ((line = Console.ReadLine()) != null)
                    {
                    }
                }
                else
                    throw new ArgumentNullException("ClientGUID Setting cannot be null.");
            }
            else
                throw new ArgumentNullException("HubConnectionURL Setting cannot be null.");
        }
    }
}
