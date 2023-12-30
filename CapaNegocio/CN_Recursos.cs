using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Recursos
    {
        private CD_Recursos objCapaDato = new CD_Recursos();

        public List<Provincia> ListarProvincia()
        {
            return objCapaDato.ListarProvincia();
        }

        public List<Municipio> ListarMunicipio()
        {
            return objCapaDato.ListarMunicipio();
        }

        public List<Sectores> ListarSector()
        {
            return objCapaDato.ListarSector();
        }

        public List<TiposDeDocumentosDeIdentidad> ListarTiposDocumentos()
        {
            return objCapaDato.ListarTiposDocumentos();
        }

        public List<EstadoDeClientes> ListarEstadoClientes()
        {
            return objCapaDato.ListarEstadoClientes();
        }

        public List<PerfilesDeUsuarios> ListarPerfilesUsuarios()
        {
            return objCapaDato.ListarPerfilesUsuarios();
        }

        public List<Grupos> ListarGrupo()
        {
            return objCapaDato.ListarGrupo();
        }
        public List<Subgrupos> ListarSubgrupo()
        {
            return objCapaDato.ListarSubgrupo();
        }
        public List<TiposDeProductos> ListarTipoProducto()
        {
            return objCapaDato.ListarTipoProducto();
        }
        public List<TiposDeImpuestos> ListarTipoImpuesto()
        {
            return objCapaDato.ListarTipoImpuesto();
        }
    }
}
