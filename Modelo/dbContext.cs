using Login_Farmacia.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia
{
    public class dbContext
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection conexion = new SqlConnection($"Server = {DTOdbContext.Server}; Database = {DTOdbContext.Database}; User Id = {DTOdbContext.User}; Password = {DTOdbContext.Password}");
                
                conexion.Open();
                return conexion;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC01-Hubo error en la conexion de la bases de datos" + ex.Message);
                return null;
            }
        }

        public static SqlConnection testConnection(string server, string database, string user, string password)
        {
            try
            {
                SqlConnection conexion = new SqlConnection($"Server = {server}; DataBase = {database}; User Id = {user}; Password = {password}");
                conexion.Open();
                return conexion;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC01-Hubo error en la conexion de la bases de datos" + ex.Message);
                return null;
            }
        }
    }
}
