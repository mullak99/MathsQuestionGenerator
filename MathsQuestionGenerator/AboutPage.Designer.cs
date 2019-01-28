namespace MathsQuestionGenerator
{
    partial class AboutPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutPage));
            this.infoMQG = new System.Windows.Forms.Label();
            this.githubLink = new System.Windows.Forms.Label();
            this.howToButton = new System.Windows.Forms.Button();
            this.launchParamsButton = new System.Windows.Forms.Button();
            this.helpText = new System.Windows.Forms.Label();
            this.logoMQG = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoMQG)).BeginInit();
            this.SuspendLayout();
            // 
            // infoMQG
            // 
            this.infoMQG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoMQG.ForeColor = System.Drawing.Color.White;
            this.infoMQG.Location = new System.Drawing.Point(152, 9);
            this.infoMQG.Name = "infoMQG";
            this.infoMQG.Size = new System.Drawing.Size(388, 120);
            this.infoMQG.TabIndex = 1;
            this.infoMQG.Text = "Maths Question Generator\r\n\r\nAn application for generating pseudo-random\r\nmaths qu" +
    "estions.\r\n\r\nGPL 3.0 | mullak99 - 2018";
            // 
            // githubLink
            // 
            this.githubLink.AutoSize = true;
            this.githubLink.ForeColor = System.Drawing.Color.White;
            this.githubLink.Location = new System.Drawing.Point(323, 465);
            this.githubLink.Name = "githubLink";
            this.githubLink.Size = new System.Drawing.Size(229, 13);
            this.githubLink.TabIndex = 2;
            this.githubLink.Text = "github.com/mullak99/MathsQuestionGenerator";
            this.githubLink.Click += new System.EventHandler(this.githubLink_Click);
            // 
            // howToButton
            // 
            this.howToButton.BackColor = System.Drawing.Color.DarkViolet;
            this.howToButton.FlatAppearance.BorderSize = 0;
            this.howToButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.howToButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.howToButton.ForeColor = System.Drawing.Color.White;
            this.howToButton.Location = new System.Drawing.Point(5, 450);
            this.howToButton.Name = "howToButton";
            this.howToButton.Size = new System.Drawing.Size(137, 23);
            this.howToButton.TabIndex = 3;
            this.howToButton.Text = "HowTo";
            this.howToButton.UseVisualStyleBackColor = false;
            this.howToButton.Click += new System.EventHandler(this.howToButton_Click);
            // 
            // launchParamsButton
            // 
            this.launchParamsButton.BackColor = System.Drawing.Color.DeepPink;
            this.launchParamsButton.FlatAppearance.BorderSize = 0;
            this.launchParamsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.launchParamsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launchParamsButton.ForeColor = System.Drawing.Color.White;
            this.launchParamsButton.Location = new System.Drawing.Point(148, 450);
            this.launchParamsButton.Name = "launchParamsButton";
            this.launchParamsButton.Size = new System.Drawing.Size(137, 23);
            this.launchParamsButton.TabIndex = 4;
            this.launchParamsButton.Text = "Launch Params";
            this.launchParamsButton.UseVisualStyleBackColor = false;
            this.launchParamsButton.Click += new System.EventHandler(this.launchParamsButton_Click);
            // 
            // helpText
            // 
            this.helpText.ForeColor = System.Drawing.Color.White;
            this.helpText.Location = new System.Drawing.Point(7, 143);
            this.helpText.Name = "helpText";
            this.helpText.Size = new System.Drawing.Size(535, 275);
            this.helpText.TabIndex = 6;
            this.helpText.Text = resources.GetString("helpText.Text");
            // 
            // logoMQG
            // 
            this.logoMQG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logoMQG.Image = global::MathsQuestionGenerator.Properties.Resources.App;
            this.logoMQG.Location = new System.Drawing.Point(5, 0);
            this.logoMQG.Name = "logoMQG";
            this.logoMQG.Size = new System.Drawing.Size(137, 129);
            this.logoMQG.TabIndex = 0;
            this.logoMQG.TabStop = false;
            this.logoMQG.Click += new System.EventHandler(this.logoMQG_Click);
            // 
            // AboutPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(551, 479);
            this.Controls.Add(this.helpText);
            this.Controls.Add(this.launchParamsButton);
            this.Controls.Add(this.howToButton);
            this.Controls.Add(this.githubLink);
            this.Controls.Add(this.infoMQG);
            this.Controls.Add(this.logoMQG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AboutPage";
            this.Text = "MQG: About";
            ((System.ComponentModel.ISupportInitialize)(this.logoMQG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoMQG;
        private System.Windows.Forms.Label infoMQG;
        private System.Windows.Forms.Label githubLink;
        private System.Windows.Forms.Button howToButton;
        private System.Windows.Forms.Button launchParamsButton;
        private System.Windows.Forms.Label helpText;
    }
}