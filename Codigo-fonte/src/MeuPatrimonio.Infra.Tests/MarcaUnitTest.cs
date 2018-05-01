using MeuPatrimonio.Infra.Data.ORM.EntityFramework.Contexts;
using MeuPatrimonio.Infra.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeuPatrimonio.Infra.Tests
{
    [TestClass]
    public class MarcaUnitTest
    {
        [TestMethod]
        public void DeveBuscarTodasAsMarcas()
        {
            var context = new MeuPatrimonioContext();
            var repository = new MarcaRepository(context);
            var marcas = repository.GetAll();

            Assert.IsNotNull(marcas);
        }
    }
}
