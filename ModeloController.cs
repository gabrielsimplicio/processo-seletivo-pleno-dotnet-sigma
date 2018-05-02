
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LuisCesarMVCWebApi.DbContext;
using LuisCesarMVCWebApi.Models.Entities;

namespace LuisCesarMVCWebApi.Controllers
{
    public class ModeloController : ApiController
    {
        private readonly PatrimonioContext _db;

        public ModeloController()
        {
            _db = new PatrimonioContext();
        }

        [HttpGet]
        public IQueryable<Modelo> Get()
        {
            return _db.Modelos;
        }

        [HttpGet]
        public Modelo Get(int id)
        {
            return _db.Modelos.FirstOrDefault(e => e.Id == id);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Modelo modelo)
        {
            try
            {
                var duplicado = ModeloDuplicado(modelo.Nome);

                if (duplicado > 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Nome " + modelo.Nome + " já existe.");

                _db.Modelos.Add(modelo);
                _db.SaveChanges();

                var mensagem = Request.CreateResponse(HttpStatusCode.Created, modelo);
                var location = Request.RequestUri + "/" + modelo.Id;
                mensagem.Headers.Location = new Uri(location);
                return mensagem;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]Modelo modelo)
        {
            var dbModelo = _db.Modelos.FirstOrDefault(e => e.Id == id);
            if (dbModelo == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Código " + id + " Não Encontrado.");

            var duplicado = ModeloDuplicado(id, modelo.Nome);

            if (duplicado > 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Nome " + modelo.Nome + " já existe.");


            dbModelo.Nome = modelo.Nome;
            _db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {

            try
            {
                var modelo = _db.Modelos.FirstOrDefault(e => e.Id == id);
                if (modelo == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Código " + id + " Não Encontrado: ");

                _db.Modelos.Remove(modelo);
                _db.SaveChanges();

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        #region Métodos

        protected int ModeloDuplicado(string nome)
        {
            return _db.Modelos.Count(e => e.Nome.Equals(nome));
        }

        protected int ModeloDuplicado(int id, string nome)
        {
            int retorno = _db.Modelos.Count(e => e.Nome.Equals(nome) && e.Id != id);
            return retorno;
        }

        #endregion

        protected void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
        }
    }
}