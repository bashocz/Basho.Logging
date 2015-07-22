using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basho.Logging
{
    public interface ILog
    {
        void Debug(string message);
        Task DebugAsync(string message);

        void Info(string message);
        Task InfoAsync(string message);

        void Warn(string message);
        Task WarnAsync(string message);

        void Error(string message);
        Task ErrorAsync(string message);

        void Fatal(string message);
        Task FatalAsync(string message);
    }
}
