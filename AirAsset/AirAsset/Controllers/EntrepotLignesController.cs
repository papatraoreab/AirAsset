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
    public class EntrepotLignesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EntrepotLignes
        public ActionResult Index()
        {
            return View(db.EntrepotLignes.ToList());
        }

        // GET: EntrepotLignes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntrepotLigne entrepotLigne = db.EntrepotLignes.Find(id);
            if (entrepotLigne == null)
            {
                return HttpNotFound();
            }
            return View(entrepotLigne);
        }

        // GET: EntrepotLignes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntrepotLignes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "entrepotID,entrepot")] EntrepotLigne entrepotLigne)
        {
            if (ModelState.IsValid)
            {
                db.EntrepotLignes.Add(entrepotLigne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entrepotLigne);
        }

        // GET: EntrepotLignes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntrepotLigne entrepotLigne = db.EntrepotLignes.Find(id);
            if (entrepotLigne == null)
            {
                return HttpNotFound();
            }
            return View(entrepotLigne);
        }

        // POST: EntrepotLignes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "entrepotID,entrepot")] EntrepotLigne entrepotLigne)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrepotLigne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entrepotLigne);
        }

        // GET: EntrepotLignes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntrepotLigne entrepotLigne = db.EntrepotLignes.Find(id);
            if (entrepotLigne == null)
            {
                return HttpNotFound();
            }
            return View(entrepotLigne);
        }

        // POST: EntrepotLignes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntrepotLigne entrepotLigne = db.EntrepotLignes.Find(id);
            db.EntrepotLignes.Remove(entrepotLigne);
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
