namespace timetracker
{
    public interface ISessionLog
    {
        public void PersistSession(ISessionManager sessionManager);
    }
}