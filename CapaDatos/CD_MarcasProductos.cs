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
    public class CD_MarcasProductos
    {
        public List<MarcasProductos> Listar()
        {
            List<MarcasProductos> lista = new List<MarcasProductos>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("select co.Id_Compania, mp.Id_Marca_Producto, mp.Descripcion_Marca, mp.Estado_Marca");
                    sb.AppendLine("from Marcas_Productos mp");
                    sb.AppendLine("inner join Compania co on co.Id_Compania = mp.Id_Compania");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new MarcasProductos()
                                {
                                    oId_Compania = new Compania() { Id_Compania = Convert.ToInt32(dr["Id_Compania"]) },
                                    Id_Marca_Producto = Convert.ToInt32(dr["Id_Marca_Producto"]),
                                    Descripcion_Marca = dr["Descripcion_Marca"].ToString(),
                                    Estado_Marca = Convert.ToBoolean(dr["Estado_Marca"])
                                }
                                );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<MarcasProductos>();
            }

            return lista;
        }
        public int Registrar(MarcasProductos obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_InsertMarcaProducto", oConexion);
                    cmd.Parameters.AddWithValue("Id_Compania", obj.oId_Compania.Id_Compania);
                    cmd.Parameters.AddWithValue("Descripcion_Marca", obj.Descripcion_Marca);
                    cmd.Parameters.AddWithValue("Estado_Marca", obj.Estado_Marca);
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

        public bool Modificar(MarcasProductos obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_UpdateMarcaProducto", oConexion);
                    cmd.Parameters.AddWithValue("Id_Compania", obj.oId_Compania.Id_Compania);
                    cmd.Parameters.AddWithValue("Id_Marca_Producto", obj.Id_Marca_Producto);
                    cmd.Parameters.AddWithValue("Descripcion_Marca", obj.Descripcion_Marca);
                    cmd.Parameters.AddWithValue("Estado_Marca", obj.Estado_Marca);
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

        public bool Eliminar(int Id_Marca_Producto, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_DeleteMarcaProducto", oConexion);
                    cmd.Parameters.AddWithValue("Id_Marca_Producto", Id_Marca_Producto);
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
