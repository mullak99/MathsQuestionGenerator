﻿using System;
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
        //Changes the text to show the 'HowTo' information.
        private void howToButton_Click(object sender, EventArgs e)
        {
            helpText.Text =
                "How to use MQG:\n" +
                "1) Choose your desired difficulty on the main menu or through 'File > New'.\n" +
                "2) Answer the questions generated by the program, or 'Reset' the questions.\n" +
                "3) Submit the questions once completed (If you fail to Submit they will be Auto - Submited when time runs out).\n" +
                "4) See how you did, and continue. The program will keep track of how well you did, this can be exported with 'File > Save > Stats'.\n\n" +
                "Features:\n" +
                "- Timer: This adds an element of challenge to the quiz, ensuring that you cannot idle.\n" +
                "- Statistics: This allows you to track how well you have done, as well as allows for exporting for further use or comparison.\n" +
                "- Auto-Update: This ensures that you will always have the most up-to-date features and bug-fixes. But can be dismissed if wanted.\n";
        }
        //Changes the text to show the 'Launch Params' information.
        private void launchParamsButton_Click(object sender, EventArgs e)
        {
            helpText.Text =
                "Launch Parameters:\n\n" +
                "Launch Parameters can be used to launch the program with (temporarily) tweaked settings or features.\n" +
                "They can be used by running the program from the command prompt using \' \"Maths Question Generator.exe\" --<param>' or creating a shortcut with the parameter at the end of the 'Target' field.\n\n" +
                "Current Launch Parameters:\n" +
                "'--offline' or '-o': Launches the program in offline mode with all internet related features disabled.\n" +
                "'--developer' or '-d': Launches the program in developer mode, this allows access to Developer and Debugging tools in the Developer Menu.\n" +
                "'--cleanUpdates' or '-c': Performs a clean update when an update is availible. Best used in the launchParams config or shortcut.\n" +
                "'--update' or '-u': Forcibly downloads and installs the latest version of MQG.\n" +
                "'--legacy or '-l': Disables the creation and loading of the new config file, ensuring that 'launchParams.cfg' has priority. Makes --legacyConfigPersistance irrelevant.\n" +
                "'--legacyConfigPersistance' or '-p': Ensures that 'launchParams.cfg' isnt deleted. The new config file still has priority.\n\n" +
                "The use of Launch Parameters in the 'launchParams.cfg' is not supported or recommended. Use the Settings Page instead.";
        }
    }
}
