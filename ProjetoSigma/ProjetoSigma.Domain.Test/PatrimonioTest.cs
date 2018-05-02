using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoSigma.Domain.Entities;

namespace ProjetoSigma.Domain.Test
{
    [TestClass]
    public class PatrimonioTest
    {
        [TestMethod]
        public void PatrimonioInValido()
        {
            var patrimonio = new PatrimonioDomain
            {
                Nome = "Monitor",
                Descricao = "BenQ 144hz"
            };
            
            Assert.IsTrue(patrimonio.Validate());
        }

        [TestMethod]
        public void PatrimonioValido()
        {
            var patrimonio = new PatrimonioDomain
            {
                Nome = "Monitor",
                Descricao = "BenQ 144hz",
                ModeloId = 1,
                MarcaId = 1,
                Tombo = GerarTombo()
            };

            Assert.IsTrue(patrimonio.Validate());
        }

        public string GerarTombo()
        {
            var prefix = "QWERTYUIOPASDFGHJKLZXCVBNM0123456789";
            var random = new Random();
            return DateTime.Today.Year + "." + new string(Enumerable.Repeat(prefix, prefix.Length - 5).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}