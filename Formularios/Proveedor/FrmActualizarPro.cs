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
    public partial class FrmActualizarPro : Form
    {
        public FrmActualizarPro(int id, string NombreE, string Contacto, string Direccion, string Email)
        {
            InitializeComponent();
            ControllerActualizarPro objControl = new ControllerActualizarPro(this, id, NombreE, Contacto, Direccion, Email);
            
        }
    }
}
