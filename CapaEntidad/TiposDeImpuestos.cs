using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class TiposDeImpuestos
    {
        //    Id_Impuesto Int Identity(1,1) Primary Key Not Null,
        //Descripcion Nvarchar(50) Not Null,
        //Porciento_Impuesto Numeric(14,2) Not Null,
        //Estado_Tarjeta Bit Not Null)

        public int Id_Impuesto { get; set; }
        public string Descripcion { get; set; }
        public double Porciento_Impuesto { get; set; }
        public bool Estado_Tarjeta { get; set; }
    }
}
