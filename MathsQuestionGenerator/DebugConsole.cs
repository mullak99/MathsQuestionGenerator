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

        public DebugConsole()
        {
            InitializeComponent();
        }

        public void AppendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength; //Begins the text selection at the end of the textbox.
            box.SelectionLength = 0;
            box.SelectionColor = color; //Sets the colour of the selection to 'color'.
            box.AppendText(text); //Appends the 'text' to the textbox.
            box.SelectionColor = box.ForeColor; //Resets the colour of the selection.
            scroll(); //Scrolls to the bottom of the textbox.
        }

        public void writeToConsole(string text, int logLevel = 0)
        {
            if (logLevel == 2)
            {
                AppendText(console, "[" + DateTime.Now.ToString("hh:mm:ss tt") + "] [ERROR] " + text + Environment.NewLine, Color.Red); //Appends the 'text' text to the textbox after the time and '[ERROR]', while using Red text.
                if (MessageBox.Show(text + "\n\nDo you want to save a log file?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes) //Shows a messagebox asking if the user wants to save a log file
                {
                    saveLogFile(); //Pressing 'Yes' will save a log file into the directory of the application.
                }
            }
            else if (logLevel == 1)
            {
                AppendText(console, "[" + DateTime.Now.ToString("hh:mm:ss tt") + "] [WARN] " + text + Environment.NewLine, Color.Orange); //Appends the 'text' text to the textbox after the time and '[WARN]', while using Orange text.
            }
            else if (logWrites)
            {
                AppendText(console, "[" + DateTime.Now.ToString("hh:mm:ss tt") + "] " + text + Environment.NewLine, Color.Green); //Appends the 'text' text to the textbox after the time, while using Green text.
            }
        }

        public void onlyWriteImportant(bool enabled)
        {
            logWrites = !enabled;
        }
        
        private void saveLogFile() //Saves all text within the textbox to a file, named with the date and time.
        {
            File.WriteAllText(DateTime.Today.ToString("dd-MM-yy") + "-" + DateTime.Now.ToString("hh-mm-ss") + "-" + DateTime.Now.ToString("tt") + "-MQG-v" + Application.ProductVersion + ".log", console.Text);
        }

        public void scroll()
        {
            console.SelectionStart = console.TextLength; //Moves the selection to the end of the textbox.
            console.ScrollToCaret(); //Scrolls to the selection.
        }

        protected override void OnFormClosing(FormClosingEventArgs e) //Overrides the Windows ('X') to hide the form instead of disposing it.
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            e.Cancel = true;
            Hide();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Hide(); //Hides the form.
        }

        private void saveLog_Click(object sender, EventArgs e)
        {
            saveLogFile(); //Manually saves a log file.
        }

        private void scrollOnVisible(object sender, EventArgs e)
        {
            scroll(); //Scrolls to the bottom of the textbox.
        }
    }
}