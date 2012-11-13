using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaddyExportLite
{
    public class ConnectionManager : IConnectionManager
    {
        private List<ConnectionMapping> ConnectionMappings;

        public ConnectionManager()
        {
            ConnectionMappings = new List<ConnectionMapping>();
        }

        public void AddConnection(string connectionID)
        {
            ConnectionMappings.Add(new ConnectionMapping(connectionID));
        }

        public void RemoveConnection(string connectionID)
        {
            var mapping = GetConnectionMappingFromConnectionID(connectionID);
            if (mapping != null)
                ConnectionMappings.Remove(mapping);
        }

        public IEnumerable<string> GetClientGUIDsFromConnectionID(string ConnectionID)
        {
            return
                from n in ConnectionMappings
                where n.ConnectionID == ConnectionID
                select n.ClientGUID;
        }
        public string GetConnectionIDFromClientGUID(string ClientGUID)
        {
            return
                (from n in ConnectionMappings
                where n.ClientGUID == ClientGUID
                select n.ConnectionID).First();
        }

        public void SetClientGUID(string connectionID, string clientGUID)
        {
            var mapping = GetConnectionMappingFromConnectionID(connectionID);
            mapping.ClientGUID = clientGUID;
        }

        public ConnectionMapping GetConnectionMappingFromConnectionID(string connectionID)
        {
            return ConnectionMappings.Find(p => p.ConnectionID == connectionID);
        }

        public ConnectionMapping GetConnectionMappingFromClientGUID(string clientGUID)
        {
            return ConnectionMappings.Find(p => p.ClientGUID == clientGUID);
        }

        public bool IsClientGUIDConnected(string clientGUID)
        {
            return ConnectionMappings.Exists(p => p.ClientGUID == clientGUID);
        }
    }
}