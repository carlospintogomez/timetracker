using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace timetracker.tests
{
    [TestClass]
    public class ProcessSessionsTests
    {
        Mock<IProcessManager> processManagerMock;

        [TestInitialize()]
        public void Initialize()
        {
            processManagerMock = new Mock<IProcessManager>(MockBehavior.Strict);
        }

        [TestMethod]
        public void SaveActiveTime_KeyInexistant_AddNewEntry()
        {
            // Arrange
            var processName = "test_process";
            processManagerMock.Setup(m => m.ComputeActiveTime()).Returns(TimeSpan.FromSeconds(5));
            var processSession = new ProcessSession(processManagerMock.Object); 

            // Act
            processSession.SaveActiveTime(processName);

            // Assert
            Assert.IsTrue(processSession.TimeLogDictionary[processName] == TimeSpan.FromSeconds(5));
        }

        [TestMethod]
        public void SaveActiveTime_KeyExistant_UpdateEntry()
        {
            // Arrange
            var processName = "test_process";
            processManagerMock.Setup(m => m.ComputeActiveTime()).Returns(TimeSpan.FromSeconds(5));
            var processSession = new ProcessSession(processManagerMock.Object);
            processSession.SaveActiveTime(processName);

            // Assume
            Assert.IsTrue(processSession.TimeLogDictionary[processName] == TimeSpan.FromSeconds(5));

            // Act
            processSession.SaveActiveTime(processName);

            // Act
            Assert.IsTrue(processSession.TimeLogDictionary[processName] == TimeSpan.FromSeconds(10));
        }
    }
}
