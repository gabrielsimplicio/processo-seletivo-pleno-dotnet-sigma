using GerenciadorPatrimonios.Api.ViewModel;
using GerenciadorPatrimonios.Data.DataContexts;
using GerenciadorPatrimonios.Domain;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace GerenciadorPatrimonios.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class PatrimonioController : ApiController
    {
        private GerenciadorPatrimoniosDataContext db = new GerenciadorPatrimoniosDataContext();
        
        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }        

        // GET: api/Patrimonio
        [Route("Patrimonios")]
        public IQueryable<Patrimonio> GetPatrimonios()
        {
            return db.Patrimonios.Include(m => m.Modelo).Include(mo => mo.Modelo.Marca);
        }

        // GET: api/Patrimonio/5
        [Route("Patrimonios/{id}")]
        [ResponseType(typeof(Patrimonio))]
        public IHttpActionResult GetPatrimonio(int id)
        {
            var patrimonio = db.Patrimonios.Include(m => m.Modelo).Include(mo => mo.Modelo.Marca).Where(p => p.Id == id);
            if (patrimonio == null)
            {
                return NotFound();
            }

            return Ok(patrimonio);
        }

        // GET: api/Marca/5/Patrimonio
        [Route("Patrimonios/{MarcaId}/Marca")]
        public IHttpActionResult GetPatrimonioByMarca(int MarcaId)
        {
            var patrimonio = db.Patrimonios.Include(m => m.Modelo).Include(mo => mo.Modelo.Marca).Where(ma => ma.Modelo.MarcaId == MarcaId).ToList();
            if (patrimonio == null)
            {
                return NotFound();
            }

            return Ok(patrimonio);
        }

        // GET: api/Modelo/5/Patrimonio
        [Route("Patrimonios/{ModeloId}/Modelo")]
        public IHttpActionResult GetPatrimonioByModelo(int ModeloId)
        {
            var patrimonio = db.Patrimonios.Include(m => m.Modelo).Include(mo => mo.Modelo.Marca).Where(ma => ma.Modelo.Id == ModeloId).ToList();
            if (patrimonio == null)
            {
                return NotFound();
            }

            return Ok(patrimonio);
        }

        // PUT: api/Patrimonio/5
        [Route("Patrimonios/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatrimonio(int id, PatrimonioViewModel patrimonioViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patrimonioViewModel.Id)
            {
                return BadRequest();
            }

            var patrimonio = new Patrimonio();
            patrimonio.Nome = patrimonioViewModel.Nome;
            patrimonio.Descricao = patrimonioViewModel.Descricao;
            patrimonio.DataAlteracao = DateTime.Now;
            patrimonio.Ativo = patrimonioViewModel.Ativo;
            patrimonio.ModeloId = patrimonioViewModel.ModeloId;

            db.Entry(patrimonio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatrimonioExists(id))
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

        // POST: api/Patrimonio
        [Route("Patrimonios")]
        [ResponseType(typeof(Patrimonio))]
        public IHttpActionResult PostPatrimonio(PatrimonioViewModel patrimonioViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patrimonio = new Patrimonio();
            patrimonio.Nome = patrimonioViewModel.Nome;
            patrimonio.Descricao = patrimonioViewModel.Descricao;
            patrimonio.NumeroTombo = RandomNumber(100, 999999);
            patrimonio.ModeloId = patrimonioViewModel.ModeloId;
            
            db.Patrimonios.Add(patrimonio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = patrimonio.Id }, patrimonio);
        }

        // DELETE: api/Patrimonio/5
        [Route("Patrimonios/{id}")]
        [ResponseType(typeof(Patrimonio))]
        public IHttpActionResult DeletePatrimonio(int id)
        {
            Patrimonio patrimonio = db.Patrimonios.Find(id);
            if (patrimonio == null)
            {
                return NotFound();
            }

            db.Patrimonios.Remove(patrimonio);
            db.SaveChanges();

            return Ok(patrimonio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatrimonioExists(int id)
        {
            return db.Patrimonios.Count(e => e.Id == id) > 0;
        }
    }
}