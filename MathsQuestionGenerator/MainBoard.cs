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
        DebugConsole console = new DebugConsole(); //Calls the 'DebugConsole' class and defines it as 'console' for later use.
        AboutPage about = new AboutPage(); //Calls the 'AboutPage' class and defines it as 'about' for later use.
        private float[,] EquationNumbers = new float[4, 4]; //Creates a float array of 4*4, this is used to store the randomised numbers that will be used within the equations as well as the symbol and answer for the equations.
        private int globalDifficulty = 10; //Creates the integer for the difficulty of the equations generated, this is set to '10' (Easy) by default and can be changed within the game.
        private int correctSession = 0; //Creates the integer for the correct number of questions this session.
        private int maxSession = 4; //Creates the integer for the amount of questions generated, with the 'correctSession' variable this allows for the user to tell the percentage of questions correct.
        TimeSpan timer; //Defines 'timer'.

        public MainBoard()
        {
            InitializeComponent();
            versionLabel.Text = "v" + Application.ProductVersion; //Sets version label to the version defined in the Assembly information.
            lockQuestions(true); //Locks (Hides) the four question group boxes and shows the infoText label.
            setActionButton(2); //Sets the 'Submit' button to display 'Start'.
            console.writeToConsole("Initialising complete!"); //Writes to the console to show its current state for debugging purposes..
        }
        //Sets the difficulty of the test, and resets the board.
        public void setDifficulty(int difficulty)
        {
            console.writeToConsole("Difficulty set to '" + difficulty + "'.");
            globalDifficulty = difficulty;
            reset();
        }
        //Generates the questions on the board.
        private void generateBoard()
        {
            console.writeToConsole("Generating board.");
            if (globalDifficulty > 100)
                console.writeToConsole("Difficulty has been set over presets. Numbers may not display correctly on high difficulties!", 1);
            doDifficultyCheck();
            randomEquations();
            question1.Text = EquationNumbers[0, 0].ToString() + " " + ConvertNumToFunction(Convert.ToInt32(EquationNumbers[0, 1])) + " " + EquationNumbers[0, 2].ToString();
            question2.Text = EquationNumbers[1, 0].ToString() + " " + ConvertNumToFunction(Convert.ToInt32(EquationNumbers[1, 1])) + " " + EquationNumbers[1, 2].ToString();
            question3.Text = EquationNumbers[2, 0].ToString() + " " + ConvertNumToFunction(Convert.ToInt32(EquationNumbers[2, 1])) + " " + EquationNumbers[2, 2].ToString();
            question4.Text = EquationNumbers[3, 0].ToString() + " " + ConvertNumToFunction(Convert.ToInt32(EquationNumbers[3, 1])) + " " + EquationNumbers[3, 2].ToString();

            dynamicFontSize(question1);
            dynamicFontSize(question2);
            dynamicFontSize(question3);
            dynamicFontSize(question4);

        }
        //Shows the answers to the questions.
        private void showAnswers()
        {
            answer1.Text = Convert.ToString(Math.Round(Convert.ToDouble(EquationNumbers[0, 3]), 2));
            answer2.Text = Convert.ToString(Math.Round(Convert.ToDouble(EquationNumbers[1, 3]), 2));
            answer3.Text = Convert.ToString(Math.Round(Convert.ToDouble(EquationNumbers[2, 3]), 2));
            answer4.Text = Convert.ToString(Math.Round(Convert.ToDouble(EquationNumbers[3, 3]), 2));

            answersToolStripMenuItem.Checked = true;
        }
        //Hides the answers to the questions.
        private void hideAnswers()
        {
            answer1.Text = "?";
            answer2.Text = "?";
            answer3.Text = "?";
            answer4.Text = "?";

            answersToolStripMenuItem.Checked = false;
        }
        //Checks the difficulty against the presets and checks them under the File > 'Difficulty' menu.
        private void doDifficultyCheck()
        {
            if (globalDifficulty == 10)
            {
                easyToolStripMenuItem.Checked = true;
                mediumToolStripMenuItem.Checked = false;
                hardToolStripMenuItem.Checked = false;
                extremeToolStripMenuItem.Checked = false;
                customToolStripMenuItem.Checked = false;
            }
            else if (globalDifficulty == 20)
            {
                easyToolStripMenuItem.Checked = false;
                mediumToolStripMenuItem.Checked = true;
                hardToolStripMenuItem.Checked = false;
                extremeToolStripMenuItem.Checked = false;
                customToolStripMenuItem.Checked = false;
            }
            else if (globalDifficulty == 30)
            {
                easyToolStripMenuItem.Checked = false;
                mediumToolStripMenuItem.Checked = false;
                hardToolStripMenuItem.Checked = true;
                extremeToolStripMenuItem.Checked = false;
                customToolStripMenuItem.Checked = false;
            }
            else if (globalDifficulty == 100)
            {
                easyToolStripMenuItem.Checked = false;
                mediumToolStripMenuItem.Checked = false;
                hardToolStripMenuItem.Checked = false;
                extremeToolStripMenuItem.Checked = true;
                customToolStripMenuItem.Checked = false;
            }
            else
            {
                easyToolStripMenuItem.Checked = false;
                mediumToolStripMenuItem.Checked = false;
                hardToolStripMenuItem.Checked = false;
                extremeToolStripMenuItem.Checked = false;
                customToolStripMenuItem.Checked = true;
            }
        }
        //Dynamically scales the font size.
        private void dynamicFontSize(Label question)
        {
            while (question.Width < System.Windows.Forms.TextRenderer.MeasureText(question.Text, new Font(question.Font.FontFamily, question.Font.Size, question.Font.Style)).Width)
                question.Font = new Font(question.Font.FontFamily, question.Font.Size - 0.5f, question.Font.Style);
        }
        //Locks write access to the guesses.
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
        //Locks (Hides) the four question group boxes and shows the infoText label.
        private void lockQuestions(bool Lock)
        {
            infoText.Visible = Lock;
            questionBox1.Visible = !Lock;
            questionBox2.Visible = !Lock;
            questionBox3.Visible = !Lock;
            questionBox4.Visible = !Lock;
            correctNum.Visible = !Lock;
            correctNumSession.Visible = !Lock;
        }
        //Resets the quiz (bool complete resets stats too).
        private void reset(bool complete = false, bool debugMode = false)
        { 
            if(globalDifficulty <= 536870911 || debugMode)
            {
                console.writeToConsole("Resetting board.");
                pauseTimer();
                startTimer();
                guess1.Text = "";
                guess2.Text = "";
                guess3.Text = "";
                guess4.Text = "";
                lockGuesses(false);
                lockQuestions(false);
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
                    resetStats();
                doDifficultyCheck();
                generateBoard();
                setActionButton(0);
            }
            else
            {
                if (MessageBox.Show("Difficulty has exceded its limit of '536870911'.\n\nDo you want to set it to the max value?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    globalDifficulty = 536870911;
                    reset();
                }
            }
        }
        //Sets the 'Submit' button to display either 'Next', 'Start' or 'Submit'.
        private void setActionButton(int var)
        {
            if(var == 1)
                submitButton.Text = "Next";
            else if (var == 2)
                submitButton.Text = "Start";
            else
                submitButton.Text = "Submit";
        }
        //Resets stats.
        private void resetStats()
        {
            console.writeToConsole("Resetting stats.");
            correctNumSession.Text = "?/4";
            correctSession = 0;
            maxSession = 4;
        }
        //Converts an integer to a maths function.
        private static string ConvertNumToFunction(int num)
        {
            if (num == 0)
                return "+";
            else if (num == 1)
                return "-";
            else if (num == 2)
                return "x";
            else if (num == 3)
                return "÷";
            else
                return "+";
        }
        //Sets the timer to a given number of seconds.
        private void setTimer(int seconds)
        {
            console.writeToConsole("Set timer to '" + seconds + "' seconds.");
            timer = TimeSpan.FromSeconds(seconds);
            timeProgress.Maximum = seconds;
            timeProgress.Value = timeProgress.Maximum;

            if (timer.TotalDays >= 1)
                timeLeft.Text = timer.ToString(@"d\:hh\:mm\:ss");
            else
                timeLeft.Text = timer.ToString();
        }
        //Starts counting down the timer.
        private void startTimer()
        {
            console.writeToConsole("Timer started!");
            timeLeft.ForeColor = Color.White;
            setTimer(4 * globalDifficulty);
            quizTimeLeft.Enabled = true;
        }
        //Pauses the countdown of the timer.
        private void pauseTimer()
        {
            console.writeToConsole("Timer paused!");
            quizTimeLeft.Enabled = false;
        }
        //Generates the pseudo-random equations for populating the board using the difficulty.
        private void randomEquations()
        {
            Random rnd = new Random();

            for(int i = 0; i < 4; i++) //Loops the code four times.
            {
                if (globalDifficulty <= 60) //If the difficulty is less than, or equal to '60' it will run the following line, otherwise it will run the code under 'else'.
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(globalDifficulty, 10 * (globalDifficulty))); //Generates the first integer for the equation, from a range of 'globalDifficulty' to 'globalDifficulty' * 10.
                else
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(globalDifficulty, 100 * (globalDifficulty))); //Generates the first integer for the equation, from a range of 'globalDifficulty' to 'globalDifficulty' * 100.

                if (globalDifficulty >= 30)
                {
                    EquationNumbers[i, 1] = rnd.Next(0, 4); //If the difficulty is greater than, or equal to 30 it will limit the equations to addition, subtraction, multiplication and division.
                    console.writeToConsole("Equation '" + (i + 1) + "' limited to addition, subtraction, multiplication and division.");
                }
                else if (globalDifficulty >= 20) 
                {
                    EquationNumbers[i, 1] = rnd.Next(0, 3); //If the difficulty is greater than, or equal to 20 (but less than 30) it will limit the equations to addition, subtraction and multiplication.
                    console.writeToConsole("Equation '" + (i + 1) + "' limited to addition, subtraction and multiplication.");
                }
                else
                {
                    EquationNumbers[i, 1] = rnd.Next(0, 2); //Otherwise, it will limit the equations to addition and subtraction.
                    console.writeToConsole("Equation '" + (i + 1) + "' limited to addition and subtraction.");
                }
                try
                {
                    EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, Convert.ToInt32(EquationNumbers[i, 0]))); //Generates the second number with a random integer between '1' and the value of the first number.
                }
                catch (ArgumentOutOfRangeException e)
                {
                    console.writeToConsole("minValue cannot be greater than maxValue. Difficulty: " + globalDifficulty + ". " + e, 2);
                }

                if (EquationNumbers[i, 1] == 0)
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] + EquationNumbers[i, 2]; //If the equation uses addition, it will set [i, 3] to the answer of the two random numbers using addition.
                else if (EquationNumbers[i, 1] == 1)
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] - EquationNumbers[i, 2]; //If the equation uses subtraction, it will set [i, 3] to the answer of the two random numbers using subtraction.
                
                if (globalDifficulty <= 15 && EquationNumbers[i, 1] == 2)
                {
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(1, 12)); //If the difficulty is less than, or equal to 15 and the equation uses multiplication; it will generate a random number between 1 and 12 for the first number.
                    EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, 12)); //If the difficulty is less than, or equal to 15 and the equation uses multiplication; it will generate a random number between 1 and 12 for the second number.
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] * EquationNumbers[i, 2]; //If the difficulty is less than, or equal to 15 and the equation uses multiplication; it will solve the equation of the two numbers.

                }
                else if (globalDifficulty <= 30 && EquationNumbers[i, 1] == 2)
                {
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(1, 25)); //If the difficulty is less than, or equal to 30 (but greater than 15) and the equation uses multiplication; it will generate a random number between 1 and 25 for the first number.
                    EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, 25)); //If the difficulty is less than, or equal to 30 (but greater than 15) and the equation uses multiplication; it will generate a random number between 1 and 25 for the second number.
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] * EquationNumbers[i, 2]; //If the difficulty is less than, or equal to 30 (but greater than 15) and the equation uses multiplication; it will solve the equation of the two numbers.
                }
                else if (globalDifficulty <= 60 && EquationNumbers[i, 1] == 2)
                {
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(1, 100)); //If the difficulty is less than, or equal to 60 (but greater than 30) and the equation uses multiplication; it will generate a random number between 1 and 100 for the first number.
                    EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, 100)); //If the difficulty is less than, or equal to 60 (but greater than 30) and the equation uses multiplication; it will generate a random number between 1 and 100 for the second number.
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] * EquationNumbers[i, 2]; //If the difficulty is less than, or equal to 60 (but greater than 30) and the equation uses multiplication; it will solve the equation of the two numbers.
                }
                else if (globalDifficulty > 60 && EquationNumbers[i, 1] == 2)
                {
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(1, (globalDifficulty * 2))); //If the difficulty is grater than 60 and the equation uses multiplication; it will generate a random number between 1 and the (globalDifficulty * 2) for the first number.
                    EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, (globalDifficulty * 2))); //If the difficulty is is grater than 60 and the equation uses multiplication; it will generate a random number between 1 and (globalDifficulty * 2) for the second number.
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] * EquationNumbers[i, 2]; //If the difficulty is greater than 60 and the equation uses multiplication; it will solve the equation of the two numbers.
                }

                if (globalDifficulty <= 15 && EquationNumbers[i, 1] == 3)
                {
                    EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, 10)); //If the difficulty is less than, or equal to 15 and the equation uses division; it will generate a random number between 1 and 10 for the second number.
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(Convert.ToInt32(EquationNumbers[i, 2]), 12)); //If the difficulty is less than, or equal to 15 and the equation uses division; it will generate a random number between the second number and 12 for the first number.
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] / EquationNumbers[i, 2]; //If the difficulty is less than, or equal to 15 and the equation uses division; it will solve the equation of the two numbers.
                }
                else if (globalDifficulty <= 30 && EquationNumbers[i, 1] == 3)
                {
                    EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, 12)); //If the difficulty is less than, or equal to 30 (but greater than 15) and the equation uses division; it will generate a random number between 1 and 12 for the second number.
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(Convert.ToInt32(EquationNumbers[i, 2]), 15)); //If the difficulty is less than, or equal to 30 (but greater than 15) and the equation uses division; it will generate a random number between the second number and 15 for the first number.
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] / EquationNumbers[i, 2]; //If the difficulty is less than, or equal to 30 (but greater than 15) and the equation uses division; it will solve the equation of the two numbers.
                }
                else if (globalDifficulty <= 60 && EquationNumbers[i, 1] == 3)
                {
                    EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, 30)); //If the difficulty is less than, or equal to 60 (but greater than 30) and the equation uses division; it will generate a random number between 1 and 30 for the second number.
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(Convert.ToInt32(EquationNumbers[i, 2]), 30)); //If the difficulty is less than, or equal to 60 (but greater than 30) and the equation uses division; it will generate a random number between the second number and 30 for the first number.
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] / EquationNumbers[i, 2]; //If the difficulty is less than, or equal to 60 (but greater than 30) and the equation uses division; it will solve the equation of the two numbers.
                }
                else if (globalDifficulty > 60 && EquationNumbers[i, 1] == 3)
                {
                    EquationNumbers[i, 0] = Convert.ToInt32(rnd.Next(1, (globalDifficulty / 2))); //If the difficulty is greater than 60 and the equation uses division; it will generate a random number between 1 and (globalDifficulty / 2) for the first number.
                    EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, (globalDifficulty / 2))); //If the difficulty is greater than 60 and the equation uses division; it will generate a random number between 1 and (globalDifficulty / 2) for the second number.
                    EquationNumbers[i, 3] = EquationNumbers[i, 0] / EquationNumbers[i, 2]; //If the difficulty is greater than 60 and the equation uses division; it will solve the equation of the two numbers.
                }

                console.writeToConsole("Finished generation equation '" + (i + 1) + "'.");
            }
        }
        //Submits the answers, this will check if the answers are correct while locking out user input.
        private void submitAnswers()
        {
            console.writeToConsole("User submitted answers.");
            pauseTimer();

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
            }
            catch (FormatException)
            {
                console.writeToConsole("Guess 1 contained invalid characters, defaulting to '0'.", 1);
                guess1.Text = "0";
                guess1.BackColor = Color.Red;
            }

            try
            {
                if (Math.Round(Convert.ToDouble(guess2.Text), 2) == Math.Round(Convert.ToDouble(EquationNumbers[1, 3]), 2))
                {
                    guess2.BackColor = Color.Green;
                    numCorrect++;
                }
                else
                    guess2.BackColor = Color.Red;
            }
            catch (FormatException)
            {
                console.writeToConsole("Guess 2 contained invalid characters, defaulting to '0'.", 1);
                guess2.Text = "0";
                guess2.BackColor = Color.Red;
            }

            try
            {
                if (Math.Round(Convert.ToDouble(guess3.Text), 2) == Math.Round(Convert.ToDouble(EquationNumbers[2, 3]), 2))
                {
                    guess3.BackColor = Color.Green;
                    numCorrect++;
                }
                else
                    guess3.BackColor = Color.Red;
            }
            catch (FormatException)
            {
                console.writeToConsole("Guess 3 contained invalid characters, defaulting to '0'.", 1);
                guess3.Text = "0";
                guess3.BackColor = Color.Red;
            }
            try
            {
                if (Math.Round(Convert.ToDouble(guess4.Text), 2) == Math.Round(Convert.ToDouble(EquationNumbers[3, 3]), 2))
                {
                    guess4.BackColor = Color.Green;
                    numCorrect++;
                }
                else
                    guess4.BackColor = Color.Red;
            }
            catch (FormatException)
            {
                console.writeToConsole("Guess 4 contained invalid characters, defaulting to '0'.", 1);
                guess4.Text = "0";
                guess4.BackColor = Color.Red;
            }
            
            correctNum.Text = numCorrect + "/4";
            correctSession += numCorrect;
            correctNumSession.Text = correctSession + "/" + maxSession;
            
            answersToolStripMenuItem.Enabled = false;
            showAnswers();

            console.writeToConsole("User scored '" + correctNum.Text + "'.");
            setActionButton(1);
        }
        //Used to set the guess textboxes to show (or hide) a greyed out '0'.
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
        //Used to generate the next board of equations.
        private void nextBoard()
        {
            reset();
            maxSession += 4;
        }
        //Called each second, it is used to countdown the timer and auto-submit answers once time is up.
        private void quizTimeLeft_Tick(object sender, EventArgs e)
        {
            if (timer.TotalSeconds <= 0)
            {
                submitAnswers();
                lockGuesses(true);
                if (guess1.BackColor == Color.White)
                    guess1.BackColor = Color.DarkGray;
                if (guess2.BackColor == Color.White)
                    guess2.BackColor = Color.DarkGray;
                if (guess3.BackColor == Color.White)
                    guess3.BackColor = Color.DarkGray;
                if (guess4.BackColor == Color.White)
                    guess4.BackColor = Color.DarkGray;
                guess1_Leave(null, null);
                guess2_Leave(null, null);
                guess3_Leave(null, null);
                guess4_Leave(null, null);
                pauseTimer();
            }
            else
            {
                timer = TimeSpan.FromSeconds(timer.TotalSeconds - 1);
                timeProgress.PerformStep();

                if (timer.TotalDays >= 1)
                    timeLeft.Text = timer.ToString(@"d\:hh\:mm\:ss");
                else
                    timeLeft.Text = timer.ToString();

                if (timer.TotalSeconds <= 3 && timeLeft.ForeColor == Color.Yellow)
                    timeLeft.ForeColor = Color.Red;
                else if (timer.TotalSeconds <= 10 && timeLeft.ForeColor == Color.White)
                    timeLeft.ForeColor = Color.Yellow;
            }
        }
        //Sets the games difficulty to '10'.
        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setDifficulty(10);
            difficultyLabel.Visible = false;
            difficulty.Visible = false;
        }
        //Sets the games difficulty to '20'.
        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setDifficulty(20);
            difficultyLabel.Visible = false;
            difficulty.Visible = false;
        }
        //Sets the games difficulty to '30'.
        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setDifficulty(30);
            difficultyLabel.Visible = false;
            difficulty.Visible = false;
        }
        //Sets the games difficulty to '100'.
        private void extremeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setDifficulty(100);
            difficultyLabel.Visible = false;
            difficulty.Visible = false;
        }
        //Manually resets the board, including all statistics (total number correct etc.).
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reset(true);
        }
        //Manually submits the board and checks if the entered guesses are correct.
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (submitButton.Text == "Submit")
                submitAnswers();
            else
                nextBoard();
        }
        //Is called whenever a user types into the guesses textbox, it ensures that only numbers and full stops can be typed.
        private void textBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }
        //Is called whenever a user types into the debug difficulty textbox, it ensures that only numbers can be typed.
        private void textBoxesNoDot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        //Manually resets the board, including all statistics (total number correct etc.).
        private void resetButton_Click(object sender, EventArgs e)
        {
            resetToolStripMenuItem_Click(sender, e);
        }
        //Is called whenever the version label is clicked at the bottom right of the application, it is used to activate the developer options (reveal answers and debug console).
        private void versionLabel_Click(object sender, EventArgs e)
        {
            developerToolStripMenuItem.Visible = !developerToolStripMenuItem.Visible;

            if (developerToolStripMenuItem.Visible)
                console.writeToConsole("Developer Mode has been enabled!", 1);
        }
        //Is called whenever the 'Console' menu item is clicked, this will launch the console form.
        private void debugConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            console.Show();
        }
        //Is called whenever the 'About' menu item is clicked, this will launch the about form.
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about.Show();
        }
        //Is called whenever the difficulty is changed whenever the developer mode is enabled, it ensures the difficulty is applied to the game.
        private void difficulty_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(difficulty.Text) || difficulty.Text == "0")
            {
                globalDifficulty = 10;
            }
            else if(Int32.TryParse(difficulty.Text, out globalDifficulty)) //Tries to parse the text within the 'difficulty' textbox to the 'globalDifficulty' integer.
            {
                globalDifficulty = Int32.Parse(difficulty.Text);
            }
            else
            {
                globalDifficulty = 10;
            }
            doDifficultyCheck();
            
        }
        //Is called whenever the 'Reveal Answers' menu item is clicked, this will reveal all the answers for the current questions.
        private void answersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            answersToolStripMenuItem.Checked = !answersToolStripMenuItem.Checked;

            if (answersToolStripMenuItem.Checked)
            {
                showAnswers(); //Show the answers.
                console.writeToConsole("Answers have been forced visible!", 1);
            }
            else
                hideAnswers(); //Hide the answers.
        }
        //Is called whenever the user changes the value of the guess textboxes, it ensures that the value entered can be converted to a float.
        private void guess_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(guess1.Text))
                    Math.Round(Convert.ToDouble(guess1.Text), 2); //If 'guess1' isn't empty, attempt to round the value to 2dp.
                if (!string.IsNullOrEmpty(guess2.Text))
                    Math.Round(Convert.ToDouble(guess2.Text), 2); //If 'guess2' isn't empty, attempt to round the value to 2dp.
                if (!string.IsNullOrEmpty(guess3.Text))
                    Math.Round(Convert.ToDouble(guess3.Text), 2); //If 'guess3' isn't empty, attempt to round the value to 2dp.
                if (!string.IsNullOrEmpty(guess4.Text))
                    Math.Round(Convert.ToDouble(guess4.Text), 2); //If 'guess4' isn't empty, attempt to round the value to 2dp.
                submitButton.Enabled = true; //If rounding succeeds, enable the submit button.
            }
            catch (FormatException)
            {
                submitButton.Enabled = false; //If rounding fails, disable the submit button.
            }
        }
        //Is called whenever 'guess1' textbox is left, it will check if the textbox is empty; if so it will set it to a ghost (grey) '0' as a placeholder.
        private void guess1_Leave(object sender, EventArgs e)
        {
            ghostText(guess1, "0", true);
        }
        //Is called whenever 'guess1' textbox is entered, it will check if the textbox is filled with a ghost (grey) 0 (the placeholder); if so it will empty the textbox.
        private void guess1_Enter(object sender, EventArgs e)
        {
            ghostText(guess1, "0", false);
        }
        //Is called whenever 'guess2' textbox is left, it will check if the textbox is empty; if so it will set it to a ghost (grey) '0' as a placeholder.
        private void guess2_Leave(object sender, EventArgs e)
        {
            ghostText(guess2, "0", true);
        }
        //Is called whenever 'guess2' textbox is entered, it will check if the textbox is filled with a ghost (grey) 0 (the placeholder); if so it will empty the textbox.
        private void guess2_Enter(object sender, EventArgs e)
        {
            ghostText(guess2, "0", false);
        }
        //Is called whenever 'guess3' textbox is left, it will check if the textbox is empty; if so it will set it to a ghost (grey) '0' as a placeholder.
        private void guess3_Leave(object sender, EventArgs e)
        {
            ghostText(guess3, "0", true);
        }
        //Is called whenever 'guess3' textbox is entered, it will check if the textbox is filled with a ghost (grey) 0 (the placeholder); if so it will empty the textbox.
        private void guess3_Enter(object sender, EventArgs e)
        {
            ghostText(guess3, "0", false);
        }
        //Is called whenever 'guess4' textbox is left, it will check if the textbox is empty; if so it will set it to a ghost (grey) '0' as a placeholder.
        private void guess4_Leave(object sender, EventArgs e)
        {
            ghostText(guess4, "0", true);
        }
        //Is called whenever 'guess4' textbox is entered, it will check if the textbox is filled with a ghost (grey) 0 (the placeholder); if so it will empty the textbox.
        private void guess4_Enter(object sender, EventArgs e)
        {
            ghostText(guess4, "0", false);
        }
        //Closes, and disposes the application.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            console.Dispose();
            this.Dispose();
        }
        //Enables 'Developer' mode.
        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficultyLabel.Visible = !difficultyLabel.Visible;
            difficulty.Visible = !difficulty.Visible;
        }
        //Fills all answer boxes with the correct answer.
        private void answerAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guess1.Text = Convert.ToString(Math.Round(Convert.ToDouble(EquationNumbers[0, 3]), 2));
            guess2.Text = Convert.ToString(Math.Round(Convert.ToDouble(EquationNumbers[1, 3]), 2));
            guess3.Text = Convert.ToString(Math.Round(Convert.ToDouble(EquationNumbers[2, 3]), 2));
            guess4.Text = Convert.ToString(Math.Round(Convert.ToDouble(EquationNumbers[3, 3]), 2));

            guess1.ForeColor = Color.Black;
            guess2.ForeColor = Color.Black;
            guess3.ForeColor = Color.Black;
            guess4.ForeColor = Color.Black;
        }
        //Attempts to find the difficulty limit of the program (Whenever something excedes the 32-bit integer).
        private void difficultiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!difficultiesToolStripMenuItem.Checked)
            {
                difficultiesToolStripMenuItem.Checked = true;
                console.onlyWriteImportant(true);
                debugConsoleToolStripMenuItem_Click(null, null);
                console.writeToConsole("Running Difficulties Increment Crash Test...", 1);
                globalDifficulty = 536865000;
                customToolStripMenuItem_Click(null, null);
                debugEvents.Start();
            }
            else
            {
                difficultiesToolStripMenuItem.Checked = false;
                debugEvents.Stop();
                console.writeToConsole("Stopping Difficulties Increment Crash Test...", 1);
                reset();
                if (silenceLogsToolStripMenuItem.Checked)
                    console.onlyWriteImportant(false);
            }
        }
        //Increases the difficulty by one and resets the board until it crashes, the number is crashes on is logged and displayed.
        private void debugEvents_Tick(object sender, EventArgs e)
        {
            try
            {
                globalDifficulty++;
                reset(false, true);
                console.writeToConsole("Difficulties Increment Crash Test at '" + globalDifficulty + "' was successful. Increasing difficulty...", 1);
            }
            catch (ArgumentOutOfRangeException)
            {
                debugEvents.Stop();
                console.writeToConsole("Stopping Difficulties Increment Crash Test. ArgumentOutOfRangeException occured at '" + globalDifficulty + "' difficulty.", 2);
                globalDifficulty--;
                reset();
                if (silenceLogsToolStripMenuItem.Checked)
                    console.onlyWriteImportant(false);
            }
        }

        private void silenceLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            silenceLogsToolStripMenuItem.Checked = !silenceLogsToolStripMenuItem.Checked;
            console.onlyWriteImportant(silenceLogsToolStripMenuItem.Checked);
        }
    }
}