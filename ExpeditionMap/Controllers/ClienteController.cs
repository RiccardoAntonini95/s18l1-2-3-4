using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpeditionMap.Controllers
{
    public class ClienteController : Controller
    {
        [Authorize]
        public ActionResult AggiungiCliente()
        {
            return View();
        }
    }
}