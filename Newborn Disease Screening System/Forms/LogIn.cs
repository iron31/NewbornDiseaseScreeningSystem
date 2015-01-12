using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Threading;
using Newborn_Disease_Screening_System.DA;
namespace Newborn_Disease_Screening_System.Forms
{
    public partial class LogIn : Form
    {
        FBSqlHelper helper = new FBSqlHelper();
        public bool status = false;
        public LogIn()
        {
            InitializeComponent();
            //FBSqlHelper helper = new FBSqlHelper();
            ////string strSql = string.Format("Select * From gm_user gur where gur.user_code='{0}' and gur.user_password='{1}'".ToUpper(), "zhaoliang", "81997694");
            //string strSql = string.Format("update gm_user gur set user_password='{0}' where gur.user_code='{1}' and gur.user_password='{2}'".ToUpper(), "8888","zhaoliang", "81997694");
            ////DataTable dt = helper.GetDataTable(strSql);
            
            //int i = helper.ExecuteNonQuery(strSql);
            //Console.WriteLine("Hello");
        }

        #region 事件
       

        private void txtUserCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogIn.Focus();
            }
        }

        private void btnLogIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogIn_Click(sender, e);
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            
            if (!checkLog())
            {
                return;
            }
            else
                status = true;
                logInTo();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            status = false;
        }
        #endregion
        


        #region 方法
       
        /// <summary>
        /// 登录
        /// </summary>
        public void logInTo()
        {
            string strSql = string.Format("Select * From gm_user gur where gur.user_code='{0}' and gur.user_password='{1}' and status='1'".ToUpper(), txtUserCode.Text.Trim(), txtPassword.Text.Trim());
            DataTable dt = helper.GetDataTable(strSql);
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("用户名或密码错误！", "警告", MessageBoxButtons.OK);
               
                txtPassword.Text = null;
                txtPassword.Focus();
                return;
            }else if(dt.Rows.Count==1)
            {
                
                Entity.GmUser.User_id = int.Parse(dt.Rows[0]["user_id"].ToString().Trim());
                Entity.GmUser.User_code = dt.Rows[0]["user_code"].ToString().Trim();
                Entity.GmUser.User_name = dt.Rows[0]["user_name"].ToString().Trim();
                Entity.GmUser.User_type = dt.Rows[0]["user_type"].ToString().Trim();
                Entity.GmUser.Beg_no = dt.Rows[0]["beg_no"].ToString().Trim();
                Entity.GmUser.Current_no = dt.Rows[0]["current_no"].ToString().Trim();
                Entity.GmUser.End_no = dt.Rows[0]["end_no"].ToString().Trim();
                Entity.GmUser.Status =char.Parse(dt.Rows[0]["status"].ToString().Trim());

                if (Entity.GmUser.User_type != "0")
                {
                    if(!role())
                    {
                        MessageBox.Show("本机未获得授权,请联系管理员!");
                        return;
                    }
                }
                MessageBox.Show("登录成功!");
                //Thread thread = new Thread(new ThreadStart(FormStart));//这里可能有人看不懂，ThreadStart方法参数是上面那个方法名，对方法被作为参数了，如果你看过委托就会了，当然这里不是讨论委托。
                //thread.Start();//定义1个线程；执行FormsStrat函数；
               
                this.Close();
            }
        }

        public Boolean checkLog()
        {
            
            if (string.IsNullOrEmpty(txtUserCode.Text))
            {
                MessageBox.Show("请输入用户工号!");
                txtUserCode.Focus();
                return  false;
                
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("请输入密码!");
                txtPassword.Focus();
                return false;
            }
            return true;
        }


        //private void FormStart()//声明一个发开Form2的方法
        //{
        //    Application.Run(new MainForm());//运行1个新的程序窗口
        //}

        private bool role()
        {
            try
            {
                string sqlstring = string.Format("select * from gm_params gps where gps.types='MAC' and gps.TYPE_VALUE='{0}'", DA.DataAccess.getHostMac());
                DataTable dt = helper.GetDataTable(sqlstring);
                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0]["status"].ToString() == "1")
                    {
                        //MessageBox.Show("本机已获得授权!");
                        return true;
                    }
                }
            }
            catch(Exception e)
            {
                return false; 
                throw;
            }
            return false;   
        }
        #endregion

        

       
    }
}
