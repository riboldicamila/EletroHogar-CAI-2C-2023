using Modelo;

namespace Negocio
{
    public class GestorDeUsuarios
    {
        // Lista para guardar los usuarios de ejemplo
        private List<Usuario> usuarios;

        public GestorDeUsuarios()
        {
            //Constructor 
            // Inicialización de la lista y generación de usuarios de ejemplo al instanciar el gestor. 
            // Usamos esta lista para harcodear usuarios y probar
            usuarios = new List<Usuario>
            {
                new Usuario("Juan", "Pérez", "juanp1234", PerfilUsuario.VENDEDOR),// aca tuve agregar un parametro mas por el constructor
                new Usuario("Ana", "Gómez", "anag1234", PerfilUsuario.SUPERVISOR),
                new Usuario("Luis", "Martínez", "luism1234", PerfilUsuario.ADMINISTRADOR)
            };

            // Estableciendo contraseñas de ejemplo
            usuarios[0].SetPassword("Pass1234");
            usuarios[1].SetPassword("Pass5678");
            usuarios[2].SetPassword("Pass9012");
        }

        public (PerfilUsuario? perfil, bool cambiarContrasena, Usuario usuario) Login(string username, string password)
        {
            var usuario = usuarios.Find(u => u.Username == username && u.EsPasswordValida(password));
            bool necesitaCambiarContrasena = usuario?.Password == "Temp1234";
            return (usuario?.Perfil, necesitaCambiarContrasena, usuario);
        }



        // Método para obtener todos los usuarios (opcional, si necesitas listarlos en algún punto)
        public List<Usuario> ObtenerUsuarios()
        {
            //lista los nombres de usuario
            usuarios.ForEach(u => { Console.WriteLine(u.Username); }) ;
            return usuarios;
            
       
        }

        public bool EstablecerContraseña(Usuario usuario, string newPassword)
        {
            if (!newPassword.Any(char.IsUpper) || !newPassword.Any(char.IsDigit))
            {
                Console.WriteLine("La contraseña debe contener al menos una letra mayúscula y un número.");
                return false;
            }

            if (newPassword == usuario.Password)
            {
                Console.WriteLine("La nueva contraseña no puede ser igual a la anterior.");
                return false;
            }

            if (newPassword.Length < 8 || newPassword.Length > 15)
            {
                Console.WriteLine("La contraseña debe tener entre 8 y 15 caracteres.");
                return false;
            }

            usuario.SetPassword(newPassword);
            return true;
        }


        public bool AgregarUsuario(string nombre, string apellido, string username, PerfilUsuario perfil) // Aca esta el nuevo parametro para Agregar al usuario nuevo
        {
            //password no agregada porque este metodo solo se usa para primera creación con static password. 
            if (!SonValidosLosDatos(nombre, apellido, username))
            {
                return false;
            }

            var nuevoUsuario = new Usuario(nombre, apellido, username,perfil);//Aca tambien esta agregado
            usuarios.Add(nuevoUsuario);
            Console.WriteLine("Usuario " + username +"agregado con exito");
            Console.WriteLine();
            return true;
        }


        private bool SonValidosLosDatos(string nombre, string apellido, string username) // Aca tambien 
        {
            //validaciones de NEGOCIO
            //validaciones propias de datos, deberian ser desde presentación
            if (string.IsNullOrEmpty(nombre) || nombre.Length <= 2 || nombre.Any(char.IsDigit))
            {
                Console.WriteLine("El nombre no puede estar vacío, debe tener por lo menos 2 caracteres y no puede contener números.");
                return false;
            }

            if (string.IsNullOrEmpty(apellido) || apellido.Length <= 2 || apellido.Any(char.IsDigit))
            {
                Console.WriteLine("El apellido no puede estar vacío, debe tener por lo menos 2 caracteres y no puede contener números.");
                return false;
            }

            if (username.Length < 8)
            {
                Console.WriteLine("El nombre de usuario debe tener mínimo 8 caracteres.");
                return false;
            }
            else if (username.Length > 15)
            {
                Console.WriteLine("El nombre de usuario debe tener un máximo de 15 caracteres.");
                return false;
            }
            else if (username.Contains(nombre))
            {
                Console.WriteLine("El nombre de usuario no debe contener el apellido.");
                return false;
            }
            else if (username.Contains(apellido))
            {
                Console.WriteLine("El nombre de usuario no debe contener el apellido.");
                return false;
            }

            return true;
        }

        public IEnumerable<Usuario> ListarVendedores()
        {
            return usuarios.Where(u => u.Perfil == PerfilUsuario.VENDEDOR);
        }




    }
}