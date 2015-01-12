using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newborn_Disease_Screening_System.DA;
using Newborn_Disease_Screening_System.Entity;

namespace Newborn_Disease_Screening_System.UC
{
    public partial class UCAddOrUpdateFirstResult : UserControl
    {
        #region 初始化
        FBSqlHelper _sqlhelp = new FBSqlHelper();
        TabControl _tc = new TabControl();
        string _flag;
        string _cardNo;

        DataTable dtStandard = new DataTable();
        NbStandardValues standardTSH = new NbStandardValues();
        NbStandardValues standardPHE = new NbStandardValues();
        NbStandardValues standardG6PD = new NbStandardValues();
        public UCAddOrUpdateFirstResult(TabControl tc, string flag, string cardNo)
        {
            InitializeComponent();
            _tc = tc;
            _flag = flag;
            _cardNo = cardNo;
        }


        private void UCAddOrUpdateFirstResult_Load(object sender, EventArgs e)
        {
            dtStandard = _sqlhelp.Query("", Sql.getStandardValues, new object[] { "TSH" });
            if(dtStandard.Rows.Count<=0)
            {
                return;
            }
            standardTSH.Standard_Values_Id = long.Parse(dtStandard.Rows[0]["STANDARD_VALUES_ID"].ToString());
            standardTSH.Item_Name = dtStandard.Rows[0]["ITEM_NAME"].ToString();
            standardTSH.Disease_Name = dtStandard.Rows[0]["DISEASE_NAME"].ToString();
            standardTSH.Normal_Low_Value = double.Parse(dtStandard.Rows[0]["NORMAL_LOW_VALUE"].ToString());
            standardTSH.Normal_High_Value = double.Parse(dtStandard.Rows[0]["NORMAL_HIGH_VALUE"].ToString());
            standardTSH.Weak_Positive_Low_Value = double.Parse(dtStandard.Rows[0]["WEAK_POSITIVE_LOW_VALUE"].ToString());
            standardTSH.Weak_Positive_High_Value = double.Parse(dtStandard.Rows[0]["WEAK_POSITIVE_HIGH_VALUE"].ToString());
            standardTSH.Positive_Low_Value = double.Parse(dtStandard.Rows[0]["POSITIVE_LOW_VALUE"].ToString());
            standardTSH.Positive_High_Value = double.Parse(dtStandard.Rows[0]["POSITIVE_HIGH_VALUE"].ToString());
            standardTSH.Units = dtStandard.Rows[0]["UNITS"].ToString();

            dtStandard = _sqlhelp.Query("", Sql.getStandardValues, new object[] { "PHE" });
            if (dtStandard.Rows.Count <= 0)
            {
                return;
            }
            standardPHE.Standard_Values_Id = long.Parse(dtStandard.Rows[0]["Standard_Values_Id"].ToString());
            standardPHE.Item_Name = dtStandard.Rows[0]["ITEM_NAME"].ToString();
            standardPHE.Disease_Name = dtStandard.Rows[0]["DISEASE_NAME"].ToString();
            standardPHE.Normal_Low_Value = double.Parse(dtStandard.Rows[0]["NORMAL_LOW_VALUE"].ToString());
            standardPHE.Normal_High_Value = double.Parse(dtStandard.Rows[0]["NORMAL_HIGH_VALUE"].ToString());
            standardPHE.Weak_Positive_Low_Value = double.Parse(dtStandard.Rows[0]["WEAK_POSITIVE_LOW_VALUE"].ToString());
            standardPHE.Weak_Positive_High_Value = double.Parse(dtStandard.Rows[0]["WEAK_POSITIVE_HIGH_VALUE"].ToString());
            standardPHE.Positive_Low_Value = double.Parse(dtStandard.Rows[0]["POSITIVE_LOW_VALUE"].ToString());
            standardPHE.Positive_High_Value = double.Parse(dtStandard.Rows[0]["POSITIVE_HIGH_VALUE"].ToString());
            standardPHE.Units = dtStandard.Rows[0]["UNITS"].ToString();

            dtStandard = _sqlhelp.Query("", Sql.getStandardValues, new object[] { "G6PD" });
            if (dtStandard.Rows.Count <= 0)
            {
                return;
            }
            standardG6PD.Standard_Values_Id = long.Parse(dtStandard.Rows[0]["Standard_Values_Id"].ToString());
            standardG6PD.Item_Name = dtStandard.Rows[0]["ITEM_NAME"].ToString();
            standardG6PD.Disease_Name = dtStandard.Rows[0]["DISEASE_NAME"].ToString();
            standardG6PD.Normal_Low_Value = double.Parse(dtStandard.Rows[0]["NORMAL_LOW_VALUE"].ToString());
            standardG6PD.Normal_High_Value = double.Parse(dtStandard.Rows[0]["NORMAL_HIGH_VALUE"].ToString());
            standardG6PD.Weak_Positive_Low_Value = double.Parse(dtStandard.Rows[0]["WEAK_POSITIVE_LOW_VALUE"].ToString());
            standardG6PD.Weak_Positive_High_Value = double.Parse(dtStandard.Rows[0]["WEAK_POSITIVE_HIGH_VALUE"].ToString());
            standardG6PD.Positive_Low_Value = double.Parse(dtStandard.Rows[0]["POSITIVE_LOW_VALUE"].ToString());
            standardG6PD.Positive_High_Value = double.Parse(dtStandard.Rows[0]["POSITIVE_HIGH_VALUE"].ToString());
            standardG6PD.Units = dtStandard.Rows[0]["UNITS"].ToString();

            if (_flag == "insert")
            {
                TSH1.PageVisible = TSH2.PageVisible = PHE1.PageVisible = PHE2.PageVisible = G6PD1.PageVisible = G6PD2.PageVisible = true;
                seCardNoTSH1.Enabled = seCardNoTSH2.Enabled = seCardNoPHE1.Enabled = seCardNoPHE2.Enabled = seCardNoG6PD1.Enabled = seCardNoG6PD2.Enabled = true;
                lbflag.Text = "新增记录";
            }
            if (_flag == "update")
            {
                lbflag.Text = "修改记录";
                TSH1.PageVisible = TSH2.PageVisible = PHE1.PageVisible = PHE2.PageVisible = G6PD1.PageVisible = G6PD2.PageVisible = false;
                seCardNoTSH1.Enabled = seCardNoTSH2.Enabled = seCardNoPHE1.Enabled = seCardNoPHE2.Enabled = seCardNoG6PD1.Enabled = seCardNoG6PD2.Enabled = false;
                string sql = @"SELECT * FROM NB_FIRST_SCREENING nsg
                                        where nsg.CARD_NO=?";
                object[] param = { _cardNo };
                DataTable t = _sqlhelp.Query("", sql, param);
                for (int i = 0; i < t.Rows.Count; i++)
                {
                    if (t.Rows[i]["ITEM_NAME"].ToString() == "TSH1")
                    {
                        TSH1.PageVisible = true;
                        seCardNoTSH1.Focus();
                        seCardNoTSH1.Text = _cardNo;
                        txtFirstSenderTSH1.Focus();
                        txtFirstSenderTSH1.Text = t.Rows[i]["first_checker"].ToString();
                        txtSecondSenderTSH1.Text = t.Rows[i]["second_checker"].ToString();
                        txtTSH1.Text = t.Rows[i]["values1"].ToString();
                        cbWashTSH1.Text = t.Rows[i]["wash"].ToString();
                        deCheckDateTSH1.Text = t.Rows[i]["check_time"].ToString();
                        txtResultTSH1.Text=t.Rows[i]["RESULT"].ToString();
                    }
                    if (t.Rows[i]["ITEM_NAME"].ToString() == "TSH2")
                    {
                        TSH2.PageVisible = true;
                        seCardNoTSH2.Focus();
                        seCardNoTSH2.Text = _cardNo;
                        txtFirstSenderTSH2.Focus();
                        txtFirstSenderTSH2.Text = t.Rows[i]["first_checker"].ToString();
                        txtSecondSenderTSH2.Text = t.Rows[i]["second_checker"].ToString();
                        txtTSH2_1.Text = t.Rows[i]["values1"].ToString();
                        txtTSH2_2.Text = t.Rows[i]["values2"].ToString();
                        this.lblAVGTSH2.Text = t.Rows[i]["wash"].ToString();
                        deCheckDateTSH2.Text = t.Rows[i]["check_time"].ToString();
                        txtResultTSH2.Text = t.Rows[i]["RESULT"].ToString();
                    }
                    if (t.Rows[i]["ITEM_NAME"].ToString() == "PHE1")
                    {
                        PHE1.PageVisible = true;
                        seCardNoPHE1.Focus();
                        seCardNoPHE1.Text = _cardNo;
                        txtFirstSenderPHE1.Focus();
                        txtFirstSenderPHE1.Text = t.Rows[i]["first_checker"].ToString();
                        txtSecondSenderPHE1.Text = t.Rows[i]["second_checker"].ToString();
                        txtPHE1.Text = t.Rows[i]["values1"].ToString();
                        //cbWashPHE1.Text = t.Rows[i]["wash_avg"].ToString();
                        deCheckDatePHE1.Text = t.Rows[i]["check_time"].ToString();
                        txtResultPHE1.Text = t.Rows[i]["RESULT"].ToString();
                    }
                    if (t.Rows[i]["ITEM_NAME"].ToString() == "PHE2")
                    {
                        PHE2.PageVisible = true;
                        seCardNoPHE2.Focus();
                        seCardNoPHE2.Text = _cardNo;
                        txtFirstSenderPHE2.Focus();
                        txtFirstSenderPHE2.Text = t.Rows[i]["first_checker"].ToString();
                        txtSecondSenderPHE2.Text = t.Rows[i]["second_checker"].ToString();
                        txtPHE2_1.Text = t.Rows[i]["values1"].ToString();
                        txtPHE2_2.Text = t.Rows[i]["values2"].ToString();
                        this.lblAVGPHE2.Text = t.Rows[i]["wash"].ToString();
                        deCheckDatePHE2.Text = t.Rows[i]["check_time"].ToString();
                        txtResultPHE2.Text = t.Rows[i]["RESULT"].ToString();
                    }
                    if (t.Rows[i]["ITEM_NAME"].ToString() == "G6PD1")
                    {
                        G6PD1.PageVisible = true;
                        seCardNoG6PD1.Focus();
                        seCardNoG6PD1.Text = _cardNo;
                        txtFirstSenderG6PD1.Focus();
                        txtFirstSenderG6PD1.Text = t.Rows[i]["first_checker"].ToString();
                        txtSecondSenderG6PD1.Text = t.Rows[i]["second_checker"].ToString();
                        txtG6PD1.Text = t.Rows[i]["values1"].ToString();
                        //cbWashG6PD1.Text = t.Rows[i]["wash_avg"].ToString();
                        deCheckDateG6PD1.Text = t.Rows[i]["check_time"].ToString();
                        txtResultG6PD1.Text = t.Rows[i]["RESULT"].ToString();
                    }
                    if (t.Rows[i]["ITEM_NAME"].ToString() == "G6PD2")
                    {
                        G6PD2.PageVisible = true;
                        seCardNoG6PD2.Focus();
                        seCardNoG6PD2.Text = _cardNo;
                        txtFirstSenderG6PD2.Focus();
                        txtFirstSenderG6PD2.Text = t.Rows[i]["first_checker"].ToString();
                        txtSecondSenderG6PD2.Text = t.Rows[i]["second_checker"].ToString();
                        txtG6PD2_1.Text = t.Rows[i]["values1"].ToString();
                        txtG6PD2_2.Text = t.Rows[i]["values2"].ToString();
                        this.lblAVGG6PD2.Text = t.Rows[i]["wash"].ToString();
                        deCheckDateG6PD2.Text = t.Rows[i]["check_time"].ToString();
                        txtResultG6PD2.Text = t.Rows[i]["RESULT"].ToString(); ;
                    }
                }
            }
        }
        
        #endregion

        #region 公用方法

        private bool checkNull(string type)
        {
            switch (type)
            {
                case "THS1":
                    if(string.IsNullOrEmpty(txtFirstSenderTSH1.Text))
                    {
                        txtFirstSenderTSH1.Focus();
                        MessageBox.Show("第一送检人不能为空!");
                        return false;
                    }
                    if (string.IsNullOrEmpty(this.deCheckDateTSH1.Text))
                    {
                        deCheckDateTSH1.Focus();
                        MessageBox.Show("送检时间能为空!");
                        return false;
                    }
                    if (string.IsNullOrEmpty(this.txtTSH1.Text))
                    {
                        txtTSH1.Focus();
                        MessageBox.Show("TSH1值能为空!");
                        return false;
                    }
                    break;
                case "PHE1":
                    if (string.IsNullOrEmpty(txtFirstSenderPHE1.Text))
                    {
                        txtFirstSenderPHE1.Focus();
                        MessageBox.Show("第一送检人不能为空!");
                        return false;
                    }
                    if (string.IsNullOrEmpty(this.deCheckDatePHE1.Text))
                    {
                        deCheckDatePHE1.Focus();
                        MessageBox.Show("送检时间能为空!");
                        return false;
                    }
                    if (string.IsNullOrEmpty(this.txtPHE1.Text))
                    {
                        txtPHE1.Focus();
                        MessageBox.Show("PHE1值能为空!");
                        return false;
                    }
                    break;
                case "G6PD1":
                    if (string.IsNullOrEmpty(txtFirstSenderG6PD1.Text))
                    {
                        txtFirstSenderG6PD1.Focus();
                        MessageBox.Show("第一送检人不能为空!");
                        return false;
                    }
                    if (string.IsNullOrEmpty(this.deCheckDateG6PD1.Text))
                    {
                        deCheckDateG6PD1.Focus();
                        MessageBox.Show("送检时间能为空!");
                        return false;
                    }
                    if (string.IsNullOrEmpty(this.txtG6PD1.Text))
                    {
                        txtG6PD1.Focus();
                        MessageBox.Show("G6PD1值能为空!");
                        return false;
                    }
                    break;
                case "THS2":
                    if (string.IsNullOrEmpty(txtFirstSenderTSH2.Text))
                    {
                        txtFirstSenderTSH2.Focus();
                        MessageBox.Show("第一送检人不能为空!");
                        return false;
                    }
                    if (string.IsNullOrEmpty(this.deCheckDateTSH2.Text))
                    {
                        deCheckDateTSH2.Focus();
                        MessageBox.Show("送检时间能为空!");
                        return false;
                    }
                    if (string.IsNullOrEmpty(this.txtTSH2_1.Text))
                    {
                        txtTSH2_1.Focus();
                        MessageBox.Show("TSH2_1值能为空!");
                        return false;
                    }
                    if (string.IsNullOrEmpty(this.txtTSH2_2.Text))
                    {
                        txtTSH2_2.Focus();
                        MessageBox.Show("TSH2_2值能为空!");
                        return false;
                    }
                    break;
                case "PHE2":
                    if (string.IsNullOrEmpty(txtFirstSenderPHE2.Text))
                    {
                        txtFirstSenderPHE2.Focus();
                        MessageBox.Show("第一送检人不能为空!");
                        return false;
                    }
                    if (string.IsNullOrEmpty(this.deCheckDatePHE2.Text))
                    {
                        deCheckDatePHE2.Focus();
                        MessageBox.Show("送检时间能为空!");
                        return false;
                    }
                    if (string.IsNullOrEmpty(this.txtPHE2_1.Text))
                    {
                        txtPHE2_1.Focus();
                        MessageBox.Show("PHE2_1值能为空!");
                        return false;
                    }
                    if (string.IsNullOrEmpty(this.txtPHE2_2.Text))
                    {
                        txtPHE2_2.Focus();
                        MessageBox.Show("PHE2_2值能为空!");
                        return false;
                    }
                    break;
                case "G6PD2":
                    if (string.IsNullOrEmpty(txtFirstSenderG6PD2.Text))
                    {
                        txtFirstSenderG6PD2.Focus();
                        MessageBox.Show("第一送检人不能为空!");
                        return false;
                    }
                    if (string.IsNullOrEmpty(this.deCheckDateG6PD2.Text))
                    {
                        deCheckDateG6PD2.Focus();
                        MessageBox.Show("送检时间能为空!");
                        return false;
                    }
                    if (string.IsNullOrEmpty(this.txtG6PD2_1.Text))
                    {
                        txtG6PD2_1.Focus();
                        MessageBox.Show("G6PD2_1值能为空!");
                        return false;
                    }
                    if (string.IsNullOrEmpty(this.txtG6PD2_2.Text))
                    {
                        txtG6PD2_2.Focus();
                        MessageBox.Show("G6PD2_2值能为空!");
                        return false;
                    }
                    break;
            }
            return true;
        }
       
        /// <summary>
        /// 显示有关卡号的信息
        /// </summary>
        /// <param name="cardNo">卡号</param>
        /// <param name="type">值类型</param>
        private void showCardInfo(string cardNo, string type)
        {
            string sql = @"select * from  VW_NB_DISEASE_CARD vcd
                                    where vcd.CARD_NO = ? ";
            DataTable dt = new DataTable();
            dt = _sqlhelp.Query("", sql, new[] { cardNo });
            if (dt.Rows.Count > 0)
            {
                switch (type)
                {
                    case "TSH1":
                        lblMotherNameTSH1.Text = dt.Rows[0]["MOTHER_NAME"].ToString();
                        lblGenderTSH1.Text = dt.Rows[0]["GENDER_INFO"].ToString();
                        lblCardCodeTSH1.Text = dt.Rows[0]["CARD_CODE"].ToString();
                        lblOrganizationTSH1.Text = dt.Rows[0]["ORGANIZATION_NAME"].ToString();
                        lblIllCaseNoTSH1.Text = dt.Rows[0]["ILLCASE_NO"].ToString();
                        btnSaveTSH1.Enabled = true;
                        break;
                    case "TSH2":
                        lblMotherNameTSH2.Text = dt.Rows[0]["MOTHER_NAME"].ToString();
                        lblGenderTSH2.Text = dt.Rows[0]["GENDER_INFO"].ToString();
                        lblCardCodeTSH2.Text = dt.Rows[0]["CARD_CODE"].ToString();
                        lblOrganizationTSH2.Text = dt.Rows[0]["ORGANIZATION_NAME"].ToString();
                        lblIllCaseNoTSH2.Text = dt.Rows[0]["ILLCASE_NO"].ToString();
                        btnSaveTSH2.Enabled = true;
                        break;
                    case "PHE1":
                        lblMotherNamePHE1.Text = dt.Rows[0]["MOTHER_NAME"].ToString();
                        lblGenderPHE1.Text = dt.Rows[0]["GENDER_INFO"].ToString();
                        lblCardCodePHE1.Text = dt.Rows[0]["CARD_CODE"].ToString();
                        lblOrganizationPHE1.Text = dt.Rows[0]["ORGANIZATION_NAME"].ToString();
                        lblIllCaseNoPHE1.Text = dt.Rows[0]["ILLCASE_NO"].ToString();
                        btnSavePHE1.Enabled = true;
                        break;
                    case "PHE2":
                        lblMotherNamePHE2.Text = dt.Rows[0]["MOTHER_NAME"].ToString();
                        lblGenderPHE2.Text = dt.Rows[0]["GENDER_INFO"].ToString();
                        lblCardCodePHE2.Text = dt.Rows[0]["CARD_CODE"].ToString();
                        lblOrganizationPHE2.Text = dt.Rows[0]["ORGANIZATION_NAME"].ToString();
                        lblIllCaseNoPHE2.Text = dt.Rows[0]["ILLCASE_NO"].ToString();
                        btnSavePHE2.Enabled = true;
                        break;
                    case "G6PD1":
                        lblMotherNameG6PD1.Text = dt.Rows[0]["MOTHER_NAME"].ToString();
                        lblGenderG6PD1.Text = dt.Rows[0]["GENDER_INFO"].ToString();
                        lblCardCodeG6PD1.Text = dt.Rows[0]["CARD_CODE"].ToString();
                        lblOrganizationG6PD1.Text = dt.Rows[0]["ORGANIZATION_NAME"].ToString();
                        lblIllCaseNoG6PD1.Text = dt.Rows[0]["ILLCASE_NO"].ToString();
                        btnSaveG6PD1.Enabled = true;
                        break;
                    case "G6PD2":
                        lblMotherNameG6PD2.Text = dt.Rows[0]["MOTHER_NAME"].ToString();
                        lblGenderG6PD2.Text = dt.Rows[0]["GENDER_INFO"].ToString();
                        lblCardCodeG6PD2.Text = dt.Rows[0]["CARD_CODE"].ToString();
                        lblOrganizationG6PD2.Text = dt.Rows[0]["ORGANIZATION_NAME"].ToString();
                        lblIllCaseNoG6PD2.Text = dt.Rows[0]["ILLCASE_NO"].ToString();
                        btnSaveG6PD2.Enabled = true;
                        break;

                }
                #region RegionName
                //lblMotherNameTSH1.Text = lblMotherNameTSH2.Text =
                //lblMotherNamePHE1.Text = lblMotherNamePHE2.Text =
                //lblMotherNameG6PD1.Text = lblMotherNameG6PD2.Text
                //= dt.Rows[0]["MOTHER_NAME"].ToString();

                //lblGenderTSH1.Text = lblGenderTSH2.Text =
                //lblGenderPHE1.Text = lblGenderPHE2.Text =
                //lblGenderG6PD1.Text = lblGenderG6PD2.Text
                //= dt.Rows[0]["GENDER_INFO"].ToString();

                //lblCardCodeTSH1.Text = lblCardCodeTSH2.Text =
                //lblCardCodePHE1.Text = lblCardCodePHE2.Text =
                //lblCardCodeG6PD1.Text = lblCardCodeG6PD2.Text
                //= dt.Rows[0]["CARD_CODE"].ToString();

                //lblOrganizationTSH1.Text = lblOrganizationTSH2.Text =
                //lblOrganizationPHE1.Text = lblOrganizationPHE2.Text =
                //lblOrganizationG6PD1.Text = lblOrganizationG6PD2.Text =
                //dt.Rows[0]["ORGANIZATION_NAME"].ToString();

                //lblIllCaseNoTSH1.Text = lblIllCaseNoTSH2.Text =
                //lblIllCaseNoPHE1.Text = lblIllCaseNoPHE2.Text =
                //lblIllCaseNoG6PD1.Text = lblIllCaseNoG6PD2.Text =
                //dt.Rows[0]["ILLCASE_NO"].ToString();
                #endregion
            }
        }


        /// <summary>
        /// 检测是否存在该值类型的第一次筛查结果
        /// </summary>
        /// <param name="cardNo">卡号</param>
        /// <param name="type">值类型</param>
        /// <returns></returns>
        private bool firstResultexists(string cardNo, string type)
        {
            object[] param = { cardNo, type };
            DataTable dt = _sqlhelp.Query("", Sql.firstResultExists, param);
            bool exists = false;
            if (dt.Rows.Count == 0)
            {
                if (_flag == "insert")
                {
                    return true;
                }
                else if (_flag == "update")
                {
                    MessageBox.Show("不存在卡号为 " + cardNo + " 的初检" + type + "结果,无法修改!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    switch (type)
                    {
                        case "TSH1":
                            seCardNoTSH1.Focus();
                            break;
                        case "TSH2":
                            seCardNoTSH2.Focus();
                            break;
                        case "PHE1":
                            seCardNoPHE1.Focus();
                            break;
                        case "PHE2":
                            seCardNoPHE2.Focus();
                            break;
                        case "G6PD1":
                            seCardNoG6PD1.Focus();
                            break;
                        case "G6PD2":
                            seCardNoG6PD2.Focus();
                            break;

                    }
                    return false;
                }
            }
            else
            {
                if (_flag == "insert")
                {
                    MessageBox.Show("卡号为 " + cardNo + " 的初检" + type + "结果已存在!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    switch (type)
                    {
                        case "TSH1":
                            seCardNoTSH1.Focus();
                            break;
                        case "TSH2":
                            seCardNoTSH2.Focus();
                            break;
                        case "PHE1":
                            seCardNoPHE1.Focus();
                            break;
                        case "PHE2":
                            seCardNoPHE2.Focus();
                            break;
                        case "G6PD1":
                            seCardNoG6PD1.Focus();
                            break;
                        case "G6PD2":
                            seCardNoG6PD2.Focus();
                            break;
                    }
                    return false;
                }
                else if (_flag == "update")
                {
                    return true;
                }
            }
            return exists;
        }


        /// <summary>
        /// 检测是否存在该卡号的疾病筛查卡
        /// </summary>
        /// <param name="cardNo">卡号</param>
        /// <returns></returns>
        private bool cardNoexists(string cardNo, string type)
        {
            if (string.IsNullOrEmpty(cardNo))
            {
                //seCardNoTSH1.Focus();
                //tc.Focus();
                return false;
            }
            //string sql = string.Format("select * from NB_DISEASE_SCREENING_CARD where card_no ={0}", cardNo);
            object[] param = { cardNo };
            DataTable dt = _sqlhelp.Query("", Sql.cardNoExists, param);
            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
               
                switch (type)
                {
                    case "TSH1":
                        //TSH1.Focus();
                        seCardNoTSH1.Text = null;
                        break;
                    case "TSH2":
                        //seCardNoTSH2.Focus();
                        seCardNoTSH2.Text = null;
                        break;
                    case "PHE1":
                        //seCardNoPHE1.Focus();
                        seCardNoPHE1.Text = null;
                        break;
                    case "PHE2":
                        //seCardNoPHE2.Focus();
                        seCardNoPHE2.Text = null;
                        break;
                    case "G6PD1":
                        //seCardNoG6PD1.Focus();
                        seCardNoG6PD1.Text = null;
                        break;
                    case "G6PD2":
                        //seCardNoG6PD2.Focus();
                        seCardNoG6PD2.Text = null;
                        break;
                } 
                MessageBox.Show("不存在卡号为 " + cardNo + " 的疾病卡!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private int saveValue(string cardNo, string type)
        {
            object[] param;
            int count = 0;
            #region insert
            //if (_flag == "insert")
            //{
            if (!cardNoexists(cardNo, type))
            {
                return 0;
            }
            switch (type)
            {
                case "TSH1":
                    seCardNoTSH1.Focus();
                    cardNo = seCardNoTSH1.Text;
                    if (!firstResultexists(cardNo, type))
                    {
                        return 0;
                    }
                    if (string.IsNullOrEmpty(seCardNoTSH1.Text))
                    {
                        MessageBox.Show("卡号不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        seCardNoTSH1.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(txtFirstSenderTSH1.Text))
                    {
                        MessageBox.Show("第一送检人不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtFirstSenderTSH1.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(deCheckDateTSH1.Text))
                    {
                        MessageBox.Show("送检时间不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        deCheckDateTSH1.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(txtTSH1.Text))
                    {
                        MessageBox.Show("TSH1值不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTSH1.Focus();
                        return 0;
                    }
                    if (_flag == "insert")
                    {
                        param = new object[] {seCardNoTSH1.Text.Trim(),
                                            type,txtTSH1.Text.Trim(),
                                            txtFirstSenderTSH1.Text.Trim(),
                                            string.IsNullOrEmpty(txtSecondSenderTSH1.Text.Trim())?null:txtSecondSenderTSH1.Text.Trim(),
                                            deCheckDateTSH1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                            cbWashTSH1.Text,
                                            txtResultTSH1.Text.Trim(),
                                            null,
                                            GmUser.User_id,
                                            GmUser.User_id,
                                            "TSH",
                                            txtTSH1.Text.Trim()
                                            };
                        count = _sqlhelp.ExecuteNonQuery(Sql.addFirstResult, param);
                    }
                    else if (_flag == "update")
                    {
                        param = new object[] {  
                                            txtFirstSenderTSH1.Text.Trim(),
                                            string.IsNullOrEmpty(txtSecondSenderTSH1.Text.Trim())?null:txtSecondSenderTSH1.Text.Trim(),
                                            deCheckDateTSH1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                            cbWashTSH1.Text,
                                            txtResultTSH1.Text.Trim(),
                                            GmUser.User_id,
                                            txtTSH1.Text.Trim(),
                                            null,
                                            txtTSH1.Text.Trim(),
                                            seCardNoTSH1.Text.Trim(),
                                            type
                                            };
                        //string tsh1 = string.Format(Sql.UpdateFirstResult, param);
                        count = _sqlhelp.ExecuteNonQuery(Sql.UpdateFirstResult, param);
                    }
                    break;
                case "TSH2":
                    seCardNoTSH2.Focus();
                    cardNo = seCardNoTSH2.Text;
                    if (!firstResultexists(cardNo, type))
                    {
                        return 0;
                    }
                    if (string.IsNullOrEmpty(seCardNoTSH2.Text))
                    {
                        MessageBox.Show("卡号不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        seCardNoTSH2.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(txtFirstSenderTSH2.Text))
                    {
                        MessageBox.Show("第一送检人不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtFirstSenderTSH2.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(deCheckDateTSH2.Text))
                    {
                        MessageBox.Show("送检时间不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        deCheckDateTSH2.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(txtTSH2_1.Text))
                    {
                        MessageBox.Show("TSH2_1值不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTSH2_1.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(txtTSH2_2.Text))
                    {
                        MessageBox.Show("TSH2_2值不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTSH2_2.Focus();
                        return 0;
                    }
                    if (_flag == "insert")
                    {
                        param = new object[] {seCardNoTSH2.Text.Trim(),
                                            type,txtTSH2_1.Text.Trim(),
                                            txtFirstSenderTSH2.Text.Trim(),
                                            string.IsNullOrEmpty(txtSecondSenderTSH2.Text.Trim())?null:txtSecondSenderTSH2.Text.Trim(),
                                            deCheckDateTSH2.DateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                            lblAVGTSH2.Text,
                                            txtResultTSH2.Text.Trim(),
                                            txtTSH2_2.Text.Trim(),
                                            GmUser.User_id,
                                            GmUser.User_id,
                                            "TSH",
                                            lblAVGTSH2.Text.Trim()
                                            };
                        count = _sqlhelp.ExecuteNonQuery(Sql.addFirstResult, param);
                    }
                    else if (_flag == "update")
                    {
                        param = new object[] { 
                                            txtFirstSenderTSH2.Text.Trim(),
                                            string.IsNullOrEmpty(txtSecondSenderTSH2.Text.Trim())?null:txtSecondSenderTSH2.Text.Trim(),
                                            deCheckDateTSH2.DateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                            "",
                                            txtResultTSH2.Text.Trim(),
                                            GmUser.User_id,
                                            txtTSH2_1.Text.Trim(),
                                            txtTSH2_2.Text.Trim(), 
                                            lblAVGTSH2.Text.Trim(),
                                            seCardNoTSH2.Text.Trim(),
                                            type
                                            };
                        count = _sqlhelp.ExecuteNonQuery(Sql.UpdateFirstResult, param);
                    }
                    break;
                case "PHE1":
                    seCardNoPHE1.Focus();
                    cardNo = seCardNoPHE1.Text;
                    if (!firstResultexists(cardNo, type))
                    {
                        return 0;
                    }
                    if (string.IsNullOrEmpty(seCardNoPHE1.Text))
                    {
                        MessageBox.Show("卡号不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        seCardNoPHE1.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(txtFirstSenderPHE1.Text))
                    {
                        MessageBox.Show("第一送检人不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtFirstSenderPHE1.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(deCheckDatePHE1.Text))
                    {
                        MessageBox.Show("送检时间不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        deCheckDatePHE1.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(txtPHE1.Text))
                    {
                        MessageBox.Show("PHE1值不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPHE1.Focus();
                        return 0;
                    }
                    if (_flag == "insert")
                    {
                        param = new object[] {seCardNoPHE1.Text.Trim(),
                                            type,txtPHE1.Text.Trim(),
                                            txtFirstSenderPHE1.Text.Trim(),
                                            string.IsNullOrEmpty(txtSecondSenderPHE1.Text.Trim())?null:txtSecondSenderPHE1.Text.Trim(),
                                            deCheckDatePHE1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                            null,
                                            txtResultPHE1.Text.Trim(),
                                            null,
                                            GmUser.User_id,
                                            GmUser.User_id,
                                            "PHE",
                                            txtPHE1.Text.Trim()
                                            };
                        count = _sqlhelp.ExecuteNonQuery(Sql.addFirstResult, param);
                    }
                    else if (_flag == "update")
                    {
                        param = new object[] { 
                                            txtFirstSenderPHE1.Text.Trim(),
                                            string.IsNullOrEmpty(txtSecondSenderPHE1.Text.Trim())?null:txtSecondSenderPHE1.Text.Trim(),
                                            deCheckDatePHE1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                            null,
                                            txtResultPHE1.Text.Trim(),
                                            GmUser.User_id,
                                            txtPHE1.Text.Trim(),
                                            null,
                                            txtPHE1.Text.Trim(),
                                            seCardNoPHE1.Text.Trim(),
                                            type
                                            };
                        count = _sqlhelp.ExecuteNonQuery(Sql.UpdateFirstResult, param);
                    }

                    break;
                case "PHE2":
                    seCardNoPHE2.Focus();
                    cardNo = seCardNoPHE2.Text;
                    if (!firstResultexists(cardNo, type))
                    {
                        return 0;
                    }
                    if (string.IsNullOrEmpty(seCardNoPHE2.Text))
                    {
                        MessageBox.Show("卡号不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        seCardNoPHE2.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(txtFirstSenderPHE2.Text))
                    {
                        MessageBox.Show("第一送检人不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtFirstSenderPHE2.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(deCheckDatePHE2.Text))
                    {
                        MessageBox.Show("送检时间不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        deCheckDatePHE2.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(txtPHE2_1.Text))
                    {
                        MessageBox.Show("PHE2_1值不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPHE2_1.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(txtPHE2_2.Text))
                    {
                        MessageBox.Show("PHE2_2值不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPHE2_2.Focus();
                        return 0;
                    }
                    if (_flag == "insert")
                    {
                        param = new object[] {seCardNoPHE2.Text.Trim(),
                                            type,txtPHE2_1.Text.Trim(),
                                            txtFirstSenderPHE2.Text.Trim(),
                                            string.IsNullOrEmpty(txtSecondSenderPHE2.Text.Trim())?null:txtSecondSenderPHE2.Text.Trim(),
                                            deCheckDatePHE2.DateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                            lblAVGPHE2.Text,
                                            txtResultPHE2.Text.Trim(),
                                            txtPHE2_2.Text.Trim(),
                                            GmUser.User_id,
                                            GmUser.User_id,
                                            "PHE",
                                            lblAVGPHE2.Text.Trim()
                                            };
                        count = _sqlhelp.ExecuteNonQuery(Sql.addFirstResult, param);
                    }
                    else if (_flag == "update")
                    {
                        param = new object[] { 
                                            txtFirstSenderPHE2.Text.Trim(),
                                            string.IsNullOrEmpty(txtSecondSenderPHE2.Text.Trim())?null:txtSecondSenderPHE2.Text.Trim(),
                                            deCheckDatePHE2.DateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                            "",
                                            txtResultPHE2.Text.Trim(),
                                            GmUser.User_id,
                                            txtPHE2_1.Text.Trim(),
                                            txtPHE2_2.Text.Trim(), 
                                            lblAVGPHE2.Text.Trim(),
                                            seCardNoPHE2.Text.Trim(),
                                            type
                                            };
                        count = _sqlhelp.ExecuteNonQuery(Sql.UpdateFirstResult, param);
                    }
                    break;
                case "G6PD1":
                    seCardNoG6PD1.Focus();
                    cardNo = seCardNoG6PD1.Text;
                    if (!firstResultexists(cardNo, type))
                    {
                        return 0;
                    }
                    if (string.IsNullOrEmpty(seCardNoG6PD1.Text))
                    {
                        MessageBox.Show("卡号不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        seCardNoG6PD1.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(txtFirstSenderG6PD1.Text))
                    {
                        MessageBox.Show("第一送检人不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtFirstSenderG6PD1.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(deCheckDateG6PD1.Text))
                    {
                        MessageBox.Show("送检时间不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        deCheckDateG6PD1.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(txtG6PD1.Text))
                    {
                        MessageBox.Show("G6PD1值不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtG6PD1.Focus();
                        return 0;
                    }
                    if (_flag == "insert")
                    {
                        param = new object[] {seCardNoG6PD1.Text.Trim(),
                                            type,txtG6PD1.Text.Trim(),
                                            txtFirstSenderG6PD1.Text.Trim(),
                                            string.IsNullOrEmpty(txtSecondSenderG6PD1.Text.Trim())?null:txtSecondSenderG6PD1.Text.Trim(),
                                            deCheckDateG6PD1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                            null,
                                            txtResultG6PD1.Text.Trim(),
                                            null,
                                            GmUser.User_id,
                                            GmUser.User_id,
                                            "G6PD",
                                            txtG6PD1.Text.Trim()
                                            };
                        count = _sqlhelp.ExecuteNonQuery(Sql.addFirstResult, param);
                    }
                    else if (_flag == "update")
                    {
                        param = new object[] {
                                            txtFirstSenderG6PD1.Text.Trim(),
                                            string.IsNullOrEmpty(txtSecondSenderG6PD1.Text.Trim())?null:txtSecondSenderG6PD1.Text.Trim(),
                                            deCheckDateG6PD1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                            null,
                                            txtResultG6PD1.Text.Trim(),
                                            GmUser.User_id,
                                            txtG6PD1.Text.Trim(),
                                            null,
                                            txtG6PD1.Text.Trim(),
                                            seCardNoG6PD1.Text.Trim(),
                                            type
                                            };
                        count = _sqlhelp.ExecuteNonQuery(Sql.UpdateFirstResult, param);
                    }
                    break;
                case "G6PD2":
                    seCardNoG6PD2.Focus();
                    cardNo = seCardNoG6PD2.Text;
                    if (!firstResultexists(cardNo, type))
                    {
                        return 0;
                    }
                    if (string.IsNullOrEmpty(seCardNoG6PD2.Text))
                    {
                        MessageBox.Show("卡号不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        seCardNoG6PD2.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(txtFirstSenderG6PD2.Text))
                    {
                        MessageBox.Show("第一送检人不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtFirstSenderG6PD2.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(deCheckDateG6PD2.Text))
                    {
                        MessageBox.Show("送检时间不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        deCheckDateG6PD2.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(txtG6PD2_1.Text))
                    {
                        MessageBox.Show("G6PD2_1值不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtG6PD2_1.Focus();
                        return 0;
                    }
                    if (string.IsNullOrEmpty(txtG6PD2_2.Text))
                    {
                        MessageBox.Show("G6PD2_2值不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtG6PD2_2.Focus();
                        return 0;
                    }
                    if (_flag == "insert")
                    {
                        param = new object[] {seCardNoG6PD2.Text.Trim(),
                                            type,txtG6PD2_1.Text.Trim(),
                                            txtFirstSenderG6PD2.Text.Trim(),
                                            string.IsNullOrEmpty(txtSecondSenderG6PD2.Text.Trim())?null:txtSecondSenderG6PD2.Text.Trim(),
                                            deCheckDateG6PD2.DateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                            lblAVGG6PD2.Text,
                                            txtResultG6PD2.Text.Trim(),
                                            txtG6PD2_2.Text.Trim(),
                                            GmUser.User_id,
                                            GmUser.User_id,
                                            "G6PD",
                                            lblAVGG6PD2.Text.Trim()
                                            };
                        count = _sqlhelp.ExecuteNonQuery(Sql.addFirstResult, param);
                    }
                    else if (_flag == "update")
                    {
                        param = new object[] { 
                                            txtFirstSenderG6PD2.Text.Trim(),
                                            string.IsNullOrEmpty(txtSecondSenderG6PD2.Text.Trim())?null:txtSecondSenderG6PD2.Text.Trim(),
                                            deCheckDateG6PD2.DateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                            "",
                                            txtResultG6PD2.Text.Trim(),
                                            GmUser.User_id,
                                            txtG6PD2_1.Text.Trim(),
                                            txtG6PD2_2.Text.Trim(),
                                            lblAVGG6PD2.Text.Trim(),
                                            seCardNoG6PD2.Text.Trim(),
                                            type
                                            };
                        count = _sqlhelp.ExecuteNonQuery(Sql.UpdateFirstResult, param);
                    }
                    break;
            }
            if (count == 1)
            {
                if (_flag == "update")
                {
                    MessageBox.Show("更新成功!");
                }
                else
                {
                    switch (type)
                    {
                        case "TSH1":
                            cbWashTSH1.SelectedIndex = 0;
                            lblMotherNameTSH1.Text = lblGenderTSH1.Text = lblCardCodeTSH1.Text = lblOrganizationTSH1.Text = lblIllCaseNoTSH1.Text =
                            txtFirstSenderTSH1.Text = txtSecondSenderTSH1.Text =
                            deCheckDateTSH1.Text = txtTSH1.Text = txtResultTSH1.Text =
                            string.Empty;
                            //btnSaveTSH1.Enabled = false;
                            break;
                        case "TSH2":
                            lblMotherNameTSH2.Text = lblGenderTSH2.Text = lblCardCodeTSH2.Text = lblOrganizationTSH2.Text = lblIllCaseNoTSH2.Text = lblAVGTSH2.Text =
                            txtFirstSenderTSH2.Text = txtSecondSenderTSH2.Text =
                            deCheckDateTSH2.Text = txtTSH2_1.Text = txtTSH2_2.Text = txtResultTSH2.Text =
                            string.Empty;
                            //btnSaveTSH2.Enabled = false;
                            break;
                        case "PHE1":
                            lblMotherNamePHE1.Text = lblGenderPHE1.Text = lblCardCodePHE1.Text = lblOrganizationPHE1.Text = lblIllCaseNoPHE1.Text =
                            txtFirstSenderPHE1.Text = txtSecondSenderPHE1.Text =
                            deCheckDatePHE1.Text = txtPHE1.Text = txtResultPHE1.Text =
                            string.Empty;
                            //btnSavePHE1.Enabled = false;
                            break;
                        case "PHE2":
                            lblMotherNamePHE2.Text = lblGenderPHE2.Text = lblCardCodePHE2.Text = lblOrganizationPHE2.Text = lblIllCaseNoPHE2.Text = lblAVGPHE2.Text =
                            txtFirstSenderPHE2.Text = txtSecondSenderPHE2.Text =
                            deCheckDatePHE2.Text = txtPHE2_1.Text = txtPHE2_2.Text = txtResultPHE2.Text =
                            string.Empty;
                            //btnSavePHE2.Enabled = false;
                            break;
                        case "G6PD1":
                            lblMotherNameG6PD1.Text = lblGenderG6PD1.Text = lblCardCodeG6PD1.Text = lblOrganizationG6PD1.Text = lblIllCaseNoG6PD1.Text =
                            txtFirstSenderG6PD1.Text = txtSecondSenderG6PD1.Text =
                            deCheckDateG6PD1.Text = txtG6PD1.Text = txtResultG6PD1.Text =
                            string.Empty;
                            //btnSaveG6PD1.Enabled = false;
                            break;
                        case "G6PD2":
                            lblMotherNameG6PD2.Text = lblGenderG6PD2.Text = lblCardCodeG6PD2.Text = lblOrganizationG6PD2.Text = lblIllCaseNoG6PD2.Text = lblAVGG6PD2.Text =
                            txtFirstSenderG6PD2.Text = txtSecondSenderG6PD2.Text =
                            deCheckDateG6PD2.Text = txtG6PD2_1.Text = txtG6PD2_2.Text = txtResultG6PD2.Text =
                            string.Empty;
                            //btnSaveG6PD2.Enabled = false;
                            break;
                    }
                    MessageBox.Show("保存成功!");
                }
                return count;
            }
            else
            {

                if (_flag == "update")
                {
                    MessageBox.Show("更新失败!");
                }
                else
                {
                    MessageBox.Show("保存失败!");
                }
                return count;
            }
            //}
            #endregion
            #region update
            //switch (type)
            //{
            //    case "TSH1":
            //        seCardNoTSH1.Focus();
            //        cardNo = seCardNoTSH1.Text;
            //        if (!firstResultexists(cardNo, type))
            //        {
            //            return;
            //        }
            //        if (string.IsNullOrEmpty(seCardNoTSH1.Text))
            //        {
            //            MessageBox.Show("卡号不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            seCardNoTSH1.Focus();
            //            return;
            //        }
            //        if (string.IsNullOrEmpty(txtFirstSenderTSH1.Text))
            //        {
            //            MessageBox.Show("第一送检人不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            txtFirstSenderTSH1.Focus();
            //            return;
            //        }
            //        if (string.IsNullOrEmpty(deCheckDateTSH1.Text))
            //        {
            //            MessageBox.Show("送检时间不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            deCheckDateTSH1.Focus();
            //            return;
            //        }
            //        if (string.IsNullOrEmpty(txtTSH1.Text))
            //        {
            //            MessageBox.Show("TSH1值不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            txtTSH1.Focus();
            //            return;
            //        }
            //        param = new object[] {  type,
            //                                txtFirstSenderTSH1.Text.Trim(),
            //                                string.IsNullOrEmpty(txtSecondSenderTSH1.Text.Trim())?null:txtSecondSenderTSH1.Text.Trim(),
            //                                deCheckDateTSH1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"),
            //                                cbWashTSH1.Text,
            //                                txtResultTSH1.Text.Trim(),
            //                                GmUser.User_id,
            //                                txtTSH1.Text.Trim(),
            //                                null,
            //                                seCardNoTSH1.Text.Trim(),
            //                                type
            //                                };
            //        count = _sqlhelp.ExecuteNonQuery(Sql.UpdateFirstResult, param);
            //        break;
            //}
            #endregion
        }
        
        private void btnReturnTHS1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要退出吗?未保存的数据将丢失!", "警告", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                _tc.SelectedTab = _tc.TabPages["FirstResultInfo"];
                {
                    DA.DataAccess.removeTabPage("AddFirstResult", _tc);
                    DA.DataAccess.removeTabPage("UpDateFirstResult", _tc);
                }
            }
            
        }
       
        #endregion

        #region TSH1

        private void seCardNoTSH1_Leave(object sender, EventArgs e)
        {
            if (cardNoexists(seCardNoTSH1.Text.Trim(), "TSH1"))
            {
                showCardInfo(seCardNoTSH1.Text.Trim(), "TSH1");
            }
        }
       
        private void txtTSH1_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtTSH1.Text.Trim(), e);
        }
       
        private void btnSaveTSH1_Click(object sender, EventArgs e)
        {
            if(!checkNull("TSH1"))
            {
                return;
            }
            int count = saveValue(seCardNoTSH1.Text.Trim(), "TSH1");
            if (count < 1)
            {
                return;
            }
            if (_flag == "insert")
            {
                seCardNoTSH1.Value = seCardNoTSH1.Value + 1;
                if (!cardNoexists(seCardNoTSH1.Value.ToString(), "TSH1"))
                {
                    return;
                }
                if (!firstResultexists(seCardNoTSH1.Value.ToString(), "TSH1"))
                {
                    return;
                }
                this.seCardNoTSH1.Focus();
            }
            else
            {
                this.lblCardCodeTSH1.Focus();
            }
           

            
        }

        private void txtTSH1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTSH1.Text.Trim()))
            {
                return;
            }
            double tsh1 = double.Parse(txtTSH1.Text);
            if (tsh1 > standardTSH.Normal_Low_Value && tsh1 < standardTSH.Normal_High_Value)
            {
                txtResultTSH1.Text = "阴性";
            }
            else if (tsh1 > standardTSH.Weak_Positive_Low_Value && tsh1 < standardTSH.Weak_Positive_High_Value)
            {
                txtResultTSH1.Text = "弱阳性";
            }
            else if (tsh1 > standardTSH.Positive_Low_Value && tsh1 < standardTSH.Positive_High_Value)
            {
                txtResultTSH1.Text = "阳性";
            }
            else
            {
                txtResultTSH1.Text = "";
            }

        }
        
        private void seCardNoTSH1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtFirstSenderTSH1.Focus();
            }
        }
        
        private void txtFirstSenderTSH1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter&&!string.IsNullOrEmpty(txtFirstSenderTSH1.Text))
            {
                this.txtSecondSenderTSH1.Focus();
            }
        }

        private void txtSecondSenderTSH1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.deCheckDateTSH1.Focus();
            }
        }

        private void deCheckDateTSH1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(deCheckDateTSH1.Text))
            {
                this.cbWashTSH1.Focus();
            }
        }

        private void cbWashTSH1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtTSH1.Focus();
            }
        }

        private void txtTSH1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSaveTSH1.Focus();
            }
        }

        private void btnSaveTSH1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSaveTSH1_Click(sender, e);
            }
        }
        #endregion

        #region TSH2

        private void seCardNoTSH2_Leave(object sender, EventArgs e)
        {
            if (cardNoexists(seCardNoTSH2.Text.Trim(), "TSH2"))
            {
                showCardInfo(seCardNoTSH2.Text.Trim(), "TSH2");
            }
        }

        private void txtTSH2_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtTSH2_1.Text.Trim(), e);
        }

        private void txtTSH2_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtTSH2_2.Text.Trim(), e);
        }

        private void txtTSH2_1_Leave(object sender, EventArgs e)
        {
            this.lblAVGTSH2.Text = ((float.Parse(string.IsNullOrEmpty(txtTSH2_1.Text.Trim()) ? "0" : txtTSH2_1.Text.Trim()) +
                float.Parse(string.IsNullOrEmpty(txtTSH2_2.Text.Trim()) ? "0" : txtTSH2_2.Text.Trim())) / 2).ToString("f4");
        }

        private void txtTSH2_2_Leave(object sender, EventArgs e)
        {
            this.lblAVGTSH2.Text = ((float.Parse(string.IsNullOrEmpty(txtTSH2_1.Text.Trim()) ? "0" : txtTSH2_1.Text.Trim()) +
                float.Parse(string.IsNullOrEmpty(txtTSH2_2.Text.Trim()) ? "0" : txtTSH2_2.Text.Trim())) / 2).ToString("f4");
        }

        private void btnSaveTSH2_Click(object sender, EventArgs e)
        {
            if (!checkNull("TSH2"))
            {
                return;
            }
            int count = saveValue(seCardNoTSH2.Text.Trim(), "TSH2");
            if (count < 1)
            {
                return;
            }
            if (_flag == "insert")
            {
                seCardNoTSH2.Value = seCardNoTSH2.Value + 1;
                if (!cardNoexists(seCardNoTSH2.Value.ToString(), "TSH2"))
                {
                    return;
                }
                if (!firstResultexists(seCardNoTSH2.Value.ToString(), "TSH2"))
                {
                    return;
                } this.seCardNoTSH2.Focus();
            }
            else
            {
                this.lblCardCodeTSH2.Focus();
            }
           
        }

        private void lblAVGTSH2_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(lblAVGTSH2.Text.Trim()))
            {
                return;
            }
            double tsh2 = double.Parse(this.lblAVGTSH2.Text);
            if (tsh2 > standardTSH.Normal_Low_Value && tsh2 < standardTSH.Normal_High_Value)
            {
                txtResultTSH2.Text = "阴性";
            }
            else if (tsh2 > standardTSH.Weak_Positive_Low_Value && tsh2 < standardTSH.Weak_Positive_High_Value)
            {
                txtResultTSH2.Text = "弱阳性";
            }
            else if (tsh2 > standardTSH.Positive_Low_Value && tsh2 < standardTSH.Positive_High_Value)
            {
                txtResultTSH2.Text = "阳性";
            }
            else
            {
                txtResultTSH2.Text = "";
            }
        }

        private void seCardNoTSH2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtFirstSenderTSH2.Focus();
            }
        }

        private void txtFirstSenderTSH2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtFirstSenderTSH2.Text))
            {
                this.txtSecondSenderTSH2.Focus();
            }
        }

        private void txtSecondSenderTSH2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.deCheckDateTSH2.Focus();
            }
        }

        private void deCheckDateTSH2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(deCheckDateTSH2.Text))
            {
                this.txtTSH2_1.Focus();
            }
        }

        private void txtTSH2_1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtTSH2_2.Focus();
            }
        }

        private void txtTSH2_2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSaveTSH2.Focus();
            }
        }

        private void btnSaveTSH2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSaveTSH2_Click(sender,e);
            }
        }
        #endregion

        #region PHE1
        private void seCardNoPHE1_Leave(object sender, EventArgs e)
        {
            if (cardNoexists(seCardNoPHE1.Text.Trim(), "PHE1"))
            {
                showCardInfo(seCardNoPHE1.Text.Trim(), "PHE1");
            }
        }

        private void btnSavePHE1_Click(object sender, EventArgs e)
        {
            if (!checkNull("PHE1"))
            {
                return;
            }
            int count = saveValue(seCardNoPHE1.Text.Trim(), "PHE1");
            if (count < 1)
            {
                return;
            }
            if (_flag == "insert")
            {
                seCardNoPHE1.Value = seCardNoPHE1.Value + 1;
                if (!cardNoexists(seCardNoPHE1.Value.ToString(), "PHE1"))
                {
                    return;
                }
                if (!firstResultexists(seCardNoPHE1.Value.ToString(), "PHE1"))
                {
                    return;
                }this.seCardNoPHE1.Focus();
            }
            else
            {
                this.lblCardCodePHE1.Focus();
            }
            
        }

        private void txtPHE1_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtPHE1.Text.Trim(), e);
        }

        private void txtPHE1_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtPHE1.Text.Trim()))
            {
                return;
            }
            double phe1 = double.Parse(txtPHE1.Text);
            if (phe1 < standardPHE.Normal_Low_Value)
            {

            }
            else if (phe1 > standardPHE.Normal_Low_Value && phe1 < standardPHE.Normal_High_Value)
            {
                txtResultPHE1.Text = "阴性";
            }
            else if (phe1 > standardPHE.Weak_Positive_Low_Value && phe1 < standardPHE.Weak_Positive_High_Value)
            {
                txtResultPHE1.Text = "弱阳性";
            }
            else if (phe1 > standardPHE.Positive_Low_Value && phe1 < standardPHE.Positive_High_Value)
            {
                txtResultPHE1.Text = "阳性";
            }
            else
            {
                txtResultPHE1.Text = "";
            }
        }
        
        private void seCardNoPHE1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtFirstSenderPHE1.Focus();
            }
        }

        private void txtFirstSenderPHE1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtFirstSenderPHE1.Text))
            {
                this.txtSecondSenderPHE1.Focus();
            }
        }

        private void txtSecondSenderPHE1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.deCheckDatePHE1.Focus();
            }
        }

        private void deCheckDatePHE1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(deCheckDatePHE1.Text))
            {
                this.txtPHE1.Focus();
            }
        }

        private void txtPHE1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSavePHE1.Focus();
            }
        }

        private void btnSavePHE1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSavePHE1_Click(sender,e);
            }
        }
        #endregion

        #region PHE2

        private void seCardNoPHE2_Leave(object sender, EventArgs e)
        {
            if (cardNoexists(seCardNoPHE2.Text.Trim(), "PHE2"))
            {
                showCardInfo(seCardNoPHE2.Text.Trim(), "PHE2");
            }
        }

        private void txtPHE2_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtPHE2_1.Text.Trim(), e);
        }

        private void txtPHE2_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtPHE2_2.Text.Trim(), e);
        }

        private void txtPHE2_1_Leave(object sender, EventArgs e)
        {
            this.lblAVGPHE2.Text = ((float.Parse(string.IsNullOrEmpty(txtPHE2_1.Text.Trim()) ? "0" : txtPHE2_1.Text.Trim()) +
                float.Parse(string.IsNullOrEmpty(txtPHE2_2.Text.Trim()) ? "0" : txtPHE2_2.Text.Trim())) / 2).ToString("f4");
        }

        private void txtPHE2_2_Leave(object sender, EventArgs e)
        {
            this.lblAVGPHE2.Text = ((float.Parse(string.IsNullOrEmpty(txtPHE2_1.Text.Trim()) ? "0" : txtPHE2_1.Text.Trim()) +
                float.Parse(string.IsNullOrEmpty(txtPHE2_2.Text.Trim()) ? "0" : txtPHE2_2.Text.Trim())) / 2).ToString("f4");
        }

        private void btnSavePHE2_Click(object sender, EventArgs e)
        {
            if (!checkNull("PHE2"))
            {
                return;
            }
            int count = saveValue(seCardNoPHE2.Text.Trim(), "PHE2");
            if (count < 1)
            {
                return;
            }
            if (_flag == "insert")
            {
                seCardNoPHE2.Value = seCardNoPHE2.Value + 1;
                if (!cardNoexists(seCardNoPHE2.Value.ToString(), "PHE2"))
                {
                    return;
                }
                if (!firstResultexists(seCardNoPHE2.Value.ToString(), "PHE2"))
                {
                    return;
                }  this.seCardNoPHE2.Focus();
            }
            else
            {
                this.lblCardCodePHE2.Focus();
            }
          
        }

        private void lblAVGPHE2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblAVGPHE2.Text.Trim()))
            {
                return;
            }
            double phe2 = double.Parse(this.lblAVGPHE2.Text);
            if (phe2 < standardPHE.Normal_Low_Value)
            {

            }
            else if (phe2 > standardPHE.Normal_Low_Value && phe2 < standardPHE.Normal_High_Value)
            {
                txtResultPHE2.Text = "阴性";
            }
            else if (phe2 > standardPHE.Weak_Positive_Low_Value && phe2 < standardPHE.Weak_Positive_High_Value)
            {
                txtResultPHE2.Text = "弱阳性";
            }
            else if (phe2 > standardPHE.Positive_Low_Value && phe2 < standardPHE.Positive_High_Value)
            {
                txtResultPHE2.Text = "阳性";
            }
            else
            {
                txtResultPHE2.Text = "";
            }
        }

        private void seCardNoPHE2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtFirstSenderPHE2.Focus();
            }
        }

        private void txtFirstSenderPHE2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtFirstSenderPHE2.Text))
            {
                this.txtSecondSenderPHE2.Focus();
            }
        }

        private void txtSecondSenderPHE2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.deCheckDatePHE2.Focus();
            }
        }

        private void deCheckDatePHE2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(deCheckDatePHE2.Text))
            {
                this.txtPHE2_1.Focus();
            }
        }

        private void txtPHE2_1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPHE2_2.Focus();
            }
        }

        private void txtPHE2_2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSavePHE2.Focus();
            }
        }

        private void btnSavePHE2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSavePHE2_Click(sender,e);
            }
        }
        #endregion

        #region G6PD1

        private void seCardNoG6DP1_Leave(object sender, EventArgs e)
        {
            if (cardNoexists(seCardNoG6PD1.Text.Trim(), "G6PD1"))
            {
                showCardInfo(seCardNoG6PD1.Text.Trim(), "G6PD1");
            }
        }
        
        private void btnSaveG6PD1_Click(object sender, EventArgs e)
        {
            if (!checkNull("G6PD1"))
            {
                return;
            }
            int count = saveValue(seCardNoG6PD1.Text.Trim(), "G6PD1");
            if (count < 1)
            {
                return;
            }
            if (_flag == "insert")
            {
                seCardNoG6PD1.Value = seCardNoG6PD1.Value + 1;
                if (!cardNoexists(seCardNoG6PD1.Value.ToString(), "G6PD1"))
                {
                    return;
                }
                if (!firstResultexists(seCardNoG6PD1.Value.ToString(), "G6PD1"))
                {
                    return;
                } this.seCardNoG6PD1.Focus();
            }
            else
            {
                this.lblCardCodeG6PD1.Focus();
            }
           
        }

        private void txtG6PD1_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtG6PD1.Text.Trim(), e);
        }

        private void txtG6PD1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtG6PD1.Text.Trim()))
            {
                return;
            }
            double g6pd1 = double.Parse(txtG6PD1.Text);
            if (g6pd1 < standardPHE.Normal_Low_Value)
            {

            }
            else if (g6pd1 > standardPHE.Normal_Low_Value)
            {
                txtResultG6PD1.Text = "阴性";
            }
            else if (g6pd1 > standardPHE.Weak_Positive_Low_Value && g6pd1 < standardPHE.Weak_Positive_High_Value)
            {
                txtResultG6PD1.Text = "弱阳性";
            }
            else if (g6pd1 > standardPHE.Positive_Low_Value && g6pd1 < standardPHE.Positive_High_Value)
            {
                txtResultG6PD1.Text = "阳性";
            }
            else
            {
                txtResultG6PD1.Text = "";
            }
        }

        private void seCardNoG6PD1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtFirstSenderG6PD1.Focus();
            }
        }

        private void txtFirstSenderG6PD1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtFirstSenderG6PD1.Text))
            {
                this.txtSecondSenderG6PD1.Focus();
            }
        }

        private void txtSecondSenderG6PD1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.deCheckDateG6PD1.Focus();
            }
        }

        private void deCheckDateG6PD1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(deCheckDateG6PD1.Text))
            {
                this.txtG6PD1.Focus();
            }
        }

        private void txtG6PD1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSaveG6PD1.Focus(); 
            }
        }

        private void btnSaveG6PD1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSaveG6PD1_Click(sender,e);
            }
        }
        #endregion

        #region G6PD2

        private void seCardNoG6PD2_Leave(object sender, EventArgs e)
        {
            if (cardNoexists(seCardNoG6PD2.Text.Trim(), "G6PD2"))
            {
                showCardInfo(seCardNoG6PD2.Text.Trim(), "G6PD2");
            }
        }

        private void txtG6PD2_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtG6PD2_1.Text.Trim(), e);
        }

        private void txtG6PD2_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtG6PD2_2.Text.Trim(), e);
        }

        private void txtG6PD2_1_Leave(object sender, EventArgs e)
        {
            this.lblAVGG6PD2.Text = ((float.Parse(string.IsNullOrEmpty(txtG6PD2_1.Text.Trim()) ? "0" : txtG6PD2_1.Text.Trim()) +
                float.Parse(string.IsNullOrEmpty(txtG6PD2_2.Text.Trim()) ? "0" : txtG6PD2_2.Text.Trim())) / 2).ToString("f4");
        }

        private void txtG6PD2_2_Leave(object sender, EventArgs e)
        {
            this.lblAVGG6PD2.Text = ((float.Parse(string.IsNullOrEmpty(txtG6PD2_1.Text.Trim()) ? "0" : txtG6PD2_1.Text.Trim()) +
                float.Parse(string.IsNullOrEmpty(txtG6PD2_2.Text.Trim()) ? "0" : txtG6PD2_2.Text.Trim())) / 2).ToString("f4");
        }

        private void btnSaveG6PD2_Click(object sender, EventArgs e)
        {
            if (!checkNull("G6PD2"))
            {
                return;
            }
            int count = saveValue(seCardNoG6PD2.Text.Trim(), "G6PD2");
            if (count < 1)
            {
                return;
            }
            if (_flag == "insert")
            {
                seCardNoG6PD2.Value = seCardNoG6PD2.Value + 1;
                if (!cardNoexists(seCardNoG6PD2.Value.ToString(), "G6PD2"))
                {
                    return;
                }
                if (!firstResultexists(seCardNoG6PD2.Value.ToString(), "G6PD2"))
                {
                    return;
                }  this.seCardNoG6PD2.Focus();
            }
            else
            {
                this.lblCardCodeG6PD2.Focus();
            }
          
        }

        private void lblAVGG6PD2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblAVGG6PD2.Text.Trim()))
            {
                return;
            }
            double g6pd2 = double.Parse(this.lblAVGG6PD2.Text);
            if (g6pd2 < standardPHE.Normal_Low_Value)
            {

            }
            else if (g6pd2 > standardPHE.Normal_Low_Value && g6pd2 < standardPHE.Normal_High_Value)
            {
                txtResultG6PD2.Text = "阴性";
            }
            else if (g6pd2 > standardPHE.Weak_Positive_Low_Value && g6pd2 < standardPHE.Weak_Positive_High_Value)
            {
                txtResultG6PD2.Text = "弱阳性";
            }
            else if (g6pd2 > standardPHE.Positive_Low_Value && g6pd2 < standardPHE.Positive_High_Value)
            {
                txtResultG6PD2.Text = "阳性";
            }
            else
            {
                txtResultG6PD2.Text = "";
            }
        }

        private void seCardNoG6PD2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtFirstSenderG6PD2.Focus();
            }
        }

        private void txtFirstSenderG6PD2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtFirstSenderG6PD2.Text))
            {
                this.txtSecondSenderG6PD2.Focus();
            }
        }

        private void txtSecondSenderG6PD2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.deCheckDateG6PD2.Focus();
            }
        }

        private void deCheckDateG6PD2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(deCheckDateG6PD2.Text))
            {
                this.txtG6PD2_1.Focus();
            }
        }

        private void txtG6PD2_1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtG6PD2_2.Focus();
            }
        }

        private void txtG6PD2_2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSaveG6PD2.Focus();
            }
        }

        private void btnSaveG6PD2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSaveG6PD2_Click(sender,e);
            }
        }
        #endregion

        

       

       

        

        

        

        

        














    }
}
