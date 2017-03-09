﻿using System;
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
            if (checkServerConnection())
                try
                {
                    File.Delete("MQGUpdater.exe");
                    File.Delete("updater.pack");
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(new Uri("http://builds.mullak99.co.uk/MathsQuestionGenerator/updater/latest"), "updater.pack");
                    ZipFile.ExtractToDirectory("updater.pack", Directory.GetCurrentDirectory() + "..");
                    File.Delete("updater.pack");
                    if (doCleanUpdate)
                        Process.Start(Path.Combine("MQGUpdater.exe" + " -c"));
                    else
                        Process.Start("MQGUpdater.exe");
                    Environment.Exit(0);
                }
                catch (UnauthorizedAccessException)
                {
                    if (MessageBox.Show("The MQG Update application is still open.\nPlease close MQG Update.\n\nDo you want to retry?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        selfUpdate();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "Error");
                    File.Delete("MQGUpdate.exe");
                    File.Delete("updater.pack");
                }
            else
            {
                File.Delete("updater.pack");
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
    }
}
