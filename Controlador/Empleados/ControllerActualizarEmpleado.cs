using Login_Farmacia.Formularios.Empleados;
using Login_Farmacia.Modelo.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia.Controlador.Empleados
{
    internal class ControllerActualizarEmpleado
    {
        FrmActualizarEmpleado ObjActualizarEmpleado;
        private int id;

        public ControllerActualizarEmpleado(FrmActualizarEmpleado Vista, int id, string Nombre, string DUI, string Telefono, string EstadoCivil, DateTime FechadeNacimiento, int Usuario)
        {
            ObjActualizarEmpleado = Vista;
            ObjActualizarEmpleado.Load += new EventHandler(Iniciar);
            this.id = id;
            ChargeValues(Nombre, DUI, Telefono, EstadoCivil, FechadeNacimiento, Usuario);
            ObjActualizarEmpleado.btnGuardar.Click += new EventHandler(Actualizar);
        }

        public void Iniciar(object sender, EventArgs e)
        {
            DAOempleados daoCombo = new DAOempleados();
            DataSet ds = daoCombo.VerUsuario();

            ObjActualizarEmpleado.cmbUsuario.DataSource = ds.Tables["Usuarios"];
            ObjActualizarEmpleado.cmbUsuario.DisplayMember = "Usernames";
            ObjActualizarEmpleado.cmbUsuario.ValueMember = "idUser";
        }

        public void Actualizar(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(ObjActualizarEmpleado.txtTelefono.Text, @"^\d+$"))
            {
                MessageBox.Show("No se permite agregar caracteres en el campo de telefono", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ObjActualizarEmpleado.txtTelefono.Text = "";
            }
            else
            {
                if (ObjActualizarEmpleado.txtDUI.Text == "" || ObjActualizarEmpleado.txtEstadoCivil.Text == "" || ObjActualizarEmpleado.txtNombre.Text == "" || ObjActualizarEmpleado.txtTelefono.Text == "" || ObjActualizarEmpleado.cmbUsuario.Text == "" || ObjActualizarEmpleado.DTFechadeNacimiento.Text == "")
                {
                    MessageBox.Show("EC02 - Algunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DAOempleados daoActualizar = new DAOempleados();
                    daoActualizar.Nombre = ObjActualizarEmpleado.txtNombre.Text.Trim();
                    daoActualizar.Dui = ObjActualizarEmpleado.txtDUI.Text.Trim();
                    daoActualizar.Telefono = ObjActualizarEmpleado.txtTelefono.Text.Trim();
                    daoActualizar.FechaNacimiento = ObjActualizarEmpleado.DTFechadeNacimiento.Value;
                    daoActualizar.EstadoCivil = ObjActualizarEmpleado.txtEstadoCivil.Text.Trim();
                    daoActualizar.IdUser = int.Parse(ObjActualizarEmpleado.cmbUsuario.SelectedValue.ToString());
                    daoActualizar.IdEmpleado = id;
                    int retorno = daoActualizar.ActualizarEmpleado();
                    if (retorno == 1)
                    {
                        MessageBox.Show("Los datos han sido actualizados correctamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Hubo error al actualizar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void ChargeValues(string Nombre, string DUI, string Telefono, string EstadoCivil, DateTime FechadeNacimiento, int Usuario)
        {
            ObjActualizarEmpleado.txtNombre.Text = Nombre;
            ObjActualizarEmpleado.txtDUI.Text = DUI;
            ObjActualizarEmpleado.txtEstadoCivil.Text = EstadoCivil;
            ObjActualizarEmpleado.txtTelefono.Text = Telefono;
            ObjActualizarEmpleado.cmbUsuario.SelectedValue = Usuario;
            ObjActualizarEmpleado.DTFechadeNacimiento.Value = FechadeNacimiento;
        }
    }
}
