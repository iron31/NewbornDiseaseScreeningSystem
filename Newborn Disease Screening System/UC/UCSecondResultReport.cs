using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newborn_Disease_Screening_System.Report;
using Newborn_Disease_Screening_System.DA;

namespace Newborn_Disease_Screening_System.UC
{
    public partial class UCSecondResultReport : UserControl
    {
        private TabControl _tc = null;
        string _type;
        RptFirstResult first;
        FBSqlHelper _sqlhelp = new FBSqlHelper();
        DataTable _dt = new DataTable();
        string _cardNo;

        public UCSecondResultReport(TabControl tc, string type)
        {
            InitializeComponent();
            _tc = tc;
            _type = type;
        }

        private void clear()
        {
            lblMotherName.Text = lblOrganization.Text = lblSendDate.Text = lblReceiveDate.Text =
            lblHealthNo.Text = lblCardCode.Text = lblGender.Text =
            lblTsh1.Text = lblPhe1.Text = lblG6PD1.Text = string.Empty;
        }

        private void UCSecondResultReport_Load(object sender, EventArgs e)
        {
            clear();
            switch (_type)
            {
                case "report":
                    lblTitle.Text = "筛查复检报告单";
                   
                    gvFirstResultReport.Columns.ColumnByName("print").Visible = true;
                    gvFirstResultReport.Columns.ColumnByName("print2").Visible = false;
                    break;
                case "inform":
                    lblTitle.Text = "筛查复检待排召回通知单";
                   
                    gvFirstResultReport.Columns.ColumnByName("print").Visible = false;
                    gvFirstResultReport.Columns.ColumnByName("print2").Visible = true;
                    break;
            }
            dateBinding();
        }

        private void dateBinding()
        {
            _dt = queryView();
            this.gcFirstResultReport.DataSource = _dt;
        }

        private DataTable queryView()
        {
            DataTable dt = new DataTable();
            txtEndCardNo.Text = string.IsNullOrEmpty(txtEndCardNo.Text.Trim()) ? txtBegCardNo.Text.Trim() : txtEndCardNo.Text;
            string begNo = this.ceCardNo.Checked ? txtBegCardNo.Text.Trim() : "1";
            string endNo = this.ceCardNo.Checked ? txtEndCardNo.Text.Trim() : "1";
            
            switch (_type)
            {
                case "report":
                    
                    dt = _sqlhelp.Query("", Sql.secondResultReport, new[] { begNo, endNo, endNo });
                    break;
                case "inform":
                    dt = _sqlhelp.Query("", Sql.secondResultInform, new[] { begNo, endNo, endNo,"待排","待排","待排" });
                    break;
            }
            return dt;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            dateBinding();
        }

        private void gvFirstResultReport_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            clear();
            if (gvFirstResultReport.DataRowCount > 0)
            {
                int i = this.gvFirstResultReport.FocusedRowHandle;
                DataRow dr = this.gvFirstResultReport.GetDataRow(i);
                string cardNo = dr["CARD_NO"].ToString();
                lblCardCode.Text = dr["CARD_CODE"].ToString();
                lblHealthNo.Text = dr["HEALTH_CODE"].ToString();
                lblGender.Text = dr["GENDER_INFO"].ToString();
                lblMotherName.Text = dr["MOTHER_NAME"].ToString();
                this.lblOrganization.Text = dr["ORGANIZATION_NAME"].ToString();
                lblReceiveDate.Text = dr["RECEIVED_DATE"].ToString();
                lblSendDate.Text = dr["SEND_DATE"].ToString();

                string sql = string.Format(@"SELECT * FROM NB_SECOND_SCREENING nsg where nsg.card_no = '{0}'", cardNo);
                DataTable dt = _sqlhelp.GetDataTable(sql);
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j]["ITEM_TYPE"].ToString() == "TSH")
                    {
                        lblTsh1.Text = dt.Rows[j]["values_avg"].ToString();
                    }
                    else if (dt.Rows[j]["ITEM_TYPE"].ToString() == "PHE")
                    {
                        lblPhe1.Text = dt.Rows[j]["values_avg"].ToString();
                    }
                    else if (dt.Rows[j]["ITEM_TYPE"].ToString() == "G6PD")
                    {
                        lblG6PD1.Text = dt.Rows[j]["values_avg"].ToString();
                    }

                }
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            switch (_type)
            {
                case "report":
                    DA.DataAccess.removeTabPage("SecondResultReport", _tc);
                    break;
                case "inform":
                    DA.DataAccess.removeTabPage("SecondResultInform", _tc);
                    break;
            }
            _tc.SelectedTab = _tc.TabPages["tbMainPage"];
        }
    }
}
