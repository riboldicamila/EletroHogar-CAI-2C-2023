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


        private void btnLogin_Click(object sender, EventArgs e)
        {
            idUsuario = LoginMenu(gestorUsuarios, txtUsername.Text, txtPassword.Text);

        }

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
    }
}
