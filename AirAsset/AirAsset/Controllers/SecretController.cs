using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirAsset.Controllers
{
    public class SecretController : Controller
    {
        // GET: Secret
        [Authorize]
        public string Secret()
        {
            return "I am a secret secret action. Only registtred users showld see me. ";
        }


        public string Public()
        {
            return "I am a public. Everybody can see me. ";
        }
    }
}