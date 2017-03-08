using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace MathsQuestionGenerator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static bool forceOfflineMode = false;
        static bool easterEgg = false;
        static bool developerMode = false;
        public static bool updateAvailible = false;

        [STAThread]
        static void Main(string[] args)
        {
            if (File.Exists("launchParams.cfg"))
                args = File.ReadAllLines("launchParams.cfg");

            for (int i = 0; i < args.Length; i++)
            { 
                if (args[i].Equals("-offline") || args[i].Equals("--offline") || args[i].Equals("-o") || args[i].Equals("--o"))
                    forceOfflineMode = true;
                if (args[i].Equals("-lord") || args[i].Equals("--lord"))
                    easterEgg = true;
                if (args[i].Equals("-developer") || args[i].Equals("--developer") || args[i].Equals("-d") || args[i].Equals("--d"))
                    developerMode = true;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainBoard());
        }

        public static bool isOfflineMode()
        {
            return forceOfflineMode;
        }

        public static bool isEasterEgg()
        {
            return easterEgg;
        }

        public static bool isDevMode()
        {
            return developerMode;
        }
    }
}
