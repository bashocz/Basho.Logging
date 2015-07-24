using System;
using System.Text;
using System.Collections.Generic;
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

        public Log4NetFixture()
        {
            _appender = new MemoryAppender();
            BasicConfigurator.Configure(_appender);

            var repository = LogManager.GetRepository();
            repository.Threshold = Level.Debug;
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
    }
}
