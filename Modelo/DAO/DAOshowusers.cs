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
    internal class DAOshowusers : DTOshowusers
    {
        readonly SqlCommand command = new SqlCommand();

        public DataSet Verusers()
        {
            try
            {
                command.Connection = GetConnection();
                string queryUser = "Select * From Cliente";
                SqlCommand cmdVer = new SqlCommand(queryUser, command.Connection);
                cmdVer.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdVer);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Cliente");
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
        public int Ingresarusers()
        {
            try
            {
                command.Connection = GetConnection();
                string queryUser = "Insert into Cliente Values (@Nombre, @Direccion, @Telefono)";
                SqlCommand cmdInsert = new SqlCommand(queryUser, command.Connection);
                cmdInsert.Parameters.AddWithValue("@Nombre", Nombre);
                cmdInsert.Parameters.AddWithValue("@Direccion", Direccion);
                cmdInsert.Parameters.AddWithValue("@Telefono", Numero);
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
                GetConnection().Close();
            }
        }
        
        public int Actualizarusers()
        {
            try
            {
                command.Connection = GetConnection();
                string queryUser = "Update Cliente set Nombre = @param1, Direccion = @param2, Telefono = @param3 Where idCliente = @param4";
                SqlCommand cmdUpdate = new SqlCommand(queryUser, command.Connection);
                cmdUpdate.Parameters.AddWithValue("@param1", Nombre);
                cmdUpdate.Parameters.AddWithValue("@param2", Direccion);
                cmdUpdate.Parameters.AddWithValue("@param3", Numero);
                cmdUpdate.Parameters.AddWithValue("@param4", Id);
                int respuesta2 = cmdUpdate.ExecuteNonQuery();
                if (respuesta2 == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                GetConnection().Close();
            }
        }

        public int Eliminarusers()
        {
            try
            {
                command.Connection = GetConnection();
                string queryUser = "Delete From Cliente Where idCliente = @param1";
                SqlCommand cmdDelete = new SqlCommand(queryUser, command.Connection);
                cmdDelete.Parameters.AddWithValue("param1", Id);
                int respuesta3 = cmdDelete.ExecuteNonQuery();
                return respuesta3;
            }
            catch (Exception)
            {
                return -1;
            }
            finally 
            {
                GetConnection().Close();
            }
        }

        public DataSet BuscarClientes(string valor)
        {
            try
            {
                command.Connection = GetConnection();
                string query = $"Select * From Cliente Where Nombre LIKE '%{valor}%' OR Direccion LIKE '%{valor}%' OR Telefono LIKE '%{valor}%'";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Cliente");
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
