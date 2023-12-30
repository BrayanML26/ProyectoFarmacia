using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class MarcasProductos
    {
        public Compania oId_Compania { get; set; }
        public int Id_Marca_Producto { get; set; }
        public string Descripcion_Marca { get; set; }
        public bool Estado_Marca { get; set; }
    }
}
