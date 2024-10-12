using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Farmacia.Modelo.DTO
{
    internal class DTOFactura : dbContext
    {
        private int cantidad;
        private int codigoProducto;
        private int venta;
        private int idDetalleVenta;
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int CodigoProducto { get => codigoProducto; set => codigoProducto = value; }
        public int Venta { get => venta; set => venta = value; }
        public int IdDetalleVenta { get => idDetalleVenta; set => idDetalleVenta = value; }
    }
}
