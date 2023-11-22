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
        //id producto
        public string id { get; set; }
        public int idCategoria { get; set; }
        public string nombre { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime? fechaBaja { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public string IdUsuario { get; set; }
        public string IdProveedor { get; set; }

        public Producto()
        {
        }

        //CONSTRUCTOR, NO ME LO TOMA EL JSON. hice todos con constructor vacio por default
        //[JsonConstructor]
        public Producto(string id, int idCategoria, string nombre, DateTime fechaAlta, DateTime fechaBaja, decimal precio, int stock)
        {
            this.id = id;
            this.idCategoria = idCategoria;
            this.nombre= nombre;
            this.fechaAlta = fechaAlta;
            this.fechaBaja = fechaBaja;
            this.precio = precio;
            this.stock=stock;
          
        }

        public Producto(ProductosWS productoWS)
        {
            idCategoria = productoWS.idCategoria;
            nombre = productoWS.nombre;
            precio = productoWS.precio;
            stock = productoWS.stock;
            IdUsuario = productoWS.idUsuario;
            IdProveedor = productoWS.idProveedor;
        }

        //necesita este para traer y mostrar LISTA
        public override string ToString()
        {
            return "(" + id + ")" + nombre.PadRight(25) + precio;
        }




    }
}
