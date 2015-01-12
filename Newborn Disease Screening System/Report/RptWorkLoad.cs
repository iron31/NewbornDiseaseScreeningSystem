using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Newborn_Disease_Screening_System.Report
{
    public partial class RptWorkLoad : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable _dt = null;
        public RptWorkLoad(DataTable dt, string begDate, string endDate)
        {
            InitializeComponent();
            _dt = dt;
            cellReceivedBegDate.Text = begDate;
            cellReceivedEndDate.Text = endDate;
            Bindate();
        }

        public void Bindate()
        {
            this.DataSource = _dt;
            if(_dt==null)
            {
                return;
            }
            string propertyName = "Text";
            cellOrgName.DataBindings.Add(propertyName, this.DataSource, "f01");
            cellCount.DataBindings.Add(propertyName, this.DataSource, "f02");
            cellQualified.DataBindings.Add(propertyName, this.DataSource, "f03");
            cellUnQualified.DataBindings.Add(propertyName, this.DataSource, "f04");
            cellPercent.DataBindings.Add(propertyName, this.DataSource, "f05", "{0:f2}");
            cellLowCH.DataBindings.Add(propertyName, this.DataSource, "f06");
            cellLowPKU.DataBindings.Add(propertyName, this.DataSource, "f07");
            cellHeighCH.DataBindings.Add(propertyName, this.DataSource, "f08");
            cellHeighPKU.DataBindings.Add(propertyName, this.DataSource, "f09");
            cellConfirmedCH.DataBindings.Add(propertyName, this.DataSource, "f10");
            cellConfirmedPKU.DataBindings.Add(propertyName, this.DataSource, "f11");

           
        }

    }
}
