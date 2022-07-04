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
    public partial class Chapter1Form : Form
    {
        public static Chapter1Form Obj;

        public void Init()
        {
            CenterToScreen();
        }
        public Chapter1Form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChapterForm.Obj.Show();
            ChapterForm.Obj.Init();
            
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TheoryViewer.Obj == null)
                TheoryViewer.Obj = new TheoryViewer();

            TheoryViewer.Obj.Init(0);
            TheoryViewer.Obj.Show();
            
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (C1Worksheet.Obj == null)
                C1Worksheet.Obj = new C1Worksheet();

            C1Worksheet.Obj.Init();
            C1Worksheet.Obj.Show();

            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int C1Score = (int)MainForm.Obj.UserRow["ScoreC1"];

            // check if the user has a previous score on the test
            // if they do they must reset their statistics to re-take it
            if (C1Score != -1)
            {
                MessageBox.Show("You already have taken this test. " + Environment.NewLine +
                    "Your final score on chapter 1 is :" + C1Score + "/100." + Environment.NewLine +
                    "If you wish to re-take the test, reset your statistics.","Attention!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult m = MessageBox.Show("Warning!" + Environment.NewLine +
                "This action will start a timed exam that you can only take ONCE."
                + Environment.NewLine + "You will have limited time to answer questions, and your score will be recorded to your statistics."
                + Environment.NewLine + "Are you sure you want to continue ? "
                , "WARNING!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (m == DialogResult.Yes)
            {
                if (C1Test.Obj == null)
                    C1Test.Obj = new C1Test();

                C1Test.Obj.Init();
                C1Test.Obj.Show();

                Hide();
            }

        }
    }
}
