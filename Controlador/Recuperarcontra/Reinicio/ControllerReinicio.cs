using Login_Farmacia.Formularios.Recuperarcontra;
using Login_Farmacia.Modelo.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Login_Farmacia.Controlador.Recuperarcontra
{
    internal class ControllerReinicio
    {
        FrmReinicio ObjReinicio;

        public ControllerReinicio(FrmReinicio Vista)
        {
            ObjReinicio = Vista;
            ObjReinicio.Load += new EventHandler(Refrescar);
            ObjReinicio.btnEliminar.Click += new EventHandler(Eliminar);
            ObjReinicio.btnActualizar.Click += new EventHandler(Actualizar);
            ObjReinicio.txtBuscar.KeyPress += new KeyPressEventHandler(Buscar);
        }

        public void Refrescar(object sender, EventArgs e)
        {
            Mostrar();
        }

        public void Mostrar()
        {
            DAOLogin ObjAdmin = new DAOLogin();
            DataSet ds = ObjAdmin.VerUsuario();
            ObjReinicio.ListadeUsuarios.DataSource = ds.Tables["VerUsuarios"];
        }

        public void Eliminar(object sender, EventArgs e)
        {
            int pos = ObjReinicio.ListadeUsuarios.CurrentRow.Index;
            if (MessageBox.Show($"Desea eliminar estos datos?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAOLogin daoEliminar = new DAOLogin();
                daoEliminar.Id = int.Parse(ObjReinicio.ListadeUsuarios[0, pos].Value.ToString());
                int retorno = daoEliminar.EliminarUsuario();

                if (retorno == 1)
                {
                    MessageBox.Show("Los datos han sido eliminados exitosamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Mostrar();
                }
                else
                {
                    MessageBox.Show("Hubo error al eliminar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Actualizar(object sender, EventArgs e)
        {
            int pos = ObjReinicio.ListadeUsuarios.CurrentRow.Index;
            int id;
            string User, Pass, Rol;

            id = int.Parse(ObjReinicio.ListadeUsuarios[0, pos].Value.ToString());
            User = ObjReinicio.ListadeUsuarios[1, pos].Value.ToString();
            Pass = ObjReinicio.ListadeUsuarios[2, pos].Value.ToString();
            Rol = ObjReinicio.ListadeUsuarios[3, pos].Value.ToString();

            FrmActualizarReinicio open = new FrmActualizarReinicio(id, User, Pass, Rol);
            open.ShowDialog();
            Mostrar();
        }

        public void Buscar(object sender, EventArgs e)
        {
            DAOLogin ObjBuscar = new DAOLogin();
            DataSet ds = ObjBuscar.BuscarUsuario(ObjReinicio.txtBuscar.Text.Trim());
            ObjReinicio.ListadeUsuarios.DataSource = ds.Tables["VerUsuarios"];
        }
    }
}
