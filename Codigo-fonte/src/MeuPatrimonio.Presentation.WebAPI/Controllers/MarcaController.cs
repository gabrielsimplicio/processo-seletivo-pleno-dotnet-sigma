using MeuPatrimonio.Application.Interfaces;
using MeuPatrimonio.Domain.DTOs;
using MeuPatrimonio.Infra.CrossCutting.Exceptions;
using System;
using System.Collections.Generic;
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

        [HttpPost]
        public IHttpActionResult Cadastrar(MarcaDTO marca)
        {
            try
            {
                return Ok(Application.Add(marca));
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
        public IHttpActionResult Editar(MarcaDTO marca)
        {
            try
            {
                return Ok(Application.Update(marca));
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
    }
}
