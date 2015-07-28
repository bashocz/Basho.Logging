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

        public void DebugFormat(string format, object arg0)
        {
            _log.DebugFormat(format, arg0);
        }

        public void DebugFormat(string format, object arg0, object arg1)
        {
            _log.DebugFormat(format, arg0, arg1);            
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.DebugFormat(format, arg0, arg1, arg2);
        }

        public void DebugFormat(string format, params object[] args)
        {
            _log.DebugFormat(format, args);
        }



        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Info(string message, Exception ex)
        {
            _log.Info(message, ex);
        }

        public void InfoFormat(string format, object arg0)
        {
            _log.InfoFormat(format, arg0);
        }

        public void InfoFormat(string format, object arg0, object arg1)
        {
            _log.InfoFormat(format, arg0, arg1);
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.InfoFormat(format, arg0, arg1, arg2);
        }

        public void InfoFormat(string format, params object[] args)
        {
            _log.InfoFormat(format, args);
        }

        

        public void Warn(string message)
        {
            _log.Warn(message);
        }

        public void Warn(string message, Exception ex)
        {
            _log.Warn(message, ex);
        }

        public void WarnFormat(string format, object arg0)
        {
            _log.WarnFormat(format, arg0);
        }

        public void WarnFormat(string format, object arg0, object arg1)
        {
            _log.WarnFormat(format, arg0, arg1);
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.WarnFormat(format, arg0, arg1, arg2);
        }

        public void WarnFormat(string format, params object[] args)
        {
            _log.WarnFormat(format, args);
        }



        public void Error(string message)
        {
            _log.Error(message);
        }

        public void Error(string message, Exception ex)
        {
            _log.Error(message, ex);
        }

        public void ErrorFormat(string format, object arg0)
        {
            _log.ErrorFormat(format, arg0);
        }

        public void ErrorFormat(string format, object arg0, object arg1)
        {
            _log.ErrorFormat(format, arg0, arg1);
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.ErrorFormat(format, arg0, arg1, arg2);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            _log.ErrorFormat(format, args);
        }



        public void Fatal(string message)
        {
            _log.Fatal(message);
        }

        public void Fatal(string message, Exception ex)
        {
            _log.Fatal(message, ex);
        }

        public void FatalFormat(string format, object arg0)
        {
            _log.FatalFormat(format, arg0);
        }

        public void FatalFormat(string format, object arg0, object arg1)
        {
            _log.FatalFormat(format, arg0, arg1);
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.FatalFormat(format, arg0, arg1, arg2);
        }

        public void FatalFormat(string format, params object[] args)
        {
            _log.FatalFormat(format, args);
        }
    }
}
