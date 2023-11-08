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
    public static class VentasDatos
    {
        //POST agregar venta

        public static void AltaProveedor(VentasWS venta)
        {
            var jsonRequest = JsonConvert.SerializeObject(venta);
            HttpResponseMessage response = WebHelper.Post("Venta/AgregarVenta", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados. Error al agregar proveedor.");
            }
        }


        //GET para traer ventas

        public static List<VentasWS> ListarVentas()
        {
            HttpResponseMessage response = WebHelper.Get("Venta/GetVenta");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
            }
            else
            {

                var contentStream = response.Content.ReadAsStringAsync().Result;
                List<VentasWS> listadoVentas = JsonConvert.DeserializeObject<List<VentasWS>>(contentStream);

                return listadoVentas;
            }
        }


        //GET para ventas por clientes


        //PATCH para devolver ventas

        public static void DevolverVenta(VentasWS venta)
        {
            var jsonRequest = JsonConvert.SerializeObject(venta);
            HttpResponseMessage response = WebHelper.Patch("Venta/DevolverVenta", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
            }
        }



    }
}
