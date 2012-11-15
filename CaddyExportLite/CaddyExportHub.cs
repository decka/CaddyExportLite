using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;
using System.Threading.Tasks;

namespace CaddyExportLite
{
    public class CaddyExportHub : Hub, IDisconnect, IConnected
    {
        private IConnectionManager theConnectionManager;

        public void SetConnectionManager(IConnectionManager connectionManager)
        {
            this.theConnectionManager = connectionManager;
        }
        #region Connection Management
        public Task Disconnect()
        {
            return Task.Factory.StartNew(
                () => 
                    theConnectionManager.RemoveConnection(Context.ConnectionId)
                );
        }
        public Task Connect()
        {
            return Task.Factory.StartNew(
                () => 
                    theConnectionManager.AddConnection(Context.ConnectionId, null)
                );
        }
        public Task Reconnect(IEnumerable<string> groups)
        {
            return Task.Factory.StartNew(
                () =>
                    {
                        if (!theConnectionManager.IsConnectionIDConnected(Context.ConnectionId))
                            theConnectionManager.AddConnection(Context.ConnectionId, null);
                    }
                );
        }
        #endregion

        #region Client callable Methods
        public Task SetClientGUID(string clientGUID)
        {
            return new TaskFactory().StartNew(
                () => 
                    theConnectionManager.SetClientGUID(Context.ConnectionId, clientGUID)
                    );
        }
        #endregion
    }
}