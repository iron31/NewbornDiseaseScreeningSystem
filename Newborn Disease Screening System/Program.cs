using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newborn_Disease_Screening_System.Forms;

namespace Newborn_Disease_Screening_System
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //Account account = new Account();
            //if (account.ProcessLogin())
            //{
            //    //Utils.LogMessage("Application.Run...");
                Application.Run(new MainForm());
            //}
        }



        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            //显示异常信息
            try
            {
                MessageBox.Show(e.Exception.Message);
            }
            catch
            {
                // ToDo... SaveToLocal
            }
        }
    }
}
