using AccesoDatos.Utilidades;
using Newtonsoft.Json;
using System.Web;
using System.Collections.Generic;
using Modelo;

namespace AccesoDatos
{
    public static class UsuarioDatos
    {
        static String usuarioAdmin = "70b37dc1-8fde-4840-be47-9ababd0ee7e5";


        public static List<UsuarioWS> ListarUsuarios()
        {

            HttpResponseMessage response = WebHelper.Get("Usuario/TraerUsuariosActivos?id=" + usuarioAdmin);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("verifique los datos ingresados");
            }
            else
            {
                var contentstream = response.Content.ReadAsStringAsync().Result;
                List<UsuarioWS> listadousuarios = JsonConvert.DeserializeObject<List<UsuarioWS>>(contentstream);
                return listadousuarios;

            }
        }
    }
}