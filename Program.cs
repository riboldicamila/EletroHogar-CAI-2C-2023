using Negocio;
using Modelo; //solo para usar PerfilUsuario, no deberiamos llamar nunca  a Usuario directamente acá, siempre sería a través de GestordeUsuarios

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World commit 3");
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
            Console.WriteLine("Ingrese su nombre de usuario:");
            var username = Console.ReadLine();

            Console.WriteLine("Ingrese su contraseña:");
            var password = Console.ReadLine();

            // Usamos el gestor de usuarios para autenticar
            var perfil = gestorUsuarios.Login(username, password);

            if (perfil.HasValue)
            {
                MostrarMenu(perfil.Value);
            }
            else
            {
                Console.WriteLine("Credenciales inválidas.");
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
            Environment.Exit(0);
        }







    }

}



