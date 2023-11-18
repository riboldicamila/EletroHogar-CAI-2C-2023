using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    using System;

    public class Ventas
    {
        public string idCliente { get; set; }
        public string idUsuario { get; set; }
        public string idProducto { get; set; }
        public int cantidad { get; set; }

        public Ventas()
        {

        }

        public Ventas(string idCliente, string idUsuario, string idProducto, int cantidad)
        {
            this.idCliente = idCliente;
            this.idUsuario= idUsuario;
            this.idProducto = idProducto;
            this.cantidad = cantidad;

        }
   
        public Ventas(VentasWS ventasWS)
        {
            this.idCliente = ventasWS.IdCliente;
            this.idUsuario = ventasWS.IdUsuario;
            this.idProducto = ventasWS.IdProducto;
            this.cantidad = ventasWS.Cantidad;

        }
    }

}
