using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using Newborn_Disease_Screening_System.DA;

namespace Newborn_Disease_Screening_System
{
    public partial class UCCardInfo : UserControl
    {
        private TabControl tc = null;
        UC.UCAddOrUpdateCard _newCard;
        FBSqlHelper _sqlhelp = new FBSqlHelper();
        Entity.NbDiseaseScreeningCard _card = new Entity.NbDiseaseScreeningCard();
        string _begDate;
        string _endDate;
        public UCCardInfo(TabControl tc)
        {
            InitializeComponent();
            this.tc = tc;
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            DA.DataAccess.removeTabPage("UpdateCard", tc);
            DA.DataAccess.removeTabPage("AddCard", tc);
            DA.DataAccess.removeTabPage("CardInfo", tc);
            tc.SelectedTab = tc.TabPages["tbMainPage"];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //DA.DataAccess.removeTabPage("CardInfo", tc);
            if (DA.DataAccess.PageIsExist("AddCard", tc))
            {
                return;
            }
            _newCard = new UC.UCAddOrUpdateCard(tc, "insert", null);
            DA.DataAccess.addTabPage("AddCard", "AddCard", _newCard, tc);

            tc.SelectedTab = tc.TabPages["AddCard"];
            //DA.DataAccess.removeTabPage("CardInfo", tc);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Entity.NbDiseaseScreeningCard card = new Entity.NbDiseaseScreeningCard();
            if (gridViewCardInfo.DataRowCount <= 0)
            {
                MessageBox.Show("未选中需要修改的记录!","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            
                //int i = this.gridViewCardInfo.FocusedRowHandle;
                //DataRow dr = this.gridViewCardInfo.GetDataRow(i);
                //showRowInfo(dr);
            
            if (DA.DataAccess.PageIsExist("UpdateCard", tc))
            {
                return;
            }
            _newCard = new UC.UCAddOrUpdateCard(tc, "update", _card);
            DA.DataAccess.addTabPage("UpdateCard", "UpdateCard", _newCard, tc);

            tc.SelectedTab = tc.TabPages["UpdateCard"];
            //DA.DataAccess.removeTabPage("CardInfo", tc);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // _handle = this.gridViewCardInfo.LocateByDisplayText(this.gridViewCardInfo.FocusedRowHandle + 1, this.gridViewCardInfo.Columns["ORG_CODE"], this.txtCardNo.Text);
            //if (_handle < 0)
            //{
               int _handle = this.gridViewCardInfo.LocateByDisplayText(0, this.gridViewCardInfo.Columns["CARD_NO"], this.txtCardNo.Text);
                if (_handle < 0)
                {
                    MessageBox.Show("没有目标记录！");
                    txtCardNo.Focus();
                    return;
                }
            //}
            this.gridViewCardInfo.FocusedRowHandle = _handle;
        }

        private void UCCardInfo_Load(object sender, EventArgs e)
        {
            dateEditBegDate.DateTime = System.DateTime.Now.Date;
            dateEditEndDate.DateTime = System.DateTime.Now.Date.AddDays(1);
            dateBinding();
        }

        private void dateBinding()
        {
            _begDate = dateEditBegDate.DateTime.ToString();
            _endDate = dateEditEndDate.DateTime.ToString();
            DataTable dt = new DataTable();
            dt = queryView(_begDate, _endDate);
            this.gridControlCardInfo.DataSource = dt;
        }

        private DataTable queryView(string begDate, string endDate)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT * FROM VW_NB_DISEASE_CARD ndsc
                            where ndsc.CREATE_DATE between ? and ?
                            ";
            dt = _sqlhelp.Query("", sql, new[] { begDate, endDate });
            return dt;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            _begDate = dateEditBegDate.DateTime.ToString();
            _endDate = dateEditEndDate.DateTime.ToString();
            this.gridControlCardInfo.DataSource = queryView(_begDate, _endDate);

        }

        private void showRowInfo(DataRow dr)
        {
            if(dr!=null)
            {
                _card.Card_Id = long.Parse(dr["card_id"].ToString());
                _card.Card_No = dr["Card_No"].ToString();
                _card.Organization_Name = dr["Organization_Name"].ToString();
                _card.Health_Code = dr["Health_Code"].ToString();
                _card.Illcase_No = dr["Illcase_No"].ToString();
                _card.Bed_No = dr["Bed_No"].ToString();
                _card.Mother_Name = dr["Mother_Name"].ToString();
                _card.Gestational_Weeks = dr["Gestational_Weeks"].ToString();
                _card.Weight = dr["Weight"].ToString();
                _card.Gender = dr["Gender"].ToString();
                _card.Birthday = DateTime.Parse(dr["Birthday"].ToString());
                _card.Get_Blood_User_Name = dr["Get_Blood_User_Name"].ToString();
                _card.Qualified = dr["Qualified"].ToString();
                _card.Reason = dr["Reason"].ToString();
                _card.Received_Date = DateTime.Parse(dr["Received_Date"].ToString());
                _card.Send_Date = DateTime.Parse(dr["Send_Date"].ToString());
                _card.Yield_Mode = dr["Yield_Mode"].ToString();
                _card.Apgar = dr["Apgar"].ToString();
                _card.Anamnesis = dr["Anamnesis"].ToString();
                _card.Feeding_Times = dr["Feeding_Times"].ToString();
                _card.Antibiotic = dr["Antibiotic"].ToString();
                _card.Iodine = dr["Iodine"].ToString();
                _card.Transfusion = dr["Transfusion"].ToString();
                _card.Phone_No = dr["Phone_No"].ToString();
                _card.Address = dr["Address"].ToString();
                _card.Report = dr["Report"].ToString();
                _card.Get_Blood_Date = DateTime.Parse(dr["Get_Blood_Date"].ToString());
                _card.Card_Code = dr["Card_Code"].ToString();
                _card.Lot_No = dr["Lot_No"].ToString();
                _card.Organization_Id = int.Parse(dr["Organization_Id"].ToString());
                _card.Create_Date = DateTime.Parse(dr["Create_Date"].ToString());
                _card.Create_By = int.Parse(dr["Create_By"].ToString());

                _card.Update_Date = DateTime.Parse(dr["Update_Date"].ToString());
                _card.Update_By = int.Parse(dr["Update_By"].ToString());
                _card.Gestational_Days = dr["Gestational_Days"].ToString();

                _card.Gender_Info = dr["gender_info"].ToString();
                _card.Qualified_Info = dr["qualified_info"].ToString();
                _card.Reason_Info = dr["reason_info"].ToString();
                _card.Yieldmode_Info = dr["yieldmode_info"].ToString();
                _card.Anamnesis_Info = dr["anamnesis_info"].ToString();
                _card.Antibiotics_Info = dr["antibiotics_info"].ToString();
                _card.Iodine_Info = dr["iodine_info"].ToString();
                _card.Transfusion_Info = dr["transfusion_info"].ToString();
                _card.Report_Info = dr["report_info"].ToString();


                lblHealthCode.Text = dr["Health_Code"].ToString();
                lblIllCaseNo.Text = _card.Illcase_No;
                lblGestationalWeeks.Text =  dr["Gestational_Weeks"].ToString()+"+"+dr["Gestational_Days"].ToString();
                lblBirthday.Text = dr["Birthday"].ToString();
                lblApgar.Text = dr["Apgar"].ToString();
                lblAnamnesis.Text = dr["Anamnesis"].ToString();
                lblAntibiotic.Text = dr["Antibiotic"].ToString();
                lblIodine.Text = dr["Iodine"].ToString();
                lblTransfusion.Text = dr["Transfusion"].ToString();
                lblAddress.Text = dr["Address"].ToString();
                lblCardCode.Text = dr["Card_Code"].ToString();
            }
            
            
        }

        private void gridViewCardInfo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           
            if (gridViewCardInfo.DataRowCount > 0)
            {
                int i = this.gridViewCardInfo.FocusedRowHandle;
                DataRow dr = this.gridViewCardInfo.GetDataRow(i);
                _card.Card_Id = long.Parse(dr["card_id"].ToString());
                _card.Card_No = dr["Card_No"].ToString();
                _card.Organization_Name = dr["Organization_Name"].ToString();
                _card.Health_Code = dr["Health_Code"].ToString();
                _card.Illcase_No = dr["Illcase_No"].ToString();
                _card.Bed_No = dr["Bed_No"].ToString();
                _card.Mother_Name = dr["Mother_Name"].ToString();
                _card.Gestational_Weeks = dr["Gestational_Weeks"].ToString();
                _card.Weight = dr["Weight"].ToString();
                _card.Gender = dr["Gender"].ToString();
                _card.Birthday = DateTime.Parse(dr["Birthday"].ToString());
                _card.Get_Blood_User_Name = dr["Get_Blood_User_Name"].ToString();
                _card.Qualified = dr["Qualified"].ToString();
                _card.Reason = dr["Reason"].ToString();
                _card.Received_Date = DateTime.Parse(dr["Received_Date"].ToString());
                _card.Send_Date = DateTime.Parse(dr["Send_Date"].ToString());
                _card.Yield_Mode = dr["Yield_Mode"].ToString();
                _card.Apgar = dr["Apgar"].ToString();
                _card.Anamnesis = dr["Anamnesis"].ToString();
                _card.Feeding_Times = dr["Feeding_Times"].ToString();
                _card.Antibiotic = dr["Antibiotic"].ToString();
                _card.Iodine = dr["Iodine"].ToString();
                _card.Transfusion = dr["Transfusion"].ToString();
                _card.Phone_No = dr["Phone_No"].ToString();
                _card.Address = dr["Address"].ToString();
                _card.Report = dr["Report"].ToString();
                _card.Get_Blood_Date = DateTime.Parse(dr["Get_Blood_Date"].ToString());
                _card.Card_Code = dr["Card_Code"].ToString();
                _card.Lot_No = dr["Lot_No"].ToString();
                _card.Organization_Id = int.Parse(dr["Organization_Id"].ToString());
                _card.Create_Date = DateTime.Parse(dr["Create_Date"].ToString());
                _card.Create_By = int.Parse(dr["Create_By"].ToString());

                _card.Update_Date = DateTime.Parse(dr["Update_Date"].ToString());
                _card.Update_By = int.Parse(dr["Update_By"].ToString());
                _card.Gestational_Days = dr["Gestational_Days"].ToString();

                _card.Gender_Info = dr["gender_info"].ToString();
                _card.Qualified_Info = dr["qualified_info"].ToString();
                _card.Reason_Info = dr["reason_info"].ToString();
                _card.Yieldmode_Info = dr["yieldmode_info"].ToString();
                _card.Anamnesis_Info = dr["anamnesis_info"].ToString();
                _card.Antibiotics_Info = dr["antibiotics_info"].ToString();
                _card.Iodine_Info = dr["iodine_info"].ToString();
                _card.Transfusion_Info = dr["transfusion_info"].ToString();
                _card.Report_Info = dr["report_info"].ToString();


                lblHealthCode.Text = _card.Health_Code;
                lblIllCaseNo.Text = _card.Illcase_No;
                lblGestationalWeeks.Text = _card.Gestational_Weeks + "+" + _card.Gestational_Days;
                lblBirthday.Text = _card.Birthday.ToString();
                lblApgar.Text = _card.Apgar;
                lblAnamnesis.Text = _card.Anamnesis_Info;
                lblAntibiotic.Text = _card.Antibiotics_Info;
                lblIodine.Text = _card.Iodine_Info;
                lblTransfusion.Text = _card.Transfusion_Info;
                lblAddress.Text = _card.Address;
                lblCardCode.Text = _card.Card_Code;
            }
        }
    }
}
