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
            string connectionString = @"Server=(LocalDB)\v11.0;Integrated Security=true;AttachDbFileName=E:\CaddyDatabase.mdf";

            IDbConnection dbconnection = new System.Data.SqlClient.SqlConnection(connectionString);
            IExportHandler aExportHandler = new ExportHandler(dbconnection);
            IConnectionManager aConnectionManager = new ConnectionManager();
            ICanSendStringToClient aStringSender = new ConsoleStringSender();

            var componentUnderTest = new Worker(aConnectionManager, aExportHandler, aStringSender);

            // Act
            aConnectionManager.AddConnection("FakeSignalRConnectionID", null);
            aConnectionManager.SetClientGUID("FakeSignalRConnectionID", "226d7253-012a-457c-b98c-f3e82e0d7bf3");

            componentUnderTest.DoWork();

            // Assert
            //Assert.IsNotEmpty(results);
       
        }
    }
}
