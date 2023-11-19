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

        }
        private GestorDeUsuarios gestorUsuarios = new GestorDeUsuarios();
        //private void btnSeleccion_Click(object sender, EventArgs e)
        //{
        //}

        private void btnSeleccion_Click_1(object sender, EventArgs e)
        {
            if (rdoAltaSup.Checked)
            {
                RegistrarUsuarioSupervisor(FormLogin.id);
            }
            else if (rdoBajaSup.Checked)
            {
                //Baja Supervisores
            }
            else if (rdoReactivarSup.Checked)
            {
                //Reactivar Supervisores
            }
            else if (rdoAltaVend.Checked)
            {
                //Alta Vendedores
            }
            else if (rdoBajaVend.Checked)
            {
                //Baja Vendedores
            }
            else if (rdoReactivarVend.Checked)
            {
                //Reactivar Vendedores
            }
            else if (rdoAltaProv.Checked)
            {
                //Alta Proveedores
            }
            else if (rdoBajaProv.Checked)
            {
                //Baja Proveedores
            }
            else if (rdoReactivarProv.Checked)
            {
                //Reactivar Proveedor
            }
            else if (rdoAltaProd.Checked)
            {
                //Alta producto
            }
            else if (rdoModificarProd.Checked)
            {
                //ModificarProducto
            }
            else if (rdoBajaProd.Checked)
            {
                //Baja Producto
            }
            else if (rdoReporteVentas.Checked)
            {
                //Reporte de Ventas por Vendedor
            }
            else if (rdoReporteStock.Checked)
            {
                //reporte stock critico
            }
            else if (rdoReporteProductos.Checked)
            {
                //reporte productos mas vendidos por categoria
            }
            else MessageBox.Show("Seleccione una opcion");
        }

        private void RegistrarUsuarioSupervisor(string idUsuario)
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
            bool response = gestorUsuarios.AgregarUsuario(nombre, 2, dni, direccion, telefono,
                       apellido, email, FormLogin.id, username, fechaNacimiento);

            if (!response)
            {
                MessageBox.Show("Hubo un error al agregar el usuario supervisor. Por favor intente nuevamente.");
            }
            else
            {
                MessageBox.Show("Usuario supervisor agregado con éxito.");
            }

            
            Console.WriteLine("Lista de usuarios existentes: ");
            ListarTodosLosUsuarios();
            Console.WriteLine();
            Console.WriteLine();

        }

        public void MostrarCampos()
        {
            lblNombre.Show();
            lblApellido.Show();
            lblUsername.Show();
            lblDireccion.Show();
            lblDNI.Show();
            lblEmail.Show();
            lblFechaNac.Show();
            lblTelefono.Show();
            txtApellido.Show();
            txtNombre.Show();
            txtUsername.Show();
            txtDireccion.Show();
            txtDni.Show();
            txtEmail.Show();
            txtFechaNac.Show();
            txtTelefono.Show();
        }
        public void OcultarCampos()
        {
            lblNombre.Hide();
            lblApellido.Hide();
            lblUsername.Hide();
            lblDireccion.Hide();
            lblDNI.Hide();
            lblEmail.Hide();
            lblFechaNac.Hide();
            lblTelefono.Hide();
            txtApellido.Hide();
            txtNombre.Hide();
            txtUsername.Hide();
            txtDireccion.Hide();
            txtDni.Hide();
            txtEmail.Hide();
            txtFechaNac.Hide();
            txtTelefono.Hide();
        }
    }
}
