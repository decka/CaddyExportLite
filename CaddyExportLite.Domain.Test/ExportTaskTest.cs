using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaddyExportLite.Domain;
using NUnit.Framework;

namespace CaddyExportLite.DomainTest
{
    [TestFixture]
    class ExportTaskTest
    {
        [Test]
        public void GetExportTypeReturnsAssignedValue()
        {
            //Arrange
            var sut = new ExportTask();
            var type = new ExportType();
            //Act
            sut.TaskType = type;
            //Assert
            Assert.AreEqual(sut.TaskType, type);
        }

        [Test]
        public void GetCaddyGUIDReturnsAssignedValue()
        {
            //Arrange
            var sut = new ExportTask();
            var testGUID = Guid.Parse("2e5ed860-82fe-4d65-9f39-94651c105159");
            //Act
            sut.CaddyGUID = testGUID;
            //Assert
            Assert.AreEqual(sut.CaddyGUID, testGUID);
        }

        [Test]
        public void GetCaddyGUIDReturnsAssignedValue2()
        {
            //Arrange
            var sut = new ExportTask();
            var testGUID = Guid.Parse("11c9bdf5-aa85-4d16-bc44-1b99aefe7c1c");
            //Act
            sut.CaddyGUID = testGUID;
            //Assert
            Assert.AreEqual(sut.CaddyGUID, testGUID);
        }
    }
}
