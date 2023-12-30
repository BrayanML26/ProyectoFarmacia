using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Departamentos
    {
        private CD_Departamentos objCapaDato = new CD_Departamentos();

        public List<Departamentos> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Departamentos obj, out string Mensaje)
        {
            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La descripcion no puede ser vacio";
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

        public bool Modificar(Departamentos obj, out string Mensaje)
        {

            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La descripcion no puede ser vacio";
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

        public bool Eliminar(int Id_Departamento, out string Mensaje)
        {
            return objCapaDato.Eliminar(Id_Departamento, out Mensaje);
        }
    }
}
