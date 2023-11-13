using AccesoDatos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestorDeClientes
    {
        public bool AgregarCliente(string nombre, int host, int dni, string direccion, string telefono, string apellido,
        string email, string idUsuarioActual, DateTime fechaNacimiento)
        {

            // Crear un objeto usuarioWS
            var nuevoClienteWS = new ClienteWS
            {
                idUsuario = "0cdbc5a5-69d9-4ab8-8cb3-9932ce33f54a",
                nombre = nombre,
                apellido = apellido,
                dni = dni,
                direccion = direccion,
                telefono = telefono,
                email = email,
                fechaNacimiento = fechaNacimiento,
                host = host, //pasa segun opcion menu
            };

            try
            {
                ClienteDatos.AgregarCliente(nuevoClienteWS);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }

}
