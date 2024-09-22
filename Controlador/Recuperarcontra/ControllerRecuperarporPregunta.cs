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

namespace Login_Farmacia.Controlador.Recuperarcontra
{
    internal class ControllerRecuperarporPregunta
    {
        FrmRecuperarporPregunta ObjPregunta;

        public ControllerRecuperarporPregunta(FrmRecuperarporPregunta Vista)
        {
            ObjPregunta = Vista;
            ObjPregunta.btnComprobar.Click += new EventHandler(Comprobar);
        }

        public void Comprobar(object sender, EventArgs e)
        {
            DAOPreguntas daoPreguntas = new DAOPreguntas();
            daoPreguntas.Nombre1 = ObjPregunta.txtNombre.Text;
            daoPreguntas.DUI1 = ObjPregunta.txtDUI.Text;
            daoPreguntas.Telefono1 = ObjPregunta.txtTelefono.Text;

            bool respuesta = daoPreguntas.Info();
            if (ObjPregunta.txtNombre.Text == "" || ObjPregunta.txtDUI.Text == "" || ObjPregunta.txtTelefono.Text == "")
            {
                MessageBox.Show("Algunos campos no han sido llenados", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (respuesta == true)
            {
                MessageBox.Show("Los datos ingresados son correctos", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Refrescar();
                FrmRecuperarcontraporadmin Recuperar = new FrmRecuperarcontraporadmin();
                Recuperar.Show();
                ObjPregunta.Hide();
            }
            else if (respuesta == false)
            {
                MessageBox.Show("Los datos ingresados son incorrectos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Refrescar()
        {
            ObjPregunta.txtDUI.Text = "";
            ObjPregunta.txtNombre.Text = "";
            ObjPregunta.txtTelefono.Text = "";
        }
    }
}
