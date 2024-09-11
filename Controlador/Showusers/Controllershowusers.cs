using Login_Farmacia.Formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login_Farmacia.Modelo.DAO;
using System.Data;

namespace Login_Farmacia.Controlador
{
    internal class Controllershowusers
    {
        Frmshowusers Objuser;

        public Controllershowusers(Frmshowusers vista)
        {
            Objuser = vista;
            Objuser.Load += new EventHandler(Refrescar);
            Objuser.btnAgregar.Click += new EventHandler(RegistrarUsuario);
            Objuser.btnActualizar.Click += new EventHandler(ActualizarUsuario);
            Objuser.btnEliminar.Click += new EventHandler(EliminarUsuario);
            Objuser.txtBuscar.KeyPress += new KeyPressEventHandler(Buscar);
            Objuser.btnAtras.Click += new EventHandler(Atras);
        }

        public void Refrescar(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }
        public void MostrarUsuarios()
        {
            DAOshowusers objAdmin = new DAOshowusers();
            DataSet ds = objAdmin.Verusers();
            Objuser.Listadeusuarios.DataSource = ds.Tables["Cliente"];
        }
        public void RegistrarUsuario(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(Objuser.txtTelefono.Text, @"^\d+$"))
            {
                MessageBox.Show("No se permite agregar caracteres en el campo de telefono", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Objuser.txtTelefono.Text = "";
            }
            else
            {
                if (Objuser.txtNombre.Text == "" || Objuser.txtDireccion.Text == "" || Objuser.txtTelefono.Text == "")
                {
                    MessageBox.Show("EC02-Algunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DAOshowusers daoInsertar = new DAOshowusers();
                    daoInsertar.Nombre = Objuser.txtNombre.Text;
                    daoInsertar.Direccion = Objuser.txtDireccion.Text;
                    daoInsertar.Numero = Objuser.txtTelefono.Text;
                    int retorno = daoInsertar.Ingresarusers();
                    if (retorno == 1)
                    {
                        MessageBox.Show("Datos ingresados correctamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarUsuarios();
                        Refrescar();
                    }
                    else
                    {
                        MessageBox.Show("Hubo error al ingresar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void ActualizarUsuario(object sender, EventArgs e)
        {
            int pos = Objuser.Listadeusuarios.CurrentRow.Index;
            int id;
            string Nombre, Direccion, Telefono;

            id = int.Parse(Objuser.Listadeusuarios[0, pos].Value.ToString());
            Nombre = Objuser.Listadeusuarios[1, pos].Value.ToString();
            Direccion = Objuser.Listadeusuarios[2, pos].Value.ToString();
            Telefono = Objuser.Listadeusuarios[3, pos].Value.ToString();

            FrmActualizar openForm = new FrmActualizar(id, Nombre, Direccion, Telefono);
            openForm.ShowDialog();
            MostrarUsuarios();
        }

        public void EliminarUsuario(object sender, EventArgs e)
        {
            int pos = Objuser.Listadeusuarios.CurrentRow.Index;
            if (MessageBox.Show($"Esta seguro de eliminar estos datos?", "Confirmacion", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                DAOshowusers daoEliminar = new DAOshowusers();
                daoEliminar.Id = int.Parse(Objuser.Listadeusuarios[0, pos].Value.ToString());
                int retorno = daoEliminar.Eliminarusers();
                if (retorno == 1)
                {
                    MessageBox.Show("Los datos se han eliminado exitosamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarUsuarios();
                }
                else
                {
                    MessageBox.Show("Ha surgido un error al eliminar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Buscar(object sender, EventArgs e)
        {
            DAOshowusers objBuscar = new DAOshowusers();
            DataSet ds = objBuscar.BuscarClientes(Objuser.txtBuscar.Text.Trim());
            Objuser.Listadeusuarios.DataSource = ds.Tables["Cliente"];
        }

        public void Refrescar()
        {
            Objuser.txtNombre.Text = "";
            Objuser.txtDireccion.Text = "";
            Objuser.txtTelefono.Text = "";
        }

        public void Atras(object sender, EventArgs e)
        {
            Frmusers ObjUsers = new Frmusers();
            ObjUsers.Show();
            Objuser.Hide();
        }
    }
}
