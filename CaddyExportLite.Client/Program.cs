using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.Client.Hubs;

namespace CaddyExportLite.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connect to the service
            var hubConnection = new HubConnection("http://localhost:10790/");

            // Create a proxy to the chat service
            var caddyExportHub = hubConnection.CreateProxy("CaddyExportHub");

            // Print the message when it comes in
            caddyExportHub.On("addMessage", message => Console.WriteLine(message));

            // Start the connection
            hubConnection.Start().Wait();

            caddyExportHub.Invoke("SetClientGUID", "226d7253-012a-457c-b98c-f3e82e0d7bf3");

            string line = null;
            while ((line = Console.ReadLine()) != null)
            {
            }
        }
    }
}
