using Login_Farmacia.Formularios.Recuperarcontra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Login_Farmacia.Formularios;
using Login_Farmacia.Modelo.DAO;
using System.Security.Cryptography.X509Certificates;

namespace Login_Farmacia.Controlador.Recuperarcontra
{
    internal class ControllerRecuperarcontraporadmin
    {
        FrmRecuperarcontraporadmin ObjAdmin;

        public ControllerRecuperarcontraporadmin(FrmRecuperarcontraporadmin Vista)
        {
            ObjAdmin = Vista;
            ObjAdmin.Load += new EventHandler(Cargar);
            ObjAdmin.btnListo.Click += new EventHandler(Listo);
            ObjAdmin.checknewpass.CheckedChanged += new EventHandler(Ocultarpass);
            ObjAdmin.checkverificar.CheckedChanged += new EventHandler(Ocultarnewpass);
        }

        public void Cargar(object sender, EventArgs e)
        {
            if (ObjAdmin.checknewpass.Checked == true)
            {
                ObjAdmin.txtnewpass.UseSystemPasswordChar = false;
            }
            else
            {
                ObjAdmin.txtnewpass.UseSystemPasswordChar = true;
            }

            if (ObjAdmin.checkverificar.Checked == true)
            {
                ObjAdmin.txtverificar.UseSystemPasswordChar = false;
            }
            else
            {
                ObjAdmin.txtverificar.UseSystemPasswordChar = true;
            }
        }

        public void Listo(object sender, EventArgs e)
        {
            if (ObjAdmin.txtuser.Text == "" || ObjAdmin.txtnewpass.Text == "" || ObjAdmin.txtverificar.Text == "")
            {
                MessageBox.Show("Algunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                DAOLogin daoUpdate = new DAOLogin();
                daoUpdate.Password1 = Encriptar.Encriptacion(ObjAdmin.txtnewpass.Text);
                daoUpdate.Username1 = ObjAdmin.txtuser.Text;

                int respuesta = daoUpdate.CambiarContra();

                if (ObjAdmin.txtnewpass.Text == ObjAdmin.txtverificar.Text)
                {
                    if (respuesta == 1)
                    {
                        MessageBox.Show("La contraseña ha sido actualizada correctamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Refrescar();
                    }
                    else
                    {
                        MessageBox.Show("Hubo error al actualizar la contraseña", "Accion interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Hubo error al actualizar la contraseña", "Accion interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Ocultarpass(object sender, EventArgs e)
        {
            if (ObjAdmin.checknewpass.Checked == true)
            {
                ObjAdmin.txtnewpass.UseSystemPasswordChar = false;
            }
            else
            {
                ObjAdmin.txtnewpass.UseSystemPasswordChar = true;
            }
        }

        public void Ocultarnewpass(object sender, EventArgs e)
        {
            if (ObjAdmin.checkverificar.Checked == true)
            {
                ObjAdmin.txtverificar.UseSystemPasswordChar = false;
            }
            else
            {
                ObjAdmin.txtverificar.UseSystemPasswordChar = true;
            }
        }

        public void Refrescar()
        {
            ObjAdmin.txtuser.Text = "";
            ObjAdmin.txtnewpass.Text = "";
            ObjAdmin.txtverificar.Text = "";
        }
    }
}
