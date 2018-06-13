using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Abstraction
{
    public interface ILogger : IDisposable
    {
        void Log(LoggerLevel type, string Message);

        [Obsolete("Este método está obsoleto, evite o uso desta sobrecarga, pode não haver compatibilidade nas próximas versões do ILogger.")]
        void Log(string aplicacao, string nome, string Texto, string Informacao);
    }
}
