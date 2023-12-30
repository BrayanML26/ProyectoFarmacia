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
    public class CD_Productos
    {
        public List<Productos> Listar()
        {
            List<Productos> lista = new List<Productos>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SELECT co.Id_Compania, p.Id_Producto, p. Nombre_Producto, d.Id_Departamento, g.Id_Grupo, sg.Id_Subgrupo,");
                    sb.AppendLine("mp.Id_Marca_Producto, tp.Id_Tipo_Producto, p.Venta_Negativo, p.Producto_Controlado, p.Producto_Generico, p.Estado_Producto");
                    sb.AppendLine("FROM Productos p");
                    sb.AppendLine("INNER JOIN Compania co ON co.Id_Compania = p.Id_Compania");
                    sb.AppendLine("INNER JOIN Departamentos d ON d.Id_Departamento = p.Id_Departamento");
                    sb.AppendLine("INNER JOIN Grupos g ON g.Id_Grupo = p.Id_Grupo");
                    sb.AppendLine("INNER JOIN Subgrupos sg ON sg.Id_Subgrupo = p.Id_Subgrupo");
                    sb.AppendLine("INNER JOIN Marcas_Productos mp ON mp.Id_Marca_Producto = p.Id_Marca_Producto");
                    sb.AppendLine("INNER JOIN Tipos_De_Productos tp ON tp.Id_Tipo_Producto = p.Id_Tipo_Producto");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Productos()
                            {
                                oId_Compania = new Compania() { Id_Compania = Convert.ToInt32(dr["Id_Compania"]) },
                                Id_Producto = Convert.ToInt32(dr["Id_Producto"]),
                                Nombre_Producto = dr["Nombre_Producto"].ToString(),
                                oId_Departamento = new Departamentos() { Id_Departamento = Convert.ToInt32(dr["Id_Departamento"]) },
                                oId_Grupo = new Grupos() { Id_Grupo = Convert.ToInt32(dr["Id_Grupo"]) },
                                oId_Subgrupo = new Subgrupos() { Id_Subgrupo = Convert.ToInt32(dr["Id_Subgrupo"]) },
                                oId_Marca_Producto = new MarcasProductos() { Id_Marca_Producto = Convert.ToInt32(dr["Id_Marca_Producto"]) },
                                oId_Tipo_Producto = new TiposDeProductos() { Id_Tipo_Producto = Convert.ToInt32(dr["Id_Tipo_Producto"]) },
                                Venta_Negativo = Convert.ToBoolean(dr["Venta_Negativo"]),
                                Producto_Controlado = Convert.ToBoolean(dr["Producto_Controlado"]),
                                Producto_Generico = Convert.ToBoolean(dr["Producto_Generico"]),
                                Estado_Producto = Convert.ToBoolean(dr["Estado_Producto"])
                            });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Productos>();
            }
            return lista;
        }

        public int Registrar(Productos obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_InsertProducto", oconexion);
                    cmd.Parameters.AddWithValue("Id_Compania", obj.oId_Compania.Id_Compania);
                    cmd.Parameters.AddWithValue("Nombre_Producto", obj.Nombre_Producto);
                    cmd.Parameters.AddWithValue("Id_Departamento", obj.oId_Departamento.Id_Departamento);
                    cmd.Parameters.AddWithValue("Id_Grupo", obj.oId_Grupo.Id_Grupo);
                    cmd.Parameters.AddWithValue("Id_Subgrupo", obj.oId_Subgrupo.Id_Subgrupo);
                    cmd.Parameters.AddWithValue("Id_Marca_Producto", obj.oId_Marca_Producto.Id_Marca_Producto);
                    cmd.Parameters.AddWithValue("Id_Tipo_Producto", obj.oId_Tipo_Producto.Id_Tipo_Producto);
                    cmd.Parameters.AddWithValue("Venta_Negativo", obj.Venta_Negativo);
                    cmd.Parameters.AddWithValue("Producto_Controlado", obj.Producto_Controlado);
                    cmd.Parameters.AddWithValue("Producto_Generico", obj.Producto_Generico);
                    cmd.Parameters.AddWithValue("Estado_Producto", obj.Estado_Producto);
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

        public bool Modificar(Productos obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_UpdateProducto", oconexion);
                    cmd.Parameters.AddWithValue("Id_Producto", obj.Id_Producto);
                    cmd.Parameters.AddWithValue("Id_Compania", obj.oId_Compania.Id_Compania);
                    cmd.Parameters.AddWithValue("Nombre_Producto", obj.Nombre_Producto);
                    cmd.Parameters.AddWithValue("Id_Departamento", obj.oId_Departamento.Id_Departamento);
                    cmd.Parameters.AddWithValue("Id_Grupo", obj.oId_Grupo.Id_Grupo);
                    cmd.Parameters.AddWithValue("Id_Subgrupo", obj.oId_Subgrupo.Id_Subgrupo);
                    cmd.Parameters.AddWithValue("Id_Marca_Producto", obj.oId_Marca_Producto.Id_Marca_Producto);
                    cmd.Parameters.AddWithValue("Id_Tipo_Producto", obj.oId_Tipo_Producto.Id_Tipo_Producto);
                    cmd.Parameters.AddWithValue("Venta_Negativo", obj.Venta_Negativo);
                    cmd.Parameters.AddWithValue("Producto_Controlado", obj.Producto_Controlado);
                    cmd.Parameters.AddWithValue("Producto_Generico", obj.Producto_Generico);
                    cmd.Parameters.AddWithValue("Estado_Producto", obj.Estado_Producto);
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

        public bool Eliminar(int Id_Producto, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_DeleteProducto", oconexion);
                    cmd.Parameters.AddWithValue("Id_Producto", Id_Producto);
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
