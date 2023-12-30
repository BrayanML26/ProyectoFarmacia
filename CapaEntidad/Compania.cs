using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Compania
    {
        public int Id_Compania { get; set; }
        public string Razon_Social { get; set; }
        public string Nombre_Comercial { get; set; }
        public string Nombre_Sucursal { get; set; }
        public string Rnc { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Estado_Compania { get; set; }
    }
}
