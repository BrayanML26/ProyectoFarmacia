using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Presentaciones
    {
        public Compania oId_Compania { get; set; }
        public Productos oId_Producto { get; set; }
        public int Id_Presentacion { get; set; }
        public string Nombre_Completo { get; set; }
        public string Nombre_Corto { get; set; }
        public int Nivel_Inventario_Maximo { get; set; }
        public int Nivel_Inventario_Minimo { get; set; }
        public double Precio { get; set; }
        public double Costo_De_Lista { get; set; }
        public double Costo_Promerio { get; set; }
        public double Porcentaje_Beneficio { get; set; }
        public double Descuento_Maximo_Permitido { get; set; }
        public TiposDeImpuestos oId_Impuesto { get; set; }
        public bool Estado_Presentacion { get; set; }
    }
}
