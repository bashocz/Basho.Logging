using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basho.Logging.Tests.Mocks
{
    class Foo
    {
        public static ILog Log = new Log();
    }
}
