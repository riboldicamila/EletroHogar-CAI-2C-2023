using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{


    public class Proveedor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdProducto { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.Now;
        public DateTime? FechaBaja { get; set; } // es null esta activo
        public long CUIT { get; set; }
        public string Email { get; set; }
        public string Apellido { get; set; }

        public Guid IdUsuarioAlta { get; set; }
        public List<Categoria> Categorias { get; set; } = new List<Categoria>(); //categorias de cada proveedor



        public EstadoProveedor estadoProveedor;

        public enum EstadoProveedor
        {
            INACTIVO,
            ACTIVO
        }

        public void DeshabilitarProveedor()
        {
            this.estadoProveedor = EstadoProveedor.INACTIVO;
        }

        public void HabilitarProveedor()
        {
            this.estadoProveedor = EstadoProveedor.ACTIVO;
        }



        //falta implementar
        public void AgregarCategoria(Categoria categoria)
        {
            if (!Categorias.Contains(categoria))
            {
                Categorias.Add(categoria);
                categoria.AgregarProveedor(this);
            }
        }
    }
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
