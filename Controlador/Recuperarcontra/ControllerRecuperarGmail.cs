using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Login_Farmacia.Formularios;
using Login_Farmacia.Modelo.DAO;
using System.Net.Mail;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using Login_Farmacia.Controlador.Recuperarcontra;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Login_Farmacia.Controlador
{
    internal class ControllerRecuperarGmail
    {
        FrmRecuperarGmail ObjGmail;
        private static readonly HttpClient httpClient = new HttpClient();
        public ControllerRecuperarGmail(FrmRecuperarGmail Vista)
        {
            ObjGmail = Vista;
            ObjGmail.Load += new EventHandler(Iniciar);
            ObjGmail.btnEnviar.Click += new EventHandler(EnvioGmail);
            ObjGmail.txtcorreo.Enter += new EventHandler(CorreoE);
            ObjGmail.txtcorreo.Leave += new EventHandler(CorreoL);
            ObjGmail.picturetest.Click += new EventHandler(Conexion);
            ObjGmail.btnValidar.Click += new EventHandler(ComprobarE);
            
        }

        public void Iniciar(object sender, EventArgs e)
        {
            ObjGmail.txtpass.UseSystemPasswordChar = true;
            ObjGmail.txtverificar.UseSystemPasswordChar = true;
        }

        public void CorreoE(object sender, EventArgs e)
        {
            if (ObjGmail.txtcorreo.Text.Trim().Equals("*Este apartado es obligatorio*"))
            {
                ObjGmail.txtcorreo.Clear();
            }
        }

        public void CorreoL(object sender, EventArgs e)
        {
            if (ObjGmail.txtcorreo.Text.Trim().Equals(""))
            {
                ObjGmail.txtcorreo.Text = "*Este apartado es obligatorio*";
            }
        }

        public static bool ValidarEmail(string comprobarEmail)
        {
            string emailFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(comprobarEmail, emailFormato))
            {
                if (Regex.Replace(comprobarEmail, emailFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void ComprobarE(object sender, EventArgs e)
        {
            Comprobar();
        }

        public void Comprobar()
        {
            if (ValidarEmail(ObjGmail.txtcorreo.Text) == false)
            {
                MessageBox.Show("Dirrecion de correo Invalida", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Dirrecion de correo Valida", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void EnvioGmail(object sender, EventArgs e)
        {
            if (ValidarEmail(ObjGmail.txtcorreo.Text) == false)
            {
                MessageBox.Show("Dirrecion de correo Invalida", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ObjGmail.txtcorreo.Text = "";
            }
            else
            {
                if (ObjGmail.txtUser.Text == "" || ObjGmail.txtpass.Text == "" || ObjGmail.txtcorreo.Text == "" || ObjGmail.txtverificar.Text == "")
                {
                    MessageBox.Show("Algunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

                    mmsg.To.Add("20210133@ricaldone.edu.sv");
                    mmsg.Subject = "Cambiar Contraseña";
                    mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
                    mmsg.Bcc.Add(ObjGmail.txtcorreo.Text);


                    mmsg.Body = "Al usuario "  + ObjGmail.txtUser.Text + " se le ha actualizado la contraseña correctamente";
                    mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                    mmsg.IsBodyHtml = true;
                    mmsg.From = new System.Net.Mail.MailAddress(ObjGmail.txtcorreo.Text);

                    System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                    cliente.Credentials = new System.Net.NetworkCredential("20210133@ricaldone.edu.sv", "Yv2R7XfC");

                    cliente.Port = 587;
                    cliente.EnableSsl = true;

                    cliente.Host = "smtp.gmail.com";


                    try
                    {
                        if (ObjGmail.txtpass.Text == "" || ObjGmail.txtverificar.Text == "" || ObjGmail.txtUser.Text == "")
                        {
                            MessageBox.Show("No ha ingresado datos para el cambio de contraseña", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (ObjGmail.txtpass.Text == ObjGmail.txtverificar.Text)
                            {
                                DAOLogin Cambiar = new DAOLogin();
                                Cambiar.Username1 = ObjGmail.txtUser.Text;
                                Cambiar.Password1 = Encriptar.Encriptacion(ObjGmail.txtverificar.Text);
                                int retorno = Cambiar.CambiarContra();
                                if (retorno == 1)
                                {
                                    cliente.Send(mmsg);
                                    MessageBox.Show("Exito al enviar el correo. Ya esta actualizada tu contraseña", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ObjGmail.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Los datos ingresados no son correctos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al enviar", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public async void Conexion(object sender, EventArgs e)
        {
            bool conexion = await Probar();

            if (conexion)
            {
                MessageBox.Show("Conexion a internet disponible", "Conexion disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No hay conexion a Internet", "Conexion no disponible", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task<bool> Probar()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://www.google.com");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
            catch (TaskCanceledException)
            {
                return false;
            }
        }
    }
}

