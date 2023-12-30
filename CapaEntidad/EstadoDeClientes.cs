using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EstadoDeClientes
    {
        public int Id_Estado_Cliente { get; set; }
        public string Descripcion { get; set; }
        public bool Permite_Facturar { get; set; }
        public bool Estado { get; set; }
    }
}
