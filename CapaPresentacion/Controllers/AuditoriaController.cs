using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    [Authorize]
    public class AuditoriaController : Controller
    {
        // GET: Auditoria
        public ActionResult Transferencias()
        {
            return View();
        }
    }
}