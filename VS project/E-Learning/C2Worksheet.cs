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
    public partial class C2Worksheet : Form
    {
        public static C2Worksheet Obj;
        public void Init()
        {
            TextBox[] inputBoxes = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16 };
            CheckBox[] checkBoxes = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6 };

            foreach (TextBox i in inputBoxes)
            {
                i.Text = String.Empty;
            }

            foreach (CheckBox j in checkBoxes)
            {
                j.Checked = false;
            }

            CenterToScreen();
            
        }

        public C2Worksheet()
        {
            InitializeComponent();
        }

        bool hasAnswers()
        {
            TextBox[] inputBoxes = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16 };

            foreach (TextBox i in inputBoxes)
                if (i.Text != String.Empty)
                    return true;

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] inputBoxes = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16 };
            CheckBox[] checkBoxes = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6 };

            int correctAnswers = 0;
            int wrongAnswers = 0;

            if (inputBoxes[0].Text == "8000" &&
                inputBoxes[1].Text == "200" &&
                inputBoxes[2].Text == "50" &&
                inputBoxes[3].Text == "9")
            {
                correctAnswers += 1;
                checkBoxes[0].Checked = true;
            }
            else
            {
                checkBoxes[0].Checked = false;
                wrongAnswers += 1;
            }
                

            if (inputBoxes[7].Text == "5000" &&
                inputBoxes[6].Text == "400" &&
                inputBoxes[5].Text == "10" &&
                inputBoxes[4].Text == "8")
            {
                correctAnswers += 1;
                checkBoxes[1].Checked = true;
            }
            else
            {
                checkBoxes[1].Checked = false;
                wrongAnswers += 1;
            }    
                

            if (inputBoxes[8].Text == "50000" &&
                inputBoxes[9].Text == "2000" &&
                inputBoxes[10].Text == "0" &&
                inputBoxes[11].Text == "60" &&
                inputBoxes[12].Text == "1" )
            {
                correctAnswers += 1;
                checkBoxes[2].Checked = true;
            }
            else
            {
                checkBoxes[2].Checked = false;
                wrongAnswers += 1;
            }


            if(inputBoxes[13].Text == "9003")
            {
                correctAnswers += 1;
                checkBoxes[3].Checked = true;
            }
            else
            {
                checkBoxes[3].Checked = false;
                wrongAnswers += 1;
            }


            if (inputBoxes[14].Text == "7218")
            {
                correctAnswers += 1;
                checkBoxes[4].Checked = true;
            }
            else
            {
                checkBoxes[4].Checked = false;
                wrongAnswers += 1;
            }

            if (inputBoxes[15].Text == "2540")
            {
                correctAnswers += 1;
                checkBoxes[5].Checked = true;
            }
            else
            {
                checkBoxes[5].Checked = false;
                wrongAnswers += 1;
            }


            MainForm.Obj.UserRow["CorrectAnswersC2"] = correctAnswers + (int)MainForm.Obj.UserRow["CorrectAnswersC2"];
            MainForm.Obj.UserRow["WrongAnswersC2"] = wrongAnswers + (int)MainForm.Obj.UserRow["WrongAnswersC2"];
            MainForm.Obj.dataSetObj.WriteXml("C:\\E-Learning\\StatisticsDatabase.xml");

            MessageBox.Show("Correct answers : " + correctAnswers + Environment.NewLine + "Wrong answers : " + wrongAnswers, "Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (wrongAnswers == 0)
                MessageBox.Show("Excellent work! Keep it up!", "Great job!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (hasAnswers())
            {
                DialogResult m = MessageBox.Show("Are you sure you want to go back? " + Environment.NewLine + "You will loose your current answers!", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (m == DialogResult.Yes)
                {
                    Chapter2Form.Obj.Init();
                    Chapter2Form.Obj.Show();
                    Hide();
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
    }
}
