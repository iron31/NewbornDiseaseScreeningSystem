using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using Newborn_Disease_Screening_System.DA;

namespace Newborn_Disease_Screening_System.Report
{
    public partial class RptFirstResult : DevExpress.XtraReports.UI.XtraReport
    {
        DataRow _dr = null;
        DataTable _dt = null;
        FBSqlHelper _sqlhelp = new FBSqlHelper();
        string _type = string.Empty;
        public RptFirstResult(DataTable dt, DataRow dr,string type)
        {
            InitializeComponent();
            _dt = dt;
            _dr = dr;
            _type = type;
            Bindate();
        }

        public void Bindate()
        {
            switch (_type)
            {
                case "report":
                    lblTitle.Text = string.Format(lblTitle.Text,"报告单");
                    break;
                case "inform":
                    lblTitle.Text = string.Format(lblTitle.Text, "通知单");
                    break;
            }
            DataTable dtparams = new DataTable();
            string sqlparams = string.Format(@"select 
                                      nvs.item_name,
                                      nvs.units,
                                      nvs.normal_low_value,
                                      nvs.normal_high_value 
                                    from nb_standard_values nvs");
            dtparams = _sqlhelp.GetDataTable(sqlparams);
            for (int i = 0; i < dtparams.Rows.Count; i++)
            {
                if (dtparams.Rows[i]["item_name"].ToString() == "TSH")
                {
                    cellNormalTSH.Text = "< " + double.Parse(dtparams.Rows[i]["normal_high_value"].ToString()).ToString("0.00") + dtparams.Rows[i]["units"].ToString();
                }
                else if (dtparams.Rows[i]["item_name"].ToString() == "PHE")
                {
                    cellNormalPHE.Text = "< " + double.Parse(dtparams.Rows[i]["normal_high_value"].ToString()).ToString("0.00") + dtparams.Rows[i]["units"].ToString();
                }
                //else if (dtparams.Rows[i]["item_name"].ToString() == "G6PD")
                //{
                //    cellNormalG6PD.Text = "> " + double.Parse(dtparams.Rows[i]["normal_low_value"].ToString()).ToString("0.00") + dtparams.Rows[i]["units"].ToString();
                //}

            }
            //DataTable dt = new DataTable();
            //dt.Columns.Add("CARD_NO");
            //dt.Columns.Add("CARD_CODE");
            //dt.Columns.Add("ORGANIZATION_NAME");
            //dt.Columns.Add("MOTHER_NAME");
            //dt.Columns.Add("ILLCASE_NO");
            //dt.Columns.Add("BED_NO");
            //dt.Columns.Add("BIRTHDAY");
            //dt.Columns.Add("GET_BLOOD_DATE");
            //dt.Columns.Add("RECEIVE_DATE");
            //dt.Columns.Add("SEND_DATE");
            //dt.Columns.Add("CHECKER");
            //dt.Columns.Add("TSH");
            //dt.Columns.Add("PHE");
            //dt.Columns.Add("G6PD");

            if (_dr == null)
            {
                this.DataSource = _dt;
                string propertyName = "Text";
                cellCardNo.DataBindings.Add(propertyName, this.DataSource, "CARD_NO");
                cellCardCode.DataBindings.Add(propertyName, this.DataSource, "CARD_CODE");
                cellBirthday.DataBindings.Add(propertyName, this.DataSource, "BIRTHDAY");

                cellGetBloodDate.DataBindings.Add(propertyName, this.DataSource, "GET_BLOOD_DATE");
                cellIllCaseNo.DataBindings.Add(propertyName, this.DataSource, "ILLCASE_NO");
                cellMotherName.DataBindings.Add(propertyName, this.DataSource, "MOTHER_NAME");
                cellOrg.DataBindings.Add(propertyName, this.DataSource, "ORGANIZATION_NAME");
                cellBedNo.DataBindings.Add(propertyName, this.DataSource, "BED_NO");
                cellReceiveDate.DataBindings.Add(propertyName, this.DataSource, "RECEIVED_DATE");
                cellSendDate.DataBindings.Add(propertyName, this.DataSource, "SEND_DATE");
                cellTSH.DataBindings.Add(propertyName, this.DataSource, "TSH");
                cellPHE.DataBindings.Add(propertyName, this.DataSource, "PHE");
                //cellG6PD.DataBindings.Add(propertyName, this.DataSource, "G6PD");
            }
            else if (_dt == null)
            {
                cellCardNo.Text = _dr["CARD_NO"].ToString();
                cellCardCode.Text = _dr["CARD_CODE"].ToString();
                cellBirthday.Text = _dr["BIRTHDAY"].ToString();
                cellGetBloodDate.Text = _dr["GET_BLOOD_DATE"].ToString();
                cellIllCaseNo.Text = _dr["ILLCASE_NO"].ToString();
                cellMotherName.Text = _dr["MOTHER_NAME"].ToString();
                cellOrg.Text = _dr["ORGANIZATION_NAME"].ToString();
                cellBedNo.Text = _dr["BED_NO"].ToString();
                cellReceiveDate.Text = _dr["RECEIVED_DATE"].ToString();
                cellSendDate.Text = _dr["SEND_DATE"].ToString();
                cellTSH.Text = _dr["TSH"].ToString();
                cellPHE.Text = _dr["PHE"].ToString();
                //cellG6PD.Text = _dr["G6PD"].ToString();
            }

        }


    }
}
