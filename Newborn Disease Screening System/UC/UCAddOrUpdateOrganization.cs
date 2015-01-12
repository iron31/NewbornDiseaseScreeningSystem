using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newborn_Disease_Screening_System.DA;


namespace Newborn_Disease_Screening_System.UC
{
    public partial class UCAddOrUpdateOrganization : UserControl
    {
        #region 初始化
        private TabControl tc = null;
        string _flag;
        Entity.GmOrganization _gmorganization = new Entity.GmOrganization();
        FBSqlHelper _sqlhelp = new FBSqlHelper();
        public UCAddOrUpdateOrganization(TabControl tc, Entity.GmOrganization org, string flag)
        {
            InitializeComponent();
            this.tc = tc;
            this._flag = flag;
            if (_flag == "update")
            {
                _gmorganization = org;
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!checkValue())
            {
                return;
            };
            _gmorganization.Organization_code = txtOrgCode.Text.Trim();
            _gmorganization.Organization_name = txtOrgName.Text.Trim();
            _gmorganization.Organization_level = cbOrgLevel.SelectedValue.ToString();
            _gmorganization.Organization_belong = this.cbOrgBelong.SelectedValue.ToString();
            int count = 0;
            try
            {
                if (_flag == "insert")
                {
                    count = _gmorganization.addOrg(_gmorganization);

                }
                else if (_flag == "update")
                {
                    count = _gmorganization.updateOrg(_gmorganization);
                }
            }
            catch (Exception)
            {

                throw;
            }

            if (count == 1)
            {
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                txtOrgCode.Focus();
            }
        }

        private bool checkValue()
        {

            if (string.IsNullOrEmpty(txtOrgCode.Text))
            {
                MessageBox.Show("单位代码不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOrgCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtOrgName.Text))
            {
                MessageBox.Show("单位名称不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtOrgName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbOrgLevel.Text))
            {
                MessageBox.Show("单位级别不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbOrgLevel.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbOrgBelong.Text))
            {
                MessageBox.Show("单位归属不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cbOrgBelong.Focus();
                return false;
            }

            return true;
        }

        private void clear()
        {
            txtOrgCode.Text = txtOrgName.Text = string.Empty;
            cbOrgLevel.SelectedIndex = cbOrgBelong.SelectedIndex = 0;
            txtOrgCode.Focus();
        }

        private void txtOrgCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOrgName.Focus();
            }
        }

        private void txtOrgName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbOrgLevel.Focus();
            }
        }
        private void cbOrgLevel_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                this.cbOrgBelong.Focus();
            }
        }

        private void cbOrgBelong_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            tc.SelectedTab = tc.TabPages["OrganizationInfo"];
        }

        private void UCAddOrUpdateOrganization_Load(object sender, EventArgs e)
        {

            txtOrgCode.Focus();
            string sql = DA.Sql.getParams;
            object[] param = { "ORGLEVEL" };
            cbOrgLevel.DataSource = _sqlhelp.Query("", sql, param);
            cbOrgLevel.DisplayMember = "object_name";
            cbOrgLevel.ValueMember = "type_value";


            object[] param2 = { "ORGBELONG" };
            this.cbOrgBelong.DataSource = _sqlhelp.Query("", sql, param2);
            cbOrgBelong.DisplayMember = "object_name";
            cbOrgBelong.ValueMember = "type_value";

            if (_flag == "insert")
            {
                cbOrgLevel.SelectedIndex = cbOrgBelong.SelectedIndex = 0;
            }
            else if (_flag == "update")
            {

                txtOrgCode.Text = _gmorganization.Organization_code;
                txtOrgName.Text = _gmorganization.Organization_name;
                cbOrgLevel.Text = _gmorganization.Organization_levelName;
                cbOrgLevel.SelectedValue = _gmorganization.Organization_level;
                cbOrgBelong.Text = _gmorganization.Organization_belongName;
                cbOrgBelong.SelectedValue = _gmorganization.Organization_belong;

            }

        }


        private void UCAddOrUpdateOrganization_Layout(object sender, LayoutEventArgs e)
        {

            if (_flag == "insert")
            {
                if (!DA.DataAccess.PageIsExist("AddOrganization", tc))
                {
                    return;
                }
                cbOrgLevel.SelectedIndex = cbOrgBelong.SelectedIndex = 0;
            }
            else if (_flag == "update")
            {

                txtOrgCode.Text = _gmorganization.Organization_code;
                txtOrgName.Text = _gmorganization.Organization_name;
                cbOrgLevel.Text = _gmorganization.Organization_levelName;
                cbOrgLevel.SelectedValue = _gmorganization.Organization_level;
                cbOrgBelong.Text = _gmorganization.Organization_belongName;
                cbOrgBelong.SelectedValue = _gmorganization.Organization_belong;

            }
        }

    }
}
