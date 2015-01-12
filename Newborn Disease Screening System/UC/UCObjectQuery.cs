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
    public partial class UCObjectQuery : UserControl
    {
        FBSqlHelper _sqlhelp = new FBSqlHelper();
        string _sql = string.Empty;
        UCObjectQueryResult _queryresult = null;
        private TabControl _tc = null;
        public UCObjectQuery(TabControl tc)
        {
            InitializeComponent();
            _tc = tc;
        }

        

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (ceCardNo.Checked)
            {
                txtEndNo.Text = string.IsNullOrEmpty(txtEndNo.Text) ? txtBegNo.Text : txtEndNo.Text;
            }
            string begDate = this.ceBirthday.Checked ? deBegDate.Text.Trim() : "0001-01-01";
            string endDate = this.ceBirthday.Checked ? deEndDate.Text.Trim() : "9999-01-01";
            string begNo = this.ceCardNo.Checked ? txtBegNo.Text.Trim() : "1";
            string endNo = this.ceCardNo.Checked ? txtEndNo.Text.Trim() : "1";
            string orgCode = ceOrgCode.Checked ? txtOrgCode.Text.Trim() : "1";
            string motherName = ceMotherName.Checked ? txtMotherName.Text.Trim() : "1";
            string illCaseNo = ceIllCaseNo.Checked ? txtIllCaseNo.Text.Trim() : "1";
            string cardCode = ceCardCode.Checked ? txtCardCode.Text.Trim() : "1";

            _sql = @"select 
                      * 
                    from VW_NB_DISEASE_CARD ncd
                    where 
                    (ncd.CARD_NO between ? and ? or ?=1)
                    and (ncd.BIRTHDAY between ? and ? )
                    and (ncd.organization_code=? or ?=1)
                    and (ncd.MOTHER_NAME=? or ?=1)
                    and (ncd.ILLCASE_NO=? or ?=1)
                    and (ncd.CARD_CODE=? or ?=1)
                    ";
            dt = _sqlhelp.Query("", _sql, new[] 
            { begNo, endNo, endNo, begDate, endDate, orgCode, orgCode, motherName, motherName, illCaseNo, illCaseNo, cardCode, cardCode });

            if (DA.DataAccess.PageIsExist("QueryObjectResult", _tc))
            {
                return;
            }
            _queryresult = new UCObjectQueryResult(_tc,dt);
            DA.DataAccess.addTabPage("QueryObjectResult", "QueryObjectResult", _queryresult, _tc);
            _tc.SelectedTab = _tc.TabPages["QueryObjectResult"];
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            DA.DataAccess.removeTabPage("QueryObject", _tc);
            _tc.SelectedTab = _tc.TabPages["tbMainPage"];
        }
    }
}
