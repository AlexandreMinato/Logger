using Logger.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Logger
{
    public static class LoggerFactory<T> where T : ILogger, new()
    {
        public static ILogger CreateInstace()
        {
            return new T();

        }
    }
}
