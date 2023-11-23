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

        // Constructor
        public Usuario()
        {
        }


        public Usuario(UsuarioWS usuarioWS)
        {
            this.idUsuario = usuarioWS.Id;
            this.host = usuarioWS.host;
            this.nombre = usuarioWS.nombre;
            this.apellido = usuarioWS.apellido;
            this.dni = usuarioWS.dni;
            this.direccion = usuarioWS.direccion;
            this.telefono = usuarioWS.telefono;
            this.email = usuarioWS.email;
            this.fechaNacimiento = usuarioWS.fechaNacimiento;
            this.nombreUsuario = usuarioWS.nombreUsuario;
            this.contraseña = usuarioWS.contraseña;
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


        override public String ToString()
        {
            return this.Id+ " - "+ this.nombre + " - " + this.apellido;
        }

    }


}







