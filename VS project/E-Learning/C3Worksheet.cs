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
    public partial class C3Worksheet : Form
    {
        public static C3Worksheet Obj;

        public void Init()
        {
            CustomRangeSelectorControl.RangeSelectorControl[] ranges = { rangeSelectorControl1, rangeSelectorControl2, rangeSelectorControl3, rangeSelectorControl4, rangeSelectorControl5, rangeSelectorControl6 };

            foreach (CustomRangeSelectorControl.RangeSelectorControl r in ranges)
            {
                r.Range1 = "-4";
                r.Range2 = "4";
            }

            CenterToScreen();
        }
        public C3Worksheet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] Answers = {
                "-4", "1",
                "-2", "4",
                "-3", "3",
                "-4", "0",
                "-3", "-1",
                "0", "2"
            };

            CustomRangeSelectorControl.RangeSelectorControl[] ranges = { rangeSelectorControl1, rangeSelectorControl2, rangeSelectorControl3, rangeSelectorControl4, rangeSelectorControl5, rangeSelectorControl6 };

            int i = 0;
            int j = 0;

            string r1, r2;

            int correctAnswers = 0;
            int wrongAnswers = 0;

            for (i = 0; i < ranges.Length; i++)
            {
                ranges[i].QueryRange(out r1, out r2);

                if (r1 == Answers[j] && r2 == Answers[j+1])
                {
                    correctAnswers++;
                }
                else
                {
                    wrongAnswers++;
                }

                j += 2;
            }

            MainForm.Obj.UserRow["CorrectAnswersC3"] = correctAnswers + (int)MainForm.Obj.UserRow["CorrectAnswersC3"];
            MainForm.Obj.UserRow["WrongAnswersC3"] = wrongAnswers + (int)MainForm.Obj.UserRow["WrongAnswersC3"];
            MainForm.Obj.dataSetObj.WriteXml("C:\\E-Learning\\StatisticsDatabase.xml");

            MessageBox.Show("Correct answers : " + correctAnswers + Environment.NewLine + "Wrong answers : " + wrongAnswers, "Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (wrongAnswers == 0)
                MessageBox.Show("Excellent work! Keep it up!", "Great job!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult m = MessageBox.Show("Are you sure you want to go back? " + Environment.NewLine + "You will loose your current answers!", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (m == DialogResult.Yes)
            {
                Chapter3Form.Obj.Init();
                Chapter3Form.Obj.Show();
                Hide();
            }
            else
            {
                return;
            }
        }
    }
}
