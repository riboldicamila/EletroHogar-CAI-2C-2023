using System;
using AccesoDatos;
using Modelo;

namespace Negocio
{    
    //STOCK: solo se verifica antes de hacer la venta (elemento). 
    //se compara stock contra la cantidad total del alta, ya que no encontre
    //relacion entre ventasWS con algún identificador de producto (Id)
    //que permita después descontar del stock inicial. 
    
    public class GestorDeProductos
    {
        private List<Producto> productos = new List<Producto>();


        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public bool AgregarProducto(int idCategoria, string idUsuarioActual, string idProveedor, string nombre, 
            decimal precio, int stock)
        {

            // Crear un objeto Productos WS (esta alreves que usuarios Ws)
            var nuevoProductoWS = new ProductosWS
            {
                idCategoria = idCategoria,
                idUsuario = idUsuarioActual,
                idProveedor = idProveedor,
                nombre = nombre,
                precio = precio,
                stock = stock
            };

            try
            {
                ProductosDatos.AgregarProducto(nuevoProductoWS);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool BajaProductos(string idProducto, string idUsuario)
        {
            try
            {
                ProductosDatos.BajaProducto(idProducto, idUsuario);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    
        public List<Producto> TraerProductos()
        {
            return ProductosDatos.TraerProductos();
        }

        public List<Producto> ListaProductosPorCategoria(int categoria)
        {
            return ProductosDatos.ListarProductoCategoria(categoria);
        }

        public bool ReactivarProducto(string idReactivar, string idUsuarioActual)
        {
            try
            {
                ProductosDatos.ReactivarProducto(idReactivar, idUsuarioActual);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Producto> ObtenerListadoDeProductosElectroHogar()
        {
            //SUPONIENDO QUE ID 1 == A PRODUCTO TIPO ELECTRO HOGAR
            //  la lista desde el webservice
            List<Producto> listadoProductos = ProductosDatos.TraerProductos();

            // Filtrar la lista  
            List<Producto> listadoProductosElectro = listadoProductos
                .Where(producto => producto.idCategoria == 1)
                .ToList();

            return listadoProductosElectro;
        }

        public bool VerificarStock(string idProducto, int cantidad)
        {
            List<Producto> productos = ProductosDatos.TraerProductos();
            Producto productoSeleccionado = productos.FirstOrDefault(p => p.id == idProducto);

            if (productoSeleccionado != null)
            {
                if (cantidad <= productoSeleccionado.stock)
                {
                    // La cantidad es menor o igual al stock disponible
                    return true;
                }
                else
                {
                    // La cantidad es mayor al stock disponible
                    return false;
                }
            }
            else
            {
                // El producto no fue encontrado
                return false;
            }
        }




    }

}