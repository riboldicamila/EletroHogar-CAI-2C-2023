using System;
using System.Data.SqlTypes;
using AccesoDatos;
using Modelo;
using Newtonsoft.Json;

namespace Negocio
{
    public class GestorDeProveedores
    {

        public List<Proveedor> ListarProveedores()
        {
            return ProveedoresDatos.ListarProveedores();
        }

        public bool AltaProveedor(string nombre, string apellido, string cuit, string email, Guid idUsuario)
        {

            // Crear un objeto ProveedoresWS
            var nuevoProveedorWS = new ProveedoresWS
            {
                idUsuario ="70b37dc1-8fde-4840-be47-9ababd0ee7e5",
                nombre = nombre,
                apellido = apellido,
                email = email,
                cuit = cuit
            };

            try
            {
                ProveedoresDatos.AltaProveedor(nuevoProveedorWS);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void ModificarProveedor()
        {
            //No es obligatorio
            //ProveedoresDatos.ModificacionProveedor(proveedorWS);
          
        }

        public bool BajaProveedor(string idProveedor, Guid idUsuario)
        {
            try
            {
                //ProveedoresDatos.BajaProveedor(idProveedor, idUsuario.ToString());
                ProveedoresDatos.BajaProveedor(idProveedor, "70b37dc1-8fde-4840-be47-9ababd0ee7e5");

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }

}