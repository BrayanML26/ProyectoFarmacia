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
    public class GestionController : Controller
    {
        // GET: Gestion
        public ActionResult Clientes()
        {
            return View();
        }
        public ActionResult TiposDeClientes()
        {
            return View();
        }
        public ActionResult Proveedores()
        {
            return View();
        }
        public ActionResult TiposDeProveedores()
        {
            return View();
        }
        public ActionResult Descuentos()
        {
            return View();
        }
        public ActionResult Ofertas()
        {
            return View();
        }

        #region CLIENTES
        [HttpGet]
        public JsonResult ListarClientes()
        {
            List<Clientes> oLista = new List<Clientes>();

            oLista = new CN_Clientes().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarClientes(Clientes obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.Id_Cliente == 0)
            {
                resultado = new CN_Clientes().Registrar(obj, out mensaje);
            }
            else
            {
                resultado = new CN_Clientes().Modificar(obj, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarClientes(int Id_Cliente)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Clientes().Eliminar(Id_Cliente, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region TIPOS CLIENTES
        [HttpGet]
        public JsonResult ListarTiposClientes()
        {
            List<TiposDeClientes> oLista = new List<TiposDeClientes>();

            oLista = new CN_TiposClientes().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarTiposClientes(TiposDeClientes oTiposDeClientes)
        {
            object resultado;
            string mensaje = string.Empty;

            if (oTiposDeClientes.Id_Tipo_Cliente == 0)
            {
                resultado = new CN_TiposClientes().Registrar(oTiposDeClientes, out mensaje);
            }
            else
            {
                resultado = new CN_TiposClientes().Modificar(oTiposDeClientes, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarTiposClientes(int Id_Tipo_Cliente)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_TiposClientes().Eliminar(Id_Tipo_Cliente, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region PROVEEDORES
        [HttpGet]
        public JsonResult ListarProveedores()
        {
            List<Proveedores> oLista = new List<Proveedores>();

            oLista = new CN_Proveedores().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarProveedores(Proveedores obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.Id_Proveedor == 0)
            {
                resultado = new CN_Proveedores().Registrar(obj, out mensaje);
            }
            else
            {
                resultado = new CN_Proveedores().Modificar(obj, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarProveedores(int Id_Proveedor)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Proveedores().Eliminar(Id_Proveedor, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region TIPOS PROVEEDORES
        [HttpGet]
        public JsonResult ListarTiposProveedores()
        {
            List<TiposDeProveedores> oLista = new List<TiposDeProveedores>();

            oLista = new CN_TiposProveedores().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarTiposProveedores(TiposDeProveedores oTiposDeProveedores)
        {
            object resultado;
            string mensaje = string.Empty;

            if (oTiposDeProveedores.Id_Tipo_Proveedor == 0)
            {
                resultado = new CN_TiposProveedores().Registrar(oTiposDeProveedores, out mensaje);
            }
            else
            {
                resultado = new CN_TiposProveedores().Modificar(oTiposDeProveedores, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarTiposProveedores(int Id_Tipo_Proveedor)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_TiposProveedores().Eliminar(Id_Tipo_Proveedor, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region TIPOS DOCUMENTOS IDENTIDAD | ESTADO CLIENTES
        [HttpGet]
        public JsonResult ListarTiposDocumentos()
        {
            List<TiposDeDocumentosDeIdentidad> oLista = new List<TiposDeDocumentosDeIdentidad>();

            oLista = new CN_Recursos().ListarTiposDocumentos();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarEstadoClientes()
        {
            List<EstadoDeClientes> oLista = new List<EstadoDeClientes>();

            oLista = new CN_Recursos().ListarEstadoClientes();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region PROVINCIAS | MUNICIPIOS | SECTORES
        [HttpGet]
        public JsonResult ListarProvincia()
        {
            List<Provincia> oLista = new List<Provincia>();

            oLista = new CN_Recursos().ListarProvincia();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarMunicipio()
        {
            List<Municipio> oLista = new List<Municipio>();

            oLista = new CN_Recursos().ListarMunicipio();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarSector()
        {
            List<Sectores> oLista = new List<Sectores>();

            oLista = new CN_Recursos().ListarSector();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}