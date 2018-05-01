using System;
using MeuPatrimonio.Domain.Entities;
using MeuPatrimonio.Domain.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeuPatrimonio.Domain.Tests
{
    [TestClass]
    public class MarcaValidationTest
    {
        [TestMethod]
        public void NomeNaoPodeSerNulo()
        {
            var marca = new Marca();
            var marcaValidation = new MarcaValidation();
            var isValid = marcaValidation.IsValid(marca);
            var invalidMessages = marcaValidation.InvalidMessages;

            Assert.IsFalse(isValid);
            Assert.IsNotNull(invalidMessages);
        }
    }
}
