using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Collections;

namespace E_Learning
{
    static class Program
    {
        public static bool Exit = false;

        //public static ChromiumWebBrowser chromeBrowser;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm.Obj = new LoginForm();
            Application.Run(LoginForm.Obj);
            
        }
    }
}
