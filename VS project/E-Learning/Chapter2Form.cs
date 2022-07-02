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
    public partial class Chapter2Form : Form
    {
        public static Chapter2Form Obj;

        public void Init()
        {
            CenterToScreen();
        }
        public Chapter2Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TheoryViewer.Obj == null)
                TheoryViewer.Obj = new TheoryViewer();

            TheoryViewer.Obj.Init(1);
            TheoryViewer.Obj.Show();

            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChapterForm.Obj.Show();
            ChapterForm.Obj.Init();

            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (C2Worksheet.Obj == null)
                C2Worksheet.Obj = new C2Worksheet();

            C2Worksheet.Obj.Init();
            C2Worksheet.Obj.Show();

            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int C2Score = (int)MainForm.Obj.UserRow["ScoreC2"];

            if (C2Score != -1)
            {
                MessageBox.Show("You already have taken this test. " + Environment.NewLine +
                    "Your final score on chapter 2 is :" + C2Score + "/100." + Environment.NewLine +
                    "If you wish to re-take the test, either reset your statistics or reset the chapter individually from the statistics tab.", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult m = MessageBox.Show("Warning!" + Environment.NewLine +
                "This action will start a timed exam that you can only take ONCE."
                + Environment.NewLine + "You will have limited time to answer questions, and your score will be recorded to your statistics."
                + Environment.NewLine + "Are you sure you want to continue ? "
                , "WARNING!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (m == DialogResult.Yes)
            {
                if (C2Test.Obj == null)
                    C2Test.Obj = new C2Test();

                C2Test.Obj.Init();
                C2Test.Obj.Show();

                Hide();
            }
        }
    }
}
