using Login_Farmacia.Formularios.Recuperarcontra;
using Login_Farmacia.Modelo.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia.Controlador.Recuperarcontra
{
    internal class ControllerActualizarReinicio
    {
        FrmActualizarReinicio ObjActualizarReinicio;
        private int id;

        public ControllerActualizarReinicio(FrmActualizarReinicio Vista, int id, string User, string Pass, string Rol)
        {
            ObjActualizarReinicio = Vista;
            this.id = id;
            ChargeValues(User, Pass, Rol);
            ObjActualizarReinicio.Load += new EventHandler(Refrescar);
            ObjActualizarReinicio.btnGuardar.Click += new EventHandler(Guardar);
            ObjActualizarReinicio.pictureBorrar.Click += new EventHandler(Borrar);
            
        }

        public void Refrescar(object sender, EventArgs e)
        {
            combobox();
            ObjActualizarReinicio.txtPass.Text = "";
        }

        public void Borrar(object sender, EventArgs e)
        {
            ObjActualizarReinicio.txtPass.Text = "";
        }

        public void combobox()
        {
            DAOLogin daoCombo = new DAOLogin();
            DataSet ds = daoCombo.VerRoles();

            ObjActualizarReinicio.cmbRol.DataSource = ds.Tables["Rol"];
            ObjActualizarReinicio.cmbRol.DisplayMember = "Rol";
            ObjActualizarReinicio.cmbRol.ValueMember = "idRol";
        }

        public void Guardar(object sender, EventArgs e)
        {
            if (ObjActualizarReinicio.txtUser.Text == "" || ObjActualizarReinicio.txtPass.Text == "" || ObjActualizarReinicio.cmbRol.Text == "")
            {
                MessageBox.Show("EC02-Algunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAOLogin daoActualizar = new DAOLogin();
                daoActualizar.Username1 = ObjActualizarReinicio.txtUser.Text.Trim();
                daoActualizar.Password1 = Encriptar.Encriptacion(ObjActualizarReinicio.txtPass.Text.Trim());
                daoActualizar.Rol1 = int.Parse(ObjActualizarReinicio.cmbRol.SelectedValue.ToString());
                daoActualizar.Id = id;

                int retorno = daoActualizar.CambiarContraReinicio();
                if (retorno == 1)
                {
                    MessageBox.Show("Los datos han sido actualizados correctamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ObjActualizarReinicio.Hide();
                }
                else
                {
                    MessageBox.Show("Hubo error al actualizar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ChargeValues(string User, string Pass, string Rol)
        {
            ObjActualizarReinicio.txtUser.Text = User;
            ObjActualizarReinicio.txtPass.Text = Pass;
            ObjActualizarReinicio.cmbRol.SelectedValue = Rol;
        }
    }
}
