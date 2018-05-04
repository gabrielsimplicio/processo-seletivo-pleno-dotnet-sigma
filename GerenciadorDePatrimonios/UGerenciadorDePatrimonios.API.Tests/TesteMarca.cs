using GerenciadorDePatrimonios.API.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGerenciadorDePatrimonios.API.Tests
{
    [TestClass]
    public class TesteMarca
    {
        [TestMethod]
        public void GetAllProductsTest()
        {        private readonly IMarcaAppService _marcaApp;
        private readonly IModeloAppService _modeloApp;

        public MarcasController(IMarcaAppService marcaApp, IModeloAppService modeloApp)
        {
            _marcaApp = marcaApp;
            _modeloApp = modeloApp;
        }
        var productController = new MarcasController(_marcaApp)
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(ServiceBaseURL + "v1/Products/Product/all")
                }
            };
            productController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            _response = productController.Get();

            var responseResult = JsonConvert.DeserializeObject<List<Product>>(_response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(_response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(responseResult.Any(), true);
            var comparer = new ProductComparer();
            CollectionAssert.AreEqual(
            responseResult.OrderBy(product => product, comparer),
            _products.OrderBy(product => product, comparer), comparer);
        }
    }
}
