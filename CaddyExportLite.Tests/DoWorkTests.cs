using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data;
using CaddyExportLite;
using SignalR.Hubs;
using SignalR;
using Moq;

namespace CaddyExportLite.Tests
{
    [TestFixture]
    class DoWorkTests
    {
        [Test]
        public void DoWork()
        {
            // Arrange
            string connectionString = @"Data Source=sqlsvr4.apexhost.net.au;Initial Catalog=construc_1;User ID=construc_usr;";
            IDbConnection dbconnection = new System.Data.SqlClient.SqlConnection(connectionString);

            IExportRepository aExportHandler = new SQLExportRepository(dbconnection);
            IConnectionManager aConnectionManager = new ConnectionManager();
            ICanSendStringToClient aStringSender = new ConsoleStringSender();

            var componentUnderTest = new Worker(aConnectionManager, aExportHandler, aStringSender);

            // Act
            aConnectionManager.AddConnection("FakeSignalRConnectionID", 0);
            aConnectionManager.SetCaddyID("FakeSignalRConnectionID", 1);

            componentUnderTest.DoWork();
            System.Threading.Thread.Sleep(3000);

            // Assert
            //Assert.IsNotEmpty(results);
       
        }
    }
}
