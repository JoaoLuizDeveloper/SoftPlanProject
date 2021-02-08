using CalcTest.API.Controllers;
using CalcTest.API.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalcTest.Test
{
    [TestClass]
    public class CalcTestTest
    {
        private readonly CalcTestController _calcTestController;

        public CalcTestTest()
        {
            _calcTestController = new CalcTestController();
        }

        [TestMethod]
        public void CalcTest_deveRetornarStringValida()
        {
            var retorno = _calcTestController.CalculaJuros(0, 2);

            Assert.IsTrue(!string.IsNullOrEmpty(retorno));
        }

        [TestMethod]
        public void CalcTest_deveRetornarValorIgualAZero()
        {
            var retorno = _calcTestController.CalculaJuros(0, 5);

            Assert.AreEqual(decimal.Zero, decimal.Parse(retorno));
        }

        [TestMethod]
        [ExpectedException(typeof(DoubleInvalidoException))]
        public void CalcTest_deveRetornarExceptionDoubleInifinito()
        {
            var retorno = _calcTestController.CalculaJuros(100, 99999);
        }

        [TestMethod]
        [DataRow("-1", 10)]
        [DataRow("130,45", -5)]
        [ExpectedException(typeof(ParametrosInvalidosException))]
        public void CalcTest_deveRetornarExceptionParametrosInvalidos(string valorInicial, int meses)
        {
            var retorno = _calcTestController.CalculaJuros(decimal.Parse(valorInicial), meses);
        }
    }
}
