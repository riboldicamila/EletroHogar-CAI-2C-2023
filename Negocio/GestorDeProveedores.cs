﻿using System;
using AccesoDatos;
using Modelo;

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
                Console.WriteLine("Error al agregar el proveedor: " + ex.Message);
                return false;
            }
        }


        private ProveedoresWS CrearProveedoresWS(string nombre, string apellido, string cuit, string email, string idUsuario)
        {
            return new ProveedoresWS
            {
                idUsuario = idUsuario,
                nombre = nombre,
                apellido = apellido,
                cuit = cuit,
                email = email
            };
        }




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

