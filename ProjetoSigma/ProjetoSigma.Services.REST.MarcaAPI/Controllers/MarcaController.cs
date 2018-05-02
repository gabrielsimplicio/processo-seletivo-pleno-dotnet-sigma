using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using ProjetoSigma.Application.Interface;
using ProjetoSigma.Application.ViewModel;

namespace ProjetoSigma.Services.REST.MarcaAPI.Controllers
{
    public class MarcaController : ApiController
    {
        private readonly IMarcaApplication _marcaApplication;

        public MarcaController(IMarcaApplication marcaApplication)
        {
            _marcaApplication = marcaApplication;
        }

        [HttpGet]
        public JsonResult<IEnumerable<MarcaViewModel>> Get()
        {
            var getAll = _marcaApplication.GetAll();
            return Json(getAll);
        }

        [HttpGet]
        public JsonResult<MarcaViewModel> Get(int id)
        {
            return Json(_marcaApplication.GetById(id));
        }

        [HttpPost]
        public JsonResult<MarcaViewModel> Post([FromBody] MarcaViewModel model)
        {
            var marca = _marcaApplication.Add(model);
            return Json(marca);
        }

        [HttpPut]
        public JsonResult<MarcaViewModel> Put(int id, [FromBody]MarcaViewModel model)
        {
            var marca = _marcaApplication.Update(model);
            return Json(marca);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _marcaApplication.Delete(id);
        }
    }
}
