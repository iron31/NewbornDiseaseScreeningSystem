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
    public partial class FormEditCardNo : Form
    {
        FBSqlHelper _helper = new FBSqlHelper();


        public FormEditCardNo()
        {
            InitializeComponent();
        }


        private bool checkCardNo()
        {
            if (string.IsNullOrEmpty(txtBegCardNo.Text) || string.IsNullOrEmpty(txtEndCardNo.Text) || string.IsNullOrEmpty(txtCurrentCardNo.Text))
            {

                if (string.IsNullOrEmpty(this.txtBegCardNo.Text))
                {
                    this.txtBegCardNo.Focus();
                }
                else if (string.IsNullOrEmpty(txtEndCardNo.Text))
                {
                    txtEndCardNo.Focus();
                }
                else
                {
                    txtCurrentCardNo.Focus();
                }
                MessageBox.Show("起始卡号,当前卡号和结束卡号不能为空,请输入!", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //else if (!DA.DataAccess.IsNumber(txtBegCardNo.Text))
            //{
            //    this.txtBegCardNo.Focus();
            //    this.txtBegCardNo.Text = string.Empty;
            //    MessageBox.Show("只能输入数字");
            //    return false;
            //}
            //else if (!DA.DataAccess.IsNumber(txtEndCardNo.Text))
            //{
            //    this.txtEndCardNo.Focus();
            //    this.txtEndCardNo.Text = string.Empty;
            //    MessageBox.Show("只能输入数字");
            //    return false;
            //}
            //else if (!DA.DataAccess.IsNumber(txtCurrentCardNo.Text))
            //{
            //    this.txtCurrentCardNo.Focus();
            //    this.txtCurrentCardNo.Text = string.Empty;
            //    MessageBox.Show("只能输入数字");
            //    return false;
            //}
            else if (double.Parse(txtBegCardNo.Text.Trim()) - double.Parse(txtCurrentCardNo.Text.Trim()) > 0)
            {
                MessageBox.Show("当前号码不能小于起始号码!");
                txtEndCardNo.Focus();
                return false;
            }
            else if (double.Parse(txtCurrentCardNo.Text.Trim()) - double.Parse(txtEndCardNo.Text.Trim()) > 0)
            {
                MessageBox.Show("结束号码不能小于当前号码!");
                txtEndCardNo.Focus();
                return false;
            }
            else
            {
                if (double.Parse(txtBegCardNo.Text.Trim()) - double.Parse(txtEndCardNo.Text.Trim()) > 0)
                {
                    MessageBox.Show("结束号码不能小于起始号码!");
                    txtEndCardNo.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = @"update gm_user set beg_no=?,current_no=?,end_no=? where user_id =?";
            object[] param = { txtBegCardNo.Text.Trim(), txtCurrentCardNo.Text.Trim(), txtEndCardNo.Text.Trim(),Entity.GmUser.User_id };
            if (checkCardNo())
            {
                int count = _helper.ExecuteNonQuery(sql, param);
                if (count == 1)
                {
                    Entity.GmUser.Beg_no = txtBegCardNo.Text;
                    Entity.GmUser.Current_no = txtCurrentCardNo.Text;
                    Entity.GmUser.End_no = txtEndCardNo.Text;
                    MessageBox.Show("设置号码成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FormEditCardNo_Load(object sender, EventArgs e)
        {
            txtBegCardNo.Text = Entity.GmUser.Beg_no;
            txtCurrentCardNo.Text = Entity.GmUser.Current_no;
            txtEndCardNo.Text = Entity.GmUser.End_no;
            txtBegCardNo.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel ;
            this.Close();
        }

        private void txtBegCardNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            DA.DataAccess.checkNumber(txtBegCardNo.Text.Trim(),e,"");
        }

        private void txtCurrentCardNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            DA.DataAccess.checkNumber(txtCurrentCardNo.Text.Trim(), e,"");
        }

        private void txtEndCardNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            DA.DataAccess.checkNumber(txtEndCardNo.Text.Trim(), e,"");
        }
    }
}
