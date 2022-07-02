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
    public partial class C3Test : Form
    {
        public static C3Test Obj;
        public Countdown CD;

        public void Init()
        {
            CD = new Countdown(25, 00, label11);

            CenterToScreen();
        }


        public C3Test()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button1.Enabled)
            {
                DialogResult m = MessageBox.Show("Are you sure you want to quit? Your answers will be submitted on exiting.", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (m == DialogResult.Yes)
                {
                    button1_Click(null, null);
                }
                else
                {
                    return;
                }
            }

            Chapter3Form.Obj.Init();
            Chapter3Form.Obj.Show();

            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int score = 0;

            RadioButton[] TFanswers = { radioButton13, radioButton5, radioButton2, radioButton4 };
            foreach (RadioButton r in TFanswers)
                if (r.Checked)
                    score += 5;

            RadioButton[] MCAnswers = { radioButton11, radioButton16 };
            foreach (RadioButton r in MCAnswers)
                if (r.Checked)
                    score += 10;

            string[] rangeAnswers =
            {
                "6","18",
                "500", "1000",
                "0", "25",
                "2000", "4500"
            };

            CustomRangeSelectorControl.RangeSelectorControl[] ranges = { rangeSelectorControl1, rangeSelectorControl2, rangeSelectorControl3, rangeSelectorControl4 };

            int i, j = 0;
            string r1, r2;

            for (i = 0; i < ranges.Length; i++)
            {
                ranges[i].QueryRange(out r1, out r2);

                if (r1 == rangeAnswers[j] && r2 == rangeAnswers[j+1])
                {
                    score += 15;
                }

                j += 2;
            }

            MainForm.Obj.UserRow["ScoreC3"] = score;
            MainForm.Obj.dataSetObj.WriteXml("C:\\E-Learning\\StatisticsDatabase.xml");

            button1.Enabled = false;
            timer1.Stop();
            label11.Text = "-";
            MessageBox.Show("Final score on Chapter 3 Exam : " + score + "/100", "Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (score >= 90)
                MessageBox.Show("Great job! You did very well, keep it up!", "Nice!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (score >= 70)
                MessageBox.Show("You did great, but you can do even better!", "Good!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (score >= 50)
                MessageBox.Show("You did good, but you must study more!", "Nice!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Chapter3Form.Obj.Init();
            Chapter3Form.Obj.Show();

            Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CD.doCountdown())
            {
                timer1.Stop();
                MessageBox.Show("Time's up!" + Environment.NewLine + "All your answers will now be submitted.", "Time's up!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1_Click(null, null);
            }
            else
            {
                MainForm.Obj.UserRow["C3TestTime"] = (int)MainForm.Obj.UserRow["C3TestTime"] + 1;
            }
        }
    }
}
