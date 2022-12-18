using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab14;

namespace Lab14.Controllers
{
    public class Sport_clubController : Controller
    {
        private DotNetEntities db = new DotNetEntities();

        // GET: Sport_club
        public async Task<ActionResult> Index()
        {
            var sport_club = db.Sport_club.Include(s => s.Kind_sport);
            return View(await sport_club.ToListAsync());
        }

        // GET: Sport_club/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sport_club sport_club = await db.Sport_club.FindAsync(id);
            if (sport_club == null)
            {
                return HttpNotFound();
            }
            return View(sport_club);
        }

        // GET: Sport_club/Create
        public ActionResult Create()
        {
            ViewBag.id_kind = new SelectList(db.Kind_sport, "id_kind", "Name_kind");
            return View();
        }

        // POST: Sport_club/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_club,id_kind,Name_club,Text_club,CreateDate_club,Image_club")] Sport_club sport_club)
        {
            if (ModelState.IsValid)
            {
                db.Sport_club.Add(sport_club);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_kind = new SelectList(db.Kind_sport, "id_kind", "Name_kind", sport_club.id_kind);
            return View(sport_club);
        }

        // GET: Sport_club/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sport_club sport_club = await db.Sport_club.FindAsync(id);
            if (sport_club == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_kind = new SelectList(db.Kind_sport, "id_kind", "Name_kind", sport_club.id_kind);
            return View(sport_club);
        }

        // POST: Sport_club/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_club,id_kind,Name_club,Text_club,CreateDate_club,Image_club")] Sport_club sport_club)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sport_club).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_kind = new SelectList(db.Kind_sport, "id_kind", "Name_kind", sport_club.id_kind);
            return View(sport_club);
        }

        // GET: Sport_club/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sport_club sport_club = await db.Sport_club.FindAsync(id);
            if (sport_club == null)
            {
                return HttpNotFound();
            }
            return View(sport_club);
        }

        // POST: Sport_club/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Sport_club sport_club = await db.Sport_club.FindAsync(id);
            db.Sport_club.Remove(sport_club);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
