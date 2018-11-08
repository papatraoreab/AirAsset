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
    public class MoyensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Moyens
        public ActionResult Index()
        {
            return View(db.Moyens.ToList());
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
        public ActionResult Create(ApplicationModel app)
        {
            return View(new Moyen(app));
        }

        // POST: Moyens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "moyenID,moyenCODE,designation,secteur,program,entrepot,type,description,poids,cmu,hauteur," +
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
        public ActionResult Edit([Bind(Include = "moyenID,moyenCODE,designation,secteur,program,entrepot,type,description,poids,cmu,hauteur,longueur,largeur,vVent,r_number,t_number")] Moyen moyen)
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
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id, HttpPostedFileBase upload)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var moyenToUpdate = db.Moyens.Find(id);
            if (TryUpdateModel(moyenToUpdate, "",
                new string[] { "moyenCODE", "designation", "secteur", "program", "entrepot", "type", "description",
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
    }
}
