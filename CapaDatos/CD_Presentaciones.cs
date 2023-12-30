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
    public class CD_Presentaciones
    {
        public List<Presentaciones> Listar()
        {
            List<Presentaciones> lista = new List<Presentaciones>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SELECT co.Id_Compania, prod.Id_Producto, p.Id_Presentacion,  p.Nombre_Completo, p.Nombre_Corto, p.Nivel_Inventario_Maximo,");
                    sb.AppendLine("p.Nivel_Inventario_Minimo, p.Precio, p.Costo_De_Lista, p.Costo_Promerio, p.Porcentaje_Beneficio,");
                    sb.AppendLine("p.Descuento_Maximo_Permitido, ti.Id_Impuesto, p.Estado_Presentacion");
                    sb.AppendLine("FROM Presentaciones p");
                    sb.AppendLine("INNER JOIN Compania co ON co.Id_Compania = p.Id_Compania");
                    sb.AppendLine("INNER JOIN Productos prod ON prod.Id_Producto = p.Id_Producto");
                    sb.AppendLine("INNER JOIN Tipos_De_Impuestos ti ON ti.Id_Impuesto = p.Id_Impuesto");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Presentaciones()
                            {
                                oId_Compania = new Compania() { Id_Compania = Convert.ToInt32(dr["Id_Compania"]) },
                                oId_Producto = new Productos() { Id_Producto = Convert.ToInt32(dr["Id_Producto"]) },
                                Id_Presentacion = Convert.ToInt32(dr["Id_Presentacion"]),
                                Nombre_Completo = dr["Nombre_Completo"].ToString(),
                                Nombre_Corto = dr["Nombre_Corto"].ToString(),
                                Nivel_Inventario_Maximo = Convert.ToInt32(dr["Nivel_Inventario_Maximo"]),
                                Nivel_Inventario_Minimo = Convert.ToInt32(dr["Nivel_Inventario_Minimo"]),
                                Precio = Convert.ToDouble(dr["Precio"]),
                                Costo_De_Lista = Convert.ToDouble(dr["Costo_De_Lista"]),
                                Costo_Promerio = Convert.ToDouble(dr["Costo_Promerio"]),
                                Porcentaje_Beneficio = Convert.ToDouble(dr["Porcentaje_Beneficio"]),
                                Descuento_Maximo_Permitido = Convert.ToDouble(dr["Descuento_Maximo_Permitido"]),
                                oId_Impuesto = new TiposDeImpuestos() { Id_Impuesto = Convert.ToInt32(dr["Id_Impuesto"]) },
                                Estado_Presentacion = Convert.ToBoolean(dr["Estado_Presentacion"])
                            });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Presentaciones>();
            }
            return lista;
        }

        public int Registrar(Presentaciones obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_InsertPresentacion", oconexion);
                    cmd.Parameters.AddWithValue("Id_Compania", obj.oId_Compania.Id_Compania);
                    cmd.Parameters.AddWithValue("Id_Producto", obj.oId_Producto.Id_Producto);
                    cmd.Parameters.AddWithValue("Id_Presentacion", obj.Id_Presentacion);
                    cmd.Parameters.AddWithValue("Nombre_Completo", obj.Nombre_Completo);
                    cmd.Parameters.AddWithValue("Nombre_Corto", obj.Nombre_Corto);
                    cmd.Parameters.AddWithValue("Nivel_Inventario_Maximo", obj.Nivel_Inventario_Maximo);
                    cmd.Parameters.AddWithValue("Nivel_Inventario_Minimo", obj.Nivel_Inventario_Minimo);
                    cmd.Parameters.AddWithValue("Precio", obj.Precio);
                    cmd.Parameters.AddWithValue("Costo_De_Lista", obj.Costo_De_Lista);
                    cmd.Parameters.AddWithValue("Costo_Promedio", obj.Costo_Promerio);
                    cmd.Parameters.AddWithValue("Porcentaje_Beneficio", obj.Porcentaje_Beneficio);
                    cmd.Parameters.AddWithValue("Descuento_Maximo_Permitido", obj.Descuento_Maximo_Permitido);
                    cmd.Parameters.AddWithValue("Id_Impuesto", obj.oId_Impuesto.Id_Impuesto);
                    cmd.Parameters.AddWithValue("Estado_Presentacion", obj.Estado_Presentacion);
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

        public bool Modificar(Presentaciones obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_UpdatePresentacion", oconexion);
                    cmd.Parameters.AddWithValue("Id_Compania", obj.oId_Compania.Id_Compania);
                    cmd.Parameters.AddWithValue("Id_Producto", obj.oId_Producto.Id_Producto);
                    cmd.Parameters.AddWithValue("Id_Presentacion", obj.Id_Presentacion);
                    cmd.Parameters.AddWithValue("Nombre_Completo", obj.Nombre_Completo);
                    cmd.Parameters.AddWithValue("Nombre_Corto", obj.Nombre_Corto);
                    cmd.Parameters.AddWithValue("Nivel_Inventario_Maximo", obj.Nivel_Inventario_Maximo);
                    cmd.Parameters.AddWithValue("Nivel_Inventario_Minimo", obj.Nivel_Inventario_Minimo);
                    cmd.Parameters.AddWithValue("Precio", obj.Precio);
                    cmd.Parameters.AddWithValue("Costo_De_Lista", obj.Costo_De_Lista);
                    cmd.Parameters.AddWithValue("Costo_Promedio", obj.Costo_Promerio);
                    cmd.Parameters.AddWithValue("Porcentaje_Beneficio", obj.Porcentaje_Beneficio);
                    cmd.Parameters.AddWithValue("Descuento_Maximo_Permitido", obj.Descuento_Maximo_Permitido);
                    cmd.Parameters.AddWithValue("Id_Impuesto", obj.oId_Impuesto.Id_Impuesto);
                    cmd.Parameters.AddWithValue("Estado_Presentacion", obj.Estado_Presentacion);
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

        public bool Eliminar(int Id_Presentacion, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_DeletePresentacion", oconexion);
                    cmd.Parameters.AddWithValue("Id_Presentacion", Id_Presentacion);
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
