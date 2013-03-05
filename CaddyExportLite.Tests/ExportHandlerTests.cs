using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data;

namespace CaddyExportLite.Transport.Tests
{
    [TestFixture]
    class ExportHandlerTests
    {
        [Test]
        public void GetExportString()
        {
            // Arrange
            string connectionString = @"Data Source=sqlsvr4.apexhost.net.au;Initial Catalog=construc_1;User ID=construc_usr;";
            //string connectionString = @"Server=(LocalDB)\v11.0;Integrated Security=true;AttachDbFileName=E:\CaddyDatabase.mdf";
            IDbConnection dbconnection = new System.Data.SqlClient.SqlConnection(connectionString);

            var componentUnderTest = new SQLExportRepository(dbconnection);

            // Act
            var results = componentUnderTest.FetchExportStringsForID(13);

            // Assert
            Assert.IsNotEmpty(results);
        }

        [Test]
        public void GetExportListing()
        {
            // Arrange
            string connectionString = @"Data Source=sqlsvr4.apexhost.net.au;Initial Catalog=construc_1;User ID=construc_usr;Password=v6x^M89;";
            IDbConnection dbconnection = new System.Data.SqlClient.SqlConnection(connectionString);

            var componentUnderTest = new SQLExportRepository(dbconnection);

            // Act
            var results = componentUnderTest.FetchExportListing();

            // Assert
            Assert.IsNotEmpty(results);
        }
    }
}
