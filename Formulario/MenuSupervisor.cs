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
    public partial class MenuSupervisor : Form
    {
        public MenuSupervisor()
        {
            InitializeComponent();
        }

        

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            
            if (rdoAltaProductos.Checked)
            {
                //Alta Productos
            }
            else if (rdoBajaProd.Checked)
            {
                //bAJA Productos
            }
            else if (rdoModificarProd.Checked)
            {
                //Modificar Producto
            }
            else if (rdoDevolucion.Checked)
            {
                //Devoluciones
            }
            else if (rdoReporteStock.Checked)
            {
                //reporte stock
            }
            else if (rdoReporteVentas.Checked)
            {
                //reporte ventas
            }
            else if (rdoReporteProductos.Checked)
            {
                //reporte productos
            }
            else MessageBox.Show("Seleccione una opcion");
        }
    }
}
