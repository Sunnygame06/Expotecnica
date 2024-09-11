using Login_Farmacia.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia.Formularios
{
    public partial class FrmActualizar : Form
    {
       public FrmActualizar(int Id, string Nombre, string Direccion, string Telefono)
       {
            InitializeComponent();
            ControllerActualizar objControl = new ControllerActualizar(this, Id, Nombre, Direccion, Telefono);
       }
    }
}
