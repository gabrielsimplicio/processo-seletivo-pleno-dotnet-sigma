using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoSigma.Domain.Entities;

namespace ProjetoSigma.Domain.Test
{
    [TestClass]
    public class MarcaTest
    {
        [TestMethod]
        public void MarcaInValido()
        {
            var marca = new MarcaDomain();
            Assert.IsTrue(marca.Validate());
        }

        [TestMethod]
        public void MarcaValido()
        {
            var marca = new MarcaDomain
            {
                Nome = "Marca test"
            };

            Assert.IsTrue(marca.Validate());
        }
    }
}
