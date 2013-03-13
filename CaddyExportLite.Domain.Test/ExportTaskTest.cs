using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaddyExportLite.Domain;
using NUnit.Framework;
using CaddyExportLite.Domain.Interfaces;

namespace CaddyExportLite.DomainTest
{
    [TestFixture]
    class ExportTaskTest
    {
        [Test]
        public void GetTaskIDFromDerivedReturnsPurchaseIDforPurchaseType()
        {
            //Arrange
            var sut = new PurchaseTask(0, 0, 1);
            //Act
            //Assert
            Assert.AreEqual(sut.TaskID, 1);
        }
        [Test]
        public void GetTaskIDFromBaseReturnsPurchaseIDforPurchaseType()
        {
            //Arrange
            var derived = new PurchaseTask(0, 0, 1);
            IExportTask sut = derived;
            //Act
            //Assert
            Assert.AreEqual(sut.TaskID, 1);
        }
    }
}
