using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login_Farmacia.Modelo.DAO;
using System.Windows.Forms;
using Login_Farmacia.Formularios;
using Login_Farmacia.Modelo;
using System.Data;

namespace Login_Farmacia.Controlador
{
    internal class ControllerActualizar
    {
        //Creamos una variable para el formulario FrmActualizar y otra variable para saber a que fila se le actualizaran los datos
        FrmActualizar ObjActualizar;
        private int Id;

        public ControllerActualizar(FrmActualizar Vista, int Id, string Nombre, string Direccion, string Telefono)
        {
            ObjActualizar = Vista;
            this.Id = Id;
            ChargeValues(Nombre, Direccion, Telefono);
            ObjActualizar.btnGuardar.Click += new EventHandler(Actualizar);
        }

        public void Actualizar(object sender, EventArgs e)
        {
            if (ObjActualizar.txtnuevoNumero.Text == "" || ObjActualizar.txtnuevoNombre.Text == "" || ObjActualizar.txtnuevaDirrecion.Text == "")
            {
                MessageBox.Show("EC02-Algunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAOshowusers daoActualizar = new DAOshowusers();
                daoActualizar.Nombre = ObjActualizar.txtnuevoNombre.Text.Trim();
                daoActualizar.Direccion = ObjActualizar.txtnuevaDirrecion.Text.Trim();
                daoActualizar.Numero = ObjActualizar.txtnuevoNumero.Text.Trim();
                daoActualizar.Id = Id;

                int retorno = daoActualizar.Actualizarusers();
                if (retorno == 1)
                {
                    MessageBox.Show("Los datos han sido actualizados correctamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ObjActualizar.Hide();
                }
                else
                {
                    MessageBox.Show("Ha surgido un error al intentar actualizar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ChargeValues(string Nombre, string Direccion, string Telefono)
        {
            ObjActualizar.txtnuevoNombre.Text = Nombre;
            ObjActualizar.txtnuevaDirrecion.Text = Direccion;
            ObjActualizar.txtnuevoNumero.Text = Telefono;
        }
    }
}
