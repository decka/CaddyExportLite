using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data;

namespace CaddyExportLite.Tests
{
    [TestFixture]
    class ExportHandlerTests
    {
        [Test]
        public void GetExportString()
        {
            // Arrange
            string connectionString = @"Server=(LocalDB)\v11.0;Integrated Security=true;AttachDbFileName=E:\CaddyDatabase.mdf";
            IDbConnection dbconnection = new System.Data.SqlClient.SqlConnection(connectionString);
            dbconnection.Open();

            var componentUnderTest = new ExportHandler(dbconnection);

            // Act
            var results = componentUnderTest.FetchExportStringsForID(1);

            // Assert
            Assert.IsNotEmpty(results);
        }

        [Test]
        public void GetExportListing()
        {
            // Arrange
            string connectionString = @"Server=(LocalDB)\v11.0;Integrated Security=true;AttachDbFileName=E:\CaddyDatabase.mdf";
            IDbConnection dbconnection = new System.Data.SqlClient.SqlConnection(connectionString);
            dbconnection.Open();

            var componentUnderTest = new ExportHandler(dbconnection);

            // Act
            var results = componentUnderTest.FetchExportListing();

            // Assert
            Assert.IsNotEmpty(results);
        }
    }
}
