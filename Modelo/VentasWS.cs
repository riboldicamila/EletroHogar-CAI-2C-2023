using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class VentasWS
    {
        public Guid idCliente { get; set; }
        public Guid idUsuario { get; set; }
        public Guid idProducto { get; set; }
        public int cantidad { get; set; }

        public VentasWS() { }

    }

}

