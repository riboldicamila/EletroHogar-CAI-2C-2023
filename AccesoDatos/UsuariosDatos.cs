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
    public static class UsuariosDatos
    {
        public static void AgregarUsuario(UsuarioWS usuario)
        {
            var jsonRequest = JsonConvert.SerializeObject(usuario);
            HttpResponseMessage response = WebHelper.Post("Usuario/AgregarUsuario", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados. Error al agregar usuario.");
            }
        }
    }
}
