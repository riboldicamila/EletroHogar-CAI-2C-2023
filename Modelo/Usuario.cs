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

            // Constructor
            public Usuario(string nombre, string apellido, string username, PerfilUsuario perfil)
            {
                this.nombre = nombre;
                this.apellido = apellido;
                this.Username = username; // Usa la propiedad para validarlo
                this.password = GenerarPasswordTemporal();
                this.ultimoCambioPass = DateTime.Now;
                this.intentosCambioPass = 0;
                this.estado = EstadoUsuario.INACTIVO;
                this.perfil = perfil;
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
                    if (value.Length < 8 || value.Length > 15 || value.Contains(nombre) || value.Contains(apellido))
                        throw new ArgumentException("El nombre de usuario no es válido.");
                    username = value;
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
            public bool SetPassword(string newPassword)
            {
                // Validar que la pass tenga por lo menos una letra mayúscula y un número
                if (!newPassword.Any(char.IsUpper) || !newPassword.Any(char.IsDigit))
                {
                    throw new ArgumentException("La contraseña debe contener al menos una letra mayúscula y un número.");
                }

                // Validar que la nueva pass no sea igual a la anterior
                if (newPassword == this.password)
                {
                    throw new ArgumentException("La nueva contraseña no puede ser igual a la anterior.");
                }

                // Validar que la pass tenga entre 8 y 15 caracteres
                if (newPassword.Length < 8 || newPassword.Length > 15)
                {
                    throw new ArgumentException("La contraseña debe tener entre 8 y 15 caracteres.");
                }

                this.password = newPassword;
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



  

  

