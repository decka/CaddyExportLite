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
    class MYOBExportStringTests
    {
        [Test]
        public void GetExportString()
        {
            // Arrange
            var dbconnection = new DatabaseConnection();
            dbconnection.Open();
            var componentUnderTest = new MYOBExportString(dbconnection.connection);

            // Act
            var results = componentUnderTest.FetchExportStringsForID(1);

            // Assert
            Assert.IsNotEmpty(results);
  
        }
    }
}
