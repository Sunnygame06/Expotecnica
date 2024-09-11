using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login_Farmacia.Modelo.DTO;

namespace Login_Farmacia.Modelo.DAO
{
    internal class DAOProveedores : DTOProveedores
    {
        readonly SqlCommand command = new SqlCommand();

        public DataSet VerProveedores()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Select * From Proveedor";
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

        public int IngresarProveedor()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Insert into Proveedor Values(@param1, @param2, @param3, @param4)";
                SqlCommand cmdInsertar = new SqlCommand(query, command.Connection);
                cmdInsertar.Parameters.AddWithValue("Param1", NombreE);
                cmdInsertar.Parameters.AddWithValue("param2", Contacto);
                cmdInsertar.Parameters.AddWithValue("param3", Direccion);
                cmdInsertar.Parameters.AddWithValue("param4", Email);
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
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                return -1;
            }
            finally
            {
                GetConnection().Close();
            }
        }

        public int ActualizarProveedor()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Update Proveedor Set Nombre_Empresa = @param1, Contacto = @param2, Direccion = @param3, Email = @param4 Where idProveedor = @param5";
                SqlCommand cmdInsertar = new SqlCommand(query, command.Connection);
                cmdInsertar.Parameters.AddWithValue("Param1", NombreE);
                cmdInsertar.Parameters.AddWithValue("param2", Contacto);
                cmdInsertar.Parameters.AddWithValue("param3", Direccion);
                cmdInsertar.Parameters.AddWithValue("param4", Email);
                cmdInsertar.Parameters.AddWithValue("param5", IdProvedor);
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

        public int EliminarProveedor()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Delete From Proveedor Where idProveedor = @param1";
                SqlCommand cmdInsertar = new SqlCommand(query, command.Connection);
                cmdInsertar.Parameters.AddWithValue("Param1", IdProvedor);
                int respuesta = cmdInsertar.ExecuteNonQuery();
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

        public DataSet BuscarProveedores(string valor)
        {
            try
            {
                command.Connection = GetConnection();
                string query = $"Select * From Proveedor Where Nombre_Empresa LIKE '%{valor}%' OR Contacto LIKE '%{valor}%' OR Direccion LIKE '%{valor}%' OR Email LIKE '%{valor}%'";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
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
    }
}
