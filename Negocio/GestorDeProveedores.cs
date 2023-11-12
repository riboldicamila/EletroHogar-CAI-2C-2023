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

        public bool AltaProveedor(string nombre, string apellido, string cuit, string email, string idUsuario)
        {

            // Crear un objeto ProveedoresWS
            var nuevoProveedorWS = new ProveedoresWS
            {
                idUsuario = idUsuario,
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

        public bool BajaProveedor(string idProveedor, string idUsuario)
        {
            try
            {
                ProveedoresDatos.BajaProveedor(idProveedor, idUsuario);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }

}