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
        private string _id;
        private string _nombre;
        private string _apellido;
        private string _email;
        private string _cuit;
        private DateTime _fechaAlta;
        private DateTime? _fechaBaja;

        public string Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Email { get => _email; set => _email = value; }
        public string Cuit { get => _cuit; set => _cuit = value; }
        public DateTime FechaAlta { get => _fechaAlta; set => _fechaAlta = value; }
        public DateTime? FechaBaja { get => _fechaBaja; set => _fechaBaja = value; }

        override
        public String ToString() => Cuit + " " + Nombre + " " + Apellido;
    }
}
