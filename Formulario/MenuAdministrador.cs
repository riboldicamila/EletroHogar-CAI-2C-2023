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
        private GestorDeUsuarios gestorUsuarios = new GestorDeUsuarios();
        //private void btnSeleccion_Click(object sender, EventArgs e)
        //{
        //}

        private void btnSeleccion_Click_1(object sender, EventArgs e)
        {
            if (rdoAltaSup.Checked)
            {
                MostrarCampos();
                host = 2;

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
                MostrarCampos();
                host = 1;
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

        public void MostrarCampos()
        {
            grpRegistrar.Show();
           
        }
        public void OcultarCampos()
        {
            grpRegistrar.Hide();
            
        }

        //Adaptar a formulario
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarUsuario(FormLogin.id);
        }
    }
}
