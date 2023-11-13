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
        public string IdCliente { get; set; }
        public string IdProducto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.Now;
        public int Estado { get; set; }
        public string IdUsuario { get; set; }

        public Ventas(VentasWS ventasWS)
        {
            this.IdCliente = ventasWS.idCliente;
            this.IdUsuario = ventasWS.idUsuario;
            this.IdProducto = ventasWS.idProducto;
            this.Cantidad = ventasWS.cantidad;

        }
    }

}
