using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Farmacia.Modelo.DTO
{
    internal class DTOProveedores : dbContext
    {
        private int idProvedor;
        private string nombreE;
        private string contacto;
        private string direccion;
        private string email;

        public string NombreE { get => nombreE; set => nombreE = value; }
        public string Contacto { get => contacto; set => contacto = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Email { get => email; set => email = value; }
        public int IdProvedor { get => idProvedor; set => idProvedor = value; }
    }
}
