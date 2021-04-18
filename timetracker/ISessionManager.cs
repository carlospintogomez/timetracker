namespace timetracker
{
    public interface ISessionManager
    {
        public IProcessSession SquashSession(IProcessSession processSession);
        public IProcessSession GetSession();
    }
}
