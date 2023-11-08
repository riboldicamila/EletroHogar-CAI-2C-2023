using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ProductosWS
    {
        public Guid IdCategoria { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdProveedor { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

        public ProductosWS() { }

    }
}
