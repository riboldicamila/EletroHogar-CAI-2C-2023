namespace Formulario
{
    partial class MenuAdministrador
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
            components = new System.ComponentModel.Container();
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Text = "Form2";
            rdoAltaSup = new RadioButton();
            grpSupervisores = new GroupBox();
            rdoReactivarSup = new RadioButton();
            rdoBajaSup = new RadioButton();
            grpVendedores = new GroupBox();
            rdoBajaVend = new RadioButton();
            rdoReactivarVend = new RadioButton();
            rdoAltaVend = new RadioButton();
            grpProveedores = new GroupBox();
            rdoBajaProv = new RadioButton();
            rdoReactivarProv = new RadioButton();
            rdoAltaProv = new RadioButton();
            grpProductos = new GroupBox();
            radioButton10 = new RadioButton();
            rdoModificarProd = new RadioButton();
            rdoAltaProd = new RadioButton();
            grpReportes = new GroupBox();
            radioButton13 = new RadioButton();
            radioButton14 = new RadioButton();
            radioButton15 = new RadioButton();
            grpSupervisores.SuspendLayout();
            grpVendedores.SuspendLayout();
            grpProveedores.SuspendLayout();
            grpProductos.SuspendLayout();
            grpReportes.SuspendLayout();
            SuspendLayout();
            // 
            // rdoAltaSup
            // 
            rdoAltaSup.AutoSize = true;
            rdoAltaSup.Location = new Point(6, 22);
            rdoAltaSup.Name = "rdoAltaSup";
            rdoAltaSup.Size = new Size(46, 19);
            rdoAltaSup.TabIndex = 0;
            rdoAltaSup.TabStop = true;
            rdoAltaSup.Text = "Alta";
            rdoAltaSup.UseVisualStyleBackColor = true;
            // 
            // grpSupervisores
            // 
            grpSupervisores.Controls.Add(rdoBajaSup);
            grpSupervisores.Controls.Add(rdoReactivarSup);
            grpSupervisores.Controls.Add(rdoAltaSup);
            grpSupervisores.Location = new Point(31, 27);
            grpSupervisores.Name = "grpSupervisores";
            grpSupervisores.Size = new Size(200, 101);
            grpSupervisores.TabIndex = 1;
            grpSupervisores.TabStop = false;
            grpSupervisores.Text = "Supervisores";
            // 
            // rdoReactivarSup
            // 
            rdoReactivarSup.AutoSize = true;
            rdoReactivarSup.Location = new Point(6, 47);
            rdoReactivarSup.Name = "rdoReactivarSup";
            rdoReactivarSup.Size = new Size(73, 19);
            rdoReactivarSup.TabIndex = 1;
            rdoReactivarSup.TabStop = true;
            rdoReactivarSup.Text = "Reactivar";
            rdoReactivarSup.UseVisualStyleBackColor = true;
            // 
            // rdoBajaSup
            // 
            rdoBajaSup.AutoSize = true;
            rdoBajaSup.Location = new Point(6, 72);
            rdoBajaSup.Name = "rdoBajaSup";
            rdoBajaSup.Size = new Size(47, 19);
            rdoBajaSup.TabIndex = 2;
            rdoBajaSup.TabStop = true;
            rdoBajaSup.Text = "Baja";
            rdoBajaSup.UseVisualStyleBackColor = true;
            // 
            // grpVendedores
            // 
            grpVendedores.Controls.Add(rdoBajaVend);
            grpVendedores.Controls.Add(rdoReactivarVend);
            grpVendedores.Controls.Add(rdoAltaVend);
            grpVendedores.Location = new Point(31, 134);
            grpVendedores.Name = "grpVendedores";
            grpVendedores.Size = new Size(200, 98);
            grpVendedores.TabIndex = 3;
            grpVendedores.TabStop = false;
            grpVendedores.Text = "Vendedores";
            // 
            // rdoBajaVend
            // 
            rdoBajaVend.AutoSize = true;
            rdoBajaVend.Location = new Point(6, 72);
            rdoBajaVend.Name = "rdoBajaVend";
            rdoBajaVend.Size = new Size(47, 19);
            rdoBajaVend.TabIndex = 2;
            rdoBajaVend.TabStop = true;
            rdoBajaVend.Text = "Baja";
            rdoBajaVend.UseVisualStyleBackColor = true;
            // 
            // rdoReactivarVend
            // 
            rdoReactivarVend.AutoSize = true;
            rdoReactivarVend.Location = new Point(6, 47);
            rdoReactivarVend.Name = "rdoReactivarVend";
            rdoReactivarVend.Size = new Size(73, 19);
            rdoReactivarVend.TabIndex = 1;
            rdoReactivarVend.TabStop = true;
            rdoReactivarVend.Text = "Reactivar";
            rdoReactivarVend.UseVisualStyleBackColor = true;
            // 
            // rdoAltaVend
            // 
            rdoAltaVend.AutoSize = true;
            rdoAltaVend.Location = new Point(6, 22);
            rdoAltaVend.Name = "rdoAltaVend";
            rdoAltaVend.Size = new Size(46, 19);
            rdoAltaVend.TabIndex = 0;
            rdoAltaVend.TabStop = true;
            rdoAltaVend.Text = "Alta";
            rdoAltaVend.UseVisualStyleBackColor = true;
            // 
            // grpProveedores
            // 
            grpProveedores.Controls.Add(rdoBajaProv);
            grpProveedores.Controls.Add(rdoReactivarProv);
            grpProveedores.Controls.Add(rdoAltaProv);
            grpProveedores.Location = new Point(31, 238);
            grpProveedores.Name = "grpProveedores";
            grpProveedores.Size = new Size(200, 98);
            grpProveedores.TabIndex = 4;
            grpProveedores.TabStop = false;
            grpProveedores.Text = "Prooveedores";
            // 
            // rdoBajaProv
            // 
            rdoBajaProv.AutoSize = true;
            rdoBajaProv.Location = new Point(6, 72);
            rdoBajaProv.Name = "rdoBajaProv";
            rdoBajaProv.Size = new Size(47, 19);
            rdoBajaProv.TabIndex = 2;
            rdoBajaProv.TabStop = true;
            rdoBajaProv.Text = "Baja";
            rdoBajaProv.UseVisualStyleBackColor = true;
            // 
            // rdoReactivarProv
            // 
            rdoReactivarProv.AutoSize = true;
            rdoReactivarProv.Location = new Point(6, 47);
            rdoReactivarProv.Name = "rdoReactivarProv";
            rdoReactivarProv.Size = new Size(73, 19);
            rdoReactivarProv.TabIndex = 1;
            rdoReactivarProv.TabStop = true;
            rdoReactivarProv.Text = "Reactivar";
            rdoReactivarProv.UseVisualStyleBackColor = true;
            // 
            // rdoAltaProv
            // 
            rdoAltaProv.AutoSize = true;
            rdoAltaProv.Location = new Point(6, 22);
            rdoAltaProv.Name = "rdoAltaProv";
            rdoAltaProv.Size = new Size(46, 19);
            rdoAltaProv.TabIndex = 0;
            rdoAltaProv.TabStop = true;
            rdoAltaProv.Text = "Alta";
            rdoAltaProv.UseVisualStyleBackColor = true;
            // 
            // grpProductos
            // 
            grpProductos.Controls.Add(radioButton10);
            grpProductos.Controls.Add(rdoModificarProd);
            grpProductos.Controls.Add(rdoAltaProd);
            grpProductos.Location = new Point(31, 342);
            grpProductos.Name = "grpProductos";
            grpProductos.Size = new Size(200, 101);
            grpProductos.TabIndex = 3;
            grpProductos.TabStop = false;
            grpProductos.Text = "Productos";
            // 
            // radioButton10
            // 
            radioButton10.AutoSize = true;
            radioButton10.Location = new Point(6, 72);
            radioButton10.Name = "radioButton10";
            radioButton10.Size = new Size(47, 19);
            radioButton10.TabIndex = 2;
            radioButton10.TabStop = true;
            radioButton10.Text = "Baja";
            radioButton10.UseVisualStyleBackColor = true;
            // 
            // rdoModificarProd
            // 
            rdoModificarProd.AutoSize = true;
            rdoModificarProd.Location = new Point(6, 47);
            rdoModificarProd.Name = "rdoModificarProd";
            rdoModificarProd.Size = new Size(76, 19);
            rdoModificarProd.TabIndex = 1;
            rdoModificarProd.TabStop = true;
            rdoModificarProd.Text = "Modificar";
            rdoModificarProd.UseVisualStyleBackColor = true;
            // 
            // rdoAltaProd
            // 
            rdoAltaProd.AutoSize = true;
            rdoAltaProd.Location = new Point(6, 22);
            rdoAltaProd.Name = "rdoAltaProd";
            rdoAltaProd.Size = new Size(46, 19);
            rdoAltaProd.TabIndex = 0;
            rdoAltaProd.TabStop = true;
            rdoAltaProd.Text = "Alta";
            rdoAltaProd.UseVisualStyleBackColor = true;
            // 
            // grpReportes
            // 
            grpReportes.Controls.Add(radioButton13);
            grpReportes.Controls.Add(radioButton14);
            grpReportes.Controls.Add(radioButton15);
            grpReportes.Location = new Point(31, 449);
            grpReportes.Name = "grpReportes";
            grpReportes.Size = new Size(200, 101);
            grpReportes.TabIndex = 4;
            grpReportes.TabStop = false;
            grpReportes.Text = "Reportes";
            // 
            // radioButton13
            // 
            radioButton13.AutoSize = true;
            radioButton13.Location = new Point(6, 72);
            radioButton13.Name = "radioButton13";
            radioButton13.Size = new Size(100, 19);
            radioButton13.TabIndex = 2;
            radioButton13.TabStop = true;
            radioButton13.Text = "radioButton13";
            radioButton13.UseVisualStyleBackColor = true;
            // 
            // radioButton14
            // 
            radioButton14.AutoSize = true;
            radioButton14.Location = new Point(6, 47);
            radioButton14.Name = "radioButton14";
            radioButton14.Size = new Size(100, 19);
            radioButton14.TabIndex = 1;
            radioButton14.TabStop = true;
            radioButton14.Text = "radioButton14";
            radioButton14.UseVisualStyleBackColor = true;
            // 
            // radioButton15
            // 
            radioButton15.AutoSize = true;
            radioButton15.Location = new Point(6, 22);
            radioButton15.Name = "radioButton15";
            radioButton15.Size = new Size(100, 19);
            radioButton15.TabIndex = 0;
            radioButton15.TabStop = true;
            radioButton15.Text = "radioButton15";
            radioButton15.UseVisualStyleBackColor = true;
            // 
            // MenuAdministrador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 581);
            Controls.Add(grpReportes);
            Controls.Add(grpProductos);
            Controls.Add(grpProveedores);
            Controls.Add(grpVendedores);
            Controls.Add(grpSupervisores);
            Name = "MenuAdministrador";
            Text = "MenuAdministrador";
            grpSupervisores.ResumeLayout(false);
            grpSupervisores.PerformLayout();
            grpVendedores.ResumeLayout(false);
            grpVendedores.PerformLayout();
            grpProveedores.ResumeLayout(false);
            grpProveedores.PerformLayout();
            grpProductos.ResumeLayout(false);
            grpProductos.PerformLayout();
            grpReportes.ResumeLayout(false);
            grpReportes.PerformLayout();
            ResumeLayout(false);
        }

        #endregion




        private RadioButton rdoAltaSup;
        private GroupBox grpSupervisores;
        private RadioButton rdoReactivarSup;
        private RadioButton rdoBajaSup;
        private GroupBox grpVendedores;
        private RadioButton rdoBajaVend;
        private RadioButton rdoReactivarVend;
        private RadioButton rdoAltaVend;
        private GroupBox grpProveedores;
        private RadioButton rdoBajaProv;
        private RadioButton rdoReactivarProv;
        private RadioButton rdoAltaProv;
        private GroupBox grpProductos;
        private RadioButton radioButton10;
        private RadioButton rdoModificarProd;
        private RadioButton rdoAltaProd;
        private GroupBox grpReportes;
        private RadioButton radioButton13;
        private RadioButton radioButton14;
        private RadioButton radioButton15;
    }
}
