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
    public class StatutsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Statuts
        public ActionResult Index()
        {
            return View(db.Statuts.ToList());
        }

        // GET: Statuts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statut statut = db.Statuts.Find(id);
            if (statut == null)
            {
                return HttpNotFound();
            }
            return View(statut);
        }

        // GET: Statuts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Statuts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "statutID,statut")] Statut statut)
        {
            if (ModelState.IsValid)
            {
                db.Statuts.Add(statut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statut);
        }

        // GET: Statuts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statut statut = db.Statuts.Find(id);
            if (statut == null)
            {
                return HttpNotFound();
            }
            return View(statut);
        }

        // POST: Statuts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "statutID,statut")] Statut statut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statut).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statut);
        }

        // GET: Statuts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statut statut = db.Statuts.Find(id);
            if (statut == null)
            {
                return HttpNotFound();
            }
            return View(statut);
        }

        // POST: Statuts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Statut statut = db.Statuts.Find(id);
            db.Statuts.Remove(statut);
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
