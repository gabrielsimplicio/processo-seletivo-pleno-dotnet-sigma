using GerenciadorPatrimonios.Data.DataContexts;
using GerenciadorPatrimonios.Domain;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace GerenciadorPatrimonios.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class ModeloController : ApiController
    {
        private GerenciadorPatrimoniosDataContext db = new GerenciadorPatrimoniosDataContext();

        // GET: api/Modelo
        [Route("Modelos")]
        public IQueryable<Modelo> GetModelos()
        {
            return db.Modelos;
        }

        // GET: api/Modelo/5
        [Route("Modelos/{id}")]
        [ResponseType(typeof(Modelo))]
        public IHttpActionResult GetModelo(int id)
        {
            Modelo modelo = db.Modelos.Find(id);
            if (modelo == null)
            {
                return NotFound();
            }

            return Ok(modelo);
        }

        // GET: api/Modelo/5
        [Route("Modelos/{MarcaId}/Marca")]
        [ResponseType(typeof(Modelo))]
        public IHttpActionResult GetModeloByMarca(int MarcaId)
        {
            var modelo = db.Modelos.Include(m => m.Marca).Where(x => x.MarcaId == MarcaId).ToList();
            if (modelo == null)
            {
                return NotFound();
            }

            return Ok(modelo);
        }

        // PUT: api/Modelo/5
        [Route("Modelos/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutModelo(int id, Modelo modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modelo.Id)
            {
                return BadRequest();
            }

            db.Entry(modelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloExists(id))
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

        // POST: api/Modelo
        [Route("Modelos")]
        [ResponseType(typeof(Modelo))]
        public IHttpActionResult PostModelo(Modelo modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Modelos.Add(modelo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = modelo.Id }, modelo);
        }

        // DELETE: api/Modelo/5
        [Route("Modelos/{id}")]
        [ResponseType(typeof(Modelo))]
        public IHttpActionResult DeleteModelo(int id)
        {
            Modelo modelo = db.Modelos.Find(id);
            if (modelo == null)
            {
                return NotFound();
            }

            db.Modelos.Remove(modelo);
            db.SaveChanges();

            return Ok(modelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModeloExists(int id)
        {
            return db.Modelos.Count(e => e.Id == id) > 0;
        }
    }
}