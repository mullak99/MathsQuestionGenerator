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

namespace MathsQuestionGenerator
{
    public partial class AboutPage : Form
    {
        public AboutPage()
        {
            InitializeComponent();
            versionLabel.Text = "v" + Application.ProductVersion; //Sets version label to the version defined in the Assembly information.
        }

        private void logoMQM_Click(object sender, EventArgs e) //Opens the Github link once the logo is clicked.
        {
            Process.Start("http://github.com/mullak99/MathsQuestionGenerator");
        }

        private void githubLink_Click(object sender, EventArgs e) //Executes logoMQM_Click once the label is clicked.
        {
            logoMQM_Click(sender, e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e) //Overrides the Windows ('X') to hide the form instead of disposing it.
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            e.Cancel = true;
            Hide();
        }
    }
}
