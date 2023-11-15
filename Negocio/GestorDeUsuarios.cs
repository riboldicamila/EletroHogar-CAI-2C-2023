using Modelo;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using AccesoDatos;
using System.Diagnostics.CodeAnalysis;

namespace Negocio
{
    public class GestorDeUsuarios
    {
        // Lista para guardar los usuarios de ejemplo
        private List<Usuario> usuarios = new List<Usuario>();
        private List<string> usuariosConIntentosFallidos = new List<string>();



        public GestorDeUsuarios()
        {
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

        public bool ListaDeControl(string nombreUsuario)
        {
            usuariosConIntentosFallidos.Add(nombreUsuario);
            int intentosFallidos = usuariosConIntentosFallidos.Count(u => u == nombreUsuario);

            if (intentosFallidos < 4)
            {
                usuariosConIntentosFallidos.Add(nombreUsuario);
                return true;
            }

            return false;
        }

        public void LimpiarListaDeControl(string nombreUsuario)
        {
            usuariosConIntentosFallidos.RemoveAll(u => u == nombreUsuario);
        }

        public string TipoDeUsuarioLogin(string idUsuario)
        {

            List<UsuarioWS> listadoUsarios = UsuarioDatos.ListarUsuarios();
            foreach (UsuarioWS usr in listadoUsarios)
            {
                if (usr.idUsuario == idUsuario)
                {
                    if (usr.host == 1)
                    {
                        return "vendedor";
                    }
                    else if (usr.host == 2)
                    {
                        return "supervisor";
                    }
                    else if (usr.host == 3)
                    {
                        return "administrador";

                    }

                }
            }

            return "";

        }

        public bool AgregarUsuario(string nombre, int host, int dni, string direccion, string telefono, string apellido,
        string email, string idUsuarioActual, string nombreUsuario, DateTime fechaNacimiento)
        {

            // Crear un objeto usuarioWS
            var nuevoUsuarioWS = new UsuarioWS
            {
                idUsuario = "0cdbc5a5-69d9-4ab8-8cb3-9932ce33f54a",
                host = host, //pasa segun opcion menu
                nombre = nombre,
                apellido = apellido,
                dni = dni,
                direccion = direccion,
                telefono = telefono,
                email = email,
                fechaNacimiento = fechaNacimiento,
                nombreUsuario = nombreUsuario,
                contraseña = "Temp1234"
            };

            try
            {
                UsuarioDatos.AgregarUsuario(nuevoUsuarioWS);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //public Usuario LogicaVieja(string username = "luism1234")
        //{
        //    return usuarios.Find(u => u == username);
        //}


        //private string GetPerfilType(Usuario usuario)
        //{
        //    if (usuario is Administrador) return "Administrador";
        //    if (usuario is Supervisor) return "Supervisor";
        //    if (usuario is Vendedor) return "Vendedor";
        //    return null;
        //}


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

        public void ValidarDireccion(string direccion)
        {
            if (string.IsNullOrEmpty(direccion) || !(direccion.Any(char.IsDigit)))
            {
                throw new ArgumentException("La direccion no puede estar vacía, debe tener por lo menos 2 caracteres y debe contener el numero de la calle.");
            }
        }

        public void ValidarTelefono(string telefono)
        {
            if (string.IsNullOrEmpty(telefono) || (telefono.All(char.IsDigit)) || (telefono.Length > 10))
            {
                throw new ArgumentException("El numero de telefono no puede estar vacío, debe contener máximo 10 numeros y solo puede contener dígitos del 0 al 9.");
            }

        }

        public void ValidarEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !(email.Contains("@")) || !(email.Contains(".com")))
            {
                throw new ArgumentException("Ingrese una dirección decorreo electrónco válida.");
            }

        }
        
        public void ValidarDni(string DNI)
        {
            if (string.IsNullOrEmpty(DNI) || DNI.
        }

        public bool EstablecerContraseña(Usuario usuario, string newPassword)
        {
            if (!newPassword.Any(char.IsUpper) || !newPassword.Any(char.IsDigit))
            {
                throw new ArgumentException("La contraseña debe contener al menos una letra mayúscula y un número.");
            }

            //if (newPassword == usuario.Password)
            //{
            //    throw new InvalidOperationException("La nueva contraseña no puede ser igual a la anterior.");
            //}

            //if (newPassword.Length < 8 || newPassword.Length > 15)
            //{
            //    throw new ArgumentException("La contraseña debe tener entre 8 y 15 caracteres.");
            //}

            //if (newPassword.ToUpper() == usuario.Username.ToUpper() || newPassword.ToUpper().Contains(usuario.Username.ToUpper()))
            //{
            //    throw new ArgumentException("La contraseña no debe contener el nombre de usuario.");
            //}

            //usuario.SetPassword(newPassword);
            return true;
        }

        public bool BajaUsuario(string nombre, string apellido, string username)
        {

            foreach (Usuario u in usuarios)
            {
                //if (u.Nombre == nombre && u.Apellido == apellido && u.Username == username)
                //{

                //    u.DeshabilitarUsuario();
                //    break;
                //}
            }

            return true;
        }

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            //lista los nombres de usuario ACTIVOS E INACTIVOS
            return usuarios;

        }

        //public List<Usuario> ObtenerUsuariosActivos()
        //{
        //    // Mostrar solo los nombres de usuarios que están en estado activo
        //    return usuarios.Where(u => u.Estado == EstadoUsuario.ACTIVO).ToList();
        //}


    }

}


