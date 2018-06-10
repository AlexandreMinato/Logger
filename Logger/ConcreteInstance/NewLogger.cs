using Logger.Abstraction;
using System;
using Logger.Extension;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Logger.ConcreteInstance
{
    public class ItauBatchLogger : ILogger
    {
        private bool _erro = false;
        private string _ApplicationName = "";
        private string _RoutineName = "";
        public ItauBatchLogger()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            var config = builder.Build();

            _ApplicationName = config["ApplicationName"];
            _RoutineName = config["RoutineName"];


            Writer.Write("I", _RoutineName, _ApplicationName);

        }

        public void Dispose()
        {

            string message = string.Format($"A rotina {_RoutineName} da Sigla {_ApplicationName}");


            string tipoFinalizacao = "S";
            string descricao = "sucesso";

            if (_erro)
            {
                tipoFinalizacao = "E";
                descricao = "erro";
            }

            Writer.Write(tipoFinalizacao, $"Finalizou com {descricao}", _ApplicationName);

        }
        public void Log(LoggerLevel type, string Message)
        {
            if (type == LoggerLevel.Erro)
                _erro = true;
            
            
            Writer.Write(type.GetDescription(), Message, _ApplicationName);
            
            
        }

        [Obsolete("O metodo esta obsoleto.", true)]
        public void Log(string aplicacao, string nome, string Texto, string Informacao)
        {
            throw new NotSupportedException();
        }

        

    }
}
