using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab03
{
    public interface ILogger : IDisposable
    {
        void Log(params String[] messages);
    }
}
