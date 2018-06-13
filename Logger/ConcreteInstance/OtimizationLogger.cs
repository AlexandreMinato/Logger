using Logger.Abstraction;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.ConcreteInstancez
{
    public class OtimizationLogger : ILogger
    {

        private List<Dictionary<LoggerLevel, string>> data = null;
        private int LoteSize = 30;
        private bool _erro = false;
        private string _ApplicationName = "";
        private string _RoutineName = "";
        public OtimizationLogger()
        {
            data = new List<Dictionary<LoggerLevel, string>>();
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

            foreach (var item in data)
            {
                
            }


            if (_erro)
            {
                tipoFinalizacao = "E";
                descricao = "erro";
            }

            Writer.Write(tipoFinalizacao, $"Finalizou com {descricao}", _ApplicationName);
        }

        public void Log(LoggerLevel type, string Message)
        {
            throw new NotImplementedException();
        }

        public void Log(string aplicacao, string nome, string Texto, string Informacao)
        {
            throw new NotImplementedException();
        }
    }
}
