using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.ComponentModel;
using Newborn_Disease_Screening_System.DA;
using Newborn_Disease_Screening_System.UC;
using Newborn_Disease_Screening_System.Forms;

namespace Newborn_Disease_Screening_System.Forms
{
    public partial class MainForm : Form
    {
        FBSqlHelper sqlhelp = new FBSqlHelper();
        UCCardInfo _cardInfo;
        UCFirstResultInfo _firstResultInfo;
        UCOrganizationInfo _OrganizationInfo;
        UCSecondResultInfo _secondResultInfo;
        UCParamsControl _paramsControl;
        UCFirstResultReport _firstReport;
        UCSecondResultReport _secondReport;
        UCFirstStatistics _firstStatistics;
        UCSecondStatistics _secondStatistics;
        TabControl tc;
        public MainForm()
        {
            InitializeComponent();
            tc = this.MainTabControl;
            tc.SizeMode = TabSizeMode.Fixed;
            tc.ItemSize = new Size(0, 1);

        }

        public void show()
        {
            tbUser_name.Text = "操作员:  " + Entity.GmUser.User_name;
            if (Entity.GmUser.User_type.Trim() == "2")
            {
                tsAddUser.Visible = false;
            } if (Entity.GmUser.User_type.Trim() == "0")
            {
                tsRemoveRole.Visible = tsGetRole.Visible = true;
            }
        }

        private void tsExit_Click(object sender, EventArgs e)
        {
            //Thread thread = new Thread(new ThreadStart(FormStart));
            //thread.Start();//定义1个线程；执行FormsStrat函数；

            DialogResult dr = MessageBox.Show("确定要退出吗?未保存的数据将丢失!", "警告", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }


            //DA.DataAccess.removeTabPage(tc.SelectedTab.Name, tc);
            //tc.SelectedTab = tc.TabPages["tbMainPage"];

        }

        //private void FormStart()
        //{
        //    Application.Run(new LogIn());//运行1个新的程序窗口
        //}

        private void tsChangePassword_Click(object sender, EventArgs e)
        {

        }

        private void tsAddUser_Click(object sender, EventArgs e)
        {
            FormAddUser adduser = new FormAddUser();
            adduser.ShowDialog();
        }

        private void tsGetRole_Click(object sender, EventArgs e)
        {
            string macAddress = DA.DataAccess.getHostMac();
            string sqlstring = string.Empty;
            int count = 0;
            try
            {
                sqlstring = string.Format("select * from gm_params gps where gps.types='MAC' and gps.TYPE_VALUE='{0}'", macAddress);
                DataTable dt = sqlhelp.GetDataTable(sqlstring);
                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0]["status"].ToString() == "1")
                    {
                        MessageBox.Show("本机已获得授权!");
                        return;
                    }
                    else if (dt.Rows[0]["status"].ToString() == "0")
                    {
                        sqlstring = string.Format(@"UPDATE GM_PARAMS GPS SET GPS.STATUS='1' WHERE  gps.status=0 and gps.types='MAC' and gps.TYPE_VALUE='{0}'", macAddress);
                        count = sqlhelp.ExecuteNonQuery(sqlstring);
                        if (count == 1)
                        {
                            MessageBox.Show("授权成功");
                        }
                    }


                }
                else
                {
                    sqlstring = string.Format(@"INSERT INTO GM_PARAMS (OBJECT_NAME, TYPE_VALUE, TYPES, STATUS)
                                            VALUES ('MACADDRESS','{0}','MAC','1')", macAddress);
                    count = sqlhelp.ExecuteNonQuery(sqlstring);
                    if (count == 1)
                    {
                        MessageBox.Show("授权成功");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void tsRemoveRole_Click(object sender, EventArgs e)
        {
            string macAddress = DA.DataAccess.getHostMac();
            string sqlstring = string.Empty;
            int count = 0;
            try
            {
                sqlstring = string.Format("select * from gm_params gps where gps.status=1 and gps.types='MAC' and gps.TYPE_VALUE='{0}'", macAddress);
                DataTable dt = sqlhelp.GetDataTable(sqlstring);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("本机未获得授权!");
                    return;
                }
                else
                    sqlstring = string.Format(@"UPDATE GM_PARAMS GPS SET GPS.STATUS='0' WHERE  gps.status=1 and gps.types='MAC' and gps.TYPE_VALUE='{0}'", macAddress);
                count = sqlhelp.ExecuteNonQuery(sqlstring);
                if (count == 1)
                {
                    MessageBox.Show("已取消授权!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        //public void returnMain()
        //{
        //    if (tc.TabPages.Count<=0)
        //    {
        //        return;
        //    }
        //    for (int i = 1; i < this.MainTabControl.TabPages.Count; i++)
        //    {
        //        this.MainTabControl.TabPages.RemoveAt(i);
        //    }
        //}


        private void tsCardInfo_Click(object sender, EventArgs e)
        {
            if (DA.DataAccess.PageIsExist("CardInfo", tc))
            {
                return;
            }
            _cardInfo = new UCCardInfo(tc);
            DA.DataAccess.addTabPage("CardInfo", "CardInfo", _cardInfo, tc);
            tc.SelectedTab = tc.TabPages["CardInfo"];
        }

        private void tsOrganization_Click(object sender, EventArgs e)
        {
            if (DA.DataAccess.PageIsExist("OrganizationInfo", tc))
            {
                return;
            }
            _OrganizationInfo = new UCOrganizationInfo(tc);
            DA.DataAccess.addTabPage("OrganizationInfo", "OrganizationInfo", _OrganizationInfo, tc);
            tc.SelectedTab = tc.TabPages["OrganizationInfo"];
        }
        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tc.SelectedTab.Name != "tbMainPage")
            {
                btnFirstResultInfo.Enabled=
                    btnFirstResultInform.Enabled=
                    btnFristResultReport.Enabled=
                    btnSecondResultInfo.Enabled=
                    btnSecondResultInform.Enabled=
                    button1.Enabled=
                    button2.Enabled =
                    button3.Enabled =
                    button4.Enabled =
                    button5.Enabled =
                    button6.Enabled =
                    button7.Enabled =
                    button8.Enabled =
                btnCardInfo.Enabled = false;
            }
            else
            {
                btnFirstResultInfo.Enabled =
                   btnFirstResultInform.Enabled =
                   btnFristResultReport.Enabled =
                   btnSecondResultInfo.Enabled =
                   btnSecondResultInform.Enabled =
                   button1.Enabled =
                   button2.Enabled =
                   button3.Enabled =
                   button4.Enabled =
                   button5.Enabled =
                   button6.Enabled =
                   button7.Enabled =
                   button8.Enabled =
                btnCardInfo.Enabled = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LogIn login = new LogIn();
            login.ShowDialog();
            if (login.status)
            {
                show();
            }
            else
                this.Close();

        }

        private void tsFirstResultInfo_Click(object sender, EventArgs e)
        {
            if (DA.DataAccess.PageIsExist("FirstResultInfo", tc))
            {
                return;
            }
            _firstResultInfo = new UCFirstResultInfo(tc);
            DA.DataAccess.addTabPage("FirstResultInfo", "FirstResultInfo", _firstResultInfo, tc);
            tc.SelectedTab = tc.TabPages["FirstResultInfo"];
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void tsSecondResultInfo_Click(object sender, EventArgs e)
        {
            if (DA.DataAccess.PageIsExist("SecondResultInfo", tc))
            {
                return;
            }
            _secondResultInfo = new UCSecondResultInfo(tc);
            DA.DataAccess.addTabPage("SecondResultInfo", "SecondResultInfo", _secondResultInfo, tc);
            tc.SelectedTab = tc.TabPages["SecondResultInfo"];
        }

        private void tsParams_Click(object sender, EventArgs e)
        {
            if (DA.DataAccess.PageIsExist("ParamsControl", tc))
            {
                return;
            }
            _paramsControl = new UCParamsControl(tc);
            DA.DataAccess.addTabPage("ParamsControl", "ParamsControl", _paramsControl, tc);
            tc.SelectedTab = tc.TabPages["ParamsControl"];
        }

        private void tsFristResultReport_Click(object sender, EventArgs e)
        {
            if (DA.DataAccess.PageIsExist("FirstResultReport", tc))
            {
                return;
            }
            _firstReport = new UCFirstResultReport(tc, "report");
            DA.DataAccess.addTabPage("FirstResultReport", "FirstResultReport", _firstReport, tc);
            tc.SelectedTab = tc.TabPages["FirstResultReport"];
        }

        private void tsQueryObject_Click(object sender, EventArgs e)
        {

            if (DA.DataAccess.PageIsExist("QueryObject", tc))
            {
                return;
            }
            UCObjectQuery objectquery = new UCObjectQuery(tc);
            DA.DataAccess.addTabPage("QueryObject", "QueryObject", objectquery, tc);
            tc.SelectedTab = tc.TabPages["QueryObject"];
        }

        private void tsFirstResultStatistics_Click(object sender, EventArgs e)
        {
            if (DA.DataAccess.PageIsExist("FirstStatistics", tc))
            {
                return;
            }
            _firstStatistics = new UCFirstStatistics(tc);
            DA.DataAccess.addTabPage("FirstStatistics", "FirstStatistics", _firstStatistics, tc);
            tc.SelectedTab = tc.TabPages["FirstStatistics"];
        }

        private void tsSecondResultStatistics_Click(object sender, EventArgs e)
        {
            if (DA.DataAccess.PageIsExist("SecondStatistics", tc))
            {
                return;
            }
            _secondStatistics = new UCSecondStatistics(tc);
            DA.DataAccess.addTabPage("SecondStatistics", "SecondStatistics", _secondStatistics, tc);
            tc.SelectedTab = tc.TabPages["SecondStatistics"];
        }

        private void tsFirstResultInform_Click(object sender, EventArgs e)
        {
            if (DA.DataAccess.PageIsExist("FirstResultInform", tc))
            {
                return;
            }
            _firstReport = new UCFirstResultReport(tc, "inform");
            DA.DataAccess.addTabPage("FirstResultInform", "FirstResultInform", _firstReport, tc);
            tc.SelectedTab = tc.TabPages["FirstResultInform"];
        }

        private void tsSecondResultReport_Click(object sender, EventArgs e)
        {
            if (DA.DataAccess.PageIsExist("SecondResultReport", tc))
            {
                return;
            }
            _secondReport = new UCSecondResultReport(tc, "report");
            DA.DataAccess.addTabPage("SecondResultReport", "SecondResultReport", _secondReport, tc);
            tc.SelectedTab = tc.TabPages["SecondResultReport"];
        }

        private void tsSecondResultInform_Click(object sender, EventArgs e)
        {
            if (DA.DataAccess.PageIsExist("SecondResultInform", tc))
            {
                return;
            }
            _secondReport = new UCSecondResultReport(tc, "inform");
            DA.DataAccess.addTabPage("SecondResultInform", "SecondResultInform", _secondReport, tc);
            tc.SelectedTab = tc.TabPages["SecondResultInform"];
        }

        private void tsRemind_Click(object sender, EventArgs e)
        {
            if (DA.DataAccess.PageIsExist("Remind", tc))
            {
                return;
            }
            UCRemind remind = new UCRemind(tc,"remind");
            DA.DataAccess.addTabPage("Remind", "Remind", remind, tc);
            tc.SelectedTab = tc.TabPages["Remind"];
        }

        private void tsWorkLoad_Click(object sender, EventArgs e)
        {

            if (DA.DataAccess.PageIsExist("WordLoad", tc))
            {
                return;
            }
            UCRemind wordLoad = new UCRemind(tc,"workload");
            DA.DataAccess.addTabPage("WordLoad", "WordLoad", wordLoad, tc);
            tc.SelectedTab = tc.TabPages["WordLoad"];
        }

        private void tsFirstReturn_Click(object sender, EventArgs e)
        {
            if (DA.DataAccess.PageIsExist("FirstReturn", tc))
            {
                return;
            }
            UCRemind firstreturn = new UCRemind(tc, "firstreturn");
            DA.DataAccess.addTabPage("FirstReturn", "FirstReturn", firstreturn, tc);
            tc.SelectedTab = tc.TabPages["FirstReturn"];
        }

        

    



    }
}
