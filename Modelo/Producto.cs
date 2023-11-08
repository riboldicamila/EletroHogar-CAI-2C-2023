using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Producto
    {
        public Guid Id { get; set; }
        public Guid IdCategoria { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdProveedor { get; set; }

        //CONSTRUCTOR
        public Producto(string nombre, double precio, int stock, Guid idCategoria)
        {
            Id = Guid.NewGuid(); // Generar un nuevo Id
            IdCategoria = idCategoria;
            Nombre = nombre;
            FechaAlta = DateTime.Now; // Establecer la fecha de alta de hoy
            Precio = precio;
            Stock = stock;
            // La propiedad FechaBaja se inicializa como null 
            IdUsuario = Guid.Empty; // check
            IdProveedor = Guid.Empty; //check
        }

        public Producto(ProductosWS productoWS)
        {
            IdCategoria = productoWS.IdCategoria;
            Nombre = productoWS.Nombre;
            Precio = productoWS.Precio;
            Stock = productoWS.Stock;
            IdUsuario = productoWS.IdUsuario;
            IdProveedor = productoWS.IdProveedor;
        }




    }
}
