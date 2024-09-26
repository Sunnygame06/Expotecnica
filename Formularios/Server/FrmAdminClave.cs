using Login_Farmacia.Controlador.Servidor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia.Formularios.Server
{
    public partial class FrmAdminClave : Form
    {
        public FrmAdminClave()
        {
            InitializeComponent();
            ControllerAdminClave ObjControl = new ControllerAdminClave(this);
        }
    }
}
