using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace timetracker.tests
{
    [TestClass]
    public class ProcessSessionsTests
    {
        [TestMethod]
        public void SaveActiveTime_NoInitialActiveTime_ActiveTimeIsEqual()
        {
            // Arrange
            var processSession = new ProcessSession("test_process"); 

            // Act
            processSession.SaveActiveTime(TimeSpan.FromSeconds(5));

            // Assert
            Assert.IsTrue(processSession.GetActiveTime() == TimeSpan.FromSeconds(5));
        }

        [TestMethod]
        public void SaveActiveTime_SomeActiveTimeExists_ActiveTimeIsEqual()
        {
            // Arrange
            var processSession = new ProcessSession("test_process");
            processSession.SaveActiveTime(TimeSpan.FromSeconds(5));

            // Assume
            Assert.IsTrue(processSession.GetActiveTime() == TimeSpan.FromSeconds(5));

            // Act
            processSession.SaveActiveTime(TimeSpan.FromSeconds(5));

            // Assert
            Assert.IsTrue(processSession.GetActiveTime() == TimeSpan.FromSeconds(10));
        }
    }
}
