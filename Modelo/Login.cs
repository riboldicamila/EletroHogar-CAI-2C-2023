using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Login
    {
        private string _nombreUsuario;
        private string _contraseña;

        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string Contraseña { get => _contraseña; set => _contraseña = value; }

    }

    //espera el post del login

    //    {
    //  "nombreUsuario": "string",
    //  "contraseña": "string"
    //   }

}
