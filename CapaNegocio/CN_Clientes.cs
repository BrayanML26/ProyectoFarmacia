using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Clientes
    {
        private CD_Clientes objCapaDato = new CD_Clientes();

        public List<Clientes> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Clientes obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre no puede ser vacio";
            }
            if (string.IsNullOrEmpty(obj.Apellido) || string.IsNullOrWhiteSpace(obj.Apellido))
            {
                Mensaje = "El apellido no puede ser vacio";
            }
            if (string.IsNullOrEmpty(obj.Documento_De_Identidad) || string.IsNullOrWhiteSpace(obj.Documento_De_Identidad))
            {
                Mensaje = "El documento de identidad no puede ser vacio";
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

        public bool Modificar(Clientes obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre no puede ser vacio";
            }
            if (string.IsNullOrEmpty(obj.Apellido) || string.IsNullOrWhiteSpace(obj.Apellido))
            {
                Mensaje = "El apellido no puede ser vacio";
            }
            if (string.IsNullOrEmpty(obj.Documento_De_Identidad) || string.IsNullOrWhiteSpace(obj.Documento_De_Identidad))
            {
                Mensaje = "El documento de identidad no puede ser vacio";
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

        public bool Eliminar(int Id_Cliente, out string Mensaje)
        {
            return objCapaDato.Eliminar(Id_Cliente, out Mensaje);
        }
    }
}
