using Login_Farmacia.Controlador.Proveedor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia.Formularios.Proveedor
{
    public partial class FrmProveedor : Form
    {
        public FrmProveedor()
        {
            InitializeComponent();
            ControllerProveedor ObjControl = new ControllerProveedor(this);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
