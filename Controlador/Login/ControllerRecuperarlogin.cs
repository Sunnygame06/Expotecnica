using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login_Farmacia.Formularios;
using System.Data;
using Login_Farmacia.Modelo.DAO;
using Login_Farmacia.Formularios.Recuperarcontra;

namespace Login_Farmacia.Controlador
{
    internal class ControllerRecuperarlogin
    {
        FrmRecuperarlogin Objrecuperar;

        public ControllerRecuperarlogin(FrmRecuperarlogin Vista)
        {
            Objrecuperar = Vista;
            Objrecuperar.Load += new EventHandler(Refrescar);
            Objrecuperar.checkpass.CheckedChanged += new EventHandler(Ocultar);
            Objrecuperar.btnEnviar.Click += new EventHandler(Mensaje);
        }

        public void Refrescar(object sender, EventArgs e)
        {
            if (Objrecuperar.checkpass.Checked == true)
            {
                Objrecuperar.txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                Objrecuperar.txtPass.UseSystemPasswordChar = true;
            }
        }

        public void Ocultar(object sender, EventArgs e)
        {
            if (Objrecuperar.checkpass.Checked == true)
            {
                Objrecuperar.txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                Objrecuperar.txtPass.UseSystemPasswordChar = true;
            }
        }

        private void Mensaje(object sender, EventArgs e)
        {
            if (Objrecuperar.txtuser.Text == "" || Objrecuperar.txtPass.Text == "")
            {
                MessageBox.Show("EC02-Algunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAOLogin DAOData = new DAOLogin();
                DAOData.Username1 = Objrecuperar.txtuser.Text;
                DAOData.Password1 = Encriptar.Encriptacion(Objrecuperar.txtPass.Text);

                bool respuesta = DAOData.LoginAdmin();
                if (respuesta == true)
                {
                    MessageBox.Show("Los datos ingresados son correctos", "Datos correctos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmRecuperarcontraporadmin ObjControl = new FrmRecuperarcontraporadmin();
                    ObjControl.Show();
                    Objrecuperar.Hide();
                }
                else
                {
                    MessageBox.Show("EC03-Los datos ingresados son incorrectos o el usuario es inexistente", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
