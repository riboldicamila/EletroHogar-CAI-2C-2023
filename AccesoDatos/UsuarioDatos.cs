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

        //POST para agregar usuario

        //public static void AgregarUsuario(UsuarioWS usuario)
        //{
        //    var jsonRequest = JsonConvert.SerializeObject(usuario);
        //    HttpResponseMessage response = WebHelper.Post("Usuario/AgregarUsuario", jsonRequest);

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        throw new Exception("Verifique los datos ingresados. Error al agregar usuario.");
        //    }
        //}


        //PATCH cambiar contraseña


        //POST para login

        //DELETE para baja de usuario

        //PATCH para reactivar usuario


    }
}