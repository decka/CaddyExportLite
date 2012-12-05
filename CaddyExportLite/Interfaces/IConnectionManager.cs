using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaddyExportLite
{
    public interface IConnectionManager
    {
        void AddConnection(string connectionID, string clientGUID);
        void RemoveConnection(string connectionID);
        string GetClientGUIDFromConnectionID(string ConnectionID);
        string GetConnectionIDFromClientGUID(string ClientGUID);
        void SetClientGUID(string connectionID, string clientGUID);
        bool IsClientGUIDConnected(string clientGUID);
        bool IsConnectionIDConnected(string connectionID);
    }
}
