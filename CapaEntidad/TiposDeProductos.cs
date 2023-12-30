using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class TiposDeProductos
    {
        public Compania oId_Compania { get; set; }
        public int Id_Tipo_Producto { get; set; }
        public string Descripcion { get; set; }
        public bool Afecta_Inventario{ get; set; }
        public bool Estado_Producto { get; set; }
    }
}
