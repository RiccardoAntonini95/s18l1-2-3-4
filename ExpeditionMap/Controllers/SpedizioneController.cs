using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpeditionMap.Controllers
{
    public class SpedizioneController : Controller
    {
        [Authorize]
        public ActionResult AggiungiSpedizione()
        {
            return View();
        }
    }
}