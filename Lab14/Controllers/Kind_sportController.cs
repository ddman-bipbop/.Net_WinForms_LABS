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
    public class Kind_sportController : Controller
    {
        private DotNetEntities db = new DotNetEntities();

        // GET: Kind_sport
        public async Task<ActionResult> Index()
        {
            return View(await db.Kind_sport.ToListAsync());
        }

        // GET: Kind_sport/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kind_sport kind_sport = await db.Kind_sport.FindAsync(id);
            if (kind_sport == null)
            {
                return HttpNotFound();
            }
            return View(kind_sport);
        }

        // GET: Kind_sport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kind_sport/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_kind,Name_kind,Group_kind")] Kind_sport kind_sport)
        {
            if (ModelState.IsValid)
            {
                db.Kind_sport.Add(kind_sport);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(kind_sport);
        }

        // GET: Kind_sport/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kind_sport kind_sport = await db.Kind_sport.FindAsync(id);
            if (kind_sport == null)
            {
                return HttpNotFound();
            }
            return View(kind_sport);
        }

        // POST: Kind_sport/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_kind,Name_kind,Group_kind")] Kind_sport kind_sport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kind_sport).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(kind_sport);
        }

        // GET: Kind_sport/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kind_sport kind_sport = await db.Kind_sport.FindAsync(id);
            if (kind_sport == null)
            {
                return HttpNotFound();
            }
            return View(kind_sport);
        }

        // POST: Kind_sport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Kind_sport kind_sport = await db.Kind_sport.FindAsync(id);
            db.Kind_sport.Remove(kind_sport);
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
