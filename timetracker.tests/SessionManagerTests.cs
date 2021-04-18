using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace timetracker.tests
{
    [TestClass]
    public class SessionManagerTests
    {
        Mock<IProcessSession> processSessionMock;

        [TestInitialize()]
        public void Initialize()
        {
            processSessionMock = new Mock<IProcessSession>(MockBehavior.Strict);
            processSessionMock.Setup(m => m.GetSessionName()).Returns("session_name1");
            processSessionMock.Setup(m => m.GetActiveTime()).Returns(TimeSpan.FromSeconds(5));
        }

        [TestMethod]
        public void SquashSession_UnequalSessions_ThrowsException()
        {
            // Arrange
            var sessionManager = new SessionManager(processSessionMock.Object);
            Mock<IProcessSession> testSessionMock = new Mock<IProcessSession>(MockBehavior.Strict);
            testSessionMock.Setup(m => m.GetSessionName()).Returns("session_name2");

            // Act + Assert
            Assert.ThrowsException<InvalidOperationException>(() => sessionManager.SquashSession(testSessionMock.Object));
        }

        [TestMethod]
        public void SquashSession_ExistingSession_SuccessfulSquash()
        {
            // Arrange
            var sessionManager = new SessionManager(processSessionMock.Object);
            Mock<IProcessSession> testSessionMock = new Mock<IProcessSession>(MockBehavior.Strict);
            testSessionMock.Setup(m => m.GetSessionName()).Returns("session_name1");
            testSessionMock.Setup(m => m.GetActiveTime()).Returns(TimeSpan.FromSeconds(5));

            // Act
            var actualSession = sessionManager.SquashSession(testSessionMock.Object);

            // Assert
            Assert.AreEqual(TimeSpan.FromSeconds(5), actualSession.GetActiveTime());
        }
    }
}
