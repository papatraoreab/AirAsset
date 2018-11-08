using AirAsset.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirAsset.Controllers
{
    public class FileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: File
        public ActionResult Index( int id)        {
            var fileToRetrieve = db.Files.Find(id);
            return File(fileToRetrieve.content, fileToRetrieve.contentType);
        }
    }
}