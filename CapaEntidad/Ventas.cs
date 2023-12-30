using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Ventas
    {
        public Compania oId_Compania { get; set; }
        public int Secuencia_Documento { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto_Total { get; set; }
        public decimal Total_Itbis { get; set; }
        public decimal Total_Descuento { get; set; }
        public TiposNcf oTipo_Ncf { get; set; }
        public string Ncf { get; set; }
        public Usuarios oId_Usuario { get; set; }

        public List<DetalleVentas> Detalles { get; set; }

    }
}
