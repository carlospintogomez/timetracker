using System;

namespace timetracker
{
    public class SessionManager : ISessionManager
    {
        private IProcessSession _processSession;

        public SessionManager(IProcessSession processSession)
        {
            _processSession = processSession;
        }

        public IProcessSession SquashSession(IProcessSession processSession)
        {
            if (!_processSession.GetSessionName().Equals(processSession.GetSessionName()))
            {
                throw new InvalidOperationException("Cannot add two sessions have different process names");
            }

            var newSession = new ProcessSession(processSession.GetSessionName());
            newSession.SaveActiveTime(_processSession.GetActiveTime() + newSession.GetActiveTime());
            return newSession;
        }

        public IProcessSession GetSession()
        {
            return _processSession;
        }
    }
}
