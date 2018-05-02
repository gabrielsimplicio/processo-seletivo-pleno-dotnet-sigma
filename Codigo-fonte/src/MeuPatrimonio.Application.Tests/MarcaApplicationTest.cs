using System.Linq;
using MeuPatrimonio.Domain.DTOs;
using MeuPatrimonio.Domain.Repositories.Interfaces;
using MeuPatrimonio.Domain.Services;
using MeuPatrimonio.Domain.Validations;
using MeuPatrimonio.Infra.CrossCutting.AutoMapper;
using MeuPatrimonio.Infra.CrossCutting.Exceptions;
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

            var repository = new MarcaRepository(new MeuPatrimonioContext());
            var validation = new MarcaValidation(repository);
            var service = new MarcaService(validation, repository);
            var application = new MarcaApplication(service);
            var lista = application.GetAll();

            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void DeveAdicionarMarcaComSucesso()
        {
            try
            {
                AutoMapperConfiguration.Configure();

                var repository = new MarcaRepository(new MeuPatrimonioContext());
                var validation = new MarcaValidation(repository);
                var service = new MarcaService(validation, repository);
                var application = new MarcaApplication(service);
                var marca = application.Add(new MarcaDTO { Nome="CCE" });

                Assert.IsNotNull(marca);
            }
            catch (ValidacaoException exc)
            {
                Assert.Fail(exc.InvalidMessages[0].Texto);
            }
        }

        [TestMethod]
        public void NaoDeveAdicionarMarcaDeNomeRepetido()
        {
            try
            {
                AutoMapperConfiguration.Configure();

                var repository = new MarcaRepository(new MeuPatrimonioContext());
                var validation = new MarcaValidation(repository);
                var service = new MarcaService(validation, repository);
                var application = new MarcaApplication(service);
                var marca = application.GetAll(m => m.Nome == "CCE").FirstOrDefault();
                application.Add(new MarcaDTO { Nome = marca.Nome });
            }
            catch (ValidacaoException exc)
            {
                Assert.Fail(exc.InvalidMessages[0].Texto);
            }
        }

        [TestMethod]
        public void NaoDeveAtualizarMarcaDeNomeRepetido()
        {
            try
            {
                AutoMapperConfiguration.Configure();

                var repository = new MarcaRepository(new MeuPatrimonioContext());
                var validation = new MarcaValidation(repository);
                var service = new MarcaService(validation, repository);
                var application = new MarcaApplication(service);
                var marca = application.GetAll(m => m.Nome == "CCE").FirstOrDefault();
                application.Update(new MarcaDTO { Nome = marca.Nome });
            }
            catch (ValidacaoException exc)
            {
                Assert.Fail(exc.InvalidMessages[0].Texto);
            }
        }
    }
}
