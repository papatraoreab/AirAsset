using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirAsset.Models;

namespace AirAsset.Controllers
{
    [Authorize]
    public class ExemplairesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Exemplaires
        //[Authorize(Users = "papa.traore@airasset.com,matthieu.orain@airasset.com,gilles.verin@airasset.com,ahmed.seghrouchni@airasset.com")]
        public ActionResult Index()
        {
            var exemplaires = db.Exemplaires.Include(e => e.Moyen);
            return View(exemplaires.ToList());
        }

        // GET: Exemplaires/Details/5
        //[Authorize(Users = "papa.traore@airasset.com,matthieu.orain@airasset.com,gilles.verin@airasset.com,ahmed.seghrouchni@airasset.com")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exemplaire exemplaire = db.Exemplaires.Find(id);
            if (exemplaire == null)
            {
                return HttpNotFound();
            }
            return View(exemplaire);
        }


        /* default 4 methods of Create and Edit

        // GET: Exemplaires/Create
        public ActionResult Create(ApplicationModel app)
        {
            ViewBag.moyenID = new SelectList(db.Moyens, "moyenID", "moyenCODE");
            return View(new Exemplaire(app));
        }

        // POST: Exemplaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "exemplaireID,moyenID,designation,exemplaireCODE,quantite,prix,suivi,location,fournisseur,statut,Date_ES,Date_FS")] Exemplaire exemplaire)
        {
            if (ModelState.IsValid)
            {
                db.Exemplaires.Add(exemplaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.moyenID = new SelectList(db.Moyens, "moyenID", "moyenCODE", exemplaire.moyenID);
            return View(exemplaire);
        }

        // GET: Exemplaires/Edit/5
        public ActionResult Edit(int? id, ApplicationModel app)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exemplaire exemplaire = db.Exemplaires.Find(id);

            if (exemplaire == null)
            {
                return HttpNotFound();
            }
            ViewBag.moyenID = new SelectList(db.Moyens, "moyenID", "moyenCODE", exemplaire.moyenID);
            return View(new Exemplaire(app));
        }

        // POST: Exemplaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "exemplaireID,moyenID,designation,exemplaireCODE,quantite,prix,suivi,location,fournisseur,statut,Date_ES,Date_FS")] Exemplaire exemplaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exemplaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.moyenID = new SelectList(db.Moyens, "moyenID", "moyenCODE", exemplaire.moyenID);
            return View(exemplaire);
        }


        */

        // start new 4 methods of Create and Edit

        // GET: Exemplaires/Create
        //[Authorize(Users = "papa.traore@airasset.com,matthieu.orain@airasset.com,gilles.verin@airasset.com")]
        public ActionResult Create(ApplicationModel app)
        {
            MoyensDropDownList();
            return View(new Exemplaire(app));
        }

        // POST: Exemplaires/Create
        //[Authorize(Users = "papa.traore@airasset.com,matthieu.orain@airasset.com,gilles.verin@airasset.com")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "exemplaireID,moyenID,designation,exemplaireCODE,quantite,prix,suivi,location,fournisseur,statut,Date_ES,Date_FS")]Exemplaire exemplaire)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Exemplaires.Add(exemplaire);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            MoyensDropDownList(exemplaire.moyenID);
            return View(exemplaire);
        }

        // GET: Exemplaires/Edit/5
        //[Authorize(Users = "papa.traore@airasset.com,matthieu.orain@airasset.com,gilles.verin@airasset.com")]
        [Authorize(Roles ="canEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exemplaire exemplaire = db.Exemplaires.Find(id);
            if (exemplaire == null)
            {
                return HttpNotFound();
            }
            MoyensDropDownList(exemplaire.moyenID);
            return View(exemplaire);
        }

        // POST: Exemplaires/Edit/5
        //[Authorize(Users = "papa.traore@airasset.com,matthieu.orain@airasset.com,gilles.verin@airasset.com")]
        [Authorize(Roles = "canEdit")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var exemplaireToUpdate = db.Exemplaires.Find(id);
            if (TryUpdateModel(exemplaireToUpdate, "",
               new string[] { "moyenID", "designation", "exemplaireCODE", "quantite", "prix", "suivi", "location", "fournisseur", "statut", "Date_ES", "Date_FS" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            MoyensDropDownList(exemplaireToUpdate.moyenID);
            return View(exemplaireToUpdate);
        }

        private void MoyensDropDownList(object selectedMoyen = null)
        {
            var moyensQuery = from d in db.Moyens
                                   orderby d.moyenCODE
                                   select d;
 
            ViewBag.moyenID = new SelectList(moyensQuery, "moyenID", "moyenCODE", selectedMoyen);
        }

        // end new 4 methods of Create and Edit


        // GET: Exemplaires/Delete/5
        //[Authorize(Users = "papa.traore@airasset.com,matthieu.orain@airasset.com")]
        [Authorize(Roles = "canEdit")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exemplaire exemplaire = db.Exemplaires.Find(id);
            if (exemplaire == null)
            {
                return HttpNotFound();
            }
            return View(exemplaire);
        }

        // POST: Exemplaires/Delete/5
        //[Authorize(Users = "papa.traore@airasset.com,matthieu.orain@airasset.com")]
        [Authorize(Roles = "canEdit")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exemplaire exemplaire = db.Exemplaires.Find(id);
            db.Exemplaires.Remove(exemplaire);
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
