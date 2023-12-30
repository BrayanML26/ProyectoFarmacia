using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Clientes
    {
        public Compania oId_Compania { get; set; }
        public int Id_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Provincia oId_Provincia { get; set; }
        public Municipio oId_Municipio { get; set; }
        public Sectores oId_Sector { get; set; }
        public string Direccion { get; set; }
        public string Numero_Telefonico { get; set; }
        public TiposDeDocumentosDeIdentidad oId_Documento { get; set; }
        public string Documento_De_Identidad { get; set; }
        public TiposDeClientes oId_Tipo_Cliente { get; set; }
        public EstadoDeClientes oId_Estado_Cliente { get; set; }
    }
}
