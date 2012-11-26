using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;

namespace CaddyExportLite
{
    public class ExportHandler : IExportHandler
    {
        private readonly IDbConnection Connection;

        public ExportHandler(IDbConnection connection)
        {
            this.Connection = connection;
            this.Connection.Open();
        }
        public IEnumerable<dynamic> FetchExportListing()
        {
            return Connection.Query("dbo.ExportTask_Listing", new { HideCompleted = 0 }, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<string> FetchExportStringsForID(int ID)
        {
            return Connection.Query<string>("dbo.Export_MYOB_Purchases_Misc", new { @ID = ID }, commandType: CommandType.StoredProcedure);
        }
    }
}