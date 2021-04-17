namespace timetracker
{
    public interface IProcessSession
    {
        public void SaveActiveTime(string processName);
    }
}