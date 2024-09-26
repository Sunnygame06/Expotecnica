using Login_Farmacia.Formularios.Server;
using Login_Farmacia.Modelo.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia.Controlador.Servidor
{
    internal class ControllerAdminClave
    {
        FrmAdminClave ObjAdminClave;

        public ControllerAdminClave(FrmAdminClave Vista)
        {
            ObjAdminClave = Vista;
            ObjAdminClave.Load += new EventHandler(Iniciar);
            ObjAdminClave.btnConfirmar.Click += new EventHandler(Confirmar);
        }

        public void Iniciar(object sender, EventArgs e)
        {
            ObjAdminClave.txtClave.UseSystemPasswordChar = true;
        }

        public void Confirmar(object sender, EventArgs e) 
        { 
            if (ObjAdminClave.txtClave.Text == "")
            {
                MessageBox.Show("EC02-Algunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAOLogin login = new DAOLogin();
                login.Password1 = Encriptar.Encriptacion(ObjAdminClave.txtClave.Text);
                bool retorno = login.ContraAdmin();
                if (retorno == true)
                {
                    MessageBox.Show("Los datos son correctos", "Datos Correctos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmAdminConexion abrir = new FrmAdminConexion(2);
                    abrir.ShowDialog();
                    ObjAdminClave.Hide();
                }
                else
                {
                    MessageBox.Show("Los datos son incorrectos", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
