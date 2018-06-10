using Logger.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Extension
{
    public static class LoggerExtension
    {
        public static ILogger AddLegacyFormater(this ILogger loggerInstance, string ApplicationName, string RoutineName)
        {

            return loggerInstance;
        }
    }

    
}
