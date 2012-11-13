using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaddyExportLite
{
    public interface IConnectionManager
    {
        void AddConnection(string connectionID);
        void RemoveConnection(string connectionID);
        IEnumerable<string> GetClientGUIDsFromConnectionID(string ConnectionID);
        string GetConnectionIDFromClientGUID(string ClientGUID);
        void SetClientGUID(string connectionID, string clientGUID);
        ConnectionMapping GetConnectionMappingFromConnectionID(string connectionID);
        ConnectionMapping GetConnectionMappingFromClientGUID(string clientGUID);
    }
}
