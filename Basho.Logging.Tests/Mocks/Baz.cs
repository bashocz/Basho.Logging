using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basho.Logging.Tests.Mocks
{
    class Baz
    {
        public readonly ILog<Baz> Log;

        public Baz(ILog<Baz> log)
        {
            if (log == null)
                throw new ArgumentNullException("log");
            Log = log;
        }
    }
}
