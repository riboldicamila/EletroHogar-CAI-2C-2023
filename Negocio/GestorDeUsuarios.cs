﻿using Modelo;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Negocio
{
    public class GestorDeUsuarios
    {
        // Lista para guardar los usuarios de ejemplo
        private List<Usuario> usuarios;

        public GestorDeUsuarios()
        {
            // Inicialización de la lista y generación de usuarios de ejemplo al instanciar el gestor. 
            // Usamos esta lista para harcodear usuarios y probar

            usuarios = new List<Usuario>();

            // Deserializa usuarios.json a un JArray
            JArray usuariosJson = JArray.Parse(File.ReadAllText("../../../AccesoDatos/usuarios.json"));

            // Recorrer cada objeto en el JArray y crear una instancia de la clase correspondiente en base al atributo "tipo"

            foreach (JObject usuarioJson in usuariosJson)
            {

//                Console.WriteLine(usuariosJson[1]["Tipo"].Value<string>());

                string tipo = usuarioJson["Tipo"]?.Value<string>() ?? throw new ArgumentException("Tipo de usuario no encontrado");

                switch (tipo)
                {
                    case "Vendedor":
                        usuarios.Add(usuarioJson.ToObject<Vendedor>());
                        break;
                    case "Supervisor":
                        usuarios.Add(usuarioJson.ToObject<Supervisor>());
                        break;
                    case "Administrador":
                        usuarios.Add(usuarioJson.ToObject<Administrador>());
                        break;
                    default:
                        throw new ArgumentException($"Tipo de usuario desconocido: {tipo}");
                }
            }
        }



        
        /*
        
        
            {
                new Vendedor("Juan", "Pérez", "juanp1234"),
                new Supervisor("Ana", "Gómez", "anag1234"),
                new Administrador("Luis", "Martínez", "luism1234")
            };

            usuarios[0].SetPassword("Pass1234");
            usuarios[1].SetPassword("Pass5678");
            usuarios[2].SetPassword("Pass9012");

        }

        */

        public (string perfil, bool necesitaCambiarContrasena, Usuario usuarioActual) Login(string username, string password)
        {
            var usuario = usuarios.Find(u => u.Username == username);
            bool requiereNuevaContrasena = false;

            if (usuario != null)
            {
                // Validar si la contraseña es correcta
                if (usuario.Password != password)
                {
                    return (perfil: null, necesitaCambiarContrasena: false, usuarioActual: null);
                }

                // Verificar si el usuario esta inactivo //LO HABIAN SACADO 
                if (usuario.Estado == EstadoUsuario.INACTIVO && usuario.Password != "Temp1234")
                {
                    throw new InvalidOperationException("El usuario está inactivo.");
                }

                // Validar si la contraseña esta vencida o es la temporal
                requiereNuevaContrasena = (DateTime.Now - usuario.UltimoCambioPass).TotalDays > 30 || usuario.Password == "Temp1234";

                string perfil = GetPerfilType(usuario);

                return (perfil: perfil, necesitaCambiarContrasena: requiereNuevaContrasena, usuarioActual: usuario);
            }

            return (perfil: null, necesitaCambiarContrasena: false, usuarioActual: null);
        }


        private string GetPerfilType(Usuario usuario)
        {
            if (usuario is Administrador) return "Administrador";
            if (usuario is Supervisor) return "Supervisor";
            if (usuario is Vendedor) return "Vendedor";
            return null;
        }


        //METODO0S VALIDACIONES
        public void ValidarNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre) || nombre.Length <= 2 || nombre.Any(char.IsDigit))
            {
                throw new ArgumentException("El nombre no puede estar vacío, debe tener por lo menos 2 caracteres y no puede contener números.");
            }
        }

        public void ValidarApellido(string apellido)
        {
            if (string.IsNullOrEmpty(apellido) || apellido.Length < 2 || apellido.Any(char.IsDigit))
            {
                throw new ArgumentException("El apellido no puede estar vacío, debe tener por lo menos 2 caracteres y no puede contener números.");
            }
        }

        public void ValidarUsername(string nombre, string apellido, string username)
        {
            if (username.Length < 8)
            {
                throw new ArgumentException("El nombre de usuario debe tener mínimo 8 caracteres.");
            }
            else if (username.Length > 15)
            {
                throw new ArgumentException("El nombre de usuario debe tener un máximo de 15 caracteres.");
            }
            else if (username.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0 ||
                     username.IndexOf(apellido, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                throw new ArgumentException("El nombre de usuario no debe contener el nombre o el apellido.");
            }
        }

        public bool EstablecerContraseña(Usuario usuario, string newPassword)
        {
            if (!newPassword.Any(char.IsUpper) || !newPassword.Any(char.IsDigit))
            {
                throw new ArgumentException("La contraseña debe contener al menos una letra mayúscula y un número.");
            }

            if (newPassword == usuario.Password)
            {
                throw new InvalidOperationException("La nueva contraseña no puede ser igual a la anterior.");
            }

            if (newPassword.Length < 8 || newPassword.Length > 15)
            {
                throw new ArgumentException("La contraseña debe tener entre 8 y 15 caracteres.");
            }

            if (newPassword.ToUpper() == usuario.Username.ToUpper() || newPassword.ToUpper().Contains(usuario.Username.ToUpper()))
            {
                throw new ArgumentException("La contraseña no debe contener el nombre de usuario.");
            }

            usuario.SetPassword(newPassword);
            return true;
        }



        // METODOS
        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            //lista los nombres de usuario ACTIVOS E INACTIVOS
            return usuarios;
           
        }

        public List<Usuario> ObtenerUsuariosActivos()
        {
            // Mostrar solo los nombres de usuarios que están en estado activo
            return usuarios.Where(u => u.Estado == EstadoUsuario.ACTIVO).ToList();
        }



        public bool AgregarUsuario(Usuario nuevoUsuario)
        {
            usuarios.Add(nuevoUsuario);
            return true;
        }



        //public IEnumerable<Usuario> ListarVendedores()
        //{
        //    return usuarios.Where(u => u.Perfil == PerfilUsuario.VENDEDOR);
        //}

        public bool BajaUsuario(string nombre, string apellido, string username) 
        {

            foreach (Usuario u in usuarios)
            {
                if (u.Nombre == nombre && u.Apellido == apellido && u.Username == username)
                {

                    u.DeshabilitarUsuario();
                    break;
                }
            }

            return true;
        }


        //HAY QUE REVISAR ESTE METODO, LOS CONSOLE.WRITE SOBRE CAPA PRESENTACIÓN
        public bool Intentosfallidos(ref string username, ref string password)
        {
            int count;

            foreach (Usuario u in usuarios)
            {
                if (u.Username == username && u.Password == password)
                {
                    return true;

                }
                else if (u.Username == username && u.Password !=password)
                {
                    string passinactivo;
                    count = 0;
                    do
                    {
                        Console.WriteLine("Vuelva a ingresar la contraseña:");
                        password = Console.ReadLine();
                        if (password == u.Password)
                        {
                            return true;
                        }



                        count = count + 1;
                    }
                    while (count < 2);
                    passinactivo = password;
                    Console.WriteLine("Su Usuario quedo Inactivo");
                    u.DeshabilitarUsuario();
                    break;
                    
                }
            }

            return true;
        }

    }


}
