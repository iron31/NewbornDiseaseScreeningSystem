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

namespace Newborn_Disease_Screening_System.UC
{
    public partial class UCRemind : UserControl
    {
        FBSqlHelper _sqlhelp = new FBSqlHelper();
        TabControl _tc = null;
        string _sql = string.Empty;
        string _type = string.Empty;
        DataTable _dt = new DataTable();
        string begDate = string.Empty;
        string endDate = string.Empty;

        public UCRemind(TabControl tc,string type)
        {
            InitializeComponent();
            _tc = tc;
            _type = type;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
           
            begDate = deBegDate.Text.Trim();
            endDate = deEndDate.Text.Trim(); 
            if(string.IsNullOrEmpty(begDate)||string.IsNullOrEmpty(endDate))
            {
                MessageBox.Show("请选择需要查询的时间");
                deBegDate.Focus();
                return;
            }
            switch(_type)
            {
                case "workload":
                    _sql = string.Format(Sql.workLoad,begDate,endDate);
                    _dt = _sqlhelp.GetDataTable(_sql);
                    RptWorkLoad workLoad = new RptWorkLoad(_dt, begDate, endDate);
                    this.reportViewRemind.Report = workLoad;
                    break;
                case "firstreturn":
                    _sql = string.Format(Sql.firstRetrun, begDate, endDate);
                    _dt = _sqlhelp.GetDataTable(_sql);
                    RptFirstReturn firstReturn = new RptFirstReturn(_dt, begDate, endDate);
                    this.reportViewRemind.Report = firstReturn;
                    break;
            }
          
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            DA.DataAccess.removeTabPage(_tc.SelectedTab.Name, _tc);
            _tc.SelectedTab = _tc.TabPages["tbMainPage"];
        }
    }
}
