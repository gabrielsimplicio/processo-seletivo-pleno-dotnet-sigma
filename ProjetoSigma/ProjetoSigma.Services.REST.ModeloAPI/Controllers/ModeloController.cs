using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using ProjetoSigma.Application.Interface;
using ProjetoSigma.Application.ViewModel;

namespace ProjetoSigma.Services.REST.ModeloAPI.Controllers
{
    public class ModeloController : ApiController
    {
        private readonly IModeloApplication _modeloApplication;

        public ModeloController(IModeloApplication modeloApplication)
        {
            _modeloApplication = modeloApplication;
        }

        [HttpGet]
        public JsonResult<IEnumerable<ModeloViewModel>> Get()
        {
            var getAll = _modeloApplication.GetAll();
            return Json(getAll);
        }

        [HttpGet]
        public JsonResult<ModeloViewModel> Get(int id)
        {
            return Json(_modeloApplication.GetById(id));
        }

        [HttpPost]
        public JsonResult<ModeloViewModel> Post([FromBody] ModeloViewModel model)
        {
            var modelo = _modeloApplication.Add(model);
            return Json(modelo);
        }

        [HttpPut]
        public JsonResult<ModeloViewModel> Put(int id, [FromBody] ModeloViewModel model)
        {
            var modelo = _modeloApplication.Update(model);
            return Json(modelo);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _modeloApplication.Delete(id);
            return Ok("Deletado!");
        }
    }
}
