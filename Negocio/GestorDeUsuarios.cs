using Modelo;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using AccesoDatos;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

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
            //Guid.Parse(idUsuario);

            List<UsuarioWS> listadoUsarios = UsuarioDatos.ListarUsuarios();
            foreach (UsuarioWS usr in listadoUsarios)
            {
                if (idUsuario == usr.id.ToString("D"))
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

            return "error";

        }

        public bool AgregarUsuario(string nombre, int host, int dni, string direccion, string telefono, string apellido,
        string email, string idUsuarioActual, string nombreUsuario, DateTime fechaNacimiento)
        {

            //// Crear un objeto usuarioWS
            var nuevoUsuarioWS = new Usuario
            {
                idUsuario = idUsuarioActual,
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
            return false;
        }

        public bool BajaUsuarios(string idUsuarioBaja, string idUsuario)
        {
            try
            {
                UsuarioDatos.BorrarUsuario(idUsuarioBaja, idUsuario);

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





        //METODO0S VALIDACIONES movidos a VALIDACIONES
        

       

        

       
        
        
       
        
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


