﻿using Modelo;
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
                MessageBox.Show("Login exitoso. El idUusario es " + idUsuario);
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

            MessageBox.Show(usuarioActualTipo);

            Console.Clear();

            
            if (usuarioActualTipo == "vendedor")
            {
                new MenuVendedor();
            }
            else if (usuarioActualTipo == "supervisor")
            {
                new MenuSupervisor();
            }
            else new MenuAdministrador();


            //Modificar segun acciones de botón
            // Se haria en el codigo de cada formulario específico
            if (usuarioActualTipo == "administrador")
            {
                //Alta Usuarios Supervisores
                if (opcionSeleccionada == "1")
                {
                    Console.WriteLine("GENERAR ALTA/NUEVO USUARIO SUPERVISOR");
                    RegistrarUsuarioSupervisor(idUsuarioActual);

                }

                //Modificacion de Usuarios Supervisores
                if (opcionSeleccionada == "2")
                {
                    ReactivarUsuario(idUsuarioActual);

                }

                //Baja Supervisores
                if (opcionSeleccionada == "3")
                {
                    BajaUsuarios(idUsuarioActual, "SUPERVISOR");
                }

                //ALTA Vendedores
                if (opcionSeleccionada == "4")
                {

                    Console.WriteLine("GENERAR ALTA/NUEVO USUARIO VENDEDORES");
                    RegistrarUsuarioVendedor(idUsuarioActual);

                }

                if (opcionSeleccionada == "5")
                {
                    ReactivarUsuario(idUsuarioActual);

                }

                if (opcionSeleccionada == "6")
                {
                    //VENDEDOR
                    BajaUsuarios(idUsuarioActual, "VENDEDOR");

                }

                if (opcionSeleccionada == "7")
                {
                    AltaProveedores(idUsuarioActual);
                }

                if (opcionSeleccionada == "8")
                {
                    //NO ESTA IMPLEMENTADO
                    ModificacionProveedores();
                }

                if (opcionSeleccionada == "9")
                {

                    BajaProveedores(idUsuarioActual);
                }

                if (opcionSeleccionada == "10")
                {
                    AltaProducto(idUsuarioActual);
                }

                if (opcionSeleccionada == "11")
                {
                    ModificarProducto();
                }

                if (opcionSeleccionada == "12")
                {
                    BajaProducto(idUsuarioActual);
                }
            }


            if (usuarioActualTipo == "supervisor")
            {
                if (opcionSeleccionada == "1")
                {
                    AltaProducto(idUsuarioActual);
                }

                if (opcionSeleccionada == "2")
                {
                    ModificarProducto();
                }

                if (opcionSeleccionada == "3")
                {
                    BajaProducto(idUsuarioActual);
                }

                if (opcionSeleccionada == "4")
                {
                    DevolverVentas(idUsuarioActual);
                }
            }


            if (usuarioActualTipo == "vendedor")
            {
                if (opcionSeleccionada == "1")
                {
                    RegistrarVenta(idUsuarioActual);
                }

                if (opcionSeleccionada == "2")
                {
                    ReporteVentas();
                }

                if (opcionSeleccionada == "3")
                {
                    RegistrarCliente(idUsuarioActual);
                }

                if (opcionSeleccionada == "4")
                {
                    ModificarCliente(idUsuarioActual);
                }

            }


            Console.WriteLine("Cerrando sesión...");
            Thread.Sleep(8000);
            Console.Clear();
            Iniciar();

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
