using AutoMapper;
using GerenciadorDePatrimonios.API.Models;
using GerenciadorDePatrimonios.Application.Interface;
using GerenciadorDePatrimonios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GerenciadorDePatrimonios.API.Controllers
{
    [RoutePrefix("api/v1/public")]
    public class MarcasController : ApiController
    {
        private readonly IMarcaAppService _marcaApp;

        public MarcasController(IMarcaAppService marcaApp)
        {
            _marcaApp = marcaApp;
        }
        [HttpGet]
        [Route("marcas")]
        public HttpResponseMessage GetMarca()
        {
            try
            {
                var resultado = Mapper.Map<IEnumerable<Marca>, IEnumerable<MarcaModel>>(_marcaApp.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao listar marcas");
            }

        }

        [Route("marcas/{marcaId}")]
        public HttpResponseMessage GetMarcaPorId(int marcaId)
        {
            try
            {
                var resultado = Mapper.Map<IEnumerable<Marca>, IEnumerable<MarcaModel>>(_marcaApp.BuscarPorId(marcaId));
                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao listar marcas");
            }

        }

        [Route("marcas")]
        public HttpResponseMessage PostMarca(MarcaModel marca)
        {
            try
            {
                if (marca != null)
                {
                    if (String.IsNullOrEmpty(marca.Nome))
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Nome da marca nao pode ser nulo ou vazio");
                    }

                    var resultado2 = (Mapper.Map<List<Marca>, List<MarcaModel>>(_marcaApp.BuscarPorNome(marca.Nome)).ToArray());
                    var msg = "";

                    if (resultado2.Length == 0)
                    {
                        var resultado = Mapper.Map<MarcaModel, Marca>(marca);
                        _marcaApp.Add(resultado);
                        msg = "Marca inserida com sucesso";
                    }
                    else
                    {
                        msg = "Marca já existe";
                    }

                    var retorno = new { marca, mensagem = msg };

                    return Request.CreateResponse(HttpStatusCode.OK, retorno);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Dados nao podem ser nulos");
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao listar marcas");
            }

        }

        [HttpPut]
        [Route("marcas")]
        public HttpResponseMessage PutMarca(MarcaModel marca)
        {
            try
            {
                if (marca != null)
                {
                    if (String.IsNullOrEmpty(marca.Nome))
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Nome da marca nao pode ser nulo ou vazio");
                    }

                    if (marca.MarcaId == 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Digite o codigo da marca para editar");
                    }

                    var resultado = Mapper.Map<MarcaModel, Marca>(marca);
                    _marcaApp.Update(resultado);

                    var msg = "Marca atualizada com sucesso";
                    var retorno = new { resultado, mensagem = msg };

                    return Request.CreateResponse(HttpStatusCode.OK, retorno);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Dados nao podem ser nulos");
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao alterar marca");
            }
        }

        [HttpDelete]
        [Route("marcas")]
        public HttpResponseMessage DeleteMarca(int marcaId)
        {
            try
            {
                if (marcaId == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Digite o codigo da marca para excluir");
                }

                var resultado = _marcaApp.GetById(marcaId);
                _marcaApp.Remove(resultado);

                var msg = "Marca excluida com sucesso";
                var retorno = new { resultado, mensagem = msg };

                return Request.CreateResponse(HttpStatusCode.OK, retorno);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao excluir a marca");
            }
        }
    }
}
