using System;
using AccesoDatos;
using Modelo;

namespace Negocio
{
    public class GestorDeProveedores
    {
        private List<Proveedor> proveedores = new List<Proveedor>();

        public List<ProveedoresWS> ListarProveedores()
        {
            return ProveedoresDatos.ListarProveedores();
        }


        public bool AgregarProveedor(string nombre, string cuit, string email, string apellido, Guid idUsuario)
        {
            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(cuit) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(apellido))
            {
                // Crear una nueva instancia de ProveedoresWS con los datos del nuevo proveedor
                ProveedoresWS nuevoProveedor = new ProveedoresWS
                {
                    Nombre = nombre,
                    Cuit = cuit,
                    Email = email,
                    Apellido = apellido,
                };

                try
                {
                    // Llamar al método AltaProveedor para agregar el nuevo proveedor
                    ProveedoresDatos.AltaProveedor(nuevoProveedor);
                    return true; // El proveedor se agregó correctamente
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al agregar el proveedor: " + ex.Message);
                }
            }

            return false; // No se pudo agregar el proveedor
        }



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

