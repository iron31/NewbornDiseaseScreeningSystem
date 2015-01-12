using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newborn_Disease_Screening_System.DA;
using Newborn_Disease_Screening_System.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid.Columns;

namespace Newborn_Disease_Screening_System.UC
{
    public partial class UCObjectQueryResult : UserControl
    {

        FBSqlHelper _sqlhelp = new FBSqlHelper();
        string _sql = string.Empty;
        UCObjectQueryResult _queryresult = null;
        private TabControl _tc = null;
        DataTable _dt = null;
        public UCObjectQueryResult(TabControl tc, DataTable dt)
        {
            InitializeComponent();
            _tc = tc;
            _dt = dt;
        }

        private void dateBing()
        {
            TreeListNode ParentNode = this.tlCard.AppendNode(null, null);
            ParentNode.SetValue(tlCard.Columns[0], "母亲名称");
            ParentNode.SetValue(tlCard.Columns[1], "卡号");
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                TreeListNode node = tlCard.AppendNode("", ParentNode);
                node.SetValue(tlCard.Columns[0], _dt.Rows[i]["MOTHER_NAME"].ToString());
                node.SetValue(tlCard.Columns[1], _dt.Rows[i]["CARD_NO"].ToString());
            }
        }

        private void UCObjectQueryResult_Load(object sender, EventArgs e)
        {
            clearText();
            dateBing();
        }

        private void tlCard_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (tlCard.Columns.Count <= 0)
            {
                return;
            }
            if (tlCard.Nodes.Count <= 0)
            {
                return;
            }
            string cardNo = tlCard.FocusedNode.GetDisplayText(1);
            if (string.IsNullOrEmpty(cardNo))
            {
                return;
            }
            else if (cardNo == "卡号")
            {
                return;
            }
            DataRow[] dr = _dt.Select("CARD_NO =" + cardNo);
            lblAddress.Text = dr[0]["ADDRESS"].ToString();
            lblAnamnesis.Text = dr[0]["ANAMNESIS_INFO"].ToString();
            lblBedNo.Text = dr[0]["BED_NO"].ToString();
            lblBirthday.Text = dr[0]["BIRTHDAY"].ToString();
            lblGender.Text = dr[0]["GENDER_INFO"].ToString();
            lblIllCaseNo.Text = dr[0]["ILLCASE_NO"].ToString();
            lblOrg.Text = dr[0]["ORGANIZATION_NAME"].ToString();
            lblPhone.Text = dr[0]["PHONE_NO"].ToString();
            lblWeight.Text = dr[0]["WEIGHT"].ToString();
            lblYieldMode.Text = dr[0]["YIELDMODE_INFO"].ToString();

            lblGetBloodDate1.Text = dr[0]["GET_BLOOD_DATE"].ToString();
            lblGetBloodUser1.Text = dr[0]["GET_BLOOD_USER_NAME"].ToString();
            lblReceivedDate1.Text = dr[0]["RECEIVED_DATE"].ToString();
            lblSendDate1.Text = dr[0]["SEND_DATE"].ToString();

            DataTable dtfirst = new DataTable();
            object[] param = { cardNo };
            dtfirst = _sqlhelp.Query("", Sql.objectQueryResultFirst, param);
            gcFirstResult.DataSource = dtfirst;

            DataTable dtSecond = new DataTable();
            object[] param2 = { cardNo };
            dtSecond = _sqlhelp.Query("", Sql.objectQueryResultSecond, param2);
            gcSecondResult.DataSource = dtSecond;
            if (dtSecond.Rows.Count <= 0)
            {
                lblGetBloodDate2.Text =
                lblGetBloodUser2.Text =
                lblReceivedDate2.Text =
                lblSendDate2.Text = string.Empty;
            }
            else
            {
                lblGetBloodDate2.Text = dtSecond.Rows[0]["GET_BLOOD_DATE"].ToString();
                lblGetBloodUser2.Text = dtSecond.Rows[0]["GET_BLOOD_USER_NAME"].ToString();
                lblReceivedDate2.Text = dtSecond.Rows[0]["RECEIVED_DATE"].ToString();
                lblSendDate2.Text = dtSecond.Rows[0]["SEND_DATE"].ToString();
            }
        }
        private void clearText()
        {
            lblAddress.Text =
            lblAnamnesis.Text =
            lblBedNo.Text =
            lblBirthday.Text =
            lblGender.Text =
            lblIllCaseNo.Text =
            lblOrg.Text =
            lblPhone.Text =
            lblWeight.Text =
            lblYieldMode.Text =
            lblGetBloodDate1.Text =
            lblGetBloodUser1.Text =
            lblReceivedDate1.Text =
            lblSendDate1.Text =
           lblGetBloodDate2.Text =
           lblGetBloodUser2.Text =
           lblReceivedDate2.Text =
           lblSendDate2.Text = string.Empty;
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            DA.DataAccess.removeTabPage("QueryObjectResult", _tc);
            _tc.SelectedTab = _tc.TabPages["QueryObject"];
        }
    }
}
