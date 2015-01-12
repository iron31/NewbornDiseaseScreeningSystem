using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newborn_Disease_Screening_System.Forms;

namespace Newborn_Disease_Screening_System
{
    public class Account
    {
        /// <summary>
        /// 处理登录
        /// </summary>
        /// <returns></returns>
        public bool ProcessLogin()
        {
            //Utils.LogMessage("ProcessLogin()");
            using (LogIn frmLogin = new LogIn())
            {
                //Utils.LogMessage("using (Forms.Login frmLogin = new ESoSi.HiS.Forms.Login())");
                frmLogin.ShowDialog();
                return true;
            }
        }
    }
}
