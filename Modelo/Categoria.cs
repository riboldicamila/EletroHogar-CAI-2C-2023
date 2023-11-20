using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Categoria
    {

        //creo que no se usa, ni se va a usar. A borrar 

        public Guid IdProducto { get; set; } = Guid.NewGuid();
        public string Descripcion { get; set; }
        public List<Proveedor> Proveedores { get; set; } = new List<Proveedor>();

        public Categoria(Guid id)
        {
            IdProducto = id;
        }


      
    }
}
