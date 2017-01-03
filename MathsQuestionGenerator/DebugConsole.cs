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

        public DebugConsole()
        {
            InitializeComponent();
            console.VisibleChanged += new EventHandler(scrollOnVisible);
        }

        public void AppendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;

            scroll();
        }

        public void writeToConsole(string text, int logLevel = 0)
        {
            if (logLevel == 2)
            {
                AppendText(console, "[" + DateTime.Now.ToString("hh:mm:ss tt") + "] [ERROR] " + text + Environment.NewLine, Color.Red);
                if (MessageBox.Show(text + "\n\nDo you want to save a log file?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saveLogFile();
                }
            }
            else if (logLevel == 1)
            {
                AppendText(console, "[" + DateTime.Now.ToString("hh:mm:ss tt") + "] [WARN] " + text + Environment.NewLine, Color.Orange);
            }
            else
            {
                AppendText(console, "[" + DateTime.Now.ToString("hh:mm:ss tt") + "] " + text + Environment.NewLine, Color.Green);
            }
                
        }
        
        private void saveLogFile()
        {
            File.WriteAllText(DateTime.Today.ToString("dd-MM-yy") + "-" + DateTime.Now.ToString("hh-mm-ss") + "-" + DateTime.Now.ToString("tt") + "-MQG-v" + Application.ProductVersion + ".log", console.Text);
        }

        public void scroll()
        {
            console.SelectionStart = console.TextLength;
            console.ScrollToCaret();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            e.Cancel = true;
            Hide();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void saveLog_Click(object sender, EventArgs e)
        {
            saveLogFile();
        }

        private void scrollOnVisible(object sender, EventArgs e)
        {
            scroll();
        }


    }
}
