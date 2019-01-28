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
        static bool cleanUpdates = false;
        static bool fullInstall = false;
        static bool onlyUseLegacyConfig = false;
        static bool legacyConfigPersistance = false;
        static bool didLoadFile = false;
        public static XmlSettings xmlSettings;

        [STAThread]
        static void Main(string[] args)
        {
            List<String> arguments = new List<String>();
            arguments.AddRange(args);

            try
            {
                if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"mullak99\Maths Question Generator\Config\launchParams.cfg")))
                    arguments.AddRange(readLaunchParams());
                if (File.Exists(@"Config\launchParams.cfg"))
                    arguments.AddRange(readLaunchParams(true));
            }
            catch (Exception) { }

            string[] lParams = arguments.ToArray();

            if (!onlyUseLegacyConfig && didLoadFile && !(File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "mullak99", "Maths Question Generator", "Config", "MQG.cfg")) || File.Exists(Path.Combine("Config", "MQG.cfg"))))
            {
                setOptionsLegacy(lParams);
                setOptions();
            }
            else
            {
                if (lParams.Length > 0 && didLoadFile)
                {
                    setOptionsLegacy(args);
                    didLoadFile = false;
                }

                if (onlyUseLegacyConfig && didLoadFile)
                {
                    setOptionsLegacy(args);
                }
                else if (!onlyUseLegacyConfig)
                {

                    setOptions();

                    loadOptions();

                    if (!legacyConfigPersistance)
                    {
                        try
                        {
                            if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"mullak99\Maths Question Generator\Config\launchParams.cfg")))
                                File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"mullak99\Maths Question Generator\Config\launchParams.cfg"));
                            if (File.Exists(@"Config\launchParams.cfg"))
                                File.Delete(@"Config\launchParams.cfg");
                        }
                        catch { }
                    }

                    for (int i = 0; i < args.Length; i++)
                    {
                        args[i].ToLower();
                        if (args[i].Equals("-offline") || args[i].Equals("--offline") || args[i].Equals("-o") || args[i].Equals("--o"))
                            forceOfflineMode = true;
                        if (args[i].Equals("-lord") || args[i].Equals("--lord"))
                            easterEgg = true;
                        if (args[i].Equals("-developer") || args[i].Equals("--developer") || args[i].Equals("-d") || args[i].Equals("--d"))
                            developerMode = true;
                        if (args[i].Equals("-cleanupdates") || args[i].Equals("--cleanupdates") || args[i].Equals("-c") || args[i].Equals("--c"))
                            cleanUpdates = true;
                        if (args[i].Equals("-update") || args[i].Equals("--update") || args[i].Equals("-u") || args[i].Equals("--u"))
                            UpdatePage.selfUpdate(cleanUpdates);
                        if (args[i].Equals("-fullinstall") || args[i].Equals("--fullinstall") || args[i].Equals("-f") || args[i].Equals("--f"))
                            fullInstall = true;
                    }
                }
            }

            

            if ((DateTime.Now.Month == 4) && (DateTime.Now.Day == 1))
            {
                easterEgg = true;
            }
            else if (!easterEgg)
            {
                purgeTemp();
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

        public static bool isFullInstall()
        {
            return fullInstall;
        }

        public static bool isDevMode()
        {
            return developerMode;
        }

        public static bool doCleanUpdates()
        {
            return cleanUpdates;
        }

        public static bool isLegacyMode()
        {
            return onlyUseLegacyConfig;
        }

        public static bool isLegacyConfigPersistant()
        {
            return legacyConfigPersistance;
        }

        public static void loadOptions()
        {
            fullInstall = xmlSettings.readBoolean("fullInstall");
            cleanUpdates = xmlSettings.readBoolean("cleanUpdates");
            developerMode = xmlSettings.readBoolean("developerMode");
            forceOfflineMode = xmlSettings.readBoolean("offlineMode");
            legacyConfigPersistance = xmlSettings.readBoolean("legacyConfigPersistance");
            easterEgg = xmlSettings.readBoolean("easterEgg");
        }

        public static void setOptions()
        {
            if (fullInstall)
            {
                if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "mullak99", "Maths Question Generator", "Config"))) Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "mullak99", "Maths Question Generator", "Config"));
                xmlSettings = new XmlSettings(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "mullak99", "Maths Question Generator", "Config", "MQG.cfg"), true, true, false, false, true, false, true, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "mullak99", "Maths Question Generator", "Config", "MQG-Config.log"));
            }
            else
            {
                if (!Directory.Exists("Config")) Directory.CreateDirectory("Config");
                xmlSettings = new XmlSettings(Path.Combine("Config", "MQG.cfg"), true, true, false, false, true, false, true, Path.Combine("Config", "MQG-Config.log"));
            }

            xmlSettings.addString("xmlCreationVersion", Application.ProductVersion);
            xmlSettings.addString("xmlCreationDate", DateTime.Today.ToString("dd/MM/yyyy") + " | " + DateTime.Now.ToString("hh:mm:ss") + " " + DateTime.Now.ToString("tt"));

            xmlSettings.addBoolean("fullInstall", fullInstall);
            xmlSettings.addBoolean("cleanUpdates", cleanUpdates);
            xmlSettings.addBoolean("developerMode", developerMode);
            xmlSettings.addBoolean("offlineMode", forceOfflineMode);
            xmlSettings.addBoolean("legacyConfigPersistance", legacyConfigPersistance);
            if (easterEgg) xmlSettings.addBoolean("easterEgg", easterEgg);

        }

        public static void setOptionsLegacy(string[] args)
        {
            
            List<String> arguments = new List<String>();
            arguments.AddRange(args);

            try
            {
                if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"mullak99\Maths Question Generator\Config\launchParams.cfg")))
                    arguments.AddRange(readLaunchParams());
                if (File.Exists(@"Config\launchParams.cfg"))
                    arguments.AddRange(readLaunchParams(true));
            }
            catch (Exception) { }

            string[] lParams = arguments.ToArray();

            for (int i = 0; i < lParams.Length; i++)
            {
                lParams[i].ToLower();
                if (lParams[i].Equals("-offline") || lParams[i].Equals("--offline") || lParams[i].Equals("-o") || lParams[i].Equals("--o"))
                    forceOfflineMode = true;
                if (lParams[i].Equals("-lord") || lParams[i].Equals("--lord"))
                    easterEgg = true;
                if (lParams[i].Equals("-developer") || lParams[i].Equals("--developer") || lParams[i].Equals("-d") || lParams[i].Equals("--d"))
                    developerMode = true;
                if (lParams[i].Equals("-cleanupdates") || lParams[i].Equals("--cleanupdates") || lParams[i].Equals("-c") || lParams[i].Equals("--c"))
                    cleanUpdates = true;
                if (lParams[i].Equals("-update") || lParams[i].Equals("--update") || lParams[i].Equals("-u") || lParams[i].Equals("--u"))
                    UpdatePage.selfUpdate(cleanUpdates);
                if (lParams[i].Equals("-fullinstall") || lParams[i].Equals("--fullinstall") || lParams[i].Equals("-f") || lParams[i].Equals("--f"))
                    fullInstall = true;
                if (lParams[i].Equals("-legacy") || lParams[i].Equals("--legacy") || lParams[i].Equals("-l") || lParams[i].Equals("--l"))
                    onlyUseLegacyConfig = true;
                if (lParams[i].Equals("-legacyconfigpersistance") || lParams[i].Equals("--legacyconfigpersistance") || lParams[i].Equals("-p") || lParams[i].Equals("--p"))
                    legacyConfigPersistance = true;
            }
        }

        [Obsolete("readLaunchParams is deprecated, use the MQG.cfg instead.")]
        public static string[] readLaunchParams(bool local = false)
        {
            didLoadFile = true;
            string dir;
            if (local)
                dir = Path.Combine(Directory.GetCurrentDirectory(), @"Config\launchParams.cfg");
            else
                dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"mullak99\Maths Question Generator\Config\launchParams.cfg");

            TextReader tr = new StreamReader(dir);
            string[] trOut = tr.ReadLine().Split(' ');
            tr.Close();
            return trOut;
        }

        public static void purgeTemp()
        {
            if (Directory.Exists(Path.Combine(Path.GetTempPath(), "mullak99", "MQG"))) Directory.Delete(Path.Combine(Path.GetTempPath(), "mullak99", "MQG"), true);
        }
    }
}
