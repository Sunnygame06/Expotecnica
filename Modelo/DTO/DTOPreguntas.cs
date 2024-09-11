using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Farmacia.Modelo.DTO
{
    public class DTOPreguntas : dbContext
    {
        private string Nombre;
        private string DUI;
        private string Telefono;

        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string DUI1 { get => DUI; set => DUI = value; }
        public string Telefono1 { get => Telefono; set => Telefono = value; }
    }
}
