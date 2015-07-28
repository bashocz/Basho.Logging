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
    public class Log4NetFixture
    {
        private static MemoryAppender _appender = null;

        private static object lockObject = new object();

        public Log4NetFixture()
        {
            _appender = new MemoryAppender();
            BasicConfigurator.Configure(_appender);

            var repository = LogManager.GetRepository();
            repository.Threshold = Level.Debug;
        }

        private LoggingEvent DoLog(Action action)
        {
            lock (lockObject)
            {
                action();
                return _appender.GetEvents().LastOrDefault();
            }
        }

        private void LogLevel(Level level, string log)
        {
            if (level == Level.Debug)
                Foo.Log.Debug(log);
            else if (level == Level.Info)
                Foo.Log.Info(log);
            else if (level == Level.Warn)
                Foo.Log.Warn(log);
            else if (level == Level.Error)
                Foo.Log.Error(log);
            else if (level == Level.Fatal)
                Foo.Log.Fatal(log);
        }

        private void LogExLevel(Level level, string log, Exception ex)
        {
            if (level == Level.Debug)
                Foo.Log.Debug(log, ex);
            else if (level == Level.Info)
                Foo.Log.Info(log, ex);
            else if (level == Level.Warn)
                Foo.Log.Warn(log, ex);
            else if (level == Level.Error)
                Foo.Log.Error(log, ex);
            else if (level == Level.Fatal)
                Foo.Log.Fatal(log, ex);
        }

        private void VerifyLogEntry(string message, Level level, string logger, LoggingEvent entry)
        {
            Assert.Equal(message, entry.RenderedMessage);
            Assert.Null(entry.ExceptionObject);
            Assert.Equal(level, entry.Level);
            Assert.Equal(logger, entry.LoggerName);
        }

        private void VerifyExLogEntry(string message, Type exType, Level level, string logger, LoggingEvent entry)
        {
            Assert.Equal(message, entry.RenderedMessage);
            Assert.IsType(exType, entry.ExceptionObject);
            Assert.Equal(level, entry.Level);
            Assert.Equal(logger, entry.LoggerName);
        }

        public void TestLog(Level level)
        {
            var entry = DoLog(() =>
            {
                LogLevel(level, "simple log");
            });

            VerifyLogEntry("simple log", level, "Basho.Logging.Tests.Mocks.Foo", entry);
        }

        public void TestExceptionLog(Level level)
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

        #region Debug methods

        [Fact]
        public void DebugTest()
        {
            _fixture.TestLog(Level.Debug);
        }

        [Fact]
        public void DebugExceptionTest()
        {
            _fixture.TestLog(Level.Debug);
        }

        #endregion Debug methods

        #region Info methods

        [Fact]
        public void InfoTest()
        {
            _fixture.TestLog(Level.Info);
        }

        [Fact]
        public void InfoExceptionTest()
        {
            _fixture.TestExceptionLog(Level.Info);
        }

        #endregion Info methods

        #region Warn methods

        [Fact]
        public void WarnTest()
        {
            _fixture.TestLog(Level.Warn);
        }

        [Fact]
        public void WarnExceptionTest()
        {
            _fixture.TestExceptionLog(Level.Warn);
        }

        #endregion Warn methods

        #region Error methods

        [Fact]
        public void ErrorTest()
        {
            _fixture.TestLog(Level.Error);
        }

        [Fact]
        public void ErrorExceptionTest()
        {
            _fixture.TestExceptionLog(Level.Error);
        }

        #endregion Error methods

        #region Fatal methods

        [Fact]
        public void FatalTest()
        {
            _fixture.TestLog(Level.Fatal);
        }

        [Fact]
        public void FatalExceptionTest()
        {
            _fixture.TestExceptionLog(Level.Fatal);
        }

        #endregion Fatal methods
    }
}
