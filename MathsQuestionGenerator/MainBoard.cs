using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        UpdatePage update = new UpdatePage();
        private float[,] EquationNumbers = new float[4, 4]; //Creates a float array of 4*4, this is used to store the randomised numbers that will be used within the equations as well as the symbol and answer for the equations.
        private int globalDifficulty = 10; //Creates the integer for the difficulty of the equations generated, this is set to '10' (Easy) by default and can be changed within the game.
        private int correctSession = 0; //Creates the integer for the correct number of questions this session.
        private int maxSession = 4; //Creates the integer for the amount of questions generated, with the 'correctSession' variable this allows for the user to tell the percentage of questions correct.
        private int timerStartTime; //The initial timer second count.
        TimeSpan timer; //Defines 'timer'.

        public MainBoard()
        {
            InitializeComponent();
            versionLabel.Text = update.getVersionInfo(); //Sets version label to the file version.
            lockQuestions(true, true); //Locks (Hides) the four question group boxes and shows the infoText label.
            setActionButton(2); //Sets the 'Submit' button to display 'Start'.
            console.writeToConsole("Initialising complete!"); //Writes to the console to show its current state for debugging purposes.
            update.checkForUpdate();
            consoleUpdateInfo();
        }
        //Sets the difficulty of the test, and resets the board.
        public void setDifficulty(int difficulty, bool doReset = true, bool resetStats = false)
        {
            console.writeToConsole("Difficulty set to '" + difficulty + "'.");
            globalDifficulty = difficulty;
            doDifficultyCheck();
            if (doReset)
                reset(resetStats);
        }
        //Generates the questions on the board.
        private void generateBoard()
        {
            console.writeToConsole("Generating board.");
            if (globalDifficulty > 100)
                console.writeToConsole("Difficulty has been set over presets. Numbers may not display correctly on high difficulties!", 2);
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
        //Posts the update info to the console.
        private void consoleUpdateInfo()
        {
            if (update.detailedUpdateInfo() == "LATESTVERSION")
                console.writeToConsole("You are on the latest version! (v" + update.getLatestVersion() + ").");
            else if (update.detailedUpdateInfo() == "APPNEWER")
                console.writeToConsole("You are on a version newer than the public version. (" + update.getVersionInfo() + ").");
            else if (update.detailedUpdateInfo() == "SERVERERROR")
                console.writeToConsole("Could not connect to the update server. Try again later!", 2);
            else
                console.writeToConsole("You are on an out of date version (" + update.getVersionInfo() + "). Consider updating to the latest version (v" + update.getLatestVersion() + ").");

        }
        //Checks the difficulty against the presets and checks them under the 'File > Difficulty' menu.
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
        //Checks the quizTimeLeft Interval agast the presets under 'Developer > Timer Tick Rate' menu.
        private void doTickRateCheck()
        {
            if (quizTimeLeft.Interval == 1000)
            {
                ms1000ToolStripMenuItem.Checked = true;
                ms500ToolStripMenuItem.Checked = false;
                ms250ToolStripMenuItem.Checked = false;
                ms100ToolStripMenuItem.Checked = false;
                ms50ToolStripMenuItem.Checked = false;
                ms10ToolStripMenuItem.Checked = false;
                ms1ToolStripMenuItem.Checked = false;
            }
            else if (quizTimeLeft.Interval == 500)
            {
                ms1000ToolStripMenuItem.Checked = false;
                ms500ToolStripMenuItem.Checked = true;
                ms250ToolStripMenuItem.Checked = false;
                ms100ToolStripMenuItem.Checked = false;
                ms50ToolStripMenuItem.Checked = false;
                ms10ToolStripMenuItem.Checked = false;
                ms1ToolStripMenuItem.Checked = false;
            }
            else if (quizTimeLeft.Interval == 250)
            {
                ms1000ToolStripMenuItem.Checked = false;
                ms500ToolStripMenuItem.Checked = false;
                ms250ToolStripMenuItem.Checked = true;
                ms100ToolStripMenuItem.Checked = false;
                ms50ToolStripMenuItem.Checked = false;
                ms10ToolStripMenuItem.Checked = false;
                ms1ToolStripMenuItem.Checked = false;
            }
            else if (quizTimeLeft.Interval == 100)
            {
                ms1000ToolStripMenuItem.Checked = false;
                ms500ToolStripMenuItem.Checked = false;
                ms250ToolStripMenuItem.Checked = false;
                ms100ToolStripMenuItem.Checked = true;
                ms50ToolStripMenuItem.Checked = false;
                ms10ToolStripMenuItem.Checked = false;
                ms1ToolStripMenuItem.Checked = false;
            }
            else if (quizTimeLeft.Interval == 50)
            {
                ms1000ToolStripMenuItem.Checked = false;
                ms500ToolStripMenuItem.Checked = false;
                ms250ToolStripMenuItem.Checked = false;
                ms100ToolStripMenuItem.Checked = false;
                ms50ToolStripMenuItem.Checked = true;
                ms10ToolStripMenuItem.Checked = false;
                ms1ToolStripMenuItem.Checked = false;
            }
            else if (quizTimeLeft.Interval == 10)
            {
                ms1000ToolStripMenuItem.Checked = false;
                ms500ToolStripMenuItem.Checked = false;
                ms250ToolStripMenuItem.Checked = false;
                ms100ToolStripMenuItem.Checked = false;
                ms50ToolStripMenuItem.Checked = false;
                ms10ToolStripMenuItem.Checked = true;
                ms1ToolStripMenuItem.Checked = false;
            }
            else if (quizTimeLeft.Interval == 1)
            {
                ms1000ToolStripMenuItem.Checked = false;
                ms500ToolStripMenuItem.Checked = false;
                ms250ToolStripMenuItem.Checked = false;
                ms100ToolStripMenuItem.Checked = false;
                ms50ToolStripMenuItem.Checked = false;
                ms10ToolStripMenuItem.Checked = false;
                ms1ToolStripMenuItem.Checked = true;
            }
            else
            {
                ms1000ToolStripMenuItem.Checked = false;
                ms500ToolStripMenuItem.Checked = false;
                ms250ToolStripMenuItem.Checked = false;
                ms100ToolStripMenuItem.Checked = false;
                ms50ToolStripMenuItem.Checked = false;
                ms10ToolStripMenuItem.Checked = false;
                ms1ToolStripMenuItem.Checked = false;
            }
        }
        //Manually override the timer tick rate/
        private void setTickRate(int ms)
        {
            console.writeToConsole("Timer Tick Rate has been forced to '" + ms + "ms'!", 1);
            quizTimeLeft.Interval = ms;
            doTickRateCheck();
        }
        //Dynamically scales the font size.
        private void dynamicFontSize(Label question)
        {
            while (question.Width < System.Windows.Forms.TextRenderer.MeasureText(question.Text, new Font(question.Font.FontFamily, question.Font.Size, question.Font.Style)).Width)
                question.Font = new Font(question.Font.FontFamily, question.Font.Size - 0.5f, question.Font.Style);

            console.writeToConsole("Question Label '" + question.Name + "' has had its font size set to '" + question.Font.Size + "'.");
        }
        //Locks write access to the guesses.
        private void lockGuesses(bool Lock)
        {
            if (Lock)
                console.writeToConsole("Guesses have been locked!");
            else
                console.writeToConsole("Guesses have been unlocked!");
            guess1.ForeColor = Color.Gray;
            guess2.ForeColor = Color.Gray;
            guess3.ForeColor = Color.Gray;
            guess4.ForeColor = Color.Gray;
            guess1.ReadOnly = Lock;
            guess2.ReadOnly = Lock;
            guess3.ReadOnly = Lock;
            guess4.ReadOnly = Lock;
        }
        //Locks (Hides) the four question group boxes and shows the infoText label.
        private void lockQuestions(bool Lock, bool init = false)
        {
            if (Lock)
                console.writeToConsole("Questions have been locked!");
            else
                console.writeToConsole("Questions have been unlocked!");
            infoText.Visible = Lock;
            questionBox1.Visible = !Lock;
            questionBox2.Visible = !Lock;
            questionBox3.Visible = !Lock;
            questionBox4.Visible = !Lock;
            correctNum.Visible = !Lock;
            correctNumSession.Visible = !Lock;
            timeProgress.Visible = !Lock;
            timerLabel.Visible = !Lock;
            timeLeft.Visible = !Lock;
            noteLabel.Visible = !Lock;
            resetButton.Visible = !Lock;
            answersToolStripMenuItem.Enabled = !Lock;
            answerAllToolStripMenuItem.Enabled = !Lock;
            forceStartSplashToolStripMenuItem.Enabled = !Lock;
            lockReset(true, init);
        }
        //Locks the difficulty triggers.
        private void lockDifficultyTriggers(bool Lock)
        {
            if (Lock)
                console.writeToConsole("Difficulty Triggers have been locked!");
            else
                console.writeToConsole("Difficulty Triggers have been unlocked!");
            easyToolStripMenuItem.Enabled = !Lock;
            mediumToolStripMenuItem.Enabled = !Lock;
            hardToolStripMenuItem.Enabled = !Lock;
            extremeToolStripMenuItem.Enabled = !Lock;
        }
        //Lock the reset button
        private void lockReset(bool Lock, bool init = false)
        {
            if (Lock)
                console.writeToConsole("Reset buttons have been locked!");
            else
                console.writeToConsole("Reset buttons have been unlocked!");
            resetButton.Enabled = !Lock;
            resetCurrentToolStripMenuItem.Enabled = !Lock;
            resetAllToolStripMenuItem.Enabled = !Lock;
            customToolStripMenuItem.Enabled = !Lock;
            if (!init)
                lockDifficultyTriggers(Lock);
        }
        //Resets the quiz (bool complete resets stats too).
        private void reset(bool complete = false, bool debugMode = false)
        { 
            if(globalDifficulty <= 536870911 || debugMode)
            {
                console.writeToConsole("Resetting board.");
                pauseTimer();
                startTimer();
                if (guess1.BackColor != Color.White || guess2.BackColor != Color.White || guess3.BackColor != Color.White || guess4.BackColor != Color.White)
                    maxSession += 4;
                guess1.Text = "0";
                guess2.Text = "0";
                guess3.Text = "0";
                guess4.Text = "0";
                lockGuesses(false);
                lockQuestions(false);
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
                doTickRateCheck();
                generateBoard();
                setActionButton(0);
            }
            else if (MessageBox.Show("Difficulty has exceded its limit of '536870911'.\n\nDo you want to set it to the max value?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                setDifficulty(536870911);
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

            submitToolStripMenuItem.Text = submitButton.Text;

            console.writeToConsole("Action button has been set to '" + submitButton.Text + "' (" + var + ").");
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
            if (num == 1)
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
            timerStartTime = seconds;
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
            lockReset(true);
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

                EquationNumbers[i, 2] = Convert.ToInt32(rnd.Next(1, Convert.ToInt32(EquationNumbers[i, 0]))); //Generates the second number with a random integer between '1' and the value of the first number.

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
            lockReset(false);
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
                console.writeToConsole("Guess 1 contained invalid characters, defaulting to '0'.", 2);
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
                console.writeToConsole("Guess 2 contained invalid characters, defaulting to '0'.", 2);
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
                console.writeToConsole("Guess 3 contained invalid characters, defaulting to '0'.", 2);
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
                console.writeToConsole("Guess 4 contained invalid characters, defaulting to '0'.", 2);
                guess4.Text = "0";
                guess4.BackColor = Color.Red;
            }

            guess1.ForeColor = Color.Black;
            guess2.ForeColor = Color.Black;
            guess3.ForeColor = Color.Black;
            guess4.ForeColor = Color.Black;
            correctNum.Text = numCorrect + "/4";
            correctSession += numCorrect;
            correctNumSession.Text = correctSession + "/" + maxSession;
            answersToolStripMenuItem.Enabled = false;
            showAnswers();
            console.writeToConsole("User scored '" + correctNum.Text + "'.");
            setActionButton(1);
        }
        //Called each second, it is used to countdown the timer and auto-submit answers once time is up.
        private void quizTimeLeft_Tick(object sender, EventArgs e)
        {
            if (timer.TotalSeconds <= 0)
            {
                submitAnswers();
                lockGuesses(true);
                guess1.ForeColor = Color.Black;
                guess2.ForeColor = Color.Black;
                guess3.ForeColor = Color.Black;
                guess4.ForeColor = Color.Black;
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

                if (timer.TotalSeconds == timerStartTime - 5)
                    lockReset(false);
            }
        }
        //Toggles the visibility of the custom difficulty options.
        private void customDifficulty(bool Show)
        {
            difficultyLabel.Visible = Show;
            difficulty.Visible = Show;
        }
        //Sets the games difficulty to '10'.
        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (questionBox1.Visible)
                setDifficulty(10);
            else
                easyStartSplash_Checked(sender, e);

            customDifficulty(false);
        }
        //Sets the games difficulty to '20'.
        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (questionBox1.Visible)
                setDifficulty(20);
            else
                mediumStartSplash_Checked(sender, e);

            customDifficulty(false);
        }
        //Sets the games difficulty to '30'.
        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (questionBox1.Visible)
                setDifficulty(30);
            else
                hardStartSplash_Checked(sender, e);

            customDifficulty(false);
        }
        //Sets the games difficulty to '100'.
        private void extremeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (questionBox1.Visible)
                setDifficulty(100);
            else
                extremeStartSplash_Checked(sender, e);

            customDifficulty(false);
        }
        //Enables the custom difficulty options.
        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customDifficulty(!difficulty.Visible);
        }
        //Manually submits the board and checks if the entered guesses are correct.
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (submitButton.Text == "Submit")
                submitAnswers();
            else
                reset();
        }
        //Manually submits the board and checks if the entered guesses are correct. Although it is in the menu.
        private void submitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            submitButton_Click(sender, e);
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
        //Manually resets the board.
        private void resetButton_Click(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift)
                resetAllToolStripMenuItem_Click(sender, e);
            else
                resetCurrentToolStripMenuItem_Click(sender, e);
        }
        //Manually resets the board.
        private void resetCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (resetButton.Enabled)
                reset();
        }
        //Manually resets the board, including all statistics (total number correct etc.).
        private void resetAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (resetButton.Enabled)
                reset(true);
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
            if(developerToolStripMenuItem.Visible)
                console.Show();
        }
        //Is called whenever the 'About' menu item is clicked, this will launch the about form.
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about.Show();
        }
        //Is called whenever the 'Check for Updates' menu item is clicked, this will launch the update form.
        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            update.Show();
        }
        //Is called whenever the difficulty is changed whenever the developer mode is enabled, it ensures the difficulty is applied to the game.
        private void difficulty_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(difficulty.Text) || difficulty.Text == "0")
                setDifficulty(10, false);
            else if (Int32.TryParse(difficulty.Text, out globalDifficulty)) //Tries to parse the text within the 'difficulty' textbox to the 'globalDifficulty' integer.
                setDifficulty(Int32.Parse(difficulty.Text), false);
            else
                setDifficulty(10, false);
        }
        //Is called whenever the 'Reveal Answers' menu item is clicked, this will reveal all the answers for the current questions.
        private void answersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (developerToolStripMenuItem.Visible)
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

            if (guess1.Text != "0")
                guess1.ForeColor = Color.Black;
            if (guess2.Text != "0")
                guess2.ForeColor = Color.Black;
            if (guess3.Text != "0")
                guess3.ForeColor = Color.Black;
            if (guess4.Text != "0")
                guess4.ForeColor = Color.Black;
        }
        //Closes, and disposes the application.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            console.Dispose();
            about.Dispose();
            update.Dispose();
            this.Dispose();
        }
        //Fills all answer boxes with the correct answer.
        private void answerAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(developerToolStripMenuItem.Visible)
            {
                console.writeToConsole("Answers have been autofilled!", 1);
                guess1.Text = Convert.ToString(Math.Round(Convert.ToDouble(EquationNumbers[0, 3]), 2));
                guess2.Text = Convert.ToString(Math.Round(Convert.ToDouble(EquationNumbers[1, 3]), 2));
                guess3.Text = Convert.ToString(Math.Round(Convert.ToDouble(EquationNumbers[2, 3]), 2));
                guess4.Text = Convert.ToString(Math.Round(Convert.ToDouble(EquationNumbers[3, 3]), 2));
            }
        }
        //Attempts to find the difficulty limit of the program (Whenever something excedes the 32-bit integer).
        private void difficultiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (developerToolStripMenuItem.Visible)
            {
                if (!difficultiesToolStripMenuItem.Checked)
                {
                    difficultiesToolStripMenuItem.Checked = true;
                    console.onlyWriteImportant(true);
                    debugConsoleToolStripMenuItem_Click(null, null);
                    console.writeToConsole("Running Difficulties Increment Crash Test...", 2);
                    setDifficulty(536870000, false);
                    customToolStripMenuItem_Click(null, null);
                    massAnswerToolStripMenuItem.Enabled = false;
                    debugEvents.Start();
                }
                else
                {
                    difficultiesToolStripMenuItem.Checked = false;
                    debugEvents.Stop();
                    console.writeToConsole("Stopping Difficulties Increment Crash Test...", 2);
                    reset();
                    silenceLogsToolStripMenuItem.Checked = false;
                    console.onlyWriteImportant(false);
                    massAnswerToolStripMenuItem.Enabled = true;
                }
            }
        }
        private void massAnswerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (developerToolStripMenuItem.Visible)
            {
                if (!massAnswerToolStripMenuItem.Checked)
                {
                    massAnswerToolStripMenuItem.Checked = true;
                    console.onlyWriteImportant(true);
                    debugConsoleToolStripMenuItem_Click(null, null);
                    console.writeToConsole("Running Mass Answer Crash Test...", 2);
                    difficultiesToolStripMenuItem.Enabled = false;
                    reset(true);
                    debugEvents.Start();
                }
                else
                {
                    massAnswerToolStripMenuItem.Checked = false;
                    debugEvents.Stop();
                    console.writeToConsole("Stopping Mass Answer Crash Test...", 2);
                    reset();
                    silenceLogsToolStripMenuItem.Checked = false;
                    console.onlyWriteImportant(false);
                    difficultiesToolStripMenuItem.Enabled = true;
                }
            }
        }
        //Performs various debug events.
        private void debugEvents_Tick(object sender, EventArgs e)
        {
            if (difficultiesToolStripMenuItem.Checked)
            {
                try
                {
                    setDifficulty(globalDifficulty + 1, false);
                    reset(false, true);
                    console.writeToConsole("Difficulties Increment Crash Test at '" + globalDifficulty + "' was successful. Increasing difficulty...", 2);
                }
                catch (ArgumentOutOfRangeException)
                {
                    debugEvents.Stop();
                    console.writeToConsole("Stopping Difficulties Increment Crash Test. ArgumentOutOfRangeException occured at '" + globalDifficulty + "' difficulty.", 3);
                    globalDifficulty--;
                    reset();
                    silenceLogsToolStripMenuItem.Checked = false;
                    console.onlyWriteImportant(false);
                }
            }
            else if (massAnswerToolStripMenuItem.Checked)
            {
                try
                {
                    answerAllToolStripMenuItem_Click(sender, e);
                    submitButton_Click(sender, e);
                    submitButton_Click(sender, e);
                }
                catch (ArgumentOutOfRangeException)
                {
                    debugEvents.Stop();
                    console.writeToConsole("Stopping Mass Answer Crash Test. ArgumentOutOfRangeException occured at '" + correctNumSession + "' correct answers this session.", 3);
                    reset(true);
                    silenceLogsToolStripMenuItem.Checked = false;
                    console.onlyWriteImportant(false);
                }
            }
        }
        //Silences the logs to only show warnings and errors.
        private void silenceLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (developerToolStripMenuItem.Visible)
            {
                silenceLogsToolStripMenuItem.Checked = !silenceLogsToolStripMenuItem.Checked;
                if (silenceLogsToolStripMenuItem.Checked)
                    console.writeToConsole("Silence Logs has been enabled!", 1);
                else
                    console.writeToConsole("Silence Logs has been disabled!", 1);
                console.onlyWriteImportant(silenceLogsToolStripMenuItem.Checked);
            }
        }
        //Bypasses the reset cooldown and forces the questions to reset.
        private void forceResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (developerToolStripMenuItem.Visible)
            {
                console.writeToConsole("Reset has been forced!", 1);
                reset();
            }
        }
        //Forces the Start Splash screen to be shown.
        private void forceStartSplashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (developerToolStripMenuItem.Visible)
            {
                console.writeToConsole("Start Splash Screen has been forced open!", 1);
                console.onlyWriteImportant(true);
                easyStartSplash_Checked(sender, e);
                reset(true);
                pauseTimer();
                setActionButton(2);
                lockQuestions(true);
                lockDifficultyTriggers(false);
                console.onlyWriteImportant(false);
            }
        }
        //Sets the selected difficulty to Easy (10) when on the startup splash screen.
        private void easyStartSplash_Checked(object sender, EventArgs e)
        {
            setDifficulty(10, false);
            easyStartSplash.Checked = true;
            mediumStartSplash.Checked = false;
            hardStartSplash.Checked = false;
            extremeStartSplash.Checked = false;
        }
        //Sets the selected difficulty to Medium (20) when on the startup splash screen.
        private void mediumStartSplash_Checked(object sender, EventArgs e)
        {
            setDifficulty(20, false);
            easyStartSplash.Checked = false;
            mediumStartSplash.Checked = true;
            hardStartSplash.Checked = false;
            extremeStartSplash.Checked = false;
        }
        //Sets the selected difficulty to Hard (30) when on the startup splash screen.
        private void hardStartSplash_Checked(object sender, EventArgs e)
        {
            setDifficulty(30, false);
            easyStartSplash.Checked = false;
            mediumStartSplash.Checked = false;
            hardStartSplash.Checked = true;
            extremeStartSplash.Checked = false;
        }
        //Sets the selected difficulty to Extreme (100) when on the startup splash screen.
        private void extremeStartSplash_Checked(object sender, EventArgs e)
        {
            setDifficulty(100, false);
            easyStartSplash.Checked = false;
            mediumStartSplash.Checked = false;
            hardStartSplash.Checked = false;
            extremeStartSplash.Checked = true;
        }
        //Manually set the quizTimeLeft Interval/Tick Rate to 1000ms.
        private void ms1000ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setTickRate(1000);
        }
        //Manually set the quizTimeLeft Interval/Tick Rate to 500ms.
        private void ms500ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setTickRate(500);
        }
        //Manually set the quizTimeLeft Interval/Tick Rate to 250ms.
        private void ms250ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setTickRate(250);
        }
        //Manually set the quizTimeLeft Interval/Tick Rate to 100ms.
        private void ms100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setTickRate(100);
        }
        //Manually set the quizTimeLeft Interval/Tick Rate to 50ms.
        private void ms50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setTickRate(50);
        }
        //Manually set the quizTimeLeft Interval/Tick Rate to 10ms.
        private void ms10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setTickRate(10);
        }
        //Manually set the quizTimeLeft Interval/Tick Rate to 1ms.
        private void ms1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setTickRate(1);
        }
        //Places a watermark '0' in Guess 1.
        private void guess1_Leave(object sender, EventArgs e)
        {
            if (guess1.Text == "")
            {
                guess1.Text = "0";
                guess1.ForeColor = Color.Gray;
            }
        }
        //Removes the watermark text for Guess 1.
        private void guess1_Enter(object sender, EventArgs e)
        {
            if (guess1.Text == "0" && !guess1.ReadOnly)
            {
                guess1.Text = "";
                guess1.ForeColor = Color.Black;
            }
        }
        //Places a watermark '0' in Guess 2.
        private void guess2_Leave(object sender, EventArgs e)
        {
            if (guess2.Text == "")
            {
                guess2.Text = "0";
                guess2.ForeColor = Color.Gray;
            }
        }
        //Removes the watermark text for Guess 2.
        private void guess2_Enter(object sender, EventArgs e)
        {
            if (guess2.Text == "0" && !guess2.ReadOnly)
            {
                guess2.Text = "";
                guess2.ForeColor = Color.Black;
            }
        }
        //Places a watermark '0' in Guess 3.
        private void guess3_Leave(object sender, EventArgs e)
        {
            if (guess3.Text == "")
            {
                guess3.Text = "0";
                guess3.ForeColor = Color.Gray;
            }
        }
        //Removes the watermark text for Guess 3.
        private void guess3_Enter(object sender, EventArgs e)
        {
            if (guess3.Text == "0" && !guess3.ReadOnly)
            {
                guess3.Text = "";
                guess3.ForeColor = Color.Black;
            }
        }
        //Places a watermark '0' in Guess 4.
        private void guess4_Leave(object sender, EventArgs e)
        {
            if (guess4.Text == "")
            {
                guess4.Text = "0";
                guess4.ForeColor = Color.Gray;
            }
        }
        //Removes the watermark text for Guess 4.
        private void guess4_Enter(object sender, EventArgs e)
        {
            if (guess4.Text == "0" && !guess4.ReadOnly)
            {
                guess4.Text = "";
                guess4.ForeColor = Color.Black;
            }
        }
        //Disables the Version Spoofer.
        private void assemblyVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            assemblyVersionToolStripMenuItem.Checked = true;
            futureVersionToolStripMenuItem.Checked = false;
            latestVersionToolStripMenuItem.Checked = false;
            v1000ToolStripMenuItem.Checked = false;
            update.spoofVersion("", false);
            versionLabel.Text = update.getVersionInfo();
            console.writeToConsole("Version Spoofer: Disabled!", 1);
        }
        //Sets the Version Spoofer to spoof a future version (99.99.99.99).
        private void futureVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            assemblyVersionToolStripMenuItem.Checked = false;
            futureVersionToolStripMenuItem.Checked = true;
            latestVersionToolStripMenuItem.Checked = false;
            v1000ToolStripMenuItem.Checked = false;
            serverErrorToolStripMenuItem.Checked = false;
            update.spoofServerError(false);
            update.spoofVersion("99.99.99.99", true);
            versionLabel.Text = update.getVersionInfo();
            console.writeToConsole("Version Spoofer: Newer Version Set!", 1);
        }
        //Sets the Version Spoofer to spoof the latest server version.
        private void latestVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            assemblyVersionToolStripMenuItem.Checked = false;
            futureVersionToolStripMenuItem.Checked = false;
            latestVersionToolStripMenuItem.Checked = true;
            v1000ToolStripMenuItem.Checked = false;
            serverErrorToolStripMenuItem.Checked = false;
            update.spoofServerError(false);
            update.spoofVersion(update.getLatestVersion(), true);
            versionLabel.Text = update.getVersionInfo();
            console.writeToConsole("Version Spoofer: Latest Version Set!", 1);
        }
        //Sets the Version Spoofer to spoof the Initial Release version.
        private void v1000ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            assemblyVersionToolStripMenuItem.Checked = false;
            futureVersionToolStripMenuItem.Checked = false;
            latestVersionToolStripMenuItem.Checked = false;
            v1000ToolStripMenuItem.Checked = true;
            serverErrorToolStripMenuItem.Checked = false;
            update.spoofServerError(false);
            update.spoofVersion("1.0.0.0", true);
            versionLabel.Text = update.getVersionInfo();
            console.writeToConsole("Version Spoofer: Initial Release Version Set!", 1);
        }
        //Disables the Version Spoofer and spoofs a server error/can not connect to server.
        private void serverErrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serverErrorToolStripMenuItem.Checked = !serverErrorToolStripMenuItem.Checked;
            latestVersionToolStripMenuItem.Checked = false;
            if (!assemblyVersionToolStripMenuItem.Checked)
                assemblyVersionToolStripMenuItem_Click(sender, e);
            update.spoofServerError(serverErrorToolStripMenuItem.Checked);

            if (serverErrorToolStripMenuItem.Checked)
                console.writeToConsole("Version Spoofer: Server Error Enabled!", 1);
            else
                console.writeToConsole("Version Spoofer: Server Error Disabled!", 1);
        }
    }
}