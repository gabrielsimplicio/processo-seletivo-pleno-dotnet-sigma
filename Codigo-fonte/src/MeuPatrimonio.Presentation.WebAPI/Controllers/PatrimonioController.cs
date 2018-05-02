using MeuPatrimonio.Application.Interfaces;
using MeuPatrimonio.Domain.DTOs;
using MeuPatrimonio.Infra.CrossCutting.Exceptions;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace MeuPatrimonio.Presentation.WebAPI.Controllers
{
    public class PatrimonioController : ApiController
    {
        private readonly IPatrimonioApplication Application;

        public PatrimonioController(IPatrimonioApplication application)
        {
            Application = application;
        }

        [HttpPost]
        public IHttpActionResult Cadastrar(PatrimonioDTO Patrimonio)
        {
            try
            {
                return Ok(Application.Add(Patrimonio));
            }
            catch (ValidacaoException exc)
            {
                return BadRequest(exc.InvalidMessages[0].Texto);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Editar(PatrimonioDTO Patrimonio)
        {
            try
            {
                return Ok(Application.Update(Patrimonio));
            }
            catch (ValidacaoException exc)
            {
                return BadRequest(exc.InvalidMessages[0].Texto);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult Excluir(int id)
        {
            try
            {
                Application.RemoveById(id);
                return Json(Ok());
            }
            catch (ValidacaoException exc)
            {
                return BadRequest(exc.InvalidMessages[0].Texto);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult Buscar(int id)
        {
            try
            {
                return Ok(Application.GetById(id));
            }
            catch (ValidacaoException exc)
            {
                return BadRequest(exc.InvalidMessages[0].Texto);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult Listar()
        {
            try
            {
                return Ok(Application.GetAll(null));
            }
            catch (ValidacaoException exc)
            {
                return BadRequest(exc.InvalidMessages[0].Texto);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult ListarPorMarcaId(int marcaId)
        {
            try
            {
                return Ok(Application.GetAll(new PatrimonioDTO { MarcaId = marcaId }));
            }
            catch (ValidacaoException exc)
            {
                return BadRequest(exc.InvalidMessages[0].Texto);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult ListarPorModeloId(int modeloId)
        {
            try
            {
                return Ok(Application.GetAll( new PatrimonioDTO { ModeloId = modeloId }));
            }
            catch (ValidacaoException exc)
            {
                return BadRequest(exc.InvalidMessages[0].Texto);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}
