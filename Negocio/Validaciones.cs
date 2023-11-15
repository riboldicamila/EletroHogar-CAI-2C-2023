using System;
using System.Collections.Generic;
using System.Linq;
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
            if (string.IsNullOrEmpty(telefono) || (telefono.All(char.IsDigit)) || (telefono.Length > 10))
            {
                throw new ArgumentException("El numero de telefono no puede estar vacío, debe contener máximo 10 numeros y solo puede contener dígitos del 0 al 9.");
            }

        }

        public static void ValidarEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !(email.Contains("@")) || !(email.Contains(".com")))
            {
                throw new ArgumentException("Ingrese una dirección decorreo electrónco válida.");
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

        public static void ValidarRegistro(string Registro)
        {
            int salida;
            if (string.IsNullOrEmpty(Registro) || !int.TryParse(Registro, out salida) || Registro.Length != 8)
            {
                throw new ArgumentException("El Registro debe ser un numero de 8 digitos, no puede estar vacío");
            }
        }
        public static void ValidarFecha(string fecha)
        {
            if (string.IsNullOrEmpty(fecha) || !DateTime.TryParse(fecha, out DateTime fechaSalida))
            {
                DateTime fechaDateTime = DateTime.Parse(fecha);
                if (fechaDateTime < new DateTime(1900, 1, 1))
                {
                    throw new ArgumentException("La fecha no es válida");
                }
            }
        }

    }

}
