using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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

        private void SetContext(string sourceFilePath, int sourceLineNumber, string memberName)
        {
            LogicalThreadContext.Properties["SourceFilePath"] = sourceFilePath;
            LogicalThreadContext.Properties["SourceLineNumber"] = sourceLineNumber;
            LogicalThreadContext.Properties["MemberName"] = memberName;
        }



        public void Debug(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.Debug(message);
        }

        public void Debug(string message, Exception ex, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.Debug(message, ex);
        }

        public void DebugFormat(string format, object arg0, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.DebugFormat(format, arg0);
        }

        public void DebugFormat(string format, object arg0, object arg1, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.DebugFormat(format, arg0, arg1);            
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.DebugFormat(format, arg0, arg1, arg2);
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2, object arg3, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.DebugFormat(format, arg0, arg1, arg2, arg3);
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.DebugFormat(format, arg0, arg1, arg2, arg3, arg4);
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.DebugFormat(format, arg0, arg1, arg2, arg3, arg4, arg5);
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.DebugFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.DebugFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }



        public void Info(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.Info(message);
        }

        public void Info(string message, Exception ex, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.Info(message, ex);
        }

        public void InfoFormat(string format, object arg0, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.InfoFormat(format, arg0);
        }

        public void InfoFormat(string format, object arg0, object arg1, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.InfoFormat(format, arg0, arg1);
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.InfoFormat(format, arg0, arg1, arg2);
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2, object arg3, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.InfoFormat(format, arg0, arg1, arg2, arg3);
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.InfoFormat(format, arg0, arg1, arg2, arg3, arg4);
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.InfoFormat(format, arg0, arg1, arg2, arg3, arg4, arg5);
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.InfoFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.InfoFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }



        public void Warn(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.Warn(message);
        }

        public void Warn(string message, Exception ex, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.Warn(message, ex);
        }

        public void WarnFormat(string format, object arg0, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.WarnFormat(format, arg0);
        }

        public void WarnFormat(string format, object arg0, object arg1, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.WarnFormat(format, arg0, arg1);
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.WarnFormat(format, arg0, arg1, arg2);
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2, object arg3, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.WarnFormat(format, arg0, arg1, arg2, arg3);
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.WarnFormat(format, arg0, arg1, arg2, arg3, arg4);
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.WarnFormat(format, arg0, arg1, arg2, arg3, arg4, arg5);
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.WarnFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.WarnFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }



        public void Error(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.Error(message);
        }

        public void Error(string message, Exception ex, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.Error(message, ex);
        }

        public void ErrorFormat(string format, object arg0, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.ErrorFormat(format, arg0);
        }

        public void ErrorFormat(string format, object arg0, object arg1, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.ErrorFormat(format, arg0, arg1);
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.ErrorFormat(format, arg0, arg1, arg2);
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2, object arg3, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.ErrorFormat(format, arg0, arg1, arg2, arg3);
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.ErrorFormat(format, arg0, arg1, arg2, arg3, arg4);
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.ErrorFormat(format, arg0, arg1, arg2, arg3, arg4, arg5);
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.ErrorFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.ErrorFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }



        public void Fatal(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.Fatal(message);
        }

        public void Fatal(string message, Exception ex, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.Fatal(message, ex);
        }

        public void FatalFormat(string format, object arg0, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.FatalFormat(format, arg0);
        }

        public void FatalFormat(string format, object arg0, object arg1, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.FatalFormat(format, arg0, arg1);
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.FatalFormat(format, arg0, arg1, arg2);
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2, object arg3, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.FatalFormat(format, arg0, arg1, arg2, arg3);
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.FatalFormat(format, arg0, arg1, arg2, arg3, arg4);
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.FatalFormat(format, arg0, arg1, arg2, arg3, arg4, arg5);
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.FatalFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, LogFormatStyle style = LogFormatStyle.Normal, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetContext(sourceFilePath, sourceLineNumber, memberName);
            _log.FatalFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }
    }
}
