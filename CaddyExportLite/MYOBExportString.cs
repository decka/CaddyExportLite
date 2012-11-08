using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Dapper;

namespace CaddyExportLite
{
    public interface IMYOBExportString
    {
        IEnumerable<string> FetchExportStringsForID(int ID);
    }

    public class MYOBExportString : IMYOBExportString
    {
        private readonly IDbConnection connection;

        public MYOBExportString(IDbConnection _connection)
        {
            this.connection = _connection;
        }

        public IEnumerable<string> FetchExportStringsForID(int ID)
        {
            return connection.Query<string>("dbo.Export_MYOB_Purchases_Misc", new { @ID = ID }, commandType: CommandType.StoredProcedure);
        }
    }
}