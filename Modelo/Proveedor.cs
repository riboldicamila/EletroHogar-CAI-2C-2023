using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Proveedor
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string CUIT { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }


        public Proveedor()
        {
            // Constructor por defecto requerido para la deserialización
        }

        public Proveedor(string id, string nombre, string apellido, string email, string cuit, DateTime fechaAlta, DateTime? fechaBaja)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            CUIT = cuit;
            FechaAlta = fechaAlta;
            FechaBaja = fechaBaja;
        }

        public Proveedor(ProveedoresWS proveedorWS)
        {
            this.Id = proveedorWS.idUsuario;
            this.Nombre = proveedorWS.nombre;
            this.Apellido = proveedorWS.apellido;
            this.Email = proveedorWS.email;
            this.CUIT = proveedorWS.cuit;
        }

        public override string ToString()
        {
            return Id + " "+ CUIT + " " + Nombre + " " + Apellido;
        }


    }
   
}
