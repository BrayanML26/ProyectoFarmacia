using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Almacenes
    {
        public Compania oId_Compania { get; set; }
        public int Id_Almacen { get; set; }
        public string Nombre_Almacen { get; set; }
        public bool Estado_Almacen { get; set; }
    }
}
