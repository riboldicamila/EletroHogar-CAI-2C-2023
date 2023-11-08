using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Categoria
    {
        public Guid IdProducto { get; set; } = Guid.NewGuid();
        public string Descripcion { get; set; }
        public List<Proveedor> Proveedores { get; set; } = new List<Proveedor>();

        public Categoria(Guid id)
        {
            IdProducto = id;
        }


        public void AgregarProveedor(Proveedor proveedor)
        {
            if (!Proveedores.Contains(proveedor))
            {
                Proveedores.Add(proveedor);
            }
        }
    }
}
