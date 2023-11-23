using Modelo;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using AccesoDatos;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace Negocio
{
    public class GestorDeUsuarios
    {
        // Lista para guardar los usuarios de ejemplo
        private List<Usuario> usuarios = new List<Usuario>();
        private List<string> usuariosConIntentosFallidos = new List<string>();



        //public GestorDeUsuarios()
        //{
        //    List<UsuarioWS> listadoUsarios = UsuarioDatos.ListarUsuarios();
        //    foreach (UsuarioWS usr in listadoUsarios)
        //    {
        //        if (usr.host.Equals("1"))
        //        {
        //            this.usuarios.Add(new Vendedor(usr));
        //        }
        //        else if (usr.host.Equals("2"))
        //        {
        //            this.usuarios.Add(new Supervisor(usr));
        //        }
        //        else
        //        {
        //            this.usuarios.Add(new Administrador(usr));
        //        }
        //    }
        //}

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

        public string TipoDeUsuarioLogin(String idUsuario)
        {
            //Guid.Parse(idUsuario);

            List<Usuario> listadoUsarios = UsuarioDatos.ListarUsuarios();
            foreach (Usuario usr in listadoUsarios)
            {
                if (idUsuario == usr.Id.ToString("D"))
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

            //// Crear un objeto usuarioWS
            var nuevoUsuarioWS = new UsuarioWS
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

        public bool ReactivarUsuario (string idUsuarioReactivar, string idUsuarioActual)
        {
            try
            {
                UsuarioDatos.ReactivarUsuario(idUsuarioReactivar, idUsuarioActual);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //private string GetPerfilType(Usuario usuario)
        //{
        //    if (usuario is Administrador) return "Administrador";
        //    if (usuario is Supervisor) return "Supervisor";
        //    if (usuario is Vendedor) return "Vendedor";
        //    return null;
        //}


        public bool EstablecerContraseña(string nombreDeUsuario, string contraseña, string newPassword)
        {
            if (!newPassword.Any(char.IsUpper) || !newPassword.Any(char.IsDigit))
            {
                throw new ArgumentException("La contraseña debe contener al menos una letra mayúscula y un número.");
            }

            if (newPassword == contraseña)
            {
                throw new InvalidOperationException("La nueva contraseña no puede ser igual a la anterior.");
            }

            if (newPassword.Length < 8 || newPassword.Length > 15)
            {
                throw new ArgumentException("La contraseña debe tener entre 8 y 15 caracteres.");
            }

            if (newPassword.ToUpper() == nombreDeUsuario.ToUpper() || newPassword.ToUpper().Contains(nombreDeUsuario.ToUpper()))
            {
                throw new ArgumentException("La contraseña no debe contener el nombre de usuario.");
            }

            try
            {
                UsuarioDatos.CambiarContraseña(nombreDeUsuario, contraseña, newPassword);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }


        public List<Usuario> ObtenerListadoDeUsuarios()
        {
            //  la lista de usuarios desde el webservice
            List<Usuario> listadoUsuarios = UsuarioDatos.ListarUsuarios();

            return listadoUsuarios;
        }

        public List<Usuario> ObtenerListadoDeUsuariosVendedores()
        {
            //  la lista de usuarios desde el webservice
            List<Usuario> listadoUsuarios = UsuarioDatos.ListarUsuarios();

            // Filtrar la lista  solo los usuarios con usr.host == 1
            List<Usuario> usuariosVendedores = listadoUsuarios
                .Where(usr => usr.host == 1)
                .ToList();

            return usuariosVendedores;
        }


        public List<Usuario> ObtenerListadoDeUsuariosInactivos()
        {
            //  la lista de usuarios desde el webservice
            List<Usuario> listadoUsuarios = UsuarioDatos.ListarUsuarios();

            // Filtrar la lista  solo usuarios inactivos
            List<Usuario> usuariosInactivos = listadoUsuarios
                .Where(usr => usr.FechaBaja != null)
                .ToList();

            return usuariosInactivos;
        }

    }

}


