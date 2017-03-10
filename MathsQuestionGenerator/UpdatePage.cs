using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Security.Principal;

namespace MathsQuestionGenerator
{
    public partial class UpdatePage : Form
    {
        bool updateIgnored = false;
        bool fakeVersionToggle = false;
        bool fakeServerError = false;
        bool isOnline = true;
        string fakeVersion = "";

        public UpdatePage()
        {
            InitializeComponent();
        }
        //Used to spoof the version of the application, can be used to test the various descriptions given on the Update Form.
        public void spoofVersion(string version, bool toggle)
        {
            fakeVersionToggle = toggle;
            fakeVersion = version;
        }
        //Used to spoof a server error (unable to get the version from the build server).
        public void spoofServerError(bool toggle)
        {
            fakeServerError = toggle;
        }
        //Used to check for application updates from the build server.
        public void checkForUpdate()
        {
            currentVer.Text = getVersionInfo();
            latestVer.Text = "v" + getLatestVersion();

            if (detailedUpdateInfo() == "LATESTVERSION")
            {
                briefDesc.Text = "You are using the latest version of MQG.";
                isOnline = true;
                downloadUpdate.Visible = false;
            }
            else if (detailedUpdateInfo() == "OFFLINEMODE")
            {
                briefDesc.Text = "You have launched MQG in offline mode. MQG will not attempt to connect to the internet in any way.";
                latestVer.Text = "OFFLINE MODE!";
                isOnline = false;
                downloadUpdate.Visible = false;
            }
            else if (detailedUpdateInfo() == "APPNEWER")
            {
                briefDesc.Text = "You are using a version of MQG that is newer than the public version. This may be due to you using a developer version, a beta or a pre-release version.";
                isOnline = true;
                downloadUpdate.Visible = false;
            }
            else if (detailedUpdateInfo() == "SERVERERROR")
            {
                briefDesc.Text = "Unable to connect to the update server. Please check your internet connection or try again later.";
                latestVer.Text = "SERVER ERROR!";
                isOnline = false;
                downloadUpdate.Visible = false;
            }
            else
            {
                briefDesc.Text = "You are using an out-of-date version of MQG.\nIt is recommended that you update to ensure you have the latest features and bugfixes.";
                isOnline = true;
                downloadUpdate.Visible = true;

                if(!updateIgnored)
                {
                    if (MessageBox.Show("A new version is availible!\n\nDo you want to update to '" + latestVer.Text + "'?", "Update", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        downloadUpdate_Click(null, null);
                    else
                        updateIgnored = true;
                }
            }
        }
        //Perform a simple online check
        public bool checkIfOnline()
        {
            checkForUpdate();
            return isOnline;
        }
        //Overrides the Windows ('X') to hide the form instead of disposing it.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            e.Cancel = true;
            Hide();
        }
        //Checks if the application is a debug build.
        private bool isDebugBuild()
        {
            if (!fakeVersionToggle)
                return this.GetType().Assembly.GetCustomAttributes(false).OfType<DebuggableAttribute>().Select(da => da.IsJITTrackingEnabled).FirstOrDefault();
            else
                return false;
        }
        //Finds the file version.
        public string getVersionInfo(bool raw = false)
        {
            if (!fakeVersionToggle)
            {
                if (!raw)
                {
                    if (isDebugBuild())
                        return "v" + Application.ProductVersion + " BETA";
                    else
                        return "v" + Application.ProductVersion;
                }
                else
                    return Application.ProductVersion;
            }
            else
            {
                if (!raw)
                {
                    if (isDebugBuild())
                        return "v" + fakeVersion + " BETA";
                    else
                        return "v" + fakeVersion;
                }
                else
                    return fakeVersion;
            }
        }
        //Converts a string to an int array.
        private int[] ToIntArray(string value, char separator)
        {
            return Array.ConvertAll(value.Split(separator), s => int.Parse(s));
        }
        //Gets the latest version information from the build server.
        public string getLatestVersion()
        {
            if (Program.isOfflineMode())
                return "-1.-1.-1.-1";
            else
            {
                try
                {
                    WebClient client = new WebClient();

                    string url = "http://builds.mullak99.co.uk/MathsQuestionGenerator/checkupdate.php";

                    byte[] html = client.DownloadData(url);
                    UTF8Encoding utf = new UTF8Encoding();
                    if (String.IsNullOrEmpty(utf.GetString(html)) || fakeServerError)
                        return "0.0.0.0";
                    else
                        return utf.GetString(html);
                }
                catch (Exception e)
                {
                    return "0.0.0.0";
                }
            }
            
            
        }
        //Used to compare the application version and the latest version from the build server.
        public bool isUpdateAvailable()
        {
            int[] latestServerVer = ToIntArray(getLatestVersion(), '.');
            int[] currentAppVer = ToIntArray(getVersionInfo(true), '.');

            if (getLatestVersion() == "0.0.0.0" || getLatestVersion() == "-1.-1.-1.-1")
                return false;
            else if (latestServerVer[0] > currentAppVer[0])
                return true;
            else if (latestServerVer[1] > currentAppVer[1] && latestServerVer[0] == currentAppVer[0])
                return true;
            else if (latestServerVer[2] > currentAppVer[2] && latestServerVer[1] == currentAppVer[1] && latestServerVer[0] == currentAppVer[0])
                return true;
            else if (latestServerVer[3] > currentAppVer[3] && latestServerVer[2] == currentAppVer[2] && latestServerVer[1] == currentAppVer[1] && latestServerVer[0] == currentAppVer[0])
                return true;
            else if (latestServerVer[0] == currentAppVer[0] && latestServerVer[1] == currentAppVer[1] && latestServerVer[2] == currentAppVer[2] && latestServerVer[3] == currentAppVer[3] && isDebugBuild())
                return true;
            else
                return false;
        }
        //Used to determine if the application version is newer than the 'latest' version on the build server.
        public bool isAppNewer()
        {
            int[] latestServerVer = ToIntArray(getLatestVersion(), '.');
            int[] currentAppVer = ToIntArray(getVersionInfo(true), '.');

            if (latestServerVer[0] < currentAppVer[0])
                return true;
            else if (latestServerVer[1] < currentAppVer[1] && latestServerVer[0] == currentAppVer[0])
                return true;
            else if (latestServerVer[2] < currentAppVer[2] && latestServerVer[1] == currentAppVer[1] && latestServerVer[0] == currentAppVer[0])
                return true;
            else if (latestServerVer[3] < currentAppVer[3] && latestServerVer[2] == currentAppVer[2] && latestServerVer[1] == currentAppVer[1] && latestServerVer[0] == currentAppVer[0])
                return true;
            else if (latestServerVer[0] == currentAppVer[0] && latestServerVer[1] == currentAppVer[1] && latestServerVer[2] == currentAppVer[2] && latestServerVer[3] == currentAppVer[3] && isDebugBuild())
                return false;
            else
                return false;
        }
        //Used to provide a more detailed report on the versions.
        public string detailedUpdateInfo()
        {
            if (isUpdateAvailable())
                return getLatestVersion();
            else if (getLatestVersion() == "0.0.0.0")
                return "SERVERERROR";
            else if (getLatestVersion() == "-1.-1.-1.-1")
                return "OFFLINEMODE";
            else if (isAppNewer())
                return "APPNEWER";
            else
                return "LATESTVERSION";
        }
        //Manually checks for an update with a button press.
        private void updateCheck_Click(object sender, EventArgs e)
        {
            checkForUpdate();
        }
        public static void selfUpdate(bool doCleanUpdate = false)
        {
            TextReader tr = new StreamReader(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"mullak99\Maths Question Generator\Config\installProperties.cfg"));
            string installDir = tr.ReadLine();
            tr.Close();

            if (checkServerConnection())
                try
                {
                    File.Delete(Path.Combine(installDir, "MQGUpdater.exe"));
                    File.Delete(Path.Combine(installDir, "updater.pack"));
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(new Uri("http://builds.mullak99.co.uk/MathsQuestionGenerator/updater/latest"), Path.Combine(installDir, "updater.pack"));
                    ZipFile.ExtractToDirectory(Path.Combine(installDir, "updater.pack"), Directory.GetCurrentDirectory() + "..");
                    File.Delete(Path.Combine(installDir, "updater.pack"));
                    if (doCleanUpdate)
                    {
                        Process p = new Process();
                        p.StartInfo.FileName = Path.Combine(installDir, "MQGUpdater.exe");
                        p.StartInfo.Arguments = "-c";
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.CreateNoWindow = true;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.Verb = "runas";
                        p.Start();
                    }
                    else
                        Process.Start(Path.Combine(installDir, "MQGUpdater.exe"));
                    Environment.Exit(0);
                }
                catch (UnauthorizedAccessException)
                {
                    if (MessageBox.Show("You are not running MQG as an admin, by doing this you cannot update the application in admin protected directories.\n\nDo you want to launch as admin?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        runAsAdmin();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "Error");
                    if (File.Exists(Path.Combine(installDir, "MQGUpdater.exe")))
                        File.Delete(Path.Combine(installDir, "MQGUpdater.exe"));
                    if (File.Exists(Path.Combine(installDir, "updater.pack")))
                        File.Delete(Path.Combine(installDir, "updater.pack"));
                }
            else
            {
                File.Delete(Path.Combine(installDir, "updater.pack"));
            }
        }

        public static bool checkServerConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://mullak99.co.uk/"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
        //Download the latest version from the build server.
        private void downloadUpdate_Click(object sender, EventArgs e)
        {
            selfUpdate(Program.doCleanUpdates());
        }

        internal static bool IsRunAsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private static void runAsAdmin()
        {
            if (!IsRunAsAdmin())
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = Environment.CurrentDirectory;
                proc.FileName = Application.ExecutablePath;
                proc.Verb = "runas";

                try
                {
                    Process.Start(proc);
                }
                catch
                {
                    return;
                }

                Environment.Exit(0);
            }
        }
    }
}
