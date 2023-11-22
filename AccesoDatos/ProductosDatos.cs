using AccesoDatos.Utilidades;
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


        //get con traer por categoria 

        public static List<Producto> ListarProductoCategoria(int categoria)
        {
            string urlWithId = "/Producto/TraerProductosPorCategoria?catnum=" + categoria;
            HttpResponseMessage response = WebHelper.Get(urlWithId);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
            }
            else
            {

                var contentStream = response.Content.ReadAsStringAsync().Result;
                List<Producto> productoCategoria = JsonConvert.DeserializeObject<List<Producto>>(contentStream);

                return productoCategoria;
            }
        }


        //producto reactivat con patch 

        public static void ReactivarProducto(string idProducto, string idUsuarioActual)
        {
            Dictionary<String, String> map = new Dictionary<String, String>();
            map.Add("id", idProducto);
            map.Add("idUsuario", idUsuarioActual);

            var jsonRequest = JsonConvert.SerializeObject(map);

            HttpResponseMessage response = WebHelper.Patch("/Producto/ReactivarProducto", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
            }

        }


    }
}
