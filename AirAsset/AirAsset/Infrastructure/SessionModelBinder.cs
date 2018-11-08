using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; // pour pouvoir implémeter IModelBinder

namespace AirAsset.Infrastructure
{
    public class SessionModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // rendre les données de portée [Session]
            return controllerContext.HttpContext.Session["data"];
        }
    }
}