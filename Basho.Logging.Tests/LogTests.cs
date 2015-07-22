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

        [TestMethod]
        public void CtorTest()
        {
            Foo foo = new Foo();

            Assert.IsNotNull(LogManager.GetLogger(foo.GetType().Name));
        }
    }
}
