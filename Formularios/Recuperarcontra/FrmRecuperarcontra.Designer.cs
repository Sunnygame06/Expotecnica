namespace Login_Farmacia.Formularios
{
    partial class FrmRecuperarcontra
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
            this.btnApp = new System.Windows.Forms.Button();
            this.btnCorreo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPregunta = new System.Windows.Forms.Button();
            this.btnReinicio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnApp
            // 
            this.btnApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApp.Location = new System.Drawing.Point(40, 101);
            this.btnApp.Name = "btnApp";
            this.btnApp.Size = new System.Drawing.Size(108, 56);
            this.btnApp.TabIndex = 0;
            this.btnApp.Text = "Intervencion de administrador";
            this.btnApp.UseVisualStyleBackColor = true;
            // 
            // btnCorreo
            // 
            this.btnCorreo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCorreo.Location = new System.Drawing.Point(167, 101);
            this.btnCorreo.Name = "btnCorreo";
            this.btnCorreo.Size = new System.Drawing.Size(109, 56);
            this.btnCorreo.TabIndex = 1;
            this.btnCorreo.Text = "Escribiendonos al correo electronico";
            this.btnCorreo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 52);
            this.label1.TabIndex = 2;
            this.label1.Text = "Por donde desearia recuperar\r\n su contraseña?";
            // 
            // btnPregunta
            // 
            this.btnPregunta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPregunta.Location = new System.Drawing.Point(40, 172);
            this.btnPregunta.Name = "btnPregunta";
            this.btnPregunta.Size = new System.Drawing.Size(109, 56);
            this.btnPregunta.TabIndex = 3;
            this.btnPregunta.Text = "Preguntas de seguridad";
            this.btnPregunta.UseVisualStyleBackColor = true;
            // 
            // btnReinicio
            // 
            this.btnReinicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReinicio.Location = new System.Drawing.Point(167, 172);
            this.btnReinicio.Name = "btnReinicio";
            this.btnReinicio.Size = new System.Drawing.Size(109, 56);
            this.btnReinicio.TabIndex = 4;
            this.btnReinicio.Text = "Reinicio";
            this.btnReinicio.UseVisualStyleBackColor = true;
            // 
            // FrmRecuperarcontra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 251);
            this.Controls.Add(this.btnReinicio);
            this.Controls.Add(this.btnPregunta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCorreo);
            this.Controls.Add(this.btnApp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRecuperarcontra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Farmacia Hígia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnApp;
        public System.Windows.Forms.Button btnCorreo;
        public System.Windows.Forms.Button btnPregunta;
        public System.Windows.Forms.Button btnReinicio;
    }
}