using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newborn_Disease_Screening_System.DA;
using Newborn_Disease_Screening_System.Report;
using FirebirdSql.Data.FirebirdClient;

namespace Newborn_Disease_Screening_System.UC
{
    public partial class UCFirstResultReport : UserControl
    {
        private TabControl _tc = null;
        string _type;
        RptFirstResult first;
        FBSqlHelper _sqlhelp = new FBSqlHelper();
        DataTable _dt = new DataTable();
        string _cardNo;
        public UCFirstResultReport(TabControl tc, string type)
        {
            InitializeComponent();
            _tc = tc;
            _type = type;
        }

        private void clear()
        {
            lblMotherName.Text = lblOrganization.Text = lblSendDate.Text = lblReceiveDate.Text =
            lblHealthNo.Text = lblCardCode.Text = lblGender.Text =
            lblTsh1.Text = lblTsh2.Text = lblPhe1.Text = lblPhe2.Text = lblG6PD1.Text = lblG6PD2.Text = string.Empty;
        }

        private void UCFirstResultReport_Load(object sender, EventArgs e)
        {
            clear();
            switch (_type)
            {
                case "report":
                    lblTitle.Text = "筛查初检报告单";
                    plReport.Visible = true;
                    plInform.Visible = false;
                    gvFirstResultReport.Columns.ColumnByName("print").Visible = true;
                    gvFirstResultReport.Columns.ColumnByName("print2").Visible = false;
                    break;
                case "inform":
                    lblTitle.Text = "筛查初检通知单";
                    plReport.Visible = false;
                    plInform.Visible = true;
                    rdoResult.SelectedIndex = 0;
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

            string begNo = string.Empty;
            string endNo = string.Empty;
            string begDate = this.ceReceivedDate.Checked ? deBegDate.DateTime.ToString() : "0001-01-01";
            string endDate = this.ceReceivedDate.Checked ? deEndDate.DateTime.ToString() : "9999-01-01";

            switch (_type)
            {
                case "report":
                    txtEndCardNo.Text = string.IsNullOrEmpty(txtEndCardNo.Text.Trim()) ? txtBegCardNo.Text.Trim() : txtEndCardNo.Text;
                    begNo = this.ceCardNo.Checked ? txtBegCardNo.Text.Trim() : "1";
                    endNo = this.ceCardNo.Checked ? txtEndCardNo.Text.Trim() : "1";

                    dt = _sqlhelp.Query("", Sql.firstResultReport, new[] { begNo, endNo, endNo, begDate, endDate, "1", "1", "1", "1" });
                    break;
                case "inform":
                    txtEndCard.Text = string.IsNullOrEmpty(txtEndCard.Text.Trim()) ? txtBegCard.Text.Trim() : txtEndCard.Text;
                    begNo = this.ceCard.Checked ? txtBegCard.Text.Trim() : "1";
                    endNo = this.ceCard.Checked ? txtEndCard.Text.Trim() : "1";
                    string editvalue = rdoResult.Properties.Items[rdoResult.SelectedIndex].Value.ToString();
                    string sql = string.Format(Sql.firstResultInform, begNo, endNo, endNo, begDate, endDate, editvalue);
                    dt = _sqlhelp.GetDataTable(sql);
                    break;
            }
            return dt;
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            switch (_type)
            {
                case "report":
                    DA.DataAccess.removeTabPage("FirstResultReport", _tc);
                    break;
                case "inform":
                    DA.DataAccess.removeTabPage("FirstResultInform", _tc);
                    break;
            }
            _tc.SelectedTab = _tc.TabPages["tbMainPage"];
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            dateBinding();
        }

        private void btnPrintOne_Click(object sender, EventArgs e)
        {
            if (gvFirstResultReport.DataRowCount > 0)
            {
                int i = this.gvFirstResultReport.FocusedRowHandle;
                DataRow dr = this.gvFirstResultReport.GetDataRow(i);
                first = new RptFirstResult(null, dr, _type);
                first.Print();
                switch (_type)
                {
                    case "report":
                        string sqlReport = string.Format(@"UPDATE
                                              NB_DISEASE_SCREENING_CARD
                                            SET
                                              PRINT = '{0}'
                                            WHERE
                                              card_no = '{1}' 
                                              and print = '0'", "1", dr["CARD_NO"].ToString());
                        _sqlhelp.ExecuteNonQuery(sqlReport);
                        break;
                    case "inform":
                        string sqlInform = string.Format(@"UPDATE
                                              NB_DISEASE_SCREENING_CARD
                                            SET
                                              PRINT2 = '{0}'
                                            WHERE
                                              card_no = '{1}' 
                                              and print2 = '0'", "1", dr["CARD_NO"].ToString());
                        _sqlhelp.ExecuteNonQuery(sqlInform);
                        break;
                }



            }
            else
            {
                MessageBox.Show("没有记录!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            if (this.gvFirstResultReport.DataRowCount <= 0)
            {
                MessageBox.Show("没有记录!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            first = new RptFirstResult(_dt, null, _type);
            first.Print();
            switch (_type)
            {
                case "report":
                    string[] sqlsReport = new string[50];
                    for (int i = 0; i < _dt.Rows.Count; i++)
                    {
                        string sql = string.Format(@"UPDATE
                                              NB_DISEASE_SCREENING_CARD
                                            SET
                                              PRINT = '{0}'
                                            WHERE
                                              card_no = '{1}' 
                                              and print = '0'", "1", _dt.Rows[i]["CARD_NO"].ToString());
                        sqlsReport.SetValue(sql, i);
                    }
                    FbTransaction tsReport = null;
                    _sqlhelp.ExecuteNonQuery(tsReport, sqlsReport);
                    break;
                case "inform":
                    string[] sqlsInform = new string[50];
                    for (int i = 0; i < _dt.Rows.Count; i++)
                    {
                        string sql = string.Format(@"UPDATE
                                              NB_DISEASE_SCREENING_CARD
                                            SET
                                              PRINT2 = '{0}'
                                            WHERE
                                              card_no = '{1}' 
                                              and print2 = '0'", "1", _dt.Rows[i]["CARD_NO"].ToString());
                        sqlsInform.SetValue(sql, i);
                    }
                    FbTransaction tsInform = null;
                    _sqlhelp.ExecuteNonQuery(tsInform, sqlsInform);
                    break;
            }

        }

        private void gvFirstResultReport_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            clear();
            if (gvFirstResultReport.DataRowCount > 0)
            {
                int i = this.gvFirstResultReport.FocusedRowHandle;
                DataRow dr = this.gvFirstResultReport.GetDataRow(i);
                string cardNo=dr["CARD_NO"].ToString();
                lblCardCode.Text = dr["CARD_CODE"].ToString();
                lblHealthNo.Text = dr["HEALTH_CODE"].ToString();
                lblGender.Text = dr["GENDER_INFO"].ToString();
                lblMotherName.Text = dr["MOTHER_NAME"].ToString();
                this.lblOrganization.Text = dr["ORGANIZATION_NAME"].ToString();
                lblReceiveDate.Text = dr["RECEIVED_DATE"].ToString();
                lblSendDate.Text = dr["SEND_DATE"].ToString();

                string sql = string.Format(@"SELECT * FROM NB_FIRST_SCREENING nsg where nsg.card_no = '{0}'", cardNo);
                DataTable dt=_sqlhelp.GetDataTable(sql);
                for (int j = 0; j < dt.Rows.Count;j++ )
                {
                    if(dt.Rows[j]["ITEM_TYPE"].ToString()=="TSH")
                    {
                        lblTsh1.Text = dt.Rows[j]["values1"].ToString();
                        lblTsh2.Text = dt.Rows[j]["values2"].ToString();
                    }else if(dt.Rows[j]["ITEM_TYPE"].ToString()=="PHE")
                    {
                        lblPhe1.Text= dt.Rows[j]["values1"].ToString();  
                        lblPhe2.Text= dt.Rows[j]["values2"].ToString();
                    }
                    else if (dt.Rows[j]["ITEM_TYPE"].ToString() == "G6PD")
                    {
                        lblG6PD1.Text = dt.Rows[j]["values1"].ToString();
                        lblG6PD2.Text = dt.Rows[j]["values2"].ToString();
                    }
                    
                }
            }
        }


    }
}
