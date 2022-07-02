using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace E_Learning
{
    public partial class LoginForm : Form
    {
        public static string currentUser;
        public static LoginForm Obj;

        public LoginForm()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            CenterToScreen();
            currentUser = String.Empty;
            userNameBox.Text = String.Empty;
            pwBox.Text = String.Empty;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        // function to calculate hash of user's password for security
        static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string plainUserName = userNameBox.Text;
            string plainPW = pwBox.Text;

            // check for empty fields
            if (plainUserName == String.Empty || plainPW == String.Empty)
            {
                MessageBox.Show("Required fields cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // hash the user's pass before writing it to the data file
            string hashedPW = ComputeSha256Hash(plainPW);

            string userEntry = plainUserName + Environment.NewLine + hashedPW + Environment.NewLine;

            if(!File.Exists("C:\\E-Learning\\Users.data"))
            {
                Directory.CreateDirectory("C:\\E-Learning\\");
                File.WriteAllText("C:\\E-Learning\\Users.data", userEntry);
            }
            else
            {
                string[] AllCredentials = File.ReadAllLines("C:\\E-Learning\\Users.data");
                for (int i = 0; i < AllCredentials.Length; i=i+2)
                {
                    // check if the username already exists
                    if (AllCredentials[i] == plainUserName)
                    {
                        MessageBox.Show("Username is already in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                File.AppendAllText("C:\\E-Learning\\Users.data", userEntry);
            }

            userNameBox.Text = String.Empty;
            pwBox.Text = String.Empty;

            MessageBox.Show("Registration successful.", "Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] AllCredentials = File.ReadAllLines("C:\\E-Learning\\Users.data");

                string plainUserName = userNameBox.Text;
                string plainPW = pwBox.Text;

                // hash the user's password
                string hashedPW = ComputeSha256Hash(plainPW);

                for (int i = 0; i < AllCredentials.Length; i=i+2)
                {
                    // check in the data file for the user's HASHED password (not the plain text one)
                    if (plainUserName == AllCredentials[i] && hashedPW == AllCredentials[i+1])
                    {
                        MessageBox.Show("Login successful.", "Logged in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        currentUser = plainUserName;

                        if (MainForm.Obj == null)
                            MainForm.Obj = new MainForm();

                        MainForm.Obj.Init(i); // launch mainform with the user ID (i, the index of the loop finding the user is the ID)
                        MainForm.Obj.Show();
                        

                        Hide();
                        return;
                    }
                }

                MessageBox.Show("Invalid credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("No registered users exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void pwBox_KeyDown(object sender, KeyEventArgs e)
        {
            // handle enter key, in case user wants to hit enter instead of clicking the button
            e.Handled = true;
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
        }

        private void userNameBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
