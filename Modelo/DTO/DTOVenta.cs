using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Farmacia.Modelo.DTO
{
    internal class DTOVenta : dbContext
    {
        private int idCliente;
        private int idEmpleado;
        private DateTime hora;
        private DateTime fecha;

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public DateTime Hora { get => hora; set => hora = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
