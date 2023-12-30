using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuarios
    {
        public Compania oId_Compania { get; set; }
        public int Id_Usuario { get; set; }
        public PerfilesDeUsuarios oId_Perfil { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public TiposDeDocumentosDeIdentidad oId_Documento { get; set; }
        public string Documento_De_Identidad { get; set; }
        public Provincia oId_Provincia { get; set; }
        public Municipio oId_Municipio { get; set; }
        public Sectores oId_Sector { get; set; }
        public string Direccion { get; set; }
        public string Numero_Telefonico { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public bool Estado_Usuario { get; set; }
    }
}
