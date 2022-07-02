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
    public partial class C1Worksheet : Form
    {
        public static C1Worksheet Obj;

        public void Init()
        {
            CenterToScreen();
            TextBox[] inputBoxes = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10 };
            CheckBox[] checkBoxes = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10 };
            button1.Enabled = true;
            for (int i = 0; i < 10; i++)
            {
                inputBoxes[i].Text = String.Empty;
                checkBoxes[i].Checked = false;
            }
        }
        public C1Worksheet()
        { 
            InitializeComponent();
            Init();
        }

        bool hasAnswers()
        {
            TextBox[] inputBoxes = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10 };

            foreach (TextBox i in inputBoxes)
                if (i.Text != String.Empty)
                    return true;

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] inputBoxes = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10 };
            CheckBox[] checkBoxes = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10 };
            int[] answers = { 56,64,4,53,31,16,54,180,36,2 };

            int correctAnswers = 0;
            int wrongAnswers = 0;
            for (int i = 0; i < 10; i++)
            {
                if (inputBoxes[i].Text == String.Empty)
                {
                    wrongAnswers++;
                    checkBoxes[i].Checked = false;
                }
                else if (answers[i] == Int32.Parse(inputBoxes[i].Text))
                {
                    correctAnswers++;
                    checkBoxes[i].Checked = true;
                }
            }

            MainForm.Obj.UserRow["CorrectAnswersC1"] = correctAnswers + (int)MainForm.Obj.UserRow["CorrectAnswersC1"];
            MainForm.Obj.UserRow["WrongAnswersC1"] = wrongAnswers + (int)MainForm.Obj.UserRow["WrongAnswersC1"];
            MainForm.Obj.dataSetObj.WriteXml("C:\\E-Learning\\StatisticsDatabase.xml");

            MessageBox.Show("Correct answers : " + correctAnswers + Environment.NewLine + "Wrong answers : " + wrongAnswers, "Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            if (wrongAnswers == 0)
                MessageBox.Show("Excellent work! Keep it up!", "Great job!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (hasAnswers())
            {
                DialogResult m = MessageBox.Show("Are you sure you want to go back? " + Environment.NewLine + "You will loose your current answers!", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (m == DialogResult.Yes)
                {
                    Chapter1Form.Obj.Init();
                    Chapter1Form.Obj.Show();
                    Hide();
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
    }
}
