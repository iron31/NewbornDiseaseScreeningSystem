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
    public partial class UCAddOrUpdateSecondResult : UserControl
    {
        FBSqlHelper _sqlhelp = new FBSqlHelper();
        TabControl _tc = new TabControl();
        string _cardNo;
        string _flag;
        string _sql;
        NbSecondSceening _tsh = new NbSecondSceening();
        NbSecondSceening _phe = new NbSecondSceening();
        NbSecondSceening _g6pd = new NbSecondSceening();

        public UCAddOrUpdateSecondResult(TabControl tc, string flag, string cardNo)
        {
            InitializeComponent();
            _tc = tc;
            _flag = flag;
            _cardNo = cardNo;
        }




        private void btnReturnTSH1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要退出吗?未保存的数据将丢失!", "警告", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                _tc.SelectedTab = _tc.TabPages["SecondResultInfo"];
                {
                    DA.DataAccess.removeTabPage("AddSecondResult", _tc);
                    DA.DataAccess.removeTabPage("UpDateSecondResult", _tc);
                }
            }
        }

        #region 公共方法





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
                        txtCardNoTSH.Text = string.Empty;
                        //txtCardNoTSH.Focus();
                        break;
                    case "PHE1":
                        txtCardNoPHE.Text = string.Empty;
                        //txtCardNoPHE.Focus();
                        break;
                    case "G6PD1":
                        txtCardNoG6PD.Text = string.Empty;
                        //txtCardNoG6PD.Focus();
                        break;

                }
                MessageBox.Show("不存在卡号为 " + cardNo + " 的疾病卡!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
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
                        lblOrganizationTSH1.Text = dt.Rows[0]["ORGANIZATION_NAME"].ToString();
                        lblIllCaseNoTSH1.Text = dt.Rows[0]["ILLCASE_NO"].ToString();
                        lblWeightTSH1.Text = dt.Rows[0]["WEIGHT"].ToString();
                        lblGestationalWeeksTSH1.Text = dt.Rows[0]["GESTATIONAL_WEEKS"].ToString() + "+" + dt.Rows[0]["GESTATIONAL_DAYS"].ToString();
                        lblBirthdayTSH1.Text = dt.Rows[0]["BIRTHDAY"].ToString();
                        btnSaveTSH1.Enabled = true;
                        break;
                    case "PHE1":
                        lblMotherNamePHE1.Text = dt.Rows[0]["MOTHER_NAME"].ToString();
                        lblGenderPHE1.Text = dt.Rows[0]["GENDER_INFO"].ToString();
                        lblOrganizationPHE1.Text = dt.Rows[0]["ORGANIZATION_NAME"].ToString();
                        lblIllCaseNoPHE1.Text = dt.Rows[0]["ILLCASE_NO"].ToString();
                        lblWeightPHE1.Text = dt.Rows[0]["WEIGHT"].ToString();
                        lblGestationalWeeksPHE1.Text = dt.Rows[0]["GESTATIONAL_WEEKS"].ToString() + "+" + dt.Rows[0]["GESTATIONAL_DAYS"].ToString();
                        lblBirthdayPHE1.Text = dt.Rows[0]["BIRTHDAY"].ToString();
                        btnSavePHE1.Enabled = true;
                        break;
                    case "G6PD1":
                        lblMotherNameG6PD1.Text = dt.Rows[0]["MOTHER_NAME"].ToString();
                        lblGenderG6PD1.Text = dt.Rows[0]["GENDER_INFO"].ToString();
                        lblOrganizationG6PD1.Text = dt.Rows[0]["ORGANIZATION_NAME"].ToString();
                        lblIllCaseNoG6PD1.Text = dt.Rows[0]["ILLCASE_NO"].ToString();
                        lblWeightG6PD1.Text = dt.Rows[0]["WEIGHT"].ToString();
                        lblGestationalWeeksG6PD1.Text = dt.Rows[0]["GESTATIONAL_WEEKS"].ToString() + "+" + dt.Rows[0]["GESTATIONAL_DAYS"].ToString();
                        lblBirthdayG6PD1.Text = dt.Rows[0]["BIRTHDAY"].ToString();
                        btnSaveG6PD1.Enabled = true;
                        break;
                }
            }
        }
        #endregion


        #region TSH1


        private void txtCardNoTSH_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCardNoTSH.Text))
            {
                if (cardNoexists(txtCardNoTSH.Text.Trim(), "TSH1"))
                {
                    showCardInfo(txtCardNoTSH.Text.Trim(), "TSH1");
                }

            }
        }




        private void txtCardNoTSH_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtCardNoTSH.Text))
            {
                this.txtCardCodeTSH1.Focus();
            }
        }

        private void txtCardCodeTSH1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.deGetBloodDateTSH1.Focus();
            }
        }

        private void deGetBloodDateTSH1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtGetBloodUserTSH1.Focus();
            }
        }

        private void txtGetBloodUserTSH1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.deSendDateTSH1.Focus();
            }
        }

        private void deSendDateTSH1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.deReceivedDateTSH1.Focus();
            }
        }

        private void deReceivedDateTSH1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbQualiFiedTSH1.Focus();
            }
        }


        private void cbQualiFiedTSH1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cbQualiFiedTSH1.Text == "不合格")
            {
                cbReasonTSH1.Focus();
            }
            if (e.KeyCode == Keys.Enter && cbQualiFiedTSH1.Text == "合格")
            {
                this.txtFirstSenderTSH1.Focus();
            }
        }

        private void cbReasonTSH1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtFirstSenderTSH1.Focus();
            }
        }

        private void txtFirstSenderTSH1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
            if (e.KeyCode == Keys.Enter)
            {
                this.txtTSH1_1.Focus();
            }
        }

        private void txtTSH1_1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtTSH1_2.Focus();
            }
        }
        private void txtTSH1_2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbResultTSH1.Focus();
            }
        }


        private void cbResultTSH1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbResultTSH1.Text == "确诊")
                {
                    this.txtRemarkTSH1.Focus();
                }
                else if (cbResultTSH1.Text == "终结")
                {
                    this.txtFinalReasonTSH1.Focus();
                }
                else
                {
                    btnSaveTSH1.Focus();
                }
            }
        }

        private void txtFinalReasonTSH1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSaveTSH1.Focus();
            }
        }

        private void txtRemarkTSH1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSaveTSH1.Focus();
            }
        }
      
        private void cbResultTSH1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbResultTSH1.Text == "确诊")
            {
                txtRemarkTSH1.Enabled = true;
                txtFinalReasonTSH1.Enabled = false;
            }
            else if (cbResultTSH1.Text == "终结")
            {
                txtRemarkTSH1.Enabled = false;
                txtFinalReasonTSH1.Enabled = true;
            }
            else
            {
                txtRemarkTSH1.Enabled = txtFinalReasonTSH1.Enabled = false;
            }
        }

        private void txtTSH1_1_Leave(object sender, EventArgs e)
        {
            this.lblAvgTSH1.Text = ((float.Parse(string.IsNullOrEmpty(txtTSH1_1.Text.Trim()) ? "0" : txtTSH1_1.Text.Trim()) +
               float.Parse(string.IsNullOrEmpty(txtTSH1_2.Text.Trim()) ? "0" : txtTSH1_2.Text.Trim())) / 2).ToString("f4");
        }
        private void txtTSH1_2_Leave(object sender, EventArgs e)
        {
            this.lblAvgTSH1.Text = ((float.Parse(string.IsNullOrEmpty(txtTSH1_1.Text.Trim()) ? "0" : txtTSH1_1.Text.Trim()) +
               float.Parse(string.IsNullOrEmpty(txtTSH1_2.Text.Trim()) ? "0" : txtTSH1_2.Text.Trim())) / 2).ToString("f4");
        }
        private void txtTSH1_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtTSH1_1.Text.Trim(), e);
        }

        private void txtTSH1_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtTSH1_2.Text.Trim(), e);
        }
        private void txtCardNoTSH_KeyPress(object sender, KeyPressEventArgs e)
        {
            DA.DataAccess.checkNumber(this.txtCardNoTSH.Text, e, "");
        }
        private void btnSaveTSH1_Click(object sender, EventArgs e)
        {
            if (checkNull("TSH1"))
            {
                saveVaule(txtCardNoTSH.Text.Trim(), "TSH1");
            }
        }
        #endregion


        #region PHE1


        private void txtCardNoPHE_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCardNoPHE.Text))
            {
                if (cardNoexists(txtCardNoPHE.Text.Trim(), "PHE1"))
                {
                    showCardInfo(txtCardNoPHE.Text.Trim(), "PHE1");
                }
            }
        }




        private void txtCardNoPHE_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtCardNoPHE.Text))
            {
                this.txtCardCodePHE1.Focus();
            }
        }

        private void txtCardCodePHE1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.deGetBloodDatePHE1.Focus();
            }
        }

        private void deGetBloodDatePHE1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtGetBloodUserPHE1.Focus();
            }
        }

        private void txtGetBloodUserPHE1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.deSendDatePHE1.Focus();
            }
        }

        private void deSendDatePHE1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.deReceivedDatePHE1.Focus();
            }
        }

        private void deReceivedDatePHE1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbQualiFiedPHE1.Focus();
            }
        }


        private void cbQualiFiedPHE1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cbQualiFiedPHE1.Text == "不合格")
            {
                cbReasonPHE1.Focus();
            }
            if (e.KeyCode == Keys.Enter && cbQualiFiedPHE1.Text == "合格")
            {
                this.txtFirstSenderPHE1.Focus();
            }
        }

        private void cbReasonPHE1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtFirstSenderPHE1.Focus();
            }
        }

        private void txtFirstSenderPHE1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPHE1_1.Focus();
            }
        }

        private void txtPHE1_1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPHE1_2.Focus();
            }
        }
        private void txtPHE1_2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbResultPHE1.Focus();
            }
        }


        private void cbResultPHE1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbResultPHE1.Text == "确诊")
                {
                    this.txtRemarkPHE1.Focus();
                }
                else if (cbResultPHE1.Text == "终结")
                {
                    this.txtFinalReasonPHE1.Focus();
                }
                else
                {
                    btnSavePHE1.Focus();
                }
            }
        }

        private void txtFinalReasonPHE1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSavePHE1.Focus();
            }
        }

        private void txtRemarkPHE1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSavePHE1.Focus();
            }
        }
        private void cbResultPHE1_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbResultPHE1.Text == "确诊")
                {
                    this.txtRemarkPHE1.Focus();
                }
                else if (cbResultPHE1.Text == "终结")
                {
                    this.txtFinalReasonPHE1.Focus();
                }
                else
                {
                    btnSavePHE1.Focus();
                }
            }
        }
        private void cbResultPHE1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbResultPHE1.Text == "确诊")
            {
                txtRemarkPHE1.Enabled = true;
                txtFinalReasonPHE1.Enabled = false;
            }
            else if (cbResultPHE1.Text == "终结")
            {
                txtRemarkPHE1.Enabled = false;
                txtFinalReasonPHE1.Enabled = true;
            }
            else
            {
                txtRemarkPHE1.Enabled = txtFinalReasonPHE1.Enabled = false;
            }
        }

        private void txtPHE1_1_Leave(object sender, EventArgs e)
        {
            this.lblAvgPHE1.Text = ((float.Parse(string.IsNullOrEmpty(txtPHE1_1.Text.Trim()) ? "0" : txtPHE1_1.Text.Trim()) +
               float.Parse(string.IsNullOrEmpty(txtPHE1_2.Text.Trim()) ? "0" : txtPHE1_2.Text.Trim())) / 2).ToString("f4");
        }
        private void txtPHE1_2_Leave(object sender, EventArgs e)
        {
            this.lblAvgPHE1.Text = ((float.Parse(string.IsNullOrEmpty(txtPHE1_1.Text.Trim()) ? "0" : txtPHE1_1.Text.Trim()) +
               float.Parse(string.IsNullOrEmpty(txtPHE1_2.Text.Trim()) ? "0" : txtPHE1_2.Text.Trim())) / 2).ToString("f4");
        }
        private void txtPHE1_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtPHE1_1.Text.Trim(), e);
        }

        private void txtPHE1_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtPHE1_2.Text.Trim(), e);
        }

        private void txtCardNoPHE_KeyPress(object sender, KeyPressEventArgs e)
        {
            DA.DataAccess.checkNumber(this.txtCardNoPHE.Text, e, "");
        }

        private void btnSavePHE1_Click(object sender, EventArgs e)
        {
            if (checkNull("PHE1"))
            {
                saveVaule(txtCardNoPHE.Text.Trim(), "PHE1");
            }
        }
        #endregion


        #region G6PD1


        private void txtCardNoG6PD_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCardNoG6PD.Text))
            {
                if (cardNoexists(txtCardNoG6PD.Text.Trim(), "G6PD1"))
                {
                    showCardInfo(txtCardNoG6PD.Text.Trim(), "G6PD1");
                }

            }
        }




        private void txtCardNoG6PD_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtCardNoG6PD.Text))
            {
                this.txtCardCodeG6PD1.Focus();
            }
        }

        private void txtCardCodeG6PD1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.deGetBloodDateG6PD1.Focus();
            }
        }

        private void deGetBloodDateG6PD1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtGetBloodUserG6PD1.Focus();
            }
        }

        private void txtGetBloodUserG6PD1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.deSendDateG6PD1.Focus();
            }
        }

        private void deSendDateG6PD1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.deReceivedDateG6PD1.Focus();
            }
        }

        private void deReceivedDateG6PD1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbQualiFiedG6PD1.Focus();
            }
        }


        private void cbQualiFiedG6PD1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cbQualiFiedG6PD1.Text == "不合格")
            {
                cbReasonG6PD1.Focus();
            }
            if (e.KeyCode == Keys.Enter && cbQualiFiedG6PD1.Text == "合格")
            {
                this.txtFirstSenderG6PD1.Focus();
            }
        }

        private void cbReasonG6PD1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtFirstSenderG6PD1.Focus();
            }
        }

        private void txtFirstSenderG6PD1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
            if (e.KeyCode == Keys.Enter)
            {
                this.txtG6PD1.Focus();
            }
        }


        private void txtG6PD1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbResultG6PD1.Focus();
            }
        }


        private void cbResultG6PD1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbResultG6PD1.Text == "确诊")
                {
                    this.txtRemarkG6PD1.Focus();
                }
                else if (cbResultG6PD1.Text == "终结")
                {
                    this.txtFinalReasonG6PD1.Focus();
                }
                else
                {
                    btnSaveG6PD1.Focus();
                }
            }
        }

        private void txtFinalReasonG6PD1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSaveG6PD1.Focus();
            }
        }

        private void txtRemarkG6PD1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSaveG6PD1.Focus();
            }
        }

        private void cbResultG6PD1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbResultG6PD1.Text == "确诊")
            {
                txtRemarkG6PD1.Enabled = true;
                txtFinalReasonG6PD1.Enabled = false;
            }
            else if (cbResultG6PD1.Text == "终结")
            {
                txtRemarkG6PD1.Enabled = false;
                txtFinalReasonG6PD1.Enabled = true;
            }
            else
            {
                txtRemarkG6PD1.Enabled = txtFinalReasonG6PD1.Enabled = false;
            }
        }


        private void txtG6PD1_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtG6PD1.Text.Trim(), e);
        }

        private void txtCardNoG6PD_KeyPress(object sender, KeyPressEventArgs e)
        {
            DA.DataAccess.checkNumber(this.txtCardNoG6PD.Text, e, "");
        }

        private void btnSaveG6PD1_Click(object sender, EventArgs e)
        {
            if (checkNull("G6PD1"))
            {
                saveVaule(txtCardNoG6PD.Text.Trim(), "G6PD1");
            }
        }
        #endregion


        private bool checkNull(string type)
        {
            switch (type)
            {
                case "TSH1":
                    if (string.IsNullOrEmpty(txtCardNoTSH.Text) || string.IsNullOrEmpty(this.deGetBloodDateTSH1.Text) ||
                        string.IsNullOrEmpty(this.deReceivedDateTSH1.Text) || string.IsNullOrEmpty(txtFirstSenderTSH1.Text) ||
                        string.IsNullOrEmpty(deCheckDateTSH1.Text) || string.IsNullOrEmpty(txtTSH1_1.Text) ||
                        string.IsNullOrEmpty(txtTSH1_2.Text) || string.IsNullOrEmpty(cbResultTSH1.Text))
                    {
                        MessageBox.Show("带*的为必填项");
                        return false;
                    }
                    break;
                case "PHE1":
                    if (string.IsNullOrEmpty(txtCardNoPHE.Text) || string.IsNullOrEmpty(this.deGetBloodDatePHE1.Text) ||
                       string.IsNullOrEmpty(this.deReceivedDatePHE1.Text) || string.IsNullOrEmpty(txtFirstSenderPHE1.Text) ||
                       string.IsNullOrEmpty(deCheckDatePHE1.Text) || string.IsNullOrEmpty(txtPHE1_1.Text) ||
                       string.IsNullOrEmpty(txtPHE1_2.Text) || string.IsNullOrEmpty(cbResultPHE1.Text))
                    {
                        MessageBox.Show("带*的为必填项");
                        return false;
                    }
                    break;
                case "G6PD1":
                    if (string.IsNullOrEmpty(txtCardNoG6PD.Text) || string.IsNullOrEmpty(this.deGetBloodDateG6PD1.Text) ||
                       string.IsNullOrEmpty(this.deReceivedDateG6PD1.Text) || string.IsNullOrEmpty(txtFirstSenderG6PD1.Text) ||
                       string.IsNullOrEmpty(deCheckDateG6PD1.Text) || string.IsNullOrEmpty(txtG6PD1.Text) || string.IsNullOrEmpty(cbResultG6PD1.Text))
                    {
                        MessageBox.Show("带*的为必填项");
                        return false;
                    }
                    break;
            }
            return true;
        }

        private void UCAddOrUpdateSecondResult_Load(object sender, EventArgs e)
        {
            _sql = "select * from gm_params gps where gps.types='REASON' and status='1' ";
            //cbReason1.DataSource = _sqlhelp.GetDataTable(sql);
            //cbReason1.DisplayMember = "OBJECT_NAME";
            //cbReason1.ValueMember = "type_value";
            DataTable da = _sqlhelp.GetDataTable(_sql);
            for (int i = 0; i < da.Rows.Count; i++)
            {
                cbReasonTSH1.Properties.Items.Add(da.Rows[i]["type_value"].ToString(), da.Rows[i]["OBJECT_NAME"].ToString());
                cbReasonPHE1.Properties.Items.Add(da.Rows[i]["type_value"].ToString(), da.Rows[i]["OBJECT_NAME"].ToString());
                cbReasonG6PD1.Properties.Items.Add(da.Rows[i]["type_value"].ToString(), da.Rows[i]["OBJECT_NAME"].ToString());
            }
            //cbReason.Properties.DataSource = _sqlhelp.GetDataTable(sql);
            //cbReason.Properties.DisplayMember = "OBJECT_NAME";
            //cbReason.Properties.ValueMember = "type_value";
            _sql = "select * from gm_params gps where gps.types='QUALIFIED' and status='1' ";
            cbQualiFiedTSH1.DataSource = cbQualiFiedPHE1.DataSource = cbQualiFiedG6PD1.DataSource = _sqlhelp.GetDataTable(_sql);
            cbQualiFiedTSH1.DisplayMember = cbQualiFiedPHE1.DisplayMember = cbQualiFiedG6PD1.DisplayMember = "OBJECT_NAME";
            cbQualiFiedTSH1.ValueMember = cbQualiFiedPHE1.ValueMember = cbQualiFiedG6PD1.ValueMember = "type_value";
            if (_flag == "insert")
            {
                lblflag.Text = "新增复检记录";
                txtCardNoTSH.Enabled = txtCardNoPHE.Enabled = txtCardNoG6PD.Enabled = true;
            }
            else if (_flag == "update")
            {
                lblflag.Text = "修改复检记录";
                TSH1.PageVisible = PHE1.PageVisible = G6PD1.PageVisible = false;
                txtCardNoTSH.Enabled = txtCardNoPHE.Enabled = txtCardNoG6PD.Enabled = false;
                string sqlCard = @"SELECT * FROM NB_DISEASE_SCREENING_CARD ncd
                                where ncd.card_no=?;";
                object[] paramCard = { _cardNo };
                DataTable dt = _sqlhelp.Query("", sqlCard, paramCard);
                
                string sql = @"SELECT * FROM NB_SECOND_SCREENING nsg
                                        where nsg.CARD_NO=?";
                object[] param = { _cardNo };
                DataTable t = _sqlhelp.Query("", sql, param);
                for (int i = 0; i < t.Rows.Count; i++)
                {
                    if (t.Rows[i]["ITEM_NAME"].ToString() == "TSH1")
                    {
                        TSH1.PageVisible = true;
                        _tsh.Second_screening_id =long.Parse(t.Rows[i]["Second_screening_id"].ToString());
                        txtCardNoTSH.Text= t.Rows[i]["CARD_NO"].ToString();
                        txtCardCodeTSH1.Text = t.Rows[i]["CARD_CODE"].ToString();
                        deGetBloodDateTSH1.Text = t.Rows[i]["GET_BLOOD_DATE"].ToString();
                        txtGetBloodUserTSH1.Text = t.Rows[i]["GET_BLOOD_USER_NAME"].ToString();
                        deSendDateTSH1.Text = t.Rows[i]["SEND_DATE"].ToString();
                        deReceivedDateTSH1.Text = t.Rows[i]["RECEIVED_DATE"].ToString();
                        cbQualiFiedTSH1.SelectedValue = t.Rows[i]["QUALIFIED"].ToString();
                        cbReasonTSH1.Text = t.Rows[i]["REASON_INFO"].ToString();
                        txtFirstSenderTSH1.Text = t.Rows[i]["FIRST_SENDER"].ToString();
                        txtSecondSenderTSH1.Text = t.Rows[i]["SECOND_SENDER"].ToString();
                        deCheckDateTSH1.Text = t.Rows[i]["CHECK_TIME"].ToString();
                        txtTSH1_1.Text = t.Rows[i]["VALUES1"].ToString();
                        txtTSH1_2.Text = t.Rows[i]["VALUES2"].ToString();
                        lblAvgTSH1.Text = t.Rows[i]["VALUES_AVG"].ToString();
                        cbResultTSH1.Text = t.Rows[i]["RESULT"].ToString();
                        txtRemarkTSH1.Text = t.Rows[i]["DIAGNOSE_REMARK"].ToString();
                        txtFinalReasonTSH1.Text = t.Rows[i]["FINALLY_REASON"].ToString();
                        string[] strarr = t.Rows[i]["REASON"].ToString().Split(',');
                        foreach (var m in strarr)
                        {
                            for (int n = 0; n < cbReasonTSH1.Properties.Items.Count; n++)
                            {
                                if (cbReasonTSH1.Properties.Items[n].Value.ToString() == m.ToString().Trim())
                                {
                                    cbReasonTSH1.Properties.Items[n].CheckState = CheckState.Checked;
                                }
                            }

                        }
                        if (dt.Rows.Count == 1)
                        {
                            lblMotherNameTSH1.Text=dt.Rows[0]["MOTHER_NAME"].ToString();
                            lblOrganizationTSH1.Text = dt.Rows[0]["ORGANIZATION_NAME"].ToString();
                            lblGenderTSH1.Text = dt.Rows[0]["GENDER"].ToString()=="0"?"女":"男";
                            lblWeightTSH1.Text = dt.Rows[0]["WEIGHT"].ToString();
                            lblBirthdayTSH1.Text = dt.Rows[0]["BIRTHDAY"].ToString();
                            lblIllCaseNoTSH1.Text = dt.Rows[0]["ILLCASE_NO"].ToString();
                            lblGestationalWeeksTSH1.Text = dt.Rows[0]["Gestational_Weeks"].ToString() + "+" + dt.Rows[0]["Gestational_days"].ToString();
                        }
                    }
                    if (t.Rows[i]["ITEM_NAME"].ToString() == "PHE1")
                    {
                        PHE1.PageVisible = true;
                        _phe.Second_screening_id = long.Parse(t.Rows[i]["Second_screening_id"].ToString());
                        txtCardNoPHE.Text = t.Rows[i]["CARD_NO"].ToString();
                        txtCardCodePHE1.Text = t.Rows[i]["CARD_CODE"].ToString();
                        deGetBloodDatePHE1.Text = t.Rows[i]["GET_BLOOD_DATE"].ToString();
                        txtGetBloodUserPHE1.Text = t.Rows[i]["GET_BLOOD_USER_NAME"].ToString();
                        deSendDatePHE1.Text = t.Rows[i]["SEND_DATE"].ToString();
                        deReceivedDatePHE1.Text = t.Rows[i]["RECEIVED_DATE"].ToString();
                        cbQualiFiedPHE1.SelectedValue = t.Rows[i]["QUALIFIED"].ToString();
                        cbReasonPHE1.Text = t.Rows[i]["REASON_INFO"].ToString();
                        txtFirstSenderPHE1.Text = t.Rows[i]["FIRST_SENDER"].ToString();
                        txtSecondSenderPHE1.Text = t.Rows[i]["SECOND_SENDER"].ToString();
                        deCheckDatePHE1.Text = t.Rows[i]["CHECK_TIME"].ToString();
                        txtPHE1_1.Text = t.Rows[i]["VALUES1"].ToString();
                        txtPHE1_2.Text = t.Rows[i]["VALUES2"].ToString();
                        lblAvgPHE1.Text = t.Rows[i]["VALUES_AVG"].ToString();
                        cbResultPHE1.Text = t.Rows[i]["RESULT"].ToString();
                        txtRemarkPHE1.Text = t.Rows[i]["DIAGNOSE_REMARK"].ToString();
                        txtFinalReasonPHE1.Text = t.Rows[i]["FINALLY_REASON"].ToString();
                        string[] strarr = t.Rows[i]["REASON"].ToString().Split(',');
                        foreach (var m in strarr)
                        {
                            for (int n = 0; n < cbReasonPHE1.Properties.Items.Count; n++)
                            {
                                if (cbReasonPHE1.Properties.Items[n].Value.ToString() == m.ToString().Trim())
                                {
                                    cbReasonPHE1.Properties.Items[n].CheckState = CheckState.Checked;
                                }
                            }

                        }
                        if (dt.Rows.Count == 1)
                        {
                            lblMotherNamePHE1.Text = dt.Rows[0]["MOTHER_NAME"].ToString();
                            lblOrganizationPHE1.Text = dt.Rows[0]["ORGANIZATION_NAME"].ToString();
                            lblGenderPHE1.Text = dt.Rows[0]["GENDER"].ToString() == "0" ? "女" : "男";
                            lblWeightPHE1.Text = dt.Rows[0]["WEIGHT"].ToString();
                            lblBirthdayPHE1.Text = dt.Rows[0]["BIRTHDAY"].ToString();
                            lblIllCaseNoPHE1.Text = dt.Rows[0]["ILLCASE_NO"].ToString();
                            lblGestationalWeeksPHE1.Text = dt.Rows[0]["Gestational_Weeks"].ToString() + "+" + dt.Rows[0]["Gestational_days"].ToString();
                        }
                    }
                    
                    if (t.Rows[i]["ITEM_NAME"].ToString() == "G6PD1")
                    {
                        G6PD1.PageVisible = true;
                        _g6pd.Second_screening_id = long.Parse(t.Rows[i]["Second_screening_id"].ToString());
                        txtCardNoG6PD.Text = t.Rows[i]["CARD_NO"].ToString();
                        txtCardCodeG6PD1.Text = t.Rows[i]["CARD_CODE"].ToString();
                        deGetBloodDateG6PD1.Text = t.Rows[i]["GET_BLOOD_DATE"].ToString();
                        txtGetBloodUserG6PD1.Text = t.Rows[i]["GET_BLOOD_USER_NAME"].ToString();
                        deSendDateG6PD1.Text = t.Rows[i]["SEND_DATE"].ToString();
                        deReceivedDateG6PD1.Text = t.Rows[i]["RECEIVED_DATE"].ToString();
                        cbQualiFiedG6PD1.SelectedValue = t.Rows[i]["QUALIFIED"].ToString();
                        cbReasonG6PD1.Text = t.Rows[i]["REASON_INFO"].ToString();
                        txtFirstSenderG6PD1.Text = t.Rows[i]["FIRST_SENDER"].ToString();
                        txtSecondSenderG6PD1.Text = t.Rows[i]["SECOND_SENDER"].ToString();
                        deCheckDateG6PD1.Text = t.Rows[i]["CHECK_TIME"].ToString();
                        txtG6PD1.Text = t.Rows[i]["VALUES1"].ToString();
                        cbResultG6PD1.Text = t.Rows[i]["RESULT"].ToString();
                        txtRemarkG6PD1.Text = t.Rows[i]["DIAGNOSE_REMARK"].ToString();
                        txtFinalReasonG6PD1.Text = t.Rows[i]["FINALLY_REASON"].ToString();
                        string[] strarr = t.Rows[i]["REASON"].ToString().Split(',');
                        foreach (var m in strarr)
                        {
                            for (int n = 0; n < cbReasonG6PD1.Properties.Items.Count; n++)
                            {
                                if (cbReasonG6PD1.Properties.Items[n].Value.ToString() == m.ToString().Trim())
                                {
                                    cbReasonG6PD1.Properties.Items[n].CheckState = CheckState.Checked;
                                }
                            }

                        }
                        if (dt.Rows.Count == 1)
                        {
                            lblMotherNameG6PD1.Text = dt.Rows[0]["MOTHER_NAME"].ToString();
                            lblOrganizationG6PD1.Text = dt.Rows[0]["ORGANIZATION_NAME"].ToString();
                            lblGenderG6PD1.Text = dt.Rows[0]["GENDER"].ToString() == "0" ? "女" : "男";
                            lblWeightG6PD1.Text = dt.Rows[0]["WEIGHT"].ToString();
                            lblBirthdayG6PD1.Text = dt.Rows[0]["BIRTHDAY"].ToString();
                            lblIllCaseNoG6PD1.Text = dt.Rows[0]["ILLCASE_NO"].ToString();
                            lblGestationalWeeksG6PD1.Text = dt.Rows[0]["Gestational_Weeks"].ToString() + "+" + dt.Rows[0]["Gestational_days"].ToString();
                        }
                    }
                   
                }

            }

        }


        private int saveVaule(string cardNo, string type)
        {
            #region MyRegion
            //int count = 0;

            //    if (!secondResultExists(cardNo, type))
            //    {
            //        return 0;
            //    }
            //    switch (type)
            //    {
            //        case "TSH1":
            //            object[] paramTSH1 = { txtCardNoTSH.Text.Trim(),
            //                           txtCardCodeTSH1.Text.Trim(),
            //                           deGetBloodDateTSH1.DateTime.ToString(), 
            //                           txtGetBloodUserTSH1.Text.Trim(), 
            //                           deReceivedDateTSH1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
            //                           deSendDateTSH1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
            //                           cbQualiFiedTSH1.SelectedValue, 
            //                           cbReasonTSH1.EditValue, 
            //                           txtFirstSenderTSH1.Text.Trim(), 
            //                           txtSecondSenderTSH1.Text.Trim(), 
            //                           deCheckDateTSH1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
            //                           txtTSH1_1.Text.Trim(), 
            //                           txtTSH1_2.Text.Trim(), 
            //                           GmUser.User_id, 
            //                           "TSH1", 
            //                           "TSH", 
            //                           lblAvgTSH1.Text, 
            //                           txtFinalReasonTSH1.Text.Trim(), 
            //                           txtRemarkTSH1.Text.Trim()};
            //            string tsh1 = string.Format(DA.Sql.addSecondResult, paramTSH1);
            //            count = _sqlhelp.ExecuteNonQuery(tsh1);

            //            break;
            //        case "PHE1":
            //            object[] paramPHE1 = { txtCardNoPHE.Text.Trim(),
            //                           txtCardCodePHE1.Text.Trim(),
            //                           deGetBloodDatePHE1.DateTime.ToString(), 
            //                           txtGetBloodUserPHE1.Text.Trim(), 
            //                           deReceivedDatePHE1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
            //                           deSendDatePHE1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
            //                           cbQualiFiedPHE1.SelectedValue, 
            //                           cbReasonPHE1.EditValue, 
            //                           txtFirstSenderPHE1.Text.Trim(), 
            //                           txtSecondSenderPHE1.Text.Trim(), 
            //                           deCheckDatePHE1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
            //                           txtPHE1_1.Text.Trim(), 
            //                           txtPHE1_2.Text.Trim(), 
            //                           GmUser.User_id, 
            //                           "PHE1", 
            //                           "PHE", 
            //                           lblAvgPHE1.Text, 
            //                           txtFinalReasonPHE1.Text.Trim(), 
            //                           txtRemarkPHE1.Text.Trim()};
            //            string phe1 = string.Format(DA.Sql.addSecondResult, paramPHE1);
            //            count = _sqlhelp.ExecuteNonQuery(phe1);
            //            break;
            //        case "G6PD1":
            //            object[] paramG6PD1 = { txtCardNoTSH.Text.Trim(),
            //                           txtCardCodeG6PD1.Text.Trim(),
            //                           deGetBloodDateG6PD1.DateTime.ToString(), 
            //                           txtGetBloodUserG6PD1.Text.Trim(), 
            //                           deReceivedDateG6PD1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
            //                           deSendDateG6PD1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
            //                           cbQualiFiedG6PD1.SelectedValue, 
            //                           cbReasonG6PD1.EditValue, 
            //                           txtFirstSenderG6PD1.Text.Trim(), 
            //                           txtSecondSenderG6PD1.Text.Trim(), 
            //                           deCheckDateG6PD1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
            //                           txtG6PD1.Text.Trim(), 
            //                           "", 
            //                           GmUser.User_id, 
            //                           "G6PD1", 
            //                           "G6PD", 
            //                           txtG6PD1.Text.Trim(),
            //                           txtFinalReasonG6PD1.Text.Trim(), 
            //                           txtRemarkG6PD1.Text.Trim()};
            //            string g6pd1 = string.Format(DA.Sql.addSecondResult, paramG6PD1);
            //            count = _sqlhelp.ExecuteNonQuery(g6pd1);
            //            break;
            //    } 
            //    return count;
            #endregion
         
            object[] param;
            int count = 0;
            if (!cardNoexists(cardNo, type))
            {
                return 0;
            }
            switch (type)
            {
                case "TSH1":
                    txtCardNoTSH.Focus();
                    cardNo = txtCardNoTSH.Text;
                    if (!secondResultExists(cardNo, type))
                    {
                        return 0;
                    }
                    if (_flag == "insert")
                    {
                        param = new object[] { txtCardNoTSH.Text.Trim(),
                                       txtCardCodeTSH1.Text.Trim(),
                                       deGetBloodDateTSH1.DateTime.ToString(), 
                                       txtGetBloodUserTSH1.Text.Trim(), 
                                       deReceivedDateTSH1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                                       deSendDateTSH1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                                       cbQualiFiedTSH1.SelectedValue, 
                                       cbReasonTSH1.EditValue, 
                                       txtFirstSenderTSH1.Text.Trim(), 
                                       txtSecondSenderTSH1.Text.Trim(), 
                                       deCheckDateTSH1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                                       txtTSH1_1.Text.Trim(), 
                                       txtTSH1_2.Text.Trim(), 
                                       GmUser.User_id, 
                                       "TSH1", 
                                       "TSH", 
                                       lblAvgTSH1.Text, 
                                       txtFinalReasonTSH1.Text.Trim(), 
                                       txtRemarkTSH1.Text.Trim(),
                                       cbReasonTSH1.Text.Trim(),
                                       cbResultTSH1.Text.Trim()};
                        string tsh1 = string.Format(DA.Sql.addSecondResult, param);
                        count = _sqlhelp.ExecuteNonQuery(tsh1);
                    }
                    else if (_flag == "update")
                    {
                        param = new object[] { txtCardCodeTSH1.Text.Trim(),
                                               deGetBloodDateTSH1.DateTime.ToString(), 
                                               txtGetBloodUserTSH1.Text.Trim(), 
                                               deReceivedDateTSH1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                                               deSendDateTSH1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                                               cbQualiFiedTSH1.SelectedValue, 
                                               cbReasonTSH1.EditValue, 
                                               txtFirstSenderTSH1.Text.Trim(), 
                                               txtSecondSenderTSH1.Text.Trim(), 
                                               deCheckDateTSH1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                                               txtTSH1_1.Text.Trim(), 
                                               txtTSH1_2.Text.Trim(),
                                               "CURRENT_TIMESTAMP",
                                               GmUser.User_id, 
                                               lblAvgTSH1.Text, 
                                               txtFinalReasonTSH1.Text.Trim(), 
                                               txtRemarkTSH1.Text.Trim(),
                                               cbReasonTSH1.Text.Trim(),
                                               cbResultTSH1.Text.Trim(),
                                               _tsh.Second_screening_id  
                                            };
                        string sql = string.Format(Sql.UpdateSecondResult, param);
                        count = _sqlhelp.ExecuteNonQuery(sql);
                    }
                    break;
                case "PHE1":
                    txtCardNoPHE.Focus();
                    cardNo = txtCardNoPHE.Text;
                    if (!secondResultExists(cardNo, type))
                    {
                        return 0;
                    }
                    if (_flag == "insert")
                    {
                        param = new object[] { txtCardNoPHE.Text.Trim(),
                                               txtCardCodePHE1.Text.Trim(),
                                               deGetBloodDatePHE1.DateTime.ToString(), 
                                               txtGetBloodUserPHE1.Text.Trim(), 
                                               deReceivedDatePHE1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                                               deSendDatePHE1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                                               cbQualiFiedPHE1.SelectedValue, 
                                               cbReasonPHE1.EditValue, 
                                               txtFirstSenderPHE1.Text.Trim(), 
                                               txtSecondSenderPHE1.Text.Trim(), 
                                               deCheckDatePHE1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                                               txtPHE1_1.Text.Trim(), 
                                               txtPHE1_2.Text.Trim(), 
                                               GmUser.User_id, 
                                               "PHE1", 
                                               "PHE", 
                                               lblAvgPHE1.Text, 
                                               txtFinalReasonPHE1.Text.Trim(), 
                                               txtRemarkPHE1.Text.Trim(),
                                               cbReasonPHE1.Text.Trim(),
                                               cbResultPHE1.Text.Trim()};
                        string phe1 = string.Format(DA.Sql.addSecondResult, param);
                        count = _sqlhelp.ExecuteNonQuery(phe1);
                    }
                    else if (_flag == "update")
                    {
                        param = new object[] { txtCardCodePHE1.Text.Trim(),
                                               deGetBloodDatePHE1.DateTime.ToString(), 
                                               txtGetBloodUserPHE1.Text.Trim(), 
                                               deReceivedDatePHE1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                                               deSendDatePHE1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                                               cbQualiFiedPHE1.SelectedValue, 
                                               cbReasonPHE1.EditValue, 
                                               txtFirstSenderPHE1.Text.Trim(), 
                                               txtSecondSenderPHE1.Text.Trim(), 
                                               deCheckDatePHE1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                                               txtPHE1_1.Text.Trim(), 
                                               txtPHE1_2.Text.Trim(),
                                               "current_timestamp",
                                               GmUser.User_id, 
                                               lblAvgPHE1.Text, 
                                               txtFinalReasonPHE1.Text.Trim(), 
                                               txtRemarkPHE1.Text.Trim(),
                                               cbReasonPHE1.Text.Trim(),
                                               cbResultPHE1.Text.Trim(),
                                               _phe.Second_screening_id
                                            };
                        string sql = string.Format(Sql.UpdateSecondResult, param);
                        count = _sqlhelp.ExecuteNonQuery(sql);
                    }

                    break;

                case "G6PD1":
                    txtCardNoG6PD.Focus();
                    cardNo = txtCardNoG6PD.Text;
                    if (!secondResultExists(cardNo, type))
                    {
                        return 0;
                    }

                    if (_flag == "insert")
                    {
                        param = new object[] { txtCardNoG6PD.Text.Trim(),
                                               txtCardCodeG6PD1.Text.Trim(),
                                               deGetBloodDateG6PD1.DateTime.ToString(), 
                                               txtGetBloodUserG6PD1.Text.Trim(), 
                                               deReceivedDateG6PD1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                                               deSendDateG6PD1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                                               cbQualiFiedG6PD1.SelectedValue, 
                                               cbReasonG6PD1.EditValue, 
                                               txtFirstSenderG6PD1.Text.Trim(), 
                                               txtSecondSenderG6PD1.Text.Trim(), 
                                               deCheckDateG6PD1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                                               txtG6PD1.Text.Trim(), 
                                               "", 
                                               GmUser.User_id, 
                                               "G6PD1", 
                                               "G6PD", 
                                               txtG6PD1.Text.Trim(),
                                               txtFinalReasonG6PD1.Text.Trim(), 
                                               txtRemarkG6PD1.Text.Trim(),
                                               cbReasonG6PD1.Text.Trim(),
                                               cbResultG6PD1.Text.Trim()};
                        string g6pd1 = string.Format(DA.Sql.addSecondResult, param);
                        count = _sqlhelp.ExecuteNonQuery(g6pd1);

                    }
                    else if (_flag == "update")
                    {
                        param = new object[] {  txtCardCodeG6PD1.Text.Trim(),
                                               deGetBloodDateG6PD1.DateTime.ToString(), 
                                               txtGetBloodUserG6PD1.Text.Trim(), 
                                               deReceivedDateG6PD1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                                               deSendDateG6PD1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                                               cbQualiFiedG6PD1.SelectedValue, 
                                               cbReasonG6PD1.EditValue, 
                                               txtFirstSenderG6PD1.Text.Trim(), 
                                               txtSecondSenderG6PD1.Text.Trim(), 
                                               deCheckDateG6PD1.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                                               txtG6PD1.Text.Trim(), 
                                               "",
                                               "current_timestamp",
                                               GmUser.User_id, 
                                               txtG6PD1.Text.Trim(), 
                                               txtFinalReasonG6PD1.Text.Trim(), 
                                               txtRemarkG6PD1.Text.Trim(),
                                               cbReasonG6PD1.Text.Trim(),
                                               cbResultG6PD1.Text.Trim(),
                                               _g6pd.Second_screening_id
                                            };
                        string sql = string.Format(Sql.UpdateSecondResult, param);
                        count = _sqlhelp.ExecuteNonQuery(sql);
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

                            break;
                        case "PHE1":

                            break;
                        case "G6PD1":

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

        }

        /// <summary>
        /// 检查是否存在改卡号的复检记录，不存在则无法修改
        /// </summary>
        /// <param name="cardNo">卡号</param>
        /// <param name="type">值类型（TSH1,PHE1,G6PD1）</param>
        /// <returns></returns>
        private bool secondResultExists(string cardNo, string type)
        {
            object[] param = { cardNo, type };
            DataTable dt = _sqlhelp.Query("", Sql.secondResultExists, param);
            bool exists = false;
            if (dt.Rows.Count == 0)
            {
                if (_flag == "insert")
                {
                    return true;
                }
                else if (_flag == "update")
                {
                    MessageBox.Show("不存在卡号为 " + cardNo + " 的复检" + type + "结果,无法修改!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    switch (type)
                    {
                        case "TSH1":
                            txtCardNoTSH.Focus();
                            break;
                        case "PHE1":
                            txtCardNoPHE.Focus();
                            break;
                        case "G6PD1":
                            txtCardNoG6PD.Focus();
                            break;
                    }
                    return false;
                }
            }
            else
            {
                if (_flag == "insert")
                {
                    MessageBox.Show("卡号为 " + cardNo + " 的复检" + type + "结果已存在!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    switch (type)
                    {
                        case "TSH1":
                            txtCardNoTSH.Focus();
                            break;
                        case "PHE1":
                            txtCardNoPHE.Focus();
                            break;
                        case "G6PD1":
                            txtCardNoG6PD.Focus();
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
    }
}
