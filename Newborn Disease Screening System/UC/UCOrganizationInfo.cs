using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newborn_Disease_Screening_System.DA;

namespace Newborn_Disease_Screening_System
{
    public partial class UCOrganizationInfo : UserControl
    {
        private TabControl tc = null;
        UC.UCAddOrUpdateOrganization _newOrganization;
        Entity.GmOrganization _gmOrganization = new Entity.GmOrganization();
        FBSqlHelper _sqlhelp = new FBSqlHelper();
        public UCOrganizationInfo(TabControl tc)
        {
            InitializeComponent();
            this.tc = tc;
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            tc.SelectedTab = tc.TabPages["tbMainPage"];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (DA.DataAccess.PageIsExist("AddOrganization", tc))
            {
                return;
            }
            _newOrganization = new UC.UCAddOrUpdateOrganization(tc, _gmOrganization, "insert");
            DA.DataAccess.addTabPage("AddOrganization", "AddOrganization", _newOrganization, tc);
            tc.SelectedTab = tc.TabPages["AddOrganization"];
        }

        private void UCOrganizationInfo_Load(object sender, EventArgs e)
        {
            datebinding();
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int _handle = this.gvOrganization.LocateByDisplayText(this.gvOrganization.FocusedRowHandle + 1, this.gvOrganization.Columns["ORG_CODE"], this.txtCode.Text);
            if (_handle < 0)
            {
                _handle = this.gvOrganization.LocateByDisplayText(0, this.gvOrganization.Columns["ORG_CODE"], this.txtCode.Text);
                if (_handle < 0)
                {
                    MessageBox.Show("没有目标记录！");
                    txtCode.Focus();
                    return;
                }
            }
            this.gvOrganization.FocusedRowHandle = _handle;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gvOrganization.GetFocusedDataRow();
            
            _gmOrganization.Organization_id=int.Parse(dr["org_id"].ToString());
            _gmOrganization.Organization_code = dr["org_code"].ToString().Trim();
            _gmOrganization.Organization_name = dr["org_name"].ToString().Trim();
            _gmOrganization.Organization_level = dr["org_level"].ToString().Trim();
            _gmOrganization.Organization_belong = dr["org_belong"].ToString().Trim();
            _gmOrganization.Organization_levelName = dr["level"].ToString().Trim();
            _gmOrganization.Organization_belongName = dr["belong"].ToString().Trim();
            if (DA.DataAccess.PageIsExist("UpdateOrganization", tc))
            {
                return;
            }
            _newOrganization = new UC.UCAddOrUpdateOrganization(tc, _gmOrganization, "update");
            DA.DataAccess.addTabPage("UpdateOrganization", "UpdateOrganization", _newOrganization, tc);
            tc.SelectedTab = tc.TabPages["UpdateOrganization"];
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            datebinding();
        }

        private void datebinding()
        {
            string sql = DA.Sql.organizationView;
            this.gcOrganization.DataSource = _sqlhelp.GetDataTable(sql);
        }

        private void UCOrganizationInfo_Layout(object sender, LayoutEventArgs e)
        {
            datebinding();
        }
    }
}
