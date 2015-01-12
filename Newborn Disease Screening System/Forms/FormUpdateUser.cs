using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newborn_Disease_Screening_System.DA;

namespace Newborn_Disease_Screening_System.Forms
{
    public partial class FormUpdateUser : Form
    {
        string _flag = string.Empty;
        string _key = string.Empty;
        FBSqlHelper _sqlhelp = new FBSqlHelper();
        DataTable _dt = new DataTable();
        int _count = 0;
     
        public FormUpdateUser(string flag,string key)
        {
            InitializeComponent();
            _flag = flag;
            _key = key;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!checkNull())return;
            if (_flag == "update")
            {
                string[] param = {txtUserName.Text.Trim(),txtPassWord.Text.Trim(),(rdoType.SelectedIndex+1).ToString(),
                                   _key };
                string sql = string.Format(@"UPDATE
                                              GM_USER
                                            SET
                                              USER_NAME = '{0}',
                                              USER_PASSWORD = '{1}',
                                              USER_TYPE = '{2}'
                                            WHERE
                                              USER_ID = '{3}'", param);
                _count = _sqlhelp.ExecuteNonQuery(sql);
            }
            else if (_flag == "add")
            {
                string[] param = {txtCardNo.Text.Trim(),txtUserName.Text.Trim(),txtPassWord.Text.Trim(),(rdoType.SelectedIndex+1).ToString(),
                                    };
                 string sql = string.Format(@"INSERT INTO GM_USER
                                            ( USER_CODE, USER_NAME, USER_PASSWORD, USER_TYPE)
                                        VALUES
                                            ( '{0}', '{1}', '{2}', '{3}')", param);
                _count = _sqlhelp.ExecuteNonQuery(sql);
   
            }
            if (_count == 1)
            {
                MessageBox.Show("保存成功!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void FormUpdateUser_Load(object sender, EventArgs e)
        {
            if (_flag == "update")
            {
                this.Text = "修改用户";
                string sql = string.Format(@"select * from gm_user gur
                            where gur.user_id= {0}", _key);
                _dt = _sqlhelp.GetDataTable(sql);
                if (_dt.Rows.Count > 0)
                {
                    txtCardNo.Text=_dt.Rows[0]["USER_CODE"].ToString();
                    txtUserName.Text=_dt.Rows[0]["USER_NAME"].ToString();
                    txtPassWord.Text=_dt.Rows[0]["USER_PASSWORD"].ToString();
                    rdoType.SelectedIndex=int.Parse(_dt.Rows[0]["USER_TYPE"].ToString())-1; 
                }
            }
            else
            {
                this.Text = "新增用户";
                txtCardNo.Enabled = true;
            }
        }

        private bool checkNull()
        {
            if(string.IsNullOrEmpty(txtCardNo.Text))
            {
                MessageBox.Show("工号不能为空!");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtUserName.Text))
            {
                MessageBox.Show("用户名不能为空!");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtPassWord.Text))
            {
                txtPassWord.Text = "8888";
            }
            if (this.rdoType.SelectedIndex==-1)
            {
                rdoType.SelectedIndex = 1;
            }
            return true;
        }
    }
}
