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
    public class TypeLocalisationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TypeLocalisations
        public ActionResult Index()
        {
            return View(db.TypeLocalisations.ToList());
        }

        // GET: TypeLocalisations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeLocalisation typeLocalisation = db.TypeLocalisations.Find(id);
            if (typeLocalisation == null)
            {
                return HttpNotFound();
            }
            return View(typeLocalisation);
        }

        // GET: TypeLocalisations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeLocalisations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "typelocalisationId,typelocalisation")] TypeLocalisation typeLocalisation)
        {
            if (ModelState.IsValid)
            {
                db.TypeLocalisations.Add(typeLocalisation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeLocalisation);
        }

        // GET: TypeLocalisations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeLocalisation typeLocalisation = db.TypeLocalisations.Find(id);
            if (typeLocalisation == null)
            {
                return HttpNotFound();
            }
            return View(typeLocalisation);
        }

        // POST: TypeLocalisations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "typelocalisationId,typelocalisation")] TypeLocalisation typeLocalisation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeLocalisation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeLocalisation);
        }

        // GET: TypeLocalisations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeLocalisation typeLocalisation = db.TypeLocalisations.Find(id);
            if (typeLocalisation == null)
            {
                return HttpNotFound();
            }
            return View(typeLocalisation);
        }

        // POST: TypeLocalisations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeLocalisation typeLocalisation = db.TypeLocalisations.Find(id);
            db.TypeLocalisations.Remove(typeLocalisation);
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
