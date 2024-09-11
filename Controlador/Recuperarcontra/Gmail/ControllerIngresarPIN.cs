using Login_Farmacia.Formularios.Recuperarcontra;
using Login_Farmacia.Formularios.Recuperarcontra.Gmail;
using Login_Farmacia.Modelo.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia.Controlador.Recuperarcontra.Gmail
{
    internal class ControllerIngresarPIN
    {
        FrmIngresarPin ObjPin;

        public ControllerIngresarPIN(FrmIngresarPin Vista)
        {
            ObjPin = Vista;
            ObjPin.btnCambiar.Click += new EventHandler(Cambiar);
        }

        public void Cambiar(object sender, EventArgs e)
        {
            try
            {
                if (ObjPin.txtUser.Text == "" || ObjPin.txtPIN.Text == "")
                {
                    MessageBox.Show("EC-02 Algunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DAOLogin daoPIN = new DAOLogin();
                    daoPIN.Pin = Encriptar.Encriptacion(ObjPin.txtPIN.Text);
                    daoPIN.Username1 = ObjPin.txtUser.Text;
                    bool retorno = daoPIN.BuscarPin();
                    if (retorno == true)
                    {
                        MessageBox.Show("Los datos son correctos", "Datos Correctos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmRecuperarcontraporadmin open = new FrmRecuperarcontraporadmin();
                        open.Show();
                        ObjPin.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Los Datos son incorrectos", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
