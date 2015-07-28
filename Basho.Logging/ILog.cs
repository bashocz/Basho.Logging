using System;

namespace Basho.Logging
{
    public interface ILog<T> : ILog { }

    public interface ILog
    {
        void Debug(string message);
        void Debug(string message, Exception ex);
        void DebugFormat(string format, object arg0);
        void DebugFormat(string format, object arg0, object arg1);
        void DebugFormat(string format, object arg0, object arg1, object arg2);
        void DebugFormat(string format, params object[] args);

        void Info(string message);
        void Info(string message, Exception ex);
        void InfoFormat(string format, object arg0);
        void InfoFormat(string format, object arg0, object arg1);
        void InfoFormat(string format, object arg0, object arg1, object arg2);
        void InfoFormat(string format, params object[] args);

        void Warn(string message);
        void Warn(string message, Exception ex);
        void WarnFormat(string format, object arg0);
        void WarnFormat(string format, object arg0, object arg1);
        void WarnFormat(string format, object arg0, object arg1, object arg2);
        void WarnFormat(string format, params object[] args);

        void Error(string message);
        void Error(string message, Exception ex);
        void ErrorFormat(string format, object arg0);
        void ErrorFormat(string format, object arg0, object arg1);
        void ErrorFormat(string format, object arg0, object arg1, object arg2);
        void ErrorFormat(string format, params object[] args);

        void Fatal(string message);
        void Fatal(string message, Exception ex);
        void FatalFormat(string format, object arg0);
        void FatalFormat(string format, object arg0, object arg1);
        void FatalFormat(string format, object arg0, object arg1, object arg2);
        void FatalFormat(string format, params object[] args);
    }
}
