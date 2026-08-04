namespace Launcher
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ptb_bgSlider = new System.Windows.Forms.PictureBox();
            this.ptb_cerrar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_completeProgress = new System.Windows.Forms.Panel();
            this.lbl_BtnEntrar = new System.Windows.Forms.Label();
            this.completeProgressText = new System.Windows.Forms.Label();
            this.lbl_mensajes = new System.Windows.Forms.Label();
            this.lbl_infoArchivos = new System.Windows.Forms.Label();
            this.lbl_textNoticia = new System.Windows.Forms.Label();
            this.ptb_slider1 = new System.Windows.Forms.PictureBox();
            this.ptb_slider2 = new System.Windows.Forms.PictureBox();
            this.ptb_slider3 = new System.Windows.Forms.PictureBox();
            this.ptb_configs = new System.Windows.Forms.PictureBox();
            this.ptb_facebook = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.ptb_soundMusic = new System.Windows.Forms.PictureBox();
            this.ptb_minimizer = new System.Windows.Forms.PictureBox();
            this.lbl_minimizer = new System.Windows.Forms.Label();
            this.timer_slider = new System.Windows.Forms.Timer(this.components);
            this.panel_noticias = new System.Windows.Forms.Panel();
            this.timer_noticias = new System.Windows.Forms.Timer(this.components);
            this.timer_reinicioNoticias = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_bgSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_cerrar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_slider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_slider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_slider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_configs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_facebook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_soundMusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_minimizer)).BeginInit();
            this.panel_noticias.SuspendLayout();
            this.SuspendLayout();
            // 
            // ptb_bgSlider
            // 
            this.ptb_bgSlider.Location = new System.Drawing.Point(24, 84);
            this.ptb_bgSlider.Name = "ptb_bgSlider";
            this.ptb_bgSlider.Size = new System.Drawing.Size(363, 296);
            this.ptb_bgSlider.TabIndex = 0;
            this.ptb_bgSlider.TabStop = false;
            // 
            // ptb_cerrar
            // 
            this.ptb_cerrar.BackColor = System.Drawing.Color.Transparent;
            this.ptb_cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptb_cerrar.Location = new System.Drawing.Point(368, 18);
            this.ptb_cerrar.Name = "ptb_cerrar";
            this.ptb_cerrar.Size = new System.Drawing.Size(24, 24);
            this.ptb_cerrar.TabIndex = 1;
            this.ptb_cerrar.TabStop = false;
            this.ptb_cerrar.Click += new System.EventHandler(this.ptb_cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.label1.Location = new System.Drawing.Point(21, 424);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.panel1.Controls.Add(this.panel_completeProgress);
            this.panel1.Location = new System.Drawing.Point(72, 420);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 26);
            this.panel1.TabIndex = 3;
            // 
            // panel_completeProgress
            // 
            this.panel_completeProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(40)))));
            this.panel_completeProgress.Location = new System.Drawing.Point(1, 1);
            this.panel_completeProgress.Name = "panel_completeProgress";
            this.panel_completeProgress.Size = new System.Drawing.Size(188, 24);
            this.panel_completeProgress.TabIndex = 4;
            // 
            // lbl_BtnEntrar
            // 
            this.lbl_BtnEntrar.AutoSize = true;
            this.lbl_BtnEntrar.BackColor = System.Drawing.Color.Transparent;
            this.lbl_BtnEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_BtnEntrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BtnEntrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(190)))), ((int)(((byte)(85)))));
            this.lbl_BtnEntrar.Image = global::Launcher.Properties.Resources.btn_entrarActive;
            this.lbl_BtnEntrar.Location = new System.Drawing.Point(304, 415);
            this.lbl_BtnEntrar.MaximumSize = new System.Drawing.Size(83, 38);
            this.lbl_BtnEntrar.MinimumSize = new System.Drawing.Size(83, 38);
            this.lbl_BtnEntrar.Name = "lbl_BtnEntrar";
            this.lbl_BtnEntrar.Size = new System.Drawing.Size(83, 38);
            this.lbl_BtnEntrar.TabIndex = 4;
            this.lbl_BtnEntrar.Text = "Entrar";
            this.lbl_BtnEntrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_BtnEntrar.Click += new System.EventHandler(this.lbl_BtnEntrar_Click);
            // 
            // completeProgressText
            // 
            this.completeProgressText.AutoSize = true;
            this.completeProgressText.BackColor = System.Drawing.Color.Transparent;
            this.completeProgressText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeProgressText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(1)))));
            this.completeProgressText.Location = new System.Drawing.Point(267, 428);
            this.completeProgressText.Name = "completeProgressText";
            this.completeProgressText.Size = new System.Drawing.Size(33, 13);
            this.completeProgressText.TabIndex = 5;
            this.completeProgressText.Text = "100%";
            // 
            // lbl_mensajes
            // 
            this.lbl_mensajes.AutoSize = true;
            this.lbl_mensajes.BackColor = System.Drawing.Color.Transparent;
            this.lbl_mensajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mensajes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(100)))), ((int)(((byte)(8)))));
            this.lbl_mensajes.Location = new System.Drawing.Point(70, 455);
            this.lbl_mensajes.Name = "lbl_mensajes";
            this.lbl_mensajes.Size = new System.Drawing.Size(0, 13);
            this.lbl_mensajes.TabIndex = 8;
            // 
            // lbl_infoArchivos
            // 
            this.lbl_infoArchivos.AutoSize = true;
            this.lbl_infoArchivos.BackColor = System.Drawing.Color.Transparent;
            this.lbl_infoArchivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_infoArchivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(211)))), ((int)(((byte)(210)))));
            this.lbl_infoArchivos.Location = new System.Drawing.Point(70, 455);
            this.lbl_infoArchivos.MinimumSize = new System.Drawing.Size(314, 13);
            this.lbl_infoArchivos.Name = "lbl_infoArchivos";
            this.lbl_infoArchivos.Size = new System.Drawing.Size(314, 13);
            this.lbl_infoArchivos.TabIndex = 9;
            // 
            // lbl_textNoticia
            // 
            this.lbl_textNoticia.AutoSize = true;
            this.lbl_textNoticia.BackColor = System.Drawing.Color.Transparent;
            this.lbl_textNoticia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_textNoticia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(157)))), ((int)(((byte)(227)))));
            this.lbl_textNoticia.Image = global::Launcher.Properties.Resources.new1;
            this.lbl_textNoticia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_textNoticia.Location = new System.Drawing.Point(190, 6);
            this.lbl_textNoticia.MinimumSize = new System.Drawing.Size(0, 14);
            this.lbl_textNoticia.Name = "lbl_textNoticia";
            this.lbl_textNoticia.Size = new System.Drawing.Size(0, 14);
            this.lbl_textNoticia.TabIndex = 10;
            this.lbl_textNoticia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ptb_slider1
            // 
            this.ptb_slider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(204)))), ((int)(((byte)(116)))));
            this.ptb_slider1.Location = new System.Drawing.Point(48, 345);
            this.ptb_slider1.Name = "ptb_slider1";
            this.ptb_slider1.Size = new System.Drawing.Size(17, 17);
            this.ptb_slider1.TabIndex = 11;
            this.ptb_slider1.TabStop = false;
            this.ptb_slider1.Click += new System.EventHandler(this.ptb_slider1_Click);
            // 
            // ptb_slider2
            // 
            this.ptb_slider2.BackColor = System.Drawing.Color.White;
            this.ptb_slider2.Location = new System.Drawing.Point(68, 345);
            this.ptb_slider2.Name = "ptb_slider2";
            this.ptb_slider2.Size = new System.Drawing.Size(17, 17);
            this.ptb_slider2.TabIndex = 12;
            this.ptb_slider2.TabStop = false;
            this.ptb_slider2.Click += new System.EventHandler(this.ptb_slider2_Click);
            // 
            // ptb_slider3
            // 
            this.ptb_slider3.BackColor = System.Drawing.Color.White;
            this.ptb_slider3.Location = new System.Drawing.Point(88, 345);
            this.ptb_slider3.Name = "ptb_slider3";
            this.ptb_slider3.Size = new System.Drawing.Size(17, 17);
            this.ptb_slider3.TabIndex = 13;
            this.ptb_slider3.TabStop = false;
            this.ptb_slider3.Click += new System.EventHandler(this.ptb_slider3_Click);
            // 
            // ptb_configs
            // 
            this.ptb_configs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(90)))), ((int)(((byte)(9)))));
            this.ptb_configs.BackgroundImage = global::Launcher.Properties.Resources.bg_configs;
            this.ptb_configs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptb_configs.Location = new System.Drawing.Point(0, 84);
            this.ptb_configs.Name = "ptb_configs";
            this.ptb_configs.Size = new System.Drawing.Size(24, 24);
            this.ptb_configs.TabIndex = 14;
            this.ptb_configs.TabStop = false;
            this.ptb_configs.Click += new System.EventHandler(this.ptb_configs_Click);
            // 
            // ptb_facebook
            // 
            this.ptb_facebook.BackColor = System.Drawing.Color.Transparent;
            this.ptb_facebook.BackgroundImage = global::Launcher.Properties.Resources.bg_facebook;
            this.ptb_facebook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptb_facebook.Location = new System.Drawing.Point(0, 111);
            this.ptb_facebook.Name = "ptb_facebook";
            this.ptb_facebook.Size = new System.Drawing.Size(24, 24);
            this.ptb_facebook.TabIndex = 15;
            this.ptb_facebook.TabStop = false;
            this.ptb_facebook.Click += new System.EventHandler(this.ptb_facebook_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Location = new System.Drawing.Point(136, 9);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(136, 36);
            this.pictureBox7.TabIndex = 16;
            this.pictureBox7.TabStop = false;
            // 
            // ptb_soundMusic
            // 
            this.ptb_soundMusic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(128)))), ((int)(((byte)(115)))));
            this.ptb_soundMusic.BackgroundImage = global::Launcher.Properties.Resources.mute;
            this.ptb_soundMusic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ptb_soundMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptb_soundMusic.Location = new System.Drawing.Point(0, 138);
            this.ptb_soundMusic.Name = "ptb_soundMusic";
            this.ptb_soundMusic.Size = new System.Drawing.Size(24, 24);
            this.ptb_soundMusic.TabIndex = 17;
            this.ptb_soundMusic.TabStop = false;
            this.ptb_soundMusic.Click += new System.EventHandler(this.ptb_soundMusic_Click);
            // 
            // ptb_minimizer
            // 
            this.ptb_minimizer.BackColor = System.Drawing.Color.Transparent;
            this.ptb_minimizer.BackgroundImage = global::Launcher.Properties.Resources.windowmode1;
            this.ptb_minimizer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ptb_minimizer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptb_minimizer.Location = new System.Drawing.Point(303, 397);
            this.ptb_minimizer.Name = "ptb_minimizer";
            this.ptb_minimizer.Size = new System.Drawing.Size(16, 15);
            this.ptb_minimizer.TabIndex = 18;
            this.ptb_minimizer.TabStop = false;
            this.ptb_minimizer.Click += new System.EventHandler(this.ptb_minimizer_Click);
            // 
            // lbl_minimizer
            // 
            this.lbl_minimizer.AutoSize = true;
            this.lbl_minimizer.BackColor = System.Drawing.Color.Transparent;
            this.lbl_minimizer.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_minimizer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_minimizer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(178)))), ((int)(((byte)(43)))));
            this.lbl_minimizer.Location = new System.Drawing.Point(320, 397);
            this.lbl_minimizer.Name = "lbl_minimizer";
            this.lbl_minimizer.Size = new System.Drawing.Size(83, 13);
            this.lbl_minimizer.TabIndex = 19;
            this.lbl_minimizer.Text = "WindowMode";
            this.lbl_minimizer.Click += new System.EventHandler(this.lbl_minimizer_Click);
            // 
            // timer_slider
            // 
            this.timer_slider.Interval = 3000;
            this.timer_slider.Tick += new System.EventHandler(this.Slider_Tick);
            // 
            // panel_noticias
            // 
            this.panel_noticias.BackColor = System.Drawing.Color.Transparent;
            this.panel_noticias.Controls.Add(this.lbl_textNoticia);
            this.panel_noticias.Location = new System.Drawing.Point(72, 391);
            this.panel_noticias.Name = "panel_noticias";
            this.panel_noticias.Size = new System.Drawing.Size(190, 26);
            this.panel_noticias.TabIndex = 21;
            // 
            // timer_noticias
            // 
            this.timer_noticias.Interval = 40;
            this.timer_noticias.Tick += new System.EventHandler(this.timer_noticias_Tick);
            // 
            // timer_reinicioNoticias
            // 
            this.timer_reinicioNoticias.Interval = 10;
            this.timer_reinicioNoticias.Tick += new System.EventHandler(this.timer_reinicioNoticias_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Launcher.Properties.Resources.bg_launcher21;
            this.ClientSize = new System.Drawing.Size(410, 490);
            this.Controls.Add(this.panel_noticias);
            this.Controls.Add(this.ptb_minimizer);
            this.Controls.Add(this.lbl_minimizer);
            this.Controls.Add(this.ptb_soundMusic);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.ptb_facebook);
            this.Controls.Add(this.ptb_configs);
            this.Controls.Add(this.ptb_slider3);
            this.Controls.Add(this.ptb_slider2);
            this.Controls.Add(this.ptb_slider1);
            this.Controls.Add(this.lbl_mensajes);
            this.Controls.Add(this.completeProgressText);
            this.Controls.Add(this.lbl_BtnEntrar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ptb_cerrar);
            this.Controls.Add(this.ptb_bgSlider);
            this.Controls.Add(this.lbl_infoArchivos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Krisbel Launcher [PREMIUM] [KittySoft]";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_bgSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_cerrar)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_slider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_slider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_slider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_configs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_facebook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_soundMusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_minimizer)).EndInit();
            this.panel_noticias.ResumeLayout(false);
            this.panel_noticias.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptb_bgSlider;
        private System.Windows.Forms.PictureBox ptb_cerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ptb_slider1;
        private System.Windows.Forms.PictureBox ptb_slider2;
        private System.Windows.Forms.PictureBox ptb_slider3;
        private System.Windows.Forms.PictureBox ptb_configs;
        private System.Windows.Forms.PictureBox ptb_facebook;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox ptb_soundMusic;
        private System.Windows.Forms.PictureBox ptb_minimizer;
        private System.Windows.Forms.Label lbl_minimizer;
        private System.Windows.Forms.Timer timer_slider;
        public System.Windows.Forms.Label completeProgressText;
        public System.Windows.Forms.Panel panel_completeProgress;
        public System.Windows.Forms.Label lbl_BtnEntrar;
        public System.Windows.Forms.Label lbl_infoArchivos;
        public System.Windows.Forms.Label lbl_mensajes;
        public System.Windows.Forms.Label lbl_textNoticia;
        private System.Windows.Forms.Panel panel_noticias;
        private System.Windows.Forms.Timer timer_noticias;
        private System.Windows.Forms.Timer timer_reinicioNoticias;
    }
}

