using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;
using SignalR;
using System.Threading.Tasks;

namespace CaddyExportLite
{
    public class CaddyExportHub : Hub, IDisconnect, IConnected
    {
        private readonly IConnectionManager CaddyConnectionManager;
        private readonly ICanMarkExportAsComplete ExportCompleter;

        public CaddyExportHub(IConnectionManager connectionManager, ICanMarkExportAsComplete exportCompleter)
        {
            this.CaddyConnectionManager = connectionManager;
            this.ExportCompleter = exportCompleter;
        }
        #region Connection Management
        public Task Disconnect()
        {
            return Task.Factory.StartNew(
                () => 
                    CaddyConnectionManager.RemoveConnection(Context.ConnectionId)
                );
        }
        public Task Connect()
        {
            return Task.Factory.StartNew(
                () => 
                    CaddyConnectionManager.AddConnection(Context.ConnectionId, null)
                );
        }
        public Task Reconnect(IEnumerable<string> groups)
        {
            return Task.Factory.StartNew(
                () =>
                    {
                        if (!CaddyConnectionManager.IsConnectionIDConnected(Context.ConnectionId))
                            CaddyConnectionManager.AddConnection(Context.ConnectionId, null);
                    }
                );
        }
        #endregion

        #region Client callable Methods
        public Task SetClientGUID(string clientGUID)
        {
            return new TaskFactory().StartNew(
                () => 
                    {
                        CaddyConnectionManager.SetClientGUID(Context.ConnectionId, clientGUID);
                    });
        }
        public Task MarkExportAsComplete(int exportID, string result)
        {
            return new TaskFactory().StartNew(
                () => 
                    {
                        ExportCompleter.MarkExportAsComplete(exportID, result);
                    });
        }

        #endregion

        #region Server callable Methods
        internal static void SendDataToClient(string connectionID, string data)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<CaddyExportHub>();
            hubContext.Clients[connectionID].stringFromServer(data);
        }
        #endregion
    }
}