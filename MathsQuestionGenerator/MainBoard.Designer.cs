namespace MathsQuestionGenerator
{
    partial class MainBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainBoard));
            this.questionBox1 = new System.Windows.Forms.GroupBox();
            this.answer1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.guess1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.question1 = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extremeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.developerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.answersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.answerAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.difficultiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.submitButton = new System.Windows.Forms.Button();
            this.questionBox2 = new System.Windows.Forms.GroupBox();
            this.answer2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guess2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.question2 = new System.Windows.Forms.Label();
            this.questionBox3 = new System.Windows.Forms.GroupBox();
            this.answer3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.guess3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.question3 = new System.Windows.Forms.Label();
            this.questionBox4 = new System.Windows.Forms.GroupBox();
            this.answer4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.guess4 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.question4 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.correctNum = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.difficultyLabel = new System.Windows.Forms.Label();
            this.difficulty = new System.Windows.Forms.TextBox();
            this.noteLabel = new System.Windows.Forms.Label();
            this.correctNumSession = new System.Windows.Forms.Label();
            this.copyrightNotice = new System.Windows.Forms.Label();
            this.timerLabel = new System.Windows.Forms.Label();
            this.timeLeft = new System.Windows.Forms.Label();
            this.timeProgress = new System.Windows.Forms.ProgressBar();
            this.quizTimeLeft = new System.Windows.Forms.Timer(this.components);
            this.infoText = new System.Windows.Forms.Label();
            this.debugEvents = new System.Windows.Forms.Timer(this.components);
            this.silenceLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questionBox1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.questionBox2.SuspendLayout();
            this.questionBox3.SuspendLayout();
            this.questionBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // questionBox1
            // 
            this.questionBox1.Controls.Add(this.answer1);
            this.questionBox1.Controls.Add(this.label14);
            this.questionBox1.Controls.Add(this.guess1);
            this.questionBox1.Controls.Add(this.label3);
            this.questionBox1.Controls.Add(this.question1);
            this.questionBox1.Location = new System.Drawing.Point(12, 74);
            this.questionBox1.Name = "questionBox1";
            this.questionBox1.Size = new System.Drawing.Size(587, 60);
            this.questionBox1.TabIndex = 1;
            this.questionBox1.TabStop = false;
            // 
            // answer1
            // 
            this.answer1.ForeColor = System.Drawing.Color.White;
            this.answer1.Location = new System.Drawing.Point(495, 16);
            this.answer1.Name = "answer1";
            this.answer1.Size = new System.Drawing.Size(88, 35);
            this.answer1.TabIndex = 6;
            this.answer1.Text = "?";
            this.answer1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(432, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 20);
            this.label14.TabIndex = 5;
            this.label14.Text = "Answer:";
            // 
            // guess1
            // 
            this.guess1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guess1.Location = new System.Drawing.Point(290, 13);
            this.guess1.Name = "guess1";
            this.guess1.Size = new System.Drawing.Size(139, 38);
            this.guess1.TabIndex = 2;
            this.guess1.TextChanged += new System.EventHandler(this.guess_TextChanged);
            this.guess1.Enter += new System.EventHandler(this.guess1_Enter);
            this.guess1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxes_KeyPress);
            this.guess1.Leave += new System.EventHandler(this.guess1_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(253, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 31);
            this.label3.TabIndex = 3;
            this.label3.Text = "=";
            // 
            // question1
            // 
            this.question1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.question1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question1.ForeColor = System.Drawing.Color.White;
            this.question1.Location = new System.Drawing.Point(5, 16);
            this.question1.Name = "question1";
            this.question1.Size = new System.Drawing.Size(242, 31);
            this.question1.TabIndex = 0;
            this.question1.Text = "0 + 0";
            this.question1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.developerToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(611, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.hardToolStripMenuItem,
            this.extremeToolStripMenuItem,
            this.customToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // easyToolStripMenuItem
            // 
            this.easyToolStripMenuItem.Name = "easyToolStripMenuItem";
            this.easyToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.easyToolStripMenuItem.Text = "Easy";
            this.easyToolStripMenuItem.Click += new System.EventHandler(this.easyToolStripMenuItem_Click);
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.mediumToolStripMenuItem.Text = "Medium";
            this.mediumToolStripMenuItem.Click += new System.EventHandler(this.mediumToolStripMenuItem_Click);
            // 
            // hardToolStripMenuItem
            // 
            this.hardToolStripMenuItem.Name = "hardToolStripMenuItem";
            this.hardToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.hardToolStripMenuItem.Text = "Hard";
            this.hardToolStripMenuItem.Click += new System.EventHandler(this.hardToolStripMenuItem_Click);
            // 
            // extremeToolStripMenuItem
            // 
            this.extremeToolStripMenuItem.Name = "extremeToolStripMenuItem";
            this.extremeToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.extremeToolStripMenuItem.Text = "Extreme";
            this.extremeToolStripMenuItem.Click += new System.EventHandler(this.extremeToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.customToolStripMenuItem.Text = "Custom";
            this.customToolStripMenuItem.Click += new System.EventHandler(this.customToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // developerToolStripMenuItem
            // 
            this.developerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugConsoleToolStripMenuItem,
            this.answersToolStripMenuItem,
            this.answerAllToolStripMenuItem,
            this.silenceLogsToolStripMenuItem,
            this.crashToolStripMenuItem});
            this.developerToolStripMenuItem.Name = "developerToolStripMenuItem";
            this.developerToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.developerToolStripMenuItem.Text = "Developer";
            this.developerToolStripMenuItem.Visible = false;
            // 
            // debugConsoleToolStripMenuItem
            // 
            this.debugConsoleToolStripMenuItem.Name = "debugConsoleToolStripMenuItem";
            this.debugConsoleToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.debugConsoleToolStripMenuItem.Text = "Console";
            this.debugConsoleToolStripMenuItem.Click += new System.EventHandler(this.debugConsoleToolStripMenuItem_Click);
            // 
            // answersToolStripMenuItem
            // 
            this.answersToolStripMenuItem.Name = "answersToolStripMenuItem";
            this.answersToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.answersToolStripMenuItem.Text = "Reveal Answers";
            this.answersToolStripMenuItem.Click += new System.EventHandler(this.answersToolStripMenuItem_Click);
            // 
            // answerAllToolStripMenuItem
            // 
            this.answerAllToolStripMenuItem.Name = "answerAllToolStripMenuItem";
            this.answerAllToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.answerAllToolStripMenuItem.Text = "Answer All";
            this.answerAllToolStripMenuItem.Click += new System.EventHandler(this.answerAllToolStripMenuItem_Click);
            // 
            // crashToolStripMenuItem
            // 
            this.crashToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.difficultiesToolStripMenuItem});
            this.crashToolStripMenuItem.Name = "crashToolStripMenuItem";
            this.crashToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.crashToolStripMenuItem.Text = "Crash";
            // 
            // difficultiesToolStripMenuItem
            // 
            this.difficultiesToolStripMenuItem.Name = "difficultiesToolStripMenuItem";
            this.difficultiesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.difficultiesToolStripMenuItem.Text = "Difficulty Limit";
            this.difficultiesToolStripMenuItem.Click += new System.EventHandler(this.difficultiesToolStripMenuItem_Click);
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.Lime;
            this.submitButton.FlatAppearance.BorderSize = 0;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(12, 351);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(162, 53);
            this.submitButton.TabIndex = 0;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // questionBox2
            // 
            this.questionBox2.Controls.Add(this.answer2);
            this.questionBox2.Controls.Add(this.label2);
            this.questionBox2.Controls.Add(this.guess2);
            this.questionBox2.Controls.Add(this.label4);
            this.questionBox2.Controls.Add(this.question2);
            this.questionBox2.Location = new System.Drawing.Point(12, 140);
            this.questionBox2.Name = "questionBox2";
            this.questionBox2.Size = new System.Drawing.Size(588, 60);
            this.questionBox2.TabIndex = 2;
            this.questionBox2.TabStop = false;
            // 
            // answer2
            // 
            this.answer2.ForeColor = System.Drawing.Color.White;
            this.answer2.Location = new System.Drawing.Point(495, 16);
            this.answer2.Name = "answer2";
            this.answer2.Size = new System.Drawing.Size(88, 35);
            this.answer2.TabIndex = 6;
            this.answer2.Text = "?";
            this.answer2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(432, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Answer:";
            // 
            // guess2
            // 
            this.guess2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guess2.Location = new System.Drawing.Point(290, 13);
            this.guess2.Name = "guess2";
            this.guess2.Size = new System.Drawing.Size(139, 38);
            this.guess2.TabIndex = 3;
            this.guess2.TextChanged += new System.EventHandler(this.guess_TextChanged);
            this.guess2.Enter += new System.EventHandler(this.guess2_Enter);
            this.guess2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxes_KeyPress);
            this.guess2.Leave += new System.EventHandler(this.guess2_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(253, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 31);
            this.label4.TabIndex = 3;
            this.label4.Text = "=";
            // 
            // question2
            // 
            this.question2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.question2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question2.ForeColor = System.Drawing.Color.White;
            this.question2.Location = new System.Drawing.Point(6, 16);
            this.question2.Name = "question2";
            this.question2.Size = new System.Drawing.Size(242, 31);
            this.question2.TabIndex = 0;
            this.question2.Text = "0 + 0";
            this.question2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // questionBox3
            // 
            this.questionBox3.Controls.Add(this.answer3);
            this.questionBox3.Controls.Add(this.label9);
            this.questionBox3.Controls.Add(this.guess3);
            this.questionBox3.Controls.Add(this.label10);
            this.questionBox3.Controls.Add(this.question3);
            this.questionBox3.Location = new System.Drawing.Point(12, 206);
            this.questionBox3.Name = "questionBox3";
            this.questionBox3.Size = new System.Drawing.Size(587, 60);
            this.questionBox3.TabIndex = 3;
            this.questionBox3.TabStop = false;
            // 
            // answer3
            // 
            this.answer3.ForeColor = System.Drawing.Color.White;
            this.answer3.Location = new System.Drawing.Point(495, 16);
            this.answer3.Name = "answer3";
            this.answer3.Size = new System.Drawing.Size(88, 35);
            this.answer3.TabIndex = 6;
            this.answer3.Text = "?";
            this.answer3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(432, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "Answer:";
            // 
            // guess3
            // 
            this.guess3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guess3.Location = new System.Drawing.Point(290, 13);
            this.guess3.Name = "guess3";
            this.guess3.Size = new System.Drawing.Size(139, 38);
            this.guess3.TabIndex = 4;
            this.guess3.TextChanged += new System.EventHandler(this.guess_TextChanged);
            this.guess3.Enter += new System.EventHandler(this.guess3_Enter);
            this.guess3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxes_KeyPress);
            this.guess3.Leave += new System.EventHandler(this.guess3_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(253, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 31);
            this.label10.TabIndex = 3;
            this.label10.Text = "=";
            // 
            // question3
            // 
            this.question3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.question3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question3.ForeColor = System.Drawing.Color.White;
            this.question3.Location = new System.Drawing.Point(5, 16);
            this.question3.Name = "question3";
            this.question3.Size = new System.Drawing.Size(242, 31);
            this.question3.TabIndex = 0;
            this.question3.Text = "0 + 0";
            this.question3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // questionBox4
            // 
            this.questionBox4.Controls.Add(this.answer4);
            this.questionBox4.Controls.Add(this.label16);
            this.questionBox4.Controls.Add(this.guess4);
            this.questionBox4.Controls.Add(this.label17);
            this.questionBox4.Controls.Add(this.question4);
            this.questionBox4.Location = new System.Drawing.Point(12, 272);
            this.questionBox4.Name = "questionBox4";
            this.questionBox4.Size = new System.Drawing.Size(587, 60);
            this.questionBox4.TabIndex = 4;
            this.questionBox4.TabStop = false;
            // 
            // answer4
            // 
            this.answer4.ForeColor = System.Drawing.Color.White;
            this.answer4.Location = new System.Drawing.Point(495, 16);
            this.answer4.Name = "answer4";
            this.answer4.Size = new System.Drawing.Size(88, 35);
            this.answer4.TabIndex = 6;
            this.answer4.Text = "?";
            this.answer4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(432, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 20);
            this.label16.TabIndex = 5;
            this.label16.Text = "Answer:";
            // 
            // guess4
            // 
            this.guess4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guess4.Location = new System.Drawing.Point(290, 13);
            this.guess4.Name = "guess4";
            this.guess4.Size = new System.Drawing.Size(139, 38);
            this.guess4.TabIndex = 5;
            this.guess4.TextChanged += new System.EventHandler(this.guess_TextChanged);
            this.guess4.Enter += new System.EventHandler(this.guess4_Enter);
            this.guess4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxes_KeyPress);
            this.guess4.Leave += new System.EventHandler(this.guess4_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(253, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(30, 31);
            this.label17.TabIndex = 3;
            this.label17.Text = "=";
            // 
            // question4
            // 
            this.question4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.question4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question4.ForeColor = System.Drawing.Color.White;
            this.question4.Location = new System.Drawing.Point(5, 16);
            this.question4.Name = "question4";
            this.question4.Size = new System.Drawing.Size(242, 31);
            this.question4.TabIndex = 0;
            this.question4.Text = "0 + 0";
            this.question4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.Yellow;
            this.resetButton.FlatAppearance.BorderSize = 0;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(482, 356);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(118, 40);
            this.resetButton.TabIndex = 0;
            this.resetButton.TabStop = false;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // correctNum
            // 
            this.correctNum.AutoSize = true;
            this.correctNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correctNum.ForeColor = System.Drawing.Color.White;
            this.correctNum.Location = new System.Drawing.Point(349, 333);
            this.correctNum.Name = "correctNum";
            this.correctNum.Size = new System.Drawing.Size(52, 31);
            this.correctNum.TabIndex = 9;
            this.correctNum.Text = "?/4";
            // 
            // versionLabel
            // 
            this.versionLabel.ForeColor = System.Drawing.Color.White;
            this.versionLabel.Location = new System.Drawing.Point(516, 407);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(93, 15);
            this.versionLabel.TabIndex = 10;
            this.versionLabel.Text = "v0.0.0.0";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.versionLabel.Click += new System.EventHandler(this.versionLabel_Click);
            // 
            // difficultyLabel
            // 
            this.difficultyLabel.AutoSize = true;
            this.difficultyLabel.ForeColor = System.Drawing.Color.White;
            this.difficultyLabel.Location = new System.Drawing.Point(479, 337);
            this.difficultyLabel.Name = "difficultyLabel";
            this.difficultyLabel.Size = new System.Drawing.Size(50, 13);
            this.difficultyLabel.TabIndex = 11;
            this.difficultyLabel.Text = "Difficulty:";
            this.difficultyLabel.Visible = false;
            // 
            // difficulty
            // 
            this.difficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficulty.Location = new System.Drawing.Point(529, 334);
            this.difficulty.MaxLength = 9;
            this.difficulty.Name = "difficulty";
            this.difficulty.Size = new System.Drawing.Size(71, 18);
            this.difficulty.TabIndex = 12;
            this.difficulty.TabStop = false;
            this.difficulty.Text = "10";
            this.difficulty.Visible = false;
            this.difficulty.TextChanged += new System.EventHandler(this.difficulty_TextChanged);
            this.difficulty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxesNoDot_KeyPress);
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.ForeColor = System.Drawing.Color.White;
            this.noteLabel.Location = new System.Drawing.Point(12, 335);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(204, 13);
            this.noteLabel.TabIndex = 13;
            this.noteLabel.Text = "Note: All answers are to 2 decimal places.";
            // 
            // correctNumSession
            // 
            this.correctNumSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correctNumSession.ForeColor = System.Drawing.Color.White;
            this.correctNumSession.Location = new System.Drawing.Point(299, 364);
            this.correctNumSession.Name = "correctNumSession";
            this.correctNumSession.Size = new System.Drawing.Size(152, 19);
            this.correctNumSession.TabIndex = 14;
            this.correctNumSession.Text = "?/4";
            this.correctNumSession.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // copyrightNotice
            // 
            this.copyrightNotice.ForeColor = System.Drawing.Color.White;
            this.copyrightNotice.Location = new System.Drawing.Point(9, 407);
            this.copyrightNotice.Name = "copyrightNotice";
            this.copyrightNotice.Size = new System.Drawing.Size(149, 15);
            this.copyrightNotice.TabIndex = 15;
            this.copyrightNotice.Text = "GPL 3.0 | mullak99 - 2017";
            this.copyrightNotice.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.ForeColor = System.Drawing.Color.White;
            this.timerLabel.Location = new System.Drawing.Point(12, 25);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(135, 31);
            this.timerLabel.TabIndex = 16;
            this.timerLabel.Text = "Time Left:";
            // 
            // timeLeft
            // 
            this.timeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLeft.ForeColor = System.Drawing.Color.White;
            this.timeLeft.Location = new System.Drawing.Point(148, 25);
            this.timeLeft.Name = "timeLeft";
            this.timeLeft.Size = new System.Drawing.Size(452, 31);
            this.timeLeft.TabIndex = 17;
            this.timeLeft.Text = "00:00:00";
            // 
            // timeProgress
            // 
            this.timeProgress.Location = new System.Drawing.Point(12, 59);
            this.timeProgress.Name = "timeProgress";
            this.timeProgress.Size = new System.Drawing.Size(588, 16);
            this.timeProgress.Step = -1;
            this.timeProgress.TabIndex = 18;
            this.timeProgress.Value = 100;
            // 
            // quizTimeLeft
            // 
            this.quizTimeLeft.Interval = 1000;
            this.quizTimeLeft.Tick += new System.EventHandler(this.quizTimeLeft_Tick);
            // 
            // infoText
            // 
            this.infoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoText.ForeColor = System.Drawing.Color.White;
            this.infoText.Location = new System.Drawing.Point(12, 166);
            this.infoText.Name = "infoText";
            this.infoText.Size = new System.Drawing.Size(588, 82);
            this.infoText.TabIndex = 19;
            this.infoText.Text = "Press \'Start\' to begin.";
            this.infoText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // debugEvents
            // 
            this.debugEvents.Interval = 1;
            this.debugEvents.Tick += new System.EventHandler(this.debugEvents_Tick);
            // 
            // silenceLogsToolStripMenuItem
            // 
            this.silenceLogsToolStripMenuItem.Name = "silenceLogsToolStripMenuItem";
            this.silenceLogsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.silenceLogsToolStripMenuItem.Text = "Silence Logs";
            this.silenceLogsToolStripMenuItem.Click += new System.EventHandler(this.silenceLogsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(611, 425);
            this.Controls.Add(this.questionBox2);
            this.Controls.Add(this.timeProgress);
            this.Controls.Add(this.timeLeft);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.copyrightNotice);
            this.Controls.Add(this.correctNumSession);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.difficulty);
            this.Controls.Add(this.difficultyLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.correctNum);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.questionBox4);
            this.Controls.Add(this.questionBox3);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.questionBox1);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.infoText);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainBoard";
            this.Text = "Maths Question Generator";
            this.questionBox1.ResumeLayout(false);
            this.questionBox1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.questionBox2.ResumeLayout(false);
            this.questionBox2.PerformLayout();
            this.questionBox3.ResumeLayout(false);
            this.questionBox3.PerformLayout();
            this.questionBox4.ResumeLayout(false);
            this.questionBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox questionBox1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extremeToolStripMenuItem;
        private System.Windows.Forms.Label answer1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox guess1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label question1;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.GroupBox questionBox2;
        private System.Windows.Forms.Label answer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox guess2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label question2;
        private System.Windows.Forms.GroupBox questionBox3;
        private System.Windows.Forms.Label answer3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox guess3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label question3;
        private System.Windows.Forms.GroupBox questionBox4;
        private System.Windows.Forms.Label answer4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox guess4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label question4;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label correctNum;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.ToolStripMenuItem developerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugConsoleToolStripMenuItem;
        private System.Windows.Forms.Label difficultyLabel;
        private System.Windows.Forms.TextBox difficulty;
        private System.Windows.Forms.ToolStripMenuItem answersToolStripMenuItem;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.Label correctNumSession;
        private System.Windows.Forms.Label copyrightNotice;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label timeLeft;
        private System.Windows.Forms.ProgressBar timeProgress;
        private System.Windows.Forms.Timer quizTimeLeft;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem answerAllToolStripMenuItem;
        private System.Windows.Forms.Label infoText;
        private System.Windows.Forms.ToolStripMenuItem crashToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem difficultiesToolStripMenuItem;
        private System.Windows.Forms.Timer debugEvents;
        private System.Windows.Forms.ToolStripMenuItem silenceLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

