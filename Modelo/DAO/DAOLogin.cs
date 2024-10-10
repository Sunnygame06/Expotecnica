using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login_Farmacia.Modelo.DTO;
using Login_Farmacia.Modelo;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Runtime.Remoting.Messaging;

namespace Login_Farmacia.Modelo.DAO
{
    public class DAOLogin : DTOLogin
    {
        SqlCommand command = new SqlCommand();
        public bool Login()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "SELECT * FROM Personas WHERE Usernames COLLATE Latin1_General_CI_AI = @Usernames AND Passwords COLLATE Latin1_General_CI_AI = @Passwords";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("@Usernames", Username1);
                cmd.Parameters.AddWithValue("@Passwords", Password1);
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

        public bool LoginAdmin()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "SELECT * FROM Personas Where Usernames COLLATE Latin1_General_CI_AI = @Usernames AND Passwords COLLATE Latin1_General_CI_AI = @Passwords AND idRol = 1";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("@Usernames", Username1);
                cmd.Parameters.AddWithValue("@Passwords", Password1);
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

        public bool ContraAdmin()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "SELECT * FROM Personas Where Passwords COLLATE Latin1_General_CI_AI = @Passwords AND idRol = 1";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("@Passwords", Password1);
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

        public DataSet VerRoles()
        {
            try
            {
                command.Connection = GetConnection();
                string queryUser = "Select idRol, Rol From Rol";
                SqlCommand cmdVer = new SqlCommand(queryUser, command.Connection);
                cmdVer.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdVer);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Rol");
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

        public DataSet VerUsuario()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "SELECT * FROM VerUsuarios";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "VerUsuarios");
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

        public int RegistrarseAdmin()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Insert into Personas(Usernames, Passwords, idRol, Gmail, Pin) Values (@Usernames, @Passwords, '1', @Gmail, @Pin)";
                SqlCommand cmdInsert = new SqlCommand(query, command.Connection);
                cmdInsert.Parameters.AddWithValue("@Usernames", Username1);
                cmdInsert.Parameters.AddWithValue("@Passwords", Password1);
                cmdInsert.Parameters.AddWithValue("@Gmail", Correo);
                cmdInsert.Parameters.AddWithValue("@Pin", Pin);
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

        public int RegistrarseEmpleado()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Insert into Personas(Usernames, Passwords, idRol, Gmail, Pin) Values (@Usernames, @Passwords, '2', @Gmail, @Pin)";
                SqlCommand cmdInsert = new SqlCommand(query, command.Connection);
                cmdInsert.Parameters.AddWithValue("@Usernames", Username1);
                cmdInsert.Parameters.AddWithValue("@Passwords", Password1);
                cmdInsert.Parameters.AddWithValue("@Gmail", Correo);
                cmdInsert.Parameters.AddWithValue("@Pin", Pin);
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

        public bool VerUsuarioAdmin()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "SELECT * FROM Personas WHERE idRol = 1";
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


        public int CambiarContra()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Update Personas Set Passwords = @param1 where Usernames = @param2";
                SqlCommand cmdUpdate = new SqlCommand(query, command.Connection);
                cmdUpdate.Parameters.AddWithValue("param1", Password1);
                cmdUpdate.Parameters.AddWithValue("param2", Username1);
                int respuesta = cmdUpdate.ExecuteNonQuery();
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

        public int CambiarContraReinicio()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Update Personas Set Passwords = @param1, Usernames = @param2, idRol = @param3 Where idUser = @param4";
                SqlCommand cmdUpdate = new SqlCommand(query, command.Connection);
                cmdUpdate.Parameters.AddWithValue("param1", Password1);
                cmdUpdate.Parameters.AddWithValue("param2", Username1);
                cmdUpdate.Parameters.AddWithValue("param3", Rol1);
                cmdUpdate.Parameters.AddWithValue("param4", Id);
                int respuesta = cmdUpdate.ExecuteNonQuery();
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

        public int EliminarUsuario()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Delete From Personas Where idUser = @param1";
                SqlCommand cmdUpdate = new SqlCommand(query, command.Connection);
                cmdUpdate.Parameters.AddWithValue("param1", Id);
                int respuesta = cmdUpdate.ExecuteNonQuery();
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

        public DataSet BuscarUsuario(string valor)
        {
            try
            {
                command.Connection = GetConnection();
                string query = $"Select * From VerUsuarios Where Usernames LIKE '%{valor}%' OR Rol LIKE '%{valor}%'";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "VerUsuarios");
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

        public bool BuscarPin()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "SELECT * FROM Personas Where Usernames = @param1 AND Pin = @param2";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("param1", Username1);
                cmd.Parameters.AddWithValue("param2", Pin);
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

        public bool BuscarCorreo()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "SELECT * FROM Personas WHERE Usernames = @Usernames AND Gmail = @Gmail";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("@Usernames", Username1);
                cmd.Parameters.AddWithValue("@Gmail", Correo);
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

        public bool RegistrarPin()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Update Personas Set Pin = @param1 Where Usernames = @param2";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("param1", Pin);
                cmd.Parameters.AddWithValue("param2", Username1);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
