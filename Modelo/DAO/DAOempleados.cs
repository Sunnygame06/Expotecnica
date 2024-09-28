using Login_Farmacia.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Login_Farmacia.Modelo.DAO
{
    internal class DAOempleados : DTOempleados
    {
        readonly SqlCommand command = new SqlCommand();

        public DataSet VerEmpleados()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Select * From Empleados";
                SqlCommand cmdVer = new SqlCommand(query, command.Connection);
                cmdVer.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdVer);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Empleados");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                return null;
            }

        }
        public int IngresarEmpleado()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Insert into Empleados Values(@param1, @param2, @param3, @param4, @param5, @param6)";
                SqlCommand cmdInsertar = new SqlCommand(query, command.Connection);
                cmdInsertar.Parameters.AddWithValue("Param1", Nombre);
                cmdInsertar.Parameters.AddWithValue("param2", FechaNacimiento);
                cmdInsertar.Parameters.AddWithValue("param3", EstadoCivil);
                cmdInsertar.Parameters.AddWithValue("param4", Dui);
                cmdInsertar.Parameters.AddWithValue("param5", Telefono);
                cmdInsertar.Parameters.AddWithValue("param6", IdUser);
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
                string query = "Update Empleado Set Nombre = @param1, Fecha_Nacimiento = @param2, Estado_Civil = @param3, DUI = @param4, Telefono = @param5, idUser = @param6 Where idEmpleados = @param7";
                SqlCommand cmdInsertar = new SqlCommand(query, command.Connection);
                cmdInsertar.Parameters.AddWithValue("Param1", Nombre);
                cmdInsertar.Parameters.AddWithValue("param2", FechaNacimiento);
                cmdInsertar.Parameters.AddWithValue("param3", EstadoCivil);
                cmdInsertar.Parameters.AddWithValue("param4", Dui);
                cmdInsertar.Parameters.AddWithValue("param5", Telefono);
                cmdInsertar.Parameters.AddWithValue("param6", IdUser);
                cmdInsertar.Parameters.AddWithValue("param7", IdEmpleado);
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

        public int EliminarEmpleado()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Delete From Empleados Where idEmpleados = @param1";
                SqlCommand cmdInsertar = new SqlCommand(query, command.Connection);
                cmdInsertar.Parameters.AddWithValue("Param1", IdEmpleado);
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

        public DataSet BuscarEmpleado(string valor)
        {
            try
            {
                command.Connection = GetConnection();
                string query = $"Select * From Empleados Where Nombre LIKE '%{valor}%' OR Fecha_Nacimiento LIKE '%{valor}%' OR Telefono LIKE '%{valor}%'";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Empleados");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                return null;
            }
        }

        public DataSet Llenarcombobox()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Select idUser From Personas";
                SqlCommand cmdVer = new SqlCommand(query, command.Connection);
                cmdVer.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdVer);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Personas");
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
