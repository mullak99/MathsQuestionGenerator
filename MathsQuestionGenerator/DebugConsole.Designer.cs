namespace MathsQuestionGenerator
{
    partial class DebugConsole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugConsole));
            this.closeButton = new System.Windows.Forms.Button();
            this.saveLog = new System.Windows.Forms.Button();
            this.console = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(299, 286);
            this.closeButton.Name = "closeButton";
            this.closeButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // saveLog
            // 
            this.saveLog.Location = new System.Drawing.Point(12, 286);
            this.saveLog.Name = "saveLog";
            this.saveLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.saveLog.Size = new System.Drawing.Size(75, 23);
            this.saveLog.TabIndex = 2;
            this.saveLog.Text = "Save";
            this.saveLog.UseVisualStyleBackColor = true;
            this.saveLog.Click += new System.EventHandler(this.saveLog_Click);
            // 
            // console
            // 
            this.console.Location = new System.Drawing.Point(12, 12);
            this.console.MaxLength = 0;
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.console.Size = new System.Drawing.Size(362, 268);
            this.console.TabIndex = 3;
            this.console.Text = "";
            // 
            // DebugConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 315);
            this.Controls.Add(this.console);
            this.Controls.Add(this.saveLog);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DebugConsole";
            this.Text = "MQG: Console";
            this.VisibleChanged += new System.EventHandler(this.scrollOnVisible);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button saveLog;
        private System.Windows.Forms.RichTextBox console;
    }
}