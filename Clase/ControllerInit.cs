using Login_Farmacia.Formularios;
using Login_Farmacia.Modelo.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia.Clase
{
    internal class ControllerInit
    {
        public static void DeterminarVistaInicial()
        {
            XMLDocument objDocument = new XMLDocument();
            objDocument.LeerArchivoXMLConexion();
            DAOLogin ObjLogin = new DAOLogin();
            bool primerusuario = ObjLogin.VerUsuarioAdmin();
            if (primerusuario == false)
            {
                Application.Run(new FrmRegistrarse());
            }
            else
            {
                Application.Run(new Frmlogin());
            }
        }
    }
}
