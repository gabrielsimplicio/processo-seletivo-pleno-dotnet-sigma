using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LuisCesarMVCWebApi.DbContext;
using LuisCesarMVCWebApi.Models.Entities;

namespace LuisCesarMVCWebApi.Controllers
{
    public class MarcaController : ApiController
    {
        private readonly PatrimonioContext _db;

        public MarcaController()
        {
            _db = new PatrimonioContext();
        }

        [HttpGet]
        public IEnumerable<string> Test()
        {
            var texto = new List<string>();
            for (int i = 0; i < 20; i++)
                texto.Add("texto " + i);

            return texto;
        }

        [HttpGet]
        public IQueryable<Marca> Get()
        {
            return _db.Marcas;
        }

        [HttpGet]
        public Marca Get(int id)
        {
            return _db.Marcas.FirstOrDefault(e => e.Id == id);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Marca marca)
        {
            try
            {
                var duplicado = MarcaDuplicado(marca.Nome);

                if (duplicado > 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Nome " + marca.Nome + " já existe.");

                _db.Marcas.Add(marca);
                _db.SaveChanges();

                var mensagem = Request.CreateResponse(HttpStatusCode.Created, marca);
                var location = Request.RequestUri + "/" + marca.Id;
                mensagem.Headers.Location = new Uri(location);

                return mensagem;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]Marca marca)
        {
            var dbMarca = _db.Marcas.FirstOrDefault(e => e.Id == id);
            if (dbMarca == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Código " + id + " Não Encontrado.");

            var duplicado = MarcaDuplicado(id, marca.Nome);

            if (duplicado > 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Nome " + marca.Nome + " já existe.");


            dbMarca.Nome = marca.Nome;
            _db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {

            try
            {
                var marca = _db.Marcas.FirstOrDefault(e => e.Id == id);
                if (marca == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Código " + id + " Não Encontrado.");

                _db.Marcas.Remove(marca);
                _db.SaveChanges();

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        #region Métodos

        protected int MarcaDuplicado(string nome)
        {
            return _db.Marcas.Count(e => e.Nome.Equals(nome));
        }

        protected int MarcaDuplicado(int id, string nome)
        {
            return _db.Marcas.Count(e => e.Nome.Equals(nome) && e.Id != id);
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