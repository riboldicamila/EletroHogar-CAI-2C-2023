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
            grpOpciones.SuspendLayout();
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
            // MenuSupervisor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grpOpciones);
            Name = "MenuSupervisor";
            Text = "Menu Supervisor";
            grpOpciones.ResumeLayout(false);
            grpOpciones.PerformLayout();
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
    }
}