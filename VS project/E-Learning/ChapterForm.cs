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
            if (Chapter2Form.Obj == null)
                Chapter2Form.Obj = new Chapter2Form();

            Chapter2Form.Obj.Init();
            Chapter2Form.Obj.Show();

            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Chapter3Form.Obj == null)
                Chapter3Form.Obj = new Chapter3Form();

            Chapter3Form.Obj.Init();
            Chapter3Form.Obj.Show();

            Hide();
        }
    }
}
