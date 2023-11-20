using Modelo;
using Negocio;

namespace Formulario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GestorDeUsuarios gestorDeUsuarios = new GestorDeUsuarios();
           // listBox1.DataSource = gestorDeUsuarios.ObtenerTodosLosUsuarios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Usuario usuarioSeleccionado = (Usuario)listBox1.SelectedItem;
            textBox1.Text = usuarioSeleccionado.Nombre;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}