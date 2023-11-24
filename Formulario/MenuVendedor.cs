using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
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

                if (!int.TryParse(txtcantidad.Text, out cantidad))
                {
                    MessageBox.Show("Por favor, ingrese un valor numérico válido para la cantidad:");
                }


                //gestorDeVentas.AgregarAListaVenta(lista, idUsuarioActual, idCliente, idProducto, cantidad);
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

            string nombre = "";
            string apellido = "";

            try
            {

                nombre = txtNombre.Text;
                Validaciones.ValidarNombre(nombre);

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);

            }


            try
            {

                apellido = txtApellido.Text;
                Validaciones.ValidarApellido(apellido);

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

            string direccion = "";

            try
            {

                direccion = txtDireccion.Text;
                Validaciones.ValidarDireccion(direccion);

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

            string telefono = "";

            try
            {
                ;
                telefono = txtTelefono.Text;
                Validaciones.ValidarTelefono(telefono);

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }


            string email = "";


            try
            {

                email = txtEmail.Text;
                Validaciones.ValidarEmail(email);

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }


            int dni = 0;
            string dni_entrada;


            try
            {

                dni_entrada = txtDni.Text;
                Validaciones.ValidarDni(dni_entrada);
                dni = int.Parse(dni_entrada);

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

           
            fechapicker.Format = DateTimePickerFormat.Custom;
            fechapicker.CustomFormat = "YYYY-DD-MM";


            DateTime fecha = fechapicker.Value;
            if (fechapicker.Value > DateTime.Today || fechapicker.Value < new DateTime(1900, 1, 1))
            {
                MessageBox.Show("la fecha es inválida.");
                fechapicker.ResetText();
            }

            


            if (gestorDeClientes.AgregarCliente(nombre, "Grupo2", dni, direccion, telefono, apellido, email, FormLogin.id, fecha))
            {
                MessageBox.Show($"Cliente {nombre} agregado con éxito.");

            }
            else
            {
                MessageBox.Show("Error al agregar el cliente. Por favor, inténtelo de nuevo.");

            }



        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarCliente(FormLogin.id);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se cerrará la aplicación. CONFIRMAR", "Cerrar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show("La aplicación se cerró exitosamente.", "Hasta luego!", MessageBoxButtons.OK);
                Application.Exit();
            }
            else
            {
                this.Activate();
            }
        }
    }
}
