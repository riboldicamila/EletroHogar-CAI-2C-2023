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
            btnSeleccion = new Button();
            btnSalir = new Button();
            rdoAgregarCliente = new RadioButton();
            rdoReporteVenta = new RadioButton();
            rdoAgregarVenta = new RadioButton();
            grpVenta = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnAgregar = new Button();
            txtcantidad = new TextBox();
            cmbproducto = new ComboBox();
            cmbclientes = new ComboBox();
            grpRegistrar = new GroupBox();
            btnRegistrar = new Button();
            lblDireccion = new Label();
            lblFechaNac = new Label();
            lblDNI = new Label();
            lblEmail = new Label();
            lblTelefono = new Label();
            txtFechaNac = new TextBox();
            txtDni = new TextBox();
            txtEmail = new TextBox();
            txtTelefono = new TextBox();
            txtDireccion = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            lblApellido = new Label();
            lblNombre = new Label();
            grpSeleccion.SuspendLayout();
            grpVenta.SuspendLayout();
            grpRegistrar.SuspendLayout();
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
            grpSeleccion.Size = new Size(227, 140);
            grpSeleccion.TabIndex = 0;
            grpSeleccion.TabStop = false;
            grpSeleccion.Text = "Seleccione una Opcion";
            // 
            // btnSeleccion
            // 
            btnSeleccion.Location = new Point(100, 98);
            btnSeleccion.Name = "btnSeleccion";
            btnSeleccion.Size = new Size(75, 23);
            btnSeleccion.TabIndex = 4;
            btnSeleccion.Text = "Seleccionar";
            btnSeleccion.UseVisualStyleBackColor = true;
            btnSeleccion.Click += btnSeleccion_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(19, 99);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
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
            // grpVenta
            // 
            grpVenta.Controls.Add(label3);
            grpVenta.Controls.Add(label2);
            grpVenta.Controls.Add(label1);
            grpVenta.Controls.Add(btnAgregar);
            grpVenta.Controls.Add(txtcantidad);
            grpVenta.Controls.Add(cmbproducto);
            grpVenta.Controls.Add(cmbclientes);
            grpVenta.Location = new Point(313, 9);
            grpVenta.Name = "grpVenta";
            grpVenta.Size = new Size(277, 194);
            grpVenta.TabIndex = 1;
            grpVenta.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(183, 66);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 7;
            label3.Text = "Cantidad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 63);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 6;
            label2.Text = "Producto";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 12);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 5;
            label1.Text = "Cliente";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(16, 138);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtcantidad
            // 
            txtcantidad.Location = new Point(183, 84);
            txtcantidad.Name = "txtcantidad";
            txtcantidad.Size = new Size(45, 23);
            txtcantidad.TabIndex = 2;
            // 
            // cmbproducto
            // 
            cmbproducto.FormattingEnabled = true;
            cmbproducto.Location = new Point(16, 85);
            cmbproducto.Name = "cmbproducto";
            cmbproducto.Size = new Size(121, 23);
            cmbproducto.TabIndex = 1;
            // 
            // cmbclientes
            // 
            cmbclientes.FormattingEnabled = true;
            cmbclientes.Location = new Point(16, 37);
            cmbclientes.Name = "cmbclientes";
            cmbclientes.Size = new Size(121, 23);
            cmbclientes.TabIndex = 0;
            // 
            // grpRegistrar
            // 
            grpRegistrar.Controls.Add(btnRegistrar);
            grpRegistrar.Controls.Add(lblDireccion);
            grpRegistrar.Controls.Add(lblFechaNac);
            grpRegistrar.Controls.Add(lblDNI);
            grpRegistrar.Controls.Add(lblEmail);
            grpRegistrar.Controls.Add(lblTelefono);
            grpRegistrar.Controls.Add(txtFechaNac);
            grpRegistrar.Controls.Add(txtDni);
            grpRegistrar.Controls.Add(txtEmail);
            grpRegistrar.Controls.Add(txtTelefono);
            grpRegistrar.Controls.Add(txtDireccion);
            grpRegistrar.Controls.Add(txtApellido);
            grpRegistrar.Controls.Add(txtNombre);
            grpRegistrar.Controls.Add(lblApellido);
            grpRegistrar.Controls.Add(lblNombre);
            grpRegistrar.Location = new Point(313, 220);
            grpRegistrar.Name = "grpRegistrar";
            grpRegistrar.Size = new Size(400, 182);
            grpRegistrar.TabIndex = 31;
            grpRegistrar.TabStop = false;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(299, 143);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(75, 23);
            btnRegistrar.TabIndex = 29;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(14, 70);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(57, 15);
            lblDireccion.TabIndex = 28;
            lblDireccion.Text = "Direccion";
            // 
            // lblFechaNac
            // 
            lblFechaNac.AutoSize = true;
            lblFechaNac.Location = new Point(148, 125);
            lblFechaNac.Name = "lblFechaNac";
            lblFechaNac.Size = new Size(119, 15);
            lblFechaNac.TabIndex = 27;
            lblFechaNac.Text = "Fecha de Nacimiento";
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.Location = new Point(14, 125);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(27, 15);
            lblDNI.TabIndex = 26;
            lblDNI.Text = "DNI";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(274, 70);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 25;
            lblEmail.Text = "Email";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(148, 70);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(52, 15);
            lblTelefono.TabIndex = 24;
            lblTelefono.Text = "Telefono";
            // 
            // txtFechaNac
            // 
            txtFechaNac.Location = new Point(148, 143);
            txtFechaNac.Name = "txtFechaNac";
            txtFechaNac.Size = new Size(100, 23);
            txtFechaNac.TabIndex = 23;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(14, 143);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 22;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(274, 89);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 21;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(148, 89);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 20;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(14, 89);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(100, 23);
            txtDireccion.TabIndex = 19;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(148, 22);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 16;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(14, 22);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 15;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(148, 4);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 14;
            lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(14, 4);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 13;
            lblNombre.Text = "Nombre";
            // 
            // MenuVendedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grpRegistrar);
            Controls.Add(grpVenta);
            Controls.Add(grpSeleccion);
            Name = "MenuVendedor";
            Text = "Menu Vendedor";
            grpSeleccion.ResumeLayout(false);
            grpSeleccion.PerformLayout();
            grpVenta.ResumeLayout(false);
            grpVenta.PerformLayout();
            grpRegistrar.ResumeLayout(false);
            grpRegistrar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpSeleccion;
        private Button btnSeleccion;
        private Button btnSalir;
        private RadioButton rdoAgregarCliente;
        private RadioButton rdoReporteVenta;
        private RadioButton rdoAgregarVenta;
        private GroupBox grpVenta;
        private ComboBox cmbproducto;
        private ComboBox cmbclientes;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnAgregar;
        private TextBox txtcantidad;
        private GroupBox grpRegistrar;
        private Button btnRegistrar;
        private Label lblDireccion;
        private Label lblFechaNac;
        private Label lblDNI;
        private Label lblEmail;
        private Label lblTelefono;
        private TextBox txtFechaNac;
        private TextBox txtDni;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private Label lblApellido;
        private Label lblNombre;
    }
}