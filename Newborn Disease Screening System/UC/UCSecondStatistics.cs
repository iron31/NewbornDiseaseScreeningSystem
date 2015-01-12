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
    public partial class UCSecondStatistics : UserControl
    {
        FBSqlHelper _sqlhelp = new FBSqlHelper();
        TabControl _tc;
        public UCSecondStatistics(TabControl tc)
        {
            InitializeComponent();
            _tc = tc;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

            string begDate=string.Empty;
            string endDate=string.Empty;
            string rbegDate = string.Empty;
            string rendDate=string.Empty;
            string gender = string.Empty;

            string type = rdoItemType.EditValue.ToString();
            // string gender=ceMan.Checked?"1":"-1"+"";
            if (rdoDate.SelectedIndex == 0)
            {
                begDate = deBegDate.Text.Trim();
                endDate = deEndDate.Text.Trim();
                rbegDate = "0001-01-01";
                rendDate = "9999-01-01";
            }
            else if (rdoDate.SelectedIndex == 1)
            {
                begDate = "0001-01-01";
                endDate = "9999-01-01";
                rbegDate = this.deReceivedBegDate.Text.Trim();
                rendDate = this.deReceivedEndDate.Text.Trim();
            }
            else
            {
                begDate = "0001-01-01";
                endDate = "9999-01-01";
                rbegDate = "0001-01-01";
                rendDate = "9999-01-01";
            }
            if(ceMan.Checked)
            {
                gender += "1,";
            }
            if (this.ceWoman.Checked)
            {
                gender += "0,";
            }
            if (this.ceUnKnown.Checked)
            {
                gender += "2,";
            }
            if (gender.Length > 0)
            {
                gender = gender.Substring(0, gender.Length - 1);
            }
            else
            {
                gender = "9";
            }

            object[] param = { type, type, type, begDate, endDate,gender, rbegDate, rendDate };
            string sql = string.Format(Sql.secondStatisticsResult, param);
           
            DataTable dt = _sqlhelp.GetDataTable(sql);

            if (DA.DataAccess.PageIsExist("SecondStatisticsResult", _tc))
            {
                return;
            }
            UCSecondStatisticsResult result = new UCSecondStatisticsResult(_tc,dt);
            DA.DataAccess.addTabPage("SecondStatisticsResult", "SecondStatisticsResult", result, _tc);
            _tc.SelectedTab = _tc.TabPages["SecondStatisticsResult"];
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            DA.DataAccess.removeTabPage("SecondStatistics", _tc);
            _tc.SelectedTab = _tc.TabPages["tbMainPage"];
        }
    }
}
