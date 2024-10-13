using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login_Farmacia.Controlador.Producto;

namespace Login_Farmacia.Formularios.Producto
{
    public partial class FrmActualizarProducto : Form
    {
        public FrmActualizarProducto(int id, string Nombre, string Descripcion, decimal Precio, DateTime FechadeVencimiento, int Stock, int Proveedor)
        {
            InitializeComponent();
            ControllerActualizarProducto objControl = new ControllerActualizarProducto(this, id, Nombre, Descripcion, Precio, FechadeVencimiento, Stock, Proveedor);
        }
    }
}
