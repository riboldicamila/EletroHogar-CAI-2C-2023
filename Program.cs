using Negocio;
using Modelo; //solo para usar PerfilUsuario, no deberiamos llamar nunca  a Usuario directamente acá, siempre sería a través de GestordeUsuarios
using System.Timers;
using System.Security.Cryptography.X509Certificates;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuConsola menu = new MenuConsola();
            menu.Iniciar();
        }
    }

    public class MenuConsola
    {
        private GestorDeUsuarios gestorUsuarios = new GestorDeUsuarios();
        

        public void Iniciar()
        {
            Console.WriteLine("Bienvenido al sistema");

            while (true)
            {
                Console.WriteLine("Ingrese su nombre de usuario:");
                var username = Console.ReadLine();

                Console.WriteLine("Ingrese su contraseña:");
                var password = Console.ReadLine();

                // Usamos el gestor de usuarios para autenticar
                var perfil = gestorUsuarios.Login(username, password);

                if (perfil.HasValue)
                {
                    MostrarMenu(perfil.Value);
                    return;
                }
                else
                {
                    Console.WriteLine("Credenciales inválidas.");
                    Console.WriteLine();
                    Console.WriteLine("1. Volver a intentarlo");
                    Console.WriteLine("2. Salir");
                    Console.Write("Ingrese su opción: ");

                    var opcion = Console.ReadLine();
                    Console.WriteLine();

                    if (opcion == "2")
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }
        
        private void MostrarMenu(PerfilUsuario perfil)
        {
           /* while (true)
            {*/
                Console.Clear();
                Console.WriteLine($"Menu de {perfil.ToString()}");

                switch (perfil)
                {
                    case PerfilUsuario.VENDEDOR:
                        Console.WriteLine("1. Venta");
                        Console.WriteLine("2. Reporte de ventas por vendedor");
                        Console.WriteLine("3. Salir");
                        break;

                    case PerfilUsuario.SUPERVISOR:
                        Console.WriteLine("1. Alta de Productos");
                        Console.WriteLine("2. Modificación de Productos");
                        Console.WriteLine("3. Baja de Productos");
                        Console.WriteLine("4. Devolución");
                        Console.WriteLine("5. Reporte de stock crítico");
                        Console.WriteLine("6. Reporte de ventas por vendedor");
                        Console.WriteLine("7. Reporte de productos más vendidos por categoría");
                        Console.WriteLine("8. Salir");
                        break;

                    case PerfilUsuario.ADMINISTRADOR:
                        Console.WriteLine("1. Alta de usuarios Supervisores");
                        Console.WriteLine("2. Modificación de usuarios Supervisores");
                        Console.WriteLine("3. Baja de usuarios Supervisores");
                        Console.WriteLine("4. Alta de usuarios Vendedores");
                        Console.WriteLine("5. Modificación de usuarios Vendedores");
                        Console.WriteLine("6. Baja de usuarios Vendedores");
                        Console.WriteLine("7. Alta de Proveedores");
                        Console.WriteLine("8. Modificación de Proveedores");
                        Console.WriteLine("9. Baja de Proveedores");
                        Console.WriteLine("10. Alta de Productos");
                        Console.WriteLine("11. Modificación de Productos");
                        Console.WriteLine("12. Baja de Productos");
                        Console.WriteLine("13. Reporte de stock crítico");
                        Console.WriteLine("14. Reporte de ventas por vendedor");
                        Console.WriteLine("15. Reporte de productos más vendidos por categoría");
                        Console.WriteLine("16. Salir");
                        break;
                }
            // }

            Console.Write("Seleccione una opción: ");
            var opcionSeleccionada = Console.ReadLine();
            Console.Clear();

            if (perfil == PerfilUsuario.ADMINISTRADOR && opcionSeleccionada == "1")
            {
                bool response = false;
                do
                {
                    Console.WriteLine("GENERAR ALTA/NUEVO USUARIO SUPERVISOR");
                    string nombre = Nombre();
                    string apellido = Apellido();
                    string username = Username();

                    response = gestorUsuarios.AgregarUsuario(nombre, apellido, username, PerfilUsuario.SUPERVISOR);

                    if (!response)
                    {
                        Console.WriteLine("Hubo un error al agregar el usuario supervisor. Por favor intente nuevamente.");
                        Console.WriteLine();
                    }
                } while (!response);

                Console.WriteLine();
                Console.WriteLine("Lista de usuarios existentes: ");
                gestorUsuarios.ObtenerUsuarios();
                Console.WriteLine();
                Console.WriteLine();
            }

            //ALTA Vendedores
            //ALTA Vendedores
            if (perfil == PerfilUsuario.ADMINISTRADOR && opcionSeleccionada == "4")
            {
                bool response = false;
                do
                {
                    Console.WriteLine("GENERAR ALTA/NUEVO USUARIO VENDEDORES");
                    string nombre = Nombre();
                    string apellido = Apellido();
                    string username = Username();

                    response = gestorUsuarios.AgregarUsuario(nombre, apellido, username, PerfilUsuario.VENDEDOR);

                    if (!response)
                    {
                        Console.WriteLine("Hubo un error al agregar el usuario. Por favor intente nuevamente.");
                        Console.WriteLine();
                    }
                } while (!response);

                Console.WriteLine();
                Console.WriteLine("Lista de usuarios existentes: ");
                gestorUsuarios.ObtenerUsuarios();
                Console.WriteLine();
                Console.WriteLine();
            }


            Console.WriteLine("Cerrando sesión...");
            Console.Clear();
            Iniciar();
        }

        static string Nombre()
            {
                string nuevoNombre;
                bool flagnombre = false;
                Console.WriteLine("Ingrese el NOMBRE del nuevo usuario:");
                nuevoNombre = Console.ReadLine();
                do
                {
                    if (string.IsNullOrEmpty(nuevoNombre))
                    {
                        Console.WriteLine("El nombre no puede estar vacío");
                        nuevoNombre = Console.ReadLine();
                    }
                    else flagnombre = true;
                } while (flagnombre == false);
                return nuevoNombre;
            }
        static string Apellido()
        {
            string nuevoapellido;
            bool flagapellido = false;
            Console.WriteLine("Ingrese el APELLIDO del nuevo usuario:");
            nuevoapellido = Console.ReadLine();
            do
            {
                if (string.IsNullOrEmpty(nuevoapellido))
                {
                    Console.WriteLine("el apellido no puede estar vacío");
                    nuevoapellido = Console.ReadLine();
                }
                else flagapellido = true;
            } while (flagapellido == false);
            return nuevoapellido;
        }
        static string Username()
        {
            string nuevousername;
            bool flagnombre = false;
            Console.WriteLine("Ingrese el NOMBRE DE USUARIO/USERNAME del nuevo usuario:");
            nuevousername = Console.ReadLine();
            do
            {
                if (string.IsNullOrEmpty(nuevousername))
                {
                    Console.WriteLine("el nombre de usuario no puede estar vacío");
                    nuevousername = Console.ReadLine();
                }
                else flagnombre = true;
            } while (flagnombre == false);
            return nuevousername;
        }



    }

}



