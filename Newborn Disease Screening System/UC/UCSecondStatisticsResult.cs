using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace Newborn_Disease_Screening_System.UC
{
    public partial class UCSecondStatisticsResult : UserControl
    {
        TabControl _tc;
        DataTable _dt=null;
        public UCSecondStatisticsResult(TabControl tc,DataTable dt)
        {
            InitializeComponent(); 
            _tc = tc;
            _dt = dt;
        }

        private void UCSecondStatisticsResult_Load(object sender, EventArgs e)
        {
            this.gcSecondStatistics.DataSource = _dt;
           
            int rowIndex = gvSecondStatistics.FocusedRowHandle;
            showView(rowIndex);
            
        }





        private void showView(int rowIndex)
        {
            DataView dv = new DataView(_dt);
            if(_dt.Rows.Count<=0)
            {
                return;
            }
            this.ccSecondStatistics.DataSource = dv;
            ccSecondStatistics.Series.Clear();
           // ccSecondStatistics. = _dt.Columns[0].ColumnName;
            for (int i = 0; i < _dt.Columns.Count - 1; i++)
            {
                //for (int m = 0; m < _dt.Rows.Count; m++)
                //{
                Series series1 = new Series(_dt.Columns[i + 1].ToString(), ViewType.Bar);
                //SeriesPoint spoint = new SeriesPoint();
                string argument = gvSecondStatistics.Columns[i + 1].Caption;
                string type = _dt.Columns[i + 1].ColumnName;
                decimal value = decimal.Parse(_dt.Rows[rowIndex][type].ToString());
                series1.Points.Add(new SeriesPoint(argument, value));
                series1.LegendText = argument;
                ccSecondStatistics.Series.Add(series1);
                //}
            }
            //ccSecondStatistics.Legend.Visible = false;//不显示指示图
        }

     
        private void gvSecondStatistics_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int rowIndex = gvSecondStatistics.FocusedRowHandle;
            showView(rowIndex);
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            DA.DataAccess.removeTabPage("SecondStatisticsResult", _tc);
            _tc.SelectedTab = _tc.TabPages["SecondStatistics"];
        }
    }
}
