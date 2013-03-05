using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.Client.Hubs;

namespace CaddyExportLite.Transport.Client
{
    public class HubServerConnection
    {
        public Guid ClientGUID { get; set; }
        public string HubConnectionURL { get; set; }
        public HubConnection theHubConnection { get; set; }
        public IHubProxy caddyExportHub { get; set; }

        public HubServerConnection(string hubConnectionURL, Guid clientGUID)
        {
            this.HubConnectionURL = hubConnectionURL;
            this.ClientGUID = clientGUID;

            ConnectToHub();
            SetupOnStringFromServer(message => Console.WriteLine(message));
            StartHub();
            TrySetClientGUID(this.ClientGUID);            
        }
        public void ConnectToHub()
        {
            theHubConnection = new HubConnection(HubConnectionURL);
            caddyExportHub = theHubConnection.CreateProxy("CaddyExportHub");
        }

        public void SetupOnStringFromServer(Action<string> onAddMessage)
        {
            caddyExportHub.On("stringFromServer", onAddMessage);
        }

        public void StartHub()
        {
            theHubConnection.Start().Wait();
        }

        public void TrySetClientGUID(Guid ClientGUID)
        {
            caddyExportHub.Invoke("SetClientGUID", ClientGUID.ToString()).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("An error occurred during the method call {0}", task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Successfully called SetClientGUID, for ClientGUID: {0}", ClientGUID.ToString());
                }
            });
        }
    }
}
