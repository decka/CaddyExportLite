using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;
using SignalR;

namespace CaddyExportLite
{
    public class HubStringSender : ICanSendStringToClient
    {
        public void SendDataToClient(string connectionID, string data)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext("CaddyExportHub");
            hubContext.Clients[connectionID].addMessage(data);
        }
    }
}