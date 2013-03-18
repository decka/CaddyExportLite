using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaddyExportLite.Domain;
using NUnit.Framework;
using CaddyExportLite.Domain.Interfaces;
using CaddyExportLite.DAL;
using Moq;

namespace CaddyExportLite.DomainTest
{
    [TestFixture]
    class ExportTaskTest
    {
        [Test]
        public void ExportIDReturnsAssignedValue()
        {
            //Arrange
            var sut = new PurchaseTask(ExportID: 0, CaddyID: 0, PurchaseID: 0, Repo: null);
            //Act
            //Assert
            Assert.AreEqual(sut.ExportID, 0);
        }
        [Test]
        public void ExportIDReturnsAssignedValue2()
        {
            //Arrange
            var sut = new PurchaseTask(ExportID: 1, CaddyID: 0, PurchaseID: 0, Repo: null);
            //Act
            //Assert
            Assert.AreEqual(sut.ExportID, 1);
        }
        [Test]
        public void CaddyIDReturnsAssignedValue()
        {
            //Arrange
            var sut = new PurchaseTask(ExportID: 0, CaddyID: 2, PurchaseID: 0, Repo: null);
            //Act
            //Assert
            Assert.AreEqual(sut.CaddyID, 2);
        }
        [Test]
        public void CaddyIDReturnsAssignedValue2()
        {
            //Arrange
            var sut = new PurchaseTask(ExportID: 0, CaddyID: 3, PurchaseID: 0, Repo: null);
            //Act
            //Assert
            Assert.AreEqual(sut.CaddyID, 3);
        }
        [Test]
        public void GetExportStringsWithPurchaseIDZeroReturnsException()
        {
            //Arrange
            var sut = new PurchaseTask(ExportID: 0, CaddyID: 0, PurchaseID: 0, Repo: null);
            //Act
            sut.PurchaseID = 0;
            //Assert
            Assert.Throws<ArgumentException>(() => sut.GetExportStrings());
        }
        [Test]
        public void GetExportStringsWithPurchaseIDLessThanZeroReturnsException()
        {
            //Arrange
            var sut = new PurchaseTask(ExportID: 0, CaddyID: 0, PurchaseID: 0, Repo: null);
            //Act
            sut.PurchaseID = -1;
            //Assert
            Assert.Throws<ArgumentException>(() => sut.GetExportStrings());
        }
        [Test]
        public void GetExportStringsContainsTestString()
        {
            //Arrange
            var exportStub = new Mock<IExportRepository>();
            exportStub.Setup(_ => _.FetchPurchaseExportStringsForPurchaseID(It.IsAny<int>())).Returns(new List<string> { "Test", "Test2" } );
            var sut = new PurchaseTask(ExportID: 0, CaddyID: 0, PurchaseID: 1, Repo: exportStub.Object);
            //Act
            var strings = sut.GetExportStrings();
            //Assert
            CollectionAssert.Contains(strings, "Test");
        }
        [Test]
        public void GetExportStringsContainsTestString2()
        {
            //Arrange
            var exportStub = new Mock<IExportRepository>();
            exportStub.Setup(_ => _.FetchPurchaseExportStringsForPurchaseID(It.IsAny<int>())).Returns(new List<string> { "Test", "Test2" });
            var sut = new PurchaseTask(ExportID: 0, CaddyID: 0, PurchaseID: 1, Repo: exportStub.Object);
            //Act
            var strings = sut.GetExportStrings();
            //Assert
            CollectionAssert.Contains(strings, "Test2");
        }
        [Test]
        public void GetExportStringsReturnsEmptyCollection()
        {
            //Arrange
            var exportStub = new Mock<IExportRepository>();
            exportStub.Setup(_ => _.FetchPurchaseExportStringsForPurchaseID(It.IsAny<int>())).Returns(new List<string>());
            var sut = new PurchaseTask(ExportID: 0, CaddyID: 0, PurchaseID: 1, Repo: exportStub.Object);
            //Act
            var strings = sut.GetExportStrings();
            //Assert
            CollectionAssert.IsEmpty(strings);
        }
    }
}
