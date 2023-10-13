using System.ComponentModel;

namespace Modelo
{

        public abstract class Usuario
        {
            // Atributos privados
            private string nombre;
            private string apellido;
            private string username;
            private string password;
            private DateTime ultimoCambioPass;
            private int intentosCambioPass;
            private EstadoUsuario estado;
            private string nuevoPass;
            


            // Constructor
            public Usuario(string nombre, string apellido, string username)
            {
                this.nombre = nombre;
                this.apellido = apellido;
                this.Username = username;
                this.password = GenerarPasswordTemporal();
                this.ultimoCambioPass = DateTime.Now;
                this.intentosCambioPass = 0;
                this.estado = EstadoUsuario.INACTIVO;

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

            public string Username
            {
                get { return username; }
                set
                {
                    username = value;
                }
            }

            public string Password
            {
                get { return password; }
                set 
                { 
                    password = value; 
                }
            }

            public string NuevoPass // nueva variable para la nueva pass
            {
            
                get { return nuevoPass; }
                set
                {
                 nuevoPass = value;
                }
            }



            public DateTime UltimoCambioPass
                {
                    get { return ultimoCambioPass; }
                    private set { ultimoCambioPass = value; }  //solo se puede cambiar dentro de la clase Usuario
                }

                public EstadoUsuario Estado
                {
                    get { return estado; }
                    set { estado = value; }
                }


                public int IntentosCambioPass
                {
                    get { return intentosCambioPass; }
                    private set { intentosCambioPass = value; }
                }


        // Métodos
        public void SetPassword(string newPassword)
        {
            this.password = newPassword;
            this.ultimoCambioPass = DateTime.Now;
            this.intentosCambioPass = 0;

            // Si el usuario pone una nueva contraseña, lo marcamos como ACTIVO
            this.estado = EstadoUsuario.ACTIVO;
        }


        public string GenerarPasswordTemporal() 
            {
                  return "Temp1234";
            
            }


            public void DeshabilitarUsuario()
            {
                    this.estado = EstadoUsuario.INACTIVO;
            }

            public void HabilitarUsuario()
            {
                this.estado = EstadoUsuario.ACTIVO;
            }
        }

        public enum EstadoUsuario
        {
            INACTIVO,
            ACTIVO
        }


    public class Administrador : Usuario
    {
        public Administrador(string nombre, string apellido, string username) : base(nombre, apellido, username)
        {
            //el base llama al constructor de la abstracta
        }

    }

    public class Supervisor : Usuario
    {
        public Supervisor(string nombre, string apellido, string username) : base(nombre, apellido, username)
        {
       
        }

    
    }

    public class Vendedor : Usuario
    {
        public Vendedor(string nombre, string apellido, string username) : base(nombre, apellido, username)
        {
            
        }


    }







}









