using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.Client.Hubs;

namespace CaddyExportLite.Client
{
    public class HubServerConnection
    {
        public Guid ClientGUID { get; set; }
        public string HubConnectionURL { get; set; }
        public HubConnection theHubConnection { get; set; }
        public IHubProxy caddyExportHub { get; set; }

        public HubServerConnection(Guid clientGUID, string hubConnectionURL)
        {
            this.ClientGUID = clientGUID;
            this.HubConnectionURL = hubConnectionURL;
        }
        public void ConnectToServer()
        {
            theHubConnection = new HubConnection(HubConnectionURL);
            caddyExportHub = theHubConnection.CreateProxy("CaddyExportHub");
        }

        public void SetupCallbacks()
        {
            caddyExportHub.On("addMessage", message => Console.WriteLine(message));
        }

        public void StartHub()
        {
            theHubConnection.Start().Wait();
        }

        public void SetClientGUID()
        {
            caddyExportHub.Invoke("SetClientGUID", ClientGUID);
        }

        public void PreStartupJobs()
        {
            ConnectToServer();
            SetupCallbacks();
            StartHub();
        }
        public void PostStartupJobs()
        {
            SetClientGUID();
        }
    }
}
