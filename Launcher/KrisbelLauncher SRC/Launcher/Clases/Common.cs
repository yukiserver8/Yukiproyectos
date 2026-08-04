using Cyclic.Redundancy.Check;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace Launcher.Clases
{
    class Common
    {
        public static void ChangeStatus(string Key, params string[] Arguments)
        {
            Globals.pForm.lbl_infoArchivos.Visible = true;
            Globals.pForm.lbl_infoArchivos.Text = Texts.GetText(Key, Arguments);
        }

        public static void UpdateCompleteProgress(long Value)
        {
            if (Value < 0 || Value > 100)
                return;

            int result = Convert.ToInt32(Value * Math.Round(1.88, 0));
            Globals.pForm.panel_completeProgress.Width = result - 40;
            Globals.pForm.completeProgressText.Text = Texts.GetText("COMPLETEPROGRESS", Value);
            if (Value == 100)
            {
                Globals.pForm.panel_completeProgress.Width = 188;
                Globals.pForm.lbl_infoArchivos.Visible = false;
            }
        }

        public static void UpdateCurrentProgress(long Value, double Speed)
        {
            if (Value < 0 || Value > 100)
                return;

            //Globals.pForm.currentProgress.Value = Convert.ToInt32(Value);
            //Globals.pForm.currentProgressText.Text = Texts.GetText("CURRENTPROGRESS", Value, Speed.ToString("0.00"));
        }

        public static string GetHash(string Name)
        {
            if (Name == string.Empty)
                return string.Empty;

            CRC crc = new CRC();

            string Hash = string.Empty;

            using (FileStream fileStream = File.Open(Name, FileMode.Open))
            {
                foreach (byte b in crc.ComputeHash(fileStream))
                {
                    Hash += b.ToString("x2").ToLower();
                }
            }

            return Hash;
        }

        public static void EnableStart()
        {
            //Globals.pForm.lbl_BtnEntrar.Enabled = true;
            //Globals.pForm.lbl_BtnEntrar.Cursor = Cursors.Hand;
        }

        public static void StartGame() 
        {
            string Argumentos = "connect/u" + Globals.IpServidor + " /p" + Globals.PortServidor;
            ProcessStartInfo Main = new ProcessStartInfo();
            Main.FileName = Globals.BinaryName;
            Main.UseShellExecute = true;
            Main.Arguments = Argumentos;
            Process p = Process.Start(Main);
            Application.Exit();
        }

        public static bool IsGameRunning()
        {
            return Process.GetProcessesByName(Globals.BinaryName).FirstOrDefault(p => p.MainModule.FileName.StartsWith("")) != default(Process);
        }
    }
}
