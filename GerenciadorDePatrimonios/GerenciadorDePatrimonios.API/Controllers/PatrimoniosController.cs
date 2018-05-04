using AutoMapper;
using GerenciadorDePatrimonios.API.Models;
using GerenciadorDePatrimonios.Application.Interface;
using GerenciadorDePatrimonios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace GerenciadorDePatrimonios.API.Controllers
{
    [RoutePrefix("api/v1/public")]
    public class PatrimoniosController : ApiController
    {
        private readonly IMarcaAppService _marcaApp;
        private readonly IModeloAppService _modeloApp;
        private readonly IPatrimonioAppService _patrimonioApp;

        public PatrimoniosController(IMarcaAppService marcaApp, IModeloAppService modeloApp, IPatrimonioAppService patrimonioApp)
        {
            _marcaApp = marcaApp;
            _modeloApp = modeloApp;
            _patrimonioApp = patrimonioApp;
        }


        [Route("patrimonios")]
        [ResponseType(typeof(IEnumerable<PatrimonioModel>))]
        public HttpResponseMessage GetPatrimonio()
        {
            try
            {
                var resultado = Mapper.Map<IEnumerable<Patrimonio>, IEnumerable<PatrimonioModel>>(_patrimonioApp.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao listar patrimonios");
            }

        }

        [Route("patrimonios/{patrimonioId}")]
        [ResponseType(typeof(IEnumerable<PatrimonioModel>))]
        public HttpResponseMessage GetPatrimonioPorId(int patrimonioId)
        {
            try
            {
                var resultado = _patrimonioApp.GetById(patrimonioId);
                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao listar patrimonios");
            }

        }

        [Route("marcas/{marcaId}/patrimonios")]
        [ResponseType(typeof(IEnumerable<PatrimonioModel>))]
        public HttpResponseMessage GetPatrimonioPorMarcaId(int marcaId)
        {
            try
            {
                var resultado = _patrimonioApp.BuscarPorMarcaId(marcaId);
                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao listar patrimonios por marcas");
            }

        }

        [Route("modelos/{modeloId}/patrimonios")]
        [ResponseType(typeof(IEnumerable<PatrimonioModel>))]
        public HttpResponseMessage GetPatrimonioPorModeloId(int modeloId)
        {
            try
            {
                var resultado = _patrimonioApp.BuscarPorModelo(modeloId);
                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao listar patrimonios por modelos");
            }

        }

        [Route("patrimonios")]
        [ResponseType(typeof(IEnumerable<PatrimonioModel>))]
        public HttpResponseMessage PostPatrimonio(PatrimonioModel patrimonio)
        {
            try
            {
                if (patrimonio != null)
                {
                    if (String.IsNullOrEmpty(patrimonio.Nome))
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Nome do patrimonio nao pode ser nulo ou vazio");
                    }
                    if (patrimonio.MarcaId == 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Codigo da marca do patrimonio nao pode ser nulo, vazio ou zero");
                    }
                    if (patrimonio.ModeloId == 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Codigo do modelo do patrimonio nao pode ser nulo , vazio ou zero");
                    }

                    var marca = _patrimonioApp.BuscarPorMarcaId(patrimonio.MarcaId);


                    //if (marca ==true)
                    //{
                    //    return Request.CreateResponse(HttpStatusCode.NotFound, "Marca não existe");
                    //}

                    //var modelo = _patrimonioApp.BuscarPorModelo(patrimonio.ModeloId);

                    //if (modelo == null)
                    //{
                    //    return Request.CreateResponse(HttpStatusCode.NotFound, "Modelo não existe");
                    //}

                    var msg = "";
                    var resultado = Mapper.Map<PatrimonioModel, Patrimonio>(patrimonio);
                    _patrimonioApp.Add(resultado);
                    msg = "Patrimonio inserido com sucesso";

                    var retorno = new { patrimonio, mensagem = msg };

                    return Request.CreateResponse(HttpStatusCode.OK, retorno);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Dados nao podem ser nulos");
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao salvar patrimonio");
            }

        }

        [HttpPut]
        [Route("patrimonios")]
        [ResponseType(typeof(IEnumerable<PatrimonioModel>))]
        public HttpResponseMessage PutPatrimonio(PatrimonioModel patrimonio)
        {
            try
            {
                if (patrimonio != null)
                {
                    if (String.IsNullOrEmpty(patrimonio.Nome))
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Nome do patrimonio nao pode ser nulo ou vazio");
                    }
                    if (patrimonio.MarcaId == 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Codigo da marca do patrimonio nao pode ser nulo ou vazio");
                    }
                    if (patrimonio.ModeloId == 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Codigo do modelo do patrimonio nao pode ser nulo ou vazio");
                    }

                    var resultado = Mapper.Map<PatrimonioModel, Patrimonio>(patrimonio);
                    _patrimonioApp.Update(resultado);

                    var msg = "Patrimonio atualizado com sucesso";
                    var obs = "Numero do tombo e atualizavel";
                    var retorno = new { resultado, mensagem = msg, observacao = obs };

                    return Request.CreateResponse(HttpStatusCode.OK, retorno);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Dados nao podem ser nulos");
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao alterar patrimonio");
            }
        }

        [HttpDelete]
        [Route("patrimonios")]
        [ResponseType(typeof(IEnumerable<PatrimonioModel>))]
        public HttpResponseMessage DeletePatrimonio(int patrimonioId)
        {
            try
            {
                if (patrimonioId == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Digite o codigo do patrimonio para excluir");
                }

                var resultado = _patrimonioApp.GetById(patrimonioId);
                _patrimonioApp.Remove(resultado);

                var msg = "Patrimonio excluido com sucesso";
                var retorno = new { resultado, mensagem = msg };

                return Request.CreateResponse(HttpStatusCode.OK, retorno);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao excluir o patrimonio");
            }
        }
    }


}

