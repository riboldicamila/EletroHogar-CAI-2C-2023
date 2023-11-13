using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ProductosWS
    {
        public int idCategoria { get; set; }
        public string idUsuario { get; set; }
        public string idProveedor { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }

        public ProductosWS() { }
        public override string ToString()
        {
            return nombre + " " + idCategoria + " " + stock + "" + precio;
        }
    }
}
    

