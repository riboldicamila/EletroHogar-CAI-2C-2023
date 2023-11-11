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

        public static List<ProductosWS> TraerProductos()
        {
            HttpResponseMessage response = WebHelper.Get("Producto/TraerProductos");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
            }
            else
            {

                var contentStream = response.Content.ReadAsStringAsync().Result;
                List<ProductosWS> listadoProductos = JsonConvert.DeserializeObject<List<ProductosWS>>(contentStream);

                return listadoProductos;
            }
        }


        //get con traer por categoria //hay que filtrarlo de alguna forma 

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
