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
    public partial class FormAddUser : Form
    {
        FBSqlHelper helper = new FBSqlHelper();
        public FormAddUser()
        {
            InitializeComponent();

        }

        public Boolean CheckBeforeSave()
        {

            if (string.IsNullOrEmpty(txtUser_code.Text))
            {
                MessageBox.Show("工号不能为空!");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtUser_Name.Text))
            {
                MessageBox.Show("用户名不能为空!");
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("密码不能为空!");
                return false;
            }
            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sqlstring = string.Format("insert into gm_user (user_code,user_name,user_password,user_type) values ('{0}','{1}','{2}','{3}')",
                  txtUser_code.Text.Trim(), txtUser_Name.Text.Trim(), txtPassword.Text.Trim(), rdoAdmin.Checked ? "1" : "2");
            if (!CheckBeforeSave())
            {
                return;
            }
            else

                try
                {
                    int count = helper.ExecuteNonQuery(sqlstring);
                    if (count == 1)
                    {
                        MessageBox.Show("添加成功!");
                    }
                    clear();
                }
                catch (Exception)
                {

                    throw;
                }

        }

        private void clear()
        {
            txtUser_Name.Text=txtPassword.Text=txtUser_code.Text = null;
            rdoAdmin.Checked = false;
            txtUser_code.Focus();
        }

        private void txtUser_code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtUser_Name.Focus();
            }
        }

        private void txtUser_Name_KeyDown(object sender, KeyEventArgs e)
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
                this.btnSave.Focus();
            }
        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            btnSave_Click(sender,e);
        }
    }
}
