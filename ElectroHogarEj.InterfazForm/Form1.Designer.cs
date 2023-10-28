namespace ElectroHogarEj.InterfazForm
{
    partial class Form1
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
            this.btnInicioSesion = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this._lbContraseña = new System.Windows.Forms.Label();
            this._lbNombreDeUsuario = new System.Windows.Forms.Label();
            this.lbElectroHogar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInicioSesion
            // 
            this.btnInicioSesion.Location = new System.Drawing.Point(37, 191);
            this.btnInicioSesion.Name = "btnInicioSesion";
            this.btnInicioSesion.Size = new System.Drawing.Size(89, 35);
            this.btnInicioSesion.TabIndex = 0;
            this.btnInicioSesion.Text = "Entrar";
            this.btnInicioSesion.UseVisualStyleBackColor = true;
            this.btnInicioSesion.Click += new System.EventHandler(this.btnInicioSesion_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(37, 87);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(37, 145);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(156, 20);
            this.textBox2.TabIndex = 2;
            // 
            // _lbContraseña
            // 
            this._lbContraseña.AutoSize = true;
            this._lbContraseña.Location = new System.Drawing.Point(34, 129);
            this._lbContraseña.Name = "_lbContraseña";
            this._lbContraseña.Size = new System.Drawing.Size(112, 13);
            this._lbContraseña.TabIndex = 3;
            this._lbContraseña.Text = "Ingrese la contraseña:";
            // 
            // _lbNombreDeUsuario
            // 
            this._lbNombreDeUsuario.AutoSize = true;
            this._lbNombreDeUsuario.Location = new System.Drawing.Point(34, 71);
            this._lbNombreDeUsuario.Name = "_lbNombreDeUsuario";
            this._lbNombreDeUsuario.Size = new System.Drawing.Size(135, 13);
            this._lbNombreDeUsuario.TabIndex = 4;
            this._lbNombreDeUsuario.Text = "Ingrese nombre de usuario:";
            // 
            // lbElectroHogar
            // 
            this.lbElectroHogar.AutoSize = true;
            this.lbElectroHogar.Location = new System.Drawing.Point(40, 29);
            this.lbElectroHogar.Name = "lbElectroHogar";
            this.lbElectroHogar.Size = new System.Drawing.Size(96, 13);
            this.lbElectroHogar.TabIndex = 5;
            this.lbElectroHogar.Text = "ELECTROHOGAR";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 324);
            this.Controls.Add(this.lbElectroHogar);
            this.Controls.Add(this._lbNombreDeUsuario);
            this.Controls.Add(this._lbContraseña);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnInicioSesion);
            this.Name = "Form1";
            this.Text = "Inicio de Sesion";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInicioSesion;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label _lbContraseña;
        private System.Windows.Forms.Label _lbNombreDeUsuario;
        private System.Windows.Forms.Label lbElectroHogar;
    }
}

