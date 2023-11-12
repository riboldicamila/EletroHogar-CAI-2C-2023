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
                idUsuario = "0cdbc5a5-69d9-4ab8-8cb3-9932ce33f54a",
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
                ProveedoresDatos.BajaProveedor(idProveedor, "0cdbc5a5-69d9-4ab8-8cb3-9932ce33f54a");

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }

}