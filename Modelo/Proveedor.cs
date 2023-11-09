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
        public string CUIT { get; set; }
        public string Email { get; set; }
        public string Apellido { get; set; }

        public string IdUsuarioAlta { get; set; }
        public List<Categoria> Categorias { get; set; } = new List<Categoria>(); //categorias de cada proveedor

        //Constructor

        public Proveedor (ProveedoresWS proveedorWS)
        {
            this.IdUsuarioAlta = proveedorWS.idUsuario;
            this.Nombre = proveedorWS.nombre;
            this.Apellido = proveedorWS.apellido;
            this.Email = proveedorWS.email;
            this.CUIT = proveedorWS.cuit;
        }

        //public Proveedor(string nombre, string apellido, string username)
        //{
        //    this.nombre = nombre;
        //    this.apellido = apellido;
        //    this.Username = username;
        //    this.password = GenerarPasswordTemporal();
        //    this.ultimoCambioPass = DateTime.Now;
        //    this.intentosCambioPass = 0;
        //    this.estado = EstadoUsuario.INACTIVO;

        //}


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
   
}
