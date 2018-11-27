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
    public class ExemplariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Exemplaries
        public ActionResult Index()
        {
            return View(db.Exemplaries.ToList());
        }

        // GET: Exemplaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exemplary exemplary = db.Exemplaries.Find(id);
            if (exemplary == null)
            {
                return HttpNotFound();
            }
            return View(exemplary);
        }

        // GET: Exemplaries/Create
        public ActionResult Create( int id=0)
        {
            Exemplary exemplary = new Exemplary();

         
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                exemplary.MoyensCollection = db.Moyens.ToList();
                exemplary.SuivisCollection = db.Suivis.ToList();
                exemplary.LocalisationsCollection = db.Localisations.ToList();
                exemplary.TypeLocalisationsCollection = db.TypeLocalisations.ToList();
                exemplary.StatutsCollection = db.Statuts.ToList();

            }
            return View(exemplary);
        }

        public ActionResult AddOrEdit(int id=0)
        {
            Exemplary exemplary = new Exemplary();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                exemplary.MoyensCollection = db.Moyens.ToList();
            }
            return View(exemplary);
        }

        // POST: Exemplaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "exemplaireID,exemplaireCODE,designation,prix,suivi,location,typelocation,fournisseur,statut,Date_ES,Date_FS")] Exemplary exemplary)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.Exemplaries.Add(exemplary);
                    db.SaveChanges();
                }
               
                return RedirectToAction("Index", new { id=0});
            }

            return View(exemplary);
        }

        // GET: Exemplaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exemplary exemplary = db.Exemplaries.Find(id);
            if (exemplary == null)
            {
                return HttpNotFound();
            }
            return View(exemplary);
        }

        // POST: Exemplaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "exemplaireID,exemplaireCODE,designation,prix,suivi,location,typelocation,fournisseur,statut,Date_ES,Date_FS")] Exemplary exemplary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exemplary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exemplary);
        }

        // GET: Exemplaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exemplary exemplary = db.Exemplaries.Find(id);
            if (exemplary == null)
            {
                return HttpNotFound();
            }
            return View(exemplary);
        }

        // POST: Exemplaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exemplary exemplary = db.Exemplaries.Find(id);
            db.Exemplaries.Remove(exemplary);
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
