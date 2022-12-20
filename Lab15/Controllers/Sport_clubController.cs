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
    public class Sport_clubController : ApiController
    {
        private Models.DotNetEntities db = new Models.DotNetEntities();

        // GET: api/Sport_club
        public IQueryable<Models.Sport_club> GetSport_club()
        {
            return db.Sport_club;
        }

        // GET: api/Sport_club/5
        [ResponseType(typeof(Models.Sport_club))]
        public async Task<IHttpActionResult> GetSport_club(int id)
        {
            Models.Sport_club sport_club = await db.Sport_club.FindAsync(id);
            if (sport_club == null)
            {
                return NotFound();
            }

            return Ok(sport_club);
        }

        // PUT: api/Sport_club/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSport_club(int id, Models.Sport_club sport_club)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sport_club.id_club)
            {
                return BadRequest();
            }

            db.Entry(sport_club).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sport_clubExists(id))
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

        // POST: api/Sport_club
        [ResponseType(typeof(Models.Sport_club))]
        public async Task<IHttpActionResult> PostSport_club(Models.Sport_club sport_club)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sport_club.Add(sport_club);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sport_club.id_club }, sport_club);
        }

        // DELETE: api/Sport_club/5
        [ResponseType(typeof(Models.Sport_club))]
        public async Task<IHttpActionResult> DeleteSport_club(int id)
        {
            Models.Sport_club sport_club = await db.Sport_club.FindAsync(id);
            if (sport_club == null)
            {
                return NotFound();
            }

            db.Sport_club.Remove(sport_club);
            await db.SaveChangesAsync();

            return Ok(sport_club);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sport_clubExists(int id)
        {
            return db.Sport_club.Count(e => e.id_club == id) > 0;
        }
    }
}