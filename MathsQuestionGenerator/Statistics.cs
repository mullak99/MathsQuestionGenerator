using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MathsQuestionGenerator
{
    class Statistics
    {

        private string spacer = "-------------------------------------------";

        public string[] gatherStats(int currentCorrect, int maxCorrect, double avgTimeTaken, int difficulty)
        {
            string[] stats = new string[4];

            stats[0] = currentCorrect + "/" + maxCorrect;

            if (avgTimeTaken >= 86400)
            {
                stats[1] = Convert.ToString(Math.Round(avgTimeTaken / 86400, 1));
                stats[2] = "day(s)";
            }
            else if (avgTimeTaken >= 3600)
            {
                stats[1] = Convert.ToString(Math.Round(avgTimeTaken / 3600, 1));
                stats[2] = "hours(s)";
            }  
            else if (avgTimeTaken >= 60)
            {
                stats[1] = Convert.ToString(Math.Round(avgTimeTaken / 60, 1));
                stats[2] = "minutes(s)";
            }  
            else
            {
                stats[1] = Convert.ToString(Math.Round(avgTimeTaken, 1));
                stats[2] = "second(s)";
            }
                
            if (difficulty == 10)
                stats[3] = "Easy";
            else if (difficulty == 20)
                stats[3] = "Medium";
            else if (difficulty == 20)
                stats[3] = "Hard";
            else if (difficulty == 20)
                stats[3] = "Extreme";
            else
                stats[1] = "Custom (" + difficulty + ")";

            return stats;
        }

        public void exportStats(int currentCorrect, int maxCorrect, double avgTimeTaken, int difficulty)
        {
            string[] stats = gatherStats(currentCorrect, maxCorrect, avgTimeTaken, difficulty);

            StreamWriter statsTXT = new StreamWriter("Statistics.txt", true);
            statsTXT.WriteLine(spacer + Environment.NewLine + DateTime.Today.ToString("dd/MM/yy") + " | " + DateTime.Now.ToString("hh:mm") + DateTime.Now.ToString("tt") + Environment.NewLine + spacer + Environment.NewLine + "Difficulty: " + stats[3] + Environment.NewLine + "Total: " + stats[0] + Environment.NewLine  + "Average Time: " + stats[1] + " " + stats[2] + Environment.NewLine + spacer + Environment.NewLine + Environment.NewLine);
            statsTXT.Close();
        }
    }
}
