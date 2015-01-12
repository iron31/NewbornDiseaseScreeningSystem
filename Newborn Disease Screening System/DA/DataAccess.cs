using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Text.RegularExpressions;

namespace Newborn_Disease_Screening_System.DA
{
    public partial class DataAccess
    {
        /// <summary>
        /// 判断页面是否存在
        /// </summary>
        /// <param name="PageTitle">页面标题</param>
        /// <returns></returns>
        public static bool PageIsExist(string PageTitle, TabControl tc)
        {
            for (int i = 0; i <= tc.TabPages.Count - 1; i++)
            {
                if (tc.TabPages[i].Text.Equals(PageTitle))
                {
                    tc.SelectedTab = tc.TabPages[i];
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// 增加一个tabpage
        /// </summary>
        /// <param name="pageTitle">tabpage标题名</param>
        /// <param name="pageName">tabpage对象名</param>
        /// <param name="userControl">用户控件</param>
        /// <param name="tabControl">tabControl对象</param>
        public static void addTabPage(string pageTitle, string pageName, Control userControl, TabControl tabControl)
        {
            userControl.Dock = DockStyle.Fill;
            TabPage tabpage = new TabPage(pageTitle);
            tabpage.Name = pageName;
            tabpage.Controls.Add(userControl);
            tabControl.Controls.Add(tabpage);
        }

        /// <summary>
        /// 移除一个tabpage
        /// </summary>
        /// <param name="pageTitle"></param>
        /// <param name="userControl"></param>
        /// <param name="tabControl"></param>
        public static void removeTabPage(string pageTitle, TabControl tc)
        {
            //if (PageIsExist(pageTitle, tabControl))
            //{
            //    tabControl.Controls.Remove(userControl);
            //}
            for (int i = 0; i <= tc.TabPages.Count - 1; i++)
            {
                if (tc.TabPages[i].Text.Equals(pageTitle))
                {
                    tc.Controls.RemoveAt(i);
                }
            }

        }
        /// <summary>
        /// 选择页面
        /// </summary>
        /// <param name="pageName">tabpage对象名</param>
        /// <param name="refid">科室与专家的关联id，若为空查询全部，否则查询对应的科室</param>
        /// <param name="userControl">用户控件</param>
        /// <param name="tabControl">tabControl对象</param>
        /// 
        public static void selectTabPage(string pageName, string refid, Control userControl, TabControl tabControl)
        {
            Type type = userControl.GetType();
            TabPage tabpage = tabControl.TabPages[pageName];

            //ExpertIntroduction expert;
            //InhosFeeList inhosFee;
            //ClinicFeeList clinicFee;

            //switch (type.Name.ToString())
            //{
            //    case "HosIntroduce":
            //        break;

            //    case "DeptIntroductionNew":
            //        break;

            //    case "ExpertIntroduction":
            //        //tabpage = tabControl.TabPages[pageName];
            //        expert = (ExpertIntroduction)tabpage.Controls[0];
            //        expert.getExpertInfo(refid);
            //        break;

            //    case "DoctorQueue":
            //        break;

            //    case "CostIntroduce":
            //        break;

            //    case "InhosFeeList":
            //        inhosFee = (InhosFeeList)tabpage.Controls[0];
            //        inhosFee.inHosClear();
            //        break;

            //    case "ClinicFeeList":
            //        clinicFee = (ClinicFeeList)tabpage.Controls[0];
            //        clinicFee.clinicClear();
            //        break;
            //}

            tabControl.SelectedTab = tabpage;
        }

        public static void BackPage(string pageName, TabControl tabControl)
        {
            tabControl.SelectedTab = tabControl.TabPages[pageName];
        }

        ///// <summary>
        ///// 消息结果
        ///// </summary>
        //public enum Result
        //{
        //    /// <summary>
        //    /// 是
        //    /// </summary>
        //    Yes = 1,
        //    /// <summary>
        //    /// 否
        //    /// </summary>
        //    No = 2,
        //    /// <summary>
        //    /// 确定
        //    /// </summary>
        //    Ok = 3,
        //    /// <summary>
        //    /// 取消
        //    /// </summary>
        //    Cancel = 4,
        //    /// <summary>
        //    /// 重试
        //    /// </summary>
        //    Retry = 5,
        //    /// <summary>
        //    /// 空
        //    /// </summary>
        //    None = 6
        //}

        /// <summary>
        /// 判断输入是否是数字,可以是小数
        /// </summary>
        /// <param name="e"></param>
        public static void checkNumber(string noString,KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (noString.Length <= 0)
                    e.Handled = true;
                //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(noString, out oldf);
                    b2 = float.TryParse(noString + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            } 
        }
        /// <summary>
        /// 不可输入小数点
        /// </summary>
        /// <param name="noString"></param>
        /// <param name="e"></param>
        /// <param name="type"></param>
        public static void checkNumber(string noString, KeyPressEventArgs e, string type)
        {
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }


        //public static bool IsNumber(String strNumber)
        //{
        //    Regex objNotNumberPattern = new Regex("[^0-9.-]");
        //    Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
        //    Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
        //    String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
        //    String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
        //    Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

        //    return !objNotNumberPattern.IsMatch(strNumber) &&
        //    !objTwoDotPattern.IsMatch(strNumber) &&
        //    !objTwoMinusPattern.IsMatch(strNumber) &&
        //    objNumberPattern.IsMatch(strNumber);
        //}

        /// <summary>
        /// 获取当前机器网卡
        /// </summary>
        /// <returns></returns>
        public static string getHostMac()
        {
            string mac = "";
            ManagementClass mc;
            mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (mo["IPEnabled"].ToString() == "True")
                    mac = mo["MacAddress"].ToString();
            }
            return mac;
        }
    }
}
