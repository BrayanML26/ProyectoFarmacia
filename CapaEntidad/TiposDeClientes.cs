using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class TiposDeClientes
    {
        public int Id_Tipo_Cliente { get; set; }
        public string Descripcion { get; set; }
        public bool Estado_Tipo_Cliente { get; set; }
    }
}
