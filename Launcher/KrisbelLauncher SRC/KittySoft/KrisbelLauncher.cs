using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using System.Net;
using Microsoft.VisualBasic.FileIO;
using System.Security.Cryptography;

namespace KittySoft
{
    public class KrisbelLauncher
    {
        //Atributos
        private string ArchiveName;
        private string LinkArchive;
        private string tmpdir = Microsoft.VisualBasic.FileIO.SpecialDirectories.Temp + @"\KSTMP";
        private Computer MyProject;
        private LeerInis inis;

        //Atributos que devuelben datos
        /*
         # Seccion General
         */
        public string LinkFacebookKS;
        public string TipoFilesKS;
        public string NombreServidorKS;
        public string NameMainKS;
        public string IpServidorKS;
        public string PortServerKS;
        /*
         # Seccion de Noticias
         */
        public string NoticiasActiveKS;
        public string NumNoticiasKS;
        public string LocalidadNoticiasKS;
        /*----------------------------------*/
        public string Noticia1;
        public string Noticia2;
        public string Noticia3;
        public string Noticia4;
        public string Noticia5;
        public string Noticia6;
        public string Noticia7;
        public string Noticia8;
        public string Noticia9;
        public string Noticia10;
 
        public KrisbelLauncher(string link)
        {
            this.ArchiveName = "KrisbelLauncher.ini";
            this.LinkArchive = link;
            this.MyProject = new Computer();

            //Instanciamos el metodo de descarga
            this.downloadArchive(this.LinkArchive, this.ArchiveName);
        }
        public KrisbelLauncher()
        {

        }

        //METODO ENCARGADO DE DESCARGAR UN ARCHIVO TEMPORAR LEERLO Y BORRARLO
        protected void downloadArchive(string Link, string Archive) 
        {
            try
            {
                if (this.MyProject.FileSystem.DirectoryExists(this.tmpdir))
                    this.MyProject.FileSystem.DeleteDirectory(this.tmpdir, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently, UICancelOption.DoNothing);
                this.MyProject.FileSystem.CreateDirectory(this.tmpdir);
                this.MyProject.Network.DownloadFile(this.LinkArchive + "Launcher/" + Archive, this.tmpdir + @"\KrisbelLauncher.ini", "", "", false, 10000, true);
                this.inis = new LeerInis(this.tmpdir + @"\KrisbelLauncher.ini");
                this.general();
                this.noticias();
            }
            finally
            {
                if (this.MyProject.FileSystem.DirectoryExists(this.tmpdir))
                    this.MyProject.FileSystem.DeleteDirectory(this.tmpdir, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently, UICancelOption.DoNothing);
            }
        }

        //METODO ENCARGADO DE OBTENER LOS DATOS EN GENERAL
        protected void general() 
        {
            try
            {
                bool flag = this.MyProject.FileSystem.DirectoryExists(this.tmpdir);
                if (flag)
                {
                    //Asignamos los datos a los atributos correspondientes
                    this.LinkFacebookKS = this.inis.Read("LinkFacebook", "GENERAL");
                    this.TipoFilesKS = this.inis.Read("TipoFiles", "GENERAL");
                    this.NombreServidorKS = this.inis.Read("NombreServidor", "GENERAL");
                    this.IpServidorKS = this.getCadena(this.inis.Read("IpServer", "GENERAL"));
                    this.PortServerKS = this.getCadena(this.inis.Read("PortServer", "GENERAL"));
                    this.NameMainKS = this.inis.Read("NameMain","GENERAL");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //METODO ENCARGADO DE OBTENER LAS NOTICIAS
        protected void noticias() 
        {
            try
            {
                bool flag = this.MyProject.FileSystem.DirectoryExists(this.tmpdir);
                if (flag)
                {
                    //Asignamos los datos a los atributos correspondientes
                    this.NoticiasActiveKS = this.inis.Read("Active/OnOff", "NOTICIAS");
                    this.NumNoticiasKS = this.inis.Read("NumNoticias", "NOTICIAS");
                    this.LocalidadNoticiasKS = this.inis.Read("LocalidadNoticias", "NOTICIAS");
                    this.Noticia1 = this.inis.Read("Noticia01", "NOTICIAS");
                    this.Noticia2 = this.inis.Read("Noticia02", "NOTICIAS");
                    this.Noticia3 = this.inis.Read("Noticia03", "NOTICIAS");
                    this.Noticia4 = this.inis.Read("Noticia04", "NOTICIAS");
                    this.Noticia5 = this.inis.Read("Noticia05", "NOTICIAS");
                    this.Noticia6 = this.inis.Read("Noticia06", "NOTICIAS");
                    this.Noticia7 = this.inis.Read("Noticia07", "NOTICIAS");
                    this.Noticia8 = this.inis.Read("Noticia08", "NOTICIAS");
                    this.Noticia9 = this.inis.Read("Noticia09", "NOTICIAS");
                    this.Noticia10 = this.inis.Read("Noticia10", "NOTICIAS");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //METODOS ENCARGADO DE CREAR LA INSTANCIA PARA DESENCRIPTAR
        private static RijndaelManaged getInstance(string pKey)
        {
            RijndaelManaged Provider = new RijndaelManaged();
            byte[] salt = Encoding.ASCII.GetBytes(pKey);
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(pKey, salt);
            //Inicializamos el proveedor
            Provider.Key = key.GetBytes(Provider.KeySize / 8);
            Provider.IV = key.GetBytes(Provider.BlockSize / 8);

            //Devuelve el proveedor
            return Provider;
        }

        //METODO ENCARGADO DE DESENCRIPTAR
        public static string Decrypt(string pString, string pKey)
        {
            if (string.IsNullOrEmpty(pString)) return "";
            try
            {
                byte[] arrBytBuffer = Convert.FromBase64String(pString);
                RijndaelManaged Provider = getInstance(pKey);
                ICryptoTransform Crypto = Provider.CreateDecryptor();

                //Devuelve el array de bytes encriptado
                return Encoding.Unicode.GetString(Crypto.TransformFinalBlock(arrBytBuffer, 0, arrBytBuffer.Length));
            }
            catch (Exception ex)
            {
                Directory.CreateDirectory(@"C:\Logs");
                File.AppendAllText(@"C:\Logs\DebugLauncher.txt", 
                    string.Format("[{0}] ERROR: {1} | Clave: {2} | String: {3}\r\n", DateTime.Now, ex.Message, pKey, pString));
                throw;
            }
        }

        //METODO ENCARGADO DE ENCRIPTAR UNA CADENA
        public static byte[] Encrypt(string pString, string pKey)
        {
            RijndaelManaged Provider = getInstance(pKey);
            ICryptoTransform Crypto = Provider.CreateEncryptor();
            byte[] BytBuffer = Encoding.Unicode.GetBytes(pString);

            //Devuelve el array de bytes encriptado
            return Crypto.TransformFinalBlock(BytBuffer, 0, BytBuffer.Length);
        }

        //METODO ENCARGADO DE ENCRIPTAR EN BASE 64
        public static string encrypToBase64(string pString, string pKey)
        {
            return Convert.ToBase64String(Encrypt(pString, pKey));
        }

        //METODO ENCARGADO DE OBTENER Y DESENCRIPTAR CADENAS
        public string getCadena(string pCadena) 
        {
            string cadena = Decrypt(pCadena, "tuservermu.com.ve");
            return cadena;
        }

        //METODO ENCARGADO DE ENCRIPTAR UN STRING
        public string setCadena(string pString) 
        {
            string cadena = encrypToBase64(pString, "tuservermu.com.ve");
            return cadena;
        }
    }
}
