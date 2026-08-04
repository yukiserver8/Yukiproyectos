namespace KrisbelLauncherConfigs
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_encriptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ipServidor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_puertoServidor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_encriptar
            // 
            this.btn_encriptar.Location = new System.Drawing.Point(16, 128);
            this.btn_encriptar.Name = "btn_encriptar";
            this.btn_encriptar.Size = new System.Drawing.Size(215, 28);
            this.btn_encriptar.TabIndex = 0;
            this.btn_encriptar.Text = "General Configs";
            this.btn_encriptar.UseVisualStyleBackColor = true;
            this.btn_encriptar.Click += new System.EventHandler(this.btn_encriptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Salmon;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = ".::Datos del Servidor::.";
            // 
            // txt_ipServidor
            // 
            this.txt_ipServidor.Location = new System.Drawing.Point(16, 61);
            this.txt_ipServidor.Name = "txt_ipServidor";
            this.txt_ipServidor.Size = new System.Drawing.Size(215, 20);
            this.txt_ipServidor.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "IpServidor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Puerto del Servidor (Ejemplo: 44405)";
            // 
            // txt_puertoServidor
            // 
            this.txt_puertoServidor.Location = new System.Drawing.Point(16, 102);
            this.txt_puertoServidor.Name = "txt_puertoServidor";
            this.txt_puertoServidor.Size = new System.Drawing.Size(215, 20);
            this.txt_puertoServidor.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(250, 175);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_puertoServidor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ipServidor);
            this.Controls.Add(this.btn_encriptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(259, 213);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KrisbelLauncher[PREMIUM] Encriptacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_encriptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ipServidor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_puertoServidor;
    }
}

