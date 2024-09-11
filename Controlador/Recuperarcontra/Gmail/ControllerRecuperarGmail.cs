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
using System.Security.Cryptography;
using Login_Farmacia.Formularios.Recuperarcontra.Gmail;

namespace Login_Farmacia.Controlador
{
    internal class ControllerRecuperarGmail
    {
        FrmRecuperarGmail ObjGmail;
        public ControllerRecuperarGmail(FrmRecuperarGmail Vista)
        {
            ObjGmail = Vista;
            ObjGmail.btnEnviar.Click += new EventHandler(EnvioGmail);
            
        }

        public void EnvioGmail(object sender, EventArgs e)
        {
            if (ObjGmail.txtCorreo.Text == "" || ObjGmail.txtUser.Text == "")
            {
                MessageBox.Show("EC-02 Algunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAOLogin daocorreo = new DAOLogin();
                daocorreo.Username1 = ObjGmail.txtUser.Text;
                daocorreo.Correo = ObjGmail.txtCorreo.Text;
                bool retorno = daocorreo.BuscarCorreo();
                if (retorno == true)
                {
                    MessageBox.Show("Se ha enviado el correo exitosamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string emailDestinatario = ObjGmail.txtCorreo.Text;
                    string pin = GenerarPin();
                    daocorreo.Pin = Encriptar.Encriptacion(pin);
                    string usuario = ObjGmail.txtUser.Text;
                    EnviarPinPorCorreo(emailDestinatario, pin, usuario);
                    bool respuesta = daocorreo.RegistrarPin();
                    if (respuesta == true)
                    {
                        MessageBox.Show("El PIN ha sido guardado exitosamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmIngresarPin open = new FrmIngresarPin();
                        open.Show();
                        ObjGmail.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hubo error al enviar el PIN", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Los datos son incorrectos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        string GenerarPin()
        {
            int longitud = 6;
            byte[] data = new byte[longitud / 2];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            string nex = BitConverter.ToString(data);
            return nex.Replace("-", "").Substring(0, longitud);
        }

        bool EnviarPinPorCorreo(string emailDestinatario, string pin, string usuario)
        {
            string remitente = "20210133@ricaldone.edu.sv";
            string contraseña = "Yv2R7XfC";
            string servidorSMTP = "smtp.gmail.com";
            int puerto = 587;

            MailMessage mensaje = new MailMessage(remitente, emailDestinatario);
            mensaje.Subject = "🚨🚨 Restablecimiento de contraseña";
            mensaje.Body = $"Hola {usuario}.\n\nTu contraseña va hacer restablecida, por favor si desea cambiar su contraseña ingrese el siguiente PIN: *{pin}* ";

            SmtpClient clienteSMTP = new SmtpClient(servidorSMTP, puerto);
            clienteSMTP.Credentials = new NetworkCredential(remitente, contraseña);
            clienteSMTP.EnableSsl = true;

            try
            {
                clienteSMTP.Send(mensaje);
                return true;
            }
            catch (SmtpException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}

