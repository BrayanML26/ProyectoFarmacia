using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Clientes
    {
        public List<Clientes> Listar()
        {
            List<Clientes> lista = new List<Clientes>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SELECT co.Id_Compania, c.Id_Cliente, c.Nombre, c.Apellido, p.Id_Provincia, m.Id_Municipio, s.Id_Sector,");
                    sb.AppendLine("c.Direccion, c.Numero_Telefonico, tdi.Id_Documento, c.Documento_De_Identidad, tc.Id_Tipo_Cliente, ec.Id_Estado_Cliente");
                    sb.AppendLine("from Clientes c");
                    sb.AppendLine("inner join Compania co on co.Id_Compania = c.Id_Compania");
                    sb.AppendLine("inner join Provincias p on p.Id_Provincia = c.Id_Provincia");
                    sb.AppendLine("inner join Municipios m on m.Id_Municipio = c.Id_Municipio");
                    sb.AppendLine("inner join Sectores s on s.Id_Sector = c.Id_Sector");
                    sb.AppendLine("inner join Tipos_De_Documentos_De_Indentidad tdi on tdi.Id_Documento = c.Id_Documento");
                    sb.AppendLine("inner join Tipos_De_Clientes tc on tc.Id_Tipo_Cliente = c.Id_Tipo_Cliente");
                    sb.AppendLine("inner join Estado_De_Clientes ec on ec.Id_Estado_Cliente = c.Id_Estado_Cliente");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Clientes()
                            {
                                oId_Compania = new Compania() { Id_Compania = Convert.ToInt32(dr["Id_Compania"]) },
                                Id_Cliente = Convert.ToInt32(dr["Id_Cliente"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                oId_Provincia = new Provincia() { Id_Provincia = Convert.ToInt32(dr["Id_Provincia"]) },
                                oId_Municipio = new Municipio() { Id_Municipio = Convert.ToInt32(dr["Id_Municipio"]) },
                                oId_Sector = new Sectores() { Id_Sector = Convert.ToInt32(dr["Id_Sector"]) },
                                Direccion = dr["Direccion"].ToString(),
                                Numero_Telefonico = dr["Numero_Telefonico"].ToString(),
                                oId_Documento = new TiposDeDocumentosDeIdentidad() { Id_Documento = Convert.ToInt32(dr["Id_Documento"]) },
                                Documento_De_Identidad = dr["Documento_De_Identidad"].ToString(),
                                oId_Tipo_Cliente = new TiposDeClientes() { Id_Tipo_Cliente = Convert.ToInt32(dr["Id_Tipo_Cliente"]) },
                                oId_Estado_Cliente = new EstadoDeClientes() { Id_Estado_Cliente = Convert.ToInt32(dr["Id_Estado_Cliente"]) }
                            });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Clientes>();
            }
            return lista;
        }

        public int Registrar(Clientes obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_InsertCliente", oconexion);
                    cmd.Parameters.AddWithValue("Id_Compania", obj.oId_Compania.Id_Compania);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.Apellido);
                    cmd.Parameters.AddWithValue("Id_Provincia", obj.oId_Provincia.Id_Provincia);
                    cmd.Parameters.AddWithValue("Id_Municipio", obj.oId_Municipio.Id_Municipio);
                    cmd.Parameters.AddWithValue("Id_Sector", obj.oId_Sector.Id_Sector);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Numero_Telefonico", obj.Numero_Telefonico);
                    cmd.Parameters.AddWithValue("Id_Documento", obj.oId_Documento.Id_Documento);
                    cmd.Parameters.AddWithValue("Documento_De_Identidad", obj.Documento_De_Identidad);
                    cmd.Parameters.AddWithValue("Id_Tipo_Cliente", obj.oId_Tipo_Cliente.Id_Tipo_Cliente);
                    cmd.Parameters.AddWithValue("Id_Estado_Cliente", obj.oId_Estado_Cliente.Id_Estado_Cliente);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idautogenerado = 0;
                Mensaje = ex.Message;
            }
            return idautogenerado;
        }

        public bool Modificar(Clientes obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_UpdateCliente", oconexion);
                    cmd.Parameters.AddWithValue("Id_Cliente", obj.Id_Cliente);
                    cmd.Parameters.AddWithValue("Id_Compania", obj.oId_Compania.Id_Compania);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.Apellido);
                    cmd.Parameters.AddWithValue("Id_Provincia", obj.oId_Provincia.Id_Provincia);
                    cmd.Parameters.AddWithValue("Id_Municipio", obj.oId_Municipio.Id_Municipio);
                    cmd.Parameters.AddWithValue("Id_Sector", obj.oId_Sector.Id_Sector);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Numero_Telefonico", obj.Numero_Telefonico);
                    cmd.Parameters.AddWithValue("Id_Documento", obj.oId_Documento.Id_Documento);
                    cmd.Parameters.AddWithValue("Documento_De_Identidad", obj.Documento_De_Identidad);
                    cmd.Parameters.AddWithValue("Id_Tipo_Cliente", obj.oId_Tipo_Cliente.Id_Tipo_Cliente);
                    cmd.Parameters.AddWithValue("Id_Estado_Cliente", obj.oId_Estado_Cliente.Id_Estado_Cliente);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

        public bool Eliminar(int Id_Cliente, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_DeleteCliente", oconexion);
                    cmd.Parameters.AddWithValue("Id_Cliente", Id_Cliente);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }
    }
}
