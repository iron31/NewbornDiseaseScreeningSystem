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
    public partial class UCSecondResultInfo : UserControl
    {
        private TabControl _tc = null;
        UC.UCAddOrUpdateSecondResult _secondResult;
        FBSqlHelper _sqlhelp = new FBSqlHelper();
        string _begDate;
        string _endDate;
        string _cardNo;
        public UCSecondResultInfo(TabControl tc)
        {
            InitializeComponent();
            _tc = tc;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (DA.DataAccess.PageIsExist("AddSecondResult", _tc))
            {
                return;
            }
            _secondResult = new UC.UCAddOrUpdateSecondResult(_tc, "insert", "");
            DA.DataAccess.addTabPage("AddSecondResult", "AddSecondResult", _secondResult, _tc);

            _tc.SelectedTab = _tc.TabPages["AddSecondResult"];
        }


        private void dateBinding()
        {

            DataTable dt = new DataTable();
            dt = queryView();
            this.gcSecondResultInfo.DataSource = dt;
        }

        private DataTable queryView()
        {
            DataTable dt = new DataTable();
            string begNO = ceCardNo.Checked ? txtBegCardNo.Text : "1";
            string endNO = ceCardNo.Checked ? txtEndCardNo.Text : "1";
            dt = _sqlhelp.Query("", Sql.secondResultInfo, new[] { begNO, endNO, endNO });
            return dt;
        }

        private void UCSecondResultInfo_Load(object sender, EventArgs e)
        {
            dateBinding();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if(ceCardNo.Checked)
            {
                txtEndCardNo.Text = string.IsNullOrEmpty(txtEndCardNo.Text) ? txtBegCardNo.Text : txtEndCardNo.Text;
            }
            this.gvSecondResultInfo.FocusedRowHandle = 0;
            dateBinding();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.gvSecondResultInfo.DataRowCount <= 0)
            {
                MessageBox.Show("未选中需要修改的记录!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DA.DataAccess.PageIsExist("UpDateSecondResult", _tc))
            {
                return;
            }
            _secondResult = new UC.UCAddOrUpdateSecondResult(_tc, "update", _cardNo);
            DA.DataAccess.addTabPage("UpDateSecondResult", "UpDateSecondResult", _secondResult, _tc);

            _tc.SelectedTab = _tc.TabPages["UpDateSecondResult"];
        }

        private void gvSecondResultInfo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string cardNo;
            lblTsh1.Text = lblPhe1.Text = lblG6PD1.Text =
            lblMotherName.Text = lblHealthNo.Text = lblOrganization.Text = lblGender.Text = string.Empty;
            if (this.gvSecondResultInfo.DataRowCount > 0)
            {
                int i = this.gvSecondResultInfo.FocusedRowHandle;
                DataRow dr = this.gvSecondResultInfo.GetDataRow(i);
                cardNo = dr["CARD_NO"].ToString();
                string sql = @"SELECT * FROM NB_SECOND_SCREENING nsg
                                    where nsg.CARD_NO=?
                                    ";
                object[] param = { cardNo };
                DataTable dt = _sqlhelp.Query("", sql, param);
                if (dt.Rows.Count > 0)
                {
                    string avg = string.Empty;
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        lblCardCode.Text = dt.Rows[j]["CARD_CODE"].ToString();
                        lblReceiveDate.Text = dt.Rows[j]["RECEIVED_DATE"].ToString();
                        lblSendDate.Text = dt.Rows[j]["SEND_DATE"].ToString();
                        avg = dt.Rows[j]["VALUES_AVG"].ToString();
                        switch (dt.Rows[j]["ITEM_NAME"].ToString())
                        {
                            case "TSH1":
                                lblTsh1.Text = avg;
                                break;
                            case "PHE1":
                                lblTsh1.Text = avg;
                                break;
                            case "G6PD1":
                                lblG6PD1.Text = avg;
                                break;
                            default:
                                lblTsh1.Text = lblPhe1.Text = lblG6PD1.Text = string.Empty;
                                break;
                        }
                    }
                }

                sql = @"SELECT * FROM NB_DISEASE_SCREENING_CARD ncd
                                    where ncd.CARD_NO=?;
                                    ";
                object[] param1 = { cardNo };
                dt = _sqlhelp.Query("", sql, param1);
                if (dt.Rows.Count > 0)
                {
                    lblMotherName.Text = dt.Rows[0]["MOTHER_NAME"].ToString();
                    lblHealthNo.Text = dt.Rows[0]["HEALTH_CODE"].ToString();
                    lblOrganization.Text = dt.Rows[0]["ORGANIZATION_NAME"].ToString();
                    lblGender.Text = dt.Rows[0]["GENDER"].ToString() == "1" ? "男" : "女";

                }
                else
                {
                    lblMotherName.Text = lblHealthNo.Text = lblOrganization.Text = lblGender.Text = string.Empty;
                }
                _cardNo = cardNo;
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            DA.DataAccess.removeTabPage("SecondResultInfo", _tc);
            _tc.SelectedTab = _tc.TabPages["tbMainPage"];
        }
    }
}
