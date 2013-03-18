﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;

namespace CaddyExportLite.DAL
{
    public class ExportRepository : IExportRepository
    {
        private readonly IDbConnection Connection;

        public ExportRepository(IDbConnection connection)
        {
            this.Connection = connection;
            this.Connection.Open();
        }
        public IEnumerable<dynamic> FetchExportListing()
        {
            return Connection.Query("dbo.ExportTask_Listing", new { @HideCompleted = 0 }, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<string> FetchPurchaseExportStringsForPurchaseID(int PurchaseID)
        {
            return Connection.Query<string>("dbo.Export_MYOB_Purchases_Misc", new { @ID = PurchaseID }, commandType: CommandType.StoredProcedure);
        }
        public void MarkExportAsComplete(int exportID, string result)
        {
            Connection.Query("dbo.ExportTask_Result", new { @ExportID = exportID, @Result = result }, commandType: CommandType.StoredProcedure);
        }
    }
}