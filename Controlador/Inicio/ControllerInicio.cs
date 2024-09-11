using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login_Farmacia.Formularios;
using Login_Farmacia.Formularios.Inicio;
using Login_Farmacia.Formularios.Proveedor;

namespace Login_Farmacia.Controlador
{
    internal class ControllerInicio
    {
        FrmIniciar ObjInicio;

        public ControllerInicio(FrmIniciar Vista)
        {
            ObjInicio = Vista;
            ObjInicio.Load += new EventHandler(Inicio);
            ObjInicio.btnCerrarSesion.Click += new EventHandler(Cerrar);
            ObjInicio.btnProveedor.Click += new EventHandler(Proveedor);
            ObjInicio.btnLogo.Click += new EventHandler(Logo);
        }

        public void Inicio(object sender, EventArgs e)
        {

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

        public void Logo(object sender, EventArgs e)
        {
            Frmusers open = new Frmusers();
            open.Show();
            ObjInicio.Hide();
        }

        public void Proveedor(object sender, EventArgs e)
        {
            FrmProveedor open = new FrmProveedor();
            open.Show();
            ObjInicio.Hide();
        }
    }
}
