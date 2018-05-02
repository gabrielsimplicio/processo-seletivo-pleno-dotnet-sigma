using System;
using MeuPatrimonio.Domain.Entities;
using MeuPatrimonio.Domain.Validations;
using MeuPatrimonio.Infra.CrossCutting.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeuPatrimonio.Domain.Tests
{
    [TestClass]
    public class MarcaValidationTest
    {
        [TestMethod]
        public void NomeNaoPodeSerNuloAoCadastrar()
        {
            var marca = new Marca();
            var marcaValidation = new MarcaValidation();
            var isValid = marcaValidation.IsValid(marca, AcaoEnum.Adicionar);
            var invalidMessages = marcaValidation.InvalidMessages;

            Assert.IsFalse(isValid);
            Assert.IsNotNull(invalidMessages);
        }
    }
}
