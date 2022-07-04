using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Learning
{
    public partial class StatisticsView : Form
    {
        public static StatisticsView Obj;
        public void Init()
        {
            CenterToScreen();

            label1.Text = "Overall statistics for user \"" + LoginForm.currentUser + "\"";

            int theoryTime = (int)MainForm.Obj.UserRow["C1Time"] + (int)MainForm.Obj.UserRow["C2Time"] + (int)MainForm.Obj.UserRow["C3Time"];
            int testTime = (int)MainForm.Obj.UserRow["C1TestTime"] + (int)MainForm.Obj.UserRow["C2TestTime"] + (int)MainForm.Obj.UserRow["C3TestTime"];

            label3.Text = "Time spent studying theory : " + theoryTime + "s";
            label4.Text = "Time spent doing exams : " + testTime + "s";

            // retrieve scores from DB
            int scoreC1 = (int)MainForm.Obj.UserRow["ScoreC1"];
            int scoreC2 = (int)MainForm.Obj.UserRow["ScoreC2"];
            int scoreC3 = (int)MainForm.Obj.UserRow["ScoreC3"];
            int scoreFinal = (int)MainForm.Obj.UserRow["ScoreFinal"];

            int avgScore;
            int scoreCount = 4;

            // show data to the labels
            if (scoreC1 == -1)
            {
                label8.Text = "Chapter 1 exam : N/A";
                scoreCount--;
                scoreC1 = 0;
            }
            else
            {
                label8.Text = "Chapter 1 exam : " + scoreC1;
            }
            if (scoreC2 == -1)
            {
                label9.Text = "Chapter 2 exam : N/A";
                scoreCount--;
                scoreC2 = 0;
            }
            else
            {
                label9.Text = "Chapter 2 exam : " + scoreC2;
            }
            if (scoreC3 == -1)
            {
                label10.Text = "Chapter 3 exam : N/A";
                scoreCount--;
                scoreC3 = 0;
            }
            else
            {
                label10.Text = "Chapter 3 exam : " + scoreC3;
            }
            if (scoreFinal == -1)
            {
                label11.Text = "Final exam : N/A";
                scoreCount--;
                scoreFinal = 0;
            }
            else
            {
                label11.Text = "Final exam : " + scoreFinal;
            }

            if (scoreCount == 0)
            {
                label2.Text = "Average exam grade : N/A";
            }
            else
            {
                avgScore = (scoreC1 + scoreC2 + scoreC3 + scoreFinal) / scoreCount;
                label2.Text = "Average exam grade : " + avgScore;
            }

            foreach (var series in chart1.Series) // reset all points in charts
            {
                series.Points.Clear();
            }

            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }

            foreach (var series in chart3.Series)
            {
                series.Points.Clear();
            }

            // add test score to the charts
            chart1.Series["Examscore"].Points.AddXY("Chapter 1", scoreC1);
            chart1.Series["Examscore"].Points.AddXY("Chapter 2", scoreC2);
            chart1.Series["Examscore"].Points.AddXY("Chapter 3", scoreC3);
            chart1.Series["Examscore"].Points.AddXY("Final", scoreFinal);

            //retrieve data from db
            int correctAnswersC1 = (int)MainForm.Obj.UserRow["CorrectAnswersC1"];
            int wrongAnswersC1 = (int)MainForm.Obj.UserRow["WrongAnswersC1"];

            int correctAnswersC2 = (int)MainForm.Obj.UserRow["CorrectAnswersC2"];
            int wrongAnswersC2 = (int)MainForm.Obj.UserRow["WrongAnswersC2"];

            int correctAnswersC3 = (int)MainForm.Obj.UserRow["CorrectAnswersC3"];
            int wrongAnswersC3 = (int)MainForm.Obj.UserRow["WrongAnswersC3"];

            // add answer stats to charts
            chart2.Series["Correct"].Points.AddXY("Chapter 1", correctAnswersC1);
            chart2.Series["Wrong"].Points.AddXY("Chapter 1", wrongAnswersC1);

            chart2.Series["Correct"].Points.AddXY("Chapter 2", correctAnswersC2);
            chart2.Series["Wrong"].Points.AddXY("Chapter 2", wrongAnswersC2);

            chart2.Series["Correct"].Points.AddXY("Chapter 3", correctAnswersC3);
            chart2.Series["Wrong"].Points.AddXY("Chapter 3", wrongAnswersC3);

            // retrieve time data from db
            int theoryTimeC1 = (int)MainForm.Obj.UserRow["C1Time"];
            int theoryTimeC2 = (int)MainForm.Obj.UserRow["C2Time"];
            int theoryTimeC3 = (int)MainForm.Obj.UserRow["C3Time"];

            int testTimeC1 = (int)MainForm.Obj.UserRow["C1TestTime"];
            int testTimeC2 = (int)MainForm.Obj.UserRow["C2TestTime"];
            int testTimeC3 = (int)MainForm.Obj.UserRow["C3TestTime"];

            // add time data to chart
            chart3.Series["TheoryTime"].Points.AddXY("Chapter 1", theoryTimeC1);
            chart3.Series["TestTime"].Points.AddXY("Chapter 1", testTimeC1);

            chart3.Series["TheoryTime"].Points.AddXY("Chapter 2", theoryTimeC2);
            chart3.Series["TestTime"].Points.AddXY("Chapter 2", testTimeC2);

            chart3.Series["TheoryTime"].Points.AddXY("Chapter 3", theoryTimeC3);
            chart3.Series["TestTime"].Points.AddXY("Chapter 3", testTimeC3);
        }
        public StatisticsView()
        {
            InitializeComponent();
        }

        private void StatisticsView_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Parent = null;
            e.Cancel = true;

            MainForm.Obj.Init(-1); // pass -1 as UID, because we are returning to main form, not logging in to another user
            MainForm.Obj.Show();


            Hide();
        }

        private void StatisticsView_Load(object sender, EventArgs e)
        {

        }
    }
}
