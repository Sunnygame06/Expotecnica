using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login_Farmacia.Modelo.DAO;
using System.Windows.Forms;
using Login_Farmacia.Formularios;
using Login_Farmacia.Modelo;
using System.IO;
using System.Security.Cryptography;
using Login_Farmacia.Formularios.Server;

namespace Login_Farmacia
{
    public class ControllerLogin
    {
        Frmlogin ObjLogin;
        int intentos;

        public ControllerLogin(Frmlogin Vista)
        {
            ObjLogin = Vista;
            ObjLogin.PBoxWifi.Click += new EventHandler(Prueba);
            ObjLogin.btnlogin.Click += new EventHandler(Acceso);
            ObjLogin.btnCerrar.Click += new EventHandler(Cerrar);
            ObjLogin.Load += new EventHandler(Iniciar);
            ObjLogin.txtUser.Enter += new EventHandler(EnterUser);
            ObjLogin.txtUser.Leave += new EventHandler(LeaveUser);
            ObjLogin.txtPass.Enter += new EventHandler(EnterPass);
            ObjLogin.txtPass.Leave += new EventHandler(LeavePass);
            ObjLogin.btnregistrarse.Click += new EventHandler(Registrarse);
            ObjLogin.btnlogo.Click += new EventHandler(History);
            ObjLogin.checkpass.CheckedChanged += new EventHandler(OcultarPass);
            ObjLogin.lblrecuperar.Click += new EventHandler(Mensaje);
            ObjLogin.Candado.Click += new EventHandler(Candado);
        }

        public void Prueba(object sender, EventArgs e)
        {
            if (dbContext.GetConnection() == null)
            {
                MessageBox.Show("EC01-No fue posible conectarse a la base de datos", "Conexion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("La base de datos esta conectada", "Conexion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Iniciar(object sender, EventArgs e)
        {
            if (ObjLogin.txtPass.Text.Trim().Equals(""))
            {
                ObjLogin.txtPass.Text = "Contraseña";
            }

            if (ObjLogin.checkpass.Checked == true)
            {
                ObjLogin.txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                ObjLogin.txtPass.UseSystemPasswordChar = true;
            }
        }
        private void Acceso(object sender, EventArgs e)
        {
            if (ObjLogin.txtUser.Text == "Usuario" || ObjLogin.txtPass.Text == "Contraseña")
            {
                MessageBox.Show("EC02-Algunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAOLogin DAOData = new DAOLogin();
                DAOData.Username1 = ObjLogin.txtUser.Text;
                DAOData.Password1 = Encriptar.Encriptacion(ObjLogin.txtPass.Text);
                bool respuesta = DAOData.Login();

                if (respuesta == true)
                {
                    MessageBox.Show("Los datos ingresados son correctos", "Datos correctos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Frmusers Frmusers = new Frmusers();
                    Frmusers.Show();
                    ObjLogin.Hide();
                }
                else
                {
                    if (intentos == 3)
                    {
                        MessageBox.Show("El numero de intentos ha alcanzado el limite", "Intentar mas tarde", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Los datos ingresados son incorrectos o el usuario es inexistente", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        intentos++;
                    }
                }
            }
        }

        private void EnterUser(object sender, EventArgs e)
        {
            if (ObjLogin.txtUser.Text.Trim().Equals("Usuario")) 
            {
                ObjLogin.txtUser.Clear();
                ObjLogin.lblUser.Visible = true;
            }
        }

        private void LeaveUser(object sender, EventArgs e)
        {
            if (ObjLogin.txtUser.Text.Trim().Equals(""))
            {
                ObjLogin.txtUser.Text = "Usuario";
                ObjLogin.lblUser.Visible = false;
            }
        }

        private void EnterPass(object sender, EventArgs e)
        {
            if (ObjLogin.txtPass.Text.Trim().Equals("Contraseña"))
            {
                ObjLogin.txtPass.Clear();
                ObjLogin.lblPass.Visible = true;
            }
        }

        private void LeavePass(object sender, EventArgs e)
        {
            if (ObjLogin.txtPass.Text.Trim().Equals(""))
            {
                ObjLogin.txtPass.Text = "Contraseña";
                ObjLogin.lblPass.Visible = false;
            }
            
        }

        private void OcultarPass(object sender, EventArgs e) 
        {
            if (ObjLogin.checkpass.Checked == true)
            {
                ObjLogin.txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                ObjLogin.txtPass.UseSystemPasswordChar = true;
            }
        }
        private void Registrarse(object sender, EventArgs e)
        {
            FrmRegistrarse registrarse = new FrmRegistrarse();
            registrarse.Show();
        }

        private void Cerrar(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void History(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://sites.google.com/ricaldone.edu.sv/farmacia-higia/historia");
        }

        private void Mensaje(object sender, EventArgs e)
        {
            FrmRecuperarcontra Recuperarcontra = new FrmRecuperarcontra();
            Recuperarcontra.Show();
        }

        public void Candado(object sender, EventArgs e)
        {
            FrmAdminClave open = new FrmAdminClave();
            open.Show();
        }
    }
}
