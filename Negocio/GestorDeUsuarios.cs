using Modelo;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using AccesoDatos;

namespace Negocio
{
    public class GestorDeUsuarios
    {
        // Lista para guardar los usuarios de ejemplo
        private List<Usuario> usuarios = new List<Usuario>();



        public GestorDeUsuarios()
        {
            // Inicialización de la lista y generación de usuarios de ejemplo al instanciar el gestor. 
            // Usamos esta lista para harcodear usuarios y probar

            usuarios = new List<Usuario>
            {
                new Vendedor("Juan", "Pérez", "juanp1234"),
                new Supervisor("Ana", "Gómez", "anag1234"),
                new Administrador("Luis", "Martínez", "luism1234")
            };

            usuarios[0].SetPassword("Pass1234");
            usuarios[1].SetPassword("Pass5678");
            usuarios[2].SetPassword("Pass9012");


            List<UsuarioWS> listadoUsarios = UsuarioDatos.ListarUsuarios();
            foreach (UsuarioWS usr in listadoUsarios)
            {
                if (usr.host.Equals("1"))
                {
                    this.usuarios.Add(new Vendedor(usr));
                }
                else if (usr.host.Equals("2"))
                {
                    this.usuarios.Add(new Supervisor(usr));
                }
                else
                {
                    this.usuarios.Add(new Administrador(usr));
                }
            }
        }

        public String Login(Login login)
        {
            String idUsuario = UsuarioDatos.Login(login);
            return idUsuario;
        }


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
            try
            {
                //crear usuario 

                ValidarNombre(nuevoUsuario.Nombre);
                ValidarApellido(nuevoUsuario.Apellido);
                ValidarUsername(nuevoUsuario.Nombre, nuevoUsuario.Apellido, nuevoUsuario.Username);

                UsuarioWS usuarioWS = null;
                if (nuevoUsuario is Vendedor)
                {
                    usuarioWS = ConvertirVendedorAUsuarioWS((Vendedor)nuevoUsuario);
                }
                else if (nuevoUsuario is Supervisor)
                {
                    usuarioWS = ConvertirSupervisorAUsuarioWS((Supervisor)nuevoUsuario);
                }

                if (usuarioWS != null)
                {
                    UsuarioDatos.AgregarUsuario(usuarioWS);
                    return true;
                }

                return false;
            }
            catch (ArgumentException ex)
            {
                throw ex;  
            }
        }


        public UsuarioWS ConvertirSupervisorAUsuarioWS(Supervisor supervisor)
        {
            UsuarioWS supervisorWS = new UsuarioWS
            {
                id = supervisor.Id,
                nombre = supervisor.Nombre,
                apellido = supervisor.Apellido,
                dni = supervisor.DNI,
                usuario = supervisor.Username,
                host = 2 //host supervisor 
            };

            return supervisorWS;
        }

        public UsuarioWS ConvertirVendedorAUsuarioWS(Vendedor vendedor)
        {
            UsuarioWS usuarioWS = new UsuarioWS
            {
                id = vendedor.Id,
                nombre = vendedor.Nombre,
                apellido = vendedor.Apellido,
                dni = vendedor.DNI,
                usuario = vendedor.Username,
                host = 1 // 1, vendedor
            };

            return usuarioWS;
        }


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
                else if (u.Username == username && u.Password != password)
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