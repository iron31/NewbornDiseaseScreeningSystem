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
    public partial class UCFirstResultInfo : UserControl
    {
        private TabControl _tc = null;
        UC.UCAddOrUpdateFirstResult _firstResult;
        FBSqlHelper _sqlhelp = new FBSqlHelper();
        string _begDate;
        string _endDate;
        string _cardNo;
        public UCFirstResultInfo(TabControl tc)
        {
            InitializeComponent();
            _tc = tc;
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (DA.DataAccess.PageIsExist("AddFirstResult", _tc))
            {
                return;
            }
            _firstResult = new UC.UCAddOrUpdateFirstResult(_tc,"insert","");
            DA.DataAccess.addTabPage("AddFirstResult", "AddFirstResult", _firstResult, _tc);

            _tc.SelectedTab = _tc.TabPages["AddFirstResult"];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.gridViewFirstResultInfo.DataRowCount <= 0)
            {
                MessageBox.Show("未选中需要修改的记录!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DA.DataAccess.PageIsExist("UpDateFirstResult", _tc))
            {
                return;
            }
            _firstResult = new UC.UCAddOrUpdateFirstResult(_tc,"update",_cardNo);
            DA.DataAccess.addTabPage("UpDateFirstResult", "UpDateFirstResult", _firstResult, _tc);

            _tc.SelectedTab = _tc.TabPages["UpDateFirstResult"];
        }


        private void btnGoBack_Click(object sender, EventArgs e)
        {
            DA.DataAccess.removeTabPage("FirstResultInfo", _tc);
            _tc.SelectedTab = _tc.TabPages["tbMainPage"];
        }

        private void UCFirstResultInfo_Load(object sender, EventArgs e)
        {
            dateEditBegDate.DateTime = System.DateTime.Now.Date;
            dateEditEndDate.DateTime = System.DateTime.Now.Date.AddDays(1);
            clear();
            dateBinding();
        }

        private void dateBinding()
        {
            _begDate = this.ceCreateDate.Checked?dateEditBegDate.DateTime.ToString():"1900-01-01";
            _endDate = this.ceCreateDate.Checked?dateEditEndDate.DateTime.ToString():"9999-01-01";
            DataTable dt = new DataTable();
            dt = queryView(_begDate, _endDate);
            this.gridControlFirstResultInfo.DataSource = dt;
        }

        private DataTable queryView(string begDate, string endDate)
        {
            DataTable dt = new DataTable();
           
            string begNo=this.ceCardNo.Checked?txtBegCardNo.Text.Trim():"1";
            string endNo=this.ceCardNo.Checked?txtEndCardNo.Text.Trim():"1";
            string dd = this.ceCreateDate.Checked ? "-1" : "1";
            dt = _sqlhelp.Query("", Sql.firstResultInfo, new[] { begDate, endDate, dd, begNo, endNo, endNo });
            return dt;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            //clear();
            if (ceCardNo.Checked)
            {
                txtEndCardNo.Text = string.IsNullOrEmpty(txtEndCardNo.Text) ? txtBegCardNo.Text : txtEndCardNo.Text;
            }
            this.gridViewFirstResultInfo.FocusedRowHandle = 0;
            dateBinding();
        }


        private void clear()
        {
            lblMotherName.Text = lblOrganization.Text = lblSendDate.Text = lblReceiveDate.Text =
            lblHealthNo.Text = lblCardCode.Text = lblGender.Text =
            lblTsh1.Text = lblTsh2.Text = lblPhe1.Text = lblPhe2.Text = lblG6PD1.Text = lblG6PD2.Text = string.Empty;
        }

        private void gridViewFirstResultInfo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string cardNo;
            if (this.gridViewFirstResultInfo.DataRowCount > 0)
            {
                int i = this.gridViewFirstResultInfo.FocusedRowHandle;
                DataRow dr = this.gridViewFirstResultInfo.GetDataRow(i);
                cardNo = dr["CARD_NO"].ToString();
                string sql = @"SELECT * FROM NB_FIRST_SCREENING nsg
                                    where nsg.CARD_NO=?
                                    ";
                object[] param = { cardNo};
                DataTable dt = _sqlhelp.Query("",sql, param);
                if(dt.Rows.Count>0)
                {
                    for (int j = 0; j < dt.Rows.Count;j++ )
                    {
                        if(dt.Rows[j]["ITEM_NAME"].ToString()=="TSH1")
                        {
                            lblTsh1.Text=dt.Rows[j]["values1"].ToString();
                        }
                        if (dt.Rows[j]["ITEM_NAME"].ToString() == "PHE1")
                        {
                            this.lblPhe1.Text = dt.Rows[j]["values1"].ToString();
                        }
                        if (dt.Rows[j]["ITEM_NAME"].ToString() == "G6PD1")
                        {
                            this.lblG6PD1.Text = dt.Rows[j]["values1"].ToString();
                        }
                        if (dt.Rows[j]["ITEM_NAME"].ToString() == "TSH2")
                        {
                            this.lblTsh2.Text = dt.Rows[j]["values1"].ToString();
                        }
                        if (dt.Rows[j]["ITEM_NAME"].ToString() == "PHE2")
                        {
                            this.lblPhe2.Text = dt.Rows[j]["values1"].ToString();
                        }
                        if (dt.Rows[j]["ITEM_NAME"].ToString() == "G6PD2")
                        {
                            this.lblG6PD2.Text = dt.Rows[j]["values1"].ToString();
                        }
                    }
                }

                string sql2 = @"SELECT * FROM VW_NB_DISEASE_CARD vcd
                            where vcd.CARD_NO=?;";
                object[] param2 = { cardNo };
                DataTable dt2 = _sqlhelp.Query("", sql2, param2);
                if (dt2.Rows.Count == 1)
                {
                    lblMotherName.Text=dt2.Rows[0]["MOTHER_NAME"].ToString();
                    lblOrganization.Text = dt2.Rows[0]["ORGANIZATION_NAME"].ToString();
                    lblCardCode.Text = dt2.Rows[0]["CARD_CODE"].ToString();
                    lblGender.Text = dt2.Rows[0]["GENDER_INFO"].ToString();
                    lblHealthNo.Text = dt2.Rows[0]["HEALTH_CODE"].ToString();
                    lblSendDate.Text = dt2.Rows[0]["SEND_DATE"].ToString();
                    lblReceiveDate.Text = dt2.Rows[0]["RECEIVED_DATE"].ToString();
                }
                _cardNo = cardNo;
            }
        }

      


    }
}
