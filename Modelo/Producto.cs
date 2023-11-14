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
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string IdUsuario { get; set; }
        public string IdProveedor { get; set; }

        //CONSTRUCTOR
        public Producto(string nombre, decimal precio, int stock, int idCategoria)
        {
            Id = Guid.NewGuid(); // Generar un nuevo Id
            IdCategoria = idCategoria;
            Nombre = nombre;
            FechaAlta = DateTime.Now; // Establecer la fecha de alta de hoy
            Precio = precio;
            Stock = stock;
            // La propiedad FechaBaja se inicializa como null 
            //IdUsuario = id
            //IdProveedor = 
        }

        public Producto(ProductosWS productoWS)
        {
            IdCategoria = productoWS.idCategoria;
            Nombre = productoWS.nombre;
            Precio = productoWS.precio;
            Stock = productoWS.stock;
            IdUsuario = productoWS.idUsuario;
            IdProveedor = productoWS.idProveedor;
        }

        //necesita este para traer y mostrar LISTA
        public override string ToString()
        {
            return Nombre + " " + IdUsuario;
        }




    }
}
