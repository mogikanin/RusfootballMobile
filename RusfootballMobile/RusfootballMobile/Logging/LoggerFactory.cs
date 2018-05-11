using System;
using System.Diagnostics;

namespace RusfootballMobile.Logging
{
    internal static class LoggerFactory
    {
        public static ILogger GetLogger<T>()
        {
            return GetLogger(typeof(T));
        }

        public static ILogger GetLogger(Type type)
        {
            return new LoggerImpl(type.Name);
        }
    }

    public interface ILogger
    {
        void Info(string message);
        void Debug(string message);
        void Error(string message, Exception exception);
    }

    internal class LoggerImpl : ILogger
    {
        private readonly string _name;

        public LoggerImpl(string name)
        {
            _name = name;
        }

        public void Info(string message)
        {
            Trace.WriteLine($"[Rusfootball.Mobile] [{_name}] [Info] " + message);
        }

        public void Debug(string message)
        {
            System.Diagnostics.Debug.WriteLine($"[Rusfootball.Mobile] [{_name}] [Dbg] " + message);
        }

        public void Error(string message, Exception exception)
        {
            if (exception != null)
            {
                message += " Exception: " + exception;
            }

            Trace.WriteLine($"[Rusfootball.Mobile] [{_name}] [Err] " + message);
        }
    }
}
