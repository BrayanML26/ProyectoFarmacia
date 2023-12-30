using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetalleVentas
    {
        public Compania oId_Compania { get; set; }
        public int Secuencia_Documento { get; set; }
        public DateTime Fecha { get; set; }
        public Productos oId_Producto { get; set; }
        public Presentaciones oId_Presentacion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
        public decimal Itbis { get; set; }

    }
}
