using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class VentasWS
    {
        public string IdCliente { get; set; }
        public string IdProducto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.Now;
        public int Estado { get; set; }
        public string IdUsuario { get; set; }

        public VentasWS() { }

    }

}

