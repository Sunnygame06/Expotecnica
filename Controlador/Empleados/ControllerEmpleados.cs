using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login_Farmacia.Formularios;
using Login_Farmacia.Formularios.Empleados;
using Login_Farmacia.Modelo.DAO;

namespace Login_Farmacia.Controlador.Empleados
{
    internal class ControllerEmpleados
    {
        FrmEmpleado ObjEmpleados;

        public ControllerEmpleados(FrmEmpleado Vista)
        {
            ObjEmpleados = Vista;
            ObjEmpleados.Load += new EventHandler(Iniciar);
            ObjEmpleados.btnAgregar.Click += new EventHandler(Agregar);
            ObjEmpleados.btnActualizar.Click += new EventHandler(Actualizar);
            ObjEmpleados.btnEliminar.Click += new EventHandler(Eliminar);
            ObjEmpleados.txtBuscar.KeyPress += new KeyPressEventHandler(Buscar);
            ObjEmpleados.btnlisto.Click += new EventHandler(listo);
        }

        public void Iniciar(object sender, EventArgs e)
        {
            ObjEmpleados.txtPass.UseSystemPasswordChar = true;

            MostrarEmpleados();

            DAOempleados daoCombo = new DAOempleados();
            DataSet ds = daoCombo.VerUsuario();

            ObjEmpleados.cmbUsuario.DataSource = ds.Tables["Usuarios"];
            ObjEmpleados.cmbUsuario.DisplayMember = "Usernames";
            ObjEmpleados.cmbUsuario.ValueMember = "idUser";
        }

        public void MostrarEmpleados()
        {
            DAOempleados objAdmin = new DAOempleados();
            DataSet ds = objAdmin.VerEmpleados();
            ObjEmpleados.listadeempleados.DataSource = ds.Tables["Empleados"];
        }

        public void listo(object sender, EventArgs e)
        {
            if (ObjEmpleados.txtPass.Text == "")
            {
                MessageBox.Show("EC-02 Algunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAOLogin daoAdmin = new DAOLogin();
                daoAdmin.Password1 = Encriptar.Encriptacion(ObjEmpleados.txtPass.Text);
                bool retorno = daoAdmin.ContraAdmin();
                if (retorno == true)
                {
                    MessageBox.Show("Los datos son correctos", "Datos Correctos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ObjEmpleados.lblContraseña.Visible = false;
                    ObjEmpleados.lblIntervencion.Visible = false;
                    ObjEmpleados.Candado.Visible = false;
                    ObjEmpleados.txtPass.Visible = false;
                    ObjEmpleados.panel2.Visible = false;
                    ObjEmpleados.btnlisto.Visible = false;
                }
                else
                {
                    MessageBox.Show("Los datos son incorrectos", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Agregar(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(ObjEmpleados.txtTelefono.Text, @"^\d+$"))
            {
                MessageBox.Show("No se permite agregar caracteres en el campo de telefono", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ObjEmpleados.txtTelefono.Text = "";
            }
            else 
            {
                if (ObjEmpleados.txtDUI.Text == "" || ObjEmpleados.txtEstadoCivil.Text == "" || ObjEmpleados.txtnombre.Text == "" || ObjEmpleados.txtTelefono.Text == "" || ObjEmpleados.cmbUsuario.Text == "" || ObjEmpleados.DTFechadenacimiento.Text == "")
                {
                    MessageBox.Show("EC02 - Algunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DAOempleados daoAgregar = new DAOempleados();
                    daoAgregar.Nombre = ObjEmpleados.txtnombre.Text.Trim();
                    daoAgregar.Telefono = ObjEmpleados.txtTelefono.Text.Trim();
                    daoAgregar.EstadoCivil = ObjEmpleados.txtEstadoCivil.Text.Trim();
                    daoAgregar.FechaNacimiento = ObjEmpleados.DTFechadenacimiento.Value;
                    daoAgregar.IdUser = int.Parse(ObjEmpleados.cmbUsuario.SelectedValue.ToString());
                    daoAgregar.Dui = ObjEmpleados.txtDUI.Text.Trim();
                    int retorno = daoAgregar.IngresarEmpleado();
                    if (retorno == 1)
                    {
                        MessageBox.Show("Datos ingresados correctamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarEmpleados();
                    }
                    else
                    {
                        MessageBox.Show("Hubo error al ingresar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void Actualizar(object sender, EventArgs e)
        {
            int pos = ObjEmpleados.listadeempleados.CurrentRow.Index;
            int id, Usuario;
            string Nombre, DUI, Telefono, EstadoCivil;
            DateTime FechadeNacimiento;

            id = int.Parse(ObjEmpleados.listadeempleados[0, pos].Value.ToString());
            Nombre = ObjEmpleados.listadeempleados[1, pos].Value.ToString();
            FechadeNacimiento = DateTime.Parse(ObjEmpleados.listadeempleados[2, pos].Value.ToString());
            EstadoCivil = ObjEmpleados.listadeempleados[3, pos].Value.ToString();
            DUI = ObjEmpleados.listadeempleados[4, pos].Value.ToString();
            Telefono = ObjEmpleados.listadeempleados[5, pos].Value.ToString();
            Usuario = int.Parse(ObjEmpleados.listadeempleados[6, pos].Value.ToString());

            FrmActualizarEmpleado open = new FrmActualizarEmpleado(id, Nombre, DUI, Telefono, EstadoCivil, FechadeNacimiento, Usuario);
            open.ShowDialog();
            MostrarEmpleados();
        }

        public void Eliminar(object sender, EventArgs e)
        {
            int pos = ObjEmpleados.listadeempleados.CurrentRow.Index;
            if (MessageBox.Show($"Esta seguro de eliminar estos datos?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAOempleados daoEliminar = new DAOempleados();
                daoEliminar.IdEmpleado = int.Parse(ObjEmpleados.listadeempleados[0, pos].Value.ToString());
                int retorno = daoEliminar.EliminarEmpleado();
                if (retorno == 1)
                {
                    MessageBox.Show("Los datos se han eliminado exitosamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarEmpleados();
                }
                else
                {
                    MessageBox.Show("Ha surgido un error al eliminar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Buscar(object sender, EventArgs e)
        {
            DAOempleados objBuscar = new DAOempleados();
            DataSet ds = objBuscar.BuscarEmpleado(ObjEmpleados.txtBuscar.Text.Trim());

            ObjEmpleados.listadeempleados.DataSource = ds.Tables["Empleados"];
        }
    }
}
