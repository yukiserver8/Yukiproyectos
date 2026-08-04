using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittySoft
{
    public class ConfigsMu
    {
        private string rutaWebzen;
        public ConfigsMu()
        {
            //Inicializamos las variables
            this.rutaWebzen = @"HKEY_CURRENT_USER\Software\Webzen\Mu\Config";
        }

        //METODOS

        //*CONFIGURACIONES*//

        //*=======================================================================*//
        //Metodo encargado de obtener el id 
        public string getIdUser() 
        {
            object IdUser = Registry.GetValue(this.rutaWebzen, "ID", null);
            if (null != IdUser)
            {    
                return IdUser.ToString();
            }
            else { return ""; }
        }

        //Metodo encargado de obtener la resolucion de pantalla
        public int getResolucion()
        {
            object Resolucion = Registry.GetValue(this.rutaWebzen, "Resolution", null);
            if (null != Resolucion)
            {
                return (int)Resolucion;
            }
            else { return 0; }
        }

        //Metodo encargado de obtener la musica
        public int getMusica() 
        {
            object Musica = Registry.GetValue(this.rutaWebzen, "MusicOnOff", null);
            if (null != Musica)
            {
                return (int)Musica;
            }
            else { return 0; }
        }

        //Metodo encargado de obtener el sonido
        public int getSonido() 
        {
            object Sonido = Registry.GetValue(this.rutaWebzen, "SoundOnOff", null);
            if (null != Sonido)
            {
                return (int)Sonido;
            }
            else { return 0; }
        }

        //Metodo encargado de obtener el estado del slider
        public int getSlider() 
        {
            object Slider = Registry.GetValue(this.rutaWebzen, "SliderOnOff", null);
            if (null != Slider)
            {
                return (int)Slider;
            }
            else { return 0; }
        }

        //Metodo encargado de obtener el minimizer
        public int getMinimizer() 
        {
            object Minimizer = Registry.GetValue(this.rutaWebzen, "Minimizer", null);
            if (null != Minimizer)
            {
                return (int)Minimizer;
            }
            else { return 0; }
        }

        //Metodo encargado de obtener el Modo Ventana
        public int getVentana() 
        {
            object Ventana = Registry.GetValue(this.rutaWebzen, "WindowMode", null);
            if (null != Ventana)
            {
                return (int)Ventana;
            }
            else { return 0; }
        }

        //Método encargado de obtener el ColorBit
        public int getColorBit() 
        {
            object ColorBit = Registry.GetValue(this.rutaWebzen, "DisplayColorBit", null);
            if (null != ColorBit)
            {
                return (int)ColorBit;
            }
            else { return 0; }
        }

        //Metodo encargado de obtener el Lenguaje
        public string getIdioma() 
        { 
            object Idioma = Registry.GetValue(this.rutaWebzen, "LangSelection", null);
            if (null != Idioma)
            {
                return Idioma.ToString();
            }
            else { return "Spn"; }
        }

        //*=======================================================================*//

        //Método encargado de guardar todas las configuraciones
        //public void setConfiguracion(string IdUser, int Ventana, int Resolucion, int ColorBit, int Sonido, int Musica, string Idioma) 
        //{

        //    Registry.SetValue(this.rutaWebzen, "ID", IdUser);
        //    Registry.SetValue(this.rutaWebzen, "WindowMode", Ventana);
        //    Registry.SetValue(this.rutaWebzen, "Resolution", Resolucion);
        //    Registry.SetValue(this.rutaWebzen, "DisplayColorBit", ColorBit);
        //    Registry.SetValue(this.rutaWebzen, "SoundOnOff", Sonido);
        //    Registry.SetValue(this.rutaWebzen, "MusicOnOff", Musica);
        //    Registry.SetValue(this.rutaWebzen, "LangSelection", Idioma);
        //}
        //Metodo encargado de guardar el id de usuario
        public void setIdUser(string IdUser) 
        {
            Registry.SetValue(this.rutaWebzen, "ID", IdUser);
        }

        public void setResolucion(int Resolucion) 
        {
            Registry.SetValue(this.rutaWebzen, "Resolution", Resolucion);
        }

        public void setMinimizer(int minimizer)
        {
            Registry.SetValue(this.rutaWebzen, "Minimizer", minimizer);
        }

        public void setSonido(int Sonido) 
        {
            Registry.SetValue(this.rutaWebzen, "SoundOnOff", Sonido);
        }

        public void setMusica(int Musica) 
        {
            Registry.SetValue(this.rutaWebzen, "MusicOnOff", Musica);
        }

        public void setSlider(int Slider) 
        {
            Registry.SetValue(this.rutaWebzen, "SliderOnOff", Slider);
        }
    }
}
