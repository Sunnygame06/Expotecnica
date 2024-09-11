using Login_Farmacia.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Login_Farmacia.Modelo.DAO
{
    public class DAOPreguntas : DTOPreguntas
    {
        readonly SqlCommand command = new SqlCommand();

        public bool Info()
        {
            try
            {
                command.Connection = GetConnection();
                string query = "Select * From Empleados Where Nombre = @Nombre and DUI = @DUI and Telefono = @Telefono";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("@Nombre", Nombre1);
                cmd.Parameters.AddWithValue("@DUI", DUI1);
                cmd.Parameters.AddWithValue("@Telefono", Telefono1);
                SqlDataReader rd = cmd.ExecuteReader();
                return rd.HasRows;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
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
    }
}
