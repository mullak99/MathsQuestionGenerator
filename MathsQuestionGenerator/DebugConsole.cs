using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathsQuestionGenerator
{
    public partial class DebugConsole : Form
    {
        private bool logWrites = true;
        private bool loggedDevMode = false;
        private string devModeMessage = "Program has been launched with Developer Mode!";

        public DebugConsole()
        {
            InitializeComponent();
        }

        public void AppendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength; //Begins the text selection at the end of the textbox.
            box.SelectionLength = 0; //No selection length, just move the cursor.
            box.SelectionColor = color; //Sets the colour of the selection to 'color'.
            box.AppendText(text); //Appends the 'text' to the textbox.
            box.SelectionColor = box.ForeColor; //Resets the colour of the selection.
            scroll(); //Scrolls to the bottom of the textbox.
        }
        //Writes the text string to the developer/debugging console, along with the appropriate colour and prefix depending on log level.
        public void writeToConsole(string text, int logLevel = 0)
        {
            if (text != devModeMessage || !loggedDevMode)
                if (logLevel >= 3) //Error log level. Used for crashes or other extreme issues.
                {
                    AppendText(console, "[" + DateTime.Now.ToString("hh:mm:ss tt") + "] [ERROR] " + text + Environment.NewLine, Color.Red); //Appends the 'text' text to the textbox after the time and '[ERROR]', while using Red text.
                    if (MessageBox.Show(text + "\n\nDo you want to save a log file?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes) //Shows a messagebox asking if the user wants to save a log file
                    {
                        saveLogFile(); //Pressing 'Yes' will save a log file into the directory of the application.
                    }
                }
                else if (logLevel == 2) //Warning log level. Used for anything that could cause instabilities within normal operation.
                    AppendText(console, "[" + DateTime.Now.ToString("hh:mm:ss tt") + "] [WARN] " + text + Environment.NewLine, Color.Orange); //Appends the 'text' text to the textbox after the time and '[WARN]', while using Orange text.
                else if (logWrites && logLevel == 1) //Cheat log level. Used when a developer-only 'cheat' is executed
                    AppendText(console, "[" + DateTime.Now.ToString("hh:mm:ss tt") + "] [DEV] " + text + Environment.NewLine, Color.DarkViolet); //Appends the 'text' text to the textbox after the time and '[DEV]', while using Violet text.
                else if (logWrites) //Default log level. Used to detail what is happening within the code.
                    AppendText(console, "[" + DateTime.Now.ToString("hh:mm:ss tt") + "] " + text + Environment.NewLine, Color.Green); //Appends the 'text' text to the textbox after the time, while using Green text.
            
            if (text == devModeMessage)
                loggedDevMode = true;
        }
        //Ensures that only logs with level 1 or greater are written to the console.
        public void onlyWriteImportant(bool enabled)
        {
            logWrites = !enabled;
        }
        //Saves all text within the textbox to a file, named with the date and time.
        public void saveLogFile() 
        {
            string logLocation = "";

            if (Program.isFullInstall())
                logLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "mullak99", "Maths Question Generator", "Logs");
            else
                logLocation = "Logs";

            if (!Directory.Exists(logLocation)) Directory.CreateDirectory(logLocation);

            string logFileName = Path.Combine(logLocation, (DateTime.Today.ToString("dd-MM-yy") + "-" + DateTime.Now.ToString("hh-mm-ss") + "-" + DateTime.Now.ToString("tt") + "-MQG-v" + Application.ProductVersion + ".log"));
            File.WriteAllText(logFileName, console.Text);

            writeToConsole("Exported Log: " + logFileName, 1);

        }
        //Moves the selection to the end of the textbox and scrolls to the selection.
        public void scroll()
        {
            console.SelectionStart = console.TextLength; 
            console.ScrollToCaret();
        }
        //Overrides the Windows ('X') to hide the form instead of disposing it.
        protected override void OnFormClosing(FormClosingEventArgs e) 
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            e.Cancel = true;
            Hide();
        }
        //Clears the textbox.
        private void clearButton_Click(object sender, EventArgs e)
        {
            console.Text = "";
            loggedDevMode = false;
        }
        //Manually saves a log file.
        private void saveLog_Click(object sender, EventArgs e)
        {
            saveLogFile(); 
        }
    }
}