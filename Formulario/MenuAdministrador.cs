using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario
{
    public partial class MenuAdministrador : Form
    {
        public MenuAdministrador()
        {
            InitializeComponent();
            OcultarCampos();
        }
        int host;
        string tipoUsuario;
        List<Usuario> listadoInactivos = new List<Usuario>();
        List<Proveedor> listadoProvInactivos = new List<Proveedor>();
        private GestorDeUsuarios gestorUsuarios = new GestorDeUsuarios();
        private GestorDeProductos gestorDeProductos = new GestorDeProductos();
        private GestorDeProveedores gestorDeProveedores = new GestorDeProveedores();
        private GestorDeVentas gestorDeVentas = new GestorDeVentas();
        private GestorDeClientes gestorDeClientes = new GestorDeClientes();
        //private void btnSeleccion_Click(object sender, EventArgs e)
        //{
        //}

        private void btnSeleccion_Click_1(object sender, EventArgs e)
        {
            if (rdoAltaSup.Checked)
            {
                OcultarCampos();
                host = 2;
                tipoUsuario = "supervisor";
                grpRegistrar.Show();
            }
            else if (rdoBajaSup.Checked)
            {
                OcultarCampos();
                host = 2;
                tipoUsuario = "supervisor";
                ListarTodosLosUsuarios();
                cmbUsuarios.Location = cmbInactivos.Location;
                btnReactivar.Text = "Baja";
                cmbInactivos.Hide();
                grpBajaYReactivar.Show();
                cmbUsuarios.Show();
            }
            else if (rdoReactivarSup.Checked)
            {
                OcultarCampos();
                host = 2;
                tipoUsuario = "supervisor";
                ListarInactivos(listadoInactivos);
                btnReactivar.Text = "Reactivar";
                cmbUsuarios.Hide();
                grpBajaYReactivar.Show();
                cmbInactivos.Show();

            }
            else if (rdoAltaVend.Checked)
            {
                OcultarCampos();
                host = 1;
                tipoUsuario = "vendedor";
                grpRegistrar.Show();
            }
            else if (rdoBajaVend.Checked)
            {
                OcultarCampos();
                host = 1;
                tipoUsuario = "vendedor";
                ListarTodosLosUsuarios();
                cmbUsuarios.Location = cmbInactivos.Location;
                btnReactivar.Text = "Baja";
                cmbInactivos.Hide();
                grpBajaYReactivar.Show();
                cmbUsuarios.Show();
            }
            else if (rdoReactivarVend.Checked)
            {
                OcultarCampos();
                host = 1;
                tipoUsuario = "vendedor";
                ListarInactivos(listadoInactivos);
                btnReactivar.Text = "Reactivar";
                cmbUsuarios.Hide();
                grpBajaYReactivar.Show();
                cmbInactivos.Show();
            }
            else if (rdoAltaProv.Checked)
            {
                OcultarCampos();
                grpAltaProv.Show();
            }
            else if (rdoBajaProv.Checked)
            {
                OcultarCampos();
                btnmodprov.Text = "Baja";
                cmbProv.Location = cmbProvInactivos.Location;
                ListarProveedores();
                cmbProvInactivos.Hide();
                cmbProv.Show();
                grpBajaYReactivarProv.Show();

            }
            else if (rdoReactivarProv.Checked)
            {
                OcultarCampos();
                btnmodprov.Text = "Reactivar";
                ListarProvInactivos(listadoProvInactivos);
                cmbProvInactivos.Show();
                cmbProv.Hide();
                grpBajaYReactivarProv.Show();

            }
            else if (rdoAltaProd.Checked)
            {
                OcultarCampos();
                ListarProveedores();
                CategoriaProducto();
                grpAltaProd.Show();
            }
            else if (rdoModificarProd.Checked)
            {
                OcultarCampos();
                ListarProductos();
                grpBajaProd.Show();

            }
            else if (rdoBajaProd.Checked)
            {
                OcultarCampos();
                ListarProductos();
                grpBajaProd.Show();

            }
            else if (rdoReporteVentas.Checked)
            {
                OcultarCampos();
                //Reporte de Ventas por Vendedor
            }
            else if (rdoReporteStock.Checked)
            {
                OcultarCampos();
                //reporte stock critico
            }
            else if (rdoReporteProductos.Checked)
            {
                OcultarCampos();
                //reporte productos mas vendidos por categoria
            }
            else MessageBox.Show("Seleccione una opcion");
        }

        private void RegistrarUsuario(string idUsuario)
        {

            string nombre;
            string apellido;

            while (true)
            {
                try
                {

                    nombre = txtNombre.Text;
                    Validaciones.ValidarNombre(nombre);
                    break;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            while (true)
            {
                try
                {

                    apellido = txtApellido.Text;
                    Validaciones.ValidarApellido(apellido);
                    break;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            string username;
            while (true)
            {
                try
                {

                    username = txtUsername.Text;
                    Validaciones.ValidarUsername(nombre, apellido, username);
                    break;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            string direccion;

            while (true)
            {
                try
                {

                    direccion = txtDireccion.Text;
                    Validaciones.ValidarDireccion(direccion);
                    break;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            string telefono;

            while (true)
            {
                try
                {
                    ;
                    telefono = txtTelefono.Text;
                    Validaciones.ValidarTelefono(telefono);
                    break;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            string email;

            while (true)
            {
                try
                {

                    email = txtEmail.Text;
                    Validaciones.ValidarEmail(email);
                    break;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            int dni;
            string dni_entrada;

            while (true)
            {
                try
                {

                    dni_entrada = txtDni.Text;
                    Validaciones.ValidarDni(dni_entrada);
                    dni = int.Parse(dni_entrada);
                    break;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            string fecha;
            DateTime fechaNacimiento;

            while (true)
            {
                try
                {

                    fecha = txtFechaNac.Text;
                    Validaciones.ValidarFecha(fecha);
                    fechaNacimiento = DateTime.Parse(fecha);
                    break;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            bool response = gestorUsuarios.AgregarUsuario(nombre, host, dni, direccion, telefono,
                       apellido, email, FormLogin.id, username, fechaNacimiento);

            if (!response)
            {
                MessageBox.Show("Hubo un error al agregar el usuario supervisor. Por favor intente nuevamente.");
            }
            else
            {
                MessageBox.Show("Usuario supervisor agregado con éxito.");
            }




        }


        public void OcultarCampos()
        {
            grpRegistrar.Hide();
            grpBajaYReactivar.Hide();
            grpAltaProv.Hide();
            grpBajaYReactivarProv.Hide();
            grpAltaProd.Hide();
            grpBajaProd.Hide();
            grpBajaYReactivar.Location = grpRegistrar.Location;
            grpAltaProv.Location = grpRegistrar.Location;
            grpBajaYReactivarProv.Location = grpRegistrar.Location;
            grpAltaProd.Location = grpRegistrar.Location;
            grpBajaProd.Location = grpRegistrar.Location;
        }

        private void ListarTodosLosUsuarios()
        {
            List<Usuario> listadoUsuarios = gestorUsuarios.ObtenerListadoDeUsuarios();

            foreach (Usuario usuario in listadoUsuarios)
            {
                if (usuario.host == host)
                {
                    cmbUsuarios.Items.Add(usuario.nombre + " " + usuario.apellido);
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarUsuario(FormLogin.id);
        }


        private void btnReactivar_Click(object sender, EventArgs e)
        {
            if (btnReactivar.Text == "Reactivar")//implementar
            {
                if (cmbInactivos.Items.Count > 0 && cmbInactivos.SelectedIndex > 0)
                {
                    MessageBox.Show("Usuario Reactivado con éxito");
                }
                else MessageBox.Show("No se encontraron usuarios inactivos o no seleccionó ninguno.");


            }
            else if (btnReactivar.Text == "Baja")
            {
                BajaUsuarios(FormLogin.id, tipoUsuario);

            }
        }

        private void BajaUsuarios(string idUsuarioActual, string tipoUsuario)
        {

            List<Usuario> listadoUsuarios = gestorUsuarios.ObtenerListadoDeUsuarios();


            foreach (Usuario usuario in listadoUsuarios)
            {
                if (cmbUsuarios.Text == (usuario.nombre + " " + usuario.apellido))
                {
                    string idUsuarioBaja = usuario.Id.ToString();
                    bool bajaExitosa = gestorUsuarios.BajaUsuarios(idUsuarioBaja, idUsuarioActual);
                    if (bajaExitosa)
                    {
                        listadoInactivos.Add(usuario);
                        MessageBox.Show($"El usuario con ID {idUsuarioBaja} se encuentra Inactivo.");
                    }
                    else
                    {
                        MessageBox.Show("Error al deshabilitar el usuario. Por favor, inténtelo de nuevo.");
                    }
                }
            }
        }

        private void ListarInactivos(List<Usuario> lista)
        {
            foreach (Usuario usuario in lista)
            {
                if (usuario.host == host)
                {
                    cmbInactivos.Items.Add(usuario.nombre + " " + usuario.apellido);
                }
            }
        }
        private void ListarProvInactivos(List<Proveedor> lista)
        {
            foreach (Proveedor p in lista)
            {
                cmbProvInactivos.Items.Add(p.Nombre + " " + p.Apellido);
            }
        }

        private void AltaProveedores(string idUsuarioActual)
        {
            string nombre = txtNombreprov.Text;
            Validaciones.ValidarNombre(nombre);
            string apellido = txtApellidoprov.Text;
            Validaciones.ValidarApellido(apellido);
            string cuit = txtCUITprov.Text;
            Validaciones.ValidarCuit(cuit);
            string email = txtemailprov.Text;
            Validaciones.ValidarEmail(email);

            if (gestorDeProveedores.AltaProveedor(nombre, apellido, cuit, email, idUsuarioActual))
            {
                MessageBox.Show($"Proveedor {nombre} agregado con éxito.");
            }
            else
            {
                MessageBox.Show("Error al agregar el proveedor. Por favor, inténtelo de nuevo.");
            }
        }

        private void ListarProveedores()
        {
            List<Proveedor> proveedores = gestorDeProveedores.ListarProveedores();
            foreach (Proveedor p in proveedores)
            {
                cmbProv.Items.Add(p.Nombre + p.Apellido);
                cmbprovprod.Items.Add(p.Nombre + p.Apellido);
            }
        }

        private void btnRegistrarProv_Click(object sender, EventArgs e)
        {
            AltaProveedores(FormLogin.id);
        }

        private void BajaProveedores(string idUsuarioActual)
        {
            List<Proveedor> listadoProveedores = gestorDeProveedores.ListarProveedores();

            foreach (Proveedor p in listadoProveedores)
            {
                if (cmbProv.Text == (p.Nombre + " " + p.Apellido))
                {
                    string idProvBaja = p.Id.ToString();
                    bool bajaProvExitosa = gestorDeProveedores.BajaProveedor(idProvBaja, FormLogin.id);
                    if (bajaProvExitosa)
                    {
                        listadoProvInactivos.Add(p);
                        MessageBox.Show($"El proveedor con ID {idProvBaja} se encuentra Inactivo.");
                        listadoProveedores.Remove(p);
                    }
                    else
                    {
                        MessageBox.Show("Error al deshabilitar el proveedor. Por favor, inténtelo de nuevo.");
                    }
                }
            }



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
                MessageBox.Show("Error al deshabilitar el proveedor. Por favor, inténtelo de nuevo.");
            }


        }

        private void btnmodprov_Click(object sender, EventArgs e)
        {
            if (btnmodprov.Text == "Reactivar")//implementar
            {
                if (cmbProvInactivos.Items.Count > 0 && cmbProvInactivos.SelectedIndex > 0)
                {
                    MessageBox.Show("Proveedor Reactivado con éxito");
                }
                else MessageBox.Show("No se encontraron proveedores inactivos o no seleccionó ninguno.");


            }
            else if (btnmodprov.Text == "Baja")
            {
                BajaProveedores(FormLogin.id);

            }
        }
        

        private void btnAltaProducto_Click(object sender, EventArgs e)
        {
            AltaProducto(FormLogin.id);
        }

        private void CategoriaProducto()
        {
            cmbcategoria.Items.Add("1");
            cmbcategoria.Items.Add("2");
            cmbcategoria.Items.Add("3");
            cmbcategoria.Items.Add("4");
            cmbcategoria.Items.Add("5");
        }
        private void AltaProducto(string idUsuarioActual)
        {

            string nombre = txtNombreprod.Text;

            decimal precio = decimal.Parse(txtPrecio.Text);

            int stock = int.Parse(txtStock.Text);

            int categoria = int.Parse(cmbcategoria.Text);
            string idProveedor = "";
            cmbprovprod = cmbProv;
            List<Proveedor> proveedores = gestorDeProveedores.ListarProveedores();
            foreach (Proveedor p in proveedores)
            {
                if (cmbprovprod.Text == p.Nombre + p.Apellido)
                {
                    idProveedor = p.Id.ToString();
                }
            }

            if (gestorDeProductos.AgregarProducto(categoria, idUsuarioActual, idProveedor, nombre, precio, stock))
            {
                MessageBox.Show($"Producto {nombre} agregado con éxito.");
            }
            else
            {
                MessageBox.Show("Error al agregar el producto. Por favor, inténtelo de nuevo.");
            }
        }
        private void BajaProducto(string idUsuarioActual)
        {
            string idProducto = "";
            ListarProductos();
            List<Producto> productos = gestorDeProductos.TraerProductos();
            foreach (Producto p in productos)
            {
                if (cmbBajaProd.Text == p.nombre)
                {
                    idProducto = p.id;
                    productos.Remove(p);
                }
            }



            bool bajaExitosa = gestorDeProductos.BajaProductos(idProducto, idUsuarioActual);

            if (bajaExitosa)
            {
                MessageBox.Show($"El producto con ID {idProducto} se encuentra ha dado de baja.");
                ListarProductos();

            }
            else
            {
                MessageBox.Show("Error al deshabilitar el producto. Por favor, inténtelo de nuevo.");
            }
        }
        private void ListarProductos()
        {

            List<Producto> productos = gestorDeProductos.TraerProductos();
            foreach (Producto p in productos)
            {
                cmbBajaProd.Items.Add(p.nombre);
            }
        }

        private void btnBajaProd_Click(object sender, EventArgs e)
        {
            BajaProducto(FormLogin.id);
        }
    }
}

