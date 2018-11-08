using AirAsset.Infrastructure;
using AirAsset.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AirAsset
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Auto généré
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Database.SetInitializer<DossierAPIsContext>(new DropCreateDatabaseIfModelChanges<DossierAPIsContext>()); // modifie le modèle à chaque modif du schema 
            // Database.SetInitializer<DossierAPIsContext>(null);// modifie le modèle à chaque modif du schema 


            //---------------------------------------------------------
            //----------configuration spécifique
            //---------------------------------------------------------


            // initialisation application
            ApplicationModel data = new ApplicationModel();


            //model binders
            ModelBinders.Binders.Add(typeof(SessionModel), new SessionModelBinder());
            ModelBinders.Binders.Add(typeof(ApplicationModel), new ApplicationModelBinder());

            //données de portée [Applicartion]
            Application["data"] = new ApplicationModel();


            //jeton Antiforgery
            //AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimsIdentity.DefaultNameClaimType; // solution pour problème de jeton anti-falsification

        }

        public void Session_Start()
        {
            //données de portée [Session]
            Session["data"] = new SessionModel();
        }
    }
}

