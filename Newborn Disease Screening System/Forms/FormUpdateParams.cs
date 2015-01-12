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
    public partial class FormUpdateParams : Form
    {
        string _flag = string.Empty;
        string _key = string.Empty;
        FBSqlHelper _sqlhelp = new FBSqlHelper();
        DataTable _dt = new DataTable();
        int _count = 0;
        public FormUpdateParams(string flag, string key)
        {
            InitializeComponent();
            _flag = flag;
            _key = key;
        }

        private void FormUpdateParams_Load(object sender, EventArgs e)
        {
            if (_flag == "update")
            {
                this.Text = "修改参数";
                string sql = string.Format(@"select * from gm_params gps
                            where gps.id= {0}", _key);
                _dt = _sqlhelp.GetDataTable(sql);
                if (_dt.Rows.Count > 0)
                {
                    txtObjectName.Text = _dt.Rows[0]["OBJECT_NAME"].ToString();
                    txtValue.Text = _dt.Rows[0]["type_value"].ToString();
                    txtType.Text = _dt.Rows[0]["types"].ToString();
                    txtRemark.Text = _dt.Rows[0]["remark"].ToString();
                }
            }
            else
            {
                this.Text = "新增参数";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_flag == "update")
            {
                string[] param = { txtObjectName.Text.Trim(), txtValue.Text.Trim(), txtType.Text.Trim(), txtRemark.Text.Trim(), _key };
                string sql = string.Format(@"UPDATE
                                          GM_PARAMS
                                        SET
                                          OBJECT_NAME = '{0}',
                                          TYPE_VALUE = '{1}',
                                          TYPES = '{2}',
                                          REMARK = '{3}'
                                        WHERE
                                          ID = {4}", param);
                _count = _sqlhelp.ExecuteNonQuery(sql);
            }
            else if (_flag == "add")
            {
                string[] param = { txtObjectName.Text.Trim(), txtValue.Text.Trim(), txtType.Text.Trim(), txtRemark.Text.Trim() };
                string sql = string.Format(@"INSERT INTO GM_PARAMS
                                            (OBJECT_NAME, TYPE_VALUE, TYPES, REMARK)
                                        VALUES
                                            ( '{0}', '{1}', '{2}', '{3}')", param);
                _count = _sqlhelp.ExecuteNonQuery(sql);
            }
            if (_count == 1)
            {
                MessageBox.Show("保存成功!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
