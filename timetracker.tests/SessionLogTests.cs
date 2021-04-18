using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace timetracker.tests
{
    [TestClass]
    public class SessionLogTests
    {
        Mock<ISessionManager> sessionManagerMock;
        Mock<IProcessSession> processSessionMock;

        [TestInitialize()]
        public void Initialize()
        {
            sessionManagerMock = new Mock<ISessionManager>(MockBehavior.Strict);
            processSessionMock = new Mock<IProcessSession>(MockBehavior.Strict);
            sessionManagerMock.Setup(m => m.GetSession()).Returns(processSessionMock.Object);
        }

        [TestMethod]
        public void PersistSession_KeyInexistant_AddNewEntry()
        {
            // Arrange
            sessionManagerMock.Setup(m => m.SquashSession(It.IsAny<IProcessSession>())).Returns(processSessionMock.Object);
            var sessionLog = new SessionLog();

            // Act
            sessionLog.PersistSession(sessionManagerMock.Object);

            // Assert
            Assert.AreEqual(processSessionMock.Object, sessionLog.SessionLogDictionary[DateTime.Today]);
        }

        [TestMethod]
        public void PersistSession_KeyExistant_UpdateEntry()
        {
            // Arrange
            sessionManagerMock.Setup(m => m.SquashSession(It.IsAny<IProcessSession>())).Returns(processSessionMock.Object);
            var sessionLog = new SessionLog();
            sessionLog.PersistSession(sessionManagerMock.Object);

            // Assume
            Assert.AreEqual(processSessionMock.Object, sessionLog.SessionLogDictionary[DateTime.Today]);

            // Act
            sessionLog.PersistSession(sessionManagerMock.Object);

            // Assert
            Assert.AreEqual(processSessionMock.Object, sessionLog.SessionLogDictionary[DateTime.Today]);
        }
    }
}
