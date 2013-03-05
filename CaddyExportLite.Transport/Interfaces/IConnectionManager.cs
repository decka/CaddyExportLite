using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaddyExportLite.Transport
{
    public interface IConnectionManager
    {
        void AddConnection(string connectionID, int caddyID);
        void RemoveConnection(string connectionID);
        int GetCaddyIDFromConnectionID(string ConnectionID);
        string GetConnectionIDFromCaddyID(int caddyID);
        void SetCaddyID(string connectionID, int caddyID);
        bool IsCaddyIDConnected(int caddyID);
        bool IsConnectionIDConnected(string connectionID);
    }
}
