using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Newborn_Disease_Screening_System.Report
{
    public partial class RptFirstReturn : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable _dt = null;
        public RptFirstReturn(DataTable dt,string begDate,string endDate)
        {
            InitializeComponent();
            _dt = dt;
            Bindate();
            cellReceivedBegDate.Text = begDate;
            cellReceivedEndDate.Text = endDate;
        }

        public void Bindate()
        {
            this.DataSource = _dt;
            if (_dt == null)
            {
                return;
            }
            string propertyName = "Text";
            this.cellCardNo.DataBindings.Add(propertyName, this.DataSource, "f01");
            cellCardCode.DataBindings.Add(propertyName, this.DataSource, "f02");
            this.cellIllCaseNo.DataBindings.Add(propertyName, this.DataSource, "f03");
            this.cellBedNo.DataBindings.Add(propertyName, this.DataSource, "f04");
            this.cellMotherName.DataBindings.Add(propertyName, this.DataSource, "f05");
            this.cellAnamnesis.DataBindings.Add(propertyName, this.DataSource, "f06");
            this.cellGestational.DataBindings.Add(propertyName, this.DataSource, "f07");
            this.cellGender.DataBindings.Add(propertyName, this.DataSource, "f08");
            this.cellWeight.DataBindings.Add(propertyName, this.DataSource, "f09");
            this.cellBirthday.DataBindings.Add(propertyName, this.DataSource, "f10");
            this.cellGetDate.DataBindings.Add(propertyName, this.DataSource, "f11");
            this.cellGetUser.DataBindings.Add(propertyName, this.DataSource, "f12");
            this.cellReceivedDate.DataBindings.Add(propertyName, this.DataSource, "f13");
            this.cellQ.DataBindings.Add(propertyName, this.DataSource, "f14");
            this.cellReason.DataBindings.Add(propertyName, this.DataSource, "f15");
            this.cellTsh.DataBindings.Add(propertyName, this.DataSource, "f16");
            this.cellPhe.DataBindings.Add(propertyName, this.DataSource, "f17");
            this.cellG6pd.DataBindings.Add(propertyName, this.DataSource, "f18");


        }

    }
}
