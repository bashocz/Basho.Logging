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

        private static object lockObject = new object();

        public Log4NetFixture()
        {
            _appender = new MemoryAppender();
            BasicConfigurator.Configure(_appender);

            var repository = LogManager.GetRepository();
        }

        private LoggingEvent DoLog(Action action)
        {
            lock (lockObject)
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

        private void VerifyLogEntry(string message, LevelTest level, string logger, LoggingEvent entry)
        {
            Assert.Equal(message, entry.RenderedMessage);
            Assert.Null(entry.ExceptionObject);
            Assert.Equal(ToLevel(level), entry.Level);
            Assert.Equal(logger, entry.LoggerName);
        }

        private void VerifyExLogEntry(string message, Type exType, LevelTest level, string logger, LoggingEvent entry)
        {
            Assert.Equal(message, entry.RenderedMessage);
            Assert.IsType(exType, entry.ExceptionObject);
            Assert.Equal(ToLevel(level), entry.Level);
            Assert.Equal(logger, entry.LoggerName);
        }

        public void TestLog(LevelTest level)
        {
            var entry = DoLog(() =>
            {
                LogLevel(level, "simple log");
            });

            VerifyLogEntry("simple log", level, "Basho.Logging.Tests.Mocks.Foo", entry);
        }

        public void TestExceptionLog(LevelTest level)
        {
            var entry = DoLog(() =>
            {
                LogExLevel(level, "simple log", new ArgumentNullException("param"));
            });

            VerifyExLogEntry("simple log", typeof(ArgumentNullException), level, "Basho.Logging.Tests.Mocks.Foo", entry);
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
        public void DebugTest(LevelTest level)
        {
            _fixture.TestLog(level);
        }

        [Theory]
        [InlineData(LevelTest.Debug)]
        [InlineData(LevelTest.Info)]
        [InlineData(LevelTest.Warn)]
        [InlineData(LevelTest.Error)]
        [InlineData(LevelTest.Fatal)]
        public void DebugExceptionTest(LevelTest level)
        {
            _fixture.TestExceptionLog(level);
        }

        #endregion Log methods
    }
}
