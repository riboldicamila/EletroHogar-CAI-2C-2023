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

            string idUsuario;

            do
            {
                Console.WriteLine("Ingrese su nombre de usuario:");
                var nombreUsuario = Console.ReadLine();

                Console.WriteLine("Ingrese su contraseña:");
                var password = Console.ReadLine();

                idUsuario = LoginMenu(gestorUsuarios, nombreUsuario, password);

                if (idUsuario == "error" || idUsuario == "")
                {
                    MostrarMenuPrincipal();
                    var opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            //  el bucle y volver a intentar el login
                            break;
                        case "2":
                            // Salir del programa
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                }

            } while (idUsuario == "error" || idUsuario == "");

            MostrarMenu(idUsuario);

        }

        private static void MostrarMenuPrincipal()
        {
            Console.WriteLine("1. Volver a intentarlo");
            Console.WriteLine("2. Salir");
            Console.Write("Ingrese su opción: ");
        }


        private void MostrarMenu(string idUsuarioActual)
        {
            //con idUsuario
            //get de usuarios con ws
            //buscar usuario en la lista
            //ver que host id tiene
            //define el perfil para hacer al menu
            //metodo me devuelva un string con tipo de usuario

            var usuarioActualTipo = "administrador";

            //var usuarioActualTipo= gestorUsuarios.TipoDeUsuarioLogin(idUsuario);
            //Console.WriteLine("ACA en progreso logica nueva"+usuarioActualTipo);

            //usuario actual no se usa mas

            var usuarioActual= gestorUsuarios.LogicaVieja();
           

            Console.Clear();
            Console.WriteLine($"Menu de "+ usuarioActualTipo);


            if (usuarioActualTipo == "vendedor")
            {
                Console.WriteLine("1. Venta");
                Console.WriteLine("2. Reporte de ventas por vendedor");
                Console.WriteLine("3. Salir");
            }
            else if (usuarioActualTipo == "supervisor")
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
            else if (usuarioActualTipo == "administrador")
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

                    //GENERAR VALIDACION EN CAPA GESTOR DE USUARIO

                    Console.WriteLine("Ingrese la Dirección física del usuario:");
                    string direccion = Console.ReadLine();

                    Console.WriteLine("Ingrese el Teléfono del usuario:");
                    string telefono = Console.ReadLine();

                    Console.WriteLine("Ingrese el Correo Electrónico del usuario:");
                    string email = Console.ReadLine();

                    Console.WriteLine("Ingrese el DNI del usuario:");
                    int dni = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese el número de registro del usuario:");
                    int numeroRegistro = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese la Fecha de Nacimiento del usuario (YYYY-MM-DD):");
                    string fechaNacimientoString = Console.ReadLine();
                    if (DateTime.TryParse(fechaNacimientoString, out DateTime fechaNacimiento))
                    {
                    }
                    else
                    {
                        Console.WriteLine("La fecha de nacimiento ingresada no es válida.");
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
                if (opcionSeleccionada == "4")
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

                if (opcionSeleccionada == "7")
                {
                    AltaProveedores(idUsuarioActual);
                }

                if (opcionSeleccionada == "8")
                {
                    //NO ESTA IMPLEMENTADO
                    ModificacionProveedores();
                }

                if (opcionSeleccionada == "9")
                {

                    BajaProveedores(idUsuarioActual);
                }

                if (opcionSeleccionada == "10")
                {
                    AltaProducto();
                }

                if (opcionSeleccionada == "11")
                {
                    ModificarProducto();
                }

                if (opcionSeleccionada == "12")
                {
                    BajaProducto();
                }
            }


            if (usuarioActual is Supervisor)
            {
                if (opcionSeleccionada == "1")
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
            ListarProductos();
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

            //Producto nuevoProducto = new Producto(nombre, precio, stock, categoria);
            //gestorDeProductos.AgregarProducto(nuevoProducto);

            Console.WriteLine($"Producto {nombre} agregado exitosamente.");
            Console.WriteLine();
        }

        private void BajaProducto()
        {
            //IMPLEMENTAR

        }

        private void AltaProveedores(string idUsuarioActual)
        {
            Console.Clear();
            Console.WriteLine("ALTA PROVEEDORES");

            string nombre = ValidacionesProveedores("Ingrese el nombre del nuevo proveedor:", Validaciones.ValidarNombre);
            string apellido = ValidacionesProveedores("Ingrese el apellido del nuevo proveedor:", Validaciones.ValidarApellido);

            Console.WriteLine("Ingrese el CUIT:");
            string cuit = Console.ReadLine();

            Console.WriteLine("Ingrese el Email:");
            string email = Console.ReadLine();

            if (gestorDeProveedores.AltaProveedor(nombre, apellido, cuit, email, idUsuarioActual))
            {
                Console.WriteLine($"Proveedor {nombre} agregado con éxito.");
                ListarProveedores();
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Error al agregar el proveedor. Por favor, inténtelo de nuevo.");
                Thread.Sleep(3000);
            }
        }

        private void ModificacionProveedores()
        {
            Console.Clear();
            Console.WriteLine("MODIFICACIÓN PROVEEDORES");

            Console.WriteLine("LISTA PROVEEDORES EN SISTEMA:");
            ListarProveedores();

            Console.WriteLine();

            Console.WriteLine("Ingrese el cuit del que desea modificar: ");
            string cuit = Console.ReadLine();

            gestorDeProveedores.ModificarProveedor();

        }

        private void BajaProveedores(string idUsuarioActual)
        {
            Console.Clear();
            Console.WriteLine("BAJA PROVEEDORES");
            Console.WriteLine("LISTA DE PROVEEDORES EXISTENTES:");
            ListarProveedores();
            Console.WriteLine();

            Console.Write("Ingrese el id del proveedor que quiere dar de baja: ");
            string idProveedor = Console.ReadLine();

            bool bajaExitosa = gestorDeProveedores.BajaProveedor(idProveedor, idUsuarioActual);

            if (bajaExitosa)
            {
                Console.WriteLine($"El proveedor con ID {idProveedor} se encuentra Inactivo.");
            }
            else
            {
                Console.WriteLine("Error al deshabilitar el proveedor. Por favor, inténtelo de nuevo.");
            }

            Thread.Sleep(3000);
            Console.Clear();
        }

        private void ListarProveedores()
        {
            Console.WriteLine("Listado de Proveedores:");
            List<Proveedor> proveedores = gestorDeProveedores.ListarProveedores();
            foreach (Proveedor p in proveedores)
            {
                Console.WriteLine(p.ToString());
            }
            Thread.Sleep(5000);

        }

        private static string LoginMenu(GestorDeUsuarios gestorDeUsuarios, string nombreUsuario, string contraseña)
        {

            Login login = new Login();
            login.NombreUsuario = nombreUsuario;
            login.Contraseña = contraseña;

            try
            {
                string idUsuario = gestorDeUsuarios.Login(login);
                Console.WriteLine("Login exitoso. El idUusario es " + idUsuario);
                gestorDeUsuarios.LimpiarListaDeControl(nombreUsuario);
                return idUsuario;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al hacer login.");
                Console.WriteLine(ex.Message);

                bool quedanIntentos = gestorDeUsuarios.ListaDeControl(nombreUsuario);

                if (!quedanIntentos)
                {
                    Console.WriteLine("El usuario está bloqueado. Demasiados intentos fallidos.");
                    return "error";
                }
            }

            return "";


        }


        private void ListarProductos()
        {
            Console.WriteLine("Listado de Productos:");
            List<ProductosWS> productos = gestorDeProductos.TraerProductos();
            foreach (ProductosWS p in productos)
            {
                Console.WriteLine(p.ToString());
            }
            Thread.Sleep(5000);

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