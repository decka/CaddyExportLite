using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaddyExportLite.Transport
{
    public class ConsoleStringSender : ICanSendStringToClient
    {
        public void SendDataToClient(string connectionID, string data)
        {
            Console.WriteLine("Connection ID: {0}, Data: {1}", connectionID, data);
        }
    }
}