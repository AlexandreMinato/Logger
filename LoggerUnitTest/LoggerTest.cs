using Logger.Abstraction;
using Logger.ConcreteInstance;
using Logger.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LoggerUnitTest
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void NewLogTest()
        {
            using (ILogger logar = LoggerFactory<LoggerInstance>.CreateInstace())
            {
                logar.Log(LoggerLevel.WARNING, "Mensagem 1");
                logar.Log(LoggerLevel.WARNING, "Mensagem 2");
                logar.Log(LoggerLevel.CRITICAL_ERROR, "Mensagem 3 com erro");
            }
        }

        [TestMethod]
        
        public void OldLogTest()
        {
            ILogger logarAntigo = LoggerFactory<LegacyInstance>.CreateInstace();

            logarAntigo.Log("I", "CD5", "CD5_ROTINA_1", "Iniciou o log");
            logarAntigo.Log("A", "CD5", "Mensagem 1", "");
            logarAntigo.Log("A", "CD5", "Mensagem 2", "");
            logarAntigo.Log("E", "CD5", "Mensagem 3 com erro", "");
            logarAntigo.Log("S", "CD5", "Finalizou com Sucesso", "");
        }
        [TestMethod]
        
        [ExpectedException(typeof(NotSupportedException),"O novo metodo não pode ser usado em uma classe contreta antiga.")]
        public void TryToUseOldMethodOnNewInstance()
        {
            using (ILogger logar = LoggerFactory<LoggerInstance>.CreateInstace())
            {
                logar.Log("I", "CD5", "CD5_ROTINA_1", "Iniciou o log");
            }

        }
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException), "O metodo antigo não pode ser usado em uma classe contreta nova.")]
        public void TryToUseNewMethodOnOldInstance()
        {
            ILogger logar = LoggerFactory<LegacyInstance>.CreateInstace();
            logar.Log(LoggerLevel.WARNING, "Mensagem 1");
            

        }
    }
}
