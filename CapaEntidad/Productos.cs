using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Productos
    {
        public Compania oId_Compania { get; set; }
        public int Id_Producto { get; set; }
        public string Nombre_Producto { get; set; }
        public Departamentos oId_Departamento { get; set; }
        public Grupos oId_Grupo { get; set; }
        public Subgrupos oId_Subgrupo { get; set; }
        public MarcasProductos oId_Marca_Producto { get; set; }
        public TiposDeProductos oId_Tipo_Producto { get; set; }
        public bool Venta_Negativo { get; set; }
        public bool Producto_Controlado { get; set; }
        public bool Producto_Generico { get; set; }
        public bool Estado_Producto { get; set; }
    }
}
