using System;
using SacherSolutions.Attributes;
using UnityEngine;

namespace SacherSolutions.Logging.Default
{
    public class SacherSolutionsLogProvider : LogProvider<DefaultLogType>
    {
        
    }

    [Serializable]
    public class SacherSolutionsLogger<TLogType> : ILogger where TLogType : Enum
    {
        [Header("Log Settings")]
        [SerializeField] private DefaultLogLevel logLevel;
        [SerializeField] private TLogType logType;
        [Header("Prefix")]
        [SerializeField] private Color prefixColor = Color.white;
        [SerializeField] private bool isDefaultLogger;

        public int LogLevel => Convert.ToInt32(logLevel);
        public int LogType => Convert.ToInt32(logType);
        public bool IsDefaultLogger => isDefaultLogger;
        
        public string HexPrefixColor => ColorUtility.ToHtmlStringRGBA(prefixColor);
        protected string LogTypePrefix => logType.ToString();
        
        public void Log(string message)
        {
            switch (logLevel)
            {
                case DefaultLogLevel.Log:
                    Debug.Log(FormatMessage(message));
                    break;
                case DefaultLogLevel.Warning:
                    Debug.LogWarning(FormatMessage(message));
                    break;
                case DefaultLogLevel.Error:
                    Debug.LogError(FormatMessage(message));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel));
            }
        }

        private string FormatMessage(string message)
        {
            #if UNITY_EDITOR
            return $"<color=#{HexPrefixColor}>{LogTypePrefix}</color>: {message}";
            #else
            return $"{LogTypePrefix}: {message}";
            #endif
        }
    }

    public enum DefaultLogLevel
    {
        Log,
        Warning,
        Error
    }
    
    public enum DefaultLogType
    {
        Default
    }
}