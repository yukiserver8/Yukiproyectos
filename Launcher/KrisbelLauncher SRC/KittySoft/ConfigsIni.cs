using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittySoft
{
    public class ConfigsIni
    {
        //ATRIBUTOS
        public string UrlMu;


        //METODOS
        public ConfigsIni(string Archivo = null)
        {
            LeerInis leerini = new LeerInis(Archivo);
            this.UrlMu = leerini.Read("WebLauncherKS", "Webs");
        }

    }
}
