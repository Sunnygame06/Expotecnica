namespace Login_Farmacia.Formularios.Server
{
    partial class FrmAdminConexion
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblServidor = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblBaseDatos = new System.Windows.Forms.Label();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.rdHabilitarWindows = new System.Windows.Forms.RadioButton();
            this.rdDeshabilitarWindows = new System.Windows.Forms.RadioButton();
            this.txtSqlAuth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSqlPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Login_Farmacia.Properties.Resources.Candado;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 294);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServidor.Location = new System.Drawing.Point(292, 9);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(111, 21);
            this.lblServidor.TabIndex = 1;
            this.lblServidor.Text = "Servidor URL:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(296, 34);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(391, 20);
            this.txtUser.TabIndex = 2;
            // 
            // lblBaseDatos
            // 
            this.lblBaseDatos.AutoSize = true;
            this.lblBaseDatos.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaseDatos.Location = new System.Drawing.Point(292, 70);
            this.lblBaseDatos.Name = "lblBaseDatos";
            this.lblBaseDatos.Size = new System.Drawing.Size(122, 21);
            this.lblBaseDatos.TabIndex = 3;
            this.lblBaseDatos.Text = "Base de Datos:";
            // 
            // txtDataBase
            // 
            this.txtDataBase.Location = new System.Drawing.Point(296, 94);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(391, 20);
            this.txtDataBase.TabIndex = 4;
            // 
            // rdHabilitarWindows
            // 
            this.rdHabilitarWindows.AutoSize = true;
            this.rdHabilitarWindows.Location = new System.Drawing.Point(296, 170);
            this.rdHabilitarWindows.Name = "rdHabilitarWindows";
            this.rdHabilitarWindows.Size = new System.Drawing.Size(221, 17);
            this.rdHabilitarWindows.TabIndex = 5;
            this.rdHabilitarWindows.TabStop = true;
            this.rdHabilitarWindows.Text = "Habilitar seguridad integrada de Windows";
            this.rdHabilitarWindows.UseVisualStyleBackColor = true;
            // 
            // rdDeshabilitarWindows
            // 
            this.rdDeshabilitarWindows.AutoSize = true;
            this.rdDeshabilitarWindows.Checked = true;
            this.rdDeshabilitarWindows.Location = new System.Drawing.Point(296, 193);
            this.rdDeshabilitarWindows.Name = "rdDeshabilitarWindows";
            this.rdDeshabilitarWindows.Size = new System.Drawing.Size(232, 17);
            this.rdDeshabilitarWindows.TabIndex = 6;
            this.rdDeshabilitarWindows.TabStop = true;
            this.rdDeshabilitarWindows.Text = "Desabilitar seguridad integrada de Windows";
            this.rdDeshabilitarWindows.UseVisualStyleBackColor = true;
            // 
            // txtSqlAuth
            // 
            this.txtSqlAuth.Location = new System.Drawing.Point(554, 169);
            this.txtSqlAuth.Name = "txtSqlAuth";
            this.txtSqlAuth.Size = new System.Drawing.Size(143, 20);
            this.txtSqlAuth.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(550, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "SQL Authentication";
            // 
            // txtSqlPass
            // 
            this.txtSqlPass.Location = new System.Drawing.Point(554, 220);
            this.txtSqlPass.Name = "txtSqlPass";
            this.txtSqlPass.Size = new System.Drawing.Size(143, 20);
            this.txtSqlPass.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(550, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Password Authentication";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(292, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Seguridad integrada de Windows";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Location = new System.Drawing.Point(554, 260);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(143, 23);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar Configuración";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // FrmAdminConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 295);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSqlPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSqlAuth);
            this.Controls.Add(this.rdDeshabilitarWindows);
            this.Controls.Add(this.rdHabilitarWindows);
            this.Controls.Add(this.txtDataBase);
            this.Controls.Add(this.lblBaseDatos);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblServidor);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdminConexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAdminConexion";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lblServidor;
        public System.Windows.Forms.Label lblBaseDatos;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtUser;
        public System.Windows.Forms.TextBox txtDataBase;
        public System.Windows.Forms.TextBox txtSqlAuth;
        public System.Windows.Forms.TextBox txtSqlPass;
        public System.Windows.Forms.RadioButton rdHabilitarWindows;
        public System.Windows.Forms.RadioButton rdDeshabilitarWindows;
        public System.Windows.Forms.Button btnGuardar;
    }
}