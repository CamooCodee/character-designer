using System;

namespace SacherSolutions.Logging
{
    internal class LoggerException : Exception
    {
        public LoggerException(string message) : base(message)
        {
        }
    }
}