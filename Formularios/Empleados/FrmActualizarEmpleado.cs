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
    public partial class FrmActualizarEmpleado : Form
    {
        public FrmActualizarEmpleado(int id, string Nombre, string DUI, string Telefono, string EstadoCivil, DateTime FechadeNacimiento, int Usuario)
        {
            InitializeComponent();
            ControllerActualizarEmpleado ObjControl = new ControllerActualizarEmpleado(this, id, Nombre, DUI, Telefono, EstadoCivil, FechadeNacimiento, Usuario);
        }
    }
}
