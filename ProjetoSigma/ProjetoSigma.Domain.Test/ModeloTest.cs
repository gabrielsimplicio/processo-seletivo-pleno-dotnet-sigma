using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoSigma.Domain.Entities;

namespace ProjetoSigma.Domain.Test
{
    [TestClass]
    public class ModeloTest
    {
        [TestMethod]
        public void ModeloInValido()
        {
            var modelo = new ModeloDomain();
            Assert.IsTrue(modelo.Validate());
        }

        [TestMethod]
        public void ModeloValido()
        {
            var modelo = new ModeloDomain
            {
                Nome = "Modelo test"
            };

            Assert.IsTrue(modelo.Validate());
        }
    }
}