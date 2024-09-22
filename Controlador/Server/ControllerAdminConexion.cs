using Login_Farmacia.Formularios.Server;
using Login_Farmacia.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Login_Farmacia.Controlador
{
    internal class ControllerAdminConexion
    {
        FrmAdminConexion ObjConexion;
        int origen;

        public ControllerAdminConexion(FrmAdminConexion Vista, int origen)
        {
            ObjConexion = Vista;
            verificarorigen(origen);
            ObjConexion.rdDeshabilitarWindows.CheckedChanged += new EventHandler(rdDeshabilitar);
            ObjConexion.rdHabilitarWindows.CheckedChanged += new EventHandler(rdHabilitar);
            ObjConexion.btnGuardar.Click += new EventHandler(Guardar);
        }

        public void verificarorigen(int origen)
        {
            if (origen == 2)
            {
                ObjConexion.txtServer.Text = DTOdbContext.Server;
                ObjConexion.txtDataBase.Text = DTOdbContext.Database;
                ObjConexion.txtSqlAuth.Text = DTOdbContext.User;
                ObjConexion.txtSqlPass.Text = DTOdbContext.Password;
            }
        }

        #region Configuracion del servidor
        void rdDeshabilitar(object sender, EventArgs e)
        {
            if (ObjConexion.rdDeshabilitarWindows.Checked == true)
            {
                ObjConexion.txtSqlAuth.Enabled = false;
                ObjConexion.txtSqlPass.Enabled = false;
            }
        }

        void rdHabilitar(object sender, EventArgs e)
        {
            if (ObjConexion.rdHabilitarWindows.Checked == true)
            {
                ObjConexion.txtSqlAuth.Enabled = true;
                ObjConexion.txtSqlPass.Enabled = true;
                ObjConexion.txtSqlAuth.Clear();
                ObjConexion.txtSqlPass.Clear();
            }
        }

        void Guardar(object sender, EventArgs e)
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

                XmlElement servidor = doc.CreateElement("Server");
                string servidorCode = CodificarBase64String(ObjConexion.txtServer.Text.Trim());

                servidor.InnerText = servidorCode;
                root.AppendChild(servidor);

                XmlElement Database = doc.CreateElement("Database");
                string DatabaseCode = CodificarBase64String(ObjConexion.txtDataBase.Text.Trim());
                Database.InnerText = DatabaseCode;
                root.AppendChild(Database);

                if (ObjConexion.rdDeshabilitarWindows.Checked == true)
                {
                    XmlElement SqlAuth = doc.CreateElement("SqlAuth");
                    string sqlAuthCode = CodificarBase64String(ObjConexion.txtSqlAuth.Text.Trim());
                    SqlAuth.InnerText = sqlAuthCode;
                    root.AppendChild(SqlAuth);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        public string CodificarBase64String(string textocifrado)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(textocifrado);
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