using Login_Farmacia.Formularios.Inicio;
using Login_Farmacia.Formularios.Proveedor;
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
    public partial class Frmusers : Form
    {
        public Frmusers()
        {
            InitializeComponent();
        }

        private void btningresarusers_Click(object sender, EventArgs e)
        {
            Frmshowusers mostrar = new Frmshowusers();
            mostrar.Show();
            this.Hide();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Frmlogin mostrar = new Frmlogin();
            mostrar.Show();
            this.Hide();
        }

        private void btncontinuar_Click(object sender, EventArgs e)
        {
            FrmIniciar mostrar = new FrmIniciar();
            mostrar.Show();
            this.Hide();
        }
    }
}
