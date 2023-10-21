using System;
using Modelo;

namespace Negocio
{
    public class GestorDeProveedores
    {
        private List<Proveedor> proveedores = new List<Proveedor>();
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

        public bool AgregarProveedor(string nombre, long cuit, string email, string apellido, Guid idUsuario, List<Categoria> categorias)

        // Guid idUsuario
        {
            if (!string.IsNullOrEmpty(nombre) && cuit != 0 && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(apellido))
            {
                Proveedor nuevoProveedor = new Proveedor
                {
                    Nombre = nombre,
                    CUIT = cuit,
                    Email = email,
                    Apellido = apellido,
                    IdUsuarioAlta = idUsuario,
                    FechaAlta = DateTime.Now,
                    Categorias = new List<Categoria>()
                };
                proveedores.Add(nuevoProveedor);
                return true;
            }
            return false;
        }

        //public bool buscarcategoria(string categoria)
        //{




        //}



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


    //CONUSLTAR A PROFESORES, IDEA ES HACER TODAS LAS VALIDACIONES ACA
    // USAR METODOS DESDE PROGRAM 

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
}

