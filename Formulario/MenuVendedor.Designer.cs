namespace Formulario
{
    partial class MenuVendedor
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
            grpSeleccion = new GroupBox();
            rdoAgregarVenta = new RadioButton();
            rdoReporteVenta = new RadioButton();
            rdoAgregarCliente = new RadioButton();
            btnSalir = new Button();
            btnSeleccion = new Button();
            grpSeleccion.SuspendLayout();
            SuspendLayout();
            // 
            // grpSeleccion
            // 
            grpSeleccion.Controls.Add(btnSeleccion);
            grpSeleccion.Controls.Add(btnSalir);
            grpSeleccion.Controls.Add(rdoAgregarCliente);
            grpSeleccion.Controls.Add(rdoReporteVenta);
            grpSeleccion.Controls.Add(rdoAgregarVenta);
            grpSeleccion.Location = new Point(38, 9);
            grpSeleccion.Name = "grpSeleccion";
            grpSeleccion.Size = new Size(200, 140);
            grpSeleccion.TabIndex = 0;
            grpSeleccion.TabStop = false;
            grpSeleccion.Text = "Seleccione una Opcion";
            // 
            // rdoAgregarVenta
            // 
            rdoAgregarVenta.AutoSize = true;
            rdoAgregarVenta.Location = new Point(14, 23);
            rdoAgregarVenta.Name = "rdoAgregarVenta";
            rdoAgregarVenta.Size = new Size(99, 19);
            rdoAgregarVenta.TabIndex = 0;
            rdoAgregarVenta.TabStop = true;
            rdoAgregarVenta.Text = "Agregar Venta";
            rdoAgregarVenta.UseVisualStyleBackColor = true;
            // 
            // rdoReporteVenta
            // 
            rdoReporteVenta.AutoSize = true;
            rdoReporteVenta.Location = new Point(14, 48);
            rdoReporteVenta.Name = "rdoReporteVenta";
            rdoReporteVenta.Size = new Size(193, 19);
            rdoReporteVenta.TabIndex = 1;
            rdoReporteVenta.TabStop = true;
            rdoReporteVenta.Text = "Reporte de Ventas por Vendedor";
            rdoReporteVenta.UseVisualStyleBackColor = true;
            // 
            // rdoAgregarCliente
            // 
            rdoAgregarCliente.AutoSize = true;
            rdoAgregarCliente.Location = new Point(14, 73);
            rdoAgregarCliente.Name = "rdoAgregarCliente";
            rdoAgregarCliente.Size = new Size(107, 19);
            rdoAgregarCliente.TabIndex = 2;
            rdoAgregarCliente.TabStop = true;
            rdoAgregarCliente.Text = "Agregar Cliente";
            rdoAgregarCliente.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(19, 99);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnSeleccion
            // 
            btnSeleccion.Location = new Point(100, 98);
            btnSeleccion.Name = "btnSeleccion";
            btnSeleccion.Size = new Size(75, 23);
            btnSeleccion.TabIndex = 4;
            btnSeleccion.Text = "Seleccionar";
            btnSeleccion.UseVisualStyleBackColor = true;
            // 
            // MenuVendedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grpSeleccion);
            Name = "MenuVendedor";
            Text = "Menu Vendedor";
            grpSeleccion.ResumeLayout(false);
            grpSeleccion.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpSeleccion;
        private Button btnSeleccion;
        private Button btnSalir;
        private RadioButton rdoAgregarCliente;
        private RadioButton rdoReporteVenta;
        private RadioButton rdoAgregarVenta;
    }
}