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
            this.clearButton = new System.Windows.Forms.Button();
            this.saveLog = new System.Windows.Forms.Button();
            this.console = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.Red;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(299, 286);
            this.clearButton.Name = "clearButton";
            this.clearButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // saveLog
            // 
            this.saveLog.BackColor = System.Drawing.Color.Lime;
            this.saveLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveLog.Location = new System.Drawing.Point(12, 286);
            this.saveLog.Name = "saveLog";
            this.saveLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.saveLog.Size = new System.Drawing.Size(75, 23);
            this.saveLog.TabIndex = 2;
            this.saveLog.Text = "Save";
            this.saveLog.UseVisualStyleBackColor = false;
            this.saveLog.Click += new System.EventHandler(this.saveLog_Click);
            // 
            // console
            // 
            this.console.BackColor = System.Drawing.Color.AliceBlue;
            this.console.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(386, 315);
            this.Controls.Add(this.console);
            this.Controls.Add(this.saveLog);
            this.Controls.Add(this.clearButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DebugConsole";
            this.Text = "MQG: Console";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button saveLog;
        private System.Windows.Forms.RichTextBox console;
    }
}