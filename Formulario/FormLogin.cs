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
    public partial class FormLogin : Form
    {
        public static string id = "";
        public FormLogin()
        {
            InitializeComponent();
           
        }
        string idUsuario;
        private GestorDeUsuarios gestorUsuarios = new GestorDeUsuarios();
        private GestorDeProductos gestorDeProductos = new GestorDeProductos();
        private GestorDeProveedores gestorDeProveedores = new GestorDeProveedores();
        private GestorDeVentas gestorDeVentas = new GestorDeVentas();
        private GestorDeClientes gestorDeClientes = new GestorDeClientes();
        private MenuSupervisor menuSupervisor = new MenuSupervisor();
        private MenuAdministrador menuAdministrador = new MenuAdministrador();
        private MenuVendedor menuVendedor = new MenuVendedor();


        private void btnLogin_Click(object sender, EventArgs e)
        {
            idUsuario = LoginMenu(gestorUsuarios, txtUsername.Text, txtPassword.Text);

            MostrarMenu(idUsuario, txtUsername.Text, txtPassword.Text);
            


           
        }

        private static string LoginMenu(GestorDeUsuarios gestorDeUsuarios, string nombreUsuario, string contraseña)
        {

            Login login = new Login();
            login.NombreUsuario = nombreUsuario;
            login.Contraseña = contraseña;

            try
            {
                string idUsuario = gestorDeUsuarios.Login(login);
                MessageBox.Show("Login exitoso. El idUusario es " + idUsuario);
                id = idUsuario;
                gestorDeUsuarios.LimpiarListaDeControl(nombreUsuario);
                return idUsuario;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al hacer login.");
                MessageBox.Show(ex.Message);

                bool quedanIntentos = gestorDeUsuarios.ListaDeControl(nombreUsuario);

                if (!quedanIntentos)
                {
                    MessageBox.Show("El usuario está bloqueado. Demasiados intentos fallidos.");
                    MessageBox.Show("La aplicación se Cerrará");
                    return "error";
                    Application.Exit();
                }
            }

            return "";


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

            //MessageBox.Show(usuarioActualTipo);




            if (usuarioActualTipo == "vendedor")
            {
                menuVendedor = new MenuVendedor();
                menuVendedor.Show();
            }
            else if (usuarioActualTipo == "supervisor")
            {
                menuSupervisor= new MenuSupervisor();
                menuSupervisor.Show();
            }
            else
            {
                menuAdministrador = new MenuAdministrador();
                menuAdministrador.Show();
            }



            //Modificar segun acciones de botón
            // Se haria en el codigo de cada formulario específico
           

            //Console.WriteLine("Cerrando sesión...");
            //Thread.Sleep(8000);
            //Console.Clear();
            //Iniciar();

        }
        
        //Adaptar a formulario
        private void SolicitarCambioDeContraseña(string nombreUsuario, string contraseña)
        {
           
            MessageBox.Show("Debe cambiar su contraseña.");
            bool cambioExitoso = false;
            string nuevaContraseña;

            while (!cambioExitoso)
            {
                MessageBox.Show("Ingrese la nueva contraseña:");
                nuevaContraseña = Console.ReadLine();

                try
                {
                    cambioExitoso = gestorUsuarios.EstablecerContraseña(nombreUsuario, contraseña, nuevaContraseña);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
    
}
