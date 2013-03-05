using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;
using SignalR;

namespace CaddyExportLite.Transport
{
    public class HubStringSender : ICanSendStringToClient
    {
        public void SendDataToClient(string connectionID, string data)
        {
            CaddyExportHub.SendDataToClient(connectionID, data);
        }
    }
}