using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_MarcasProductos
    {
        private CD_MarcasProductos objCapaDato = new CD_MarcasProductos();

        public List<MarcasProductos> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(MarcasProductos obj, out string Mensaje)
        {
            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.Descripcion_Marca) || string.IsNullOrWhiteSpace(obj.Descripcion_Marca))
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

        public bool Modificar(MarcasProductos obj, out string Mensaje)
        {

            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.Descripcion_Marca) || string.IsNullOrWhiteSpace(obj.Descripcion_Marca))
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

        public bool Eliminar(int Id_Marca_Producto, out string Mensaje)
        {
            return objCapaDato.Eliminar(Id_Marca_Producto, out Mensaje);
        }
    }
}
