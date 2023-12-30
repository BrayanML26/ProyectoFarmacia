using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    [Authorize]
    public class MovimientoController : Controller
    {
        // GET: Movimiento
        public ActionResult Pedidos()
        {
            return View();
        }
        public ActionResult Ventas()
        {
            return View();
        }
        public ActionResult Compras()
        {
            return View();
        }
        //public ActionResult Caja()
        //{
        //    return View();
        //}


    }
}