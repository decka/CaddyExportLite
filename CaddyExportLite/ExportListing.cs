using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;

namespace CaddyExportLite
{
    public interface IExportListing
    {
        IEnumerable<dynamic> FetchExportListing();
    }
    public class ExportListing : IExportListing
    {
        private readonly IDbConnection connection;

        public ExportListing(IDbConnection _connection)
        {
            this.connection = _connection;
        }
        public IEnumerable<dynamic> FetchExportListing()
        {
            return connection.Query("dbo.ExportTask_Listing", new { HideCompleted = 0 }, commandType: CommandType.StoredProcedure);
        }
    }
}