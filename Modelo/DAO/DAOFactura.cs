using Login_Farmacia.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia.Modelo.DAO
{
    internal class DAOFactura : DTOFactura
    {
        readonly SqlCommand command = new SqlCommand();

        public DataSet Verfactura()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "SELECT * FROM DetalleVenta";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "DetalleVenta");
                return ds;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
                return null;
            }
            finally
            {
                GetConnection().Close();
            }
        }

        public DataSet VerRoles()
        {
            try
            {
                command.Connection = GetConnection();
                string queryUser = "Select idEmpleados, Nombre From VerEmpleados";
                SqlCommand cmdVer = new SqlCommand(queryUser, command.Connection);
                cmdVer.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdVer);
                DataSet ds = new DataSet();
                adp.Fill(ds, "VerEmpleados");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
                return null;
            }
            finally
            {
                GetConnection().Close();
            }
        }

        public bool VerCodigo()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "SELECT * FROM Producto WHERE Codigo_Producto = @param1";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("@param1", CodigoProducto);
                SqlDataReader rd = cmd.ExecuteReader();
                return rd.HasRows;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                GetConnection().Close();
            }
        }


        public int IngresarPro()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Insert into DetalleVenta(Cantidad, Codigo_Producto, idVenta) Values (@param1, @param2, @param3)";
                SqlCommand cmdInsert = new SqlCommand(query, command.Connection);
                cmdInsert.Parameters.AddWithValue("@param1", Cantidad);
                cmdInsert.Parameters.AddWithValue("@Param2", CodigoProducto);
                cmdInsert.Parameters.AddWithValue("@Param3", Venta);
                int respuesta = cmdInsert.ExecuteNonQuery();
                if (respuesta == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public int ActualizarPro()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Update DetalleVenta Set Cantidad = @param1, Codigo_Producto = @param2, idVenta = @param3 Where idDetalleVenta = @param4";
                SqlCommand cmdInsert = new SqlCommand(query, command.Connection);
                cmdInsert.Parameters.AddWithValue("@param1", Cantidad);
                cmdInsert.Parameters.AddWithValue("@Param2", CodigoProducto);
                cmdInsert.Parameters.AddWithValue("@Param3", Venta);
                cmdInsert.Parameters.AddWithValue("@Param4", IdDetalleVenta);
                int respuesta = cmdInsert.ExecuteNonQuery();
                if (respuesta == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public int EliminarPro()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Delete From DetalleVenta Where idDetalleVenta = @param4";
                SqlCommand cmdInsert = new SqlCommand(query, command.Connection);
                cmdInsert.Parameters.AddWithValue("@Param4", IdDetalleVenta);
                int respuesta = cmdInsert.ExecuteNonQuery();
                if (respuesta == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public bool VerDetalleVenta()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "SELECT * FROM DetalleVenta";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                SqlDataReader rd = cmd.ExecuteReader();
                return rd.HasRows;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                GetConnection().Close();
            }
        }

        public int EliminarDetalleVenta()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Delete From DetalleVenta";
                SqlCommand cmdInsert = new SqlCommand(query, command.Connection);
                int respuesta = cmdInsert.ExecuteNonQuery();
                if (respuesta == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public DataSet BuscarProductos(string valor)
        {
            try
            {
                command.Connection = GetConnection();
                string query = $"Select * From DetalleVenta Where Codigo_Producto LIKE '%{valor}%'";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "DetalleVenta");
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                GetConnection().Close();
            }
        }
    }
}
