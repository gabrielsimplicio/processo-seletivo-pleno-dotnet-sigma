using MeuPatrimonio.Application.Interfaces;
using MeuPatrimonio.Domain.DTOs;
using System.Web.Http;
using System.Web.Http.Results;

namespace MeuPatrimonio.Presentation.WebAPI.Controllers
{
    public class MarcaController : ApiController
    {
        private readonly IMarcaApplication Application;

        public MarcaController(IMarcaApplication application)
        {
            Application = application;
        }

        [HttpGet]
        public JsonResult<MarcaDTO> GetById(int id)
        {
            return Json(Application.GetById(id));
        }
    }
}
