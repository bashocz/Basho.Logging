using log4net;

namespace Basho.Logging
{
    public class Log : ILog
    {
        private const string LoggerName = "MyLogger";
        private readonly log4net.ILog _log;

        public Log()
            : this(GetLoggerName())
        {
        }

        private Log(string loggerName)
        {
            _log = LogManager.GetLogger(loggerName);
        }

        private static string GetLoggerName()
        {
            return LoggerName;
        }

        public void Debug(string message)
        {
            _log.Debug(message);
        }

        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Warn(string message)
        {
            _log.Warn(message);
        }

        public void Error(string message)
        {
            _log.Error(message);
        }

        public void Fatal(string message)
        {
            _log.Fatal(message);
        }
    }
}
