using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login_Farmacia.Formularios;
using Login_Farmacia.Formularios.Producto;
using Login_Farmacia.Modelo.DAO;

namespace Login_Farmacia.Controlador.Producto
{
    internal class ControllerActualizarProducto
    {
        FrmActualizarProducto ObjProducto;
        private int Id;

        public ControllerActualizarProducto(FrmActualizarProducto Vista, int id, string Nombre, string Descripcion, decimal Precio, DateTime FechadeVencimiento, int Stock, int Proveedor)
        {
            ObjProducto = Vista;
            this.Id = id;
            ChargeValues(Nombre, Descripcion, Precio, FechadeVencimiento, Stock, Proveedor);
            ObjProducto.Load += new EventHandler(Iniciar);
            ObjProducto.btnGuardar.Click += new EventHandler(Guardar);
        }

        public void Iniciar(object sender, EventArgs e)
        {
            DAOProductos daoCombo = new DAOProductos();
            DataSet DS = daoCombo.VerProveedores();

            ObjProducto.cmbProveedor.DataSource = DS.Tables["Proveedor"];
            ObjProducto.cmbProveedor.DisplayMember = "Nombre_Empresa";
            ObjProducto.cmbProveedor.ValueMember = "idProveedor";
        }

        public void Guardar(object sender, EventArgs e)
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
                    daoAgregar.IdProducto = Id;
                    int retorno = daoAgregar.ActualizarProducto();
                    if (retorno == 1)
                    {
                        MessageBox.Show("Datos actualizados correctamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ObjProducto.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hubo error al actualizar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        public void ChargeValues(string Nombre, string Descripcion, decimal Precio, DateTime FechadeVencimiento, int Stock, int Proveedor)
        {
            ObjProducto.txtnombre.Text = Nombre;
            ObjProducto.txtDescripcion.Text = Descripcion;
            ObjProducto.txtPrecio.Text = Precio.ToString();
            ObjProducto.DTFechadeVencimiento.Value = FechadeVencimiento;
            ObjProducto.txtStock.Text = Stock.ToString();
            ObjProducto.cmbProveedor.SelectedValue = Proveedor;
        }
    }
}
