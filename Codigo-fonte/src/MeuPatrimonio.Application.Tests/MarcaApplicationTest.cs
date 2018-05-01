using System;
using MeuPatrimonio.Application.AutoMapper;
using MeuPatrimonio.Domain.Repositories.Interfaces;
using MeuPatrimonio.Domain.Services;
using MeuPatrimonio.Domain.Validations;
using MeuPatrimonio.Infra.Data.ORM.EntityFramework.Contexts;
using MeuPatrimonio.Infra.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeuPatrimonio.Application.Tests
{
    [TestClass]
    public class MarcaApplicationTest
    {
        [TestMethod]
        public void DeveListarTodasAsMarcas()
        {
            AutoMapperConfiguration.Configure();

            var validation = new MarcaValidation();
            var repository = new MarcaRepository(new MeuPatrimonioContext());
            var service = new MarcaService(validation, repository);
            var application = new MarcaApplication(service);
            var lista = application.GetAll();

            Assert.IsNotNull(lista);
        }
    }
}
