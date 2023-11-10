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
        public static void BajaProveedor(object requestData)
        {
            try
            {
                string jsonRequest = JsonConvert.SerializeObject(requestData);
                HttpResponseMessage response = WebHelper.DeleteConBody("/Proveedor/BajaProveedor", jsonRequest);

            }
            catch (Exception ex)
            {
                throw new Exception("Verifique los datos ingresados");
            }
        }


        //public static void BajaProveedor(ProveedoresWS proveedor)
        //{
        //    var jsonRequest = JsonConvert.SerializeObject(proveedor);
        //    HttpResponseMessage response = WebHelper.DeleteConBody("/Proveedor/BajaProveedor", jsonRequest);

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        throw new Exception("Verifique los datos ingresados");
        //    }
        //}

        //PATCH modificar
        public static void ModificacionProveedor(ProveedoresWS proveedor)
        {
            var jsonRequest = JsonConvert.SerializeObject(proveedor);
            HttpResponseMessage response = WebHelper.Patch("Proveedor/ModificarProveedor", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
            }
        }





    }
}
