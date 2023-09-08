using System.ComponentModel;

namespace Modelo
{

        public class Usuario
        {
            // Atributos privados
            private string nombre;
            private string apellido;
            private string username;
            private string password;
            private DateTime ultimoCambioPass;
            private int intentosCambioPass;
            private EstadoUsuario estado;
            private PerfilUsuario perfil;
            private string nuevoPass;// Aca agregue esta variable donde va a tomar la nueva pass
            


            // Constructor
            public Usuario(string nombre, string apellido, string username, PerfilUsuario perfil,string nuevopass)
            {
                this.nombre = nombre;
                this.apellido = apellido;
                this.Username = username;
                this.password = GenerarPasswordTemporal();
                this.ultimoCambioPass = DateTime.Now;
                this.intentosCambioPass = 0;
                this.estado = EstadoUsuario.INACTIVO;
                this.perfil = perfil;
                this.nuevoPass = nuevopass; // la nueva variable en el constructor


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
            //se va a necesitar acceder desde negocio para implementar la logica
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

            public PerfilUsuario Perfil
            {
                get { return perfil; }
                set { perfil = value; }
            }

            public int IntentosCambioPass
            {
                get { return intentosCambioPass; }
                private set { intentosCambioPass = value; }
            }

            
        // Métodos
        public bool SetPassword(string nuevopass) // aca cambie newpassword por nuevopass
            {
                // Validar que la pass tenga por lo menos una letra mayúscula y un número
                if (!nuevopass.Any(char.IsUpper) || !nuevopass.Any(char.IsDigit))
                {
                    throw new ArgumentException("La contraseña debe contener al menos una letra mayúscula y un número.");
                }

                // Validar que la nueva pass no sea igual a la anterior
                if (nuevopass == this.password)
                {
                    throw new ArgumentException("La nueva contraseña no puede ser igual a la anterior.");
                }

                // Validar que la pass tenga entre 8 y 15 caracteres
                if (nuevopass.Length < 8 || nuevopass.Length > 15)
                {
                    throw new ArgumentException("La contraseña debe tener entre 8 y 15 caracteres.");
                }

                this.password = nuevopass;
                this.ultimoCambioPass = DateTime.Now;
                this.intentosCambioPass = 0;
                return true;
            }

            public bool EsPasswordValida(string password)
            {
                // Validar si la pass venció
                if ((DateTime.Now - ultimoCambioPass).TotalDays > 30)
                {
                    throw new InvalidOperationException("La contraseña ha vencido.");
                }
                return this.password == password; //validar si es la pass correcta
            }

            public string GenerarPasswordTemporal()  //tendriamos que mejorar la logica despues
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

        public enum PerfilUsuario
        {
            ADMINISTRADOR,
            SUPERVISOR,
            VENDEDOR
        }
    }



  

  

