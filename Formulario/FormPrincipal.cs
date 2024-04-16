using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Formulario
{
    public partial class Acceso : Form
    {
        private GestorDeUsuarios _gestorUsuarios;
        private GestorDeProductos _gestorDeProductos;
        private GestorDeProveedores _gestorDeProveedores;
        private GestorDeVentas _gestorDeVentas;
        private GestorDeClientes _gestorDeClientes;

        public Acceso()
        {
            InitializeComponent();

            _gestorUsuarios = new GestorDeUsuarios();

        }

        private void AltaUsuarios()
        {
            _gestorUsuarios.

        }



        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
