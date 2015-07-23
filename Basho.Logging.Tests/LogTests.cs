using System;
using System.Text;
using System.Collections.Generic;
using Basho.Logging.Tests.Mocks;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basho.Logging.Tests
{
    [TestClass]
    public class LogTests
    {
        #region initialization

        private static MemoryAppender _appender = null;

        [ClassInitialize]
        public static void LogTestsInitialize(TestContext testContext)
        {
            _appender = new MemoryAppender();
            BasicConfigurator.Configure(_appender);

            var repository = LogManager.GetRepository();
            repository.Threshold = Level.Debug;
        }

        [ClassCleanup]
        public static void LogTestsCleanup()
        {

        }

        #endregion initialization

        #region ctor tests

        [TestMethod]
        public void CtorLogTest()
        {
            var foo = new Foo();

            Assert.IsNotNull(LogManager.GetLogger(foo.GetType().Name));
        }

        [TestMethod]
        public void CtorLogOfTTest()
        {
            var bar = new Bar();

            Assert.IsNotNull(LogManager.GetLogger(bar.GetType().Name));
        }

        [TestMethod]
        public void CtorLogOfTDerivedeFromLogTest()
        {
            var fooBar = new FooBar();

            Assert.IsNotNull(LogManager.GetLogger(fooBar.GetType().Name));
        }

        [TestMethod]
        public void CtorLogOfTDiReadyTest()
        {
            var log = new Log<Baz>();
            var baz = new Baz(log);

            Assert.IsNotNull(baz.Log);
            Assert.IsNotNull(LogManager.GetLogger(baz.GetType().Name));
        }

        #endregion ctor tests
    }
}
