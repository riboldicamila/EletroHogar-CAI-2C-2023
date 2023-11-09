using System;
using AccesoDatos;
using Modelo;
using Newtonsoft.Json;

namespace Negocio
{
    public class GestorDeProveedores
    {

        public List<ProveedoresWS> ListarProveedores()
        {
            return ProveedoresDatos.ListarProveedores();
        }

        public bool AltaProveedor(string nombre, string apellido, string cuit, string email, Guid idUsuario)
        {
            // Crear un objeto Proveedor
            var nuevoProveedor = new Proveedor(Guid.NewGuid(), Guid.NewGuid(), nombre, apellido, email, cuit, idUsuario.ToString());

            // Crear un objeto ProveedoresWS
            var nuevoProveedorWS = new ProveedoresWS
            {
                idUsuario = "70b37dc1-8fde-4840-be47-9ababd0ee7e5",
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

            //ProveedoresDatos.ModificacionProveedor(proveedorWS);
          
        }

        public bool BajaProveedor(string idProveedor, Guid idUsuario)
        {
            try
            {
                var requestData = new
                {
                    id = idProveedor,
                    idUsuario = idUsuario.ToString()
                };

                ProveedoresDatos.BajaProveedor(requestData);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }





        //VIEJO

        private List<Proveedor> proveedores = new List<Proveedor>();



        public bool BajaProveedor(string nombre, string apellido)
        {
            foreach (Proveedor p in proveedores)
            {
                if (p.Nombre == nombre && p.Apellido == apellido)
                {
                    p.DeshabilitarProveedor();
                    break;
                }
            }
            return true;

        }
        //public bool asignarcategoriaaproveedor(guid proveedorid, categoria categoria)
        //{
        //    var proveedor = proveedores.firstordefault(p => p.id == proveedorid);
        //    if (proveedor != null && categoria != null)
        //    {
        //        proveedor.agregarcategoria(categoria);
        //        return true;
        //    }
        //    return false;
        //}

        public List<Proveedor> ObtenerTodosLosProveedores()
        {
            return proveedores;
        }

    }

}