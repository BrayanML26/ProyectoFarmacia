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
    public class CD_TiposProveedores
    {
        public List<TiposDeProveedores> Listar()
        {
            List<TiposDeProveedores> lista = new List<TiposDeProveedores>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT Id_Tipo_Proveedor, Descripcion, Estado_Tipo_Proveedor FROM Tipos_De_Proveedores";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new TiposDeProveedores()
                                {
                                    Id_Tipo_Proveedor = Convert.ToInt32(dr["Id_Tipo_Proveedor"]),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Estado_Tipo_Proveedor = Convert.ToBoolean(dr["Estado_Tipo_Proveedor"])
                                }
                                );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<TiposDeProveedores>();
            }

            return lista;
        }
        public int Registrar(TiposDeProveedores oTiposDeProveedores, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_InsertTipoProveedor", oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oTiposDeProveedores.Descripcion);
                    cmd.Parameters.AddWithValue("Estado_Tipo_Proveedor", oTiposDeProveedores.Estado_Tipo_Proveedor);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

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

        public bool Modificar(TiposDeProveedores oTiposDeProveedores, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_UpdateTipoProveedor", oConexion);
                    cmd.Parameters.AddWithValue("Id_Tipo_Proveedor", oTiposDeProveedores.Id_Tipo_Proveedor);
                    cmd.Parameters.AddWithValue("Descripcion", oTiposDeProveedores.Descripcion);
                    cmd.Parameters.AddWithValue("Estado_Tipo_Proveedor", oTiposDeProveedores.Estado_Tipo_Proveedor);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

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

        public bool Eliminar(int Id_Tipo_Proveedor, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_DeleteTipoProveedor", oConexion);
                    cmd.Parameters.AddWithValue("Id_Tipo_Proveedor", Id_Tipo_Proveedor);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

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
