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
        public string idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dni { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int host { get; set; }

        public Cliente(ClienteWS clienteWS)
        {
            idUsuario= clienteWS.idUsuario;
            nombre= clienteWS.nombre;
            apellido= clienteWS.apellido;
            dni = clienteWS.dni;
            direccion= clienteWS.direccion;
            telefono= clienteWS.telefono;
            email= clienteWS.email;
            fechaNacimiento = clienteWS.fechaNacimiento;
            host= clienteWS.host;
        }
    }
}
