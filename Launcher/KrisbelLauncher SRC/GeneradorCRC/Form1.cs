using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using KittySoft;

namespace GeneradorCRC
{
    public partial class Form1 : Form
    {
        string[] Files;

        public Form1()
        {
            InitializeComponent();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Files = GetFiles(e.Argument);

            for (int i = 0; i < Files.Length; i++)
            {
                backgroundWorker.ReportProgress(i + 1, GetFileData(Files[i]));
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            actualizaResultado(e.UserState);

            actualizaProgreso(ComputeProgress(e.ProgressPercentage));
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EnableButtons();
        }

        private void DisableButtons()
        {
            progressBar1.Value = 0;
            txt_lista.Clear();
            btn_guardar.Enabled = false;
            btn_seleccionar.Enabled = false;
        }

        private void EnableButtons()
        {
            btn_guardar.Enabled = true;
            btn_seleccionar.Enabled = true;
        }

        public string[] GetFiles(object Path)
        {
            return Directory.GetFiles(Path.ToString(), "*.*", System.IO.SearchOption.AllDirectories);
        }

        public int GetFilesCount(string[] Files)
        {
            return Files.Length;
        }

        public string GetFileData(string File)
        {

            FileInfo fileInfo = new FileInfo(File);
            int rutaLength = folderBrowserDialog.SelectedPath.Length + 1;
            string archivos = File.Remove(0, rutaLength);

            return archivos + " " + GetHash(File) + " " + fileInfo.Length;
        }

        private string GetHash(string Name)
        {
            if (Name == string.Empty)
                return null;

            CRC32 crc = new CRC32();

            string Hash = string.Empty;

            try
            {
                using (FileStream fileStream = File.Open(Name, FileMode.Open))
                {
                    foreach (byte b in crc.ComputeHash(fileStream))
                    {
                        Hash += b.ToString("x2").ToLower();
                    }
                }
            }
            catch
            {
                MessageBox.Show("No se puede abrir: " + Name);
            }

            return Hash;
        }

        private void actualizaResultado(object Data)
        {
            if (!txt_lista.IsDisposed)
            {
                txt_lista.AppendText(Data.ToString().Replace(@"\", "/") + Environment.NewLine);
            }
        }

        private int ComputeProgress(int Percent)
        {
            return (100 * Percent) / Files.Length;
        }

        private void actualizaProgreso(int Percent)
        {
            if (Percent < 0 || Percent > 100)
                return;

            if (!progressBar1.IsDisposed)
            {
                progressBar1.Value = Percent;
            }
        }

        //METODO ENCARGADO DE ABRIR OBTENER LA UBUCAION DE LOS ARCHIVOS
        private void buscarArchivos()
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                DisableButtons();
                txt_directorio.Text = folderBrowserDialog.SelectedPath.Replace(@"\", "/");

                if (!backgroundWorker.IsBusy)
                {
                    backgroundWorker.RunWorkerAsync(folderBrowserDialog.SelectedPath);
                }
            }
        }

        //METODO ENCARGADO DE GUARDAR LA LISTA CRC
        private void guardarLista()
        {
            saveFileDialog.FileName = "ArchiveList.txt";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|Every file (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
                {
                    streamWriter.Write(txt_lista.Text);
                }
            }
        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            this.buscarArchivos();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            this.guardarLista();
        }
    }
}
