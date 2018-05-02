using GerenciadorPatrimonios.Data.DataContexts;
using GerenciadorPatrimonios.Domain;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace GerenciadorPatrimonios.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class MarcaController : ApiController
    {
        private GerenciadorPatrimoniosDataContext db = new GerenciadorPatrimoniosDataContext();

        // GET: api/Marca
        [Route("Marcas")]
        public IQueryable<Marca> GetMarcas()
        {
            return db.Marcas;
        }

        // GET: api/Marca/5
        [Route("Marcas/{id}")]
        [ResponseType(typeof(Marca))]
        public IHttpActionResult GetMarca(int id)
        {
            var marca = db.Marcas.Where(m => m.Id == id);
            if (marca == null)
            {
                return NotFound();
            }

            return Ok(marca);
        }
        
        // PUT: api/Marca/5
        [Route("Marcas/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMarca(int id, Marca marca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != marca.Id)
            {
                return BadRequest();
            }

            db.Entry(marca).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Marca
        [Route("Marcas")]
        [ResponseType(typeof(Marca))]
        public IHttpActionResult PostMarca(Marca marca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Marcas.Add(marca);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = marca.Id }, marca);
        }

        // DELETE: api/Marca/5
        [Route("Marcas/{id}")]
        [ResponseType(typeof(Marca))]
        public IHttpActionResult DeleteMarca(int id)
        {
            Marca marca = db.Marcas.Find(id);
            if (marca == null)
            {
                return NotFound();
            }

            db.Marcas.Remove(marca);
            db.SaveChanges();

            return Ok(marca);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MarcaExists(int id)
        {
            return db.Marcas.Count(e => e.Id == id) > 0;
        }
    }
}