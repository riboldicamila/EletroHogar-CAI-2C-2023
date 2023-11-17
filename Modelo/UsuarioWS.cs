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

        private Guid _id;
        private string _nombre, _apellido, _usuario;

        private int _host, _dni;
        public Guid id { get => _id; set => _id = value; }
        public string nombre { get => _nombre; set => _nombre = value; }
        public string apellido { get => _apellido; set => _apellido = value; }
        public int dni { get => _dni; set => _dni = value; }
        public string usuario { get => _usuario; set => _usuario = value; }
        public int host { get => _host; set => _host = value; }

        public UsuarioWS()
        {

        }

        public override string ToString()
        {
            return  id + " " + nombre + " " + apellido;
        }
    }
}