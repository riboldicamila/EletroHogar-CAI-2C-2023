using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cliente
    {
        //ESTE CASO HOST ES STRING! 

        public string id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dni { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime? fechaBaja { get; set; } //permite null :)
        public string host { get; set; }

        public Cliente(ClienteWS clienteWS)
        {
            id = clienteWS.idUsuario;
            nombre= clienteWS.nombre;
            apellido= clienteWS.apellido;
            dni = clienteWS.dni;
            direccion= clienteWS.direccion;
            telefono= clienteWS.telefono;
            email= clienteWS.email;
            fechaNacimiento = clienteWS.fechaNacimiento;
            host= clienteWS.host;
        }
        public Cliente()
        {
            // Constructor para la deserialización
        }

        //CONSTRUCTOR, NO ME LO TOMA EL JSON. hice todos con constructor vacio por default
        //[JsonConstructor]
        public Cliente(string id, string nombre, string apellido, int dni, string direccion, string telefono, string email, DateTime fechaNacimiento, 
            DateTime fechaAlta, DateTime fechaBaja, string host)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.direccion = direccion;
            this.telefono = telefono;
            this.email = email;
            this.fechaNacimiento = fechaNacimiento;
            this.fechaAlta= fechaAlta;
            this.fechaBaja= fechaBaja;
            this.host = host;
        }

        //ver si es cliente nuevo
        public bool TieneFechaAltaHoy()
        {
            DateTime fechaActual = DateTime.Today;
            return fechaAlta.Date == fechaActual;
        }

        public override string ToString()
        {
            return nombre.PadRight(25) + " " + apellido.PadRight(25) + "(" + id + ")";
        }
    }
}
