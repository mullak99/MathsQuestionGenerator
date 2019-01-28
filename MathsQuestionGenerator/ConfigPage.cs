using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathsQuestionGenerator
{
    public partial class ConfigPage : Form
    {
        public ConfigPage()
        {
            InitializeComponent();
            loadConfigFile();
        }

        //Opens the Github link once the logo is clicked.
        private void logoMQG_Click(object sender, EventArgs e)
        {
            Process.Start("http://github.com/mullak99/MathsQuestionGenerator");
        }

        //Overrides the Windows ('X') to hide the form instead of disposing it.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!discardWarning())
            {
                base.OnFormClosing(e);

                if (e.CloseReason == CloseReason.WindowsShutDown) return;

                e.Cancel = true;
                Hide();
            }
            else e.Cancel = true;
        }
        //Enables Runtime Timer when hovering over Checkbox List.
        private void configTogglesCheckboxList_MouseEnter(object sender, EventArgs e)
        {
            configRuntime.Start();
        }
        //Disables Runtime Timer when leaving Checkbox List.
        private void configTogglesCheckboxList_MouseLeave(object sender, EventArgs e)
        {
            configRuntime.Stop();
        }
        //Updates the item that is checked.
        private void configTogglesCheckboxList_KeyDown(object sender, KeyEventArgs e)
        {
            updateCheckedItems();
        }
        //Updates the item that is checked.
        private void configRuntime_Tick(object sender, EventArgs e)
        {
            updateCheckedItems();
        }
        //Ensures each Checkbox Toggle has the same value as the Checkbox List.
        private void updateCheckedItems()
        {
            for (int i = 0; i < configTogglesCheckboxList.Items.Count; i++)
            {
                (configTogglesCheckboxList.Items[i] as XmlSettingListBoxItem).Value = configTogglesCheckboxList.GetItemChecked(i);
            }
        }
        //Loads all values from the config file and applied them to the Settings Page Checkboxes and Config Stats.
        private void loadConfigFile()
        {
            configTogglesCheckboxList.Items.Clear();
            configTogglesCheckboxList.Items.Insert(0, new XmlSettingListBoxItem("Clean Updates", Program.xmlSettings.readBoolean("cleanUpdates"), "Removes all unnecessary files after updating."));
            configTogglesCheckboxList.Items.Insert(1, new XmlSettingListBoxItem("Developer Mode", Program.xmlSettings.readBoolean("developerMode"), "Allows access to Developer and Debugging tools in the Developer Menu."));
            configTogglesCheckboxList.Items.Insert(2, new XmlSettingListBoxItem("Offline Mode", Program.xmlSettings.readBoolean("offlineMode"), "Disables all internet related features."));
            configTogglesCheckboxList.Items.Insert(3, new XmlSettingListBoxItem("Legacy Config Persistance", Program.xmlSettings.readBoolean("legacyConfigPersistance"), "Ensures that 'launchParams.cfg' isnt deleted."));
            if (Program.xmlSettings.doesVariableExist("easterEgg")) configTogglesCheckboxList.Items.Insert(4, new XmlSettingListBoxItem("Easter Egg", Program.xmlSettings.readBoolean("easterEgg"), "Disable it if you don't like fun :("));

            for (int i = 0; i < configTogglesCheckboxList.Items.Count; i++)
            {
                configTogglesCheckboxList.SetItemChecked(i, (configTogglesCheckboxList.Items[i] as XmlSettingListBoxItem).Value);
            }

            configStats.Text = "Config Statistics:" +
                "\nCreated on: " + Program.xmlSettings.readString("xmlCreationDate") +
                "\nCreated with: v" + Program.xmlSettings.readString("xmlCreationVersion");
        }
        //Checks if changes exist between the config file and the checkboxes.
        private bool wasChangesMade()
        {
            if (Program.xmlSettings.readBoolean("cleanUpdates") != (configTogglesCheckboxList.Items[0] as XmlSettingListBoxItem).Value) return true;
            if (Program.xmlSettings.readBoolean("developerMode") != (configTogglesCheckboxList.Items[1] as XmlSettingListBoxItem).Value) return true;
            if (Program.xmlSettings.readBoolean("offlineMode") != (configTogglesCheckboxList.Items[2] as XmlSettingListBoxItem).Value) return true;
            if (Program.xmlSettings.readBoolean("legacyConfigPersistance") != (configTogglesCheckboxList.Items[3] as XmlSettingListBoxItem).Value) return true;
            if (Program.xmlSettings.doesVariableExist("easterEgg") && Program.xmlSettings.readBoolean("easterEgg") != (configTogglesCheckboxList.Items[4] as XmlSettingListBoxItem).Value) return true;

            return false;
        }
        //Warns the user if changes exist.
        private bool discardWarning()
        {
            if (wasChangesMade())
            {
                if (MessageBox.Show("Changes have been made.\n\nAre you sure you want to discard these changes?", "Discard Changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    loadConfigFile();
                else
                    return true;
            }
            return false;
        }
        //Sets all the values in the config file to the checkbox values.
        private void saveButton_Click(object sender, EventArgs e)
        {
            Program.xmlSettings.setBoolean("cleanUpdates", (configTogglesCheckboxList.Items[0] as XmlSettingListBoxItem).Value);
            Program.xmlSettings.setBoolean("developerMode", (configTogglesCheckboxList.Items[1] as XmlSettingListBoxItem).Value);
            Program.xmlSettings.setBoolean("offlineMode", (configTogglesCheckboxList.Items[2] as XmlSettingListBoxItem).Value);
            Program.xmlSettings.setBoolean("legacyConfigPersistance", (configTogglesCheckboxList.Items[3] as XmlSettingListBoxItem).Value);
            if (Program.xmlSettings.doesVariableExist("easterEgg")) Program.xmlSettings.setBoolean("easterEgg", (configTogglesCheckboxList.Items[4] as XmlSettingListBoxItem).Value);

            Program.loadOptions();
            Hide();
        }
        //Displays Changes warning if applicable.
        private void discardButton_Click(object sender, EventArgs e)
        {
            discardWarning();
        }
    }
}
