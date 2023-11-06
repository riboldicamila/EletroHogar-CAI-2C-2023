using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class UsuarioWS
    {
        private Guid _idUsuario;
        private string _nombre;
        private string _apellido;
        private string _username;
        private int _host;
        private int _dni;

        public Guid idUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int host { get => _host; set => _host = value; }
        public string nombre { get => _nombre; set => _nombre = value; }
        public string apellido { get => _apellido; set => _apellido = value; }
        public int dni { get => _dni; set => _dni = value; }
        public string username { get => _username; set => _username = value; }
        //public string direccion { get; set; }
        // public string telefono { get; set; }
        //public DateTime fechaNacimiento { get; set; }

        //public string contraseña { get; set; }

        public UsuarioWS()
        {

        }


        public override string ToString()
        {
            return nombre + " " + apellido + "" + username;
        }
    }
}