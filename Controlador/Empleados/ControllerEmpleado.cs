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
    internal class ControllerEmpleado
    {
        FrmEmpleado ObjEmpleado;

        public ControllerEmpleado(FrmEmpleado Vista)
        {
            ObjEmpleado = Vista;
            ObjEmpleado.Load += new EventHandler(Iniciar);
            ObjEmpleado.btnEliminar.Click += new EventHandler(Eliminar);
            ObjEmpleado.btnAgregar.Click += new EventHandler(abrir);
        }

        public void Iniciar(object sender, EventArgs e)
        {
            DAOempleados ObjAdmin = new DAOempleados();
            DataSet ds = ObjAdmin.VerEmpleados();
            ObjEmpleado.dgvempleados.DataSource = ds.Tables["Empleados"];
        }

        public void mostrarEmpleados()
        {
            DAOempleados ObjAdmin = new DAOempleados();
            DataSet ds = ObjAdmin.VerEmpleados();
            ObjEmpleado.dgvempleados.DataSource = ds.Tables["Empleados"];
        }
        public void Eliminar(object sender, EventArgs e)
        {
            int pos = ObjEmpleado.dgvempleados.CurrentRow.Index;
            if (MessageBox.Show($"Esta seguro de eliminar estos datos?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAOempleados daoEliminar = new DAOempleados();
                daoEliminar.IdEmpleado = int.Parse(ObjEmpleado.dgvempleados[0, pos].Value.ToString());
                int retorno = daoEliminar.EliminarEmpleado();
                if (retorno == 1)
                {
                    MessageBox.Show("Los datos se han eliminado exitosamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mostrarEmpleados();
                }
                else
                {
                    MessageBox.Show("Ha surgido un error al eliminar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
 
            }         
        }

        public void abrir(object sender, EventArgs e)
        {
            FrmAgregarEmpleado open = new FrmAgregarEmpleado();
            open.Show();
        }
    }
}

