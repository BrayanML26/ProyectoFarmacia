using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_TiposClientes
    {
        private CD_TiposClientes objCapaDato = new CD_TiposClientes();

        public List<TiposDeClientes> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(TiposDeClientes oTiposDeClientes, out string Mensaje)
        {
            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(oTiposDeClientes.Descripcion) || string.IsNullOrWhiteSpace(oTiposDeClientes.Descripcion))
            {
                Mensaje = "La descripcion no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(oTiposDeClientes, out Mensaje);
            }
            else
            {

                return 0;
            }
        }

        public bool Modificar(TiposDeClientes oTiposDeClientes, out string Mensaje)
        {

            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(oTiposDeClientes.Descripcion) || string.IsNullOrWhiteSpace(oTiposDeClientes.Descripcion))
            {
                Mensaje = "La descripcion no puede ser vacio";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.Modificar(oTiposDeClientes, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int Id_Tipo_Cliente, out string Mensaje)
        {
            return objCapaDato.Eliminar(Id_Tipo_Cliente, out Mensaje);
        }
    }
}
