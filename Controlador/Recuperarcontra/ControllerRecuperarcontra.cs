using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Login_Farmacia.Formularios;
using Login_Farmacia.Modelo.DAO;
using Login_Farmacia.Formularios.Recuperarcontra;
using Login_Farmacia.Formularios.Login;

namespace Login_Farmacia.Controlador
{
    internal class ControllerRecuperarcontra
    {
        FrmRecuperarcontra ObjRecuperarcontra;

        public ControllerRecuperarcontra(FrmRecuperarcontra Vista)
        {
            ObjRecuperarcontra = Vista;
            ObjRecuperarcontra.btnApp.Click += new EventHandler(Admin);
            ObjRecuperarcontra.btnCorreo.Click += new EventHandler(Gmail);
            ObjRecuperarcontra.btnPregunta.Click += new EventHandler(Pregunta);
            ObjRecuperarcontra.btnReinicio.Click += new EventHandler(Reinicio);
        }

        public void Admin(object sender, EventArgs e)
        {
            FrmRecuperarlogin Recuperar = new FrmRecuperarlogin();
            Recuperar.Show();
            ObjRecuperarcontra.Hide();
        }

        public void Gmail(object sender, EventArgs e)
        {
            FrmRecuperarGmail Recuperar = new FrmRecuperarGmail();
            Recuperar.Show();
            ObjRecuperarcontra.Hide();
        }

        public void Pregunta(object sender, EventArgs e)
        {
            FrmRecuperarporPregunta Recuperar = new FrmRecuperarporPregunta();
            Recuperar.Show();
            ObjRecuperarcontra.Hide();
        }

        public void Reinicio(object sender, EventArgs e)
        {
            FrmRecuperarloginReinicio Recuperar = new FrmRecuperarloginReinicio();
            Recuperar.Show();
            ObjRecuperarcontra.Hide();
        }
    }

}
