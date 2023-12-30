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
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Productos()
        {
            return View();
        }
        public ActionResult Marcas()
        {
            return View();
        }
        public ActionResult Presentaciones()
        {
            return View();
        }
        public ActionResult Sustancias()
        {
            return View();
        }
        public ActionResult Existencias()
        {
            return View();
        }
        public ActionResult CambiosDePrecios()
        {
            return View();
        }
        public ActionResult CambiosMasivos()
        {
            return View();
        }

        #region PRODUCTOS
        [HttpGet]
        public JsonResult ListarProducto()
        {
            List<Productos> oLista = new List<Productos>();

            oLista = new CN_Productos().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarProducto(Productos obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.Id_Producto == 0)
            {
                resultado = new CN_Productos().Registrar(obj, out mensaje);
            }
            else
            {
                resultado = new CN_Productos().Modificar(obj, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarProducto(int Id_Producto)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Productos().Eliminar(Id_Producto, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region MARCAS
        [HttpGet]
        public JsonResult ListarMarca()
        {
            List<MarcasProductos> oLista = new List<MarcasProductos>();

            oLista = new CN_MarcasProductos().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarMarca(MarcasProductos obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.Id_Marca_Producto == 0)
            {
                resultado = new CN_MarcasProductos().Registrar(obj, out mensaje);
            }
            else
            {
                resultado = new CN_MarcasProductos().Modificar(obj, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarMarca(int Id_Marca_Producto)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_MarcasProductos().Eliminar(Id_Marca_Producto, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region PRESENTACIONES
        [HttpGet]
        public JsonResult ListarPresentacion()
        {
            List<Presentaciones> oLista = new List<Presentaciones>();

            oLista = new CN_Presentaciones().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarPresentacion(Presentaciones obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.Id_Presentacion == 0)
            {
                resultado = new CN_Presentaciones().Registrar(obj, out mensaje);
            }
            else
            {
                resultado = new CN_Presentaciones().Modificar(obj, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarPresentacion(int Id_Presentacion)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Presentaciones().Eliminar(Id_Presentacion, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region SUSTANCIAS
        [HttpGet]
        public JsonResult ListarSustancia()
        {
            List<Sustancias> oLista = new List<Sustancias>();

            oLista = new CN_Sustancias().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarSustancia(Sustancias obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.Id_Sustancia == 0)
            {
                resultado = new CN_Sustancias().Registrar(obj, out mensaje);
            }
            else
            {
                resultado = new CN_Sustancias().Modificar(obj, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarSustancia(int Id_Sustancia)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Sustancias().Eliminar(Id_Sustancia, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region GRUPOS
        [HttpGet]
        public JsonResult ListarGrupo()
        {
            List<Grupos> oLista = new List<Grupos>();

            oLista = new CN_Recursos().ListarGrupo();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region SUBGRUPOS
        [HttpGet]
        public JsonResult ListarSubgrupo()
        {
            List<Subgrupos> oLista = new List<Subgrupos>();

            oLista = new CN_Recursos().ListarSubgrupo();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region TIPO PRODUCTO
        [HttpGet]
        public JsonResult ListarTipoProducto()
        {
            List<TiposDeProductos> oLista = new List<TiposDeProductos>();

            oLista = new CN_Recursos().ListarTipoProducto();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region TIPO IMPUESTO
        [HttpGet]
        public JsonResult ListarTipoImpuesto()
        {
            List<TiposDeImpuestos> oLista = new List<TiposDeImpuestos>();

            oLista = new CN_Recursos().ListarTipoImpuesto();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}