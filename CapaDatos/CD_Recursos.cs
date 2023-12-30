using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Recursos
    {
        public List<Provincia> ListarProvincia()
        {
            List<Provincia> lista = new List<Provincia>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT Id_Provincia, Descripcion, Estado_Provincia FROM Provincias";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Provincia()
                                {
                                    Id_Provincia = Convert.ToInt32(dr["Id_Provincia"]),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Estado_Provincia = Convert.ToBoolean(dr["Estado_Provincia"])
                                }
                                );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Provincia>();
            }
            return lista;
        }

        public List<Municipio> ListarMunicipio()
        {
            List<Municipio> lista = new List<Municipio>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT Id_Municipio, Descripcion, Estado_Municipio FROM Municipios";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Municipio()
                                {
                                    Id_Municipio = Convert.ToInt32(dr["Id_Municipio"]),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Estado_Municipio = Convert.ToBoolean(dr["Estado_Municipio"])
                                }
                                );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Municipio>();
            }
            return lista;
        }

        public List<Sectores> ListarSector()
        {
            List<Sectores> lista = new List<Sectores>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT Id_Sector, Descripcion, Estado_Sector FROM Sectores";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Sectores()
                                {
                                    Id_Sector = Convert.ToInt32(dr["Id_Sector"]),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Estado_Sector = Convert.ToBoolean(dr["Estado_Sector"])
                                }
                                );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Sectores>();
            }
            return lista;
        }

        public List<TiposDeDocumentosDeIdentidad> ListarTiposDocumentos()
        {
            List<TiposDeDocumentosDeIdentidad> lista = new List<TiposDeDocumentosDeIdentidad>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT Id_Documento, Descripcion, Estado_Documento FROM Tipos_De_Documentos_De_Indentidad";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new TiposDeDocumentosDeIdentidad()
                                {
                                    Id_Documento = Convert.ToInt32(dr["Id_Documento"]),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Estado_Documento = Convert.ToBoolean(dr["Estado_Documento"])
                                }
                                );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<TiposDeDocumentosDeIdentidad>();
            }
            return lista;
        }

        public List<EstadoDeClientes> ListarEstadoClientes()
        {
            List<EstadoDeClientes> lista = new List<EstadoDeClientes>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT Id_Estado_Cliente, Descripcion, Permite_Facturar, Estado FROM Estado_De_Clientes";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new EstadoDeClientes()
                                {
                                    Id_Estado_Cliente = Convert.ToInt32(dr["Id_Estado_Cliente"]),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Permite_Facturar = Convert.ToBoolean(dr["Permite_Facturar"]),
                                    Estado = Convert.ToBoolean(dr["Estado"])
                                }
                                );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<EstadoDeClientes>();
            }
            return lista;
        }

        public List<PerfilesDeUsuarios> ListarPerfilesUsuarios()
        {
            List<PerfilesDeUsuarios> lista = new List<PerfilesDeUsuarios>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT Id_Compania, Id_Perfil, Descripcion, Estado_Perfil FROM Perfiles_De_Usuario";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new PerfilesDeUsuarios()
                                {
                                    oId_Compania = new Compania() { Id_Compania = Convert.ToInt32(dr["Id_Compania"]) },
                                    Id_Perfil = Convert.ToInt32(dr["Id_Perfil"]),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Estado_Perfil = Convert.ToBoolean(dr["Estado_Perfil"])
                                }
                                );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<PerfilesDeUsuarios>();
            }
            return lista;
        }

        public List<Grupos> ListarGrupo()
        {
            List<Grupos> lista = new List<Grupos>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT Id_Grupo, Descripcion, Estado_Grupo FROM Grupos";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Grupos()
                                {
                                    Id_Grupo = Convert.ToInt32(dr["Id_Grupo"]),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Estado_Grupo = Convert.ToBoolean(dr["Estado_Grupo"])
                                }
                                );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Grupos>();
            }
            return lista;
        }
        public List<Subgrupos> ListarSubgrupo()
        {
            List<Subgrupos> lista = new List<Subgrupos>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT Id_Subgrupo, Descripcion, Estado_Subgrupo FROM Subgrupos";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Subgrupos()
                                {
                                    Id_Subgrupo = Convert.ToInt32(dr["Id_Subgrupo"]),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Estado_Subgrupo = Convert.ToBoolean(dr["Estado_Subgrupo"])
                                }
                                );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Subgrupos>();
            }
            return lista;
        }

        public List<TiposDeProductos> ListarTipoProducto()
        {
            List<TiposDeProductos> lista = new List<TiposDeProductos>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT Id_Compania, Id_Tipo_Producto, Descripcion, Afecta_Inventario, Estado_Producto FROM Tipos_De_Productos";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new TiposDeProductos()
                                {
                                    oId_Compania = new Compania() { Id_Compania = Convert.ToInt32(dr["Id_Compania"]) },
                                    Id_Tipo_Producto = Convert.ToInt32(dr["Id_Tipo_Producto"]),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Afecta_Inventario = Convert.ToBoolean(dr["Afecta_Inventario"]),
                                    Estado_Producto = Convert.ToBoolean(dr["Estado_Producto"])
                                }
                                );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<TiposDeProductos>();
            }
            return lista;
        }

        public List<TiposDeImpuestos> ListarTipoImpuesto()
        {
            List<TiposDeImpuestos> lista = new List<TiposDeImpuestos>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT Id_Impuesto, Descripcion, Porciento_Impuesto, Estado_Tarjeta FROM Tipos_De_Impuestos";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new TiposDeImpuestos()
                                {
                                    Id_Impuesto = Convert.ToInt32(dr["Id_Impuesto"]),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Porciento_Impuesto = Convert.ToDouble(dr["Porciento_Impuesto"]),
                                    Estado_Tarjeta = Convert.ToBoolean(dr["Estado_Tarjeta"])
                                }
                                );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<TiposDeImpuestos>();
            }
            return lista;
        }
    }
}
