using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KittySoft;
using Launcher.Clases;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.FileIO;

namespace Launcher
{
    public partial class Form1 : Form
    {

        //ATRIBUTOS
        private int checkedSoundMusic = 0;
        private int checkedMinimizer = 0;
        private int checkedSlider = 1;
        private int sizeNoticia = 0;
        private int sizeNegativo = 0;
        private int locationNoticia = 190;
        private int noticiasActive = 0;
        private int numNoticia;
        private int cantNoticias;
        private int localidadNoticia;
        private Bitmap bgBtn_Minimizer;
        private Bitmap bgSlider;
        private Color colorBtn_SoundMusic;
        private string UrlMu, NombreServidor, WebFacebook, NombreMain, IpServidor, ConnectServer;
        private string noticia1, noticia2, noticia3, noticia4, noticia5, noticia6, noticia7, noticia8, noticia9, noticia10;
        private ConfigsMu confsMu = new ConfigsMu();
        private ConfigsIni confsIni;
        private string tmpdir = Microsoft.VisualBasic.FileIO.SpecialDirectories.Temp + @"\KSTMP";
        private Microsoft.VisualBasic.Devices.Computer MyProject;

        public Form1()
        {
            InitializeComponent();
            Launcher.Clases.Globals.pForm = this;

            //Obtenemos las configuraciones

            if (confsMu.getIdioma() == "Spn")
            {
                lbl_textNoticia.Text = "Archivos";
                label1.Text = "Total";
                lbl_BtnEntrar.Text = "Jugar";
            }
            else if (confsMu.getIdioma() == "Eng")
            {
                lbl_textNoticia.Text = "Archive";
                label1.Text = "Total";
                lbl_BtnEntrar.Text = "To Play";
            }
            else if (confsMu.getIdioma() == "Por")
            {
                lbl_textNoticia.Text = "Arquivo";
                label1.Text = "Total";
                lbl_BtnEntrar.Text = "Reproduzir";
            }
            else
            {
                lbl_textNoticia.Text = "Archivo";
                label1.Text = "Total";
                lbl_BtnEntrar.Text = "Jugar";
            }

        }

#region Metodos

        //METODO ENCARGADO DE LEER ARCHIVOS INIS
        private void LeerIni(string Archivo = null)
        {
            this.confsIni = new ConfigsIni(Archivo);

            //////
            this.UrlMu = this.confsIni.UrlMu;

            Launcher.Clases.Globals.ServerURL = this.UrlMu + "Launcher/";

            //Descargamos el archivo temporal via hosting
            this.downloadArchiveTmp(this.UrlMu);
        }

        //METODO ENCARGADO DE MOSTRAR LOS TEXTOS
        private void Textos()
        {
            ConfigsMu kitty = new ConfigsMu();
            if (kitty.getIdioma() == "Spn")
            {
                lbl_mensajes.Text = "Cliente actualizado.";
            }
            else if (kitty.getIdioma() == "Eng")
            {
                lbl_mensajes.Text = "Update completed.";
            }
            else if (kitty.getIdioma() == "Por")
            {
                lbl_mensajes.Text = "Atualização concluída.";
            }
            else { lbl_mensajes.Text = "Cliente actualizado."; }
        }

        //METODO ENCARGADO DE LAS NOTICIAS VIA LAUNCHER
        private void noticiasHttp(string Archivo = null) 
        {

            //Preguntamos si las noticias se mostraran en el top o en el botom
            if (localidadNoticia > 0) { panel_noticias.Location = new Point(110, 52); }
            else { panel_noticias.Location = new Point(72, 391); }

            //Preguntamos si las noticias estan activas
            if (this.noticiasActive > 0)
            {
                //Preguntamos si el numero de noticia es igual a 0 y lo ponemos por defaul a 1
                if (this.numNoticia == 0)
                {
                    this.numNoticia = 1;
                    //Verificamos si la noticia no esta vacia
                    if (this.noticia1 != "")
                    {
                        //Asignamos la noticia
                    }
                        //De lo contrario asignamos una noticia por defecto
                    else { this.noticia1 = "      " + "Krisbel Launcher Premium"; }
                }
                
                //Iniciamos una noticia
                lbl_textNoticia.Text = this.noticia1;
                this.sizeNoticia = lbl_textNoticia.Width;

                //Iniciamos el timer noticias
                this.timer_noticias.Start();
            }

        }

        //METODO ENCARGADO DE VERIFICAR CONFUGS LADO HOSTING
        private void downloadArchiveTmp(string link) 
        {
            KrisbelLauncher Tmp = new KrisbelLauncher(link);

            //Asignamos los valores a las variables correspondientes
            this.WebFacebook = Tmp.LinkFacebookKS.Trim();
            this.NombreServidor = Tmp.NombreServidorKS.Trim();
            this.IpServidor = Tmp.IpServidorKS.Trim();
            this.ConnectServer = Tmp.PortServerKS.Trim();
            this.NombreMain = Tmp.NameMainKS.Trim();
            if (string.IsNullOrEmpty(this.NombreMain)) this.NombreMain = "main.exe";
            if (string.IsNullOrEmpty(this.IpServidor)) this.IpServidor = "yukisrv.ddns.net";
            if (string.IsNullOrEmpty(this.ConnectServer)) this.ConnectServer = "44405";

            Launcher.Clases.Globals.BinaryName = this.NombreMain;
            Launcher.Clases.Globals.IpServidor = this.IpServidor;
            Launcher.Clases.Globals.PortServidor = this.ConnectServer;

            //----------------------------------//
            this.noticiasActive = 0; int.TryParse(Tmp.NoticiasActiveKS, out this.noticiasActive);
            this.cantNoticias = 3; int.TryParse(Tmp.NumNoticiasKS, out this.cantNoticias);
            this.localidadNoticia = 0; int.TryParse(Tmp.LocalidadNoticiasKS, out this.localidadNoticia);
            //----------------------------------//
            this.noticia1 = "      " + Tmp.Noticia1.Trim();
            this.noticia2 = "      " + Tmp.Noticia2.Trim();
            this.noticia3 = "      " + Tmp.Noticia3.Trim();
            this.noticia4 = "      " + Tmp.Noticia4.Trim();
            this.noticia5 = "      " + Tmp.Noticia5.Trim();
            this.noticia6 = "      " + Tmp.Noticia6.Trim();
            this.noticia7 = "      " + Tmp.Noticia7.Trim();
            this.noticia8 = "      " + Tmp.Noticia8.Trim();
            this.noticia9 = "      " + Tmp.Noticia9.Trim();
            this.noticia10 = "      " + Tmp.Noticia10.Trim();

        }

#endregion

        private void ptb_cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ptb_configs_Click(object sender, EventArgs e)
        {
            Configuraciones configs = new Configuraciones();
            configs.Show();
        }

        private void ptb_facebook_Click(object sender, EventArgs e)
        {
            Process.Start(this.WebFacebook);
        }

        private void ptb_soundMusic_Click(object sender, EventArgs e)
        {

            if (this.checkedSoundMusic > 0)
            {
                this.checkedSoundMusic = 0;
                this.colorBtn_SoundMusic = Color.FromArgb(88, 128, 115);

                //Iniciamos el slider
                this.timer_slider.Start();

                //Guardamos la configuracion en el registro de windows
                this.confsMu.setSonido(1);
                this.confsMu.setMusica(1);
                this.confsMu.setSlider(1);
            }
            else 
            {
                this.checkedSoundMusic = 1;
                this.colorBtn_SoundMusic = Color.FromArgb(139, 90, 9);

                //Paramos el slider
                this.timer_slider.Stop();

                //Guardamos la configuracion en el registro de windows
                this.confsMu.setSonido(0);
                this.confsMu.setMusica(0);
                this.confsMu.setSlider(0);
            }

            //Asignamos el color de fondo
            ptb_soundMusic.BackColor = this.colorBtn_SoundMusic;
            
        }

        private void ptb_minimizer_Click(object sender, EventArgs e)
        {
            if (this.checkedMinimizer > 0)
            {
                this.checkedMinimizer = 0;
                this.bgBtn_Minimizer = new Bitmap(Properties.Resources.windowmode2);
                this.confsMu.setMinimizer(1);
            }
            else 
            {
                this.checkedMinimizer = 1;
                this.bgBtn_Minimizer = new Bitmap(Properties.Resources.windowmode1);
                this.confsMu.setMinimizer(0);
            }

            //Asignamos el background al picturebox minimizer
            this.ptb_minimizer.BackgroundImage = this.bgBtn_Minimizer;
        }

        private void lbl_minimizer_Click(object sender, EventArgs e)
        {
            if (this.checkedMinimizer > 0)
            {
                this.checkedMinimizer = 0;
                this.bgBtn_Minimizer = new Bitmap(Properties.Resources.windowmode2);
                this.confsMu.setMinimizer(1);
            }
            else
            {
                this.checkedMinimizer = 1;
                this.bgBtn_Minimizer = new Bitmap(Properties.Resources.windowmode1);
                this.confsMu.setMinimizer(0);
            }

            //Asignamos el background al picturebox minimizer
            this.ptb_minimizer.BackgroundImage = this.bgBtn_Minimizer;
        }

        private void ptb_slider1_Click(object sender, EventArgs e)
        {
            this.bgSlider = new Bitmap(Image.FromFile(Application.StartupPath + @"\Data\Launcher\Slider\slider1.jpg"));
            ptb_bgSlider.BackgroundImage = this.bgSlider;

            ptb_slider1.BackColor = Color.FromArgb(234, 204, 116);
            ptb_slider2.BackColor = Color.FromArgb(255,255,255);
            ptb_slider3.BackColor = Color.FromArgb(255,255,255);

            this.checkedSlider = 1;
        }

        private void ptb_slider2_Click(object sender, EventArgs e)
        {
            this.bgSlider = new Bitmap(Image.FromFile(Application.StartupPath + @"\Data\Launcher\Slider\slider2.jpg"));
            ptb_bgSlider.BackgroundImage = this.bgSlider;

            ptb_slider1.BackColor = Color.FromArgb(255, 255, 255);
            ptb_slider2.BackColor = Color.FromArgb(234, 204, 116);
            ptb_slider3.BackColor = Color.FromArgb(255, 255, 255);

            this.checkedSlider = 2;
        }

        private void ptb_slider3_Click(object sender, EventArgs e)
        {
            this.bgSlider = new Bitmap(Image.FromFile(Application.StartupPath + @"\Data\Launcher\Slider\slider3.jpg"));
            ptb_bgSlider.BackgroundImage = this.bgSlider;

            ptb_slider1.BackColor = Color.FromArgb(255, 255, 255);
            ptb_slider2.BackColor = Color.FromArgb(255, 255, 255);
            ptb_slider3.BackColor = Color.FromArgb(234, 204, 116);

            this.checkedSlider = 3;
        }

        private void Slider_Tick(object sender, EventArgs e)
        {
            if (this.checkedSlider == 1)
            {
                this.bgSlider = new Bitmap(Image.FromFile(Application.StartupPath + @"\Data\Launcher\Slider\slider2.jpg"));
                ptb_bgSlider.BackgroundImage = this.bgSlider;

                ptb_slider1.BackColor = Color.FromArgb(255, 255, 255);
                ptb_slider2.BackColor = Color.FromArgb(234, 204, 116);
                ptb_slider3.BackColor = Color.FromArgb(255, 255, 255);
                this.checkedSlider = 2;
            }
            else if (this.checkedSlider == 2) 
            {
                this.bgSlider = new Bitmap(Image.FromFile(Application.StartupPath + @"\Data\Launcher\Slider\slider3.jpg"));
                ptb_bgSlider.BackgroundImage = this.bgSlider;

                ptb_slider1.BackColor = Color.FromArgb(255, 255, 255);
                ptb_slider2.BackColor = Color.FromArgb(255, 255, 255);
                ptb_slider3.BackColor = Color.FromArgb(234, 204, 116);
                this.checkedSlider = 3;
            }
            else if (this.checkedSlider == 3) 
            {
                this.bgSlider = new Bitmap(Image.FromFile(Application.StartupPath + @"\Data\Launcher\Slider\slider1.jpg"));
                ptb_bgSlider.BackgroundImage = this.bgSlider;

                ptb_slider1.BackColor = Color.FromArgb(234, 204, 116);
                ptb_slider2.BackColor = Color.FromArgb(255, 255, 255);
                ptb_slider3.BackColor = Color.FromArgb(255, 255, 255);
                this.checkedSlider = 1;
            }
            else 
            {
                this.bgSlider = new Bitmap(Image.FromFile(Application.StartupPath + @"\Data\Launcher\Slider\slider1.jpg"));
                ptb_bgSlider.BackgroundImage = this.bgSlider;

                ptb_slider1.BackColor = Color.FromArgb(234, 204, 116);
                ptb_slider2.BackColor = Color.FromArgb(255, 255, 255);
                ptb_slider3.BackColor = Color.FromArgb(255, 255, 255);
                this.checkedSlider = 2;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            //Asignamos el background del slider
            this.bgSlider = new Bitmap(Image.FromFile(Application.StartupPath + @"\Data\Launcher\Slider\slider1.jpg"));
            ptb_bgSlider.BackgroundImage = this.bgSlider;
            this.bgSlider = new Bitmap(Image.FromFile(Application.StartupPath + @"\Data\Launcher\Images\logo.png"));
            pictureBox7.BackgroundImage = this.bgSlider;

            this.MyProject = new Microsoft.VisualBasic.Devices.Computer();

            //Preguntamos si minimizer esta on/off
            if (this.confsMu.getMinimizer() > 0)
            {
                this.checkedMinimizer = 0;
                this.bgBtn_Minimizer = new Bitmap(Properties.Resources.windowmode2);

                //Asignamos el background al picturebox minimizer
                this.ptb_minimizer.BackgroundImage = this.bgBtn_Minimizer;
            }
            else
            {
                this.checkedMinimizer = 1;
                this.bgBtn_Minimizer = new Bitmap(Properties.Resources.windowmode1);

                //Asignamos el background al picturebox minimizer
                this.ptb_minimizer.BackgroundImage = this.bgBtn_Minimizer;
            }

            //Preguntamos si el estado del slider esta on/off
            if (this.confsMu.getSlider() > 0)
            {
                this.checkedSoundMusic = 0;
                this.colorBtn_SoundMusic = Color.FromArgb(88, 128, 115);

                //Asignamos el color de fondo
                ptb_soundMusic.BackColor = this.colorBtn_SoundMusic;

                //Iniciamos el slider
                this.timer_slider.Start();
            }
            else
            {
                this.checkedSoundMusic = 1;
                this.colorBtn_SoundMusic = Color.FromArgb(139, 90, 9);

                //Asignamos el color de fondo
                ptb_soundMusic.BackColor = this.colorBtn_SoundMusic;

                //Paramos el slider
                this.timer_slider.Stop();
            }

            //Leemos el archivo ini
            LeerIni(Application.StartupPath + @"\Data\Launcher\Configs\Configs.kitty");
            //Instanciamos el metodo para obtener el estado del servidor
            this.Textos();
            //Iniciamos en metodo noticias
            this.noticiasHttp();

        }

        private void lbl_BtnEntrar_Click(object sender, EventArgs e)
        {

            if (Common.IsGameRunning())
            {
                Common.EnableStart();
            }
            else
            {
                Networking.CheckNetwork();
            }

            lbl_mensajes.ResetText();
            lbl_BtnEntrar.Enabled = false;
        }

        private void timer_noticias_Tick(object sender, EventArgs e)
        {

            //Preguntamos si la localidad del label que muestra la noticias es mayor a 0
            if (lbl_textNoticia.Location.X > 0)
            {
                //Cambiamos la localidad del label que muestra la noticia
                lbl_textNoticia.Location = new Point(this.locationNoticia, 6);
                //Decrementamos la localidad en 1
                this.locationNoticia += -1;
                //Preguntamos si el atributo locationNoticia es negativo -1 y lo ponemos en 0
                if (this.locationNoticia == -1)
                {
                    this.locationNoticia = 0;
                }
            }
            else if(this.locationNoticia == 0)
            {
                if (this.sizeNoticia > 0)
                {
                    //Cambiamos la localidad del label que muestra la noticia
                    lbl_textNoticia.Location = new Point(this.sizeNegativo, 6);
                    //Decrementamos la localidad en -1
                    this.sizeNegativo += -1;
                    //Decrementamos el sizeNoticia en 1
                    this.sizeNoticia += -1;
                }
                else
                {
                    //Si el numero de noticia es menor al maximo de noticias lo incrementamos en 1 (Ejemplo: si esta = a 1 luego va estar igual a 2)
                    if (this.numNoticia < this.cantNoticias)
                    {
                        this.numNoticia++;
                        this.sizeNoticia = lbl_textNoticia.Width;
                        this.timer_noticias.Stop();
                        this.timer_reinicioNoticias.Start();
                    }
                    else 
                    { 
                        //Si el numero de noticia es igual al maximo de noticias lo volvemos a 1
                        this.numNoticia = 1;
                        this.sizeNoticia = lbl_textNoticia.Width;
                        //Paramos el timer noticia
                        this.timer_noticias.Stop();
                        //Iniciamos el timer para reiniciar la noticia
                        this.timer_reinicioNoticias.Start();
                    }

                }
            }

        }

        private void timer_reinicioNoticias_Tick(object sender, EventArgs e)
        {
            
            if (this.sizeNegativo == -this.sizeNoticia) 
            {
                
                //Cambiamos la localidad del label que muestra la noticia
                lbl_textNoticia.Location = new Point(190, 6);
                //Reiniciamos los atributos
                this.sizeNegativo = 0;
                this.locationNoticia = 190;

                switch (this.numNoticia)
                {
                    case 1: { lbl_textNoticia.Text = this.noticia1; this.sizeNoticia = lbl_textNoticia.Width; this.timer_reinicioNoticias.Stop(); this.timer_noticias.Start(); break; }
                    case 2: { lbl_textNoticia.Text = this.noticia2; this.sizeNoticia = lbl_textNoticia.Width; this.timer_reinicioNoticias.Stop(); this.timer_noticias.Start(); break; }
                    case 3: { lbl_textNoticia.Text = this.noticia3; this.sizeNoticia = lbl_textNoticia.Width; this.timer_reinicioNoticias.Stop(); this.timer_noticias.Start(); break; }
                    case 4: { lbl_textNoticia.Text = this.noticia4; this.sizeNoticia = lbl_textNoticia.Width; this.timer_reinicioNoticias.Stop(); this.timer_noticias.Start(); break; }
                    case 5: { lbl_textNoticia.Text = this.noticia5; this.sizeNoticia = lbl_textNoticia.Width; this.timer_reinicioNoticias.Stop(); this.timer_noticias.Start(); break; }
                    case 6: { lbl_textNoticia.Text = this.noticia6; this.sizeNoticia = lbl_textNoticia.Width; this.timer_reinicioNoticias.Stop(); this.timer_noticias.Start(); break; }
                    case 7: { lbl_textNoticia.Text = this.noticia7; this.sizeNoticia = lbl_textNoticia.Width; this.timer_reinicioNoticias.Stop(); this.timer_noticias.Start(); break; }
                    case 8: { lbl_textNoticia.Text = this.noticia8; this.sizeNoticia = lbl_textNoticia.Width; this.timer_reinicioNoticias.Stop(); this.timer_noticias.Start(); break; }
                    case 9: { lbl_textNoticia.Text = this.noticia9; this.sizeNoticia = lbl_textNoticia.Width; this.timer_reinicioNoticias.Stop(); this.timer_noticias.Start(); break; }
                    case 10: { lbl_textNoticia.Text = this.noticia10; this.sizeNoticia = lbl_textNoticia.Width; this.timer_reinicioNoticias.Stop(); this.timer_noticias.Start(); break; }
                   
                }

                
            }
            
        }


    }
}
