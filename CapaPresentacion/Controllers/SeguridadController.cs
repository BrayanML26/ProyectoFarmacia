using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion.Controllers
{
    [Authorize]
    public class SeguridadController : Controller
    {
        // GET: Seguridad
        //public ActionResult Roles()
        //{
        //    return View();
        //}
        public ActionResult Usuarios()
        {
            return View();
        }

        #region USUARIOS
        [HttpGet]
        public JsonResult ListarUsuario()
        {
            List<Usuarios> oLista = new List<Usuarios>();

            oLista = new CN_Usuarios().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarUsuario(Usuarios obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.Id_Usuario == 0)
            {
                resultado = new CN_Usuarios().Registrar(obj, out mensaje);
            }
            else
            {
                resultado = new CN_Usuarios().Modificar(obj, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarUsuario(int Id_Usuario)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Usuarios().Eliminar(Id_Usuario, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region PERFILES_DE_USUARIOS
        [HttpGet]
        public JsonResult ListarPerfilesUsuarios()
        {
            List<PerfilesDeUsuarios> oLista = new List<PerfilesDeUsuarios>();

            oLista = new CN_Recursos().ListarPerfilesUsuarios();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}