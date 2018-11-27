using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirAsset.Models;

namespace AirAsset.Controllers
{
    public class LocalisationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Localisations
        public ActionResult Index()
        {
            return View(db.Localisations.ToList());
        }

        // GET: Localisations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localisation localisation = db.Localisations.Find(id);
            if (localisation == null)
            {
                return HttpNotFound();
            }
            return View(localisation);
        }

        // GET: Localisations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Localisations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "localisationId,localisation")] Localisation localisation)
        {
            if (ModelState.IsValid)
            {
                db.Localisations.Add(localisation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(localisation);
        }

        // GET: Localisations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localisation localisation = db.Localisations.Find(id);
            if (localisation == null)
            {
                return HttpNotFound();
            }
            return View(localisation);
        }

        // POST: Localisations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "localisationId,localisation")] Localisation localisation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(localisation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(localisation);
        }

        // GET: Localisations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localisation localisation = db.Localisations.Find(id);
            if (localisation == null)
            {
                return HttpNotFound();
            }
            return View(localisation);
        }

        // POST: Localisations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Localisation localisation = db.Localisations.Find(id);
            db.Localisations.Remove(localisation);
            db.SaveChanges();
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
