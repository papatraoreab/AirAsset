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
    public class SecteursController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Secteurs
        public ActionResult Index()
        {
            return View(db.Secteurs.ToList());
        }

        // GET: Secteurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secteur secteur = db.Secteurs.Find(id);
            if (secteur == null)
            {
                return HttpNotFound();
            }
            return View(secteur);
        }

        // GET: Secteurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Secteurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "secteurId,secteur")] Secteur secteur)
        {
            if (ModelState.IsValid)
            {
                db.Secteurs.Add(secteur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(secteur);
        }

        // GET: Secteurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secteur secteur = db.Secteurs.Find(id);
            if (secteur == null)
            {
                return HttpNotFound();
            }
            return View(secteur);
        }

        // POST: Secteurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "secteurId,secteur")] Secteur secteur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(secteur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(secteur);
        }

        // GET: Secteurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secteur secteur = db.Secteurs.Find(id);
            if (secteur == null)
            {
                return HttpNotFound();
            }
            return View(secteur);
        }

        // POST: Secteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Secteur secteur = db.Secteurs.Find(id);
            db.Secteurs.Remove(secteur);
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
