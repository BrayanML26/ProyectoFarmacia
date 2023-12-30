using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Sucursales
    {
        private CD_Sucursales objCapaDato = new CD_Sucursales();

        public List<Compania> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Compania obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Razon_Social) || string.IsNullOrWhiteSpace(obj.Razon_Social))
            {
                Mensaje = "Debe llenar el campo de Razon Social";
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

        public bool Modificar(Compania obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Razon_Social) || string.IsNullOrWhiteSpace(obj.Razon_Social))
            {
                Mensaje = "Debe llenar el campo de Razon Social";
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

        public bool Eliminar(int Id_Compania, out string Mensaje)
        {
            return objCapaDato.Eliminar(Id_Compania, out Mensaje);
        }
    }
}
