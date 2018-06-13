using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Logger.Abstraction
{
    public enum LoggerLevel
    {
        [Description("A")]
        WARNING,

        [Description("M")]
        MESSAGE,

        [Description("E")]
        CRITICAL_ERROR

    }

    public enum ProcessStatus
    {
        
        NOT_STARTED = 0,
        RUNNING,

        [Description("S")]
        SUCCESS,

        [Description("F")]
        FALIL,

        CONFIGURATION_ERROR
    }
}
