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
using PagedList.Mvc;
using PagedList;

namespace AirAsset.Controllers
{
    [Authorize]
    public class ExemplairesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /*
        // GET: 
        //[Authorize(Users = "papa.traore@airasset.com,matthieu.orain@airasset.com,gilles.verin@airasset.com,ahmed.seghrouchni@airasset.com")]
        public ActionResult Index()
        {
            var exemplaires = db.Exemplaires.Include(e => e.Moyen);
            return View(exemplaires.ToList());
        }
        */

        // GET: Exemplaires
        public ActionResult Index(string search, int? i, string SortOrder)
        {
            ViewBag.exemplaireCode = String.IsNullOrEmpty(SortOrder) ? "exemplairecode_desc" : "";
            ViewBag.designation = SortOrder == "designation" ? "designation_desc" : "designation";
            ViewBag.quantite = SortOrder == "quantite" ? "quantite_desc" : "quantite";
            ViewBag.prix = SortOrder == "prix" ? "prix_desc" : "prix";
            ViewBag.suivi = SortOrder == "suivi" ? "suivi_desc" : "suivi";
            ViewBag.location = SortOrder == "location" ? "location_desc" : "location";
            ViewBag.statut = SortOrder == "statut" ? "statut_desc" : "statut";
            ViewBag.date_es = SortOrder == "date_es" ? "date_es_desc" : "date_es";
            ViewBag.date_fs = SortOrder == "date_fs" ? "date_fs_desc" : "date_fs";

            var exemplaire = from e in db.Exemplaires select e;

            switch (SortOrder)
            {
                case "exemplairecode_desc":
                    exemplaire = exemplaire.OrderByDescending(e => e.exemplaireCODE);
                    break;
                case "designation":
                    exemplaire = exemplaire.OrderBy(e => e.designation);
                    break;
                case "designation_desc":
                    exemplaire = exemplaire.OrderByDescending(e => e.designation);
                    break;

                case "quantite":
                    exemplaire = exemplaire.OrderBy(e => e.quantite);
                    break;
                case "quantite_desc":
                    exemplaire = exemplaire.OrderByDescending(e => e.quantite);
                    break;
                case "prix":
                    exemplaire = exemplaire.OrderBy(e => e.prix);
                    break;
                case "prix_desc":
                    exemplaire = exemplaire.OrderByDescending(e => e.prix);
                    break;
                case "suivi":
                    exemplaire = exemplaire.OrderBy(e => e.suivi);
                    break;
                case "suivi_desc":
                    exemplaire = exemplaire.OrderByDescending(e => e.suivi);
                    break;
                case "location":
                    exemplaire = exemplaire.OrderBy(e => e.location);
                    break;
                case "location_desc":
                    exemplaire = exemplaire.OrderByDescending(e => e.location);
                    break;
                case "statut":
                    exemplaire = exemplaire.OrderBy(e => e.statut);
                    break;
                case "statut_desc":
                    exemplaire = exemplaire.OrderByDescending(e => e.statut);
                    break;
                case "date_es":
                    exemplaire = exemplaire.OrderBy(e => e.Date_ES);
                    break;
                case "date_es_desc":
                    exemplaire = exemplaire.OrderByDescending(e => e.Date_ES);
                    break;
                case "date_fs":
                    exemplaire = exemplaire.OrderBy(e => e.Date_FS);
                    break;
                case "date_fs_desc":
                    exemplaire = exemplaire.OrderByDescending(e => e.Date_FS);
                    break;
                    
                default:
                    exemplaire = exemplaire.OrderBy(e => e.exemplaireCODE);
                    break;
            }

            return View(exemplaire.Where(m => m.exemplaireCODE.StartsWith(search) || search == null).ToList().ToPagedList(i ?? 1, 10)); //pagination
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
        [Authorize(Roles = "canEdit")]
        public ActionResult Create(ApplicationModel app)
        {
            MoyensDropDownList();
            return View(new Exemplaire(app));
        }

        // POST: Exemplaires/Create
        //[Authorize(Users = "papa.traore@airasset.com,matthieu.orain@airasset.com,gilles.verin@airasset.com")]
        [Authorize(Roles = "canEdit")]
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


        //Research 
        public ActionResult Research(string search)
        {
            var exemplaires = from m in db.Exemplaires select m;
            if (!String.IsNullOrEmpty(search))
            {
                exemplaires = exemplaires.Where(m => m.exemplaireCODE.Contains(search));
            }
            return View(exemplaires.ToList());
        }

        //Export  data to csv

        public void exportToCsv()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();

            sw.WriteLine("\"Code Exemplaire\",\"Designation\",\"Quantite\",\"Prix\",\"Suivi\",\"Localisation\",\"Statut\",\"Entree en Service\",\"Fin de Service\"");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=exportedExemplaires.csv");
            Response.ContentType = "text/csv";

            var exemplaires = db.Exemplaires;

            foreach (var exemplaire in exemplaires)
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\"",

                exemplaire.exemplaireCODE,
                exemplaire.designation,
                exemplaire.quantite,
                exemplaire.prix,
                exemplaire.suivi,
                exemplaire.location,
                exemplaire.statut,
                exemplaire.Date_ES,
                exemplaire.Date_FS)
                );
            }
            Response.Write(sw.ToString());
            Response.End();
        }


        
    }
}
