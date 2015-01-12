using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newborn_Disease_Screening_System.DA;

namespace Newborn_Disease_Screening_System.Forms
{
    public partial class FormUpdateStandard : Form
    {
        string _flag = string.Empty;
        string _key = string.Empty;
        FBSqlHelper _sqlhelp = new FBSqlHelper();
        DataTable _dt = new DataTable();
        int _count = 0;
      
        public FormUpdateStandard(string flag, string key)
        {
            InitializeComponent();
             _flag = flag;
            _key = key;
        }

        private void FormUpdateStandard_Load(object sender, EventArgs e)
        {
            if (_flag == "update")
            {
                this.Text = "修改参数";
                string sql = string.Format(@"select * from NB_STANDARD_VALUES
                            where STANDARD_VALUES_ID= {0}", _key);
                _dt = _sqlhelp.GetDataTable(sql);
                if (_dt.Rows.Count > 0)
                {
                    txtItemName.Text=_dt.Rows[0]["ITEM_NAME"].ToString();
                    txtDiseaseName.Text = _dt.Rows[0]["DISEASE_NAME"].ToString();
                    txtNormalHighValue.Text = _dt.Rows[0]["NORMAL_HIGH_VALUE"].ToString();
                    txtNormalLowValue.Text = _dt.Rows[0]["NORMAL_LOW_VALUE"].ToString();
                    txtWeakPositiveHighValue.Text = _dt.Rows[0]["WEAK_POSITIVE_HIGH_VALUE"].ToString();
                    txtWeakPositiveLowValue.Text = _dt.Rows[0]["WEAK_POSITIVE_LOW_VALUE"].ToString();
                    txtPositiveHighValue.Text = _dt.Rows[0]["POSITIVE_HIGH_VALUE"].ToString();
                    txtPositiveLowValue.Text = _dt.Rows[0]["POSITIVE_LOW_VALUE"].ToString();
                }
            }
            else
            {
                this.Text = "新增参数";
                this.txtItemName.Enabled=true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_flag == "update")
            {
                string[] param = { txtItemName.Text.Trim(), txtDiseaseName.Text.Trim(), 
                                   txtNormalLowValue.Text.Trim(), txtNormalHighValue.Text.Trim(),
                                   txtWeakPositiveLowValue.Text.Trim(), txtWeakPositiveHighValue.Text.Trim(),
                                   txtPositiveLowValue.Text.Trim(), txtPositiveHighValue.Text.Trim(),
                                   _key };
                string sql = string.Format(@"UPDATE
                                              NB_STANDARD_VALUES
                                            SET
                                              ITEM_NAME = '{0}',
                                              DISEASE_NAME = '{1}',
                                              NORMAL_LOW_VALUE = {2},
                                              NORMAL_HIGH_VALUE = {3},
                                              WEAK_POSITIVE_LOW_VALUE = {4},
                                              WEAK_POSITIVE_HIGH_VALUE = {5},
                                              POSITIVE_LOW_VALUE = {6},
                                              POSITIVE_HIGH_VALUE = {7}
                                            WHERE
                                              STANDARD_VALUES_ID = {8}", param);
                _count = _sqlhelp.ExecuteNonQuery(sql);
            }
            else if (_flag == "add")
            {
               
            }
            if (_count == 1)
            {
                MessageBox.Show("保存成功!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txtNormalLowValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtNormalLowValue.Text.Trim(), e);
        }

        private void txtNormalHighValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtNormalHighValue.Text.Trim(), e);
        }

        private void txtWeakPositiveHighValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtWeakPositiveHighValue.Text.Trim(), e);
        }

        private void txtWeakPositiveLowValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtWeakPositiveLowValue.Text.Trim(), e);
        }

        private void txtPositiveLowValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtPositiveLowValue.Text.Trim(), e);
        }

        private void txtPositiveHighValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataAccess.checkNumber(txtPositiveHighValue.Text.Trim(), e);
        }
    }
}
