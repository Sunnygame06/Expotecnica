using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        private void Frmlogin_Load(object sender, EventArgs e)
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 30, 30));
            btnlogin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnlogin.Width, btnlogin.Height, 30, 30));
            btnregistrarse.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnregistrarse.Width, btnregistrarse.Height, 30, 30));
            btnCerrar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnCerrar.Width, btnCerrar.Height, 30, 30));
            txtUser.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtUser.Width, txtUser.Height, 30, 30));
            txtPass.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtPass.Width, txtPass.Height, 30, 30));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
