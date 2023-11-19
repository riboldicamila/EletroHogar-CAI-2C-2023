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

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            if (rdoAltaSup.Checked)
            {
                //Alta Supervisores
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



        }
    }
}
