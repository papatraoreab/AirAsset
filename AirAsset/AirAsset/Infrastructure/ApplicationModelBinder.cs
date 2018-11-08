using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; // importer pour pouvoir implémenter IModelBinder (Interface)

namespace AirAsset.Infrastructure
{
    public class ApplicationModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // rendre les données de portée [Application]
            return controllerContext.RequestContext.HttpContext.Application["data"];
        }
    }
}