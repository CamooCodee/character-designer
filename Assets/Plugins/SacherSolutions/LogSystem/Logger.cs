namespace SacherSolutions.Logging
{
    public static class Logger
    {
        private static ILoggerProvider provider;
        
        /// <summary>
        /// Sets the log provider. It's used whenever a message shall be logged. This is required to use the Logger.
        /// </summary>
        /// <param name="newProvider"></param>
        public static void SetLogProvider(ILoggerProvider newProvider) => 
            provider = newProvider;

        /// <summary>
        /// Gets the logger through the set Log Provider. Then logs the message with the provided Logger.
        /// </summary>
        /// <param name="level">The log level. (e.g. Log, Warning, Error)</param>
        /// <param name="type">The logger type, which can be used for different systems.</param>
        /// <param name="message">The message to log.</param>
        public static void Log(int level, int type, string message) => 
            GetLogger(level, type).Log(message);
        
        /// <inheritdoc cref="Log(int, int, string)"/>
        public static void LogType(int type, string message) => 
            GetLogger(0, type).Log(message);
        
        /// <inheritdoc cref="Log(int, int, string)"/>
        public static void LogLevel(int level, string message) => 
            GetLogger(level, 0).Log(message);
        
        /// <inheritdoc cref="Log(int, int, string)"/>
        /// Uses the default logger.
        public static void Log(string message) => 
            GetDefaultLogger().Log(message);

        private static ILogger GetLogger(int level, int type)
        {
            CheckProvider();
            return provider.GetLogger(level, type);
        }
        
        private static ILogger GetDefaultLogger()
        {
            CheckProvider();
            return provider.GetDefaultLogger();
        }
        
        private static void CheckProvider()
        {
            if (provider == null)
                throw new LoggerException(
                    $"No log provider set. Before logging, make sure to initialize the Logger with {nameof(SetLogProvider)}");
        }
    }
}