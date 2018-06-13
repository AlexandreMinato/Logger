using Logger.Abstraction;
using Logger.ConcreteInstance;
using Logger.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoggerUnitTest
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void NewLogTest()
        {
            using (ILogger logar = LoggerFactory<ItauBatchLogger>.CreateInstace())
            {
                logar.Log(LoggerLevel.Aviso, "Mensagem 1");
                logar.Log(LoggerLevel.Aviso, "Mensagem 2");
                logar.Log(LoggerLevel.Erro, "Mensagem 3 com erro");
                logar.Log("", "", "", "");
            }
        }

        [TestMethod]
        public void OldLogTest()
        {
            ILogger logarAntigo = LoggerFactory<LegacyInstanceItau>.CreateInstace();

            logarAntigo.Log("I", "CD5", "CD5_ROTINA_1", "Iniciou o log");
            logarAntigo.Log("A", "CD5", "Mensagem 1", "");
            logarAntigo.Log("A", "CD5", "Mensagem 2", "");
            logarAntigo.Log("E", "CD5", "Mensagem 3 com erro", "");
            logarAntigo.Log("S", "CD5", "Finalizou com Sucesso", "");
        }


    }
}
