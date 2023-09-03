using Modelo;

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
            usuarios = new List<Usuario>
            {
                new Usuario("Juan", "Pérez", "juanp1234", PerfilUsuario.VENDEDOR),
                new Usuario("Ana", "Gómez", "anag1234", PerfilUsuario.SUPERVISOR),
                new Usuario("Luis", "Martínez", "luism1234", PerfilUsuario.ADMINISTRADOR)
            };

            // Estableciendo contraseñas de ejemplo
            usuarios[0].SetPassword("Pass1234");
            usuarios[1].SetPassword("Pass5678");
            usuarios[2].SetPassword("Pass9012");
        }

        public PerfilUsuario? Login(string username, string password)  // o devuelve un perfil de usuario o devuelve null
        {
            var usuario = usuarios.Find(u => u.Username == username && u.EsPasswordValida(password));
            return usuario?.Perfil;
        }

        // Método para obtener todos los usuarios (opcional, si necesitas listarlos en algún punto)
        public List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }

        public bool AgregarUsuario(string nombre, string apellido, string username, PerfilUsuario perfil)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                Console.WriteLine("El nombre no debe estar vacío.");
                return false;  
            }

            if (string.IsNullOrEmpty(apellido))
            {
                Console.WriteLine("El apellido no debe estar vacío.");
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
            else if (username.Contains(apellido))
            {
                Console.WriteLine("El nombre de usuario no debe contener el apellido.");
                return false;
            }

            var nuevoUsuario = new Usuario(nombre, apellido, username, perfil);
            usuarios.Add(nuevoUsuario);
            return true;
        }


        public IEnumerable<Usuario> ListarVendedores()
        {
            return usuarios.Where(u => u.Perfil == PerfilUsuario.VENDEDOR);
        }




    }
}