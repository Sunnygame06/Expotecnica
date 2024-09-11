using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia
{
    public partial class Frmlogin : Form
    {
        public Frmlogin()
        {
            InitializeComponent();
            ControllerLogin control = new ControllerLogin(this);
        }
    }
}
