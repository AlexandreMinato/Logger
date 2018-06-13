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
        public void NewLogTestSuccess()
        {
            using (ILogger newLogger = LoggerFactory<LoggerInstance>.CreateInstace())
            {
                
                newLogger.Log(LoggerLevel.WARNING, "Mensagem 1");
                newLogger.Log(LoggerLevel.WARNING, "Mensagem 2");
                newLogger.Log(LoggerLevel.WARNING, "Mensagem 3");
                Assert.AreEqual(ProcessStatus.SUCCESS, newLogger.Status);

            }
        }


        public void NewLogTestFail()
        {
            using (ILogger newLogger = LoggerFactory<LoggerInstance>.CreateInstace())
            {

                newLogger.Log(LoggerLevel.WARNING, "Mensagem 1");
                newLogger.Log(LoggerLevel.CRITICAL_ERROR, "Mensagem 2");
                newLogger.Log(LoggerLevel.WARNING, "Mensagem 3");
                Assert.AreEqual(ProcessStatus.FALIL, newLogger.Status);

            }
        }

       

        [TestMethod]
        
        public void OldLogTest()
        {
            ILogger oldLogger = LoggerFactory<LegacyInstance>.CreateInstace();

            oldLogger.Log("I", "CD5", "CD5_ROTINA_1", "Iniciou o log");
            oldLogger.Log("A", "CD5", "Mensagem 1", "");
            oldLogger.Log("A", "CD5", "Mensagem 2", "");
            oldLogger.Log("E", "CD5", "Mensagem 3 com erro", "");
            oldLogger.Log("S", "CD5", "Finalizou com Sucesso", "");
        }
        [TestMethod]
        
        [ExpectedException(typeof(NotSupportedException),"O método antigo, não pode ser chamado em uma nova classe concreta.")]
        public void TryToUseOldMethodOnNewInstance()
        {
            using (ILogger _logNewInstance = LoggerFactory<LoggerInstance>.CreateInstace())
            {
                _logNewInstance.Log("I", "CD5", "CD5_ROTINA_1", "Iniciou o log");
            }

        }
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException), "O método novo, não pode ser chamado em uma classe concreta antiga.")]
        public void TryToUseNewMethodOnOldInstance()
        {
            ILogger _lodOldInstance = LoggerFactory<LegacyInstance>.CreateInstace();
            _lodOldInstance.Log(LoggerLevel.WARNING, "Mensagem 1");
            

        }
    }
}
