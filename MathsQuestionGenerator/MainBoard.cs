using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathsQuestionGenerator
{
    public partial class MainBoard : Form
    {

        DebugConsole console = new DebugConsole();
        private float[,] EquationNumbers = new float[4, 4];
        private int globalDifficulty = 10;
        private int correctSession = 0;
        private int maxSession = 4;

        public MainBoard()
        {
            InitializeComponent();
            guess1.KeyPress += new KeyPressEventHandler(textBoxes_KeyPress);
            guess1.Leave += new EventHandler(this.guess1_Leave);
            guess1.Enter += new EventHandler(this.guess1_Enter);
            guess1.TextChanged += new EventHandler(guess_TextChanged);
            guess2.KeyPress += new KeyPressEventHandler(textBoxes_KeyPress);
            guess2.Leave += new EventHandler(this.guess2_Leave);
            guess2.Enter += new EventHandler(this.guess2_Enter);
            guess2.TextChanged += new EventHandler(guess_TextChanged);
            guess3.KeyPress += new KeyPressEventHandler(textBoxes_KeyPress);
            guess3.Leave += new EventHandler(this.guess3_Leave);
            guess3.Enter += new EventHandler(this.guess3_Enter);
            guess3.TextChanged += new EventHandler(guess_TextChanged);
            guess4.KeyPress += new KeyPressEventHandler(textBoxes_KeyPress);
            guess4.Leave += new EventHandler(this.guess4_Leave);
            guess4.Enter += new EventHandler(this.guess4_Enter);
            guess4.TextChanged += new EventHandler(guess_TextChanged);
            difficulty.KeyPress += new KeyPressEventHandler(textBoxesNoDot_KeyPress);
            versionLabel.Text = "v" + Application.ProductVersion;
            reset();
            console.writeToConsole("Initialising complete!");
        }

        public void setDifficulty(int difficulty)
        {
            console.writeToConsole("Difficulty set to '" + difficulty + "'.");
            globalDifficulty = difficulty;
            reset();
        }

        private void generateBoard()
        {
            console.writeToConsole("Generating board.");
            if (globalDifficulty > 100)
                console.writeToConsole("Difficulty has been set over presets. Numbers may not display correctly on high difficulties!", 1);

            randomEquations(globalDifficulty);
            question1.Text = EquationNumbers[0, 0].ToString() + " " + ConvertNumToFunction(Convert.ToInt32(EquationNumbers[0, 1])) + " " + EquationNumbers[0, 2].ToString();
            question2.Text = EquationNumbers[1, 0].ToString() + " " + ConvertNumToFunction(Convert.ToInt32(EquationNumbers[1, 1])) + " " + EquationNumbers[1, 2].ToString();
            question3.Text = EquationNumbers[2, 0].ToString() + " " + ConvertNumToFunction(Convert.ToInt32(EquationNumbers[2, 1])) + " " + EquationNumbers[2, 2].ToString();
            question4.Text = EquationNumbers[3, 0].ToString() + " " + ConvertNumToFunction(Convert.ToInt32(EquationNumbers[3, 1])) + " " + EquationNumbers[3, 2].ToString();

            dynamicFontSize(question1);
            dynamicFontSize(question2);
            dynamicFontSize(question3);
            dynamicFontSize(question4);
        }

        private void showAnswers()
        {
            answer1.Text = Convert.ToString(Math.Round(Convert.ToDouble(EquationNumbers[0, 3]), 2));
            answer2.Text = Convert.ToString(Math.Round(Convert.ToDouble(EquationNumbers[1, 3]), 2));
            answer3.Text = Convert.ToString(Math.Round(Convert.ToDouble(EquationNumbers[2, 3]), 2));
            answer4.Text = Convert.ToString(Math.Round(Convert.ToDouble(EquationNumbers[3, 3]), 2));

            answersToolStripMenuItem.Checked = true;
        }

        private void hideAnswers()
        {
            answer1.Text = "?";
            answer2.Text = "?";
            answer3.Text = "?";
            answer4.Text = "?";

            answersToolStripMenuItem.Checked = false;
        }

        private void doDifficultyCheck()
        {
            if (globalDifficulty == 10)
            {
                easyToolStripMenuItem.Checked = true;
                mediumToolStripMenuItem.Checked = false;
                hardToolStripMenuItem.Checked = false;
                extremeToolStripMenuItem.Checked = false;
            }
            else if (globalDifficulty == 20)
            {
                easyToolStripMenuItem.Checked = false;
                mediumToolStripMenuItem.Checked = true;
                hardToolStripMenuItem.Checked = false;
                extremeToolStripMenuItem.Checked = false;
            }
            else if (globalDifficulty == 30)
            {
                easyToolStripMenuItem.Checked = false;
                mediumToolStripMenuItem.Checked = false;
                hardToolStripMenuItem.Checked = true;
                extremeToolStripMenuItem.Checked = false;
            }
            else if (globalDifficulty == 100)
            {
                easyToolStripMenuItem.Checked = false;
                mediumToolStripMenuItem.Checked = false;
                hardToolStripMenuItem.Checked = false;
                extremeToolStripMenuItem.Checked = true;
            }
            else
            {
                easyToolStripMenuItem.Checked = false;
                mediumToolStripMenuItem.Checked = false;
                hardToolStripMenuItem.Checked = false;
                extremeToolStripMenuItem.Checked = false;
            }
        }

        private void dynamicFontSize(Label question)
        {
            while (question.Width < System.Windows.Forms.TextRenderer.MeasureText(question.Text, new Font(question.Font.FontFamily, question.Font.Size, question.Font.Style)).Width)
                question.Font = new Font(question.Font.FontFamily, question.Font.Size - 0.5f, question.Font.Style);
        }
        
        private void lockGuesses(bool Lock)
        {
            guess1.ForeColor = Color.Black;
            guess2.ForeColor = Color.Black;
            guess3.ForeColor = Color.Black;
            guess4.ForeColor = Color.Black;
            guess1.ReadOnly = Lock;
            guess2.ReadOnly = Lock;
            guess3.ReadOnly = Lock;
            guess4.ReadOnly = Lock;
        }

        private void reset(bool complete = false)
        { 
            console.writeToConsole("Resetting board.");
            guess1.Text = "";
            guess2.Text = "";
            guess3.Text = "";
            guess4.Text = "";
            lockGuesses(false);
            guess1_Leave(0, null);
            guess2_Leave(0, null);
            guess3_Leave(0, null);
            guess4_Leave(0, null);
            correctNum.Text = "?/4";
            guess1.BackColor = Color.White;
            guess2.BackColor = Color.White;
            guess3.BackColor = Color.White;
            guess4.BackColor = Color.White;
            answersToolStripMenuItem.Enabled = true;
            hideAnswers();
            question1.Font = new Font(question1.Font.FontFamily, 20, question1.Font.Style);
            question2.Font = new Font(question2.Font.FontFamily, 20, question2.Font.Style);
            question3.Font = new Font(question3.Font.FontFamily, 20, question3.Font.Style);
            question4.Font = new Font(question4.Font.FontFamily, 20, question4.Font.Style);
            difficulty.Text = Convert.ToString(globalDifficulty);
            if (complete)
            {
                resetStats();
                console.writeToConsole("Resetting stats.");
            }
            doDifficultyCheck();
            generateBoard();
            submitButton.Text = "Submit";
        }

        private void resetStats()
        {
            correctNumSession.Text = "?/4";
            correctSession = 0;
            maxSession = 4;
        }
        
        private static string ConvertNumToFunction(int num)
        {
            if (num == 0)
                return "+";
            else if (num == 1)
                return "-";
            else if (num == 2)
                return "x";
            else if (num == 3)
                return "/";
            else
                return "+";
        }

        private void randomEquations(int difficulty)
        {
            Random rnd = new Random();

            for(int i = 0; i < 4; i++)
            {
                if (difficulty <= 60)
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(difficulty, 10 * (difficulty)));
                else
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(difficulty, 100 * (difficulty)));

                if (difficulty >= 30)
                {
                    EquationNumbers[i, 1] = rnd.Next(0, 4);
                    console.writeToConsole("Equation '" + (i + 1) + "' limited to addition, subtraction, multiplication and division.");
                }
                else if (difficulty >= 20)
                {
                    EquationNumbers[i, 1] = rnd.Next(0, 3);
                    console.writeToConsole("Equation '" + (i + 1) + "' limited to addition, subtraction and multiplication.");
                }
                else
                {
                    EquationNumbers[i, 1] = rnd.Next(0, 2);
                    console.writeToConsole("Equation '" + (i + 1) + "' limited to addition and subtraction.");
                }

                if (difficulty <= 60)
                    EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, Convert.ToInt32(EquationNumbers[i, 0]))); 
                else
                    EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, Convert.ToInt32(EquationNumbers[i, 0])));

                if (EquationNumbers[i, 1] == 0)
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] + EquationNumbers[i, 2];
                else if (EquationNumbers[i, 1] == 1)
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] - EquationNumbers[i, 2];
                
                if (difficulty <= 15 && EquationNumbers[i, 1] == 2)
                {
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(1, 12));
                    EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, 12));
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] * EquationNumbers[i, 2];

                }
                else if (difficulty <= 30 && EquationNumbers[i, 1] == 2)
                {
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(1, 25));
                    EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, 25));
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] * EquationNumbers[i, 2];
                }
                else if (difficulty <= 60 && EquationNumbers[i, 1] == 2)
                {
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(1, 100));
                    EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, 100));
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] * EquationNumbers[i, 2];
                }
                else if (difficulty > 60 && EquationNumbers[i, 1] == 2)
                {
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(1, (difficulty * 2)));
                    EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, (difficulty * 2)));
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] * EquationNumbers[i, 2];
                }

                if (difficulty <= 15 && EquationNumbers[i, 1] == 3)
                {
                    EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, 10));
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(Convert.ToInt32(EquationNumbers[i, 2]), 12));
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] / EquationNumbers[i, 2];
                }
                else if (difficulty <= 30 && EquationNumbers[i, 1] == 3)
                {
                    EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, 12));
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(Convert.ToInt32(EquationNumbers[i, 2]), 15));
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] / EquationNumbers[i, 2];
                }
                else if (difficulty <= 60 && EquationNumbers[i, 1] == 3)
                {
                    EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, 30));
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(Convert.ToInt32(EquationNumbers[i, 2]), 30));
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] / EquationNumbers[i, 2];
                }
                else if (difficulty > 60 && EquationNumbers[i, 1] == 3)
                {
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(1, (difficulty / 2)));
                    EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, (difficulty / 2)));
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] / EquationNumbers[i, 2];
                }

                console.writeToConsole("Finished generation equation '" + (i + 1) + "'.");
            }
        }

        private void submitAnswers()
        {
            console.writeToConsole("User submitted answers.");

            if (string.IsNullOrEmpty(guess1.Text))
                guess1.Text = "0";
            if (string.IsNullOrEmpty(guess2.Text))
                guess2.Text = "0";
            if (string.IsNullOrEmpty(guess3.Text))
                guess3.Text = "0";
            if (string.IsNullOrEmpty(guess4.Text))
                guess4.Text = "0";

            lockGuesses(true);

            int numCorrect = 0;
            try
            {
                if (Math.Round(Convert.ToDouble(guess1.Text), 2) == Math.Round(Convert.ToDouble(EquationNumbers[0, 3]), 2))
                {
                    guess1.BackColor = Color.Green;
                    numCorrect++;
                }
                else
                    guess1.BackColor = Color.Red;
                if (Math.Round(Convert.ToDouble(guess2.Text), 2) == Math.Round(Convert.ToDouble(EquationNumbers[1, 3]), 2))
                {
                    guess2.BackColor = Color.Green;
                    numCorrect++;
                }
                else
                    guess2.BackColor = Color.Red;
                if (Math.Round(Convert.ToDouble(guess3.Text), 2) == Math.Round(Convert.ToDouble(EquationNumbers[2, 3]), 2))
                {
                    guess3.BackColor = Color.Green;
                    numCorrect++;
                }
                else
                    guess3.BackColor = Color.Red;
                if (Math.Round(Convert.ToDouble(guess4.Text), 2) == Math.Round(Convert.ToDouble(EquationNumbers[3, 3]), 2))
                {
                    guess4.BackColor = Color.Green;
                    numCorrect++;
                }
                else
                    guess4.BackColor = Color.Red;

                correctNum.Text = numCorrect + "/4";
                correctSession += numCorrect;
                correctNumSession.Text = correctSession + "/" + maxSession;

                answersToolStripMenuItem.Enabled = false;
                showAnswers();

                console.writeToConsole("User scored '" + correctNum.Text + "'.");
                submitButton.Text = "Next";
            }
            catch (FormatException)
            {
                console.writeToConsole("You have entered invalid characters.", 2);
            }
        }

        private void ghostText(TextBox textbox, string ghostText, bool ghostMode)
        {
            if(!textbox.ReadOnly)
            {
                if (ghostMode)
                {
                    if (textbox.Text.Length == 0)
                    {
                        textbox.Text = ghostText;
                        textbox.ForeColor = SystemColors.GrayText;
                    }
                }
                else
                {
                    if (textbox.Text == ghostText)
                    {
                        textbox.Text = "";
                        textbox.ForeColor = SystemColors.WindowText;
                    }
                }
            }
            
        }

        private void nextBoard()
        {
            reset();
            maxSession += 4;
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setDifficulty(10);
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setDifficulty(20);
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setDifficulty(30);
        }

        private void extremeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setDifficulty(100);
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reset(true);
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (submitButton.Text == "Submit")
                submitAnswers();
            else
                nextBoard();
        }

        private void textBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }

        private void textBoxesNoDot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            resetToolStripMenuItem_Click(sender, e);
        }

        private void versionLabel_Click(object sender, EventArgs e)
        {
            developerToolStripMenuItem.Visible = !developerToolStripMenuItem.Visible;
            difficulty.Visible = !difficulty.Visible;
            difficultyLabel.Visible = !difficultyLabel.Visible;

            if (developerToolStripMenuItem.Visible)
                console.writeToConsole("Developer Mode has been enabled!", 1);
        }

        private void debugConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            console.Show();
            console.scroll();
        }

        private void difficulty_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(difficulty.Text, out globalDifficulty);
            doDifficultyCheck();
        }

        private void answersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            answersToolStripMenuItem.Checked = !answersToolStripMenuItem.Checked;

            if (answersToolStripMenuItem.Checked)
            {
                showAnswers();
                console.writeToConsole("Answers have been forced visible!", 1);
            }
            else
                hideAnswers();
        }

        private void guess_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(guess1.Text))
                    Math.Round(Convert.ToDouble(guess1.Text), 2);
                if (!string.IsNullOrEmpty(guess2.Text))
                    Math.Round(Convert.ToDouble(guess2.Text), 2);
                if (!string.IsNullOrEmpty(guess3.Text))
                    Math.Round(Convert.ToDouble(guess3.Text), 2);
                if (!string.IsNullOrEmpty(guess4.Text))
                    Math.Round(Convert.ToDouble(guess4.Text), 2);
                submitButton.Enabled = true;
            }
            catch (FormatException)
            {
                submitButton.Enabled = false;
            }
        }

        private void guess1_Leave(object sender, EventArgs e)
        {
            ghostText(guess1, "0", true);
        }

        private void guess1_Enter(object sender, EventArgs e)
        {
            ghostText(guess1, "0", false);
        }

        private void guess2_Leave(object sender, EventArgs e)
        {
            ghostText(guess2, "0", true);
        }

        private void guess2_Enter(object sender, EventArgs e)
        {
            ghostText(guess2, "0", false);
        }

        private void guess3_Leave(object sender, EventArgs e)
        {
            ghostText(guess3, "0", true);
        }

        private void guess3_Enter(object sender, EventArgs e)
        {
            ghostText(guess3, "0", false);
        }

        private void guess4_Leave(object sender, EventArgs e)
        {
            ghostText(guess4, "0", true);
        }

        private void guess4_Enter(object sender, EventArgs e)
        {
            ghostText(guess4, "0", false);
        }
    }
}
