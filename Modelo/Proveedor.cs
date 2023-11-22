using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Proveedor
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string cuit { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime? fechaBaja { get; set; }


        public Proveedor()
        {
            // Constructor para la deserialización
        }

        //CONSTRUCTOR, NO ME LO TOMA EL JSON. hice todos con constructor vacio por default
        public Proveedor(string id, string nombre, string apellido, string email, string cuit, DateTime fechaAlta, DateTime? fechaBaja)
        {
            id = id;
            nombre = nombre;
            apellido = apellido;
            email = email;
            cuit = cuit;
            fechaAlta = fechaAlta;
            fechaBaja = fechaBaja;
        }

        public Proveedor(ProveedoresWS proveedorWS)
        {
            this.id = proveedorWS.idUsuario;
            this.nombre = proveedorWS.nombre;
            this.apellido = proveedorWS.apellido;
            this.email = proveedorWS.email;
            this.cuit = proveedorWS.cuit;
        }

        public override string ToString()
        {
            return cuit.PadRight(20) + " " + nombre.PadRight(25) + " " + apellido.PadRight(25) + "(" + id + ")";
        }


    }
   
}
