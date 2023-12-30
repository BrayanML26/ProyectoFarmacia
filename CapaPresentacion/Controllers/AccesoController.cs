using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;

using System.Web.Security;

namespace CapaPresentacion.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acesso
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string usuario, string contrasena)
        {
            Usuarios oUsuario = new Usuarios();

            oUsuario = new CN_Usuarios().Listar().Where(u => u.Usuario == usuario && u.Contrasena == contrasena).FirstOrDefault();

            if(oUsuario == null)
            {
                ViewBag.Error = "User y/o Password no correcto";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(oUsuario.Usuario, false);

                ViewBag.Error = null;

                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Acceso");
        }
    }
}