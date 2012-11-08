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
            componentUnderTest.DoWork(aConnectionManager, aExportListing, aMYOBExportString, null);

            // Assert
            //Assert.IsNotEmpty(results);
        }
    }
}
