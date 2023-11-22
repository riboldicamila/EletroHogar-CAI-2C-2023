using AccesoDatos.Utilidades;
using Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net.Http;

namespace AccesoDatos
{
    public static class ProveedoresDatos
    {

        //GET para traer proveedores
        public static List<Proveedor> ListarProveedores()
        {
            HttpResponseMessage response = WebHelper.Get("Proveedor/TraerProveedores");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
            }
            else
            {

                var contentStream = response.Content.ReadAsStringAsync().Result;
                List<Proveedor> listadoProveedores = JsonConvert.DeserializeObject<List<Proveedor>>(contentStream);

                return listadoProveedores;
            }
        }

        //POST agregar
        public static void AltaProveedor (ProveedoresWS proveedor)
        {
            var jsonRequest = JsonConvert.SerializeObject(proveedor);
            HttpResponseMessage response = WebHelper.Post("Proveedor/AgregarProveedor", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados. Error al agregar proveedor.");
            }
        }


        //DELETE para baja
        public static void BajaProveedor(string id, string idUsuario)
        {
            try
            {
                Dictionary<String, String> dict = new Dictionary<String, String>();
                dict.Add("id", id);
                dict.Add("idUsuario", idUsuario);

                var jsonRequest = JsonConvert.SerializeObject(dict);

                HttpResponseMessage response = WebHelper.DeleteConBody("/Proveedor/BajaProveedor", jsonRequest);

            }
            catch (Exception ex)
            {
                throw new Exception("Verifique los datos ingresados");
            }
        }

        //PATCH modificar

        public static void ModificarProveedor(string id, string idUsuario, string nombre, string apellido, string email, string cuit)
        {
            try
            {
                Dictionary<String, String> dict = new Dictionary<String, String>();
                dict.Add("id", id);
                dict.Add("idUsuario", idUsuario);
                dict.Add("nombre", nombre);
                dict.Add("apellido", apellido);
                dict.Add("email", email);
                dict.Add("cuit", cuit);

                var jsonRequest = JsonConvert.SerializeObject(dict);

                HttpResponseMessage response = WebHelper.Patch("/Proveedor/ModificarProveedor", jsonRequest);

            }
            catch (Exception ex)
            {
                throw new Exception("Verifique los datos ingresados");
            }
        }



    }
}
