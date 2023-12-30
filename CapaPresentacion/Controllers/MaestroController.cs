using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public class MaestroController : Controller
    {
        // GET: Maestro
        public ActionResult Departamentos()
        {
            return View();
        }
        public ActionResult UnidadCompraVenta()
        {
            return View();
        }
        public ActionResult UnidadContenido()
        {
            return View();
        }

        #region DEPARTAMENTO
        [HttpGet]
        public JsonResult ListarDepartamento()
        {
            List<Departamentos> oLista = new List<Departamentos>();

            oLista = new CN_Departamentos().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarDepartamento(Departamentos obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.Id_Departamento == 0)
            {
                resultado = new CN_Departamentos().Registrar(obj, out mensaje);
            }
            else
            {
                resultado = new CN_Departamentos().Modificar(obj, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarDepartamento(int Id_Departamento)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Departamentos().Eliminar(Id_Departamento, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region UNIDADCOMPRAVENTA
        [HttpGet]
        public JsonResult ListarUnidadCV()
        {
            List<Unidades> oLista = new List<Unidades>();

            oLista = new CN_UnidadCompraVenta().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarUnidadCV(Unidades obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.Id_Unidad == 0)
            {
                resultado = new CN_UnidadCompraVenta().Registrar(obj, out mensaje);
            }
            else
            {
                resultado = new CN_UnidadCompraVenta().Modificar(obj, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarUnidadCV(int Id_Unidad)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_UnidadCompraVenta().Eliminar(Id_Unidad, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}