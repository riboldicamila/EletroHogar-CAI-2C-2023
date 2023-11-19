﻿using AccesoDatos.Utilidades;
using Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public static class ProductosDatos
    {
        //POST con agregar

        public static void AgregarProducto(ProductosWS producto)
        {
            var jsonRequest = JsonConvert.SerializeObject(producto);
            HttpResponseMessage response = WebHelper.Post("Producto/AgregarProducto", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados. Error al agregar proveedor.");
            }
        }

        //GET con traer

        public static List<Producto> TraerProductos()
        {
            HttpResponseMessage response = WebHelper.Get("Producto/TraerProductos");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
            }
            else
            {

                var contentStream = response.Content.ReadAsStringAsync().Result;
                List<Producto> listadoProductos = JsonConvert.DeserializeObject<List<Producto>>(contentStream);

                return listadoProductos;
            }
        }

        //BAJA PRODUCTO, DELETE

        public static void BajaProducto(string id, string idUsuario)
        {
            try
            {
                Dictionary<String, String> dict = new Dictionary<String, String>();
                dict.Add("id", id);
                dict.Add("idUsuario", idUsuario);

                var jsonRequest = JsonConvert.SerializeObject(dict);

                HttpResponseMessage response = WebHelper.DeleteConBody("/Proveedor/BajaProducto", jsonRequest);

            }
            catch (Exception ex)
            {
                throw new Exception("Verifique los datos ingresados");
            }
        }


        //get con traer por categoria //hay que filtrarlo de alguna forma 


        //NO OBLIGATORIO TODO LO DE ABAJO
        //
        //
        //

        //patch con modificar 

        public static void ModificarProducto(ProductosWS producto)
        {
            var jsonRequest = JsonConvert.SerializeObject(producto);
            HttpResponseMessage response = WebHelper.Patch("Producto/ModificarProducto", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
            }
        }

        //delete con baja


        //producto reactivat con patch

        public static void ReactivarProducto(ProductosWS producto)
        {
            var jsonRequest = JsonConvert.SerializeObject(producto);
            HttpResponseMessage response = WebHelper.Post("Proveedor/AgregarProveedor", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados. Error al agregar proveedor.");
            }
        }

        
    }
}
