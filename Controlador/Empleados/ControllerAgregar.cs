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
    internal class ControllerAgregar
    {
        FrmAgregarEmpleado objAgregar;
        public ControllerAgregar(FrmAgregarEmpleado vista)
        {
            objAgregar = vista;
            objAgregar.Load += new EventHandler(Refrescar);
            objAgregar.btnAgregar2.Click += new EventHandler(Agregar);
        } 

        public void Refrescar(object sender, EventArgs e)
        {
            DAOempleados daoCombo = new DAOempleados();
            DataSet ds = daoCombo.Llenarcombobox();

            objAgregar.cmbUser.DataSource = ds.Tables["Personas"];
            objAgregar.cmbUser.DisplayMember = "Usernames";
            objAgregar.cmbUser.ValueMember = "idUser";
        }

        public void Agregar(object sender, EventArgs e)
        {
            if (objAgregar.txtNombreEmpleado.Text == "" || objAgregar.txtEstadoCivil.Text == "" || objAgregar.txtTelefono.Text == "" || objAgregar.cmbUser.Text == "")
            {
                MessageBox.Show("EC02-Algunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAOempleados daoAgregar = new DAOempleados();
                daoAgregar.Nombre = objAgregar.txtNombreEmpleado.Text.Trim();
                daoAgregar.EstadoCivil = objAgregar.txtEstadoCivil.Text.Trim();
                daoAgregar.Telefono = objAgregar.txtTelefono.Text.Trim();
                daoAgregar.Dui = objAgregar.mskDui.Text.Trim();
                daoAgregar.FechaNacimiento = objAgregar.dtpFechaNacimiento.Value.Date;
                daoAgregar.IdUser = int.Parse(objAgregar.cmbUser.SelectedValue.ToString());
                int retorno = daoAgregar.IngresarEmpleado();
                if (retorno == 1)
                {
                    MessageBox.Show("Datos ingresados correctamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("Hubo error al ingresar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
