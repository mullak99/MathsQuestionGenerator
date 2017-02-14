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
            this.logoMQM = new System.Windows.Forms.PictureBox();
            this.infoMQM = new System.Windows.Forms.Label();
            this.githubLink = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoMQM)).BeginInit();
            this.SuspendLayout();
            // 
            // logoMQM
            // 
            this.logoMQM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logoMQM.Image = global::MathsQuestionGenerator.Properties.Resources.App;
            this.logoMQM.Location = new System.Drawing.Point(9, 9);
            this.logoMQM.Name = "logoMQM";
            this.logoMQM.Size = new System.Drawing.Size(137, 129);
            this.logoMQM.TabIndex = 0;
            this.logoMQM.TabStop = false;
            this.logoMQM.Click += new System.EventHandler(this.logoMQM_Click);
            // 
            // infoMQM
            // 
            this.infoMQM.AutoSize = true;
            this.infoMQM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoMQM.ForeColor = System.Drawing.Color.White;
            this.infoMQM.Location = new System.Drawing.Point(152, 9);
            this.infoMQM.Name = "infoMQM";
            this.infoMQM.Size = new System.Drawing.Size(328, 120);
            this.infoMQM.TabIndex = 1;
            this.infoMQM.Text = "Maths Question Generator\r\n\r\nAn application for generating pseudo-random\r\nmaths qu" +
    "estions.\r\n\r\nGPL 3.0 | mullak99 - 2017";
            // 
            // githubLink
            // 
            this.githubLink.AutoSize = true;
            this.githubLink.ForeColor = System.Drawing.Color.White;
            this.githubLink.Location = new System.Drawing.Point(261, 154);
            this.githubLink.Name = "githubLink";
            this.githubLink.Size = new System.Drawing.Size(229, 13);
            this.githubLink.TabIndex = 2;
            this.githubLink.Text = "github.com/mullak99/MathsQuestionGenerator";
            this.githubLink.Click += new System.EventHandler(this.githubLink_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.ForeColor = System.Drawing.Color.White;
            this.versionLabel.Location = new System.Drawing.Point(2, 152);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(93, 15);
            this.versionLabel.TabIndex = 11;
            this.versionLabel.Text = "v0.0.0.0";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // AboutPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(490, 168);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.githubLink);
            this.Controls.Add(this.infoMQM);
            this.Controls.Add(this.logoMQM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AboutPage";
            this.Text = "MQM: About";
            ((System.ComponentModel.ISupportInitialize)(this.logoMQM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoMQM;
        private System.Windows.Forms.Label infoMQM;
        private System.Windows.Forms.Label githubLink;
        private System.Windows.Forms.Label versionLabel;
    }
}