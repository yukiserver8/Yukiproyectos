using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KittySoft;

namespace Launcher
{
    public partial class Configuraciones : Form
    {
        public Configuraciones()
        {
            InitializeComponent();
        }

        //ATRIBUTOS
        private Bitmap checkedBg;
        private int checkedCamara = 0;
        private int checked600x480 = 0;
        private int checked800x600 = 0;
        private int checked1024x768 = 0;
        private int checked1280x1024 = 0;
        private int checkedMiniMap = 0;
        private int checkedCielos = 0;
        private int checkedDiaNoche = 0;
        private int checkedTipoCamara3D = 0;
        private int tipoFile;
        private string nombreFiles;
        private string Camara3DValue, Camara3DTipo;
        private ConfigsMu confsMu = new ConfigsMu();
        private MyIni MyIni;

        private void ptb_cerrar_Click(object sender, EventArgs e)
        {
            this.Close(); //Cerramos el formulario
            Form1 formulario = new Form1();
            formulario.Show();
        }

        //METODO ENCARGADO DE GUARDAR LAS CONFIGURACIONES

        private void ptb_checkedCamara3D_Click(object sender, EventArgs e)
        {
            if (this.checkedCamara > 0)
            {
                this.checkedCamara = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);

                //Guardamos el resultado en el archivo Configuraciones.ini
                //Instanciamos la clase MyIni
                this.MyIni = new MyIni("./Configuraciones.ini");
                MyIni.WriteString("Camara3D", "Switch", "0");
            }
            else 
            { 
                this.checkedCamara = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);

                //Guardamos el resultado en el archivo Configuraciones.ini
                //Instanciamos la clase MyIni
                this.MyIni = new MyIni("./Configuraciones.ini");
                MyIni.WriteString("Camara3D", "Switch", "1");
            }

            //Asignamos el background al checked
            this.ptb_checkedCamara3D.BackgroundImage = this.checkedBg;
        }

        //METODO ENCARGADO DE OBTENER LOS DATOS DE LOS FILES A USAR
        private void tipoFiles() 
        {
            //Obtnemos el tipo de files
            this.tipoFile = 0;

            //TIPOS DE FILES ([0 = Aminyuz 97d] - [1 = DarksTeam 97D+99I] - [2 = Mirague Continent V3 99b] - [3 = Otros files cualquiera])

            switch (this.tipoFile)
            {
                case 0: { this.nombreFiles = "Aminyuz 97d"; panel_aminyuz.Visible = true; break; }
                case 1: { this.nombreFiles = "DarksTeam 97D+99I"; panel_DarksTeam.Visible = true; break; }
                case 2: { this.nombreFiles = "Mirague Continent V3 99b"; break; }
                case 3: { this.nombreFiles = "Files Desconocidos"; break; }
            }
        }

        private void lbl_checkedCamara3D_Click(object sender, EventArgs e)
        {
            if (this.checkedCamara > 0)
            {
                this.checkedCamara = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);

                //Guardamos el resultado en el archivo Configuraciones.ini
                //Instanciamos la clase MyIni
                this.MyIni = new MyIni("./Configuraciones.ini");
                MyIni.WriteString("Camara3D", "Switch", "0");
            }
            else
            {
                this.checkedCamara = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);

                //Guardamos el resultado en el archivo Configuraciones.ini
                //Instanciamos la clase MyIni
                this.MyIni = new MyIni("./Configuraciones.ini");
                MyIni.WriteString("Camara3D", "Switch", "1");
            }

            //Asignamos el background al checked
            this.ptb_checkedCamara3D.BackgroundImage = this.checkedBg;
        }

        private void ptb_checked600x480_Click(object sender, EventArgs e)
        {
            if (this.checked600x480 > 0)
            {
                this.checked600x480 = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                //Asignamos el background al checked
                this.ptb_checked600x480.BackgroundImage = this.checkedBg;
                this.confsMu.setResolucion(1);

            }
            else
            {
                this.checked600x480 = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);
                //Asignamos el background al checked
                this.ptb_checked600x480.BackgroundImage = this.checkedBg;
                this.confsMu.setResolucion(0);

                //Ponemos las demas resoluciones por default
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                this.checked800x600 = 0;
                this.checked1024x768 = 0;
                this.checked1280x1024 = 0;

                ptb_checked800x600.BackgroundImage = this.checkedBg;
                ptb_checked1024x768.BackgroundImage = this.checkedBg;
                ptb_checked1280x1024.BackgroundImage = this.checkedBg;
            }

        }

        private void lbl_checked600x480_Click(object sender, EventArgs e)
        {
            if (this.checked600x480 > 0)
            {
                this.checked600x480 = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                //Asignamos el background al checked
                this.ptb_checked600x480.BackgroundImage = this.checkedBg;
                this.confsMu.setResolucion(1);
            }
            else
            {
                this.checked600x480 = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);
                //Asignamos el background al checked
                this.ptb_checked600x480.BackgroundImage = this.checkedBg;
                this.confsMu.setResolucion(0);

                //Ponemos las demas resoluciones por default
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                this.checked800x600 = 0;
                this.checked1024x768 = 0;
                this.checked1280x1024 = 0;

                ptb_checked800x600.BackgroundImage = this.checkedBg;
                ptb_checked1024x768.BackgroundImage = this.checkedBg;
                ptb_checked1280x1024.BackgroundImage = this.checkedBg;
            }

        }

        private void ptb_checked800x600_Click(object sender, EventArgs e)
        {
            if (this.checked800x600 > 0)
            {
                this.checked800x600 = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                //Asignamos el background al checked
                this.ptb_checked800x600.BackgroundImage = this.checkedBg;
                this.confsMu.setResolucion(1);
            }
            else
            {
                this.checked800x600 = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);
                //Asignamos el background al checked
                this.ptb_checked800x600.BackgroundImage = this.checkedBg;
                this.confsMu.setResolucion(1);

                //Ponemos las demas resoluciones por default
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                this.checked600x480 = 0;
                this.checked1024x768 = 0;
                this.checked1280x1024 = 0;

                ptb_checked600x480.BackgroundImage = this.checkedBg;
                ptb_checked1024x768.BackgroundImage = this.checkedBg;
                ptb_checked1280x1024.BackgroundImage = this.checkedBg;
            }

        }

        private void lbl_checked800x600_Click(object sender, EventArgs e)
        {
            if (this.checked800x600 > 0)
            {
                this.checked800x600 = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                //Asignamos el background al checked
                this.ptb_checked800x600.BackgroundImage = this.checkedBg;
                this.confsMu.setResolucion(1);

            }
            else
            {
                this.checked800x600 = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);
                //Asignamos el background al checked
                this.ptb_checked800x600.BackgroundImage = this.checkedBg;
                this.confsMu.setResolucion(1);

                //Ponemos las demas resoluciones por default
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                this.checked600x480 = 0;
                this.checked1024x768 = 0;
                this.checked1280x1024 = 0;

                ptb_checked600x480.BackgroundImage = this.checkedBg;
                ptb_checked1024x768.BackgroundImage = this.checkedBg;
                ptb_checked1280x1024.BackgroundImage = this.checkedBg;
            }

        }

        private void ptb_checked1024x768_Click(object sender, EventArgs e)
        {
            if (this.checked1024x768 > 0)
            {
                this.checked1024x768 = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                //Asignamos el background al checked
                this.ptb_checked1024x768.BackgroundImage = this.checkedBg;
                this.confsMu.setResolucion(1);
            }
            else
            {
                this.checked1024x768 = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);
                //Asignamos el background al checked
                this.ptb_checked1024x768.BackgroundImage = this.checkedBg;
                this.confsMu.setResolucion(2);

                //Ponemos las demas resoluciones por default
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                this.checked600x480 = 0;
                this.checked800x600 = 0;
                this.checked1280x1024 = 0;

                ptb_checked600x480.BackgroundImage = this.checkedBg;
                ptb_checked800x600.BackgroundImage = this.checkedBg;
                ptb_checked1280x1024.BackgroundImage = this.checkedBg;
            }

        }

        private void lbl_checked1024x768_Click(object sender, EventArgs e)
        {
            if (this.checked1024x768 > 0)
            {
                this.checked1024x768 = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                //Asignamos el background al checked
                this.ptb_checked1024x768.BackgroundImage = this.checkedBg;
                this.confsMu.setResolucion(1);
            }
            else
            {
                this.checked1024x768 = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);
                //Asignamos el background al checked
                this.ptb_checked1024x768.BackgroundImage = this.checkedBg;
                this.confsMu.setResolucion(2);

                //Ponemos las demas resoluciones por default
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                this.checked600x480 = 0;
                this.checked800x600 = 0;
                this.checked1280x1024 = 0;

                ptb_checked600x480.BackgroundImage = this.checkedBg;
                ptb_checked800x600.BackgroundImage = this.checkedBg;
                ptb_checked1280x1024.BackgroundImage = this.checkedBg;
            }

        }

        private void ptb_checked1280x1024_Click(object sender, EventArgs e)
        {
            if (this.checked1280x1024 > 0)
            {
                this.checked1280x1024 = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                //Asignamos el background al checked
                this.ptb_checked1280x1024.BackgroundImage = this.checkedBg;
                this.confsMu.setResolucion(1);
            }
            else
            {
                this.checked1280x1024 = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);
                //Asignamos el background al checked
                this.ptb_checked1280x1024.BackgroundImage = this.checkedBg;
                this.confsMu.setResolucion(3);

                //Ponemos las demas resoluciones por default
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                this.checked600x480 = 0;
                this.checked800x600 = 0;
                this.checked1024x768 = 0;

                ptb_checked600x480.BackgroundImage = this.checkedBg;
                ptb_checked800x600.BackgroundImage = this.checkedBg;
                ptb_checked1024x768.BackgroundImage = this.checkedBg;
            }

        }

        private void lbl_checked1280x1024_Click(object sender, EventArgs e)
        {
            if (this.checked1280x1024 > 0)
            {
                this.checked1280x1024 = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                //Asignamos el background al checked
                this.ptb_checked1280x1024.BackgroundImage = this.checkedBg;
                this.confsMu.setResolucion(1);
            }
            else
            {
                this.checked1280x1024 = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);
                //Asignamos el background al checked
                this.ptb_checked1280x1024.BackgroundImage = this.checkedBg;
                this.confsMu.setResolucion(3);

                //Ponemos las demas resoluciones por default
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                this.checked600x480 = 0;
                this.checked800x600 = 0;
                this.checked1024x768 = 0;

                ptb_checked600x480.BackgroundImage = this.checkedBg;
                ptb_checked800x600.BackgroundImage = this.checkedBg;
                ptb_checked1024x768.BackgroundImage = this.checkedBg;
            }

        }

        private void ptb_checkedMiniMap_Click(object sender, EventArgs e)
        {
            if (this.checkedMiniMap > 0)
            {
                this.checkedMiniMap = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);

                //Guardamos el resultado en el archivo Configuraciones.ini
                //Instanciamos la clase MyIni
                this.MyIni = new MyIni("./Configuraciones.ini");
                MyIni.WriteString("MiniMap", "Switch", "0");
            }
            else
            {
                this.checkedMiniMap = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);

                //Guardamos el resultado en el archivo Configuraciones.ini
                //Instanciamos la clase MyIni
                this.MyIni = new MyIni("./Configuraciones.ini");
                MyIni.WriteString("MiniMap", "Switch", "1");
            }
            //Asignamos el background al checked
            this.ptb_checkedMiniMap.BackgroundImage = this.checkedBg;
        }

        private void lbl_checkedMiniMap_Click(object sender, EventArgs e)
        {
            if (this.checkedMiniMap > 0)
            {
                this.checkedMiniMap = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);

                //Guardamos el resultado en el archivo Configuraciones.ini
                //Instanciamos la clase MyIni
                this.MyIni = new MyIni("./Configuraciones.ini");
                MyIni.WriteString("MiniMap", "Switch", "0");
            }
            else
            {
                this.checkedMiniMap = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);

                //Guardamos el resultado en el archivo Configuraciones.ini
                //Instanciamos la clase MyIni
                this.MyIni = new MyIni("./Configuraciones.ini");
                MyIni.WriteString("MiniMap", "Switch", "1");
            }
            //Asignamos el background al checked
            this.ptb_checkedMiniMap.BackgroundImage = this.checkedBg;
        }

        private void ptb_checkedCielos_Click(object sender, EventArgs e)
        {
            if (this.checkedCielos > 0)
            {
                this.checkedCielos = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);

                //Guardamos el resultado en el archivo Configuraciones.ini
                //Instanciamos la clase MyIni
                this.MyIni = new MyIni("./Configuraciones.ini");
                MyIni.WriteString("Cielos", "Switch", "0");
            }
            else
            {
                this.checkedCielos = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);

                //Guardamos el resultado en el archivo Configuraciones.ini
                //Instanciamos la clase MyIni
                this.MyIni = new MyIni("./Configuraciones.ini");
                MyIni.WriteString("Cielos", "Switch", "1");
            }
            //Asignamos el background al checked
            this.ptb_checkedCielos.BackgroundImage = this.checkedBg;
        }

        private void lbl_checkedCielos_Click(object sender, EventArgs e)
        {
            if (this.checkedCielos > 0)
            {
                this.checkedCielos = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);

                //Guardamos el resultado en el archivo Configuraciones.ini
                //Instanciamos la clase MyIni
                this.MyIni = new MyIni("./Configuraciones.ini");
                MyIni.WriteString("Cielos", "Switch", "0");
            }
            else
            {
                this.checkedCielos = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);

                //Guardamos el resultado en el archivo Configuraciones.ini
                //Instanciamos la clase MyIni
                this.MyIni = new MyIni("./Configuraciones.ini");
                MyIni.WriteString("Cielos", "Switch", "1");
            }
            //Asignamos el background al checked
            this.ptb_checkedCielos.BackgroundImage = this.checkedBg;
        }

        private void ptb_checkedDiaNoche_Click(object sender, EventArgs e)
        {
            if (this.checkedDiaNoche > 0)
            {
                this.checkedDiaNoche = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);

                //Guardamos el resultado en el archivo Configuraciones.ini
                //Instanciamos la clase MyIni
                this.MyIni = new MyIni("./Configuraciones.ini");
                MyIni.WriteString("Cielos", "Dia/Noche", "0");
            }
            else
            {
                this.checkedDiaNoche = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);

                //Guardamos el resultado en el archivo Configuraciones.ini
                //Instanciamos la clase MyIni
                this.MyIni = new MyIni("./Configuraciones.ini");
                MyIni.WriteString("Cielos", "Dia/Noche", "1");
            }

            //Asignamos el background al checked
            this.ptb_checkedDiaNoche.BackgroundImage = this.checkedBg;
        }

        private void lbl_checkedDiaNoche_Click(object sender, EventArgs e)
        {
            if (this.checkedDiaNoche > 0)
            {
                this.checkedDiaNoche = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);

                //Guardamos el resultado en el archivo Configuraciones.ini
                //Instanciamos la clase MyIni
                this.MyIni = new MyIni("./Configuraciones.ini");
                MyIni.WriteString("Cielos", "Dia/Noche", "0");
            }
            else
            {
                this.checkedDiaNoche = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);

                //Guardamos el resultado en el archivo Configuraciones.ini
                //Instanciamos la clase MyIni
                this.MyIni = new MyIni("./Configuraciones.ini");
                MyIni.WriteString("Cielos", "Dia/Noche", "1");
            }

            //Asignamos el background al checked
            this.ptb_checkedDiaNoche.BackgroundImage = this.checkedBg;
        }

        //METODO ENCARGADO DE OBTENER LA RESOLUCION DEL MU
        private void getResolucion() 
        {
            int Resolucion = 0;
            Resolucion = this.confsMu.getResolucion();

            switch (Resolucion)
            {
                case 0: 
                    {
                        this.checked600x480 = 1;
                        this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);
                        //Asignamos el background al checked
                        this.ptb_checked600x480.BackgroundImage = this.checkedBg; 
                        break;
                    }
                case 1: 
                    {
                        this.checked800x600 = 1;
                        this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);
                        //Asignamos el background al checked
                        this.ptb_checked800x600.BackgroundImage = this.checkedBg;
                        break;
                    }
                case 2: 
                    {
                        this.checked1024x768 = 1;
                        this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);
                        //Asignamos el background al checked
                        this.ptb_checked1024x768.BackgroundImage = this.checkedBg;
                        break;
                    }
                case 3: 
                    {
                        this.checked1280x1024 = 1;
                        this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);
                        //Asignamos el background al checked
                        this.ptb_checked1280x1024.BackgroundImage = this.checkedBg;
                        break;
                    }
            }
        }

        //METODO ENCARGADO DE OBTENER EL ESTADO DE LA CAMARA 3D
        private void getCamara3D() 
        { 
            //Instanciamos la clase MyIni
            this.MyIni = new MyIni("./Configuraciones.ini");
            
            this.Camara3DValue = MyIni.GetString("Camara3D", "Switch", string.Empty);
            this.Camara3DTipo = MyIni.GetString("Camara3D", "Tipo", "0");

            if (this.Camara3DValue == "0")
            {
                this.checkedCamara = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                ptb_checkedCamara3D.BackgroundImage = this.checkedBg;
            }
            else 
            {
                this.checkedCamara = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);
                ptb_checkedCamara3D.BackgroundImage = this.checkedBg;
            }

            if (this.Camara3DTipo == "1")
            {
                lbl_tipoCamara3D.Text = "Scroll del Mouse";
                lbl_tipo1.BackColor = Color.White;
            }
            else if (this.Camara3DTipo == "2")
            {
                lbl_tipoCamara3D.Text = "Ambos Botones...";
                lbl_tipo2.BackColor = Color.White;
            }
           

        }

        //METODO ENCARGADO DE OBTENER EL ESTADO DEL MINIMAP CIELOS Y DIA & NOCHE
        private void getVarios() 
        {
            //Instanciamos la clase MyIni
            this.MyIni = new MyIni("./Configuraciones.ini");
            string Minimap,Cielos,DiaNoche;
            Minimap = this.MyIni.GetString("MiniMap", "Switch", "0");
            Cielos = this.MyIni.GetString("Cielos", "Switch", "0");
            DiaNoche = this.MyIni.GetString("Cielos", "Dia/Noche", "0");

            if (Minimap == "0")
            {
                this.checkedMiniMap = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                ptb_checkedMiniMap.BackgroundImage = this.checkedBg;
            }
            else 
            {
                this.checkedMiniMap = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);
                ptb_checkedMiniMap.BackgroundImage = this.checkedBg;
            }

            if (Cielos == "0")
            {
                this.checkedCielos = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                ptb_checkedCielos.BackgroundImage = this.checkedBg;
            }
            else 
            {
                this.checkedCielos = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);
                ptb_checkedCielos.BackgroundImage = this.checkedBg;
            }

            if (DiaNoche == "0")
            {
                this.checkedDiaNoche = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOff);
                ptb_checkedDiaNoche.BackgroundImage = this.checkedBg;
            }
            else 
            {
                this.checkedDiaNoche = 1;
                this.checkedBg = new Bitmap(Properties.Resources.bg_checkedOn);
                ptb_checkedDiaNoche.BackgroundImage = this.checkedBg;
            }
        }

        private void Configuraciones_Load(object sender, EventArgs e)
        {
            //OBTENEMOS EL ID DE USUARIO
            txt_userID.Text = this.confsMu.getIdUser();
            //OBTENEMOS LA RESOLUCION
            this.getResolucion();
            //OBTENEMOS LA CONFIGURACION DE LA CAMARA
            this.getCamara3D();
            //OBTENEMOS LA CONFIGURACION DEL MINIMAP CIELOS Y DIA & NOCHE
            this.getVarios();
            //OBTENEMOS LOS DATOS D LOS FILES A USAR
            this.tipoFiles();
        }

        private void ptb_cmbBoxOpcionesCamara_Click(object sender, EventArgs e)
        {
            
            if (this.checkedTipoCamara3D > 0)
            {
                this.checkedTipoCamara3D = 0;
                panel_btnOpcionesCamara.Visible = false;
                panel_btnOpcionesCamara.Height = 0;
                this.checkedBg = new Bitmap(Properties.Resources.bg_flechaBotton);
                ptb_cmbBoxOpcionesCamara.BackgroundImage = this.checkedBg;

                if (this.Camara3DTipo == "1")
                {
                    lbl_tipoCamara3D.Text = "Scroll del Mouse";
                    lbl_tipo1.BackColor = Color.White;
                }
                else if (this.Camara3DTipo == "2")
                {
                    lbl_tipoCamara3D.Text = "Ambos Botones...";
                    lbl_tipo2.BackColor = Color.White;
                }
            }
            else 
            {
                this.checkedTipoCamara3D = 1;
                panel_btnOpcionesCamara.Visible = true;
                panel_btnOpcionesCamara.Height = 46;
                this.checkedBg = new Bitmap(Properties.Resources.bg_flechaTop);
                ptb_cmbBoxOpcionesCamara.BackgroundImage = this.checkedBg;

                if (this.Camara3DTipo == "1")
                {
                    lbl_tipoCamara3D.Text = "Scroll del Mouse";
                    lbl_tipo1.BackColor = Color.White;
                }
                else if (this.Camara3DTipo == "2")
                {
                    lbl_tipoCamara3D.Text = "Ambos Botones...";
                    lbl_tipo2.BackColor = Color.White;
                }
            }
        }

        private void lbl_tipo1_MouseMove(object sender, MouseEventArgs e)
        {
            lbl_tipo1.BackColor = Color.White;
            lbl_tipo2.BackColor = Color.Transparent;
        }

        private void lbl_tipo2_MouseMove(object sender, MouseEventArgs e)
        {
            lbl_tipo1.BackColor = Color.Transparent;
            lbl_tipo2.BackColor = Color.White;
        }

        private void lbl_tipo1_MouseLeave(object sender, EventArgs e)
        {
            lbl_tipo1.BackColor = Color.Transparent;
        }

        private void lbl_tipo2_MouseLeave(object sender, EventArgs e)
        {
            lbl_tipo2.BackColor = Color.Transparent;
        }

        private void lbl_tipo1_Click(object sender, EventArgs e)
        {
            lbl_tipoCamara3D.Text = "Scroll del Mouse";
            lbl_tipo1.BackColor = Color.White;
            this.checkedTipoCamara3D = 0;
            panel_btnOpcionesCamara.Visible = false;
            panel_btnOpcionesCamara.Height = 0;
            this.checkedBg = new Bitmap(Properties.Resources.bg_flechaBotton);
            ptb_cmbBoxOpcionesCamara.BackgroundImage = this.checkedBg;
            this.Camara3DTipo = "1";

            //Guardamos el resultado en el archivo Configuraciones.ini
            //Instanciamos la clase MyIni
            this.MyIni = new MyIni("./Configuraciones.ini");
            MyIni.WriteString("Camara3D", "Tipo", "1");
        }

        private void lbl_tipo2_Click(object sender, EventArgs e)
        {
            lbl_tipoCamara3D.Text = "Ambos Botones...";
            lbl_tipo2.BackColor = Color.White;
            this.checkedTipoCamara3D = 0;
            panel_btnOpcionesCamara.Visible = false;
            panel_btnOpcionesCamara.Height = 0;
            this.checkedBg = new Bitmap(Properties.Resources.bg_flechaBotton);
            ptb_cmbBoxOpcionesCamara.BackgroundImage = this.checkedBg;
            this.Camara3DTipo = "2";

            //Guardamos el resultado en el archivo Configuraciones.ini
            //Instanciamos la clase MyIni
            this.MyIni = new MyIni("./Configuraciones.ini");
            MyIni.WriteString("Camara3D", "Tipo", "2");
        }

        private void txt_userID_TextChanged(object sender, EventArgs e)
        {
            this.confsMu.setIdUser(txt_userID.Text);
        }
    }
}
