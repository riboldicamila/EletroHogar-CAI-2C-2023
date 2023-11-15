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
