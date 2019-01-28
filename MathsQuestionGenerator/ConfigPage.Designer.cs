namespace MathsQuestionGenerator
{
    partial class ConfigPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigPage));
            this.logoMQG = new System.Windows.Forms.PictureBox();
            this.infoMQG = new System.Windows.Forms.Label();
            this.configTogglesCheckboxList = new System.Windows.Forms.CheckedListBox();
            this.configRuntime = new System.Windows.Forms.Timer(this.components);
            this.discardButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.configInfo = new System.Windows.Forms.Label();
            this.configStats = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoMQG)).BeginInit();
            this.SuspendLayout();
            // 
            // logoMQG
            // 
            this.logoMQG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logoMQG.Image = global::MathsQuestionGenerator.Properties.Resources.App;
            this.logoMQG.Location = new System.Drawing.Point(7, 2);
            this.logoMQG.Name = "logoMQG";
            this.logoMQG.Size = new System.Drawing.Size(137, 129);
            this.logoMQG.TabIndex = 1;
            this.logoMQG.TabStop = false;
            this.logoMQG.Click += new System.EventHandler(this.logoMQG_Click);
            // 
            // infoMQG
            // 
            this.infoMQG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoMQG.ForeColor = System.Drawing.Color.White;
            this.infoMQG.Location = new System.Drawing.Point(154, 11);
            this.infoMQG.Name = "infoMQG";
            this.infoMQG.Size = new System.Drawing.Size(388, 120);
            this.infoMQG.TabIndex = 2;
            this.infoMQG.Text = "Maths Question Generator\r\n\r\nAn application for generating pseudo-random\r\nmaths qu" +
    "estions.\r\n\r\nGPL 3.0 | mullak99 - 2018";
            // 
            // configTogglesCheckboxList
            // 
            this.configTogglesCheckboxList.BackColor = System.Drawing.Color.RoyalBlue;
            this.configTogglesCheckboxList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configTogglesCheckboxList.CheckOnClick = true;
            this.configTogglesCheckboxList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configTogglesCheckboxList.ForeColor = System.Drawing.Color.White;
            this.configTogglesCheckboxList.FormattingEnabled = true;
            this.configTogglesCheckboxList.Location = new System.Drawing.Point(7, 214);
            this.configTogglesCheckboxList.Name = "configTogglesCheckboxList";
            this.configTogglesCheckboxList.Size = new System.Drawing.Size(536, 135);
            this.configTogglesCheckboxList.TabIndex = 3;
            this.configTogglesCheckboxList.ThreeDCheckBoxes = true;
            this.configTogglesCheckboxList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.configTogglesCheckboxList_KeyDown);
            this.configTogglesCheckboxList.MouseEnter += new System.EventHandler(this.configTogglesCheckboxList_MouseEnter);
            this.configTogglesCheckboxList.MouseLeave += new System.EventHandler(this.configTogglesCheckboxList_MouseLeave);
            // 
            // configRuntime
            // 
            this.configRuntime.Tick += new System.EventHandler(this.configRuntime_Tick);
            // 
            // discardButton
            // 
            this.discardButton.BackColor = System.Drawing.Color.Red;
            this.discardButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.discardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discardButton.ForeColor = System.Drawing.Color.White;
            this.discardButton.Location = new System.Drawing.Point(97, 365);
            this.discardButton.Name = "discardButton";
            this.discardButton.Size = new System.Drawing.Size(84, 32);
            this.discardButton.TabIndex = 9;
            this.discardButton.Text = "Discard";
            this.discardButton.UseVisualStyleBackColor = false;
            this.discardButton.Click += new System.EventHandler(this.discardButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Lime;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.Black;
            this.saveButton.Location = new System.Drawing.Point(7, 365);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(84, 32);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // configInfo
            // 
            this.configInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configInfo.ForeColor = System.Drawing.Color.White;
            this.configInfo.Location = new System.Drawing.Point(7, 134);
            this.configInfo.Name = "configInfo";
            this.configInfo.Size = new System.Drawing.Size(536, 62);
            this.configInfo.TabIndex = 11;
            this.configInfo.Text = "Changes to the config file will only be applied after a restart of the applicatio" +
    "n.";
            this.configInfo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // configStats
            // 
            this.configStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configStats.ForeColor = System.Drawing.Color.White;
            this.configStats.Location = new System.Drawing.Point(222, 358);
            this.configStats.Name = "configStats";
            this.configStats.Size = new System.Drawing.Size(331, 45);
            this.configStats.TabIndex = 12;
            this.configStats.Text = "Config Statistics:\r\nCreated on:\r\nCreated with: v";
            this.configStats.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ConfigPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(555, 405);
            this.Controls.Add(this.configStats);
            this.Controls.Add(this.configInfo);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.discardButton);
            this.Controls.Add(this.configTogglesCheckboxList);
            this.Controls.Add(this.infoMQG);
            this.Controls.Add(this.logoMQG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigPage";
            this.Text = "MQG: Settings";
            ((System.ComponentModel.ISupportInitialize)(this.logoMQG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox logoMQG;
        private System.Windows.Forms.Label infoMQG;
        private System.Windows.Forms.CheckedListBox configTogglesCheckboxList;
        private System.Windows.Forms.Timer configRuntime;
        private System.Windows.Forms.Button discardButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label configInfo;
        private System.Windows.Forms.Label configStats;
    }
}