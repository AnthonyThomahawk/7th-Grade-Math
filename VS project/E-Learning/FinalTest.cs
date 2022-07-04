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
    public partial class FinalTest : Form
    {
        public static FinalTest Obj;
        Countdown CD;

        public void Init()
        {
            CD = new Countdown(45, 00, label18);

            RadioButton[] rb = { radioButton1,radioButton2,radioButton3,radioButton4,radioButton7,radioButton8,radioButton9,radioButton14, radioButton13, radioButton10 };
            
            foreach (RadioButton r in rb)
                r.Checked = false;

            TextBox[] tb = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10 };
            
            foreach (TextBox tbox in tb)
                tbox.Text = String.Empty;

            rangeSelectorControl1.Range1 = "1000";
            rangeSelectorControl1.Range2 = "2000";
            rangeSelectorControl2.Range1 = "1";
            rangeSelectorControl2.Range2 = "20";

            CenterToScreen();
        }

        public FinalTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int finalScore = 0;

            RadioButton[] TFAnswers = { radioButton14, radioButton2, radioButton4, radioButton7, radioButton9 };

            foreach (RadioButton r in TFAnswers)
            {
                if (r.Checked)
                    finalScore += 4;
            }

            int[] solveAnswers = { 26, 21, 30, 22, 30, 15 };
            TextBox[] boxes = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6 };

            for (int i = 0; i < 6; i++)
            {
                try
                {
                    if (Int32.Parse(boxes[i].Text) == solveAnswers[i])
                        finalScore += 5;
                }
                catch (Exception) { }
                
            }

            int[] numAnswers = { 1212, 3285, 1452, 2587};
            TextBox[] Tboxes = { textBox7, textBox8, textBox9, textBox10};

            for (int i = 0; i < 6; i++)
            {
                try
                {
                    if (Int32.Parse(Tboxes[i].Text) == numAnswers[i])
                        finalScore += 4;
                }
                catch (Exception) { }

            }

            string r1, r2;
            rangeSelectorControl1.QueryRange(out r1, out r2);

            if (r1 == "1200" && r2 == "2000")
                finalScore += 15;

            rangeSelectorControl2.QueryRange(out r1, out r2);

            if (r1 == "8" && r2 == "15")
                finalScore += 15;

            button1.Enabled = false;
            timer1.Stop();
            label11.Text = "-";

            MainForm.Obj.UserRow["ScoreFinal"] = finalScore;
            MainForm.Obj.dataSetObj.WriteXml("C:\\E-Learning\\StatisticsDatabase.xml");

            MessageBox.Show("Final score : " + finalScore + "/100", "Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (finalScore >= 90)
                MessageBox.Show("Great job! You did very well, keep it up!", "Nice!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (finalScore >= 70)
                MessageBox.Show("You did great, but you can do even better!", "Good!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (finalScore >= 50)
                MessageBox.Show("You did good, but you must study more!", "Nice!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ChapterForm.Obj.Init();
            ChapterForm.Obj.Show();

            Hide();
        }

        private void FinalTest_Load(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CD.doCountdown())
            {
                timer1.Stop();
                MessageBox.Show("Time's up!" + Environment.NewLine + "All your answers will now be submitted.", "Time's up!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1_Click(null, null);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
