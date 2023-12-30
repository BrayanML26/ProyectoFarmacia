using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_TiposProveedores
    {
        private CD_TiposProveedores objCapaDato = new CD_TiposProveedores();

        public List<TiposDeProveedores> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(TiposDeProveedores oTiposDeProveedores, out string Mensaje)
        {
            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(oTiposDeProveedores.Descripcion) || string.IsNullOrWhiteSpace(oTiposDeProveedores.Descripcion))
            {
                Mensaje = "La descripcion no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(oTiposDeProveedores, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool Modificar(TiposDeProveedores oTiposDeProveedores, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(oTiposDeProveedores.Descripcion) || string.IsNullOrWhiteSpace(oTiposDeProveedores.Descripcion))
            {
                Mensaje = "La descripcion no puede ser vacio";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Modificar(oTiposDeProveedores, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int Id_Tipo_Proveedor, out string Mensaje)
        {
            return objCapaDato.Eliminar(Id_Tipo_Proveedor, out Mensaje);
        }
    }
}
