using System;
using AccesoDatos;
using Modelo;

namespace Negocio
{    
    
    public class GestorDeProductos
    {
        private List<Producto> productos = new List<Producto>();

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public List<Producto> ObtenerTodosLosProductos()
        {
            return productos;
        }

        public List<ProductosWS> TraerProductos()
        {
            return ProductosDatos.TraerProductos();
        }
    }

}