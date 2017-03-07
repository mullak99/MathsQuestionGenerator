namespace MathsQuestionGenerator
{
    partial class UpdatePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatePage));
            this.logoMQG = new System.Windows.Forms.PictureBox();
            this.titleMQG = new System.Windows.Forms.Label();
            this.currentVerLabel = new System.Windows.Forms.Label();
            this.latestVerLabel = new System.Windows.Forms.Label();
            this.currentVer = new System.Windows.Forms.Label();
            this.latestVer = new System.Windows.Forms.Label();
            this.briefDesc = new System.Windows.Forms.Label();
            this.updateCheck = new System.Windows.Forms.Button();
            this.downloadUpdate = new System.Windows.Forms.Button();
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
            this.logoMQG.TabIndex = 1;
            this.logoMQG.TabStop = false;
            // 
            // titleMQG
            // 
            this.titleMQG.AutoSize = true;
            this.titleMQG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleMQG.ForeColor = System.Drawing.Color.White;
            this.titleMQG.Location = new System.Drawing.Point(148, 9);
            this.titleMQG.Name = "titleMQG";
            this.titleMQG.Size = new System.Drawing.Size(222, 20);
            this.titleMQG.TabIndex = 2;
            this.titleMQG.Text = "Maths Question Generator";
            // 
            // currentVerLabel
            // 
            this.currentVerLabel.AutoSize = true;
            this.currentVerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentVerLabel.ForeColor = System.Drawing.Color.White;
            this.currentVerLabel.Location = new System.Drawing.Point(149, 44);
            this.currentVerLabel.Name = "currentVerLabel";
            this.currentVerLabel.Size = new System.Drawing.Size(110, 15);
            this.currentVerLabel.TabIndex = 3;
            this.currentVerLabel.Text = "Current Version:";
            // 
            // latestVerLabel
            // 
            this.latestVerLabel.AutoSize = true;
            this.latestVerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latestVerLabel.ForeColor = System.Drawing.Color.White;
            this.latestVerLabel.Location = new System.Drawing.Point(149, 69);
            this.latestVerLabel.Name = "latestVerLabel";
            this.latestVerLabel.Size = new System.Drawing.Size(102, 15);
            this.latestVerLabel.TabIndex = 4;
            this.latestVerLabel.Text = "Latest Version:";
            // 
            // currentVer
            // 
            this.currentVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentVer.ForeColor = System.Drawing.Color.White;
            this.currentVer.Location = new System.Drawing.Point(262, 44);
            this.currentVer.Name = "currentVer";
            this.currentVer.Size = new System.Drawing.Size(108, 15);
            this.currentVer.TabIndex = 5;
            this.currentVer.Text = "v0.0.0.0";
            // 
            // latestVer
            // 
            this.latestVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latestVer.ForeColor = System.Drawing.Color.White;
            this.latestVer.Location = new System.Drawing.Point(262, 69);
            this.latestVer.Name = "latestVer";
            this.latestVer.Size = new System.Drawing.Size(108, 15);
            this.latestVer.TabIndex = 6;
            this.latestVer.Text = "v0.0.0.0";
            // 
            // briefDesc
            // 
            this.briefDesc.ForeColor = System.Drawing.Color.White;
            this.briefDesc.Location = new System.Drawing.Point(148, 99);
            this.briefDesc.Name = "briefDesc";
            this.briefDesc.Size = new System.Drawing.Size(258, 45);
            this.briefDesc.TabIndex = 7;
            this.briefDesc.Text = "PLACEHOLDER TEXT";
            // 
            // updateCheck
            // 
            this.updateCheck.BackColor = System.Drawing.Color.Lime;
            this.updateCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.updateCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateCheck.ForeColor = System.Drawing.Color.Black;
            this.updateCheck.Location = new System.Drawing.Point(5, 176);
            this.updateCheck.Name = "updateCheck";
            this.updateCheck.Size = new System.Drawing.Size(129, 32);
            this.updateCheck.TabIndex = 8;
            this.updateCheck.Text = "Check for Update";
            this.updateCheck.UseVisualStyleBackColor = false;
            this.updateCheck.Click += new System.EventHandler(this.updateCheck_Click);
            // 
            // downloadUpdate
            // 
            this.downloadUpdate.BackColor = System.Drawing.Color.Yellow;
            this.downloadUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.downloadUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadUpdate.ForeColor = System.Drawing.Color.Black;
            this.downloadUpdate.Location = new System.Drawing.Point(140, 176);
            this.downloadUpdate.Name = "downloadUpdate";
            this.downloadUpdate.Size = new System.Drawing.Size(129, 32);
            this.downloadUpdate.TabIndex = 9;
            this.downloadUpdate.Text = "Download Update";
            this.downloadUpdate.UseVisualStyleBackColor = false;
            this.downloadUpdate.Visible = false;
            this.downloadUpdate.Click += new System.EventHandler(this.downloadUpdate_Click);
            // 
            // UpdatePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(418, 215);
            this.Controls.Add(this.downloadUpdate);
            this.Controls.Add(this.updateCheck);
            this.Controls.Add(this.briefDesc);
            this.Controls.Add(this.latestVer);
            this.Controls.Add(this.currentVer);
            this.Controls.Add(this.latestVerLabel);
            this.Controls.Add(this.currentVerLabel);
            this.Controls.Add(this.titleMQG);
            this.Controls.Add(this.logoMQG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UpdatePage";
            this.Text = "MQG: Update";
            ((System.ComponentModel.ISupportInitialize)(this.logoMQG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoMQG;
        private System.Windows.Forms.Label titleMQG;
        private System.Windows.Forms.Label currentVerLabel;
        private System.Windows.Forms.Label latestVerLabel;
        private System.Windows.Forms.Label currentVer;
        private System.Windows.Forms.Label latestVer;
        private System.Windows.Forms.Label briefDesc;
        private System.Windows.Forms.Button updateCheck;
        private System.Windows.Forms.Button downloadUpdate;
    }
}