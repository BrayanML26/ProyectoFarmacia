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
    public class CD_Proveedores
    {
        public List<Proveedores> Listar()
        {
            List<Proveedores> lista = new List<Proveedores>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SELECT co.Id_Compania, p.Id_Proveedor, p.Nombre_Proveedor, prov.Id_Provincia, m.Id_Municipio,");
                    sb.AppendLine("s.Id_Sector, p.Direccion, p.Telefono, p.Email, p.Estado_Proveedor, tp.Id_Tipo_Proveedor");
                    sb.AppendLine("FROM Proveedores p");
                    sb.AppendLine("INNER JOIN Compania co on co.Id_Compania = p.Id_Compania");
                    sb.AppendLine("INNER JOIN Provincias prov on prov.Id_Provincia = p.Id_Provincia");
                    sb.AppendLine("INNER JOIN Municipios m on m.Id_Municipio = p.Id_Municipio");
                    sb.AppendLine("INNER JOIN Sectores s on s.Id_Sector = p.Id_Sector");
                    sb.AppendLine("INNER JOIN Tipos_De_Proveedores tp on tp.Id_Tipo_Proveedor = p.Id_Tipo_Proveedor");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Proveedores()
                            {
                                oId_Compania = new Compania() { Id_Compania = Convert.ToInt32(dr["Id_Compania"]) },
                                Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"]),
                                Nombre_Proveedor = dr["Nombre_Proveedor"].ToString(),
                                oId_Provincia = new Provincia() { Id_Provincia = Convert.ToInt32(dr["Id_Provincia"]) },
                                oId_Municipio = new Municipio() { Id_Municipio = Convert.ToInt32(dr["Id_Municipio"]) },
                                oId_Sector = new Sectores() { Id_Sector = Convert.ToInt32(dr["Id_Sector"]) },
                                Direccion = dr["Direccion"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Email = dr["Email"].ToString(),
                                Estado_Proveedor = Convert.ToBoolean(dr["Estado_Proveedor"]),
                                oId_Tipo_Proveedor = new TiposDeProveedores() { Id_Tipo_Proveedor = Convert.ToInt32(dr["Id_Tipo_Proveedor"]) }
                            });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Proveedores>();
            }
            return lista;
        }

        public int Registrar(Proveedores obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_InsertProveedor", oconexion);
                    cmd.Parameters.AddWithValue("Id_Compania", obj.oId_Compania.Id_Compania);
                    cmd.Parameters.AddWithValue("Nombre_Proveedor", obj.Nombre_Proveedor);
                    cmd.Parameters.AddWithValue("Id_Provincia", obj.oId_Provincia.Id_Provincia);
                    cmd.Parameters.AddWithValue("Id_Municipio", obj.oId_Municipio.Id_Municipio);
                    cmd.Parameters.AddWithValue("Id_Sector", obj.oId_Sector.Id_Sector);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("Estado_Proveedor", obj.Estado_Proveedor);
                    cmd.Parameters.AddWithValue("Id_Tipo_Proveedor", obj.oId_Tipo_Proveedor.Id_Tipo_Proveedor);
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

        public bool Modificar(Proveedores obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {                   
                    SqlCommand cmd = new SqlCommand("Sp_UpdateProveedor", oconexion);
                    cmd.Parameters.AddWithValue("Id_Proveedor", obj.Id_Proveedor);
                    cmd.Parameters.AddWithValue("Id_Compania", obj.oId_Compania.Id_Compania);
                    cmd.Parameters.AddWithValue("Nombre_Proveedor", obj.Nombre_Proveedor);
                    cmd.Parameters.AddWithValue("Id_Provincia", obj.oId_Provincia.Id_Provincia);
                    cmd.Parameters.AddWithValue("Id_Municipio", obj.oId_Municipio.Id_Municipio);
                    cmd.Parameters.AddWithValue("Id_Sector", obj.oId_Sector.Id_Sector);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("Estado_Proveedor", obj.Estado_Proveedor);
                    cmd.Parameters.AddWithValue("Id_Tipo_Proveedor", obj.oId_Tipo_Proveedor.Id_Tipo_Proveedor);
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

        public bool Eliminar(int Id_Proveedor, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_DeleteProveedor", oconexion);
                    cmd.Parameters.AddWithValue("Id_Proveedor", Id_Proveedor);
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
