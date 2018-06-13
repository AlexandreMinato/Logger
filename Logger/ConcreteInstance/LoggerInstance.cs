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
        ProcessStatus _Status;


        private string _ApplicationName = "";
        private string _ProcessName = "";
        public ProcessStatus Status { get { return _Status; } protected set { } }
        public LoggerInstance()
        {
            
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");

            var config = builder.Build();


            if (config["ApplicationName"] == null || config["ProcessName"] == null)
            { 
                _Status = ProcessStatus.CONFIGURATION_ERROR;
                throw new KeyNotFoundException("Nome da aplicaçao ou rotina não configurado");
            }


            _ApplicationName = config["ApplicationName"];
            _ProcessName = config["ProcessName"];
            _Status = ProcessStatus.RUNNING;

            Writer.Write("I", _ProcessName, _ApplicationName);
        }


        

        

        public void Dispose()
        {
            string message = string.Format($"A rotina {_ProcessName} da Sigla {_ApplicationName}");


            string descricao = "sucesso";

           if (this.Status == ProcessStatus.FALIL)
            {
                descricao = "erro";
            }

            Writer.Write(Status.GetDescription(), $"Finalizou com {descricao}", _ApplicationName);
        }

        public void Log(LoggerLevel type, string Message)
        {
            if (type == LoggerLevel.CRITICAL_ERROR)
                _Status = ProcessStatus.FALIL;


            if (_Status != ProcessStatus.FALIL)
                _Status = ProcessStatus.SUCCESS;


            Writer.Write(type.GetDescription(), Message, _ApplicationName);
        }

        public void Log(string aplicacao, string nome, string Texto, string Informacao)
        {
            throw new NotSupportedException();
        }
    }
}
