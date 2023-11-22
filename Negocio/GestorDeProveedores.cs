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

        public bool ModificarProveedor(string id, string idUsuarioActual, string nombre, string apellido, string email, string cuit)
        {
            try
            {
                ProveedoresDatos.ModificarProveedorWS(id, idUsuarioActual, nombre, apellido, email,cuit);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public Proveedor BuscarProveedor(string id)
        {
            Proveedor proveedor = ObtenerProveedorPorId(id);

            return proveedor;

        }

        public Proveedor ObtenerProveedorPorId(string idProveedor)
        {
            List<Proveedor> listaProveedores = ProveedoresDatos.ListarProveedores();

            foreach (Proveedor proveedor in listaProveedores)
            {
                if (proveedor.id == idProveedor)
                {
                    return proveedor; // Devuelve el proveedor encontrado
                }
            }

            return null; 
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