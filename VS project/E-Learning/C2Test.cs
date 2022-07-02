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
    public partial class C2Test : Form
    {
        public static C2Test Obj;
        Countdown CD;

        public void Init()
        {
            CD = new Countdown(25, 00, label11);
            TextBox[] tBoxes = { textBox1, textBox2, textBox3};
            RadioButton[] rButtons = { radioButton1, radioButton2, radioButton3, radioButton4, radioButton5, radioButton6, radioButton7, radioButton8, radioButton9, radioButton10, radioButton11, radioButton12, radioButton13, radioButton14, radioButton15, radioButton16 , radioButton17, radioButton18, radioButton19, radioButton20 };

            foreach (TextBox t in tBoxes)
                t.Text = String.Empty;

            foreach (RadioButton r in rButtons)
                r.Checked = false;

            CenterToScreen();
        }
        public C2Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int score = 0;

            RadioButton[] rAnswers = { radioButton10, radioButton2, radioButton7, radioButton13, radioButton16, radioButton18, radioButton20 };

            foreach (RadioButton r in rAnswers)
            {
                if (r.Checked)
                    score += 10;    
            }

            if (textBox1.Text == "1532")
                score += 10;
            if (textBox2.Text == "2065")
                score += 10;
            if (textBox3.Text == "817")
                score += 10;

            MainForm.Obj.UserRow["ScoreC2"] = score;
            MainForm.Obj.dataSetObj.WriteXml("C:\\E-Learning\\StatisticsDatabase.xml");

            button1.Enabled = false;
            timer1.Stop();
            label11.Text = "-";
            MessageBox.Show("Final score on Chapter 2 Exam : " + score + "/100", "Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (score >= 90)
                MessageBox.Show("Great job! You did very well, keep it up!", "Nice!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (score >= 70)
                MessageBox.Show("You did great, but you can do even better!", "Good!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (score >= 50)
                MessageBox.Show("You did good, but you must study more!", "Nice!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Chapter2Form.Obj.Init();
            Chapter2Form.Obj.Show();

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
                MainForm.Obj.UserRow["C2TestTime"] = (int)MainForm.Obj.UserRow["C2TestTime"] + 1;
            }
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

            Chapter2Form.Obj.Init();
            Chapter2Form.Obj.Show();

            Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void C2Test_Load(object sender, EventArgs e)
        {

        }
    }
}
