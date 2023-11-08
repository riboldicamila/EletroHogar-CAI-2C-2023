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
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdCliente { get; set; }
        public Guid IdProducto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.Now;
        public int Estado { get; set; }
        public Guid IdUsuario { get; set; }

        public Ventas(VentasWS ventasWS)
        {
            this.IdCliente = ventasWS.idCliente;
            this.IdProducto = ventasWS.idProducto;
            this.Cantidad = ventasWS.cantidad;
            this.IdUsuario = ventasWS.idUsuario;
            // El campo "Estado"
        }
    }

}
