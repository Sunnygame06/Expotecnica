using Login_Farmacia.Formularios.Server;
using Login_Farmacia.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Login_Farmacia.Controlador.Servidor
{
    internal class ControllerAdminconexcion
    {
        FrmAdminConexion ObjConn;

        public ControllerAdminconexcion(FrmAdminConexion Vista, int origen)
        {
            ObjConn = Vista;
            ObjConn.Load += new EventHandler(Iniciar);
            VerificarOrigen(origen);
            ObjConn.rdHabilitarWindows.CheckedChanged += new EventHandler(rdTrueMarked);
            ObjConn.rdDeshabilitarWindows.CheckedChanged += new EventHandler(rdFalseMarked);
            ObjConn.btnGuardar.Click += new EventHandler(GuardarRegistro);
        }

        public void Iniciar(object sender, EventArgs e)
        {
            ObjConn.txtSqlPass.UseSystemPasswordChar = true;
        }

        public void VerificarOrigen(int origen)
        {
            if(origen == 2)
            {
                ObjConn.txtUser.Text = DTOdbContext.Server;
                ObjConn.txtDataBase.Text = DTOdbContext.Database;
                ObjConn.txtSqlAuth.Text = DTOdbContext.User;
                ObjConn.txtSqlPass.Text = DTOdbContext.Password;
            }
        }

        void rdFalseMarked(object sender, EventArgs e)
        {
            if (ObjConn.rdDeshabilitarWindows.Checked == true)
            {
                ObjConn.txtSqlAuth.Enabled = true;
                ObjConn.txtSqlPass.Enabled = true;
            }
        }

        void rdTrueMarked(object sender, EventArgs e)
        {
            if (ObjConn.rdHabilitarWindows.Checked == true)
            {
                ObjConn.txtSqlAuth.Enabled = false;
                ObjConn.txtSqlPass.Enabled = false;
                ObjConn.txtSqlAuth.Clear();
                ObjConn.txtSqlPass.Clear();

            }
        }

        void GuardarRegistro(object sender, EventArgs e) 
        {
            GuardarConfiguracionXML();
        }

        public void GuardarConfiguracionXML()
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                XmlDeclaration decl = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(decl);

                XmlElement root = doc.CreateElement("Conn");
                doc.AppendChild(root);

                XmlElement servidor = doc.CreateElement("Server");
                string servidorCode = CodificarBase64String(ObjConn.txtUser.Text.Trim());
                servidor.InnerText = servidorCode;
                root.AppendChild(servidor);

                XmlElement DataBase = doc.CreateElement("Database");
                string DataBaseCode = CodificarBase64String(ObjConn.txtDataBase.Text.Trim());
                DataBase.InnerText = DataBaseCode;
                root.AppendChild(DataBase);

                if (ObjConn.rdDeshabilitarWindows.Checked == true)
                {
                    XmlElement SqlAuth = doc.CreateElement("SqlAuth");
                    string SqlAuthCode = CodificarBase64String(ObjConn.txtSqlAuth.Text.Trim());
                    SqlAuth.InnerText = SqlAuthCode;
                    root.AppendChild(SqlAuth);

                    XmlElement SqlPass = doc.CreateElement("SqlPass");
                    string SqlPassCode = CodificarBase64String(ObjConn.txtSqlPass.Text.Trim());
                    SqlPass.InnerText = SqlPassCode;
                    root.AppendChild(SqlPass);
                }
                else
                {
                    XmlElement SqlAuth = doc.CreateElement("SqlAuth");
                    SqlAuth.InnerText = string.Empty;
                    root.AppendChild(SqlAuth);

                    XmlElement SqlPass = doc.CreateElement("SqlPass");
                    SqlPass.InnerText = string.Empty;
                    root.AppendChild(SqlPass);
                }
                SqlConnection con = dbContext.testConnection(ObjConn.txtUser.Text.Trim(), ObjConn.txtDataBase.Text.Trim(), ObjConn.txtSqlAuth.Text.Trim(), ObjConn.txtSqlPass.Text.Trim());
                if (con != null)
                {
                    doc.Save("config_server.xml");
                    DTOdbContext.Server = ObjConn.txtUser.Text.Trim();
                    DTOdbContext.Database = ObjConn.txtDataBase.Text.Trim();
                    DTOdbContext.User = ObjConn.txtSqlAuth.Text.Trim();
                    DTOdbContext.Password = ObjConn.txtSqlPass.Text.Trim();
                    MessageBox.Show($"El archivo fue creado exitosamente", "Archivo de configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ObjConn.Hide();
                }
            }
            catch (XmlException ex)
            {
                MessageBox.Show($"{ex.Message}, no se pudo crear el archivo de configuración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public string CodificarBase64String(string textoacifrar)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(textoacifrar);
                string base64String = Convert.ToBase64String(bytes);
                return base64String;
            }
            catch (Exception)
            {
                return string.Empty;
            } 
        }
    }
}
