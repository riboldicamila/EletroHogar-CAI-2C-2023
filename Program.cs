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
        private GestorDeProductos gestorDeProductos = new GestorDeProductos();
        private GestorDeProveedores gestorDeProveedores = new GestorDeProveedores();

       
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

                    if (!string.IsNullOrEmpty(perfil))
                    {
                        if (necesitaCambiarContrasena)
                        {
                            SolicitarCambioDeContraseña(usuarioActual);
                        }

                        MostrarMenu(usuarioActual);
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


        private void MostrarMenu(Usuario usuarioActual)
        {

            Console.Clear();
            Console.WriteLine($"Menu de {usuarioActual.GetType().Name}");


            if (usuarioActual is Vendedor)
            {
                Console.WriteLine("1. Venta");
                Console.WriteLine("2. Reporte de ventas por vendedor");
                Console.WriteLine("3. Salir");
            }
            else if (usuarioActual is Supervisor)
            {
                Console.WriteLine("1. Alta de Productos");
                Console.WriteLine("2. Modificación de Productos");
                Console.WriteLine("3. Baja de Productos");
                Console.WriteLine("4. Devolución");
                Console.WriteLine("5. Reporte de stock crítico");
                Console.WriteLine("6. Reporte de ventas por vendedor");
                Console.WriteLine("7. Reporte de productos más vendidos por categoría");
                Console.WriteLine("8. Salir");
            }
            else if (usuarioActual is Administrador)
            {
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
            }

            Console.Write("Seleccione una opción: ");
            var opcionSeleccionada = Console.ReadLine();
            Console.Clear();

            if (usuarioActual is Administrador)
            {    
                //Alta Usuarios Supervisores
                if (opcionSeleccionada == "1")
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
                bool response = gestorUsuarios.AgregarUsuario(new Supervisor(nombre, apellido, username));

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
                DevolverListaConTodosUsuarios();

                Console.WriteLine();
                Console.WriteLine();
            }

                //Baja Supervisores
                if (opcionSeleccionada == "3")
                {
                    Console.WriteLine("BAJA USUARIO SUPERVISOR");
                    Console.WriteLine("Ingrese el nombre de usuario (username) del supervisor que desea dar de baja:");
                    string username = Console.ReadLine();

                    Console.WriteLine();
                    Usuario usuarioAInhabilitar = gestorUsuarios.ObtenerTodosLosUsuarios().FirstOrDefault(u => u.Username == username && u is Supervisor);

                        if (usuarioAInhabilitar != null)
                    {
                        if (gestorUsuarios.BajaUsuario(usuarioAInhabilitar.Nombre, usuarioAInhabilitar.Apellido, usuarioAInhabilitar.Username))
                        {
                            Console.WriteLine("Baja de usuario con éxito.");
                            Console.WriteLine();
                            Console.WriteLine("Lista de usuarios existentes, tras la baja del usuario: ");
                            ListaUsuariosActivos();
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
                if ( opcionSeleccionada == "4")
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
                    bool response = gestorUsuarios.AgregarUsuario(new Vendedor(nombre, apellido, username));

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
                if (opcionSeleccionada == "6")
                {
                    Console.WriteLine("BAJA USUARIO Vendedor");
                    Console.WriteLine("Ingrese el nombre de usuario (username) del vendedor que desea dar de baja:");
                    string username = Console.ReadLine();

                    Console.WriteLine();
                    Usuario usuarioAInhabilitar = gestorUsuarios.ObtenerTodosLosUsuarios().FirstOrDefault(u => u.Username == username && u is Vendedor);

                        if (usuarioAInhabilitar != null)
                    {
                        if (gestorUsuarios.BajaUsuario(usuarioAInhabilitar.Nombre, usuarioAInhabilitar.Apellido, usuarioAInhabilitar.Username))
                        {
                            Console.WriteLine("Baja de usuario con éxito.");
                            Console.WriteLine();
                            Console.WriteLine("Lista de usuarios existentes, tras la baja del usuario: ");
                            ListaUsuariosActivos();
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

                if (opcionSeleccionada == "6")
                {
                    Console.WriteLine("BAJA USUARIO Vendedor");
                    Console.WriteLine("Ingrese el nombre de usuario (username) del vendedor que desea dar de baja:");
                    string username = Console.ReadLine();

                    Console.WriteLine();
                    Usuario usuarioAInhabilitar = gestorUsuarios.ObtenerTodosLosUsuarios().FirstOrDefault(u => u.Username == username && u is Vendedor);

                        if (usuarioAInhabilitar != null)
                    {
                        if (gestorUsuarios.BajaUsuario(usuarioAInhabilitar.Nombre, usuarioAInhabilitar.Apellido, usuarioAInhabilitar.Username))
                        {
                            Console.WriteLine("Baja de usuario con éxito.");
                            Console.WriteLine();
                            Console.WriteLine("Lista de usuarios existentes, tras la baja del usuario: ");
                            ListaUsuariosActivos();
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

                if (opcionSeleccionada== "7")
                {
                    AltaProveedores(usuarioActual);
                }

                if (opcionSeleccionada == "8")
                {
                    ModificacionProveedores();
                }

                if (opcionSeleccionada == "9")
                {
                    BajaProveedores();
                }

                if(opcionSeleccionada == "10")
                {
                    AltaProducto();
                }

                if (opcionSeleccionada == "11")
                {
                    ModificarProducto();
                }

                if(opcionSeleccionada=="12")
                {
                    BajaProducto();
                }
            }


            if(usuarioActual is Supervisor)
            {
                if(opcionSeleccionada == "1")
                {
                    AltaProducto();
                }

                if (opcionSeleccionada == "2")
                {
                    ModificarProducto();
                }

                if (opcionSeleccionada == "3")
                {
                    BajaProducto();
                }
            }


            
            Console.WriteLine("Cerrando sesión...");
            Thread.Sleep(2000);
            Console.Clear();
            Iniciar();

        }
      

        //EXTRACCIÓN DE METODOS PARA MANTENER ORDEN 
        private void SolicitarCambioDeContraseña(Usuario usuarioActual)
        {
            Console.WriteLine("Debe cambiar su contraseña.");
            string nuevaContrasena;
            bool cambioExitoso = false;

            while (!cambioExitoso)
            {
                Console.WriteLine("Ingrese la nueva contraseña:");
                nuevaContrasena = Console.ReadLine();

                try
                {
                    cambioExitoso = gestorUsuarios.EstablecerContraseña(usuarioActual, nuevaContrasena);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void DevolverListaConTodosUsuarios()
        {
            var todosLosUsuarios = gestorUsuarios.ObtenerTodosLosUsuarios();
            foreach (var usuario in todosLosUsuarios)
            {
                Console.WriteLine(usuario.Username);
            }
        }

        private void ListaUsuariosActivos()
        {
            var usuariosActivos = gestorUsuarios.ObtenerUsuariosActivos();
            foreach (var usuario in usuariosActivos)
            {
                Console.WriteLine(usuario.Username);
            }
        }

        private void ModificarProducto()
        {
            Console.WriteLine("MODIFICACIÓN DE PRODUCTO");

            Console.WriteLine("Ingrese el nombre del producto que desea modificar:");
            string nombreProducto = Console.ReadLine();

            // TODAVIA SIN IMPLEMENTAR 

            Console.WriteLine($"Producto {nombreProducto} ha sido modificado.");
            Console.WriteLine();
        }

        private void AltaProducto()
        {
            Console.WriteLine("ALTA DE PRODUCTO");

            Console.WriteLine("Ingrese el nombre del producto:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del producto:");
            decimal precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el stock inicial del producto:");
            int stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la categoría del producto:");
            string categoria = Console.ReadLine();

            Producto nuevoProducto = new Producto(nombre, precio, stock, categoria);
            gestorDeProductos.AgregarProducto(nuevoProducto);

            Console.WriteLine($"Producto {nombre} agregado exitosamente.");
            Console.WriteLine();
        }

        private void BajaProducto()
        {
            //IMPLEMENTAR
        }

        private void AltaProveedores(Usuario usuarioActual)
        {
            Console.Clear();
            Console.WriteLine("ALTA PROVEEDORES");

            string nombre = ValidacionesProveedores("Ingrese el nombre del nuevo proveedor:", Validaciones.ValidarNombre);

            string apellido= ValidacionesProveedores("Ingrese el apellido del nuevo proveedor:", Validaciones.ValidarApellido);

            Console.WriteLine("Ingrese el CUIT:");
            long cuit = long.Parse(Console.ReadLine()); 

            Console.WriteLine("Ingrese el Email:");
            var email = Console.ReadLine();

            Console.WriteLine("Ingrese la categoría del producto:");
            string categoria = Console.ReadLine();


            //try
            //{
            //    if ()
            //    {
            //        Console.WriteLine("Esa categoria ya esta registrada");
            //    }
            //    else
            //    {
                    
            //    }
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}



            Guid idUsuario = usuarioActual.Id;

           // Guid idProducto = Guid.Parse("TRIAL");

            if (gestorDeProveedores.AgregarProveedor(nombre, cuit, email, apellido, idUsuario))
            {
                Console.WriteLine($"Proveedor {nombre} agregado con éxito.");
                DevolverListaConTodosProveedores();
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Error al agregar el proveedor. Por favor, inténtelo de nuevo.");
                Thread.Sleep(3000);
            }
            Console.Clear();
        }

        private void ModificacionProveedores()
        {
           //******///

            

        }

        private void BajaProveedores()
        {
            
            Console.Clear();
            Console.WriteLine("BAJA PROVEEDORES");

            string nombre = ValidacionesProveedores("Ingrese el nombre del proveedor:", Validaciones.ValidarNombre);

            string apellido = ValidacionesProveedores("Ingrese el apellido del proveedor:", Validaciones.ValidarApellido);

            if (gestorDeProveedores.BajaProveedor(nombre, apellido))
            {
                Console.WriteLine("El proveedor " + nombre + " " + apellido + " se encuentra Inactivo.");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Error al deshabilitar el proveedor. Por favor, inténtelo de nuevo.");
                Thread.Sleep(3000);
            }
            Console.Clear();
            
            
        }

        private void DevolverListaConTodosProveedores()
        {
            Console.WriteLine();
            Console.WriteLine("Listado de proveedores:");
            var proveedores = gestorDeProveedores.ObtenerTodosLosProveedores();
            foreach (var proveedor in proveedores)
            {
                Console.WriteLine($"Proveedor {proveedor.Nombre}, {proveedor.Apellido}. ID: {proveedor.Id}");
            }

        }

        //IDEA ES PODER REUTILIZARLO PARA TODO DESPUES
        private string ValidacionesProveedores(string mensaje, Action<string> validacion)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(mensaje);
                    string value = Console.ReadLine();
                    validacion(value);
                    return value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

}