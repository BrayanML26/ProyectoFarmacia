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
    public class CompaniaController : Controller
    {
        // GET: Compania
        public ActionResult Sucursales()
        {
            return View();
        }
        public ActionResult ComprobantesFiscales()
        {
            return View();
        }

        #region SUCURSALES
        [HttpGet]
        public JsonResult ListarSucursales()
        {
            List<Compania> oLista = new List<Compania>();

            oLista = new CN_Sucursales().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarSucursales(Compania obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.Id_Compania == 0)
            {
                resultado = new CN_Sucursales().Registrar(obj, out mensaje);
            }
            else
            {
                resultado = new CN_Sucursales().Modificar(obj, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarSucursal(int Id_Compania)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Sucursales().Eliminar(Id_Compania, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region TIPOS NCF
        [HttpGet]
        public JsonResult ListarTiposNcf()
        {
            List<TiposNcf> oLista = new List<TiposNcf>();

            oLista = new CN_TiposNcf().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarTiposNcf(TiposNcf obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.Tipo_Ncf == "")
            {
                resultado = new CN_TiposNcf().Registrar(obj, out mensaje);
            }
            else
            {
                resultado = new CN_TiposNcf().Modificar(obj, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarTiposNcf(string Tipo_Ncf)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_TiposNcf().Eliminar(Tipo_Ncf, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}