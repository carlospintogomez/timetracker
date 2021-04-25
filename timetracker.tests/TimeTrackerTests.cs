using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace timetracker.tests
{
    [TestClass]
    public class TimeTrackerTests
    {
        [TestMethod]
        public void ProcessStarted_ActiveTimeIsValid()
        {
            var timeTracker = new TimeTracker();
            timeTracker.StartTimeTracker(new List<string> { "test" });
        }
    }
}
