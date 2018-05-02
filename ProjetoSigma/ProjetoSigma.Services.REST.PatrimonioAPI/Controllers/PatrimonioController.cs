using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using ProjetoSigma.Application.Interface;
using ProjetoSigma.Application.ViewModel;

namespace ProjetoSigma.Services.REST.PatrimonioAPI.Controllers
{
    public class PatrimonioController : ApiController
    {
        private readonly IPatrimonioApplication _patrimonioApplication;

        public PatrimonioController(IPatrimonioApplication patrimonioApplication)
        {
            _patrimonioApplication = patrimonioApplication;
        }

        [HttpGet]
        public JsonResult<IEnumerable<PatrimonioViewModel>> Get()
        {
            var getAll = _patrimonioApplication.GetAll();
            return Json(getAll);
        }

        [HttpGet]
        public JsonResult<PatrimonioViewModel> Get(int id)
        {
            return Json(_patrimonioApplication.GetById(id));
        }

        [HttpGet]
        [Route("api/patrimonio/{modeloId}/modelo")]
        public JsonResult<IEnumerable<PatrimonioViewModel>> GetModelo(int modeloId)
        {
            var model = _patrimonioApplication.GetPatrimonioByModelo(modeloId);
            return Json(model);
        }

        [HttpGet]
        [Route("api/patrimonio/{marcaId}/marca")]
        public JsonResult<IEnumerable<PatrimonioViewModel>> GetMarca(int marcaId)
        {
            var model = _patrimonioApplication.GetPatrimonioByMarca(marcaId);
            return Json(model);
        }

        [HttpPost]
        public JsonResult<PatrimonioViewModel> Post([FromBody] PatrimonioViewModel model)
        {
            var patrimonio = _patrimonioApplication.Add(model);
            return Json(patrimonio);
        }

        [HttpPut]
        public JsonResult<PatrimonioViewModel> Put(int id, [FromBody] PatrimonioViewModel model)
        {
            var patrimonio = _patrimonioApplication.Update(model);
            return Json(patrimonio);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _patrimonioApplication.Delete(id);
            return Ok("Deletado!");
        }
    }
}
