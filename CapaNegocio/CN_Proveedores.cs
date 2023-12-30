using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Proveedores
    {
        private CD_Proveedores objCapaDato = new CD_Proveedores();

        public List<Proveedores> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Proveedores obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre_Proveedor) || string.IsNullOrWhiteSpace(obj.Nombre_Proveedor))
            {
                Mensaje = "El nombre no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool Modificar(Proveedores obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre_Proveedor) || string.IsNullOrWhiteSpace(obj.Nombre_Proveedor))
            {
                Mensaje = "El nombre no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Modificar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int Id_Proveedor, out string Mensaje)
        {
            return objCapaDato.Eliminar(Id_Proveedor, out Mensaje);
        }
    }
}
