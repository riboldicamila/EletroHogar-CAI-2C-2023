using Negocio;
using Modelo; 
using System.Timers;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Runtime.CompilerServices;

//Finalmente, hay un reporte de ventas totales (por consola) y uno de ventas por fecha de la venta. 


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
        private String IdUsuarioLogueado = "";
        private String UsuarioLogueado = "";
        private String PerfilUsuarioLogeado = "";



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

            UsuarioLogueado = nombreUsuario;
            IdUsuarioLogueado = idUsuario;

            //con idUsuario, get de usuarios con ws
            //buscar usuario en la lista, ver que host id tiene
            //define el perfil para hacer al menu
            //metodo me devuelva un string con tipo de usuario

            if (password == "Temp1234")
            {
                SolicitarCambioDeContraseña(nombreUsuario, password);

            }

            PerfilUsuarioLogeado = gestorUsuarios.TipoDeUsuarioLogin(IdUsuarioLogueado);
            //PerfilUsuarioLogeado = "vendedor";
            MostrarMenu();

        }

        private static void MostrarMenuPrincipal()
        {
            Console.WriteLine("1. Volver a intentarlo");
            Console.WriteLine("2. Salir");
            Console.Write("Ingrese su opción: ");
        }


        private void MostrarMenu()
        {
            Console.Clear();
            
            Console.WriteLine($"Menu de " + UsuarioLogueado);


            if (PerfilUsuarioLogeado == "vendedor")
            {
                Console.WriteLine("1. Agregar una Venta");
                Console.WriteLine("2. Reporte de ventas total (por vendedor, no puede lograr relacion)");
                Console.WriteLine("3. Agregar/Registrar Cliente");
                Console.WriteLine("4. Modificar Cliente");
                Console.WriteLine("5. Reporte de ventas por fecha");

                Console.WriteLine("6. Salir");

            }
            else if (PerfilUsuarioLogeado == "supervisor")
            {
                Console.WriteLine("1. Alta de Productos");
                Console.WriteLine("2. Baja de Productos");
                Console.WriteLine("3. Reactivar producto");
                Console.WriteLine("4. Devolver una venta");
                Console.WriteLine("5. Reporte de ventas total (por vendedor, no puede lograr relacion)");
                Console.WriteLine("6. Reporte de ventas por fecha");
                Console.WriteLine("7. Salir");
            }
            else if (PerfilUsuarioLogeado == "administrador")
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
                Console.WriteLine("11. Reporte de ventas por fecha");
                Console.WriteLine("12. Baja de Productos");
                Console.WriteLine("13. Reporte de ventas total (por vendedor, no puede lograr relacion)"); 
                Console.WriteLine("14. Salir");
            }

            Console.Write("Seleccione una opción: ");
            var opcionSeleccionada = Console.ReadLine();
            Console.Clear();

            if (PerfilUsuarioLogeado == "administrador")
            {
                //Alta Usuarios Supervisores
                if (opcionSeleccionada == "1")
                {
                    Console.WriteLine("GENERAR ALTA/NUEVO USUARIO SUPERVISOR");
                    RegistrarUsuarioSupervisor(IdUsuarioLogueado);

                }

                //Modificacion de Usuarios Supervisores
                if(opcionSeleccionada == "2")
                {
                    ReactivarUsuario(IdUsuarioLogueado);

                }

                //Baja Supervisores
                if (opcionSeleccionada == "3")
                {
                    BajaUsuarios(IdUsuarioLogueado, "SUPERVISOR");
                }

                //ALTA Vendedores
                if (opcionSeleccionada == "4")
                {

                    Console.WriteLine("GENERAR ALTA/NUEVO USUARIO VENDEDORES");
                    RegistrarUsuarioVendedor(IdUsuarioLogueado);

                }

                if (opcionSeleccionada == "5")
                {
                    ReactivarUsuario(IdUsuarioLogueado);

                }

                if (opcionSeleccionada == "6")
                {
                    //VENDEDOR
                    BajaUsuarios(IdUsuarioLogueado, "VENDEDOR");
                 
                }

                if (opcionSeleccionada == "7")
                {
                    AltaProveedores(IdUsuarioLogueado);
                }

                if (opcionSeleccionada == "8")
                {
                    ModificacionProveedores(IdUsuarioLogueado);
                }

                if (opcionSeleccionada == "9")
                {

                    BajaProveedores(IdUsuarioLogueado);
                }

                if (opcionSeleccionada == "10")
                {
                    AltaProducto(IdUsuarioLogueado);
                }

                if (opcionSeleccionada == "11")
                {
                    ReporteVentasPorFechaAlta();
                }

                if (opcionSeleccionada == "12")
                {
                    BajaProducto(IdUsuarioLogueado);
                }

                if (opcionSeleccionada == "13")
                {
                    ListarTodosLasVentas();
                }

                if (opcionSeleccionada == "14")
                {
                    Iniciar();
                }
            }


            if (PerfilUsuarioLogeado == "supervisor")
            {
                if (opcionSeleccionada == "1")
                {
                    AltaProducto(IdUsuarioLogueado);
                }

                if (opcionSeleccionada == "2")
                {
                    BajaProducto(IdUsuarioLogueado);
                }

                if (opcionSeleccionada == "3")
                {
                    ReactivarProducto(IdUsuarioLogueado);
                }

                if (opcionSeleccionada == "4")
                {
                    DevolverVentas(IdUsuarioLogueado);
                }

                if (opcionSeleccionada == "5")
                {
                    ListarTodosLasVentas();
                }

                if (opcionSeleccionada == "6")
                {
                    ReporteVentasPorFechaAlta();
                }

                if(opcionSeleccionada == "7")
                {
                    Iniciar();
                }

            }


            if (PerfilUsuarioLogeado == "vendedor")
            {
                if (opcionSeleccionada == "1")
                {
                    RegistrarVenta();
                }

                if (opcionSeleccionada == "2")
                {
                    ReporteVentas();
                }

                if (opcionSeleccionada == "3")
                {
                    RegistrarCliente(IdUsuarioLogueado);
                }

                if (opcionSeleccionada == "4")
                {
                    ModificarCliente();
                }

                if(opcionSeleccionada == "5")
                {
                    ReporteVentasPorFechaAlta();
                }

                if (opcionSeleccionada == "6")
                {
                    Iniciar();
                }

            }

            Console.WriteLine();
            Console.WriteLine("Volviendo al menú...");
            Thread.Sleep(5000);
            MostrarMenu();

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
                return idUsuario.Replace("\"", "");

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
                //se valida en método

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

            string nombreProducto;

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el nombre del producto que desea modificar:");
                    nombreProducto = Console.ReadLine();
                    Validaciones.ValidarCampoString(nombreProducto);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            // TODAVIA SIN IMPLEMENTAR 

            Console.WriteLine($"Producto {nombreProducto} ha sido modificado.");
            Console.WriteLine();


        }

        private void AltaProducto(string idUsuarioActual)
        {
            Console.WriteLine("ALTA DE PRODUCTO");

            string nombre;
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el nombre del producto:");
                    nombre = Console.ReadLine();
                    Validaciones.ValidarCampoString(nombre);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            Console.WriteLine("Ingrese el precio del producto:");

            decimal precio;
            while (true)
            {
                try
                {
                    string precioInput = Console.ReadLine();
                    precio = decimal.Parse(precioInput);
                    Validaciones.ValidarPrecio(precio);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Ingrese un valor numérico para el precio.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Ingrese el stock inicial del producto:");

            int stock;
            while (true)
            {
                try
                {
                    string stockInput = Console.ReadLine();
                    stock = int.Parse(stockInput);
                    Validaciones.ValidarStock(stock);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Ingrese un valor numérico para el stock.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Ingrese la categoría del producto:");

            int categoria;
            while (true)
            {
                try
                {
                    string categoriaInput = Console.ReadLine();
                    categoria = int.Parse(categoriaInput);
                    Validaciones.ValidarCategoria(categoria);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Ingrese un valor numérico para la categoría.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            //OFRECER LISTA DE PROVEEDORES, en form
            Console.WriteLine("Ingrese el id del proveedor con el cuál lo desea relacionar:");
            ListarProveedores();

            string idProveedor;
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el id del proveedor con el cuál lo desea relacionar:");
                    idProveedor = Console.ReadLine();
                    Validaciones.ValidarId(idProveedor);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

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

            string idProducto;
            while (true)
            {
                try
                {
                    Console.Write("Ingrese el id del producto que quiere dar de baja: ");
                    idProducto = Console.ReadLine();
                    Validaciones.ValidarId(idProducto);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

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
                    Console.WriteLine();
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
                    Console.WriteLine();
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

        private void ModificacionProveedores(string idUsuarioActual)
        {
            Console.Clear();
            Console.WriteLine("MODIFICACIÓN PROVEEDORES");

            Console.WriteLine("LISTA PROVEEDORES EN SISTEMA:");
            ListarProveedores();

            Console.WriteLine();

            string id;
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el id del que desea modificar: ");
                    id = Console.ReadLine();
                    Validaciones.ValidarId(id);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Devolver objeto proveedor
            Proveedor proveedor = gestorDeProveedores.BuscarProveedor(id);

            bool response; 

            if (proveedor != null)
            {
                Console.WriteLine($"Proveedor encontrado: {proveedor.nombre}, {proveedor.apellido}, {proveedor.email}, {proveedor.cuit}");

                Console.WriteLine("Seleccione el número de la propiedad que desea modificar:");
                Console.WriteLine("1. Nombre");
                Console.WriteLine("2. Apellido");
                Console.WriteLine("3. Email");
                Console.WriteLine("4. CUIT");

                if (int.TryParse(Console.ReadLine(), out int opcionSeleccionada))
                {
                    switch (opcionSeleccionada)
                    {
                        case 1:
                            Console.WriteLine("Ingrese el nuevo nombre:");
                            string nuevoNombre = Console.ReadLine();
                            response = gestorDeProveedores.ModificarProveedor(idUsuarioActual, id, nuevoNombre, proveedor.apellido, proveedor.email, proveedor.cuit);
                            break;
                        case 2:
                            Console.WriteLine("Ingrese el nuevo apellido:");
                            string nuevoApellido = Console.ReadLine();
                            response = gestorDeProveedores.ModificarProveedor(idUsuarioActual, id, proveedor.nombre, nuevoApellido, proveedor.email, proveedor.cuit);
                            break;
                        case 3:
                            Console.WriteLine("Ingrese el nuevo email:");
                            string nuevoEmail = Console.ReadLine();
                            response = gestorDeProveedores.ModificarProveedor(idUsuarioActual, id, proveedor.nombre, proveedor.apellido, nuevoEmail, proveedor.cuit);
                            break;
                        case 4:
                            Console.WriteLine("Ingrese el nuevo CUIT:");
                            string nuevoCuit = Console.ReadLine();
                            response = gestorDeProveedores.ModificarProveedor(idUsuarioActual, id, proveedor.nombre, proveedor.apellido, proveedor.email, nuevoCuit);
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            response = false;
                            break;
                    }

                    if (response)
                    {
                        Console.WriteLine("Se ha modificado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("Error al modificar.");
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese un número válido.");
                }
            }
            else
            {
                Console.WriteLine("Proveedor no encontrado.");
            }
        }

        private void BajaProveedores(string idUsuarioActual)
        {
            Console.Clear();
            Console.WriteLine("BAJA PROVEEDORES");
            Console.WriteLine("LISTA DE PROVEEDORES EXISTENTES:");
            ListarProveedores();
            Console.WriteLine();

            string idProveedor;
            while (true)
            {
                try
                {
                    Console.Write("Ingrese el id del proveedor que quiere dar de baja: ");
                    idProveedor = Console.ReadLine();
                    Validaciones.ValidarId(idProveedor);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


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
            Console.WriteLine();

            Thread.Sleep(2000);

        }

        private void ListarTodosLasVentas()
        {
            Console.WriteLine();
            Console.WriteLine("Listado de Todas las Ventas:");
            List<VentasWS> ventas = gestorDeVentas.ObtenerTodasLasVentas();
            foreach (VentasWS v in ventas)
            {
                Console.WriteLine(v.ToString());
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
            Console.WriteLine();

            Thread.Sleep(2000);
        }
        private void ObtenerPrecioYNombreProductoPorId(ItemProductosVentas producto)
        {
            List<Producto> productos = gestorDeProductos.TraerProductos();
            foreach (Producto p in productos)
            {
                if (p.id == producto.IdProducto)
                {
                    producto.Nombre = p.nombre;
                    producto.Precio = p.precio;
                }
            }
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

        private void RegistrarVenta()
        {
            ProductosVenta productosVenta = new ProductosVenta();
            productosVenta.IdUsuario = IdUsuarioLogueado;

            Console.Clear();
            Console.WriteLine("AGREGAR UNA VENTA");

            Console.WriteLine("Ingrese el id del cliente:");
            Console.WriteLine();
            Console.WriteLine("LISTA DE CLIENTES:");
            ListarClientes();

            Console.WriteLine("Ingrese el id del cliente:");
            string idCliente = Console.ReadLine();
            productosVenta.IdCliente = idCliente;

            productosVenta.ListadoProductosVentas = new List<ItemProductosVentas>();

            while (true)
            {
                ItemProductosVentas producto = new ItemProductosVentas();

                Console.WriteLine();
                Console.WriteLine("LISTA DE PRODUCTOS:");
                ListarProductos();
                Console.WriteLine("Ingrese el id del producto:");
                string idProducto = Console.ReadLine();
                producto.IdProducto = idProducto;

                int cantidad;

                do
                {
                    Console.WriteLine("Ingrese la cantidad:");

                    while (!int.TryParse(Console.ReadLine(), out cantidad))
                    {
                        Console.WriteLine("Por favor, ingrese un valor numérico válido para la cantidad:");
                    }

                } while (!gestorDeProductos.VerificarStock(idProducto, cantidad));



                producto.Cantidad = cantidad;
                ObtenerPrecioYNombreProductoPorId(producto);

                productosVenta.ListadoProductosVentas.Add(producto);
                Console.WriteLine();
                ListarCarroDeCompras(productosVenta);

                Console.WriteLine();
                Console.WriteLine("¿Desea agregar otro producto? S/N");
                String respuesta = Console.ReadLine();

                if (!(respuesta.ToLower().Equals("s")))
                {
                    break;
                }
            }

            bool response;
            response = gestorDeVentas.AgregarAListaVenta(productosVenta);

            if (!response)
            {
                Console.WriteLine("Error al agregar venta.");
            }
            else
            {
                Console.WriteLine("Resumen de la venta:");
                ListarCarroDeCompras(productosVenta);
                Console.WriteLine();
                ListarTotalConDescuentos(productosVenta, idCliente);
            }
            Thread.Sleep(8000);

        }

        private void ListarCarroDeCompras(ProductosVenta productos)
        {
            decimal SubTotal = 0;
            foreach (ItemProductosVentas item in productos.ListadoProductosVentas)
            {
                Console.WriteLine(item.ToString());
                SubTotal = SubTotal + (item.Precio * item.Cantidad);
            }
            Console.WriteLine("Sub Total:" + SubTotal);
            Console.WriteLine();

        }

        private void ListarTotalConDescuentos(ProductosVenta productos, string idCliente)
        {
            decimal SubTotal = 0;
            foreach (ItemProductosVentas item in productos.ListadoProductosVentas)
            {
                Console.WriteLine(item.ToString());
                SubTotal = SubTotal + (item.Precio * item.Cantidad);
            }
            Console.WriteLine();
            Console.WriteLine("Total sin descuentos:" + SubTotal);


            Cliente cliente = gestorDeClientes.BuscarCliente(idCliente);

            if (cliente != null && cliente.TieneFechaAltaHoy())
            {
                //es un nuevo cliente. Promo cliente NUEVO, acumulable

                decimal descuento = SubTotal * 0.05m;
                decimal totalConDescuento = SubTotal - descuento;

                Console.WriteLine("Descuento aplicado del 5%: " + descuento);
                Console.WriteLine("Total con descuento (PROMO CLIENTE NUEVO): " + totalConDescuento);

                //PROMO ELECTRO HOGAR
                decimal totalElectroHogar = 0;

                foreach (ItemProductosVentas item in productos.ListadoProductosVentas)
                {
                    string idProducto = item.IdProducto;

                    // Buscar si ese ID está dentro de la lista ELECTROHOGAR (supongo que es productos con id 1)
                    List<Producto> productosElectroHogar = gestorDeProductos.ListaProductosPorCategoria(1);

                    foreach (Producto p in productosElectroHogar)
                    {
                        // Verificar si el ID del producto en productosElectroHogar con el ID del item
                        if (p.id == idProducto)
                        {
                            // Sumar el precio del item al total
                            totalElectroHogar += (item.Precio * item.Cantidad);
                        }
                    }
                }
                decimal descuentoElectroHogar = 0;
                decimal totalElectroHogarConDescuento = 0;

                if (totalElectroHogar > 100000)
                {
                    //aplicar otro descuento 
                    descuentoElectroHogar = totalElectroHogar * 0.05m;
                    totalElectroHogarConDescuento = totalElectroHogar * 0.95m;
                    totalConDescuento = totalConDescuento - totalElectroHogar + totalElectroHogarConDescuento;
                    Console.WriteLine();
                    Console.WriteLine("Descuento aplicado del 5%: " + descuentoElectroHogar);
                    Console.WriteLine("Total con descuento (PROMO ELECTRO HOGAR): " + totalConDescuento);
                }

            }
            else
            {
                //Total normal
                Console.WriteLine();
                Console.WriteLine("Total de la compra: " + SubTotal);
               
            }


        }

        private void ReporteVentas() {

            //LA IDEA ERA FILTRAR LAS VENTAS POR VENDEDOR PARA HACER REPORTE
            //PERO NO LO DEVUELVE EL WS, no encuentro como relacionar ventas con ws y con vendedor.

            ListarTodosLasVentas();
        
        }

        private void ReporteVentasPorFechaAlta()
        {
            // IDEA REPORTE nuestro de VENTAS POR FECHA DE ALTA
            Console.WriteLine("REPORTE VENTA POR FECHA DE ALTA:");
            Console.WriteLine();
            Console.WriteLine("INGRESE LA FECHA QUE DESEA BUSCAR: (YYYY/MM/DD)");
            string fechaStr = Console.ReadLine();

            if (DateTime.TryParse(fechaStr, out DateTime fecha))
            {
                List<VentasWS> ventas = gestorDeVentas.FiltrarVentasPorFechaDeAlta(fecha);

                if (ventas.Count > 0)
                {
                    foreach (VentasWS v in ventas)
                    {
                        Console.WriteLine(v.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron ventas para la fecha especificada.");
                }
            }
            else
            {
                Console.WriteLine("Formato de fecha incorrecto. Por favor, ingrese una fecha válida.");
            }

            Console.WriteLine();
            Thread.Sleep(2000);
        }

        private void DevolverVentas(string idUsuarioActual)
        {
            Console.Clear();
            Console.WriteLine("DEVOLVER VENTA (producto de una venta)");
            Console.WriteLine("LISTA DE VENTAS EXISTENTES:");
            //
            Console.WriteLine();
            ListarTodosLasVentas();

            string idVenta;
            while (true)
            {
                try
                {
                    Console.Write("Ingrese el id de la venta que quiere dar de baja: ");
                    idVenta = Console.ReadLine();
                    Validaciones.ValidarId(idVenta);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


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

            string idCliente;
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el Id del cliente a modificar:");
                    idCliente = Console.ReadLine();
                    Validaciones.ValidarId(idCliente);
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
            string idUsuarioBaja;
            while (true)
            {
                try
                {
                    Console.Write("Ingrese el id del usuario que quiere dar de baja: ");
                    idUsuarioBaja = Console.ReadLine();
                    Validaciones.ValidarId(idUsuarioBaja);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

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
            List<Usuario> listadoUsuarios = gestorUsuarios.ObtenerListadoDeUsuarios();

            // Mostrar el listado de usuarios utilizando ToString()
            foreach (Usuario usuario in listadoUsuarios)
            {
                Console.WriteLine(usuario.ToString());
            }
            Console.WriteLine();
        }

        //NO FUNCIONA, EL WS SOLO TRAE USUARIOS ACTIVOS.
        private bool ListarUsuariosInactivos()
        {
            List<Usuario> listadoUsuarios = gestorUsuarios.ObtenerListadoDeUsuariosInactivos();

            if (listadoUsuarios.Count == 0)
            {
                Console.WriteLine("No hay usuarios inactivos");
                return false;
            }

            // Mostrar el listado de usuarios utilizando ToString()
            foreach (Usuario usuario in listadoUsuarios)
            {
                Console.WriteLine(usuario.ToString());
            }
            Console.WriteLine();

            return true;
        }


        private void ListarUsuariosVendedores()
        {
            List<Usuario> listadoUsuarios = gestorUsuarios.ObtenerListadoDeUsuariosVendedores();

            foreach (Usuario usuario in listadoUsuarios)
            {
                Console.WriteLine(usuario.ToString());
            }
            Console.WriteLine();
        }

        private void ReactivarUsuario(string idUsuarioActual)
        {
            //solo inactivos, la lista ListarUsuariosInactivos, vuelve vacia. 

            ListarTodosLosUsuarios();

            string idReactivar;
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el id del usuario que desea reactivar:");
                    idReactivar = Console.ReadLine();
                    Validaciones.ValidarId(idReactivar);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bool reactivadoExitoso = gestorUsuarios.ReactivarUsuario(idReactivar, idUsuarioActual);

            if (reactivadoExitoso)
            {
                Console.WriteLine($"El usuario con ID {idReactivar} se encuentra Activo.");
            }
            else
            {
                Console.WriteLine("Error al rehabilitar usuario. Por favor, inténtelo de nuevo.");
            }

            Thread.Sleep(5000);
            Console.Clear();

        }

        private void ReactivarProducto(string idUsuarioActual)
        {
            ListarProductos();
     
            string idReactivar;
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el id del producto que desea reactivar:");
                    idReactivar = Console.ReadLine();
                    Validaciones.ValidarId(idReactivar);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            bool reactivadoExitoso = gestorDeProductos.ReactivarProducto(idReactivar, idUsuarioActual);

            if (reactivadoExitoso)
            {
                Console.WriteLine($"El producto con ID {idReactivar} se encuentra Activo.");
            }
            else
            {
                Console.WriteLine("Error al reactivar producto. Por favor, inténtelo de nuevo.");
            }

            Thread.Sleep(5000);
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