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

namespace KrisbelLauncherConfigs
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_encriptar_Click(object sender, EventArgs e)
        {
            //encriptamos la ip y el puerto
            KrisbelLauncher KS = new KrisbelLauncher();
            txt_ipServidor.Text = KS.setCadena(txt_ipServidor.Text.Trim());
            txt_puertoServidor.Text = KS.setCadena(txt_puertoServidor.Text.Trim());
            MessageBox.Show("Datos encriptados con exito...");
        }
    }
}
