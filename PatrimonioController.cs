using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntityFramework.Toolkit.Extensions;
using LuisCesarMVCWebApi.DbContext;
using LuisCesarMVCWebApi.Models.Entities;
using LuisCesarMVCWebApi.ViewModel;

namespace LuisCesarMVCWebApi.Controllers
{
    public class PatrimonioController : ApiController
    {
        private readonly PatrimonioContext _db;

        public PatrimonioController()
        {
            _db = new PatrimonioContext();
        }


        [HttpGet]
        public IQueryable<Patrimonio> Get()
        {
            return _db.Patrimonios;
        }

        [HttpGet]
        public Patrimonio Get(int id)
        {
            return _db.Patrimonios.FirstOrDefault(e => e.Id == id);
        }

        [HttpGet]
        public List<PatrimonioVW> GetPatrimonioMarca(int marcaId)
        {
            var retorno = _db.Patrimonios
                            .Where(x => x.MarcaId == marcaId)
                            .Include(z => z.Marca)
                            .Include(s=> s.Modelo);

            var patrimonioVw = new List<PatrimonioVW>();

            foreach (var patrimonio in retorno)
            {
                patrimonioVw.Add(new PatrimonioVW
                {
                    Id = patrimonio.Id,
                    Nome = patrimonio.Nome,
                    Descricao = patrimonio.Descricao,
                    MarcaId = patrimonio.Id,
                    MarcaNome = patrimonio.Marca.Nome,
                    ModeloId = patrimonio.Modelo.Id,
                    ModeloNome = patrimonio.Modelo.Nome,
                    NumeroTombo = patrimonio.NumeroTombo,
                });
            }

            return patrimonioVw;
        }

        [HttpGet]
        public List<PatrimonioVW> GetPatrimonioModelo(int modeloId)
        {
            var retorno = _db.Patrimonios
                            .Where(x => x.ModeloId == modeloId)
                            .Include(z => z.Marca)
                            .Include(s => s.Modelo);

            var patrimonioVw = new List<PatrimonioVW>();

            foreach (var patrimonio in retorno)
            {
                patrimonioVw.Add(new PatrimonioVW
                {
                    Id = patrimonio.Id,
                    Nome = patrimonio.Nome,
                    Descricao = patrimonio.Descricao,
                    MarcaId = patrimonio.Id,
                    MarcaNome = patrimonio.Marca.Nome,
                    ModeloId = patrimonio.Modelo.Id,
                    ModeloNome = patrimonio.Modelo.Nome,
                    NumeroTombo = patrimonio.NumeroTombo,
                });
            }

            return patrimonioVw;
        }


        [HttpPost]
        public HttpResponseMessage Post([FromBody]Patrimonio patrimonio)
        {
            try
            {
                var marca = MarcaExiste(patrimonio.MarcaId);
                if (marca == 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "MarcaId " + patrimonio.MarcaId + " não encontrado.");

                var modelo = MarcaExiste(patrimonio.ModeloId);
                if (modelo == 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "ModeloId " + patrimonio.ModeloId + " não encontrado.");

                patrimonio.NumeroTombo = Guid.NewGuid().ToString();
                _db.Patrimonios.Add(patrimonio);
                _db.SaveChanges();

                var mensagem = Request.CreateResponse(HttpStatusCode.Created, patrimonio);
                var location = Request.RequestUri + "/" + patrimonio.Id;
                mensagem.Headers.Location = new Uri(location);

                return mensagem;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]Patrimonio patrimonio)
        {
            var dbPatrimonio = _db.Patrimonios.FirstOrDefault(e => e.Id == id);
            if (dbPatrimonio == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Código " + id + " Não Encontrado.");

            var duplicado = TomboDuplicado(id, patrimonio.Nome);
            if (duplicado > 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Tombo " + patrimonio.NumeroTombo + " já existe.");

            var marca = MarcaExiste(patrimonio.MarcaId);
            if (marca == 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "MarcaId " + patrimonio.MarcaId + " não encontrado.");

            var modelo = MarcaExiste(patrimonio.ModeloId);
            if (modelo == 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ModeloId " + patrimonio.ModeloId + " não encontrado.");

            try
            {
                dbPatrimonio.Nome = patrimonio.Nome;
                dbPatrimonio.Descricao = patrimonio.Descricao;
                dbPatrimonio.MarcaId = patrimonio.MarcaId;
                dbPatrimonio.ModeloId = patrimonio.ModeloId;

                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro: " + ex.InnerException.Message);
            }


            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {

            try
            {
                var patrimonio = _db.Patrimonios.FirstOrDefault(e => e.Id == id);
                if (patrimonio == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Código " + id + " Não Encontrado.");

                _db.Patrimonios.Remove(patrimonio);
                _db.SaveChanges();

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        #region Métodos

        protected int TomboDuplicado(int id, string numeroTombo)
        {
            return _db.Patrimonios.Count(e => e.NumeroTombo.Equals(numeroTombo) && e.Id != id);
        }

        protected int MarcaExiste(int id)
        {
            return _db.Marcas.Count(e => e.Id == id);
        }

        protected int ModeloExiste(int id)
        {
            return _db.Modelos.Count(e => e.Id == id);
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