using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class UsuarioWS
    {

        public string idUsuario { get; set; }
        public int host { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dni { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string nombreUsuario { get; set; }
        public string contraseña { get; set; }



        public override string ToString()
        {
            return nombre + " " + apellido + "" + idUsuario;
        }
    }
}