using Login_Farmacia.Controlador.Empleados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia.Formularios.Empleados
{
    public partial class FrmAgregarEmpleado : Form
    {
        public FrmAgregarEmpleado()
        {
            InitializeComponent();
            ControllerAgregar open = new ControllerAgregar(this);
        }

        private void FrmAgregarEmpleado_Load(object sender, EventArgs e)
        {

        }
    }
}
