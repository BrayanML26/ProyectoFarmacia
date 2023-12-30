using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Proveedores
    {
        public Compania oId_Compania { get; set; }
        public int Id_Proveedor { get; set; }
        public string Nombre_Proveedor { get; set; }
        public Provincia oId_Provincia { get; set; }
        public Municipio oId_Municipio { get; set; }
        public Sectores oId_Sector { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Estado_Proveedor { get; set; }
        public TiposDeProveedores oId_Tipo_Proveedor { get; set; }
    }
}
