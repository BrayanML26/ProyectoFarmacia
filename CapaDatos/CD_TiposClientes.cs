using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CapaDatos
{
    public class CD_TiposClientes
    {
        public List<TiposDeClientes> Listar()
        {
            List<TiposDeClientes> lista = new List<TiposDeClientes>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT Id_Tipo_Cliente, Descripcion, Estado_Tipo_Cliente FROM Tipos_De_Clientes";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new TiposDeClientes()
                                {
                                    Id_Tipo_Cliente = Convert.ToInt32(dr["Id_Tipo_Cliente"]),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Estado_Tipo_Cliente = Convert.ToBoolean(dr["Estado_Tipo_Cliente"])
                                }
                                );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<TiposDeClientes>();
            }

            return lista;
        }
        public int Registrar(TiposDeClientes oTiposDeClientes, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_InsertTipoCliente", oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oTiposDeClientes.Descripcion);
                    cmd.Parameters.AddWithValue("Estado_Tipo_Cliente", oTiposDeClientes.Estado_Tipo_Cliente);
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

        public bool Modificar(TiposDeClientes oTiposDeClientes, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_UpdateTipoCliente", oConexion);
                    cmd.Parameters.AddWithValue("Id_Tipo_Cliente", oTiposDeClientes.Id_Tipo_Cliente);
                    cmd.Parameters.AddWithValue("Descripcion", oTiposDeClientes.Descripcion);
                    cmd.Parameters.AddWithValue("Estado_Tipo_Cliente", oTiposDeClientes.Estado_Tipo_Cliente);
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

        public bool Eliminar(int Id_Tipo_Cliente, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_DeleteTipoCliente", oConexion);
                    cmd.Parameters.AddWithValue("Id_Tipo_Cliente", Id_Tipo_Cliente);
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
