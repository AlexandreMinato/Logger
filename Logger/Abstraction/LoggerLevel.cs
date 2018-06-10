using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Logger.Abstraction
{
    public enum LoggerLevel
    {
        [Description("A")]
        Aviso,

        [Description("M")]
        Mensagem,

        [Description("E")]
        Erro

    }
}
