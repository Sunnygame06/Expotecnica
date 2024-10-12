using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login_Farmacia.Formularios;
using Login_Farmacia.Formularios.Empleados;
using Login_Farmacia.Formularios.Inicio;
using Login_Farmacia.Formularios.Producto;
using Login_Farmacia.Formularios.Proveedor;

namespace Login_Farmacia.Controlador
{
    internal class ControllerInicio
    {
        FrmIniciar ObjInicio;
        Form currentForm = null;

        public ControllerInicio(FrmIniciar Vista)
        {
            ObjInicio = Vista;
            //ObjInicio.Load += new EventHandler(Inicio);
            ObjInicio.btnCerrarSesion.Click += new EventHandler(Cerrar);
            ObjInicio.btnClientes.Click += new EventHandler(Clientes);
            ObjInicio.btnProveedor.Click += new EventHandler(Proveedor);
            ObjInicio.btnEmpleado.Click += new EventHandler(Empleado);
            ObjInicio.btnProducto.Click += new EventHandler(Producto);
            ObjInicio.btnFactura.Click += new EventHandler(Factura);
            //ObjInicio.btnLogo.Click += new EventHandler(Logo);
        }

        public void Cerrar(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Estas seguro de cerrar sesion temporalmente?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Frmlogin Login = new Frmlogin();
                Login.Show();
                ObjInicio.Hide();
            }
        }

        public void Clientes(object sender, EventArgs e)
        {
            AbrirFormulario<Frmshowusers>();
        }

        public void Proveedor(object sender, EventArgs e)
        {
            AbrirFormulario<FrmProveedor>();
        }

        public void Empleado(object sender, EventArgs e)
        {
            AbrirFormulario<FrmEmpleado>();
        }

        public void Producto(object sender, EventArgs e)
        {
            AbrirFormulario<FrmProducto>();
        }

        public void Factura(object sender, EventArgs e)
        {
            AbrirFormulario<FrmFactura>();
        }

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            //Se declara objeto de tipo Form llamada formulario
            Form formulario;
            //Se guarda en el panel contenedor del formulario principal todos los controles del formulario que desea abrir <MiForm> posteriormente se guarda todo en el objeto de tipo formulario
            formulario = ObjInicio.PanelContenedor.Controls.OfType<MiForm>().FirstOrDefault();
            //Si el formulario no existe se procederá a crearlo de lo contrario solo se traerá al frente (ver clausula else)
            if (formulario == null)
            {
                //Se define un nuevo formulario para guardarse como nuevo objeto MiForm
                formulario = new MiForm();
                //Se especifica que el formulario debe mostrarse como ventana
                formulario.TopLevel = false;
                //Se eliminan los bordes del formulario
                formulario.FormBorderStyle = FormBorderStyle.None;
                //Se establece que se abrira en todo el espacio del formulario padre
                formulario.Dock = DockStyle.Fill;
                //Se le asigna una opacidad de 0.75
                formulario.Opacity = 0.75;
                //Se evalua el formulario actual para verificar si es nulo
                if (currentForm != null)
                {
                    //Se cierra el formulario actual para mostrar el nuevo formulario
                    currentForm.Close();
                    //Se eliminan del panel contenedor todos los controles del formulario que se cerrará
                    ObjInicio.PanelContenedor.Controls.Remove(currentForm);
                }
                //Se establece como nuevo formulario actual el formulario que se está abriendo
                currentForm = formulario;
                //Se agregan los controles del nuevo formulario al panel contenedor
                ObjInicio.PanelContenedor.Controls.Add(formulario);
                //Tag es una propiedad genérica disponible para la mayoría de los controles en aplicaciones .NET, incluyendo los paneles.
                ObjInicio.PanelContenedor.Tag = formulario;
                //Se muestra el formulario en el panel contenedor
                formulario.Show();
                //Se trae al frente el formulario armado
                formulario.BringToFront();
            }
            else
            {
                formulario.BringToFront();
            }
        }

        //private void CerrarForm(object sender, EventArgs e)
        //{
        //    if (currentForm != null)
        //    {
                //Se cierra el formulario actual para mostrar el nuevo formulario
                //currentForm.Close();
                //Se eliminan del panel contenedor todos los controles del formulario que se cerrará
                //ObjInicio.PanelContenedor.Controls.Remove(currentForm);
        //    }
        //}

    }
}
