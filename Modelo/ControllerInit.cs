using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Login_Farmacia.Clase;
using Login_Farmacia.Formularios;
using Login_Farmacia.Formularios.Recuperarcontra;
using Login_Farmacia.Modelo.DAO;

namespace Login_Farmacia.Modelo
{
    internal class ControllerInit
    {
        public static void DterminarVistaInicial()
        {
            XMLDocument Objdocument = new XMLDocument();
            Objdocument.LeerArchivoXMLConexion();

            DAOLogin daofirst = new DAOLogin();
            bool primerusuario = daofirst.VerUsuarioAdmin();

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
