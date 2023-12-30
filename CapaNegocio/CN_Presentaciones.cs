using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Presentaciones
    {
        private CD_Presentaciones objCapaDato = new CD_Presentaciones();

        public List<Presentaciones> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Presentaciones obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre_Completo) || string.IsNullOrWhiteSpace(obj.Nombre_Completo))
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

        public bool Modificar(Presentaciones obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre_Completo) || string.IsNullOrWhiteSpace(obj.Nombre_Completo))
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

        public bool Eliminar(int Id_Presentacion, out string Mensaje)
        {
            return objCapaDato.Eliminar(Id_Presentacion, out Mensaje);
        }
    }
}
