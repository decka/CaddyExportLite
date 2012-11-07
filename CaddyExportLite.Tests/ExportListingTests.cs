using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data;
using CaddyExportLite;

namespace CaddyExportLite.Tests
{
    [TestFixture]
    class ExportListingTests
    {
        [Test]
        public void GetExportListing()
        {
            // Arrange
            var dbconnection = new DatabaseConnection();
            dbconnection.Open();
            var componentUnderTest = new ExportListing(dbconnection.connection);

            // Act
            var results = componentUnderTest.FetchExportListing();

            // Assert
            Assert.IsNotEmpty(results);
        }

    }
}
