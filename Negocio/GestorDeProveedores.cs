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
            ProveedoresWS nuevoProveedor = CrearProveedoresWS(nombre, apellido, cuit, email, idUsuario.ToString());

            try
            {
                ProveedoresDatos.AltaProveedor(nuevoProveedor);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        private ProveedoresWS CrearProveedoresWS(string nombre, string apellido, string cuit, string email, string idUsuario)
        {
            return new ProveedoresWS
            {
                //id usuarios ponemos por ahora el master, se debe cambiar, consultar.
                idUsuario = "70b37dc1-8fde-4840-be47-9ababd0ee7e5",
                nombre = nombre,
                apellido = apellido,
                cuit = cuit,
                email = email
            };
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




    // FUERA DE LA CLASE: VALIDACIONES
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
    }



    /*
private List<Categoria> categoriasPermitidas = new List<Categoria>
 {
new Categoria { IdProducto = Guid.NewGuid(), Descripcion = "Audio" },
new Categoria { IdProducto = Guid.NewGuid(), Descripcion = "Celulares" },
new Categoria { IdProducto = Guid.NewGuid(), Descripcion = "Electro Hogar" },
new Categoria { IdProducto = Guid.NewGuid(), Descripcion = "Informatica" },
new Categoria { IdProducto = Guid.NewGuid(), Descripcion = "Smart Tv" }
 };
*/
    /*
    private bool EsCategoriaValida(Guid categoriaId)
    {
        // Verificar si el ID de la categoría está en la lista de categorías permitidas
        return categoriasPermitidas.Any(c => c.IdProducto == categoriaId);
    }
    */
}