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
    public class TypeMoyensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TypeMoyens
        public ActionResult Index()
        {
            return View(db.TypeMoyens.ToList());
        }

        // GET: TypeMoyens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeMoyen typeMoyen = db.TypeMoyens.Find(id);
            if (typeMoyen == null)
            {
                return HttpNotFound();
            }
            return View(typeMoyen);
        }

        // GET: TypeMoyens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeMoyens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "typemoyenID,typemoyen")] TypeMoyen typeMoyen)
        {
            if (ModelState.IsValid)
            {
                db.TypeMoyens.Add(typeMoyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeMoyen);
        }

        // GET: TypeMoyens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeMoyen typeMoyen = db.TypeMoyens.Find(id);
            if (typeMoyen == null)
            {
                return HttpNotFound();
            }
            return View(typeMoyen);
        }

        // POST: TypeMoyens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "typemoyenID,typemoyen")] TypeMoyen typeMoyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeMoyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeMoyen);
        }

        // GET: TypeMoyens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeMoyen typeMoyen = db.TypeMoyens.Find(id);
            if (typeMoyen == null)
            {
                return HttpNotFound();
            }
            return View(typeMoyen);
        }

        // POST: TypeMoyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeMoyen typeMoyen = db.TypeMoyens.Find(id);
            db.TypeMoyens.Remove(typeMoyen);
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
