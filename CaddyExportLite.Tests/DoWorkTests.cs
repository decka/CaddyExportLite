using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data;
using CaddyExportLite;
using SignalR.Hubs;

namespace CaddyExportLite.Tests
{
    [TestFixture]
    class DoWorkTests
    {
        [Test]
        public void DoWork()
        {
            // Arrange
            var dbconnection = new DatabaseConnection();
            dbconnection.Open();

            IExportListing aExportListing = new ExportListing(dbconnection.connection);
            IMYOBExportString aMYOBExportString = new MYOBExportString(dbconnection.connection);
            ConnectionManager aConnectionManager = new ConnectionManager();
            
            var componentUnderTest = new Worker();

            // Act
            aConnectionManager.AddConnection("FakeSignalRConnectionID");
            aConnectionManager.SetClientGUID("FakeSignalRConnectionID", "226d7253-012a-457c-b98c-f3e82e0d7bf3");

            componentUnderTest.DoWork(aConnectionManager, aExportListing, aMYOBExportString, null);

            // Assert
            //Assert.IsNotEmpty(results);
        }
    }
}
