using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Farmacia.Modelo.DTO
{
    internal class DTOProducto : dbContext
    {
        private int idProducto;
        private string nombre;
        private string descripcion;
        private decimal precio;
        private int stock;
        private DateTime fechadeVencimiento;
        private int proveedor;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public int Stock { get => stock; set => stock = value; }
        public DateTime FechadeVencimiento { get => fechadeVencimiento; set => fechadeVencimiento = value; }
        public int Proveedor { get => proveedor; set => proveedor = value; }
    }
}
