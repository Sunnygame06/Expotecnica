using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Farmacia.Modelo.DTO
{
    internal class DTOempleados : dbContext
    {
        private int idEmpleado;
        private string nombre;
        private DateTime fechaNacimiento;
        private string estadoCivil;
        private string dui;
        private string telefono;
        private int idUser;

        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string EstadoCivil { get => estadoCivil; set => estadoCivil = value; }
        public string Dui { get => dui; set => dui = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int IdUser { get => idUser; set => idUser = value; }
    }
}
