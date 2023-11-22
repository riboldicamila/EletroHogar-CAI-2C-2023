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
        public bool AgregarCliente(string nombre, string host, int dni, string direccion, string telefono, string apellido,
        string email, string idUsuarioActual, DateTime fechaNacimiento)
        {

            // Crear un objeto usuarioWS
            var nuevoClienteWS = new ClienteWS
            {
                idUsuario = idUsuarioActual,
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

        public List<Cliente> ListarClientes()
        {
            return ClienteDatos.DevolverClientes();
        }



        //Para ver si es un cliente nuevo.
        public Cliente BuscarCliente(string idCliente)
        {
            return ClienteDatos.BusquedaPorCliente(idCliente);
        }



        public bool ModificacionCliente(string id, string direccion, string telefono, string email)
        {
            try
            {
                ClienteDatos.ModificacionCliente(id, direccion, telefono, email);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }

}
