namespace Login_Farmacia.Formularios
{
    partial class Frmusers
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
            this.btningresarusers = new System.Windows.Forms.Button();
            this.btncontinuar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btningresarusers
            // 
            this.btningresarusers.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btningresarusers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btningresarusers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btningresarusers.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btningresarusers.Location = new System.Drawing.Point(581, 257);
            this.btningresarusers.Name = "btningresarusers";
            this.btningresarusers.Size = new System.Drawing.Size(256, 239);
            this.btningresarusers.TabIndex = 1;
            this.btningresarusers.Text = "Ingresar usuarios";
            this.btningresarusers.UseVisualStyleBackColor = false;
            this.btningresarusers.Click += new System.EventHandler(this.btningresarusers_Click);
            // 
            // btncontinuar
            // 
            this.btncontinuar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btncontinuar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncontinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncontinuar.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncontinuar.Location = new System.Drawing.Point(885, 257);
            this.btncontinuar.Name = "btncontinuar";
            this.btncontinuar.Size = new System.Drawing.Size(256, 239);
            this.btncontinuar.TabIndex = 2;
            this.btncontinuar.Text = "Continuar...";
            this.btncontinuar.UseVisualStyleBackColor = false;
            this.btncontinuar.Click += new System.EventHandler(this.btncontinuar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(284, 257);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(256, 239);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "Cerrar Seccion";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Login_Farmacia.Properties.Resources.login;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1370, 749);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Frmusers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btncontinuar);
            this.Controls.Add(this.btningresarusers);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Frmusers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Farmacia Higia";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button btningresarusers;
        public System.Windows.Forms.Button btncontinuar;
        public System.Windows.Forms.Button btnCerrar;
    }
}