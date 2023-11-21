using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ItemProductosVentas
    {
        String idProducto;
        String nombre;
        int cantidad;
        decimal precio;

        public string IdProducto { get => idProducto; set => idProducto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Precio { get => precio; set => precio = value; }

        public override string ToString()
        {
            return nombre.PadRight(25) + cantidad.ToString().PadRight(5) + precio.ToString().PadRight(10);
        }
    }
}
