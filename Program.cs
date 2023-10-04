﻿using Negocio;
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

                var intentos = gestorUsuarios.Intentosfallidos(ref username, ref password);

                try
                {
                    var (perfil, necesitaCambiarContrasena, usuarioActual) = gestorUsuarios.Login(username, password);

                    if (perfil.HasValue)
                    {
                        if (necesitaCambiarContrasena)
                        {
                            SolicitarCambioDeContraseña(usuarioActual);
                        }

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
                        else if (intentos == true && opcion == "1")
                        {
                            Iniciar();
                        }
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message); 
                    continue; 
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

            //Alta Usuarios Supervisores
            if (perfil == PerfilUsuario.ADMINISTRADOR && opcionSeleccionada == "1")
            {
                Console.WriteLine("GENERAR ALTA/NUEVO USUARIO SUPERVISOR");

                string nombre = "";
                string apellido = "";
                string username = "";

                while (true)  
                {
                    try
                    {
                        Console.WriteLine("Ingrese el NOMBRE del usuario:");
                        nombre = Console.ReadLine();
                        gestorUsuarios.ValidarNombre(nombre);
                        break; 
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                while (true)  
                {
                    try
                    {
                        Console.WriteLine("Ingrese el APELLIDO del usuario:");
                        apellido = Console.ReadLine();
                        gestorUsuarios.ValidarApellido(apellido);
                        break;  
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                while (true) 
                {
                    try
                    {
                        Console.WriteLine("Ingrese el NOMBRE DE USUARIO/USERNAME del usuario:");
                        username = Console.ReadLine();
                        gestorUsuarios.ValidarUsername(nombre, apellido, username);
                        break;  
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                //Todo validado, se genera el usuario. 
                bool response = gestorUsuarios.AgregarUsuario(nombre, apellido, username, PerfilUsuario.SUPERVISOR);
                if (!response)
                {
                    Console.WriteLine("Hubo un error al agregar el usuario supervisor. Por favor intente nuevamente.");
                }
                else
                {
                    Console.WriteLine("Usuario supervisor agregado con éxito.");
                }

                Console.WriteLine();
                Console.WriteLine("Lista de usuarios existentes: ");
                gestorUsuarios.ObtenerTodosLosUsuarios();
                Console.WriteLine();
                Console.WriteLine();
            }

            //Baja Supervisores
            if (perfil == PerfilUsuario.ADMINISTRADOR && opcionSeleccionada == "3")
            {
                Console.WriteLine("BAJA USUARIO SUPERVISOR");
                Console.WriteLine("Ingrese el nombre de usuario (username) del supervisor que desea dar de baja:");
                string username = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Lista de usuarios existentes antes de la baja:");
                Usuario usuarioAInhabilitar = gestorUsuarios.ObtenerTodosLosUsuarios().FirstOrDefault(u => u.Username == username && u.Perfil == PerfilUsuario.SUPERVISOR);

                if (usuarioAInhabilitar != null)
                {
                    if (gestorUsuarios.BajaUsuario(usuarioAInhabilitar.Nombre, usuarioAInhabilitar.Apellido, usuarioAInhabilitar.Username))
                    {
                        Console.WriteLine("Baja de usuario con éxito.");
                        Console.WriteLine();
                        Console.WriteLine("Lista de usuarios existentes, tras la baja del usuario: ");
                        gestorUsuarios.ObtenerUsuariosActivos();
                    }
                    else
                    {
                        Console.WriteLine("Hubo un error al dar de baja el usuario supervisor. Por favor intente nuevamente.");
                    }
                }
                else
                {
                    Console.WriteLine("El nombre de usuario ingresado no existe o no es de tipo supervisor.");
                   
                }
                Console.WriteLine();
                Thread.Sleep(4000);
            }


            //ALTA Vendedores
            if (perfil == PerfilUsuario.ADMINISTRADOR && opcionSeleccionada == "4")
            {

                Console.WriteLine("GENERAR ALTA/NUEVO USUARIO VENDEDORES");
                string nombre = "";
                string apellido = "";
                string username = "";

                while (true)
                {
                    try
                    {
                        Console.WriteLine("Ingrese el NOMBRE del usuario:");
                        nombre = Console.ReadLine();
                        gestorUsuarios.ValidarNombre(nombre);
                        break;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                while (true)
                {
                    try
                    {
                        Console.WriteLine("Ingrese el APELLIDO del usuario:");
                        apellido = Console.ReadLine();
                        gestorUsuarios.ValidarApellido(apellido);
                        break;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                while (true)
                {
                    try
                    {
                        Console.WriteLine("Ingrese el NOMBRE DE USUARIO/USERNAME del usuario:");
                        username = Console.ReadLine();
                        gestorUsuarios.ValidarUsername(nombre, apellido, username);
                        break;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                //Todo validado, se genera el usuario. 
                bool response = gestorUsuarios.AgregarUsuario(nombre, apellido, username, PerfilUsuario.VENDEDOR);
                if (!response)
                {
                    Console.WriteLine("Hubo un error al agregar el usuario supervisor. Por favor intente nuevamente.");
                }
                else
                {
                    Console.WriteLine("Usuario supervisor agregado con éxito.");
                }

                Console.WriteLine();
                Console.WriteLine("Lista de usuarios existentes: ");
                gestorUsuarios.ObtenerTodosLosUsuarios();
                Console.WriteLine();
                Console.WriteLine();

            }


            //Baja Vendedores
            if (perfil == PerfilUsuario.ADMINISTRADOR && opcionSeleccionada == "6")
            {
                Console.WriteLine("BAJA USUARIO Vendedor");
                Console.WriteLine("Ingrese el nombre de usuario (username) del vendedor que desea dar de baja:");
                string username = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Lista de usuarios existentes antes de la baja:");
                Usuario usuarioAInhabilitar = gestorUsuarios.ObtenerTodosLosUsuarios().FirstOrDefault(u => u.Username == username && u.Perfil == PerfilUsuario.SUPERVISOR);

                if (usuarioAInhabilitar != null)
                {
                    if (gestorUsuarios.BajaUsuario(usuarioAInhabilitar.Nombre, usuarioAInhabilitar.Apellido, usuarioAInhabilitar.Username))
                    {
                        Console.WriteLine("Baja de usuario con éxito.");
                        Console.WriteLine();
                        Console.WriteLine("Lista de usuarios existentes, tras la baja del usuario: ");
                        gestorUsuarios.ObtenerUsuariosActivos();
                    }
                    else
                    {
                        Console.WriteLine("Hubo un error al dar de baja el usuario vendedor. Por favor intente nuevamente.");
                    }
                }
                else
                {
                    Console.WriteLine("El nombre de usuario ingresado no existe o no es de tipo vendedor.");

                }
                Console.WriteLine();
                Thread.Sleep(4000);
            }
            
            Console.WriteLine("Cerrando sesión...");
            Thread.Sleep(2000);
            Console.Clear();
            Iniciar();




        }
        static string Nombre()
        {
            string nuevoNombre;
            bool flagnombre = false;
            Console.WriteLine("Ingrese el NOMBRE del usuario:");
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
            Console.WriteLine("Ingrese el APELLIDO del usuario:");
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
            Console.WriteLine("Ingrese el NOMBRE DE USUARIO/USERNAME del usuario:");
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


        //EXTRACCIÓN DE METODOS PARA MANTENER ORDEN 
        public void SolicitarCambioDeContraseña(Usuario usuarioActual)
        {
            Console.WriteLine("Debe cambiar su contraseña.");
            string nuevaContrasena;
            bool cambioExitoso;
            do
            {
                Console.WriteLine("Ingrese la nueva contraseña:");
                nuevaContrasena = Console.ReadLine();
                cambioExitoso = gestorUsuarios.EstablecerContraseña(usuarioActual, nuevaContrasena);
            } while (!cambioExitoso);
        }

    }

}