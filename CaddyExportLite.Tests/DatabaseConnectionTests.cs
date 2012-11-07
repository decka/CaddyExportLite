using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NUnit.Framework;
using CaddyExportLite;


namespace CaddyExportLite.Tests
{
    [TestFixture]
    public class DatabaseConnectionTests
    {
        [Test]
        public void OpenDatabase()
        {
            //Arrange
            var componentUnderTest = new DatabaseConnection();
            
            //Act
            componentUnderTest.Open();

            //Assert
            Assert.AreEqual(componentUnderTest.Status(), ConnectionState.Open);
        }
    }
}

            //Arrange

            //Act

            //Assert
