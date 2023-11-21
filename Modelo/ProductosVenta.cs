using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ProductosVenta
    {
        String idCliente;
        String idUsuario;
        List<ItemProductosVentas> listadoProductosVentas;

        public ProductosVenta()
        {
        }

        public string IdCliente { get => idCliente; set => idCliente = value; }
        public string IdUsuario { get => idUsuario; set => idUsuario = value; }
        public List<ItemProductosVentas> ListadoProductosVentas { get => listadoProductosVentas; set => listadoProductosVentas = value; }
    }
}
