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
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

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
        public ActionResult Index(string search, int? i, string SortOrder, string SelectedReference, string SelectedDesignation, string SelectedSuivi, string SelectedLocalisation, string SelectedTypeLocalisation, string SelectedStatut)
        {
            ViewBag.reference = String.IsNullOrEmpty(SortOrder) ? "reference_desc" : "";
            ViewBag.exemplaireCode = SortOrder == "exemplaireCODE" ? "exemplaireCODE_desc" : "exemplaireCODE";
            ViewBag.designation = SortOrder == "designation" ? "designation_desc" : "designation";
            ViewBag.prix = SortOrder == "prix" ? "prix_desc" : "prix";
            ViewBag.suivi = SortOrder == "suivi" ? "suivi_desc" : "suivi";
            ViewBag.location = SortOrder == "location" ? "location_desc" : "location";
            ViewBag.typelocation = SortOrder == "typelocation" ? "typelocation_desc" : "typelocation";
            ViewBag.statut = SortOrder == "statut" ? "statut_desc" : "statut";
            ViewBag.date_es = SortOrder == "date_es" ? "date_es_desc" : "date_es";
            ViewBag.date_fs = SortOrder == "date_fs" ? "date_fs_desc" : "date_fs";

            var rawData = (from e in db.Exemplaires select e).Where(e => e.reference.Contains(search) || search == null).ToList();//filter dropdownlist and include value 
            //search by exemplaireCODE
            
            var exemplaire = from e in rawData select e;


            //filter dropdownlist
            if (!String.IsNullOrEmpty(SelectedReference))
            {
                exemplaire = exemplaire.Where(e => e.reference.Trim().Equals(SelectedReference.Trim()));

            }
            if (!String.IsNullOrEmpty(SelectedDesignation))
            {
                exemplaire = exemplaire.Where(e => e.designation.Trim().Equals(SelectedDesignation.Trim()));
            }
            if (!String.IsNullOrEmpty(SelectedSuivi))
            {
                exemplaire = exemplaire.Where(e => e.suivi.Trim().Equals(SelectedSuivi.Trim()));
            }

            if (!String.IsNullOrEmpty(SelectedLocalisation))
            {
                exemplaire = exemplaire.Where(e => e.location.Trim().Equals(SelectedLocalisation.Trim()));
            }

            if (!String.IsNullOrEmpty(SelectedTypeLocalisation))
            {
                exemplaire = exemplaire.Where(e => e.typelocation.Trim().Equals(SelectedTypeLocalisation.Trim()));
            }

            if (!String.IsNullOrEmpty(SelectedStatut))
            {
                exemplaire = exemplaire.Where(e => e.statut.Trim().Equals(SelectedStatut.Trim()));
            }

            var UniqueReference = from e in exemplaire group e by e.reference into newGroup where newGroup.Key != null orderby newGroup.Key select new { reference = newGroup.Key };
            ViewBag.UniqueReference = UniqueReference.Select(e => new SelectListItem { Value = e.reference, Text = e.reference }).ToList();

            var UniqueDesignation = from e in exemplaire group e by e.designation into newGroup where newGroup.Key != null orderby newGroup.Key select new { designation = newGroup.Key };
            ViewBag.UniqueDesignation = UniqueDesignation.Select(e => new SelectListItem { Value = e.designation, Text = e.designation }).ToList();

            var UniqueSuivi = from e in exemplaire group e by e.suivi into newGroup where newGroup.Key != null orderby newGroup.Key select new { suivi = newGroup.Key };
            ViewBag.UniqueSuivi = UniqueSuivi.Select(e => new SelectListItem { Value = e.suivi, Text = e.suivi }).ToList();

            var UniqueLocalisation = from e in exemplaire group e by e.location into newGroup where newGroup.Key != null orderby newGroup.Key select new { location = newGroup.Key };
            ViewBag.UniqueLocalisation = UniqueLocalisation.Select(e => new SelectListItem { Value = e.location, Text = e.location }).ToList();

            var UniqueTypeLocalisation = from e in exemplaire group e by e.typelocation into newGroup where newGroup.Key != null orderby newGroup.Key select new { typelocation = newGroup.Key };
            ViewBag.UniqueTypeLocalisation = UniqueTypeLocalisation.Select(e => new SelectListItem { Value = e.typelocation, Text = e.typelocation }).ToList();

            var UniqueStatut = from e in exemplaire group e by e.statut into newGroup where newGroup.Key != null orderby newGroup.Key select new { statut = newGroup.Key };
            ViewBag.UniqueStatut = UniqueStatut.Select(e => new SelectListItem { Value = e.statut, Text = e.statut }).ToList();

            ViewBag.SelectedReference = SelectedReference;
            ViewBag.SelectedDesignation = SelectedDesignation;
            ViewBag.SelectedSuivi = SelectedSuivi;
            ViewBag.SelectedLocalisation = SelectedLocalisation;
            ViewBag.SelectedTypeLocalisation = SelectedTypeLocalisation;
            ViewBag.SelectedStatut = SelectedStatut;

            //end




            switch (SortOrder)
            {
                case "reference":
                    exemplaire = exemplaire.OrderByDescending(e => e.reference);
                    break;

                case "exemplaireCODE":
                    exemplaire = exemplaire.OrderBy(e => e.exemplaireCODE);
                    break;
                case "exemplaireCODE_desc":
                    exemplaire = exemplaire.OrderByDescending(e => e.exemplaireCODE);
                    break;

                case "designation":
                    exemplaire = exemplaire.OrderBy(e => e.designation);
                    break;
                case "designation_desc":
                    exemplaire = exemplaire.OrderByDescending(e => e.designation);
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
                case "typelocation":
                    exemplaire = exemplaire.OrderBy(e => e.location);
                    break;
                case "typelocation_desc":
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
                    exemplaire = exemplaire.OrderBy(e => e.reference);
                    break;
            }

            return View(exemplaire.ToList().ToPagedList(i ?? 1, 10)); //pagination

            //prise en charge recherche mettre :  return View(exemplaire.Where(m => m.exemplaireCODE.Contains(search) || search == null).ToList().ToPagedList(i ?? 1, 10));
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
        public ActionResult Create([Bind(Include = "exemplaireID,moyenID,designation,exemplaireCODE,quantite,prix,suivi,location,typelocation,fournisseur,statut,Date_ES,Date_FS")] Exemplaire exemplaire)
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
        public ActionResult Edit([Bind(Include = "exemplaireID,moyenID,designation,exemplaireCODE,quantite,prix,suivi,location,typelocation,fournisseur,statut,Date_ES,Date_FS")] Exemplaire exemplaire)
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
        public ActionResult Create(ApplicationModel app, int id = 0)
        {
            Exemplaire exemplaires = new Exemplaire(app);
           

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                exemplaires.MoyensCollection = db.Moyens.ToList();
               

            }

            return View(exemplaires);
        }

        // POST: Exemplaires/Create
        //[Authorize(Users = "papa.traore@airasset.com,matthieu.orain@airasset.com,gilles.verin@airasset.com")]
        [Authorize(Roles = "canEdit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "exemplaireID,reference,designation,exemplaireCODE,prix,suivi,location,typelocation,fournisseur,statut,Date_ES,Date_FS")]Exemplaire exemplaire)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        db.Exemplaires.Add(exemplaire);
                        db.SaveChanges();
                    }
                        
                    return RedirectToAction("Details", new { id = exemplaire.exemplaireID }); //after creating exemplaire, return to cureent details of exemplaire
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            
            return View(exemplaire);
        }

        // GET: Exemplaires/Edit/5
        //[Authorize(Users = "papa.traore@airasset.com,matthieu.orain@airasset.com,gilles.verin@airasset.com")]
        [Authorize(Roles ="canEdit")]
        public ActionResult Edit(int? id, ApplicationModel app)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Exemplaire exemplaire = new Exemplaire(app);
            Exemplaire exemplaire = db.Exemplaires.Find(id);
            if (exemplaire == null)
            {
                return HttpNotFound();
            }


            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                exemplaire.MoyensCollection = db.Moyens.ToList();
                exemplaire.ExemplairesCollection = db.Exemplaires.ToList();
            }
            
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
               new string[] { "reference", "designation", "exemplaireCODE", "prix", "suivi", "location","typelocation", "fournisseur", "statut", "Date_ES", "Date_FS" }))
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
          
            return View(exemplaireToUpdate);
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
            var exemplaires = from e in db.Exemplaires select e;
            if (!String.IsNullOrEmpty(search))
            {
                exemplaires = exemplaires.Where(e => e.reference.Contains(search));
            }
            return View(exemplaires.ToList());
        }

        //Export  data to csv

        public void exportToCsv()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();

            sw.WriteLine("\"Code Exemplaire\",\"Designation\",\"Prix\",\"Suivi\",\"Localisation\",\"Statut\",\"Entree en Service\",\"Fin de Service\"");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=exportedExemplaires.csv");
            Response.ContentType = "application/ms-excel";
            

            var exemplaires = db.Exemplaires;

            foreach (var exemplaire in exemplaires)
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\"",

                exemplaire.exemplaireCODE,
                exemplaire.designation,
                exemplaire.prix,
                exemplaire.suivi,
                exemplaire.location,
                exemplaire.typelocation,
                exemplaire.statut,
                exemplaire.Date_ES,
                exemplaire.Date_FS)
                );
            }
            Response.Write(sw.ToString());
            Response.End();
        }



        public ActionResult Export()
        {

            var gv = new GridView();
            var exemplaires = db.Exemplaires;

            gv.DataSource = exemplaires;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("Index");
            
        }


    }
}
