namespace Formulario
{
    partial class MenuSupervisor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpOpciones = new GroupBox();
            btnSeleccion = new Button();
            btnSalir = new Button();
            rdoReporteProductos = new RadioButton();
            rdoReporteVentas = new RadioButton();
            rdoReporteStock = new RadioButton();
            rdoBajaProd = new RadioButton();
            rdoDevolucion = new RadioButton();
            rdoModificarProd = new RadioButton();
            rdoAltaProductos = new RadioButton();
            grpAltaProd = new GroupBox();
            cmbprovprod = new ComboBox();
            btnAltaProducto = new Button();
            cmbcategoria = new ComboBox();
            lblProveedorDummy = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            txtStock = new TextBox();
            txtPrecio = new TextBox();
            txtNombreprod = new TextBox();
            grpBajaProd = new GroupBox();
            lblNombreProd = new Label();
            btnBajaProd = new Button();
            cmbBajaProd = new ComboBox();
            grpDevolucion = new GroupBox();
            txtventa = new TextBox();
            btnDevolucion = new Button();
            label1 = new Label();
            grpOpciones.SuspendLayout();
            grpAltaProd.SuspendLayout();
            grpBajaProd.SuspendLayout();
            grpDevolucion.SuspendLayout();
            SuspendLayout();
            // 
            // grpOpciones
            // 
            grpOpciones.Controls.Add(btnSeleccion);
            grpOpciones.Controls.Add(btnSalir);
            grpOpciones.Controls.Add(rdoReporteProductos);
            grpOpciones.Controls.Add(rdoReporteVentas);
            grpOpciones.Controls.Add(rdoReporteStock);
            grpOpciones.Controls.Add(rdoBajaProd);
            grpOpciones.Controls.Add(rdoDevolucion);
            grpOpciones.Controls.Add(rdoModificarProd);
            grpOpciones.Controls.Add(rdoAltaProductos);
            grpOpciones.Location = new Point(12, 12);
            grpOpciones.Name = "grpOpciones";
            grpOpciones.Size = new Size(355, 249);
            grpOpciones.TabIndex = 0;
            grpOpciones.TabStop = false;
            grpOpciones.Text = "Seleccione una Opcion";
            // 
            // btnSeleccion
            // 
            btnSeleccion.Location = new Point(104, 220);
            btnSeleccion.Name = "btnSeleccion";
            btnSeleccion.Size = new Size(75, 23);
            btnSeleccion.TabIndex = 8;
            btnSeleccion.Text = "Seleccionar";
            btnSeleccion.UseVisualStyleBackColor = true;
            btnSeleccion.Click += btnSeleccion_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(23, 220);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // rdoReporteProductos
            // 
            rdoReporteProductos.AutoSize = true;
            rdoReporteProductos.Location = new Point(23, 175);
            rdoReporteProductos.Name = "rdoReporteProductos";
            rdoReporteProductos.Size = new Size(215, 19);
            rdoReporteProductos.TabIndex = 6;
            rdoReporteProductos.TabStop = true;
            rdoReporteProductos.Text = "Reporte de Productos mas Vendidos";
            rdoReporteProductos.UseVisualStyleBackColor = true;
            // 
            // rdoReporteVentas
            // 
            rdoReporteVentas.AutoSize = true;
            rdoReporteVentas.Location = new Point(23, 150);
            rdoReporteVentas.Name = "rdoReporteVentas";
            rdoReporteVentas.Size = new Size(177, 19);
            rdoReporteVentas.TabIndex = 5;
            rdoReporteVentas.TabStop = true;
            rdoReporteVentas.Text = "Reporte Ventas por Vendedor";
            rdoReporteVentas.UseVisualStyleBackColor = true;
            // 
            // rdoReporteStock
            // 
            rdoReporteStock.AutoSize = true;
            rdoReporteStock.Location = new Point(23, 125);
            rdoReporteStock.Name = "rdoReporteStock";
            rdoReporteStock.Size = new Size(136, 19);
            rdoReporteStock.TabIndex = 4;
            rdoReporteStock.TabStop = true;
            rdoReporteStock.Text = "Reporte Stock Critico";
            rdoReporteStock.UseVisualStyleBackColor = true;
            // 
            // rdoBajaProd
            // 
            rdoBajaProd.AutoSize = true;
            rdoBajaProd.Location = new Point(23, 75);
            rdoBajaProd.Name = "rdoBajaProd";
            rdoBajaProd.Size = new Size(104, 19);
            rdoBajaProd.TabIndex = 3;
            rdoBajaProd.TabStop = true;
            rdoBajaProd.Text = "Baja Productos";
            rdoBajaProd.UseVisualStyleBackColor = true;
            // 
            // rdoDevolucion
            // 
            rdoDevolucion.AutoSize = true;
            rdoDevolucion.Location = new Point(23, 100);
            rdoDevolucion.Name = "rdoDevolucion";
            rdoDevolucion.Size = new Size(85, 19);
            rdoDevolucion.TabIndex = 2;
            rdoDevolucion.TabStop = true;
            rdoDevolucion.Text = "Devolucion";
            rdoDevolucion.UseVisualStyleBackColor = true;
            // 
            // rdoModificarProd
            // 
            rdoModificarProd.AutoSize = true;
            rdoModificarProd.Location = new Point(23, 50);
            rdoModificarProd.Name = "rdoModificarProd";
            rdoModificarProd.Size = new Size(168, 19);
            rdoModificarProd.TabIndex = 1;
            rdoModificarProd.TabStop = true;
            rdoModificarProd.Text = "Modificacion de Productos";
            rdoModificarProd.UseVisualStyleBackColor = true;
            // 
            // rdoAltaProductos
            // 
            rdoAltaProductos.AutoSize = true;
            rdoAltaProductos.Location = new Point(23, 25);
            rdoAltaProductos.Name = "rdoAltaProductos";
            rdoAltaProductos.Size = new Size(103, 19);
            rdoAltaProductos.TabIndex = 0;
            rdoAltaProductos.TabStop = true;
            rdoAltaProductos.Text = "Alta Productos";
            rdoAltaProductos.UseVisualStyleBackColor = true;
            // 
            // grpAltaProd
            // 
            grpAltaProd.Controls.Add(cmbprovprod);
            grpAltaProd.Controls.Add(btnAltaProducto);
            grpAltaProd.Controls.Add(cmbcategoria);
            grpAltaProd.Controls.Add(lblProveedorDummy);
            grpAltaProd.Controls.Add(label10);
            grpAltaProd.Controls.Add(label9);
            grpAltaProd.Controls.Add(label8);
            grpAltaProd.Controls.Add(label7);
            grpAltaProd.Controls.Add(label6);
            grpAltaProd.Controls.Add(txtStock);
            grpAltaProd.Controls.Add(txtPrecio);
            grpAltaProd.Controls.Add(txtNombreprod);
            grpAltaProd.Location = new Point(404, 12);
            grpAltaProd.Name = "grpAltaProd";
            grpAltaProd.Size = new Size(371, 100);
            grpAltaProd.TabIndex = 35;
            grpAltaProd.TabStop = false;
            // 
            // cmbprovprod
            // 
            cmbprovprod.FormattingEnabled = true;
            cmbprovprod.Location = new Point(269, 26);
            cmbprovprod.Name = "cmbprovprod";
            cmbprovprod.Size = new Size(90, 23);
            cmbprovprod.TabIndex = 40;
            // 
            // btnAltaProducto
            // 
            btnAltaProducto.Location = new Point(271, 70);
            btnAltaProducto.Name = "btnAltaProducto";
            btnAltaProducto.Size = new Size(75, 23);
            btnAltaProducto.TabIndex = 39;
            btnAltaProducto.Text = "Alta";
            btnAltaProducto.UseVisualStyleBackColor = true;
            // 
            // cmbcategoria
            // 
            cmbcategoria.FormattingEnabled = true;
            cmbcategoria.Location = new Point(145, 26);
            cmbcategoria.Name = "cmbcategoria";
            cmbcategoria.Size = new Size(58, 23);
            cmbcategoria.TabIndex = 38;
            // 
            // lblProveedorDummy
            // 
            lblProveedorDummy.AutoSize = true;
            lblProveedorDummy.Location = new Point(269, 26);
            lblProveedorDummy.Name = "lblProveedorDummy";
            lblProveedorDummy.Size = new Size(0, 15);
            lblProveedorDummy.TabIndex = 37;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(271, 8);
            label10.Name = "label10";
            label10.Size = new Size(61, 15);
            label10.TabIndex = 36;
            label10.Text = "Proveedor";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(145, 8);
            label9.Name = "label9";
            label9.Size = new Size(58, 15);
            label9.TabIndex = 35;
            label9.Text = "Categoria";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(145, 53);
            label8.Name = "label8";
            label8.Size = new Size(70, 15);
            label8.TabIndex = 34;
            label8.Text = "Stock Inicial";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 53);
            label7.Name = "label7";
            label7.Size = new Size(40, 15);
            label7.TabIndex = 33;
            label7.Text = "Precio";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 8);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 32;
            label6.Text = "Nombre";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(145, 71);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 19;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(11, 71);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 18;
            // 
            // txtNombreprod
            // 
            txtNombreprod.Location = new Point(11, 26);
            txtNombreprod.Name = "txtNombreprod";
            txtNombreprod.Size = new Size(100, 23);
            txtNombreprod.TabIndex = 17;
            // 
            // grpBajaProd
            // 
            grpBajaProd.Controls.Add(lblNombreProd);
            grpBajaProd.Controls.Add(btnBajaProd);
            grpBajaProd.Controls.Add(cmbBajaProd);
            grpBajaProd.Location = new Point(404, 118);
            grpBajaProd.Name = "grpBajaProd";
            grpBajaProd.Size = new Size(200, 100);
            grpBajaProd.TabIndex = 36;
            grpBajaProd.TabStop = false;
            // 
            // lblNombreProd
            // 
            lblNombreProd.AutoSize = true;
            lblNombreProd.Location = new Point(20, 9);
            lblNombreProd.Name = "lblNombreProd";
            lblNombreProd.Size = new Size(61, 15);
            lblNombreProd.TabIndex = 33;
            lblNombreProd.Text = "Productos";
            // 
            // btnBajaProd
            // 
            btnBajaProd.Location = new Point(119, 71);
            btnBajaProd.Name = "btnBajaProd";
            btnBajaProd.Size = new Size(75, 23);
            btnBajaProd.TabIndex = 1;
            btnBajaProd.Text = "Baja";
            btnBajaProd.UseVisualStyleBackColor = true;
            // 
            // cmbBajaProd
            // 
            cmbBajaProd.FormattingEnabled = true;
            cmbBajaProd.Location = new Point(20, 33);
            cmbBajaProd.Name = "cmbBajaProd";
            cmbBajaProd.Size = new Size(121, 23);
            cmbBajaProd.TabIndex = 0;
            // 
            // grpDevolucion
            // 
            grpDevolucion.Controls.Add(txtventa);
            grpDevolucion.Controls.Add(btnDevolucion);
            grpDevolucion.Controls.Add(label1);
            grpDevolucion.Location = new Point(404, 232);
            grpDevolucion.Name = "grpDevolucion";
            grpDevolucion.Size = new Size(200, 100);
            grpDevolucion.TabIndex = 37;
            grpDevolucion.TabStop = false;
            // 
            // txtventa
            // 
            txtventa.Location = new Point(20, 37);
            txtventa.Name = "txtventa";
            txtventa.Size = new Size(100, 23);
            txtventa.TabIndex = 3;
            // 
            // btnDevolucion
            // 
            btnDevolucion.Location = new Point(119, 71);
            btnDevolucion.Name = "btnDevolucion";
            btnDevolucion.Size = new Size(75, 23);
            btnDevolucion.TabIndex = 2;
            btnDevolucion.Text = "Devolucion";
            btnDevolucion.UseVisualStyleBackColor = true;
            btnDevolucion.Click += btnDevolucion_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 19);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 1;
            label1.Text = "Ventas";
            // 
            // MenuSupervisor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grpDevolucion);
            Controls.Add(grpBajaProd);
            Controls.Add(grpAltaProd);
            Controls.Add(grpOpciones);
            Name = "MenuSupervisor";
            Text = "Menu Supervisor";
            grpOpciones.ResumeLayout(false);
            grpOpciones.PerformLayout();
            grpAltaProd.ResumeLayout(false);
            grpAltaProd.PerformLayout();
            grpBajaProd.ResumeLayout(false);
            grpBajaProd.PerformLayout();
            grpDevolucion.ResumeLayout(false);
            grpDevolucion.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpOpciones;
        private Button btnSeleccion;
        private Button btnSalir;
        private RadioButton rdoReporteProductos;
        private RadioButton rdoReporteVentas;
        private RadioButton rdoReporteStock;
        private RadioButton rdoBajaProd;
        private RadioButton rdoDevolucion;
        private RadioButton rdoModificarProd;
        private RadioButton rdoAltaProductos;
        private GroupBox grpAltaProd;
        private ComboBox cmbprovprod;
        private Button btnAltaProducto;
        private ComboBox cmbcategoria;
        private Label lblProveedorDummy;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox txtStock;
        private TextBox txtPrecio;
        private TextBox txtNombreprod;
        private GroupBox grpBajaProd;
        private Label lblNombreProd;
        private Button btnBajaProd;
        private ComboBox cmbBajaProd;
        private GroupBox grpDevolucion;
        private Button btnDevolucion;
        private Label label1;
        private TextBox txtventa;
    }
}