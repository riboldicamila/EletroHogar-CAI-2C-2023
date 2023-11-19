using Negocio;
using Modelo; //solo para usar PerfilUsuario, no deberiamos llamar nunca  a Usuario directamente acá, siempre sería a través de GestordeUsuarios
using System.Timers;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Runtime.CompilerServices;

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
        private GestorDeVentas gestorDeVentas = new GestorDeVentas();
        private GestorDeClientes gestorDeClientes = new GestorDeClientes();



        public void Iniciar()
        {
            Console.WriteLine("Bienvenido al sistema");

            string idUsuario;
            string nombreUsuario;
            string password;

            do
            {
                Console.WriteLine("Ingrese su nombre de usuario:");
                nombreUsuario = Console.ReadLine();

                Console.WriteLine("Ingrese su contraseña:");
                password = Console.ReadLine();

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

            MostrarMenu(idUsuario, nombreUsuario, password);

        }

        private static void MostrarMenuPrincipal()
        {
            Console.WriteLine("1. Volver a intentarlo");
            Console.WriteLine("2. Salir");
            Console.Write("Ingrese su opción: ");
        }


        private void MostrarMenu(string idUsuarioActual, string nombreUsuario, string password)
        {
            //con idUsuario, get de usuarios con ws
            //buscar usuario en la lista, ver que host id tiene
            //define el perfil para hacer al menu
            //metodo me devuelva un string con tipo de usuario

            idUsuarioActual = idUsuarioActual.Trim('"');

            if (password == "Temp1234")
            {
                SolicitarCambioDeContraseña(nombreUsuario, password);

            }

            string usuarioActualTipo = gestorUsuarios.TipoDeUsuarioLogin(idUsuarioActual);

            Console.WriteLine(usuarioActualTipo);

            Console.Clear();
            
            Console.WriteLine($"Menu de " + usuarioActualTipo);


            if (usuarioActualTipo == "vendedor")
            {
                Console.WriteLine("1. Agregar una Venta");
                Console.WriteLine("2. Reporte de ventas por vendedor");
                Console.WriteLine("3. Agregar/Registrar Cliente");
                Console.WriteLine("4. Salir");
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
                Console.WriteLine("2. Reactivar usuarios Supervisores");
                Console.WriteLine("3. Baja de usuarios Supervisores");
                Console.WriteLine("4. Alta de usuarios Vendedores");
                Console.WriteLine("5. Reactivar usuarios Vendedores");
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

            if (usuarioActualTipo == "administrador")
            {
                //Alta Usuarios Supervisores
                if (opcionSeleccionada == "1")
                {
                    Console.WriteLine("GENERAR ALTA/NUEVO USUARIO SUPERVISOR");
                    RegistrarUsuarioSupervisor(idUsuarioActual);

                }

                //Modificacion de Usuarios Supervisores
                if(opcionSeleccionada == "2")
                {
                    ReactivarUsuario(idUsuarioActual);

                }

                //Baja Supervisores
                if (opcionSeleccionada == "3")
                {
                    BajaUsuarios(idUsuarioActual, "SUPERVISOR");
                }

                //ALTA Vendedores
                if (opcionSeleccionada == "4")
                {

                    Console.WriteLine("GENERAR ALTA/NUEVO USUARIO VENDEDORES");
                    RegistrarUsuarioVendedor(idUsuarioActual);

                }

                if (opcionSeleccionada == "5")
                {
                    ReactivarUsuario(idUsuarioActual);

                }

                if (opcionSeleccionada == "6")
                {
                    //VENDEDOR
                    BajaUsuarios(idUsuarioActual, "VENDEDOR");
                 
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
                    AltaProducto(idUsuarioActual);
                }

                if (opcionSeleccionada == "11")
                {
                    ModificarProducto();
                }

                if (opcionSeleccionada == "12")
                {
                    BajaProducto(idUsuarioActual);
                }
            }


            if (usuarioActualTipo == "supervisor")
            {
                if (opcionSeleccionada == "1")
                {
                    AltaProducto(idUsuarioActual);
                }

                if (opcionSeleccionada == "2")
                {
                    ModificarProducto();
                }

                if (opcionSeleccionada == "3")
                {
                    BajaProducto(idUsuarioActual);
                }

                if (opcionSeleccionada == "4")
                {
                    DevolverVentas(idUsuarioActual);
                }
            }


            if (usuarioActualTipo == "vendedor")
            {
                if (opcionSeleccionada == "1")
                {
                    RegistrarVenta(idUsuarioActual);
                }

                if (opcionSeleccionada == "2")
                {
                    ReporteVentas();
                }

                if (opcionSeleccionada == "3")
                {
                    RegistrarCliente(idUsuarioActual);
                }

                if (opcionSeleccionada == "4")
                {
                    ModificarCliente();
                }

            }


            Console.WriteLine("Cerrando sesión...");
            Thread.Sleep(8000);
            Console.Clear();
            Iniciar();

        }


        //EXTRACCIÓN DE METODOS PARA MANTENER ORDEN 

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

        private void SolicitarCambioDeContraseña(string nombreUsuario, string contraseña)
        {
            Console.WriteLine("Debe cambiar su contraseña.");
            bool cambioExitoso = false;
            string nuevaContraseña;

            while (!cambioExitoso)
            {
                Console.WriteLine("Ingrese la nueva contraseña:");
                nuevaContraseña = Console.ReadLine();

                try
                {
                    cambioExitoso = gestorUsuarios.EstablecerContraseña(nombreUsuario, contraseña, nuevaContraseña);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void ModificarProducto()

        {
            Console.WriteLine("MODIFICACIÓN DE PRODUCTO");
            ListarProductos();

            Console.WriteLine("Ingrese el nombre del producto que desea modificar:");
            string nombreProducto = Console.ReadLine();

            // TODAVIA SIN IMPLEMENTAR 

            Console.WriteLine($"Producto {nombreProducto} ha sido modificado.");
            Console.WriteLine();


        }

        private void AltaProducto(string idUsuarioActual)
        {
            Console.WriteLine("ALTA DE PRODUCTO");

            Console.WriteLine("Ingrese el nombre del producto:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del producto:");
            decimal precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el stock inicial del producto:");
            int stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la categoría del producto:");
            int categoria = int.Parse(Console.ReadLine());

            //OFRECER LISTA DE PROVEEDORES, en form
            Console.WriteLine("Ingrese el id del proveedor con el cuál lo desea relacionar:");
            ListarProveedores();

            string idProveedor = Console.ReadLine();


            if (gestorDeProductos.AgregarProducto(categoria, idUsuarioActual, idProveedor, nombre, precio, stock))
            {
                Console.WriteLine($"Producto {nombre} agregado con éxito.");
                Console.WriteLine("LISTA DE PRODUCTOS EXISTENTES:");
                ListarProductos();
                Thread.Sleep(5000);
            }
            else
            {
                Console.WriteLine("Error al agregar el producto. Por favor, inténtelo de nuevo.");
                Thread.Sleep(8000);
            }
        }

        private void BajaProducto(string idUsuarioActual)
        {
            Console.Clear();
            Console.WriteLine("BAJA PRODUCTOS");
            Console.WriteLine("LISTA DE PRODUCTOS EXISTENTES:");
            ListarProductos();
            Console.WriteLine();

            Console.Write("Ingrese el id del producto que quiere dar de baja: ");
            string idProducto = Console.ReadLine();

            bool bajaExitosa = gestorDeProductos.BajaProductos(idProducto, idUsuarioActual);

            if (bajaExitosa)
            {
                Console.WriteLine($"El producto con ID {idProducto} se encuentra ha dado de baja.");
                ListarProductos();

            }
            else
            {
                Console.WriteLine("Error al deshabilitar el producto. Por favor, inténtelo de nuevo.");
            }

            Thread.Sleep(8000);
            Console.Clear();

        }

        private void AltaProveedores(string idUsuarioActual)
        {
            Console.Clear();
            Console.WriteLine("ALTA PROVEEDORES");

            string nombre = ValidacionesProveedores("Ingrese el nombre del nuevo proveedor:", Validaciones.ValidarNombre);
            string apellido = ValidacionesProveedores("Ingrese el apellido del nuevo proveedor:", Validaciones.ValidarApellido);
            string cuit;
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el CUIT del proveedor, SIN espacios ni guiones:");
                    cuit = Console.ReadLine();
                    Validaciones.ValidarCuit(cuit);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            string email;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el email del proveedor");
                    email = Console.ReadLine();
                    Validaciones.ValidarEmail(email);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (gestorDeProveedores.AltaProveedor(nombre, apellido, cuit, email, idUsuarioActual))
            {
                Console.WriteLine($"Proveedor {nombre} agregado con éxito.");
                ListarProveedores();
                Thread.Sleep(8000);
            }
            else
            {
                Console.WriteLine("Error al agregar el proveedor. Por favor, inténtelo de nuevo.");
                Thread.Sleep(8000);
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
            Validaciones.ValidarCuit(cuit);

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
                ListarProveedores();
            }
            else
            {
                Console.WriteLine("Error al deshabilitar el proveedor. Por favor, inténtelo de nuevo.");
            }

            Thread.Sleep(8000);
            Console.Clear();
        }

        private void ListarProveedores()
        {
            Console.WriteLine();
            Console.WriteLine("Listado de Proveedores:");
            List<Proveedor> proveedores = gestorDeProveedores.ListarProveedores();
            foreach (Proveedor p in proveedores)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine();
            Thread.Sleep(2000);

        }

        private void ListarProductos()
        {
            Console.WriteLine();
            Console.WriteLine("Listado de Productos:");
            List<Producto> productos = gestorDeProductos.TraerProductos();
            foreach (Producto p in productos)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine();

            Thread.Sleep(2000);
        }

        private void ListarClientes()
        {
            Console.WriteLine();
            Console.WriteLine("Listado de Clientes:");
            List<Cliente> cliente = gestorDeClientes.ListarClientes();
            foreach (Cliente c in cliente)
            {
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine();
        }

        private void RegistrarVenta(string idUsuarioActual)
        {
            Console.Clear();
            Console.WriteLine("AGREGAR UNA VENTA");

            Console.WriteLine("Ingrese el id del cliente:");
            Console.WriteLine();
            Console.WriteLine("LISTA DE CLIENTES:");
            ListarClientes();

            Console.WriteLine("Ingrese el id del cliente:");
            string idCliente = Console.ReadLine();
            List<Ventas> lista = new List<Ventas>();

            while (true)
            {
                Console.WriteLine("Ingrese el id del producto:");
                Console.WriteLine();
                Console.WriteLine("LISTA DE PRODUCTOS:");
                ListarProductos();
                string idProducto = Console.ReadLine();

                Console.WriteLine("Ingrese la cantidad:");
                int cantidad;

                while (!int.TryParse(Console.ReadLine(), out cantidad))
                {
                    Console.WriteLine("Por favor, ingrese un valor numérico válido para la cantidad:");
                }

                gestorDeVentas.AgregarAListaVenta(lista, idUsuarioActual, idCliente, idProducto, cantidad);

                Console.WriteLine("¿Desea agregar otro producto? S/N");
                string respuesta = Console.ReadLine();

                if (respuesta != "S" || respuesta != "s")
                {
                    break;
                }
            }

            bool response;
            response = gestorDeVentas.LlamarWSporProducto(lista);

            if (!response)
            {
                Console.WriteLine("Error al agregar venta.");
            }
            else
            {
                Console.WriteLine("Resumen de la venta:");
                //con datos de la lista local
                //mostrar el descuento aca tambien
                //sistema de descuentos 

            }
        }

        private void ReporteVentas() { }

        private void DevolverVentas(string idUsuarioActual)
        {
            Console.Clear();
            Console.WriteLine("DEVOLVER VENTA");
            Console.WriteLine("LISTA DE VENTAS EXISTENTES:");
            //
            Console.WriteLine();

            Console.Write("Ingrese el id de la venta que quiere dar de baja: ");
            string idVenta = Console.ReadLine();

            bool bajaExitosa = gestorDeVentas.DevolverVenta(idVenta, idUsuarioActual);

            if (bajaExitosa)
            {
                Console.WriteLine($"La venta con ID {idVenta} se encuentra Inactivo.");
            }
            else
            {
                Console.WriteLine("Error al devolver venta. Por favor, inténtelo de nuevo.");
            }

            Thread.Sleep(3000);
            Console.Clear();
        }

        private void RegistrarCliente(string idUsuarioActual)
        {
            Console.Clear();
            Console.WriteLine("AGREGAR CLIENTE");

            string nombre;
            string apellido;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el NOMBRE del usuario:");
                    nombre = Console.ReadLine();
                    Validaciones.ValidarNombre(nombre);
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
                    Validaciones.ValidarApellido(apellido);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string direccion;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese la Dirección física del usuario:");
                    direccion = Console.ReadLine();
                    Validaciones.ValidarDireccion(direccion);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string telefono;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el Teléfono del usuario:");
                    telefono = Console.ReadLine();
                    Validaciones.ValidarTelefono(telefono);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string email;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el Correo Electrónico del usuario:");
                    email = Console.ReadLine();
                    Validaciones.ValidarEmail(email);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int dni;
            string dni_entrada;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el DNI del usuario:");
                    dni_entrada = Console.ReadLine();
                    Validaciones.ValidarDni(dni_entrada);
                    dni = int.Parse(dni_entrada);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            string fecha;
            DateTime fechaNacimiento;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese la Fecha de Nacimiento del usuario (YYYY-MM-DD):");
                    fecha = Console.ReadLine();
                    Validaciones.ValidarFecha(fecha);
                    fechaNacimiento = DateTime.Parse(fecha);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            //DUDA SI ES 3 POR EL TIPO DE USUARIO

            if (gestorDeClientes.AgregarCliente(nombre, "Grupo2", dni, direccion, telefono, apellido, email, idUsuarioActual, fechaNacimiento))
            {
                Console.WriteLine($"Cliente {nombre} agregado con éxito.");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Error al agregar el cliente. Por favor, inténtelo de nuevo.");
                Thread.Sleep(3000);
            }
        }

        private void ModificarCliente()
        {
            //se puede mejorar, obliga modificar todos los campos
            Console.Clear();
            Console.WriteLine("MODIFICAR CLIENTE");
            ListarClientes();
            Console.WriteLine("Ingrese el Id del cliente a modificar:");
            string idCliente = Console.ReadLine();

            string direccion;
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese la Dirección física del usuario:");
                    direccion = Console.ReadLine();
                    Validaciones.ValidarDireccion(direccion);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string telefono;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el Teléfono del usuario:");
                    telefono = Console.ReadLine();
                    Validaciones.ValidarTelefono(telefono);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string email;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el Correo Electrónico del usuario:");
                    email = Console.ReadLine();
                    Validaciones.ValidarEmail(email);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bool modificacionExitosa = gestorDeClientes.ModificacionCliente(idCliente,direccion,telefono,email);

            if (modificacionExitosa)
            {
                Console.WriteLine($"El cliente con ID {idCliente} se ha modificado.");
            }
            else
            {
                Console.WriteLine("Error al deshabilitar el proveedor. Por favor, inténtelo de nuevo.");
            }

            Thread.Sleep(8000);
            Console.Clear();



        }

        private void BajaUsuarios(string idUsuarioActual, string tipoUsuario)
        {
            Console.Clear();
            Console.WriteLine("BAJA USUARIOS " + tipoUsuario);

            //Listar usuarios, habria que filtrar por tipo de usuario
            Console.WriteLine("Lista de usuario activos:");
            ListarTodosLosUsuarios();
            Console.Write("Ingrese el id del usuario que quiere dar de baja: ");
            string idUsuarioBaja = Console.ReadLine();

            //HABRIA QUE LISTAR A USUARIOS

            bool bajaExitosa = gestorUsuarios.BajaUsuarios(idUsuarioBaja, idUsuarioActual);

            if (bajaExitosa)
            {
                Console.WriteLine($"El usuario con ID {idUsuarioBaja} se encuentra Inactivo.");
            }
            else
            {
                Console.WriteLine("Error al deshabilitar el proveedor. Por favor, inténtelo de nuevo.");
            }

            Thread.Sleep(8000);
            Console.Clear();



        }

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

        private void ListarTodosLosUsuarios()
        {
            List<UsuarioWS> listadoUsuarios = gestorUsuarios.ObtenerListadoDeUsuarios();

            // Mostrar el listado de usuarios utilizando ToString()
            foreach (UsuarioWS usuario in listadoUsuarios)
            {
                Console.WriteLine(usuario.ToString());
            }
            Console.WriteLine();
        }

        private void ListarUsuariosVendedores()
        {
            List<UsuarioWS> listadoUsuarios = gestorUsuarios.ObtenerListadoDeUsuariosVendedores();

            foreach (UsuarioWS usuario in listadoUsuarios)
            {
                Console.WriteLine(usuario.ToString());
            }
            Console.WriteLine();
        }

        private void ReactivarUsuario(string idUsuarioActual)
        {
            Console.WriteLine("Ingrese el id del usuario que desea reactivar:");
            string idReactivar = Console.ReadLine();

            bool reactivadoExitoso = gestorUsuarios.BajaUsuarios(idReactivar, idUsuarioActual);

            if (reactivadoExitoso)
            {
                Console.WriteLine($"El usuario con ID {idReactivar} se encuentra Activo.");
            }
            else
            {
                Console.WriteLine("Error al rehabilitar usuario. Por favor, inténtelo de nuevo.");
            }

            Thread.Sleep(8000);
            Console.Clear();

        }

        private void RegistrarUsuarioSupervisor(string idUsuarioActual)
        {
            Console.Clear();

            string nombre;
            string apellido;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el NOMBRE del usuario:");
                    nombre = Console.ReadLine();
                    Validaciones.ValidarNombre(nombre);
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
                    Validaciones.ValidarApellido(apellido);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string username;
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el Nombre de Usuario (username)");
                    username = Console.ReadLine();
                    Validaciones.ValidarUsername(nombre, apellido, username);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string direccion;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese la Dirección física del usuario:");
                    direccion = Console.ReadLine();
                    Validaciones.ValidarDireccion(direccion);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string telefono;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el Teléfono del usuario:");
                    telefono = Console.ReadLine();
                    Validaciones.ValidarTelefono(telefono);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string email;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el Correo Electrónico del usuario:");
                    email = Console.ReadLine();
                    Validaciones.ValidarEmail(email);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int dni;
            string dni_entrada;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el DNI del usuario:");
                    dni_entrada = Console.ReadLine();
                    Validaciones.ValidarDni(dni_entrada);
                    dni = int.Parse(dni_entrada);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            string fecha;
            DateTime fechaNacimiento;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese la Fecha de Nacimiento del usuario (YYYY-MM-DD):");
                    fecha = Console.ReadLine();
                    Validaciones.ValidarFecha(fecha);
                    fechaNacimiento = DateTime.Parse(fecha);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            bool response = gestorUsuarios.AgregarUsuario(nombre, 2, dni, direccion, telefono,
                       apellido, email, idUsuarioActual, username, fechaNacimiento);

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
            ListarTodosLosUsuarios();
            Console.WriteLine();
            Console.WriteLine();

        }
        private void RegistrarUsuarioVendedor(string idUsuarioActual)
        {
            Console.Clear();

            string nombre;
            string apellido;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el NOMBRE del usuario:");
                    nombre = Console.ReadLine();
                    Validaciones.ValidarNombre(nombre);
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
                    Validaciones.ValidarApellido(apellido);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string username;
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el Nombre de Usuario (username)");
                    username = Console.ReadLine();
                    Validaciones.ValidarUsername(nombre, apellido, username);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string direccion;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese la Dirección física del usuario:");
                    direccion = Console.ReadLine();
                    Validaciones.ValidarDireccion(direccion);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string telefono;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el Teléfono del usuario:");
                    telefono = Console.ReadLine();
                    Validaciones.ValidarTelefono(telefono);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string email;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el Correo Electrónico del usuario:");
                    email = Console.ReadLine();
                    Validaciones.ValidarEmail(email);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int dni;
            string dni_entrada;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el DNI del usuario:");
                    dni_entrada = Console.ReadLine();
                    Validaciones.ValidarDni(dni_entrada);
                    dni = int.Parse(dni_entrada);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            string fecha;
            DateTime fechaNacimiento;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese la Fecha de Nacimiento del usuario (YYYY-MM-DD):");
                    fecha = Console.ReadLine();
                    Validaciones.ValidarFecha(fecha);
                    fechaNacimiento = DateTime.Parse(fecha);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            bool response = gestorUsuarios.AgregarUsuario(nombre, 1, dni, direccion, telefono,
                       apellido, email, idUsuarioActual, username, fechaNacimiento);

            if (!response)
            {
                Console.WriteLine("Hubo un error al agregar el usuario vendedor. Por favor intente nuevamente.");
            }
            else
            {
                Console.WriteLine("Usuario vendedor agregado con éxito.");
            }

            Console.WriteLine();
            Console.WriteLine("Lista de usuarios existentes: ");
            ListarTodosLosUsuarios();

            Console.WriteLine();
            Console.WriteLine();

        }

    
    }

}