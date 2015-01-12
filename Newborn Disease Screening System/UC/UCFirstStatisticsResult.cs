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
    public partial class UCFirstStatisticsResult : UserControl
    {
        TabControl _tc;
        string _type;
        DataTable _dt = null;
        int _rowIndex = 0;
        public UCFirstStatisticsResult(TabControl tc, string type, DataTable dt)
        {
            InitializeComponent();
            _tc = tc;
            _type = type;
            _dt = dt;
        }

        private void UCFirstStatisticsResult_Load(object sender, EventArgs e)
        {
            gvFirstStatistics.Columns.Clear();
            addColumns(_type);
            this.gcFirstStatistics.DataSource = _dt;
            _rowIndex = gvFirstStatistics.FocusedRowHandle;
            showView(_rowIndex);
        }

        private void addColumns(string type)
        {
            switch (type)
            {
                case "GENDER":
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();

                    this.gvFirstStatistics.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                    gridColumn1,gridColumn2,gridColumn3,gridColumn4});

                    gridColumn1.Caption = "分娩医院";
                    gridColumn1.FieldName = "ORGANIZATION_NAME";
                    gridColumn1.Name = "gridColumn1";
                    gridColumn1.OptionsColumn.AllowEdit = false;
                    gridColumn1.Visible = true;
                    gridColumn1.VisibleIndex = 0;

                    gridColumn2.Caption = "男";
                    gridColumn2.FieldName = "GENDERL";
                    gridColumn2.Name = "gridColumn2";
                    gridColumn2.OptionsColumn.AllowEdit = false;
                    gridColumn2.Visible = true;
                    gridColumn2.VisibleIndex = 1;

                    gridColumn3.Caption = "女";
                    gridColumn3.FieldName = "GENDERN";
                    gridColumn3.Name = "gridColumn3";
                    gridColumn3.OptionsColumn.AllowEdit = false;
                    gridColumn3.Visible = true;
                    gridColumn3.VisibleIndex = 2;

                    gridColumn4.Caption = "不详";
                    gridColumn4.FieldName = "GENDERH";
                    gridColumn4.Name = "gridColumn4";
                    gridColumn4.OptionsColumn.AllowEdit = false;
                    gridColumn4.Visible = true;
                    gridColumn4.VisibleIndex = 3;
                    break;
                case "WEIGHT":
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();

                    this.gvFirstStatistics.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                    gridColumn5,gridColumn6,gridColumn7,gridColumn8});

                    gridColumn5.Caption = "分娩医院";
                    gridColumn5.FieldName = "ORGANIZATION_NAME";
                    gridColumn5.Name = "gridColumn5";
                    gridColumn5.OptionsColumn.AllowEdit = false;
                    gridColumn5.Visible = true;
                    gridColumn5.VisibleIndex = 0;

                    gridColumn6.Caption = "<2.5kg";
                    gridColumn6.FieldName = "WEIGHTL";
                    gridColumn6.Name = "gridColumn6";
                    gridColumn6.OptionsColumn.AllowEdit = false;
                    gridColumn6.Visible = true;
                    gridColumn6.VisibleIndex = 1;

                    gridColumn7.Caption = "2.5-4.0kg";
                    gridColumn7.FieldName = "WEIGHTN";
                    gridColumn7.Name = "gridColumn7";
                    gridColumn7.OptionsColumn.AllowEdit = false;
                    gridColumn7.Visible = true;
                    gridColumn7.VisibleIndex = 2;

                    gridColumn8.Caption = ">4.0kg";
                    gridColumn8.FieldName = "WEIGHTH";
                    gridColumn8.Name = "gridColumn8";
                    gridColumn8.OptionsColumn.AllowEdit = false;
                    gridColumn8.Visible = true;
                    gridColumn8.VisibleIndex = 3;
                    break;
                case "WEEKS":
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();

                    this.gvFirstStatistics.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                    gridColumn9,gridColumn10,gridColumn11,gridColumn12});

                    gridColumn9.Caption = "分娩医院";
                    gridColumn9.FieldName = "ORGANIZATION_NAME";
                    gridColumn9.Name = "gridColumn9";
                    gridColumn9.OptionsColumn.AllowEdit = false;
                    gridColumn9.Visible = true;
                    gridColumn9.VisibleIndex = 0;

                    gridColumn10.Caption = "<37周";
                    gridColumn10.FieldName = "WEEKSL";
                    gridColumn10.Name = "gridColumn10";
                    gridColumn10.OptionsColumn.AllowEdit = false;
                    gridColumn10.Visible = true;
                    gridColumn10.VisibleIndex = 1;

                    gridColumn11.Caption = "37-42周";
                    gridColumn11.FieldName = "WEEKSN";
                    gridColumn11.Name = "gridColumn11";
                    gridColumn11.OptionsColumn.AllowEdit = false;
                    gridColumn11.Visible = true;
                    gridColumn11.VisibleIndex = 2;

                    gridColumn12.Caption = ">42周";
                    gridColumn12.FieldName = "WEEKSH";
                    gridColumn12.Name = "gridColumn12";
                    gridColumn12.OptionsColumn.AllowEdit = false;
                    gridColumn12.Visible = true;
                    gridColumn12.VisibleIndex = 3;
                    break;
                case "YIELD":
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
                    this.gvFirstStatistics.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                    gridColumn13,gridColumn14,gridColumn15,gridColumn16,gridColumn17,gridColumn18,gridColumn19});

                    gridColumn13.Caption = "分娩医院";
                    gridColumn13.FieldName = "ORGANIZATION_NAME";
                    gridColumn13.Name = "gridColumn9";
                    gridColumn13.OptionsColumn.AllowEdit = false;
                    gridColumn13.Visible = true;
                    gridColumn13.VisibleIndex = 0;

                    gridColumn14.Caption = "顺产";
                    gridColumn14.FieldName = "YIELD1";
                    gridColumn14.Name = "gridColumn10";
                    gridColumn14.OptionsColumn.AllowEdit = false;
                    gridColumn14.Visible = true;
                    gridColumn14.VisibleIndex = 1;

                    gridColumn15.Caption = "剖宫产";
                    gridColumn15.FieldName = "YIELD2";
                    gridColumn15.Name = "gridColumn11";
                    gridColumn15.OptionsColumn.AllowEdit = false;
                    gridColumn15.Visible = true;
                    gridColumn15.VisibleIndex = 2;

                    gridColumn16.Caption = "产钳助产";
                    gridColumn16.FieldName = "YIELD3";
                    gridColumn16.Name = "gridColumn12";
                    gridColumn16.OptionsColumn.AllowEdit = false;
                    gridColumn16.Visible = true;
                    gridColumn16.VisibleIndex = 3;


                    gridColumn17.Caption = "胎吸";
                    gridColumn17.FieldName = "YIELD4";
                    gridColumn17.Name = "gridColumn13";
                    gridColumn17.OptionsColumn.AllowEdit = false;
                    gridColumn17.Visible = true;
                    gridColumn17.VisibleIndex = 4;


                    gridColumn18.Caption = "臀位助娩";
                    gridColumn18.FieldName = "YIELD5";
                    gridColumn18.Name = "gridColumn14";
                    gridColumn18.OptionsColumn.AllowEdit = false;
                    gridColumn18.Visible = true;
                    gridColumn18.VisibleIndex = 5;


                    gridColumn19.Caption = "其它";
                    gridColumn19.FieldName = "YIELD6";
                    gridColumn19.Name = "gridColumn15";
                    gridColumn19.OptionsColumn.AllowEdit = false;
                    gridColumn19.Visible = true;
                    gridColumn19.VisibleIndex = 6;
                    break;
                case "TSH":
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();

                    this.gvFirstStatistics.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                    gridColumn20,gridColumn21,gridColumn22,gridColumn23});

                    gridColumn20.Caption = "分娩医院";
                    gridColumn20.FieldName = "ORGANIZATION_NAME";
                    gridColumn20.Name = "gridColumn9";
                    gridColumn20.OptionsColumn.AllowEdit = false;
                    gridColumn20.Visible = true;
                    gridColumn20.VisibleIndex = 0;

                    gridColumn21.Caption = "阴性";
                    gridColumn21.FieldName = "TSH1";
                    gridColumn21.Name = "gridColumn10";
                    gridColumn21.OptionsColumn.AllowEdit = false;
                    gridColumn21.Visible = true;
                    gridColumn21.VisibleIndex = 1;

                    gridColumn22.Caption = "弱阳性";
                    gridColumn22.FieldName = "TSH2";
                    gridColumn22.Name = "gridColumn11";
                    gridColumn22.OptionsColumn.AllowEdit = false;
                    gridColumn22.Visible = true;
                    gridColumn22.VisibleIndex = 2;

                    gridColumn23.Caption = "阳性";
                    gridColumn23.FieldName = "TSH3";
                    gridColumn23.Name = "gridColumn12";
                    gridColumn23.OptionsColumn.AllowEdit = false;
                    gridColumn23.Visible = true;
                    gridColumn23.VisibleIndex = 3;
                    break;
                case "PHE":
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();

                    this.gvFirstStatistics.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                    gridColumn24,gridColumn25,gridColumn26,gridColumn27});

                    gridColumn24.Caption = "分娩医院";
                    gridColumn24.FieldName = "ORGANIZATION_NAME";
                    gridColumn24.Name = "gridColumn9";
                    gridColumn24.OptionsColumn.AllowEdit = false;
                    gridColumn24.Visible = true;
                    gridColumn24.VisibleIndex = 0;

                    gridColumn25.Caption = "阴性";
                    gridColumn25.FieldName = "PHE1";
                    gridColumn25.Name = "gridColumn10";
                    gridColumn25.OptionsColumn.AllowEdit = false;
                    gridColumn25.Visible = true;
                    gridColumn25.VisibleIndex = 1;

                    gridColumn26.Caption = "弱阳性";
                    gridColumn26.FieldName = "PHE2";
                    gridColumn26.Name = "gridColumn11";
                    gridColumn26.OptionsColumn.AllowEdit = false;
                    gridColumn26.Visible = true;
                    gridColumn26.VisibleIndex = 2;

                    gridColumn27.Caption = "阳性";
                    gridColumn27.FieldName = "PHE3";
                    gridColumn27.Name = "gridColumn12";
                    gridColumn27.OptionsColumn.AllowEdit = false;
                    gridColumn27.Visible = true;
                    gridColumn27.VisibleIndex = 3;
                    break;
                case "G6PD":
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();

                    this.gvFirstStatistics.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                    gridColumn28,gridColumn29,gridColumn30,gridColumn31});

                    gridColumn28.Caption = "分娩医院";
                    gridColumn28.FieldName = "ORGANIZATION_NAME";
                    gridColumn28.Name = "gridColumn9";
                    gridColumn28.OptionsColumn.AllowEdit = false;
                    gridColumn28.Visible = true;
                    gridColumn28.VisibleIndex = 0;

                    gridColumn29.Caption = "阴性";
                    gridColumn29.FieldName = "G6PD1";
                    gridColumn29.Name = "gridColumn10";
                    gridColumn29.OptionsColumn.AllowEdit = false;
                    gridColumn29.Visible = true;
                    gridColumn29.VisibleIndex = 1;

                    gridColumn30.Caption = "弱阳性";
                    gridColumn30.FieldName = "G6PD2";
                    gridColumn30.Name = "gridColumn11";
                    gridColumn30.OptionsColumn.AllowEdit = false;
                    gridColumn30.Visible = true;
                    gridColumn30.VisibleIndex = 2;

                    gridColumn31.Caption = "阳性";
                    gridColumn31.FieldName = "G6PD3";
                    gridColumn31.Name = "gridColumn12";
                    gridColumn31.OptionsColumn.AllowEdit = false;
                    gridColumn31.Visible = true;
                    gridColumn31.VisibleIndex = 3;
                    break;
                case "ANAMNESIS":
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();

                    this.gvFirstStatistics.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                    gridColumn32,gridColumn33,gridColumn34,gridColumn35,gridColumn36,gridColumn37});

                    gridColumn32.Caption = "分娩医院";
                    gridColumn32.FieldName = "ORGANIZATION_NAME";
                    gridColumn32.Name = "gridColumn9";
                    gridColumn32.OptionsColumn.AllowEdit = false;
                    gridColumn32.Visible = true;
                    gridColumn32.VisibleIndex = 0;

                    gridColumn33.Caption = "无";
                    gridColumn33.FieldName = "ANAMNESIS1";
                    gridColumn33.Name = "gridColumn10";
                    gridColumn33.OptionsColumn.AllowEdit = false;
                    gridColumn33.Visible = true;
                    gridColumn33.VisibleIndex = 1;

                    gridColumn34.Caption = "甲亢";
                    gridColumn34.FieldName = "ANAMNESIS2";
                    gridColumn34.Name = "gridColumn11";
                    gridColumn34.OptionsColumn.AllowEdit = false;
                    gridColumn34.Visible = true;
                    gridColumn34.VisibleIndex = 2;

                    gridColumn35.Caption = "甲低";
                    gridColumn35.FieldName = "ANAMNESIS3";
                    gridColumn35.Name = "gridColumn12";
                    gridColumn35.OptionsColumn.AllowEdit = false;
                    gridColumn35.Visible = true;
                    gridColumn35.VisibleIndex = 3;


                    gridColumn36.Caption = "PKU";
                    gridColumn36.FieldName = "ANAMNESIS4";
                    gridColumn36.Name = "gridColumn13";
                    gridColumn36.OptionsColumn.AllowEdit = false;
                    gridColumn36.Visible = true;
                    gridColumn36.VisibleIndex = 4;


                    gridColumn37.Caption = "病理儿";
                    gridColumn37.FieldName = "ANAMNESIS5";
                    gridColumn37.Name = "gridColumn14";
                    gridColumn37.OptionsColumn.AllowEdit = false;
                    gridColumn37.Visible = true;
                    gridColumn37.VisibleIndex = 5;


                    break;
            }

        }


        private void showView(int rowIndex)
        {

            DataView dv = new DataView(_dt);
            if (_dt.Rows.Count <= 0)
            {
                return;
            }
            this.ccFirstStatistics.DataSource = dv;

            ccFirstStatistics.Series.Clear();
            // ccSecondStatistics. = _dt.Columns[0].ColumnName;
            for (int i = 0; i < _dt.Columns.Count - 1; i++)
            {
                //for (int m = 0; m < _dt.Rows.Count; m++)
                //{
                Series series1 = new Series(_dt.Columns[i + 1].ToString(), ViewType.Bar);
                //SeriesPoint spoint = new SeriesPoint();
                string argument = gvFirstStatistics.Columns[i + 1].Caption;
                string type = _dt.Columns[i + 1].ColumnName;
                decimal value = decimal.Parse(_dt.Rows[rowIndex][type].ToString());
                series1.Points.Add(new SeriesPoint(argument, value));
                series1.LegendText = argument;
                ccFirstStatistics.Series.Add(series1);
                //}
            }
            //ccSecondStatistics.Legend.Visible = false;//不显示指示图
        }

        private void gvFirstStatistics_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            _rowIndex = gvFirstStatistics.FocusedRowHandle;
            showView(_rowIndex);
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            DA.DataAccess.removeTabPage("FirstStatisticsResult", _tc);
            _tc.SelectedTab = _tc.TabPages["FirstStatistics"];
        }
    }
}
