using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathsQuestionGenerator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        static bool forceOfflineMode = false;
        static bool easterEgg = false;
        static bool developerMode = false;


        [STAThread]
        static void Main(string[] args)
        {

            for (int i = 0; i < args.Length; i++)
            { 
                if (args[i].Equals("-offlineMode") || args[i].Equals("-offline") || args[i].Equals("-oM") || args[i].Equals("--offlineMode") || args[i].Equals("--offline") || args[i].Equals("--oM"))
                    forceOfflineMode = true;
                if (args[i].Equals("-lord") || args[i].Equals("--lord"))
                    easterEgg = true;
                if (args[i].Equals("-developerMode") || args[i].Equals("--developerMode") || args[i].Equals("-dev") || args[i].Equals("--dev"))
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
