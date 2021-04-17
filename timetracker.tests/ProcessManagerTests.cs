using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace timetracker.tests
{
    [TestClass]
    public class ProcessManagerTests
    {
        Mock<IProcess> processMock;

        [TestInitialize()]
        public void Initialize()
        {
            processMock = new Mock<IProcess>(MockBehavior.Strict);
        }

        //TODO: potential flaky test since it's not deterministic
        [TestMethod]
        public void ComputeActiveTime_ValidProcess_IncreasesActiveTime()
        {
            // Arrange
            var time = 2000;
            processMock.Setup(m => m.IsActive()).Returns(true);
            processMock.Setup(m => m.HasExited()).Returns(false);
            var processManager = new ProcessManager(processMock.Object);
            var task = System.Threading.Tasks.Task.Run(() =>
            {
                // TODO: this prevents flakiness since CPU is faster than 1s. Not optimal.
                System.Threading.Thread.Sleep(time);
                processMock.Setup(m => m.IsActive()).Returns(false);
                processMock.Setup(m => m.HasExited()).Returns(true);
            });

            // Act
            var result = processManager.ComputeActiveTime();

            // Assert
            Assert.IsTrue(result.Ticks > TimeSpan.FromMilliseconds(time).Ticks);
        }
    }
}
