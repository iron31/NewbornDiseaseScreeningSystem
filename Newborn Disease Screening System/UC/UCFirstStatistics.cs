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
    public partial class UCFirstStatistics : UserControl
    {
        FBSqlHelper _sqlhelp = new FBSqlHelper();
        TabControl _tc;
        DataTable _dt;
        public UCFirstStatistics(TabControl tc)
        {
            InitializeComponent();
            _tc = tc;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string begDate = string.Empty;
            string endDate = string.Empty;
            string rbegDate = string.Empty;
            string rendDate = string.Empty;

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
            string type = rdoType.Properties.Items[rdoType.SelectedIndex].Value.ToString();
          
            object[] param = {  rbegDate, rendDate, begDate, endDate };
            switch(type)
            {
                case"GENDER": 
                    string sql = string.Format(Sql.firstStatisticsGender, param);
                     _dt = _sqlhelp.GetDataTable(sql);
                    break;
                case "WEIGHT":
                    string sql1 = string.Format(Sql.firstStatisticsWeight, param);
                    _dt = _sqlhelp.GetDataTable(sql1);
                    break;
                case "WEEKS":
                    string sql2 = string.Format(Sql.firstStatisticsWeeks, param);
                    _dt = _sqlhelp.GetDataTable(sql2);
                    break;
                case "YIELD":
                    string sql3 = string.Format(Sql.firstStatisticsYield, param);
                    _dt = _sqlhelp.GetDataTable(sql3);
                    break;
                case "TSH":
                    string sql4 = string.Format(Sql.firstStatisticsTsh, param);
                    _dt = _sqlhelp.GetDataTable(sql4);
                    break;
                case "PHE":
                    string sql5 = string.Format(Sql.firstStatisticsPhe, param);
                    _dt = _sqlhelp.GetDataTable(sql5);
                    break;
                case "G6PD":
                    string sql6 = string.Format(Sql.firstStatisticsG6pd, param);
                    _dt = _sqlhelp.GetDataTable(sql6);
                    break;
                case "ANAMNESIS":
                    string sql7 = string.Format(Sql.firstStatisticsAnamnesis, param);
                    _dt = _sqlhelp.GetDataTable(sql7);
                    break;
            }
          

            if (DA.DataAccess.PageIsExist("FirstStatisticsResult", _tc))
            {
                return;
            }
            UCFirstStatisticsResult result = new UCFirstStatisticsResult(_tc,type,_dt);
            DA.DataAccess.addTabPage("FirstStatisticsResult", "FirstStatisticsResult", result, _tc);
            _tc.SelectedTab = _tc.TabPages["FirstStatisticsResult"];
        }
    }
}
