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


        //get cliente //DEVOLVER SOLO 1 CLIENTE CREO

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

        public static void ModificacionCliente(ClienteWS cliente)
        {
            var jsonRequest = JsonConvert.SerializeObject(cliente);
            HttpResponseMessage response = WebHelper.Patch("Cliente/PatchCliente", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
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
