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
    public class ModelosController : ApiController
    {
        private readonly IMarcaAppService _marcaApp;
        private readonly IModeloAppService _modeloApp;

        public ModelosController(IMarcaAppService marcaApp, IModeloAppService modeloApp)
        {
            _marcaApp = marcaApp;
            _modeloApp = modeloApp;
        }


        [Route("modelos")]
        [ResponseType(typeof(IEnumerable<Modelo>))]
        public HttpResponseMessage GetModelo()
        {
            try
            {
                var resultado = Mapper.Map<IEnumerable<Modelo>, IEnumerable<ModeloModel>>(_modeloApp.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao listar modelos");
            }

        }

        [Route("modelos/{modeloId}")]
        [ResponseType(typeof(IEnumerable<Modelo>))]
        public HttpResponseMessage GetModeloPorId(int modeloId)
        {
            try
            {
                var resultado = _modeloApp.GetById(modeloId);
                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao listar modelos");
            }

        }

        [Route("modelos")]
        [ResponseType(typeof(IEnumerable<Modelo>))]
        public HttpResponseMessage PostModelo(ModeloModel modelo)
        {
            try
            {
                if (modelo != null)
                {
                    if (String.IsNullOrEmpty(modelo.Nome))
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Nome da modelo nao pode ser nulo ou vazio");
                    }
                    if (modelo.MarcaId == 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Codigo da marca nao pode ser nulo ou vazio");
                    }

                    var resultad_ = (Mapper.Map<List<Modelo>, List<ModeloModel>>(_modeloApp.BuscarPorNome(modelo.Nome, modelo.MarcaId)).ToArray());
                    var msg = "";

                    if (resultad_.Length == 0)
                    {
                        var resultado = Mapper.Map<ModeloModel, Modelo>(modelo);
                        _modeloApp.Add(resultado);
                        msg = "Modelo inserido com sucesso";
                    }
                    else
                    {
                        msg = "Modelo já existe";
                        modelo.ModeloId = resultad_[0].ModeloId;
                    }

                    var retorno = new { modelo, mensagem = msg };

                    return Request.CreateResponse(HttpStatusCode.OK, retorno);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Dados nao podem ser nulos");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao salvar modelo");
            }

        }

        [HttpPut]
        [Route("modelos")]
        [ResponseType(typeof(IEnumerable<ModeloModel>))]
        public HttpResponseMessage PutModelo(ModeloModel modelo)
        {
            try
            {
                if (modelo != null)
                {
                    if (String.IsNullOrEmpty(modelo.Nome))
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Nome da modelo nao pode ser nulo ou vazio");
                    }

                    if (modelo.ModeloId == 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Digite o codigo da modelo para editar");
                    }

                    var resultado = Mapper.Map<ModeloModel, Modelo>(modelo);
                    _modeloApp.Update(resultado);

                    var msg = "Modelo atualizada com sucesso";
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao alterar modelo");
            }
        }

        [HttpDelete]
        [Route("modelos")]
        [ResponseType(typeof(IEnumerable<Modelo>))]
        public HttpResponseMessage DeleteModelo(int modeloId)
        {
            try
            {
                if (modeloId == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Digite o codigo da modelo para excluir");
                }

                var resultado = _modeloApp.GetById(modeloId);
                _modeloApp.Remove(resultado);

                var msg = "Modelo excluida com sucesso";
                var retorno = new { resultado, mensagem = msg };

                return Request.CreateResponse(HttpStatusCode.OK, retorno);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao excluir a modelo");
            }
        }
    }
}
