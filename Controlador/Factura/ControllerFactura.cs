using Login_Farmacia.Formularios.Factura;
using Login_Farmacia.Formularios;
using Login_Farmacia.Modelo.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia.Controlador.Factura
{
    internal class ControllerFactura
    {
        FrmFactura Objfactura;

        public ControllerFactura(FrmFactura Vista)
        {
            Objfactura = Vista;
            Objfactura.Load += new EventHandler(Iniciar);
            Objfactura.btnRegistrar.Click += new EventHandler(Registrar);
            Objfactura.btnAgregar.Click += new EventHandler(Agregar);
            Objfactura.btnActualizar.Click += new EventHandler(Actualizar);
            Objfactura.btnEliminar.Click += new EventHandler(Eliminar);
            Objfactura.btnPagar.Click += new EventHandler(Pagar);
            Objfactura.txtBuscar.KeyPress += new KeyPressEventHandler(Buscar);
        }

        public void Iniciar(object sender, EventArgs e)
        {
            VerFactura();
            LlenarcomboEmpleado();
            LlenarcomboCliente();
        }

        public void VerFactura()
        {
            DAOFactura objAdmin = new DAOFactura();
            DataSet ds = objAdmin.Verfactura();
            Objfactura.ListaFactura.DataSource = ds.Tables["DetalleVenta"];
        }

        public void Pagar(object sender, EventArgs e)
        {
            DAOFactura ver = new DAOFactura();
            bool respuesta = ver.VerDetalleVenta();

            if (respuesta == true)
            {
                MessageBox.Show("El pago se ha realizado exitosamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DAOFactura daoEliminar = new DAOFactura();
                int retorno = daoEliminar.EliminarDetalleVenta();
                VerFactura();
            }
            else
            {
                MessageBox.Show("No ha ingresado ningun producto", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void mostrar()
        {
            DAOFactura objAdmin = new DAOFactura();
            DataSet ds = objAdmin.Verfactura();
            Objfactura.ListaFactura.DataSource = ds.Tables["DetalleVenta"];
        }

        public void LlenarcomboEmpleado()
        {
            DAOVenta daoCombo = new DAOVenta();
            DataSet ds = daoCombo.VerEmpleado();

            Objfactura.cmbEmpleado.DataSource = ds.Tables["VerEmpleados"];
            Objfactura.cmbEmpleado.DisplayMember = "Nombre";
            Objfactura.cmbEmpleado.ValueMember = "idEmpleados";
        }

        public void LlenarcomboCliente()
        {
            DAOVenta daoCombo = new DAOVenta();
            DataSet ds = daoCombo.VerCliente();

            Objfactura.cmbCliente.DataSource = ds.Tables["VerClientes"];
            Objfactura.cmbCliente.DisplayMember = "Nombre";
            Objfactura.cmbCliente.ValueMember = "idCliente";
        }

        public void Registrar(object sender, EventArgs e)
        {
            if (Objfactura.cmbCliente.Text == "" || Objfactura.cmbEmpleado.Text == "")
            {
                MessageBox.Show("Algunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    DateTime time = DateTime.Now;
                    DateTime date = DateTime.Now;

                    DAOVenta daoventa = new DAOVenta();
                    daoventa.IdCliente = int.Parse(Objfactura.cmbCliente.SelectedValue.ToString());
                    daoventa.IdEmpleado = int.Parse(Objfactura.cmbEmpleado.SelectedValue.ToString());
                    daoventa.Hora = DateTime.Parse(time.ToShortTimeString());
                    daoventa.Fecha = DateTime.Parse(date.ToShortDateString());
                    int respuesta = daoventa.RegistrarVenta();
                    if (respuesta == 1)
                    {
                        MessageBox.Show("Los datos han sido ingresados correctamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Hubo error al ingresar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
            }
        }

        public void Agregar(object sender, EventArgs e)
        {
            FrmAgregarFactura abrir = new FrmAgregarFactura();
            abrir.ShowDialog();
            mostrar();
        }

        public void Actualizar(object sender, EventArgs e)
        {
            int pos = Objfactura.ListaFactura.CurrentRow.Index;
            int id;
            string Cantidad, Codigo, Venta;

            id = int.Parse(Objfactura.ListaFactura[0, pos].Value.ToString());
            Cantidad = Objfactura.ListaFactura[1, pos].Value.ToString();
            Codigo = Objfactura.ListaFactura[2, pos].Value.ToString();
            Venta = Objfactura.ListaFactura[3, pos].Value.ToString();

            FrmActualizarFactura openForm = new FrmActualizarFactura(id, Cantidad, Codigo, Venta);
            openForm.ShowDialog();
            mostrar();
        }

        public void Eliminar(object sender, EventArgs e)
        {
            int pos = Objfactura.ListaFactura.CurrentRow.Index;
            if (MessageBox.Show($"Esta seguro de eliminar estos datos?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAOFactura daoEliminar = new DAOFactura();
                daoEliminar.IdDetalleVenta = int.Parse(Objfactura.ListaFactura[0, pos].Value.ToString());
                int retorno = daoEliminar.EliminarPro();
                if (retorno == 1)
                {
                    MessageBox.Show("Los datos se han eliminado exitosamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mostrar();
                }
                else
                {
                    MessageBox.Show("Ha surgido un error al eliminar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Buscar(object sender, EventArgs e)
        {
            DAOFactura objBuscar = new DAOFactura();
            DataSet ds = objBuscar.BuscarProductos(Objfactura.txtBuscar.Text.Trim());
            Objfactura.ListaFactura.DataSource = ds.Tables["DetalleVenta"];
        }
    }
}
