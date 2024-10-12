using Login_Farmacia.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia.Modelo.DAO
{
    internal class DAOProductos : DTOProducto
    {
        readonly SqlCommand command = new SqlCommand();

        public DataSet VerProductos()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Select * From Producto";
                SqlCommand cmdVer = new SqlCommand(query, command.Connection);
                cmdVer.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdVer);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Producto");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                return null;
            }
        }

        public DataSet VerProveedores()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Select idProveedor, Nombre_Empresa From Proveedor";
                SqlCommand cmdVer = new SqlCommand(query, command.Connection);
                cmdVer.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdVer);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Proveedor");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                return null;
            }
        }

        public int IngresarProducto()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Insert into Producto Values(@param1, @param2, @param3, @param4, @param5, @param6)";
                SqlCommand cmdInsertar = new SqlCommand(query, command.Connection);
                cmdInsertar.Parameters.AddWithValue("Param1", Nombre);
                cmdInsertar.Parameters.AddWithValue("param5", Descripcion);
                cmdInsertar.Parameters.AddWithValue("param3", Precio);  
                cmdInsertar.Parameters.AddWithValue("param2", FechadeVencimiento);
                cmdInsertar.Parameters.AddWithValue("param4", Stock);
                cmdInsertar.Parameters.AddWithValue("param6", Proveedor);
                int respuesta = cmdInsertar.ExecuteNonQuery();
                if (respuesta == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                return -1;
            }
            finally
            {
                GetConnection().Close();
            }
        }

        public int ActualizarEmpleado()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Update Producto Set nombre_Producto = @param1, Fecha_Vencimiento = @param2, Precio = @param3, Stock = @param4, Descripcion = @param5, idProveedor = @param6 Where Codigo_Producto = @param7";
                SqlCommand cmdInsertar = new SqlCommand(query, command.Connection);
                cmdInsertar.Parameters.AddWithValue("Param1", Nombre);
                cmdInsertar.Parameters.AddWithValue("param2", FechadeVencimiento);
                cmdInsertar.Parameters.AddWithValue("param3", Precio);
                cmdInsertar.Parameters.AddWithValue("param4", Stock);
                cmdInsertar.Parameters.AddWithValue("param5", Descripcion);
                cmdInsertar.Parameters.AddWithValue("param6", Proveedor);
                cmdInsertar.Parameters.AddWithValue("param7", IdProducto);
                int respuesta = cmdInsertar.ExecuteNonQuery();
                if (respuesta == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                return -1;
            }
            finally
            {
                GetConnection().Close();
            }
        }

        public int EliminarProducto()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Delete From Producto Where Codigo_Producto = @param1";
                SqlCommand cmdEliminar = new SqlCommand(query, command.Connection);
                cmdEliminar.Parameters.AddWithValue("@param1", IdProducto);
                int respuesta = cmdEliminar.ExecuteNonQuery();
                return respuesta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                return -1;
            }
            finally
            {
                GetConnection().Close();
            }
        }

        public DataSet BuscarProducto(string valor)
        {
            try
            {
                command.Connection = GetConnection();
                string query = $"Select * From Producto Where nombre_Producto LIKE '%{valor}%' OR Codigo_Producto LIKE '%{valor}%'";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Producto");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                return null;
            }
        }
    }
}
