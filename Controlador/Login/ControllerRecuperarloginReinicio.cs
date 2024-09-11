using Login_Farmacia.Formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login_Farmacia.Modelo.DAO;
using System.Data;
using Login_Farmacia.Formularios.Login;
using Login_Farmacia.Formularios.Recuperarcontra;

namespace Login_Farmacia.Controlador.Login
{
    internal class ControllerRecuperarloginReinicio
    {
        FrmRecuperarloginReinicio ObjReinicio;

        public ControllerRecuperarloginReinicio(FrmRecuperarloginReinicio Vista)
        {
            ObjReinicio = Vista;
            ObjReinicio.Load += new EventHandler(Iniciar);
            ObjReinicio.btnReinicio.Click += new EventHandler(Reinicio);
            ObjReinicio.checkpass.CheckedChanged += new EventHandler(Ocultar);
        }

        public void Iniciar(object sender, EventArgs e)
        {
            if (ObjReinicio.checkpass.Checked == true)
            {
                ObjReinicio.txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                ObjReinicio.txtPass.UseSystemPasswordChar = true;
            }
        }

        public void Reinicio(object sender, EventArgs e)
        {
            DAOLogin DAOData = new DAOLogin();
            DAOData.Username1 = ObjReinicio.txtUser.Text;
            DAOData.Password1 = Encriptar.Encriptacion(ObjReinicio.txtPass.Text);

            bool respuesta = DAOData.LoginAdmin();
            if (ObjReinicio.txtUser.Text == "" || ObjReinicio.txtPass.Text == "")
            {
                MessageBox.Show("EC02-Algun campo no ha sido ingresado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (respuesta == true)
                {
                    MessageBox.Show("Los datos son correctos", "Datos correctos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmReinicio open = new FrmReinicio();
                    open.Show();
                    ObjReinicio.Hide();
                }
                else
                {
                    MessageBox.Show("Los datos son incorrectos", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Ocultar(object sender, EventArgs e)
        {
            if (ObjReinicio.checkpass.Checked == true)
            {
                ObjReinicio.txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                ObjReinicio.txtPass.UseSystemPasswordChar = true;
            }
        }
    }
}
