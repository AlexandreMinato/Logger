using Logger.Abstraction;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.ConcreteInstance
{
    public class LegacyInstanceItau : ILogger
    {
       
        public LegacyInstanceItau()
        {


            
        }

        public void Testar()
        { }

        public void Dispose()
        {
            //Marca Finalizado
            //Itau.Log("F", ApplicationName, routineName)
        }

        public void Log(LoggerLevel type, string Message)
        {
                        
        }

        public void Log(string aplicacao, string nome, string Texto, string Informacao)
        {
            Writer.Write(aplicacao, Texto, nome);

            //Console.WriteLine($"{aplicacao}, {nome}, {Texto} {Informacao}");
        }


    }
}
