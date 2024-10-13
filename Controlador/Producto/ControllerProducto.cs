using Login_Farmacia.Formularios.Empleados;
using Login_Farmacia.Formularios.Producto;
using Login_Farmacia.Modelo.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia.Controlador.Producto
{
    internal class ControllerProducto
    {
        FrmProducto ObjProducto;

        public ControllerProducto(FrmProducto Vista)
        {
            ObjProducto = Vista;
            ObjProducto.Load += new EventHandler(Iniciar);
            ObjProducto.btnAgregar.Click += new EventHandler(Agregar);
            ObjProducto.btnActualizar.Click += new EventHandler(Actualizar);
            ObjProducto.btnEliminar.Click += new EventHandler(Eliminar);
            ObjProducto.txtBuscar.KeyPress += new KeyPressEventHandler(Buscar);
        }

        public void Iniciar(object sender, EventArgs e)
        {
            MostrarProducto();
        }

        public void MostrarProducto()
        {
            DAOProductos objAdmin = new DAOProductos();
            DataSet ds = objAdmin.VerProductos();
            ObjProducto.ListadeProductos.DataSource = ds.Tables["Producto"];

            DAOProductos daoCombo = new DAOProductos();
            DataSet DS = daoCombo.VerProveedores();

            ObjProducto.cmbProveedor.DataSource = DS.Tables["Proveedor"];
            ObjProducto.cmbProveedor.DisplayMember = "Nombre_Empresa";
            ObjProducto.cmbProveedor.ValueMember = "idProveedor";
        }

        public void Agregar(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(ObjProducto.txtStock.Text, @"^\d+$"))
            {
                MessageBox.Show("No se permite agregar caracteres en el campo de Stock", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ObjProducto.txtStock.Text = "";
            }
            else 
            {
                if (ObjProducto.txtnombre.Text == "" || ObjProducto.txtDescripcion.Text == "" || ObjProducto.txtPrecio.Text == "" || ObjProducto.txtStock.Text == "" || ObjProducto.DTFechadeVencimiento.Text == "" || ObjProducto.cmbProveedor.Text == "")
                {
                    MessageBox.Show("EC02 - Algunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DAOProductos daoAgregar = new DAOProductos();
                    daoAgregar.Nombre = ObjProducto.txtnombre.Text.Trim();
                    daoAgregar.Descripcion = ObjProducto.txtDescripcion.Text.Trim();
                    daoAgregar.Precio = decimal.Parse(ObjProducto.txtPrecio.Text.Trim());
                    daoAgregar.FechadeVencimiento = ObjProducto.DTFechadeVencimiento.Value;
                    daoAgregar.Stock = int.Parse(ObjProducto.txtStock.Text.Trim());
                    daoAgregar.Proveedor = int.Parse(ObjProducto.cmbProveedor.SelectedValue.ToString());
                    int retorno = daoAgregar.IngresarProducto();
                    if (retorno == 1)
                    {
                        MessageBox.Show("Datos ingresados correctamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarProducto();
                        Refrescar();
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
            int pos = ObjProducto.ListadeProductos.CurrentRow.Index;
            int id, Stock ,Proveedor;
            decimal Precio;
            string Nombre, Descripcion;
            DateTime FechadeVencimiento;

            id = int.Parse(ObjProducto.ListadeProductos[0, pos].Value.ToString());
            Nombre = ObjProducto.ListadeProductos[1, pos].Value.ToString();
            Descripcion = ObjProducto.ListadeProductos[2, pos].Value.ToString();
            Precio = decimal.Parse(ObjProducto.ListadeProductos[3, pos].Value.ToString());
            FechadeVencimiento = DateTime.Parse(ObjProducto.ListadeProductos[4, pos].Value.ToString());
            Stock = int.Parse(ObjProducto.ListadeProductos[5, pos].Value.ToString());
            Proveedor = int.Parse(ObjProducto.ListadeProductos[6, pos].Value.ToString());

            FrmActualizarProducto open = new FrmActualizarProducto(id, Nombre, Descripcion, Precio, FechadeVencimiento, Stock, Proveedor);
            open.ShowDialog();
            MostrarProducto();
        }

        public void Eliminar(object sender, EventArgs e)
        {
            int pos = ObjProducto.ListadeProductos.CurrentRow.Index;
            if (MessageBox.Show($"Esta seguro de eliminar estos datos?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAOProductos daoEliminar = new DAOProductos();
                daoEliminar.IdProducto = int.Parse(ObjProducto.ListadeProductos[0, pos].Value.ToString());
                int retorno = daoEliminar.EliminarProducto();
                if (retorno == 1)
                {
                    MessageBox.Show("Los datos se han eliminado exitosamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarProducto();
                }
                else
                {
                    MessageBox.Show("Ha surgido un error al eliminar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Buscar(object sender, EventArgs e)
        {
            DAOProductos objBuscar = new DAOProductos();
            DataSet ds = objBuscar.BuscarProducto(ObjProducto.txtBuscar.Text.Trim());

            ObjProducto.ListadeProductos.DataSource = ds.Tables["Producto"];
        }

        public void Refrescar()
        {
            ObjProducto.txtnombre.Text = "";
            ObjProducto.txtDescripcion.Text = "";
            ObjProducto.txtPrecio.Text = "";
            ObjProducto.txtStock.Text = "";
        }
    }
}
