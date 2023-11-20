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
        List<UsuarioWS> listadoInactivos = new List<UsuarioWS>();
        private GestorDeUsuarios gestorUsuarios = new GestorDeUsuarios();
        //private void btnSeleccion_Click(object sender, EventArgs e)
        //{
        //}

        private void btnSeleccion_Click_1(object sender, EventArgs e)
        {
            if (rdoAltaSup.Checked)
            {
                host = 2;
                tipoUsuario = "supervisor";
                grpRegistrar.Show();
            }
            else if (rdoBajaSup.Checked)
            {
                host = 2;
                tipoUsuario = "supervisor";
                ListarTodosLosUsuarios();
                cmbUsuarios.Location = cmbInactivos.Location;
                btnReactivar.Text = "Baja";
                cmbInactivos.Hide();
                grpBajaYReactivar.Show();
            }
            else if (rdoReactivarSup.Checked)
            {
                host = 2;
                tipoUsuario = "supervisor";
                ListarInactivos(listadoInactivos);
                btnReactivar.Text = "Reactivar";
                cmbUsuarios.Hide();
                grpBajaYReactivar.Show();

            }
            else if (rdoAltaVend.Checked)
            {
                host = 1;
                tipoUsuario = "vendedor";
                grpRegistrar.Show();
            }
            else if (rdoBajaVend.Checked)
            {
                host = 1;
                tipoUsuario = "vendedor";
                ListarTodosLosUsuarios();
                cmbUsuarios.Location = cmbInactivos.Location;
                btnReactivar.Text = "Baja";
                cmbInactivos.Hide();
                grpBajaYReactivar.Show();
            }
            else if (rdoReactivarVend.Checked)
            {
                host = 1;
                tipoUsuario = "vendedor";
                ListarInactivos(listadoInactivos);
                btnReactivar.Text = "Reactivar";
                cmbUsuarios.Hide();
                grpBajaYReactivar.Show();
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


        public void OcultarCampos()
        {
            grpRegistrar.Hide();
            grpBajaYReactivar.Hide();

        }

        private void ListarTodosLosUsuarios()
        {
            List<UsuarioWS> listadoUsuarios = gestorUsuarios.ObtenerListadoDeUsuarios();

            foreach (UsuarioWS usuario in listadoUsuarios)
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
            if (btnReactivar.Text == "Reactivar")
            {
                //implementar
                MessageBox.Show("Usuario Reactivado con éxito");
            }
            else if (btnReactivar.Text == "Baja")
            {
                BajaUsuarios(FormLogin.id, tipoUsuario);

            }
        }

        private void BajaUsuarios(string idUsuarioActual, string tipoUsuario)
        {
            
            List<UsuarioWS> listadoUsuarios = gestorUsuarios.ObtenerListadoDeUsuarios();
            

            foreach (UsuarioWS usuario in listadoUsuarios)
            {
                if (cmbUsuarios.Text == (usuario.nombre + " " + usuario.apellido))
                {
                    string idUsuarioBaja = usuario.id.ToString();
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

        private void ListarInactivos(List<UsuarioWS> lista)
        {
            foreach (UsuarioWS usuario in lista)
            {
                if (usuario.host == host)
                {
                    cmbInactivos.Items.Add(usuario.nombre + " " + usuario.apellido);
                }
            }
        }
    }
}
