using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;

namespace E_Learning
{
    // struct with all the paths of files for a chapter
    public struct ChapterFiles
    {
        public string zipPath;
        public string extractPath;
        public string indexPath;
        public byte[] ZIP;
    }
    public partial class TheoryViewer : Form
    {
        public static TheoryViewer Obj;
        public static ChapterFiles[] AllChapters;

        public int currentChapter;
        
        public static void LoadChapters()
        {
            // variable that holds all the paths for all chapters
            AllChapters = new ChapterFiles[3];

            AllChapters[0].zipPath = "C:\\E-Learning\\OrderOfOperations.zip";
            AllChapters[0].extractPath = "C:\\E-Learning\\";
            AllChapters[0].indexPath = "C:\\E-Learning\\" + "OrderOfOperations.html";
            AllChapters[0].ZIP = Properties.Resources.OrderOfOperationsZIP;

            AllChapters[1].zipPath = "C:\\E-Learning\\NaturalNumbers.zip";
            AllChapters[1].extractPath = "C:\\E-Learning\\";
            AllChapters[1].indexPath = "C:\\E-Learning\\" + "NaturalNumbers.html";
            AllChapters[1].ZIP = Properties.Resources.NaturalNumbers;

            AllChapters[2].zipPath = "C:\\E-Learning\\Inequality.zip";
            AllChapters[2].extractPath = "C:\\E-Learning\\";
            AllChapters[2].indexPath = "C:\\E-Learning\\" + "Inequality.html";
            AllChapters[2].ZIP = Properties.Resources.Inequality;
        }

        // load chapter to the viewer (0,1,2) (3 chapters)
        public void LoadChapter(int c)
        {
            File.WriteAllBytes(AllChapters[c].zipPath, AllChapters[c].ZIP);
            if (!File.Exists(AllChapters[c].indexPath))
                ZipFile.ExtractToDirectory(AllChapters[c].zipPath, AllChapters[c].extractPath);

            webBrowser1.Navigate(AllChapters[c].indexPath);
        }

        // initialize the viewer (load chapter then start timer for statistics)
        public void Init(int Chapter)
        {
            CenterToScreen();

            if (AllChapters == null)
                TheoryViewer.LoadChapters();

            currentChapter = Chapter;
            LoadChapter(currentChapter);

            timer1.Start();
        }
        public TheoryViewer()
        {
            InitializeComponent();
        }

        // return to the corresponding chapter menu
        private void C1Theory_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Parent = null;
            e.Cancel = true;

            timer1.Stop();
            MainForm.Obj.dataSetObj.WriteXml("C:\\E-Learning\\StatisticsDatabase.xml");

            switch (currentChapter)
            {
                case 0:
                    Chapter1Form.Obj.Show();
                    Chapter1Form.Obj.Init();
                    break;
                case 1:
                    Chapter2Form.Obj.Show();
                    Chapter2Form.Obj.Init();
                    break;
                case 2:
                    Chapter3Form.Obj.Show();
                    Chapter3Form.Obj.Init();
                    break;
            }

            Hide();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        // count time for each chapter studied
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch(currentChapter)
            {
                case 0:
                    MainForm.Obj.UserRow["C1Time"] = (int)MainForm.Obj.UserRow["C1Time"] + 1;
                    break;
                case 1:
                    MainForm.Obj.UserRow["C2Time"] = (int)MainForm.Obj.UserRow["C2Time"] + 1;
                    break;
                case 2:
                    MainForm.Obj.UserRow["C3Time"] = (int)MainForm.Obj.UserRow["C3Time"] + 1;
                    break;
            }
        }
    }
}
