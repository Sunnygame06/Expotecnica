namespace Login_Farmacia
{
    partial class Frmlogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.PBoxWifi = new System.Windows.Forms.PictureBox();
            this.btnregistrarse = new System.Windows.Forms.Button();
            this.lblrecuperar = new System.Windows.Forms.LinkLabel();
            this.checkpass = new System.Windows.Forms.CheckBox();
            this.btnlogo = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnlogin = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBoxWifi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblPass);
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.PBoxWifi);
            this.panel1.Controls.Add(this.btnregistrarse);
            this.panel1.Controls.Add(this.lblrecuperar);
            this.panel1.Controls.Add(this.checkpass);
            this.panel1.Controls.Add(this.btnlogo);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnlogin);
            this.panel1.Controls.Add(this.txtPass);
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(196, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 248);
            this.panel1.TabIndex = 1;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(40, 163);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(61, 13);
            this.lblPass.TabIndex = 16;
            this.lblPass.Text = "Contraseña";
            this.lblPass.Visible = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(40, 127);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(43, 13);
            this.lblUser.TabIndex = 15;
            this.lblUser.Text = "Usuario";
            // 
            // PBoxWifi
            // 
            this.PBoxWifi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBoxWifi.Image = global::Login_Farmacia.Properties.Resources.wifi;
            this.PBoxWifi.Location = new System.Drawing.Point(383, 3);
            this.PBoxWifi.Name = "PBoxWifi";
            this.PBoxWifi.Size = new System.Drawing.Size(48, 40);
            this.PBoxWifi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBoxWifi.TabIndex = 14;
            this.PBoxWifi.TabStop = false;
            // 
            // btnregistrarse
            // 
            this.btnregistrarse.BackColor = System.Drawing.Color.AliceBlue;
            this.btnregistrarse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnregistrarse.Location = new System.Drawing.Point(43, 218);
            this.btnregistrarse.Name = "btnregistrarse";
            this.btnregistrarse.Size = new System.Drawing.Size(71, 23);
            this.btnregistrarse.TabIndex = 5;
            this.btnregistrarse.Text = "Registrase";
            this.btnregistrarse.UseVisualStyleBackColor = false;
            // 
            // lblrecuperar
            // 
            this.lblrecuperar.AutoSize = true;
            this.lblrecuperar.Location = new System.Drawing.Point(308, 199);
            this.lblrecuperar.Name = "lblrecuperar";
            this.lblrecuperar.Size = new System.Drawing.Size(113, 13);
            this.lblrecuperar.TabIndex = 3;
            this.lblrecuperar.TabStop = true;
            this.lblrecuperar.Text = "Recuperar contraseña";
            // 
            // checkpass
            // 
            this.checkpass.AutoSize = true;
            this.checkpass.Checked = true;
            this.checkpass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkpass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkpass.Location = new System.Drawing.Point(397, 179);
            this.checkpass.Name = "checkpass";
            this.checkpass.Size = new System.Drawing.Size(15, 14);
            this.checkpass.TabIndex = 2;
            this.checkpass.UseVisualStyleBackColor = true;
            // 
            // btnlogo
            // 
            this.btnlogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogo.Image = global::Login_Farmacia.Properties.Resources.logo;
            this.btnlogo.Location = new System.Drawing.Point(43, 18);
            this.btnlogo.Name = "btnlogo";
            this.btnlogo.Size = new System.Drawing.Size(146, 106);
            this.btnlogo.TabIndex = 9;
            this.btnlogo.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Location = new System.Drawing.Point(230, 218);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(63, 23);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnlogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlogin.FlatAppearance.BorderSize = 0;
            this.btnlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogin.Location = new System.Drawing.Point(120, 218);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(104, 23);
            this.btnlogin.TabIndex = 4;
            this.btnlogin.Text = "Iniciar Sesion";
            this.btnlogin.UseVisualStyleBackColor = false;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(43, 176);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(348, 20);
            this.txtPass.TabIndex = 1;
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.SystemColors.Window;
            this.txtUser.Location = new System.Drawing.Point(43, 140);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(369, 20);
            this.txtUser.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(226, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "a Farmacia Higía";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(195, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "¡Bienvenidos!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Login_Farmacia.Properties.Resources.login;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Frmlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Frmlogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Farmacia Higia";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBoxWifi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnCerrar;
        public System.Windows.Forms.TextBox txtUser;
        public System.Windows.Forms.TextBox txtPass;
        public System.Windows.Forms.Button btnlogin;
        public System.Windows.Forms.Button btnlogo;
        public System.Windows.Forms.CheckBox checkpass;
        public System.Windows.Forms.LinkLabel lblrecuperar;
        public System.Windows.Forms.Button btnregistrarse;
        public System.Windows.Forms.PictureBox PBoxWifi;
        public System.Windows.Forms.Label lblUser;
        public System.Windows.Forms.Label lblPass;
    }
}

