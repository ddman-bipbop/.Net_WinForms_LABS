using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Lab15;


namespace Lab15.Controllers
{
    public class Kind_sportController : ApiController
    {
        private Models.DotNetEntities db = new Models.DotNetEntities();

        // GET: api/Kind_sport
        public IQueryable<Models.Kind_sport> GetKind_sport()
        {
            return db.Kind_sport;
        }

        // GET: api/Kind_sport/5
        [ResponseType(typeof(Models.Kind_sport))]
        public async Task<IHttpActionResult> GetKind_sport(int id)
        {
            Models.Kind_sport kind_sport = await db.Kind_sport.FindAsync(id);
            if (kind_sport == null)
            {
                return NotFound();
            }

            return Ok(kind_sport);
        }

        // PUT: api/Kind_sport/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKind_sport(int id, Models.Kind_sport kind_sport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kind_sport.id_kind)
            {
                return BadRequest();
            }

            db.Entry(kind_sport).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Kind_sportExists(id))
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

        // POST: api/Kind_sport
        [ResponseType(typeof(Models.Kind_sport))]
        public async Task<IHttpActionResult> PostKind_sport(Models.Kind_sport kind_sport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kind_sport.Add(kind_sport);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = kind_sport.id_kind }, kind_sport);
        }

        // DELETE: api/Kind_sport/5
        [ResponseType(typeof(Models.Kind_sport))]
        public async Task<IHttpActionResult> DeleteKind_sport(int id)
        {
            Models.Kind_sport kind_sport = await db.Kind_sport.FindAsync(id);
            if (kind_sport == null)
            {
                return NotFound();
            }

            db.Kind_sport.Remove(kind_sport);
            await db.SaveChangesAsync();

            return Ok(kind_sport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Kind_sportExists(int id)
        {
            return db.Kind_sport.Count(e => e.id_kind == id) > 0;
        }
    }
}