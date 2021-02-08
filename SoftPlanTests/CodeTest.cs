using CalcTest.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalcTest.Test
{
    [TestClass]
    public class CodeTest
    {
        private readonly CodeController _codeController;

        public CodeTest()
        {
            _codeController = new CodeController();
        }

        [TestMethod]
        public void Code_deveRetornarStringUrlValida()
        {
            var retorno = _codeController.GetUrlCode();
            Uri uriResult;

            Assert.IsTrue(Uri.TryCreate(retorno, UriKind.RelativeOrAbsolute, out uriResult));
        }
    }
}
