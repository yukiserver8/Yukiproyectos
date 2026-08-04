using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Launcher.Clases
{
    class Starter
    {
        public static void Start()
        {
            if (!File.Exists(Globals.BinaryName))
            {
                MessageBox.Show(Texts.GetText("MISSINGBINARY", Globals.BinaryName));

                return;
            }

            try
            {

                Process startProcess = new Process();
                startProcess.StartInfo.FileName = Globals.BinaryName;
                startProcess.StartInfo.UseShellExecute = false;
                startProcess.Start();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Texts.GetText("UNKNOWNERROR", exception.Message));
                Application.Exit();
            }
        }
    }
}
