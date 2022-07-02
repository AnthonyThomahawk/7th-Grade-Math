using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace E_Learning
{
    public partial class MainForm : Form
    {
        public static MainForm Obj;
        public DataRow UserRow;
        public int UUID;

        // function that returns the Row from the DB, where the current user's data is
        public DataRow GetUserRow(int id)
        {
            // search all rows until the given ID is found, then return the row
            foreach (DataRow DR in dataSetObj.Tables[0].Rows)
            {
                if ((int)DR["id"] == id)
                {
                    return DR;
                }
            }

            // if not found return null
            return null;
        }

        public void Init(int UID)
        {
            label2.Text = "Welcome back, " + LoginForm.currentUser + "!";
            CenterToScreen();

            if (UID != -1) // if the user id is not -1, this means we have a user login
            {
                UUID = UID; // copy to global variable

                // read the DB from file, if it doesnt exist then create it
                if (File.Exists("C:\\E-Learning\\StatisticsDatabase.xml"))
                    dataSetObj.ReadXml("C:\\E-Learning\\StatisticsDatabase.xml");
                else
                    dataSetObj.WriteXml("C:\\E-Learning\\StatisticsDatabase.xml");

                UserRow = GetUserRow(UID);

                // if user doesnt exist in DB, create a row for them
                if (UserRow == null)
                {
                    dataSetObj.Tables[0].Rows.Add(UID);
                    UserRow = GetUserRow(UID);
                    dataSetObj.WriteXml("C:\\E-Learning\\StatisticsDatabase.xml");
                }
            }

        }
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult m = MessageBox.Show("Are you sure you want to exit?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (m == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult m = MessageBox.Show("Are you sure you want to change user?", "Change user?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (m == DialogResult.Yes)
            {
                LoginForm.Obj.Init();
                LoginForm.Obj.Show();
                Hide();
            }
            
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ChapterForm.Obj == null)
                ChapterForm.Obj = new ChapterForm();

            ChapterForm.Obj.Init();
            ChapterForm.Obj.Show();
            
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult m = MessageBox.Show("This action will permanently delete all recorded statistics for this user" + Environment.NewLine +
                "This action is irreversible." + Environment.NewLine +
                "Are you sure you want to continue?", "WARNING!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (m == DialogResult.Yes)
            {
                // delete the user row from DB
                UserRow.Delete();

                // create a new, empty one
                dataSetObj.Tables[0].Rows.Add(UUID);
                UserRow = GetUserRow(UUID);
                dataSetObj.WriteXml("C:\\E-Learning\\StatisticsDatabase.xml");

                MessageBox.Show("Your statistics have been reset.", "Stat reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (StatisticsView.Obj == null)
                StatisticsView.Obj = new StatisticsView();

            StatisticsView.Obj.Init();
            StatisticsView.Obj.Show();

            Hide();
        }
    }
}
