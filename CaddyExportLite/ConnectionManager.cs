using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaddyExportLite
{
    public class ConnectionManager : IConnectionManager
    {
        private Dictionary<string, string> ConnectionMappings;
        public ConnectionManager()
        {
            ConnectionMappings = new Dictionary<string, string>();
        }
        public void AddConnection(string connectionID, string clientGUID)
        {
            ConnectionMappings.Add(connectionID, clientGUID);
        }
        public void RemoveConnection(string connectionID)
        {
            ConnectionMappings.Remove(connectionID);
        }
        public string GetClientGUIDFromConnectionID(string connectionID)
        {
            return ConnectionMappings.Where(n => n.Key == connectionID).FirstOrDefault().Value;
        }
        public string GetConnectionIDFromClientGUID(string clientGUID)
        {
            return ConnectionMappings.Where(n => n.Value == clientGUID).FirstOrDefault().Key;
        }
        public void SetClientGUID(string connectionID, string clientGUID)
        {
            ConnectionMappings[connectionID] = clientGUID;
        }
        public bool IsClientGUIDConnected(string clientGUID)
        {
            return ConnectionMappings.ContainsValue(clientGUID);
        }
        public bool IsConnectionIDConnected(string connectionID)
        {
            return ConnectionMappings.ContainsKey(connectionID);
        }
    }
}