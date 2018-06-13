using Logger.Abstraction;
using Logger.Extension;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.ConcreteInstance
{
    public class LoggerInstance : ILogger
    {
                
        private bool _erro = false;
        private string _ApplicationName = "";
        private string _ProcessName = "";
        public LoggerInstance()
        {
            
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");

            var config = builder.Build();

            _ApplicationName = config["ApplicationName"];
            _ProcessName = config["ProcessName"];


            Writer.Write("I", _ProcessName, _ApplicationName);
        }

        public void Dispose()
        {
            string message = string.Format($"A rotina {_ProcessName} da Sigla {_ApplicationName}");


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
            if (type == LoggerLevel.CRITICAL_ERROR)
                _erro = true;
            
            Writer.Write(type.GetDescription(), Message, _ApplicationName);
        }

        public void Log(string aplicacao, string nome, string Texto, string Informacao)
        {
            throw new NotSupportedException();
        }
    }
}
