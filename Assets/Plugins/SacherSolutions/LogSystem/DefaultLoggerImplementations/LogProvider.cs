using System;
using System.Linq;
using UnityEngine;

namespace SacherSolutions.Logging.Default
{
    [DefaultExecutionOrder(-1001)]
    public abstract class LogProvider<TLogType> : MonoBehaviour, ILoggerProvider where TLogType : Enum
    {
        [SerializeField] private SacherSolutionsLogger<TLogType>[] loggers;

        private void Awake()
        {
            ValidateLoggers();
            Logger.SetLogProvider(this);
        }

        private void ValidateLoggers()
        {
            CheckForAnyDefaultLogger();
            CheckForDuplicateDefaultLogger();
        }

        private void CheckForAnyDefaultLogger()
        {
            if (!loggers.Any(l => l.IsDefaultLogger))
                throw new LoggerException("No default logger found. Please check one logger as default.");
        }

        private void CheckForDuplicateDefaultLogger()
        {
            if(loggers.Count(l => l.IsDefaultLogger) > 1)
                throw new LoggerException($"Duplicate default loggers found. This is not allowed. Please uncheck all but one default logger.");
        }
        
        public ILogger GetLogger(int level, int type)
        {
            if (TryGetLogger(level, type, out var logger))
                return logger;
            
            throw new LoggerException($"No logger found for level {level} and type {type}.");
        }
        
        public bool TryGetLogger(int level, int type, out ILogger logger)
        {
            logger = loggers.FirstOrDefault(l => l.LogLevel == level && l.LogType == type);
            return logger != null;
        }

        public ILogger GetDefaultLogger() => 
            loggers.First(l => l.IsDefaultLogger);
    }
}