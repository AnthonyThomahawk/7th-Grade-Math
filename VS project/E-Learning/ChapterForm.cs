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
    public partial class ChapterForm : Form
    {
        public static ChapterForm Obj;

        public void Init()
        {
            CenterToScreen();
        }

        public ChapterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Chapter1Form.Obj == null)
                Chapter1Form.Obj = new Chapter1Form();

            Chapter1Form.Obj.Init();
            Chapter1Form.Obj.Show();
            
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm.Obj.Init(-1);
            MainForm.Obj.Show();
            
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int C1Score = (int)MainForm.Obj.UserRow["ScoreC1"];
            if (C1Score == -1)
            {
                MessageBox.Show("You must complete chapter 1 before entering this chapter.", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Chapter2Form.Obj == null)
                Chapter2Form.Obj = new Chapter2Form();

            Chapter2Form.Obj.Init();
            Chapter2Form.Obj.Show();

            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int C2Score = (int)MainForm.Obj.UserRow["ScoreC2"];
            if (C2Score == -1)
            {
                MessageBox.Show("You must complete chapter 2 before entering this chapter.", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Chapter3Form.Obj == null)
                Chapter3Form.Obj = new Chapter3Form();

            Chapter3Form.Obj.Init();
            Chapter3Form.Obj.Show();

            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int finalScore = (int)MainForm.Obj.UserRow["ScoreFinal"];

            if (finalScore != -1)
            {
                MessageBox.Show("You already have taken this test. " + Environment.NewLine +
                    "Your final score is :" + finalScore + "/100." + Environment.NewLine +
                    "If you wish to re-take the test, reset your statistics.", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int C3Score = (int)MainForm.Obj.UserRow["ScoreC3"];

            if (C3Score == -1)
            {
                MessageBox.Show("You must complete all chapters before taking this test.", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult m = MessageBox.Show("Warning!" + Environment.NewLine +
                "This action will start a timed exam that you can only take ONCE."
                + Environment.NewLine + "You will have limited time to answer questions, and your score will be recorded to your statistics."
                + Environment.NewLine + "Are you sure you want to continue ? "
                , "WARNING!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (m == DialogResult.Yes)
            {
                if (FinalTest.Obj == null)
                    FinalTest.Obj = new FinalTest();

                FinalTest.Obj.Init();
                FinalTest.Obj.Show();

                Hide();
            }

            
        }
    }
}
