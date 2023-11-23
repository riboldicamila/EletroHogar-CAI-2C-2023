using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class Validaciones
    {
        public static void ValidarNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre) || nombre.Length <= 2 || nombre.Any(char.IsDigit))
            {
                throw new ArgumentException("El nombre no puede estar vacío, debe tener por lo menos 2 caracteres y no puede contener números.");
            }
            
        }

        public static void ValidarApellido(string apellido)
        {
            if (string.IsNullOrEmpty(apellido) || apellido.Length < 2 || apellido.Any(char.IsDigit))
            {
                throw new ArgumentException("El apellido no puede estar vacío, debe tener por lo menos 2 caracteres y no puede contener números.");
            }
        }
        public static void ValidarDireccion(string direccion)
        {
            if (string.IsNullOrEmpty(direccion) || !(direccion.Any(char.IsDigit)))
            {
                throw new ArgumentException("La direccion no puede estar vacía, debe tener por lo menos 2 caracteres y debe contener el numero de la calle.");
            }
        }
        public static void ValidarUsername(string nombre, string apellido, string username)
        {
            if (username.Length < 8)
            {
                throw new ArgumentException("El nombre de usuario debe tener mínimo 8 caracteres.");
            }
            else if (username.Length > 15)
            {
                throw new ArgumentException("El nombre de usuario debe tener un máximo de 15 caracteres.");
            }
            else if (username.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0 ||
                     username.IndexOf(apellido, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                throw new ArgumentException("El nombre de usuario no debe contener el nombre o el apellido.");
            }
        }

        public static void ValidarTelefono(string telefono)
        {
            const int minDigitos = 10;

            if (string.IsNullOrEmpty(telefono) || telefono.Length < minDigitos || !telefono.All(char.IsDigit))
            {
                throw new ArgumentException($"El número de teléfono debe tener al menos {minDigitos} dígitos y solo puede contener dígitos del 0 al 9.");
            }
        }


        public static void ValidarEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !(email.Contains("@")) || !(email.Contains(".com")))
            {
                throw new ArgumentException("Ingrese una dirección de correo electrónco válida.");
            }

        }

        public static void ValidarDni(string DNI)
        {
            int salida;
            if (string.IsNullOrEmpty(DNI) || !int.TryParse(DNI, out salida) || DNI.Length != 8 || int.Parse(DNI) < 0)
            {
                throw new ArgumentException("El dni debe ser un numero positivo de 8 digitos, no puede estar vacío");
            }
        }

 
        public static void ValidarFecha(string fecha)
        {
            if (!string.IsNullOrEmpty(fecha) || !DateTime.TryParse(fecha, out DateTime fechaSalida) )
            {
                DateTime fechaDateTime = DateTime.Parse(fecha);
                if (fechaDateTime < new DateTime(1900, 1, 1))
                {
                    throw new ArgumentException("La fecha no es válida");
                }
            }
        }

        public static void ValidarCuit(string cuit)
        {
            if (string.IsNullOrEmpty(cuit) || cuit.Length != 11 || !EsNumeroPositivo(cuit))
            {
                throw new ArgumentException("El CUIT debe ser un número positivo de 11 dígitos, sin espacios ni guiones. No puede estar vacío.");
            }
        }

        private static bool EsNumeroPositivo(string input)
        {
            return int.TryParse(input, out int salida) && salida >= 0;
        }


        public static void ValidarPrecio(decimal precio)
        {
            if (precio <= 0)
            {
                throw new ArgumentException("El precio debe ser un valor decimal positivo.");
            }
        }

        public static void ValidarCategoria(int categoria)
        {
            if (categoria < 1 || categoria > 5)
            {
                throw new ArgumentException("La categoría debe estar en el rango de 1 a 5.");
            }
        }

        public static void ValidarStock(int stock)
        {
            if (stock < 0)
            {
                throw new ArgumentException("El stock no puede ser un número negativo.");
            }
        }

        public static void ValidarId(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out _))
            {
                throw new ArgumentException("El ID no tiene el formato correcto.");
            }
        }

        public static void ValidarCampoString(string generico)
        {
            if (string.IsNullOrEmpty(generico))
            {
                throw new ArgumentException("No puede dejar el campo vacio. Ingrese un dato.");
            }
        }

    }

}
