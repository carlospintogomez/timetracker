using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace timetracker.tests
{
    [TestClass]
    public class ProcessSessionsTests
    {
        [TestMethod]
        public void AddActiveTime_NoInitialActiveTime_ActiveTimeIsEqual()
        {
            // Arrange
            var processSession = new ProcessSession("test_process"); 

            // Act
            processSession.AddActiveTime(TimeSpan.FromSeconds(5));

            // Assert
            Assert.IsTrue(processSession.GetActiveTime() == TimeSpan.FromSeconds(5));
        }

        [TestMethod]
        public void AddActiveTime_SomeActiveTimeExists_ActiveTimeIsEqual()
        {
            // Arrange
            var processSession = new ProcessSession("test_process");
            processSession.AddActiveTime(TimeSpan.FromSeconds(5));

            // Assume
            Assert.IsTrue(processSession.GetActiveTime() == TimeSpan.FromSeconds(5));

            // Act
            processSession.AddActiveTime(TimeSpan.FromSeconds(5));

            // Assert
            Assert.IsTrue(processSession.GetActiveTime() == TimeSpan.FromSeconds(10));
        }
    }
}
