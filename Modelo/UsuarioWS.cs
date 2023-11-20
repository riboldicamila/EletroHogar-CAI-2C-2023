using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class UsuarioWS
    {
        //WS se usa para deserilizar
        //tiene todos los atributos de la response body del GET 

        public string Id { get; set; }
        public string idUsuario { get; set; }
        public int host { get; set; }
        public string nombre;
        public string apellido;
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public DateTime? fechaNacimiento { get; set; }  // ? permite null
        public DateTime? FechaBaja { get; set; }  // ? permite null
        public string nombreUsuario;
        public int dni { get; set; }
        public string contraseña;

        public UsuarioWS()
        {

        }

        public override string ToString()
        {
            return  Id + " " + nombre + " " + apellido;
        }
    }
}