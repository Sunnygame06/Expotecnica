using Login_Farmacia.Controlador.Recuperarcontra.Gmail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia.Formularios.Recuperarcontra.Gmail
{
    public partial class FrmIngresarPin : Form
    {
        public FrmIngresarPin()
        {
            InitializeComponent();
            ControllerIngresarPIN ObjControl = new ControllerIngresarPIN(this);
        }
    }
}
