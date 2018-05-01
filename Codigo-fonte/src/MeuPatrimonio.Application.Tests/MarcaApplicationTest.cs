using System;
using MeuPatrimonio.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeuPatrimonio.Application.Tests
{
    [TestClass]
    public class MarcaApplicationTest
    {
        [TestMethod]
        public void DeveListarTodasAsMarcas()
        {
            var service = new MarcaService();
            var application = new MarcaApplication(service);
            var lista = application.GetAll();

            Assert.IsNotNull(lista);
        }
    }
}
