using Logger.Abstraction;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.ConcreteInstance
{
    public class LegacyInstance : ILogger
    {
        

        public LegacyInstance()
        {


            
        }

        public ProcessStatus Status => throw new NotSupportedException();

        public void Dispose()
        {
            //Marca Finalizado
            //Itau.Log("F", ApplicationName, routineName)
        }

        public void Log(LoggerLevel type, string Message)
        {
            throw new NotSupportedException();
        }

        public void Log(string aplicacao, string nome, string Texto, string Informacao)
        {
            Writer.Write(aplicacao, Texto, nome);

            //Console.WriteLine($"{aplicacao}, {nome}, {Texto} {Informacao}");
        }


    }
}
