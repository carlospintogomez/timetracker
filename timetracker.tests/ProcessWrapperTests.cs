using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace timetracker.tests
{
    [TestClass]
    public class ProcessWrapperTests
    {
        [DataRow(0)]
        [DataTestMethod]
        public void ProcessWrapper_EmptyArray_ReturnsNull(int numberOfProcesses)
        {
            // Arrange
            List<Process> processes = new List<Process>();

            // Act
            var processWrapper = new ProcessWrapper(processes.ToArray());

            // Assert
            Assert.IsNull(processWrapper.Process);
        }

        [DataRow(1)]
        [DataTestMethod]
        public void ProcessWrapper_SingleElementArray_ReturnsSingleElement(int numberOfProcesses)
        {
            // Arrange
            var process = new Process();
            List<Process> processes = new List<Process>
            {
                process
            };

            // Act
            var processWrapper = new ProcessWrapper(processes.ToArray());

            // Assert
            Assert.AreEqual(process, processWrapper.Process);
        }

        [DataRow(2)]
        [DataTestMethod]
        public void ProcessWrapper_AtLeastOneElementArray_ThrowsException(int numberOfProcesses)
        {
            // Arrange
            List<Process> processes = new List<Process>();
            for (int i = 0; i < numberOfProcesses; i++)
            {
                processes.Add(new Process());
            }

            // Act + Assert
            Assert.ThrowsException<InvalidOperationException>(()=> new ProcessWrapper(processes.ToArray()));
        }
    }
}
