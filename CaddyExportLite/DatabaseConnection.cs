using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CaddyExportLite
{
    public class DatabaseConnection
    {
        public IDbConnection connection { get; set; }
        public string connectionString;
        public DatabaseConnection()
        {
            this.connectionString = @"Server=(LocalDB)\v11.0;Integrated Security=true;AttachDbFileName=E:\CaddyDatabase.mdf";
            this.connection = new System.Data.SqlClient.SqlConnection(connectionString);
        }
        public void Open()
        {
            this.connection.Open();
        }
        public void Close()
        {
            this.connection.Close();
        }
        public ConnectionState Status()
        {
            return this.connection.State;
        }
    }
}