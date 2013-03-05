using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaddyExportLite.Transport
{
    public class ConnectionManager : IConnectionManager
    {
        private Dictionary<string, int> ConnectionMappings;
        public ConnectionManager()
        {
            ConnectionMappings = new Dictionary<string, int>();
        }
        public void AddConnection(string connectionID, int caddyID)
        {
            ConnectionMappings.Add(connectionID, caddyID);
        }
        public void RemoveConnection(string connectionID)
        {
            ConnectionMappings.Remove(connectionID);
        }
        public int GetCaddyIDFromConnectionID(string connectionID)
        {
            return ConnectionMappings.Where(n => n.Key == connectionID).FirstOrDefault().Value;
        }
        public string GetConnectionIDFromCaddyID(int clientGUID)
        {
            return ConnectionMappings.Where(n => n.Value == clientGUID).FirstOrDefault().Key;
        }
        public void SetCaddyID(string connectionID, int clientGUID)
        {
            ConnectionMappings[connectionID] = clientGUID;
        }
        public bool IsCaddyIDConnected(int clientGUID)
        {
            return ConnectionMappings.ContainsValue(clientGUID);
        }
        public bool IsConnectionIDConnected(string connectionID)
        {
            return ConnectionMappings.ContainsKey(connectionID);
        }
    }
}