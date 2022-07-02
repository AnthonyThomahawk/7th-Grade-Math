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
    public partial class Chapter3Form : Form
    {
        public static Chapter3Form Obj;

        public void Init()
        {
            CenterToScreen();
        }

        public Chapter3Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TheoryViewer.Obj == null)
                TheoryViewer.Obj = new TheoryViewer();

            TheoryViewer.Obj.Init(2);
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
            if (C3Worksheet.Obj == null)
                C3Worksheet.Obj = new C3Worksheet();

            C3Worksheet.Obj.Init();
            C3Worksheet.Obj.Show();

            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int C3Score = (int)MainForm.Obj.UserRow["ScoreC3"];

            if (C3Score != -1)
            {
                MessageBox.Show("You already have taken this test. " + Environment.NewLine +
                    "Your final score on chapter 3 is :" + C3Score + "/100." + Environment.NewLine +
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
                if (C3Test.Obj == null)
                    C3Test.Obj = new C3Test();

                C3Test.Obj.Init();
                C3Test.Obj.Show();

                Hide();
            }
        }
    }
}
