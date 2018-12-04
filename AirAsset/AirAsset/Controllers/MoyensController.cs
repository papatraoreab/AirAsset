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
    public class MoyensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Moyens
        /*
        public ActionResult Index()
        {
            return View(db.Moyens.ToList());
        }
        */

        // GET: Moyens
        public ActionResult Index(string search, int? i, string SortOrder, string SelectedCode, string SelectedDesignation, string SelectedSecteur, string SelectedProgramme, string SelectedEntrepot, string SelectedType)
        {
            ViewBag.moyenCode = String.IsNullOrEmpty(SortOrder) ? "moyencode_desc" : "";
            ViewBag.designation = SortOrder == "designation" ? "designation_desc" : "designation";
            ViewBag.quantite = SortOrder == "quantite" ? "quantite_desc" : "quantite";
            ViewBag.secteur = SortOrder == "secteur" ? "secteur_desc" : "secteur";
            ViewBag.program = SortOrder == "program" ? "program_desc" : "program";
            ViewBag.entrepotouligne = SortOrder == "entrepotouligne" ? "entrepotouligne_desc" : "entrepotouligne";
            ViewBag.type = SortOrder == "type" ? "type_desc" : "type";

            var rawData = (from m in db.Moyens select m).Where(m => m.designation.Contains(search) || search == null).ToList(); //filter dropdownlist and include value 
            //search by description
            var moyen = from m in rawData select m;

            //filter dropdownlist
            if (!String.IsNullOrEmpty(SelectedCode))
            {
                moyen = moyen.Where(m => m.moyenCODE.Trim().Equals(SelectedCode.Trim()));
            }

            if (!String.IsNullOrEmpty(SelectedDesignation))
            {
                moyen = moyen.Where(m => m.designation.Trim().Equals(SelectedDesignation.Trim()));
            }
            

            if (!String.IsNullOrEmpty(SelectedSecteur))
            {
                moyen = moyen.Where(m => m.secteur.Trim().Equals(SelectedSecteur.Trim()));
            }

            if (!String.IsNullOrEmpty(SelectedProgramme))
            {
                moyen = moyen.Where(m => m.program.Trim().Equals(SelectedProgramme.Trim()));
            }

            if (!String.IsNullOrEmpty(SelectedEntrepot))
            {
                moyen = moyen.Where(m => m.entrepot.Trim().Equals(SelectedEntrepot.Trim()));
            }

            if (!String.IsNullOrEmpty(SelectedType))
            {
                moyen = moyen.Where(m => m.type.Trim().Equals(SelectedType.Trim()));
            }

            var UniqueCode = from m in moyen group m by m.moyenCODE into newGroup where newGroup.Key != null orderby newGroup.Key select new { moyenCODE = newGroup.Key };
            ViewBag.UniqueCode = UniqueCode.Select(m => new SelectListItem { Value = m.moyenCODE, Text = m.moyenCODE }).ToList();


            var UniqueDesignation = from m in moyen group m by m.designation into newGroup where newGroup.Key != null orderby newGroup.Key select new { designation = newGroup.Key };
            ViewBag.UniqueDesignation = UniqueDesignation.Select(m => new SelectListItem { Value = m.designation, Text = m.designation }).ToList();


            var UniqueSecteur = from m in moyen group m by m.secteur into newGroup where newGroup.Key != null orderby newGroup.Key select new { secteur = newGroup.Key };
            ViewBag.UniqueSecteur = UniqueSecteur.Select(m => new SelectListItem { Value = m.secteur, Text = m.secteur }).ToList();

            var UniqueProgramme = from m in moyen group m by m.program into newGroup where newGroup.Key != null orderby newGroup.Key select new { program = newGroup.Key };
            ViewBag.UniqueProgramme = UniqueProgramme.Select(m => new SelectListItem { Value = m.program, Text = m.program }).ToList();

            var UniqueEntrepot = from m in moyen group m by m.entrepot into newGroup where newGroup.Key != null orderby newGroup.Key select new { entrepot = newGroup.Key };
            ViewBag.UniqueEntrepot = UniqueEntrepot.Select(m => new SelectListItem { Value = m.entrepot, Text = m.entrepot }).ToList();

            var UniqueType = from m in moyen group m by m.type into newGroup where newGroup.Key != null orderby newGroup.Key select new { type = newGroup.Key };
            ViewBag.UniqueType = UniqueType.Select(m => new SelectListItem { Value = m.type, Text = m.type }).ToList();

         
            ViewBag.SelectedCode = SelectedCode;
            ViewBag.SelectedDesignation = SelectedDesignation;
            ViewBag.SelectedSecteur = SelectedSecteur;
            ViewBag.SelectedProgramme = SelectedProgramme;
            ViewBag.SelectedEntrepot = SelectedEntrepot;
            ViewBag.SelectedType = SelectedType;


            switch (SortOrder)
            {
                case "moyencode_desc":
                    moyen = moyen.OrderByDescending(m => m.moyenCODE);
                    break;
                case "designation":
                    moyen = moyen.OrderBy(m => m.designation);
                    break;
                case "designation_desc":
                    moyen = moyen.OrderByDescending(m => m.designation);
                    break;

                case "quantite":
                    moyen = moyen.OrderBy(m => m.quantite);
                    break;
                case "quantite_desc":
                    moyen = moyen.OrderByDescending(m => m.quantite);
                    break;

                case "secteur":
                    moyen = moyen.OrderBy(m => m.secteur);
                    break;
                case "secteur_desc":
                    moyen = moyen.OrderByDescending(m => m.secteur);
                    break;

                case "program":
                    moyen = moyen.OrderBy(m => m.program);
                    break;
                case "program_desc":
                    moyen = moyen.OrderByDescending(m => m.program);
                    break;

                case "entrepotouligne":
                    moyen = moyen.OrderBy(m => m.entrepot);
                    break;
                case "entrepotouligne_desc":
                    moyen = moyen.OrderByDescending(m => m.entrepot);
                    break;

                case "type":
                    moyen = moyen.OrderBy(m => m.type);
                    break;
                case "type_desc":
                    moyen = moyen.OrderByDescending(m => m.type);
                    break;

                default:
                    moyen = moyen.OrderBy(m => m.moyenCODE);
                    break;
            }

            return View(moyen.ToList().ToPagedList(i ?? 1, 10)); //pagination
            //return View(moyen.Where(m => m.designation.Contains(search) || search == null).ToList().ToPagedList(i ?? 1, 10));
        }

        // GET: Moyens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moyen moyen = db.Moyens.Include(s => s.Files).SingleOrDefault(s => s.moyenID == id); //customised to includ method in the linq query 
            //that fetches the moyen from the database to bring back releated files
            if (moyen == null)
            {
                return HttpNotFound();
            }
            return View(moyen);
        }

        // GET: Moyens/Create
        [Authorize(Roles = "canEdit")]
        public ActionResult Create(ApplicationModel app)
        {
            return View(new Moyen(app));
        }

        // POST: Moyens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "canEdit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "moyenID,moyenCODE,designation,quantite,secteur,program,entrepot,type,description,poids,cmu,hauteur," +
            "longueur,largeur,vVent,r_number,t_number")] Moyen moyen, HttpPostedFileBase upload) // is added upload
        { //implementation customised, to to take into account the loading of the file
            try
            {

                if (ModelState.IsValid)
                {
                    //upload files
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var capture = new Models.File

                        {
                            fileName = System.IO.Path.GetFileName(upload.FileName),
                            

                            FileType = FileType.Capture,
                            contentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            capture.content = reader.ReadBytes(upload.ContentLength);
                        }
                        moyen.Files = new List<Models.File> { capture };
                    }

                   

                    db.Moyens.Add(moyen);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            catch (System.Data.Entity.Infrastructure.RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(moyen);
        }

        // GET: Moyens/Edit/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Moyen moyen = db.Moyens.Include(s => s.Files).SingleOrDefault(s => s.moyenID == id);//customised to includ method in the linq query 
            //that fetches the moyen from the database to bring back releated files
            if (moyen == null)
            {
                return HttpNotFound();
            }

            //added to collect dropdown list to db Moyens using object MoyensCollection
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                moyen.MoyensCollection = db.Moyens.ToList();
            }

            return View(moyen);
        }

        /* this default methods has been modified, replace by the EditPost methods (see below EditPost)
         * 
         * 
        // POST: Moyens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "moyenID,moyenCODE,designation,quantite,secteur,program,entrepot,type,description,poids,cmu,hauteur,longueur,largeur,vVent,r_number,t_number")] Moyen moyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moyen);
        }*/


        //changes|modification maked to Edit (see above) to implemeted the file upload change

        // POST: Moyens/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult EditPost(int? id, HttpPostedFileBase upload)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var moyenToUpdate = db.Moyens.Find(id);
            if (TryUpdateModel(moyenToUpdate, "",
                new string[] { "moyenCODE", "designation","quantite", "secteur", "program", "entrepot", "type", "description",
                    "poids", "cmu", "hauteur" , "longueur", "largeur", "vVent", "r_number", "t_number" }))
            {
                try
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        if (moyenToUpdate.Files.Any(f => f.FileType == FileType.Capture))
                        {
                            db.Files.Remove(moyenToUpdate.Files.First(f => f.FileType == FileType.Capture));
                        }
                        var capture = new File
                        {
                            fileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Capture,
                            contentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            capture.content = reader.ReadBytes(upload.ContentLength);
                        }
                        moyenToUpdate.Files = new List<File> { capture };
                    }


                   

                    db.Entry(moyenToUpdate).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(moyenToUpdate);
        }

        // end changes|modification to the HttpPost Edit


        // GET: Moyens/Delete/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moyen moyen = db.Moyens.Find(id);
            if (moyen == null)
            {
                return HttpNotFound();
            }
            return View(moyen);
        }

        // POST: Moyens/Delete/5
        [Authorize(Roles = "canEdit")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Moyen moyen = db.Moyens.Find(id);
            db.Moyens.Remove(moyen);
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
            var moyens = from m in db.Moyens select m;
            if (!String.IsNullOrEmpty(search))
            {
                moyens = moyens.Where(m => m.designation.Contains(search));
            }
            return View(moyens.ToList());
        }

       
        //moyens export
        public void exportToCsv()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();

            sw.WriteLine("\"Code Moyen\",\"Designation\",\"Quantite\",\"Secteur\",\"Programme\",\"Entrepot ou Ligne\",\"Type\",\"Description\",\"Poids\",\"CMU\"," +
                "\"Hauteur\",\"Longueur\",\"Largeur\",\"Vitesse du Vent\",\"RUS Number\",\"Tool Number\"");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=exportedMoyens.csv");
            Response.ContentType = "text/csv";

            var moyens = db.Moyens;

            foreach (var moyen in moyens)
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\"",

                moyen.moyenCODE,
                moyen.designation,
                moyen.quantite,
                moyen.secteur,
                moyen.program,
                moyen.entrepot,
                moyen.type,
                moyen.description,
                moyen.poids,
                moyen.cmu,
                moyen.hauteur,
                moyen.longueur,
                moyen.largeur,
                moyen.vVent,
                moyen.r_number,
                moyen.t_number)
                );
            }
            Response.Write(sw.ToString());
            Response.End();
        }

        //liste des exemplaires de moyens 
        public ActionResult List(string search, int? i)
        {
            var moyen = from m in db.Moyens select m;

            return View(moyen.Where(m => m.moyenCODE.StartsWith(search) || search == null).ToList().ToPagedList(i ?? 1, 10)); //pagination;
        }
    }
}
