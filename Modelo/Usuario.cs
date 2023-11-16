using System.ComponentModel;

namespace Modelo
{

    public class Usuario
    {
        // Atributos privados
        public Guid Id { get; set; }
        public string idUsuario { get; set; }
        public int host { get; set; }
        public string nombre;
        public string apellido;
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public DateTime? fechaNacimiento { get; set; }  // ? permite null
        public DateTime? FechaBaja { get; set; }  // ? permite null
        public string nombreUsuario;
        public int dni { get; set; }
        public string contraseña;
        private string nuevoPass;



        // Constructor
        public Usuario()
        {
        }


        public Usuario(UsuarioWS usuarioWS)
        {
            this.nombre = usuarioWS.nombre;
            this.apellido = usuarioWS.apellido;
            this.Id = usuarioWS.id;
            this.nombreUsuario = usuarioWS.usuario;
        }

        public Usuario(string idUsuarioActual, string nombre, string apellido, string username, int dni, string direccion,
            string telefono, string email, DateTime fechaNacimiento, string nombreUsuario, string contraseña="Temp1234")
        {
            this.idUsuario= idUsuarioActual;
            this.host = host;
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.direccion = direccion;
            this.telefono = telefono;
            this.email = email;
            this.fechaNacimiento = fechaNacimiento;
            this.nombreUsuario = nombreUsuario;
            this.contraseña = contraseña;
          
        }

        // Propiedades
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        //public string Username
        //{
        //    get { return username; }
        //    set
        //    {
        //        username = value;
        //    }
        //}

        //public string Password
        //{
        //    get { return password; }
        //    set
        //    {
        //        password = value;
        //    }
        //}

        public string NuevoPass // nueva variable para la nueva pass
        {

            get { return nuevoPass; }
            set
            {
                nuevoPass = value;
            }
        }


        // Métodos
        //public void SetPassword(string newPassword)
        //{
        //    this.password = newPassword;
        //    this.ultimoCambioPass = DateTime.Now;
        //    this.intentosCambioPass = 0;

        //    // Si el usuario pone una nueva contraseña, lo marcamos como ACTIVO
        //    this.estado = EstadoUsuario.ACTIVO;
        //}


        public string GenerarPasswordTemporal()
        {
            return "Temp1234";

        }


        override
        public String ToString()
        {
            return this.nombre + " - " + this.apellido;
        }
    }


}







