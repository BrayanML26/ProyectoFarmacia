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
    public class CD_Sucursales
    {
        public List<Compania> Listar()
        {
            List<Compania> lista = new List<Compania>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT Id_Compania, Razon_Social, Nombre_Comercial, Nombre_Sucursal, Rnc, Direccion, Telefono, Email, Estado_Compania FROM Compania";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Compania()
                                {
                                    Id_Compania = Convert.ToInt32(dr["Id_Compania"]),
                                    Razon_Social = dr["Razon_Social"].ToString(),
                                    Nombre_Comercial = dr["Nombre_Comercial"].ToString(),
                                    Nombre_Sucursal = dr["Nombre_Sucursal"].ToString(),
                                    Rnc = dr["Rnc"].ToString(),
                                    Direccion = dr["Direccion"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Estado_Compania = Convert.ToBoolean(dr["Estado_Compania"])
                                }
                                );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Compania>();
            }

            return lista;
        }
        public int Registrar(Compania obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_InsertCompany", oConexion);
                    cmd.Parameters.AddWithValue("Razon_Social", obj.Razon_Social);
                    cmd.Parameters.AddWithValue("Nombre_Comercial", obj.Nombre_Comercial);
                    cmd.Parameters.AddWithValue("Nombre_Sucursal", obj.Nombre_Sucursal);
                    cmd.Parameters.AddWithValue("Rnc", obj.Rnc);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("Estado_Compania", obj.Estado_Compania);
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

        public bool Modificar(Compania obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_UpdateCompany", oConexion);
                    cmd.Parameters.AddWithValue("Id_Compania", obj.Id_Compania);
                    cmd.Parameters.AddWithValue("Razon_Social", obj.Razon_Social);
                    cmd.Parameters.AddWithValue("Nombre_Comercial", obj.Nombre_Comercial);
                    cmd.Parameters.AddWithValue("Nombre_Sucursal", obj.Nombre_Sucursal);
                    cmd.Parameters.AddWithValue("Rnc", obj.Rnc);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("Estado_Compania", obj.Estado_Compania);
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

        public bool Eliminar(int Id_Compania, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_DeleteCompany", oConexion);
                    cmd.Parameters.AddWithValue("Id_Compania", Id_Compania);
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
