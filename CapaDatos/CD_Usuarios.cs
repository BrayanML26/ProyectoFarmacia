using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Usuarios
    {
        public List<Usuarios> Listar()
        {
            List<Usuarios> lista = new List<Usuarios>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SELECT co.Id_Compania, u.Id_Usuario, pu.Id_Perfil, u.Nombre, u.Apellido, u.Sexo, u.Fecha_Nacimiento,");
                    sb.AppendLine("tdi.Id_Documento, u.Documento_De_Identidad, p.Id_Provincia, m.Id_Municipio, s.Id_Sector, u.Direccion,");
                    sb.AppendLine("u.Numero_Telefonico, u.Usuario, u.Contrasena, u.Estado_Usuario");
                    sb.AppendLine("from Usuarios u");
                    sb.AppendLine("inner join Compania co on co.Id_Compania = u.Id_Compania");
                    sb.AppendLine("inner join Perfiles_De_Usuario pu on pu.Id_Perfil = u.Id_Perfil");
                    sb.AppendLine("inner join Tipos_De_Documentos_De_Indentidad tdi on tdi.Id_Documento = u.Id_Documento");
                    sb.AppendLine("inner join Provincias p on p.Id_Provincia = u.Id_Provincia");
                    sb.AppendLine("inner join Municipios m on m.Id_Municipio = u.Id_Municipio");
                    sb.AppendLine("inner join Sectores s on s.Id_Sector = u.Id_Sector");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader() )
                    {
                        while (dr.Read())
                        {
                            lista.Add( new Usuarios()
                            {
                                    oId_Compania = new Compania() { Id_Compania = Convert.ToInt32(dr["Id_Compania"]) },
                                    Id_Usuario = Convert.ToInt32(dr["Id_Usuario"]),
                                    oId_Perfil = new PerfilesDeUsuarios() { Id_Perfil = Convert.ToInt32(dr["Id_Perfil"]) },
                                    Nombre = dr["Nombre"].ToString(),
                                    Apellido = dr["Apellido"].ToString(),
                                    Sexo = dr["Sexo"].ToString(),
                                    Fecha_Nacimiento = Convert.ToDateTime(dr["Fecha_Nacimiento"]),
                                    oId_Documento = new TiposDeDocumentosDeIdentidad() { Id_Documento = Convert.ToInt32(dr["Id_Documento"]) },
                                    Documento_De_Identidad = dr["Documento_De_Identidad"].ToString(),
                                    oId_Provincia = new Provincia() { Id_Provincia = Convert.ToInt32(dr["Id_Provincia"]) },
                                    oId_Municipio = new Municipio() { Id_Municipio = Convert.ToInt32(dr["Id_Municipio"]) },
                                    oId_Sector = new Sectores() { Id_Sector = Convert.ToInt32(dr["Id_Sector"]) },
                                    Direccion = dr["Direccion"].ToString(),
                                    Numero_Telefonico = dr["Numero_Telefonico"].ToString(),
                                    Usuario = dr["Usuario"].ToString(),
                                    Contrasena = dr["Contrasena"].ToString(),
                                    Estado_Usuario = Convert.ToBoolean(dr["Estado_Usuario"])
                            });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Usuarios>();
            }
            return lista;
        }

        public int Registrar(Usuarios obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_InsertUsuario", oconexion);
                    cmd.Parameters.AddWithValue("Id_Compania", obj.oId_Compania.Id_Compania);
                    cmd.Parameters.AddWithValue("Id_Perfil", obj.oId_Perfil.Id_Perfil);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.Apellido);
                    cmd.Parameters.AddWithValue("Sexo", obj.Sexo);
                    cmd.Parameters.AddWithValue("Fecha_Nacimiento", obj.Fecha_Nacimiento);
                    cmd.Parameters.AddWithValue("Id_Documento", obj.oId_Documento.Id_Documento);
                    cmd.Parameters.AddWithValue("Documento_De_Identidad", obj.Documento_De_Identidad);
                    cmd.Parameters.AddWithValue("Id_Provincia", obj.oId_Provincia.Id_Provincia);
                    cmd.Parameters.AddWithValue("Id_Municipio", obj.oId_Municipio.Id_Municipio);
                    cmd.Parameters.AddWithValue("Id_Sector", obj.oId_Sector.Id_Sector);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Numero_Telefonico", obj.Numero_Telefonico);
                    cmd.Parameters.AddWithValue("Usuario", obj.Usuario);
                    cmd.Parameters.AddWithValue("Contrasena", obj.Contrasena);
                    cmd.Parameters.AddWithValue("Estado_Usuario", obj.Estado_Usuario);
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

        public bool Modificar(Usuarios obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_UpdateUsuario", oconexion);
                    cmd.Parameters.AddWithValue("Id_Usuario", obj.Id_Usuario);
                    cmd.Parameters.AddWithValue("Id_Compania", obj.oId_Compania.Id_Compania);
                    cmd.Parameters.AddWithValue("Id_Perfil", obj.oId_Perfil.Id_Perfil);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.Apellido);
                    cmd.Parameters.AddWithValue("Sexo", obj.Sexo);
                    cmd.Parameters.AddWithValue("Fecha_Nacimiento", obj.Fecha_Nacimiento);
                    cmd.Parameters.AddWithValue("Id_Documento", obj.oId_Documento.Id_Documento);
                    cmd.Parameters.AddWithValue("Documento_De_Identidad", obj.Documento_De_Identidad);
                    cmd.Parameters.AddWithValue("Id_Provincia", obj.oId_Provincia.Id_Provincia);
                    cmd.Parameters.AddWithValue("Id_Municipio", obj.oId_Municipio.Id_Municipio);
                    cmd.Parameters.AddWithValue("Id_Sector", obj.oId_Sector.Id_Sector);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Numero_Telefonico", obj.Numero_Telefonico);
                    cmd.Parameters.AddWithValue("Usuario", obj.Usuario);
                    cmd.Parameters.AddWithValue("Contrasena", obj.Contrasena);
                    cmd.Parameters.AddWithValue("Estado_Usuario", obj.Estado_Usuario);
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

        public bool Eliminar(int Id_Usuario, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_DeleteUsuario", oconexion);
                    cmd.Parameters.AddWithValue("Id_Usuario", Id_Usuario);
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
