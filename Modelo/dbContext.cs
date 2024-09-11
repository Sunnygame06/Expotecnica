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
                string server = "SQL8020.site4now.net";
                string database = "db_aac69e_higia";
                string userId = "db_aac69e_higia_admin";
                string Password = "Yv2R7XfC";
                SqlConnection conexion = new SqlConnection($"Server = {server}; Database = {database}; User Id = {userId}; Password = {Password}");
                
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
