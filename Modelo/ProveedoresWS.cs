using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ProveedoresWS
    {
    
            public string idUsuario { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string email { get; set; }
            public string cuit { get; set; }
        


        public override string ToString()
        {
            return cuit + " " + nombre + " " + apellido+ "" + idUsuario;
        }
    }
}
