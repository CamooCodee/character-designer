namespace SacherSolutions.Logging
{
    public interface ILoggerProvider
    {
        public ILogger GetLogger(int level, int type);
        public ILogger GetDefaultLogger();
    }
}