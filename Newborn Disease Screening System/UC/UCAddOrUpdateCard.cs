using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newborn_Disease_Screening_System.DA;
using FirebirdSql.Data.FirebirdClient;
using Newborn_Disease_Screening_System.Forms;

namespace Newborn_Disease_Screening_System.UC
{
    public partial class UCAddOrUpdateCard : UserControl
    {
        #region 初始化
        private TabControl tc = null;
        FBSqlHelper _sqlhelp = new FBSqlHelper();
        Entity.NbDiseaseScreeningCard _card = new Entity.NbDiseaseScreeningCard();

        string _flag;
        public UCAddOrUpdateCard(TabControl tc, string flag, Entity.NbDiseaseScreeningCard card)
        {
            InitializeComponent();
            this.tc = tc;
            this._flag = flag;
            _card = card;
        }

        private void dataBingding()
        {

            #region insert
            if (_flag == "insert")
            {
                if (string.IsNullOrEmpty(Entity.GmUser.Current_no))
                {
                    //pcCardInfo.Enabled = false; 
                    this.btnSetNo.Focus();
                }
                else
                {
                    //pcCardInfo.Enabled = true;
                    this.txtCardCode.Focus();
                }
                lbflag.Text = "新增疾病卡";
                lblCurrentNoName.Text = "当前号码:";
                if (!string.IsNullOrEmpty(Entity.GmUser.Beg_no))
                {
                    txtBegCardNo.Text = Entity.GmUser.Beg_no;
                    txtEndCardNo.Text = Entity.GmUser.End_no;
                    lblCurrentNo.Text = Entity.GmUser.Current_no;
                    btnSetNo.Enabled = true;
                }
                txtLotNo.Text = System.DateTime.Today.ToShortDateString().Replace("/","");
            }
            #endregion
            #region update
            else if (_flag == "update")
            {
                clear();

                lblCurrentNo.Text = _card.Card_No;
                cbOrganization.SelectedValue = _card.Organization_Id.ToString();
                cbOrganization.Text = _card.Organization_Name;

                cbGender.Text = _card.Gender_Info;
                cbGender.SelectedValue = _card.Gender;

                cbReason.Text = _card.Reason_Info;
                //cbReason.EditValue = _card.Reason;
                //cbReason.Properties.Items[3].CheckState = CheckState.Checked;
                //cbReason.SetEditValue( );
                string[] strarr = _card.Reason.Split(',');
                foreach (var i in strarr)
                {
                    for(int j=0;j<cbReason.Properties.Items.Count;j++)
                    {
                    if (cbReason.Properties.Items[j].Value.ToString()==i.ToString().Trim())
                      {
                          cbReason.Properties.Items[j].CheckState = CheckState.Checked;
                      }
                    }
                    
                }
               

                cbQualiFied.Text = _card.Qualified_Info;
                cbQualiFied.SelectedIndex = int.Parse(_card.Qualified);

                cbYieldMode.Text = _card.Yieldmode_Info;
                cbYieldMode.SelectedIndex = int.Parse(_card.Yield_Mode);

                cbAnamnesis.Text = _card.Anamnesis_Info;
                cbAnamnesis.SelectedIndex = int.Parse(_card.Anamnesis);

                cbAntibiotics.Text = _card.Antibiotics_Info;
                cbAntibiotics.SelectedIndex = int.Parse(_card.Antibiotic);

                cbIodine.Text = _card.Iodine_Info;
                cbIodine.SelectedIndex = int.Parse(_card.Iodine);

                cbTransfusion.Text = _card.Transfusion_Info;
                cbTransfusion.SelectedIndex = int.Parse(_card.Transfusion);

                cbReport.Text = _card.Report_Info;
                cbReport.SelectedIndex = int.Parse(_card.Report);
                lbflag.Text = "修改疾病卡";
                lblCurrentNoName.Text = "修改号码";
                lblCurrentNo.Text = _card.Card_No;
                btnSetNo.Enabled = false;

                txtHealthNo.Text = _card.Health_Code;
                txtCardCode.Text = _card.Card_Code;
                txtIllCaseNo.Text = _card.Illcase_No;
                txtBedNo.Text = _card.Bed_No;
                txtMotherName.Text = _card.Mother_Name;
                txtGestationalWeeks.Text = _card.Gestational_Weeks;
                txtGestationalDays.Text = _card.Gestational_Days;
                txtWeight.Text = _card.Weight;
                deBirthday.DateTime = _card.Birthday;
                deGetBloodDate.DateTime = _card.Get_Blood_Date;
                deReceiveDate.DateTime = _card.Received_Date;
                txtGetBloodUserName.Text = _card.Get_Blood_User_Name;
                deSendDate.DateTime = _card.Send_Date;
                txtApgar.Text = _card.Apgar;
                txtFeedingTimes.Text = _card.Feeding_Times;
                txtPhoneNo.Text = _card.Phone_No;
                txtAddress.Text = _card.Address;
                txtLotNo.Text = _card.Lot_No;

            }
            #endregion
        }
        #endregion

        #region 事件

        private void UCAddOrUpdateCard_Load(object sender, EventArgs e)
        {
            string sql = "select org_id,org_code||org_name org_name from gm_organization  ";
            this.cbOrganization.DataSource = _sqlhelp.GetDataTable(sql);
            cbOrganization.DisplayMember = "ORG_NAME";
            cbOrganization.ValueMember = "ORG_ID";
            this.cbOrganization.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cbOrganization.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            sql = "select * from gm_params gps where gps.types='GENDER' and status='1' ";
            cbGender.DataSource = _sqlhelp.GetDataTable(sql);
            cbGender.DisplayMember = "OBJECT_NAME";
            cbGender.ValueMember = "type_value";

            sql = "select * from gm_params gps where gps.types='REASON' and status='1' ";
            //cbReason1.DataSource = _sqlhelp.GetDataTable(sql);
            //cbReason1.DisplayMember = "OBJECT_NAME";
            //cbReason1.ValueMember = "type_value";
            DataTable da = _sqlhelp.GetDataTable(sql);
            for (int i = 0; i < da.Rows.Count; i++)
            {
                cbReason.Properties.Items.Add(da.Rows[i]["type_value"].ToString(), da.Rows[i]["OBJECT_NAME"].ToString());
            }
            //cbReason.Properties.DataSource = _sqlhelp.GetDataTable(sql);
            //cbReason.Properties.DisplayMember = "OBJECT_NAME";
            //cbReason.Properties.ValueMember = "type_value";
            


            sql = "select * from gm_params gps where gps.types='QUALIFIED' and status='1' ";
            cbQualiFied.DataSource = _sqlhelp.GetDataTable(sql);
            cbQualiFied.DisplayMember = "OBJECT_NAME";
            cbQualiFied.ValueMember = "type_value";



            sql = "select * from gm_params gps where gps.types='YIELDMODE' and status='1' ";
            cbYieldMode.DataSource = _sqlhelp.GetDataTable(sql);
            cbYieldMode.DisplayMember = "OBJECT_NAME";
            cbYieldMode.ValueMember = "type_value";

            sql = "select * from gm_params gps where gps.types='ANAMNESIS' and status='1' ";
            cbAnamnesis.DataSource = _sqlhelp.GetDataTable(sql);
            cbAnamnesis.DisplayMember = "OBJECT_NAME";
            cbAnamnesis.ValueMember = "type_value";

            sql = "select * from gm_params gps where gps.types='ANTIBIOTICS' and status='1' ";
            cbAntibiotics.DataSource = _sqlhelp.GetDataTable(sql);
            cbAntibiotics.DisplayMember = "OBJECT_NAME";
            cbAntibiotics.ValueMember = "type_value";

            sql = "select * from gm_params gps where gps.types='IODINE' and status='1' ";
            cbIodine.DataSource = _sqlhelp.GetDataTable(sql);
            cbIodine.DisplayMember = "OBJECT_NAME";
            cbIodine.ValueMember = "type_value";

            sql = "select * from gm_params gps where gps.types='TRANSFUSION' and status='1' ";
            cbTransfusion.DataSource = _sqlhelp.GetDataTable(sql);
            cbTransfusion.DisplayMember = "OBJECT_NAME";
            cbTransfusion.ValueMember = "type_value";

            sql = "select * from gm_params gps where gps.types='REPORT' and status='1' ";
            cbReport.DataSource = _sqlhelp.GetDataTable(sql);
            cbReport.DisplayMember = "OBJECT_NAME";
            cbReport.ValueMember = "type_value";

            dataBingding();
        }


        private void txtBegCardNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtEndCardNo.Focus();
            }
        }
        private void cbOrganization_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtCardCode.Focus();
            }
        }
        private void txtCardCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtIllCaseNo.Focus();
            }
        }
        private void txtIllCaseNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBedNo.Focus();
            }
        }
        private void txtBedNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMotherName.Focus();
            }
        }
        private void txtMotherName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtGestationalWeeks.Focus();
            }
        }
        private void txtGestationalWeeks_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtGestationalDays.Focus();
            }
        }
        private void txtGestationalDays_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWeight.Focus();
            }
        }
        private void txtWeight_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbGender.Focus();
            }
        }
        private void cbGender_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                deBirthday.Focus();
            }
        }
        private void deBirthday_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (deBirthday.SelectionStart.ToString() == "11")
                //{
                deGetBloodDate.Focus();
                //}
                //else
                //    SendKeys.Send("{RIGHT}");
            }

        }
        private void deGetBloodDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (this.deGetBloodDate.SelectionStart.ToString() == "11")
                //{
                this.deReceiveDate.Focus();
                //}
                //else
                //    SendKeys.Send("{RIGHT}");
            }
        }
        private void deReceiveDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (this.deReceiveDate.SelectionStart.ToString() == "8")
                //{
                this.txtGetBloodUserName.Focus();
                //}
                //else
                //    SendKeys.Send("{RIGHT}");
            }
        }
        private void txtGetBloodUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbQualiFied.Focus();
            }
        }
        private void cbQualiFied_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cbQualiFied.Text == "不合格")
            {
                cbReason.Focus();
            }
            if (e.KeyCode == Keys.Enter && cbQualiFied.Text == "合格")
            {
                cbAnamnesis.Focus();
            }
        }
        private void cbReason_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbAnamnesis.Focus();
            }
        }
        private void deSendDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (this.deSendDate.SelectionStart.ToString() == "8")
                //{
                this.cbYieldMode.Focus();
                //}
                //else
                //    SendKeys.Send("{RIGHT}");
            }
        }
        private void cbYieldMode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtApgar.Focus();
            }
        }
        private void txtApgar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbAnamnesis.Focus();
            }
        }
        private void cbAnamnesis_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPhoneNo.Focus();
            }
        }
        private void txtFeedingTimes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbAntibiotics.Focus();
            }
        }
        private void cbAntibiotic_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbIodine.Focus();
            }
        }
        private void cbIodine_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbTransfusion.Focus();
            }
        }
        private void cbTransfusion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPhoneNo.Focus();
            }
        }
        private void txtPhoneNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress.Focus();
            }
        }
        private void txtAddress_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }
        private void txtLotNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }
        private void cbGetBloodUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbQualiFied.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region 新增疾病卡
            if (this.cbQualiFied.SelectedIndex == 0)
            {
                this.cbReason.Text = null;
                this.cbReason.SetEditValue (0020);
            }
          
            if (_flag == "insert")
            {
                if (!cardNoexists(lblCurrentNo.Text.Trim()))
                {
                    MessageBox.Show("该卡号的疾病筛查卡已存在!");
                    return;
                }
                if (!checkCurrentNo(sender, e))
                {
                    return;
                }
                else if (!checkNotNull())
                {
                    return;
                }
                else
                {

                    string i = cbGender.SelectedValue.ToString();
                    
                    // string insertCard = Sql.addNewCard;
                    string insertCard = string.Format(@"insert into nb_disease_screening_card (
                                          card_no, 
                                          organization_name, 
                                          health_code, 
                                          illcase_no, 
                                          bed_no, 
                                          mother_name, 
                                          gestational_weeks, 
                                          weight, 
                                          gender, 
                                          birthday, 
                                          get_blood_user_name, 
                                          qualified, 
                                          reason, 
                                          received_date, 
                                          send_date, 
                                          yield_mode, 
                                          apgar, 
                                          anamnesis, 
                                          feeding_times, 
                                          antibiotic, 
                                          iodine, 
                                          transfusion, 
                                          phone_no, 
                                          address, 
                                          report, 
                                          create_date, 
                                          create_by, 
                                          update_date, 
                                          update_by, 
                                          get_blood_date, 
                                          card_code, 
                                          lot_no,
                                          organization_id,
                                          Gestational_Days,
                                          reason_info) 
                                         values (
                                         '{0}', 
                                          '{1}', 
                                          NULLIF('{2}',''), 
                                          '{3}', 
                                          '{4}', 
                                          '{5}', 
                                          NULLIF('{6}',''), 
                                          NULLIF('{7}',''), 
                                          '{8}', 
                                          '{9}', 
                                          NULLIF('{10}',''), 
                                          '{11}', 
                                          NULLIF('{12}',''), 
                                          '{13}', 
                                          '{14}', 
                                          '{15}', 
                                          '{16}', 
                                          NULLIF('{17}',''),  
                                          NULLIF('{18}',''), 
                                          '{19}', 
                                          '{20}', 
                                          '{21}', 
                                          NULLIF('{22}',''), 
                                          NULLIF('{23}',''),
                                          '{24}', 
                                          {25}, 
                                          '{26}', 
                                          {27},
                                          '{28}',
                                          '{29}', 
                                          NULLIF('{30}',''), 
                                          NULLIF('{31}',''), 
                                          '{32}',
                                          NULLIF('{33}',''),
                                          NULLIF('{34}',''))", lblCurrentNo.Text, cbOrganization.Text, txtHealthNo.Text
                                    , txtIllCaseNo.Text, txtBedNo.Text, txtMotherName.Text, txtGestationalWeeks.Text
                                    , txtWeight.Text, cbGender.SelectedValue, deBirthday.DateTime.ToString("yyyy-MM-dd HH:mm:ss")
                                    , txtGetBloodUserName.Text, cbQualiFied.SelectedValue, cbReason.EditValue.ToString().Trim()
                                    , deReceiveDate.DateTime.ToString("yyyy-MM-dd"), deSendDate.DateTime.ToString("yyyy-MM-dd")
                                    , cbYieldMode.SelectedValue, txtApgar.Text, cbAnamnesis.SelectedValue
                                    , txtFeedingTimes.Text, cbAntibiotics.SelectedValue, cbIodine.SelectedValue
                                    , cbTransfusion.SelectedValue, txtPhoneNo.Text, txtAddress.Text, this.cbReport.SelectedValue, "CURRENT_TIMESTAMP"
                                    , Entity.GmUser.User_id.ToString(), "CURRENT_TIMESTAMP", Entity.GmUser.User_id.ToString(), deGetBloodDate.DateTime.ToString("yyyy-MM-dd HH:mm:ss")
                                    , txtCardCode.Text, txtLotNo.Text, cbOrganization.SelectedValue
                                    , txtGestationalDays.Text,cbReason.Text.Trim());
                    
                    string updateUser = string.Format(@"update gm_user set current_no='{0}' where user_id ={1} and status='1'", int.Parse(Entity.GmUser.Current_no)+1, Entity.GmUser.User_id.ToString());
                    #region
                    //object[] Params1 = new object[] { lblCurrentNo.Text,cbOrganization.Text,txtHealthNo.Text
                    //                ,txtIllCaseNo.Text,txtBedNo.Text,txtMotherName.Text,txtGestationalWeeks.Text
                    //                ,txtWeight.Text,cbGender.SelectedValue,deBirthday.DateTime.ToString("yyyy-MM-dd HH:mm:ss")
                    //                ,txtGetBloodUserName.Text,cbQualiFied.SelectedValue,cbReason.SelectedValue
                    //                ,deReceiveDate.DateTime.ToString("yyyy-MM-dd"),deSendDate.DateTime.ToString("yyyy-MM-dd")
                    //                ,cbYieldMode.SelectedValue,txtApgar.Text,cbAnamnesis.SelectedValue
                    //                ,txtFeedingTimes.Text,cbAntibiotics.SelectedValue,cbIodine.SelectedValue
                    //                ,cbTransfusion.SelectedValue,txtPhoneNo.Text,txtAddress.Text,this.cbReport.SelectedValue,"CURRENT_TIMESTAMP"
                    //                ,Entity.GmUser.User_id.ToString(),"","",deGetBloodDate.DateTime.ToString("yyyy-MM-dd HH:mm:ss")
                    //                ,txtCardCode.Text,txtLotNo.Text,cbOrganization.SelectedValue
                    //                ,txtGestationalDays.Text};

                    //            //                              feeding_times,
                    //            //                              antibiotic,
                    //            //                              iodine
                    //             string insertCard= @"insert into nb_disease_screening_card (
                    //                                          card_no,
                    //                                          organization_name, 
                    //                                          health_code,
                    //                                          illcase_no, 
                    //                                          bed_no, 
                    //                                          mother_name, 
                    //                                          gestational_weeks, 
                    //                                          weight, 
                    //                                          gender,
                    //                                          birthday,
                    //                                          get_blood_user_name, 
                    //                                          qualified, 
                    //                                          reason,
                    //                                          received_date, 
                    //                                          send_date,
                    //                                          yield_mode, 
                    //                                          --apgar
                    //                                          --anamnesis,
                    //                                         feeding_times
                    //                                          --antibiotic,
                    //                                          --iodine
                    //                                          ) 
                    //                                         values (
                    //                                         ?,
                    //                                         ?, 
                    //                                         ?,
                    //                                         ?,
                    //                                         ?, 
                    //                                         ?,
                    //                                         ?,
                    //                                         ?, 
                    //                                         ?,
                    //                                         ?,
                    //                                         ?,
                    //                                         ?,
                    //                                         ?,
                    //                                         ?, 
                    //                                         ?,
                    //                                         ?,
                    //                                         --?,
                    //                                        -- ?,
                    //                                        -- ?,
                    //                                        -- ?,
                    //                                         ?
                    //                                          )";
                    //                object[] Params1 = new object[] { lblCurrentNo.Text,cbOrganization.Text,txtHealthNo.Text==""?null:txtHealthNo.Text
                    //                                   ,txtIllCaseNo.Text==""?null:txtIllCaseNo.Text,txtBedNo.Text==""?null:txtBedNo.Text,txtMotherName.Text==""?null:txtMotherName.Text
                    //                                   ,txtGestationalWeeks.Text==""?null:txtGestationalWeeks.Text,txtWeight.Text==""?null:txtWeight.Text,cbGender.SelectedValue
                    //                                   ,deBirthday.DateTime.ToString("yyyy-MM-dd HH:mm:ss"),txtGetBloodUserName.Text==""?null:txtGetBloodUserName.Text,cbQualiFied.SelectedValue
                    //                                   ,cbReason.SelectedValue,deReceiveDate.DateTime.ToString("yyyy-MM-dd"),deSendDate.DateTime.ToString("yyyy-MM-dd")=="0001-01-01"?null:deSendDate.DateTime.ToString("yyyy-MM-dd")
                    //                                   , cbYieldMode.SelectedValue//,txtApgar.Text==""?null:txtApgar.Text//, cbAnamnesis.SelectedValue
                    //                                   , txtFeedingTimes.Text==""?null:txtFeedingTimes.Text //, cbAntibiotics.SelectedValue, cbIodine.SelectedValue
                    //                                  };
                    //object[] Params2 = new object[] { Entity.GmUser.Current_no, Entity.GmUser.User_id.ToString() };
                    #endregion
                    
                    FbTransaction ts = null;
                    int count = _sqlhelp.ExecuteNonQuery(ts, new string[] { insertCard, updateUser });
                    if (count == 2)
                    {

                        MessageBox.Show("保存成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        Entity.GmUser.Current_no = lblCurrentNo.Text = (double.Parse(Entity.GmUser.Current_no) + 1).ToString();
                        this.cbOrganization.Focus();
                    }
                }
            }
            #endregion
            #region 修改疾病卡
            else if (_flag == "update")
            {
                if (!checkNotNull())
                {
                    return;
                }
                Entity.NbDiseaseScreeningCard card = new Entity.NbDiseaseScreeningCard();
                card = _card;
                card.Organization_Id = int.Parse(cbOrganization.SelectedValue.ToString());
                card.Organization_Name = cbOrganization.Text.Trim();

                card.Gender_Info = cbGender.Text.Trim();
                card.Gender = cbGender.SelectedValue.ToString();

                card.Reason_Info = cbReason.Text.Trim();
                card.Reason = cbReason.EditValue.ToString();

                card.Qualified_Info = cbQualiFied.Text.Trim();
                card.Qualified = cbQualiFied.SelectedValue.ToString();

                card.Yieldmode_Info = cbYieldMode.Text.Trim();
                card.Yield_Mode = cbYieldMode.SelectedValue.ToString();

                card.Anamnesis_Info = cbAnamnesis.Text.Trim();
                card.Anamnesis = cbAnamnesis.SelectedValue.ToString();

                card.Antibiotics_Info = cbAntibiotics.Text.Trim();
                card.Antibiotic = cbAntibiotics.SelectedValue.ToString();

                card.Iodine_Info = cbIodine.Text.Trim();
                card.Iodine = cbIodine.SelectedValue.ToString();

                card.Transfusion_Info = cbTransfusion.Text.Trim();
                card.Transfusion = cbTransfusion.SelectedValue.ToString();

                card.Report_Info = cbReport.Text.Trim();
                card.Report = cbReport.SelectedValue.ToString();

                card.Health_Code = txtHealthNo.Text.Trim();
                card.Card_Code = txtCardCode.Text.Trim();
                card.Illcase_No = txtIllCaseNo.Text.Trim();
                card.Bed_No = txtBedNo.Text.Trim();
                card.Mother_Name = txtMotherName.Text.Trim();
                card.Gestational_Weeks = txtGestationalWeeks.Text.Trim();
                card.Gestational_Days = txtGestationalDays.Text.Trim();
                card.Weight = txtWeight.Text.Trim();
                card.Birthday = deBirthday.DateTime;
                card.Get_Blood_Date = deGetBloodDate.DateTime;
                card.Received_Date = deReceiveDate.DateTime;
                card.Get_Blood_User_Name = txtGetBloodUserName.Text.Trim();
                card.Send_Date = deSendDate.DateTime;
                card.Apgar = txtApgar.Text.Trim();
                card.Feeding_Times = txtFeedingTimes.Text.Trim();
                card.Phone_No = txtPhoneNo.Text.Trim();
                card.Address = txtAddress.Text.Trim();
                card.Lot_No = txtLotNo.Text.Trim();


                string updateCard = string.Format(@"UPDATE
                                                    NB_DISEASE_SCREENING_CARD
                                                SET
                                                    ORGANIZATION_NAME = '{0}',
                                                    HEALTH_CODE = NULLIF('{1}',''),
                                                    ILLCASE_NO = '{2}',
                                                    BED_NO = '{3}',
                                                    MOTHER_NAME = '{4}',
                                                    GESTATIONAL_WEEKS = NULLIF('{5}',''),
                                                    WEIGHT = NULLIF('{6}',''),
                                                    GENDER = '{7}',
                                                    BIRTHDAY = '{8}',
                                                    GET_BLOOD_USER_NAME =NULLIF( '{9}',''),
                                                    QUALIFIED = '{10}',
                                                    REASON = '{11}',
                                                    RECEIVED_DATE = '{12}',
                                                    SEND_DATE = '{13}',
                                                    YIELD_MODE = '{14}',
                                                    APGAR =NULLIF( '{15}',''),
                                                    ANAMNESIS = '{16}',
                                                    FEEDING_TIMES = NULLIF('{17}',''),
                                                    ANTIBIOTIC = '{18}',
                                                    IODINE = '{19}',
                                                    TRANSFUSION = '{20}',
                                                    PHONE_NO = NULLIF('{21}',''),
                                                    ADDRESS = NULLIF('{22}',''),
                                                    REPORT = '{23}',
                                                    UPDATE_DATE = {24},
                                                    UPDATE_BY = '{25}',
                                                    GET_BLOOD_DATE = '{26}',
                                                    CARD_CODE = NULLIF('{27}',''),
                                                    LOT_NO = NULLIF('{28}',''),
                                                    ORGANIZATION_ID = '{29}',
                                                    GESTATIONAL_DAYS = NULLIF('{30}',''),
                                                    REASON_INFO = NULLIF('{31}','')
                                                WHERE
                                                    CARD_ID = '{32}'",
                                                    card.Organization_Name, card.Health_Code, card.Illcase_No,
                                                    card.Bed_No, card.Mother_Name, card.Gestational_Weeks,
                                                    card.Weight, card.Gender, card.Birthday,
                                                    card.Get_Blood_User_Name, card.Qualified, card.Reason,
                                                    card.Received_Date, card.Send_Date, card.Yield_Mode,
                                                    card.Apgar, card.Anamnesis, card.Feeding_Times,
                                                    card.Antibiotic, card.Iodine, card.Transfusion,
                                                    card.Phone_No, card.Address, card.Report,
                                                    "CURRENT_TIMESTAMP", Entity.GmUser.User_id, card.Get_Blood_Date,
                                                    card.Card_Code, card.Lot_No, card.Organization_Id,
                                                    card.Gestational_Days,card.Reason_Info,
                                                    card.Card_Id
                                                );
                int count = _sqlhelp.ExecuteNonQuery(updateCard);
                if (count == 1)
                {
                    MessageBox.Show("更新成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            #endregion
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            //if (DA.DataAccess.PageIsExist("CardInfo", tc))
            //{
            //    return;
            //}
            //UCCardInfo _cardInfo = new UCCardInfo(tc);
            //DA.DataAccess.addTabPage("CardInfo", "CardInfo", _cardInfo, tc);
            DialogResult dr = MessageBox.Show("确定要退出吗?未保存的数据将丢失!", "警告", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                tc.SelectedTab = tc.TabPages["CardInfo"];
                if (_flag == "insert")
                {
                    DA.DataAccess.removeTabPage("AddCard", tc);
                }
                else if (_flag == "update")
                {
                    DA.DataAccess.removeTabPage("UpdateCard", tc);
                }
            }
            

        }

        private void btnSetNo_Click(object sender, EventArgs e)
        {
            FormEditCardNo editCard = new FormEditCardNo();
            editCard.ShowDialog();
            if (editCard.DialogResult == DialogResult.Cancel)
            {
                txtBegCardNo.Text = Entity.GmUser.Beg_no;
                lblCurrentNo.Text = Entity.GmUser.Current_no;
                txtEndCardNo.Text = Entity.GmUser.End_no;
            }

        }

        private void cbQualiFied_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.cbReason.SelectedIndex = this.cbQualiFied.SelectedIndex;
            if (this.cbQualiFied.SelectedIndex == 0)
            {
                this.cbReason.Enabled = false;
            }
            else
            {
                this.cbReason.Enabled = true;
                //this.cbReason.SelectedText = null;
                //this.cbReason.EditValue = null;
            }
        }




        #endregion

        #region 方法

        private void clear()
        {
            cbReason.SetEditValue("");
            cbQualiFied.SelectedIndex = cbIodine.SelectedIndex = cbGender.SelectedIndex = cbAnamnesis.SelectedIndex = cbReport.SelectedIndex
                = cbYieldMode.SelectedIndex = cbTransfusion.SelectedIndex = 0;
            txtHealthNo.Text = txtIllCaseNo.Text = txtBedNo.Text = txtMotherName.Text = txtGestationalWeeks.Text = txtGestationalDays.Text
                                = txtWeight.Text = cbGender.Text = deBirthday.Text = txtGetBloodUserName.Text = cbQualiFied.Text = cbReason.Text
                                = cbYieldMode.Text = txtApgar.Text = cbAnamnesis.Text = txtFeedingTimes.Text
                                = cbAntibiotics.Text = cbIodine.Text = cbTransfusion.Text = txtPhoneNo.Text = txtAddress.Text = cbReason.Text
                                = deGetBloodDate.Text = txtCardCode.Text  = string.Empty;
            if(_flag=="update")
            {
                lblCurrentNo.Text = string.Empty;
            }
        }
        private bool checkCurrentNo(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblCurrentNo.Text))
            {
                DialogResult dr;
                dr = MessageBox.Show("当前卡号段未设置,是否设置?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    btnSetNo_Click(sender, e);
                }
                return false;
            }
            return true;
        }
        private bool checkNotNull()
        {
            if (string.IsNullOrEmpty(cbOrganization.Text))
            {
                MessageBox.Show("请选择医疗机构名称!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbOrganization.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtIllCaseNo.Text))
            {
                MessageBox.Show("住院号不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtIllCaseNo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtBedNo.Text))
            {
                MessageBox.Show("床位号不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtBedNo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtMotherName.Text))
            {
                MessageBox.Show("母亲姓名不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMotherName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbGender.Text))
            {
                MessageBox.Show("请选择性别!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbGender.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(deBirthday.Text))
            {
                MessageBox.Show("出生日期不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                deBirthday.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(deGetBloodDate.Text))
            {
                MessageBox.Show("采血时间不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                deGetBloodDate.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(deReceiveDate.Text))
            {
                MessageBox.Show("标本收到时间不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                deReceiveDate.Focus();
                return false;
            }
            return true;
        }


         /// <summary>
        /// 检测是否存在该卡号的疾病筛查卡
        /// </summary>
        /// <param name="cardNo">卡号</param>
        /// <returns></returns>
        private bool cardNoexists(string cardNo)
        {
            if (string.IsNullOrEmpty(cardNo))
            {
                return false;
            }
            //string sql = string.Format("select * from NB_DISEASE_SCREENING_CARD where card_no ={0}", cardNo);
            object[] param = { cardNo };
            DataTable dt = _sqlhelp.Query("", Sql.cardNoExists, param);
            if (dt.Rows.Count >= 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        private void txtHealthNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbOrganization.Focus();
            }
        }

        private void txtGestationalWeeks_KeyPress(object sender, KeyPressEventArgs e)
        {
            DA.DataAccess.checkNumber(this.txtGestationalWeeks.Text.Trim(), e, "");
        }

        private void txtGestationalDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            DA.DataAccess.checkNumber(this.txtGestationalDays.Text.Trim(), e, "");
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            DA.DataAccess.checkNumber(this.txtWeight.Text.Trim(), e);
        }








    }
}
