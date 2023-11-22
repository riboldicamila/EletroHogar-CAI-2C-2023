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
    public static class ClienteDatos
    {

        //post agregar

        public static void AgregarCliente(ClienteWS cliente)
        {
            var jsonRequest = JsonConvert.SerializeObject(cliente);
            HttpResponseMessage response = WebHelper.Post("Cliente/AgregarCliente", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados. Error al agregar cliente.");
            }
        }


        //get cliente 

        public static List<Cliente> DevolverClientes()
        {
            HttpResponseMessage response = WebHelper.Get("Cliente/GetClientes");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
            }
            else
            {

                var contentStream = response.Content.ReadAsStringAsync().Result;
                List <Cliente> listadoCliente = JsonConvert.DeserializeObject<List<Cliente>>(contentStream);

                return listadoCliente;
            }
        }

        //patch

        public static void ModificacionCliente (string id, string direccion, string telefono, string email)
        {
            try
            {
                Dictionary<String, String> dict = new Dictionary<String, String>();
                dict.Add("id", id);
                dict.Add("direccion", direccion);
                dict.Add("telefono", telefono);
                dict.Add("email", email);


                var jsonRequest = JsonConvert.SerializeObject(dict);

                HttpResponseMessage response = WebHelper.Patch("/Cliente/PatchCliente", jsonRequest);

            }
            catch (Exception ex)
            {
                throw new Exception("Verifique los datos ingresados, error al modificar.");
            }
        }

        //check si cliente es nuevo, get SOLO 1

        public static Cliente BusquedaPorCliente(string idCliente)
        {
            string urlWithId = "/api/Cliente/GetCliente?id=" + idCliente;
            HttpResponseMessage response = WebHelper.Get(urlWithId);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
            }
            else
            {

                var contentStream = response.Content.ReadAsStringAsync().Result;
                Cliente clienteNuevo = JsonConvert.DeserializeObject<Cliente>(contentStream);

                return clienteNuevo;
            }
        }



        //delete con baja




        //patch con reactivar

        public static void ReactivarCliente(ClienteWS cliente)
        {
            var jsonRequest = JsonConvert.SerializeObject(cliente);
            HttpResponseMessage response = WebHelper.Patch("Cliente/ReactivarCliente", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
            }

        }
    }
}
