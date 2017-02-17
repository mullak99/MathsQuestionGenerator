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
            this.logoMQG = new System.Windows.Forms.PictureBox();
            this.infoMQG = new System.Windows.Forms.Label();
            this.githubLink = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoMQG)).BeginInit();
            this.SuspendLayout();
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
            // infoMQG
            // 
            this.infoMQG.AutoSize = true;
            this.infoMQG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoMQG.ForeColor = System.Drawing.Color.White;
            this.infoMQG.Location = new System.Drawing.Point(152, 9);
            this.infoMQG.Name = "infoMQG";
            this.infoMQG.Size = new System.Drawing.Size(328, 120);
            this.infoMQG.TabIndex = 1;
            this.infoMQG.Text = "Maths Question Generator\r\n\r\nAn application for generating pseudo-random\r\nmaths qu" +
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
            // AboutPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(490, 168);
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
    }
}