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
    public partial class C1Test : Form
    {
        public static C1Test Obj;
        Countdown CD;

        public void Init()
        {
            CD = new Countdown(25, 00, label11);
            TextBox[] tBoxes = { textBox1, textBox2, textBox3, textBox4, textBox5 };
            RadioButton[] rButtons = { radioButton1, radioButton2, radioButton3, radioButton4, radioButton5, radioButton6, radioButton7, radioButton8, radioButton9, radioButton10, radioButton11, radioButton12, radioButton13, radioButton14, radioButton15, radioButton16 };

            foreach (TextBox t in tBoxes)
                t.Text = String.Empty;

            foreach (RadioButton r in rButtons)
                r.Checked = false;

            CenterToScreen();
        }
        public C1Test()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] solveAnswers = { 26, 1, 2, 75, 62 };
            TextBox[] tBoxes = { textBox1, textBox2, textBox3, textBox4, textBox5 };

            int score = 0;

            if (radioButton2.Checked)
                score += 5;
            if (radioButton4.Checked)
                score += 5;
            if (radioButton5.Checked)
                score += 5;
            if (radioButton8.Checked)
                score += 5;

            if (radioButton12.Checked)
                score += 15;
            if (radioButton16.Checked)
                score += 15;


            for (int i = 0; i < 5; i++)
            {
                try
                {
                    if (solveAnswers[i] == Int32.Parse(tBoxes[i].Text))
                        score += 10;
                }
                catch (Exception) { }
            }

            MainForm.Obj.UserRow["ScoreC1"] = score;
            MainForm.Obj.dataSetObj.WriteXml("C:\\E-Learning\\StatisticsDatabase.xml");

            button1.Enabled = false;
            timer1.Stop();
            label11.Text = "-";
            MessageBox.Show("Final score on Chapter 1 Exam : " + score + "/100", "Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (score >= 90)
                MessageBox.Show("Great job! You did very well, keep it up!", "Nice!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (score >=70)
                MessageBox.Show("You did great, but you can do even better!", "Good!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (score >= 50)
                MessageBox.Show("You did good, but you must study more!", "Nice!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Chapter1Form.Obj.Init();
            Chapter1Form.Obj.Show();

            Hide();
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

            Chapter1Form.Obj.Init();
            Chapter1Form.Obj.Show();

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
                MainForm.Obj.UserRow["C1TestTime"] = (int)MainForm.Obj.UserRow["C1TestTime"] + 1;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); // only handle if user types a number
        }
    }
}
