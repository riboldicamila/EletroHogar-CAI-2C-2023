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

        public static void AgregarVenta(Ventas venta)
        {
            var jsonRequest = JsonConvert.SerializeObject(venta);
            HttpResponseMessage response = WebHelper.Post("Venta/AgregarVenta", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados. Error al agregar proveedor.");
            }
        }

        //PATCH para devolver ventas
        public static void DevolverVenta(string id, string idUsuario)
        {
            try
            {
                Dictionary<String, String> dict = new Dictionary<String, String>();
                dict.Add("id", id);
                dict.Add("idUsuario", idUsuario);

                var jsonRequest = JsonConvert.SerializeObject(dict);

                HttpResponseMessage response = WebHelper.DeleteConBody("Venta/DevolverVenta", jsonRequest);

            }
            catch (Exception ex)
            {
                throw new Exception("Verifique los datos ingresados");
            }
        }


        //GET para traer ventas

        public static List<VentasWS> BuscarVentasPorCliente(string idCliente)
        {
            string urlWithId = "Venta/GetVentaByCliente?idCliente=" + idCliente;
            HttpResponseMessage response = WebHelper.Get(urlWithId);

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






    }
}
