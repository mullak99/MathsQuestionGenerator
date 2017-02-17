using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Net;

namespace MathsQuestionGenerator
{
    public partial class AboutPage : Form
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        //Opens the Github link once the logo is clicked.
        private void logoMQG_Click(object sender, EventArgs e) 
        {
            Process.Start("http://github.com/mullak99/MathsQuestionGenerator");
        }
        //Executes logoMQM_Click once the label is clicked.
        private void githubLink_Click(object sender, EventArgs e)
        {
            logoMQG_Click(sender, e);
        }
        //Overrides the Windows ('X') to hide the form instead of disposing it.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            e.Cancel = true;
            Hide();
        }
    }
}
