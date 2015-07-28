using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Basho.Logging.Tests.Mocks;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using Xunit;

namespace Basho.Logging.Tests
{
    public enum LevelTest
    {
        Debug,
        Info,
        Warn,
        Error,
        Fatal
    }

    public class Log4NetFixture
    {
        private static MemoryAppender _appender = null;

        private static readonly object LockObject = new object();

        private static readonly List<string> Args = new List<string>
        {
            "first", "second", "third", "fourth", "fifth",
            "sixth", "seventh", "eighth", "ninth", "tenth",
            "eleventh", "twelfth", "thirteenth", "fourteenth", "fifteenth",
            "sixteenth"
        };

        public Log4NetFixture()
        {
            _appender = new MemoryAppender();
            BasicConfigurator.Configure(_appender);

            var repository = LogManager.GetRepository();
        }

        private LoggingEvent DoLog(Action action)
        {
            lock (LockObject)
            {
                action();
                return _appender.GetEvents().LastOrDefault();
            }
        }

        private void LogLevel(LevelTest level, string log)
        {
            switch (level)
            {
                case LevelTest.Debug:
                    Foo.Log.Debug(log);
                    break;
                case LevelTest.Info:
                    Foo.Log.Info(log);
                    break;
                case LevelTest.Warn:
                    Foo.Log.Warn(log);
                    break;
                case LevelTest.Error:
                    Foo.Log.Error(log);
                    break;
                case LevelTest.Fatal:
                    Foo.Log.Fatal(log);
                    break;
            }
        }

        private void LogExLevel(LevelTest level, string log, Exception ex)
        {
            switch (level)
            {
                case LevelTest.Debug:
                    Foo.Log.Debug(log, ex);
                    break;
                case LevelTest.Info:
                    Foo.Log.Info(log, ex);
                    break;
                case LevelTest.Warn:
                    Foo.Log.Warn(log, ex);
                    break;
                case LevelTest.Error:
                    Foo.Log.Error(log, ex);
                    break;
                case LevelTest.Fatal:
                    Foo.Log.Fatal(log, ex);
                    break;
            }
        }

        private void LogFormatLevel(LevelTest level, string log, int formatN, int paramsN)
        {
            string format = GetLogFormatString(log, formatN);
            switch (level)
            {
                case LevelTest.Debug:
                    switch (paramsN)
                    {
                        case 1:
                            Foo.Log.DebugFormat(format, Args[0]);
                            break;
                        case 2:
                            Foo.Log.DebugFormat(format, Args[0], Args[1]);
                            break;
                        case 3:
                            Foo.Log.DebugFormat(format, Args[0], Args[1], Args[2]);
                            break;
                        case 4:
                            Foo.Log.DebugFormat(format, Args[0], Args[1], Args[2], Args[3]);
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    break;
                case LevelTest.Info:
                    switch (paramsN)
                    {
                        case 1:
                            Foo.Log.InfoFormat(format, Args[0]);
                            break;
                        case 2:
                            Foo.Log.InfoFormat(format, Args[0], Args[1]);
                            break;
                        case 3:
                            Foo.Log.InfoFormat(format, Args[0], Args[1], Args[2]);
                            break;
                        case 4:
                            Foo.Log.InfoFormat(format, Args[0], Args[1], Args[2], Args[3]);
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    break;
                case LevelTest.Warn:
                    switch (paramsN)
                    {
                        case 1:
                            Foo.Log.WarnFormat(format, Args[0]);
                            break;
                        case 2:
                            Foo.Log.WarnFormat(format, Args[0], Args[1]);
                            break;
                        case 3:
                            Foo.Log.WarnFormat(format, Args[0], Args[1], Args[2]);
                            break;
                        case 4:
                            Foo.Log.WarnFormat(format, Args[0], Args[1], Args[2], Args[3]);
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    break;
                case LevelTest.Error:
                    switch (paramsN)
                    {
                        case 1:
                            Foo.Log.ErrorFormat(format, Args[0]);
                            break;
                        case 2:
                            Foo.Log.ErrorFormat(format, Args[0], Args[1]);
                            break;
                        case 3:
                            Foo.Log.ErrorFormat(format, Args[0], Args[1], Args[2]);
                            break;
                        case 4:
                            Foo.Log.ErrorFormat(format, Args[0], Args[1], Args[2], Args[3]);
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    break;
                case LevelTest.Fatal:
                    switch (paramsN)
                    {
                        case 1:
                            Foo.Log.FatalFormat(format, Args[0]);
                            break;
                        case 2:
                            Foo.Log.FatalFormat(format, Args[0], Args[1]);
                            break;
                        case 3:
                            Foo.Log.FatalFormat(format, Args[0], Args[1], Args[2]);
                            break;
                        case 4:
                            Foo.Log.FatalFormat(format, Args[0], Args[1], Args[2], Args[3]);
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    break;
            }
        }

        private string GetLogFormatString(string log, int n)
        {
            StringBuilder args = new StringBuilder();
            args.Append("{0}");
            for (int i = 1; i < n; i++)
                args.Append(string.Format(",{{{0}}}", i));
            return log + args;
        }

        private Level ToLevel(LevelTest level)
        {
            switch (level)
            {
                case LevelTest.Debug:
                    return Level.Debug;
                case LevelTest.Info:
                    return Level.Info;
                case LevelTest.Warn:
                    return Level.Warn;
                case LevelTest.Error:
                    return Level.Error;
                case LevelTest.Fatal:
                    return Level.Fatal;
                default:
                    throw new NotImplementedException();
            }
        }

        private void VerifyBasisLogEntry(LevelTest level, string message, string logger, LoggingEvent entry)
        {
            Assert.Equal(message, entry.RenderedMessage);
            Assert.Equal(ToLevel(level), entry.Level);
            Assert.Equal(logger, entry.LoggerName);
        }

        private void VerifyLogEntry(LevelTest level, string message, string logger, LoggingEvent entry)
        {
            VerifyBasisLogEntry(level, message, logger, entry);

            Assert.Null(entry.ExceptionObject);

            Assert.NotNull(entry.Properties["MemberName"]);
            Assert.Equal("LogLevel", entry.Properties["MemberName"]);
        }

        private void VerifyExLogEntry(LevelTest level, string message, Type exType, string logger, LoggingEvent entry)
        {
            VerifyBasisLogEntry(level, message, logger, entry);

            Assert.IsType(exType, entry.ExceptionObject);

            Assert.NotNull(entry.Properties["MemberName"]);
            Assert.Equal("LogExLevel", entry.Properties["MemberName"]);
        }

        private void VerifyFormatLogEntry(LevelTest level, string message, string logger, LoggingEvent entry)
        {
            VerifyBasisLogEntry(level, message, logger, entry);

            Assert.Null(entry.ExceptionObject);
        }

        public void TestLog(LevelTest level)
        {
            var entry = DoLog(() =>
            {
                LogLevel(level, "simple log");
            });

            VerifyLogEntry(level, "simple log", "Basho.Logging.Tests.Mocks.Foo", entry);
        }

        public void TestExceptionLog(LevelTest level)
        {
            var entry = DoLog(() =>
            {
                LogExLevel(level, "simple log", new ArgumentNullException("param"));
            });

            VerifyExLogEntry(level, "simple log", typeof(ArgumentNullException), "Basho.Logging.Tests.Mocks.Foo", entry);
        }

        public void TestFormatLog(LevelTest level, int formatN, int paramsN)
        {
            var entry = DoLog(() =>
            {
                LogFormatLevel(level, "format log:", formatN, paramsN);
            });

            VerifyFormatLogEntry(level, "format log:" + string.Join(",", Args.Take(formatN)), "Basho.Logging.Tests.Mocks.Foo", entry);
        }
    }

    public class LogTests : IClassFixture<Log4NetFixture>
    {
        public readonly Log4NetFixture _fixture;

        public LogTests(Log4NetFixture fixture)
        {
            _fixture = fixture;
        }

        #region ctor tests

        [Fact]
        public void CtorLogTest()
        {
            var foo = new Foo();

            Assert.NotNull(LogManager.GetLogger(foo.GetType().Name));
        }

        [Fact]
        public void CtorLogOfTTest()
        {
            var bar = new Bar();

            Assert.NotNull(LogManager.GetLogger(bar.GetType().Name));
        }

        [Fact]
        public void CtorLogOfTDerivedFromLogTest()
        {
            var fooBar = new FooBar();

            Assert.NotNull(LogManager.GetLogger(fooBar.GetType().Name));
        }

        [Fact]
        public void CtorLogOfTDiReadyTest()
        {
            var log = new Log<Baz>();
            var baz = new Baz(log);

            Assert.NotNull(baz.Log);
            Assert.NotNull(LogManager.GetLogger(baz.GetType().Name));
        }

        #endregion ctor tests

        #region Log methods

        [Theory]
        [InlineData(LevelTest.Debug)]
        [InlineData(LevelTest.Info)]
        [InlineData(LevelTest.Warn)]
        [InlineData(LevelTest.Error)]
        [InlineData(LevelTest.Fatal)]
        public void LogTest(LevelTest level)
        {
            _fixture.TestLog(level);
        }

        [Theory]
        [InlineData(LevelTest.Debug)]
        [InlineData(LevelTest.Info)]
        [InlineData(LevelTest.Warn)]
        [InlineData(LevelTest.Error)]
        [InlineData(LevelTest.Fatal)]
        public void LogExceptionTest(LevelTest level)
        {
            _fixture.TestExceptionLog(level);
        }


        [Theory]
        [InlineData(LevelTest.Debug, 1, 1)]
        [InlineData(LevelTest.Debug, 2, 2)]
        [InlineData(LevelTest.Debug, 3, 3)]
        [InlineData(LevelTest.Debug, 4, 4)]
        [InlineData(LevelTest.Debug, 1, 4)]
        [InlineData(LevelTest.Debug, 3, 4)]

        [InlineData(LevelTest.Info, 1, 1)]
        [InlineData(LevelTest.Info, 2, 2)]
        [InlineData(LevelTest.Info, 3, 3)]
        [InlineData(LevelTest.Info, 4, 4)]
        [InlineData(LevelTest.Info, 1, 4)]
        [InlineData(LevelTest.Info, 3, 4)]

        [InlineData(LevelTest.Warn, 1, 1)]
        [InlineData(LevelTest.Warn, 2, 2)]
        [InlineData(LevelTest.Warn, 3, 3)]
        [InlineData(LevelTest.Warn, 4, 4)]
        [InlineData(LevelTest.Warn, 1, 4)]
        [InlineData(LevelTest.Warn, 3, 4)]

        [InlineData(LevelTest.Error, 1, 1)]
        [InlineData(LevelTest.Error, 2, 2)]
        [InlineData(LevelTest.Error, 3, 3)]
        [InlineData(LevelTest.Error, 4, 4)]
        [InlineData(LevelTest.Error, 1, 4)]
        [InlineData(LevelTest.Error, 3, 4)]

        [InlineData(LevelTest.Fatal, 1, 1)]
        [InlineData(LevelTest.Fatal, 2, 2)]
        [InlineData(LevelTest.Fatal, 3, 3)]
        [InlineData(LevelTest.Fatal, 4, 4)]
        [InlineData(LevelTest.Fatal, 1, 4)]
        [InlineData(LevelTest.Fatal, 3, 4)]
        public void LogFormatTest(LevelTest level, int formatN, int paramsN)
        {
            _fixture.TestFormatLog(level, formatN, paramsN);
        }
        #endregion Log methods
    }
}
