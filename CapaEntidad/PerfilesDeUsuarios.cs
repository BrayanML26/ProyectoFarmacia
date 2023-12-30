using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PerfilesDeUsuarios
    {
        public Compania oId_Compania { get; set; }
        public int Id_Perfil { get; set; }
        public string Descripcion { get; set; }
        public bool Estado_Perfil { get; set; }
    }
}
