using System.Collections.Generic;

namespace Launcher.Clases
{
    class Globals
    {
        public static string ServerURL;
        public static string PatchlistName = "ArchiveList.txt";
        public static string BinaryName;
        public static string IpServidor;
        public static string PortServidor;

        public static Form1 pForm;
        public static Configuraciones pConfigs;

        public static List<File> Files = new List<File>();
        public static List<string> OldFiles = new List<string>();

        public static long fullSize;
        public static long completeSize;

        public struct File
        {
            public string Name;
            public string Hash;
            public long Size;
        }
    }
}
