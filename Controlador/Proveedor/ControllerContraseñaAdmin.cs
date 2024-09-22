using Login_Farmacia.Formularios.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Farmacia.Controlador.Proveedor
{
    internal class ControllerContraseñaAdmin
    {
        FrmContraseñaAdmin ObjAdmin;

        public ControllerContraseñaAdmin(FrmContraseñaAdmin Vista)
        {
            ObjAdmin = Vista;
            ObjAdmin.btnListo.Click += new EventHandler(Listo);
        }

        public void Listo(object sender, EventArgs e)
        {

        }
    }
}
