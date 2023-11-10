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


        //POST para login
        public static string Login(Login login)
        {
            var jsonRequest = JsonConvert.SerializeObject(login);

            HttpResponseMessage response = WebHelper.Post("Usuario/Login", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
            }

            var reader = new StreamReader(response.Content.ReadAsStream());

            String respuesta = reader.ReadToEnd();

            return respuesta;
        }


        //POST para agregar usuario

        public static void AgregarUsuario(UsuarioWS usuario)
        {
            var jsonRequest = JsonConvert.SerializeObject(usuario);
            HttpResponseMessage response = WebHelper.Post("Usuario/AgregarUsuario", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados. Error al agregar usuario.");
            }
        }


        //GET para traer usuarios
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


        //PATCH cambiar contraseña

        public static string CambiarContraseña(string nombreUsuario, string contraseña, string contraseñaNueva)
        {
            Dictionary<String, String> map = new Dictionary<String, String>();
            map.Add("nombreUsuario", nombreUsuario);
            map.Add("contraseña", contraseña);
            map.Add("contraseñaNueva", contraseñaNueva);

            var jsonRequest = JsonConvert.SerializeObject(map);

            HttpResponseMessage response = WebHelper.Patch("Usuario/CambiarContraseña", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
            }

            var reader = new StreamReader(response.Content.ReadAsStream());

            String respuesta = reader.ReadToEnd();

            return respuesta;
        }


        //DELETE para baja de usuario

        public static void BorrarUsuario(string idUsuario, string idUsuarioMaster)
        {
            Dictionary<String, String> map = new Dictionary<String, String>();
            map.Add("id", idUsuario);
            map.Add("idUsuario", idUsuarioMaster);

            var jsonRequest = JsonConvert.SerializeObject(map);

            HttpResponseMessage response = WebHelper.DeleteConBody("Usuario/BajaUsuario", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
            }

        }


        //PATCH para reactivar usuario


    }
}