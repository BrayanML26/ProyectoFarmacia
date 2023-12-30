using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult VistaEscritorio()
        {
            Escritorio objeto = new CN_Reporte().VerEscritorio();

            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);
        }
    }
}