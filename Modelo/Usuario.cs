using System.ComponentModel;

namespace Modelo
{

    public abstract class Usuario
    {
        // Atributos privados
        public int host { get; set; }
        public string idUsuarioActual { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime? FechaNacimiento { get; set; }  // ? permite null
        public DateTime? FechaBaja { get; set; }  // ? permite null
        public string NombreUsuario { get; set; }
        public int DNI { get; set; }
        public string contraseña { get; set; }
        private string nuevoPass;


        // Constructor
        public Usuario(UsuarioWS usuarioWS)
        {
            this.idUsuarioActual = usuarioWS.idUsuario;
            this.host= usuarioWS.host;
            this.nombre = usuarioWS.nombre;
            this.apellido = usuarioWS.apellido;
            this.DNI = usuarioWS.dni;
            this.Direccion = usuarioWS.direccion;
            this.Telefono= usuarioWS.telefono;
            this.Email = usuarioWS.email;
            this.FechaNacimiento = usuarioWS.fechaNacimiento;
            this.NombreUsuario = usuarioWS.nombreUsuario;
            this.contraseña = usuarioWS.contraseña;
  
        }

        public Usuario(string nombre, string apellido, string username)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.NombreUsuario = username;
            this.contraseña = GenerarPasswordTemporal();
     
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







