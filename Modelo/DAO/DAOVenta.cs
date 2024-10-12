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
    internal class DAOVenta : DTOVenta
    {
        readonly SqlCommand command = new SqlCommand();

        public DataSet VerEmpleado()
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

        public DataSet VerCliente()
        {
            try
            {
                command.Connection = GetConnection();
                string queryUser = "Select idCliente, Nombre From VerClientes";
                SqlCommand cmdVer = new SqlCommand(queryUser, command.Connection);
                cmdVer.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdVer);
                DataSet ds = new DataSet();
                adp.Fill(ds, "VerClientes");
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

        public int RegistrarVenta()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Insert into Ventas (idCliente, idEmpleado, Hora, Fecha) Values (@param1, @param2, @param3, @param4)";
                SqlCommand cmdInsert = new SqlCommand(query, command.Connection);
                cmdInsert.Parameters.AddWithValue("@param1", IdCliente);
                cmdInsert.Parameters.AddWithValue("@Param2", IdEmpleado);
                cmdInsert.Parameters.AddWithValue("@Param3", Hora);
                cmdInsert.Parameters.AddWithValue("@Param4", Fecha);
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
    }
}
