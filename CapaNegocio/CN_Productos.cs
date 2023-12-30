using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Productos objCapaDato = new CD_Productos();

        public List<Productos> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Productos obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre_Producto) || string.IsNullOrWhiteSpace(obj.Nombre_Producto))
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

        public bool Modificar(Productos obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre_Producto) || string.IsNullOrWhiteSpace(obj.Nombre_Producto))
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

        public bool Eliminar(int Id_Producto, out string Mensaje)
        {
            return objCapaDato.Eliminar(Id_Producto, out Mensaje);
        }
    }
}
