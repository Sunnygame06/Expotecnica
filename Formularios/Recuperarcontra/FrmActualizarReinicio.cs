using Login_Farmacia.Controlador.Recuperarcontra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia.Formularios.Recuperarcontra
{
    public partial class FrmActualizarReinicio : Form
    {
        public FrmActualizarReinicio(int id, string User, string Pass, string Rol)
        {
            InitializeComponent();
            ControllerActualizarReinicio objControl = new ControllerActualizarReinicio(this, id, User, Pass, Rol);
            
        }
    }
}
