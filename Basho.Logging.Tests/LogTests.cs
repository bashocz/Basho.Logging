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

        public LoggingEvent DoLog(Action action)
        {
            lock (lockObject)
            {
                action();
                return _appender.GetEvents().LastOrDefault();
            }
        }

        public void VerifyLogEntry(string message, Type exType, Level level, string logger, LoggingEvent entry)
        {
            Assert.Equal(message, entry.RenderedMessage);
            if (exType == null)
                Assert.Null(entry.ExceptionObject);
            else
                Assert.IsType(exType, entry.ExceptionObject);
            Assert.Equal(level, entry.Level);
            Assert.Equal(logger, entry.LoggerName);
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
            var entry = _fixture.DoLog(() =>
            {
                Foo.Log.Debug("simple log");
            });

            _fixture.VerifyLogEntry("simple log", null, Level.Debug, "Basho.Logging.Tests.Mocks.Foo", entry);            
        }

        [Fact]
        public void DebugExceptionTest()
        {
            Exception ex = new ArgumentNullException("param");
            var entry = _fixture.DoLog(() =>
            {
                Foo.Log.Debug("simple log", ex);
            });

            _fixture.VerifyLogEntry("simple log", typeof(ArgumentNullException), Level.Debug, "Basho.Logging.Tests.Mocks.Foo", entry);
        }

        #endregion Debug methods

        #region Info methods

        [Fact]
        public void InfoTest()
        {
            var entry = _fixture.DoLog(() =>
            {
                Foo.Log.Info("simple log");
            });

            _fixture.VerifyLogEntry("simple log", null, Level.Info, "Basho.Logging.Tests.Mocks.Foo", entry);
        }

        [Fact]
        public void InfoExceptionTest()
        {
            Exception ex = new ArgumentNullException("param");
            var entry = _fixture.DoLog(() =>
            {
                Foo.Log.Info("simple log", ex);
            });

            _fixture.VerifyLogEntry("simple log", typeof(ArgumentNullException), Level.Info, "Basho.Logging.Tests.Mocks.Foo", entry);
        }

        #endregion Info methods

        #region Warn methods

        [Fact]
        public void WarnTest()
        {
            var entry = _fixture.DoLog(() =>
            {
                Foo.Log.Warn("simple log");
            });

            _fixture.VerifyLogEntry("simple log", null, Level.Warn, "Basho.Logging.Tests.Mocks.Foo", entry);
        }

        [Fact]
        public void WarnExceptionTest()
        {
            Exception ex = new ArgumentNullException("param");
            var entry = _fixture.DoLog(() =>
            {
                Foo.Log.Warn("simple log", ex);
            });

            _fixture.VerifyLogEntry("simple log", typeof(ArgumentNullException), Level.Warn, "Basho.Logging.Tests.Mocks.Foo", entry);
        }

        #endregion Warn methods

        #region Error methods

        [Fact]
        public void ErrorTest()
        {
            var entry = _fixture.DoLog(() =>
            {
                Foo.Log.Error("simple log");
            });

            _fixture.VerifyLogEntry("simple log", null, Level.Error, "Basho.Logging.Tests.Mocks.Foo", entry);
        }

        [Fact]
        public void ErrorExceptionTest()
        {
            Exception ex = new ArgumentNullException("param");
            var entry = _fixture.DoLog(() =>
            {
                Foo.Log.Error("simple log", ex);
            });

            _fixture.VerifyLogEntry("simple log", typeof(ArgumentNullException), Level.Error, "Basho.Logging.Tests.Mocks.Foo", entry);
        }

        #endregion Error methods

        #region Fatal methods

        [Fact]
        public void FatalTest()
        {
            var entry = _fixture.DoLog(() =>
            {
                Foo.Log.Fatal("simple log");
            });

            _fixture.VerifyLogEntry("simple log", null, Level.Fatal, "Basho.Logging.Tests.Mocks.Foo", entry);
        }

        [Fact]
        public void FatalExceptionTest()
        {
            Exception ex = new ArgumentNullException("param");
            var entry = _fixture.DoLog(() =>
            {
                Foo.Log.Fatal("simple log", ex);
            });

            _fixture.VerifyLogEntry("simple log", typeof(ArgumentNullException), Level.Fatal, "Basho.Logging.Tests.Mocks.Foo", entry);
        }

        #endregion Fatal methods
    }
}
