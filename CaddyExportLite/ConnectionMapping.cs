using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaddyExportLite
{
    public class ConnectionMapping
    {
        public string ConnectionID { get; set; }
        public string ClientGUID { get; set; }

        public ConnectionMapping(string connectionID)
        {
            this.ConnectionID = connectionID;
        }

        public ConnectionMapping(string connectionID, string clientGUID)
        {
            this.ConnectionID = connectionID;
            this.ClientGUID = clientGUID;
        }
    }
}