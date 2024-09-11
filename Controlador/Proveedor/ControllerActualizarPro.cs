using Login_Farmacia.Formularios.Proveedor;
using Login_Farmacia.Modelo.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia.Controlador.Proveedor
{
    internal class ControllerActualizarPro
    {
        FrmActualizarPro ObjActualizarPro;
        private int Id;
        public ControllerActualizarPro(FrmActualizarPro Vista, int id, string NombreE, string Contacto, string Direccion, string Email)
        {
            ObjActualizarPro = Vista;
            this.Id = id;
            ChargeValues(NombreE, Contacto, Direccion, Email);
            ObjActualizarPro.btnGuardar.Click += new EventHandler(Actualizar);
        }

        public void Actualizar(object sender, EventArgs e)
        {
            if (ObjActualizarPro.txtnNombreEmpresa.Text == "" || ObjActualizarPro.txtnEmail.Text == "" || ObjActualizarPro.txtnDireccion.Text == "" || ObjActualizarPro.txtnContacto.Text == "")
            {
                MessageBox.Show("EC02-Algunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAOProveedores daoActualizar = new DAOProveedores();
                daoActualizar.NombreE = ObjActualizarPro.txtnNombreEmpresa.Text.Trim();
                daoActualizar.Contacto = ObjActualizarPro.txtnContacto.Text.Trim();
                daoActualizar.Direccion = ObjActualizarPro.txtnDireccion.Text.Trim();
                daoActualizar.Email = ObjActualizarPro.txtnEmail.Text.Trim();
                daoActualizar.IdProvedor = Id;
                int retorno = daoActualizar.ActualizarProveedor();

                if (retorno == 1)
                {
                    MessageBox.Show("Los datos han sido actualizados correctamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ObjActualizarPro.Hide();
                }
                else
                {
                    MessageBox.Show("Ha surgido un error al intentar actualizar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ChargeValues(string NombreE, string Contacto, string Direccion, string Email)
        {
            ObjActualizarPro.txtnNombreEmpresa.Text = NombreE;
            ObjActualizarPro.txtnContacto.Text = Contacto;
            ObjActualizarPro.txtnDireccion.Text = Direccion;
            ObjActualizarPro.txtnEmail.Text = Email;
        }
    }
}
