using MeuPatrimonio.Application.Interfaces;
using MeuPatrimonio.Domain.DTOs;
using MeuPatrimonio.Infra.CrossCutting.Exceptions;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace MeuPatrimonio.Presentation.WebAPI.Controllers
{
    public class ModeloController : ApiController
    {
        private readonly IModeloApplication Application;

        public ModeloController(IModeloApplication application)
        {
            Application = application;
        }

        [HttpPost]
        public IHttpActionResult Cadastrar(ModeloDTO Modelo)
        {
            try
            {
                return Ok(Application.Add(Modelo));
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
        public IHttpActionResult Editar(ModeloDTO Modelo)
        {
            try
            {
                return Ok(Application.Update(Modelo));
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
                return Ok(Application.GetAll(new ModeloDTO { MarcaId = marcaId }));
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
