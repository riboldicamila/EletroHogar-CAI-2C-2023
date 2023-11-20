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
    public partial class MenuVendedor : Form
    {
        public MenuVendedor()
        {
            InitializeComponent();
        }
        
        string msj = "";
        private GestorDeProductos gestorDeProductos = new GestorDeProductos();
        private GestorDeVentas gestorDeVentas = new GestorDeVentas();
        private GestorDeClientes gestorDeClientes = new GestorDeClientes();
        public void OcultarCampos()
        {
            grpVenta.Hide();
            grpRegistrar.Hide();
            grpRegistrar.Location = grpVenta.Location;
        }
        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            if (rdoAgregarCliente.Checked)
            {
                OcultarCampos();
                grpRegistrar.Show();

            }
            else if (rdoAgregarVenta.Checked)
            {
                OcultarCampos();
                ListarClientes();
                ListarProductos();
                grpVenta.Show();
            }
            else if (rdoReporteVenta.Checked)
            {
                OcultarCampos();
            }
        }
        private void AgregarVenta(string idUsuarioActual)
        {
            string idCliente = "";
            List<Cliente> cliente = gestorDeClientes.ListarClientes();
            foreach (Cliente c in cliente)
            {
                if (c.nombre == cmbclientes.Text)
                {
                    idCliente = c.id.ToString();
                }
            }

            List<Ventas> lista = new List<Ventas>();
            string idProducto = "";
            while (true)
            {
                List<Producto> productos = gestorDeProductos.TraerProductos();
                foreach (Producto p in productos)
                {
                    if (p.nombre == cmbproducto.Text)
                    {
                        idProducto = p.id.ToString();
                    }
                }


                int cantidad;

                while (!int.TryParse(txtcantidad.Text, out cantidad))
                {
                    MessageBox.Show("Por favor, ingrese un valor numérico válido para la cantidad:");
                }

                gestorDeVentas.AgregarAListaVenta(lista, idUsuarioActual, idCliente, idProducto, cantidad);
                bool response;
                response = gestorDeVentas.LlamarWSporProducto(lista);

                if (!response)
                {
                    MessageBox.Show("Error al agregar venta.");
                }
                else
                {
                    MessageBox.Show("Resumen de la venta: " + lista);
                    //con datos de la lista local
                    //mostrar el descuento aca tambien
                    //sistema de descuentos 
                }
            }


        }
        private void ListarClientes()
        {

            List<Cliente> cliente = gestorDeClientes.ListarClientes();
            foreach (Cliente c in cliente)
            {
                cmbclientes.Items.Add(c.ToString());
            }

        }
        private void ListarProductos()
        {

            List<Producto> productos = gestorDeProductos.TraerProductos();
            foreach (Producto p in productos)
            {
                cmbproducto.Items.Add(p.nombre);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarVenta(FormLogin.id);
        }
        private void RegistrarCliente(string idUsuario)
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
                    msj += (ex.Message + System.Environment.NewLine);
                    
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
                    msj += (ex.Message + System.Environment.NewLine);
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
                    msj += (ex.Message + System.Environment.NewLine);
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
                    msj += (ex.Message + System.Environment.NewLine);
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
                    msj += (ex.Message + System.Environment.NewLine);
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
                    msj += (ex.Message + System.Environment.NewLine);
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
                    msj += (ex.Message + System.Environment.NewLine);
                }
            }

            if (gestorDeClientes.AgregarCliente(nombre, "Grupo2", dni, direccion, telefono, apellido, email, FormLogin.id, fechaNacimiento))
            {
                MessageBox.Show($"Cliente {nombre} agregado con éxito.");

            }
            else
            {
                MessageBox.Show("Error al agregar el cliente. Por favor, inténtelo de nuevo.");
                MessageBox.Show(msj);
            }



        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarCliente(FormLogin.id);
        }
    }
}
