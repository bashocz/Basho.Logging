using System;
using System.Diagnostics;
using log4net;

namespace Basho.Logging
{
    public class Log<T> : Log, ILog<T>
    {
        public Log()
            : base(typeof(T)) { }
    }

    public class Log : ILog
    {
        private readonly log4net.ILog _log;

        public Log()
            : this(GetLoggerName()) { }

        protected Log(Type callerType)
        {
            string loggerName = callerType.FullName;
            _log = LogManager.GetLogger(loggerName);
        }

        private static Type GetLoggerName()
        {
            var callerType = new StackFrame(2, false).GetMethod().DeclaringType;
            return callerType;
        }



        public void Debug(string message)
        {
            _log.Debug(message);
        }

        public void Debug(string message, Exception ex)
        {
            _log.Debug(message, ex);
        }




        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Info(string message, Exception ex)
        {
            _log.Info(message, ex);
        }




        public void Warn(string message)
        {
            _log.Warn(message);
        }

        public void Warn(string message, Exception ex)
        {
            _log.Warn(message, ex);
        }




        public void Error(string message)
        {
            _log.Error(message);
        }

        public void Error(string message, Exception ex)
        {
            _log.Error(message, ex);
        }




        public void Fatal(string message)
        {
            _log.Fatal(message);
        }

        public void Fatal(string message, Exception ex)
        {
            _log.Fatal(message, ex);
        }
    }
}
