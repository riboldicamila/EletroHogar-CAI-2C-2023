using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectroHogarEj.InterfazForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInicioSesion_Click(object sender, EventArgs e)
        {

            if(Validar())
            {
                MessageBox.Show("Wow, estamos en reparación.");
            }
            else
            {
                MessageBox.Show("Wow, estamos en reparación.");
            }
           
        }

        private bool Validar()
        {
            return true;
            //todos los text box 
        }
    }
}
