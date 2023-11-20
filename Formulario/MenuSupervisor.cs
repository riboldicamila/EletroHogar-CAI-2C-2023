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
    public partial class MenuSupervisor : Form
    {
        public MenuSupervisor()
        {
            InitializeComponent();
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

        public void OcultarCampos()
        {
            grpAltaProd.Hide();
            grpBajaProd.Hide();
            grpBajaProd.Location = grpAltaProd.Location;
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {

            if (rdoAltaProductos.Checked)
            {
                OcultarCampos();
                ListarProveedores();
                CategoriaProducto();
                grpAltaProd.Show();
            }
            else if (rdoBajaProd.Checked)
            {
                OcultarCampos();
                ListarProductos();
                grpBajaProd.Show();
            }
            else if (rdoModificarProd.Checked)
            {
                //Modificar Producto
            }
            else if (rdoDevolucion.Checked)
            {
                //Devoluciones
            }
            else if (rdoReporteStock.Checked)
            {
                //reporte stock
            }
            else if (rdoReporteVentas.Checked)
            {
                //reporte ventas
            }
            else if (rdoReporteProductos.Checked)
            {
                //reporte productos
            }
            else MessageBox.Show("Seleccione una opcion");
        }
        private void ListarProveedores()
        {
            List<Proveedor> proveedores = gestorDeProveedores.ListarProveedores();
            foreach (Proveedor p in proveedores)
            {
                cmbprovprod.Items.Add(p.Nombre + p.Apellido);
            }
        }
        private void CategoriaProducto()
        {
            cmbcategoria.Items.Add("1");
            cmbcategoria.Items.Add("2");
            cmbcategoria.Items.Add("3");
            cmbcategoria.Items.Add("4");
            cmbcategoria.Items.Add("5");
        }
        private void ListarProductos()
        {

            List<Producto> productos = gestorDeProductos.TraerProductos();
            foreach (Producto p in productos)
            {
                cmbBajaProd.Items.Add(p.nombre);
            }
        }
        private void AltaProducto(string idUsuarioActual)
        {

            string nombre = txtNombreprod.Text;

            decimal precio = decimal.Parse(txtPrecio.Text);

            int stock = int.Parse(txtStock.Text);

            int categoria = int.Parse(cmbcategoria.Text);
            string idProveedor = "";
            List<Proveedor> proveedoreslist = gestorDeProveedores.ListarProveedores();
            foreach (Proveedor p in proveedoreslist)
            {
                cmbprovprod.Items.Add(p.Nombre + p.Apellido);
            }

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
        private void btnAltaProducto_Click(object sender, EventArgs e)
        {
            AltaProducto(FormLogin.id);
        }
        private void btnBajaProd_Click(object sender, EventArgs e)
        {
            BajaProducto(FormLogin.id);
        }
        private void DevolverVentas(string idUsuarioActual)
        {
            
            string idVenta = Console.ReadLine();

            bool bajaExitosa = gestorDeVentas.DevolverVenta(idVenta, idUsuarioActual);

            if (bajaExitosa)
            {
                MessageBox.Show($"La venta con ID {idVenta} se encuentra Inactivo.");
            }
            else
            {
                Console.WriteLine("Error al devolver venta. Por favor, inténtelo de nuevo.");
            }

            Thread.Sleep(3000);
            Console.Clear();
        }
    }
}
