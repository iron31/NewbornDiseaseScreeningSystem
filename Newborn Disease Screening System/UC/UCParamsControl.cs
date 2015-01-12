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
using Newborn_Disease_Screening_System.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid.Columns;

namespace Newborn_Disease_Screening_System.UC
{
    public partial class UCParamsControl : UserControl
    {
        FBSqlHelper _sqlhelp = new FBSqlHelper();
        TabControl _tc = null;
        string _sql = string.Empty;
        string _tmp;
        string _type;
        string _table;
        DataTable _dt = new DataTable();

        public UCParamsControl(TabControl tc)
        {
            InitializeComponent();
            _tc = tc;
        }

        private void UCParamsControl_Load(object sender, EventArgs e)
        {
            showInfo();
        }

        private void treeList1_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            TreeList node = sender as TreeList; if (e.Node == node.FocusedNode)
            {
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds); Rectangle r =
                    new Rectangle(e.EditViewInfo.ContentRect.Left, e.EditViewInfo.ContentRect.Top,
                        Convert.ToInt32(e.Graphics.MeasureString(e.CellText, tlParams.Font).Width + 1),
                        Convert.ToInt32(e.Graphics.MeasureString(e.CellText, tlParams.Font).Height));
                e.Graphics.FillRectangle(SystemBrushes.Highlight, r);
                e.Graphics.DrawString(e.CellText, tlParams.Font, SystemBrushes.HighlightText, r);
                e.Handled = true;
            }
        }

        private void treeList1_Click(object sender, EventArgs e)
        {

        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {

            DataTable dt;
            string sql;
            gvParams.Columns.Clear();
            if (tlParams.Columns.Count <= 0)
            {
                return;
            }
            if(tlParams.Nodes.Count<=0)
            {
                return;
            }
            _tmp = tlParams.FocusedNode.GetDisplayText(0);
            _table = tlParams.FocusedNode.GetDisplayText(1);
            _type = tlParams.FocusedNode.GetDisplayText(2);


            switch (_table)
            {
                case "医疗保健机构人员表":
                    tsmUpdate.Enabled = false;
                    tsmAdd.Enabled = true;
                    sql = string.Format(@"select 
                                          gur.user_code {0}, 
                                          gur.user_name {1}, 
                                          case gur.user_type 
                                            when 1 then '管理员'
                                            when 2 then '操作员'
                                          end {2}
                                        from gm_user gur 
                                        where
                                          user_type <> 0
                                          order by user_code;", "\"用户工号\"", "\"用户名称\"", "\"用户类别\""
                                               );
                    dt = _sqlhelp.GetDataTable(sql);
                    showTableInfo(dt);
                    this.gcParams.DataSource = dt;
                    break;
                case "检验值标准表":
                    tsmUpdate.Enabled = false;
                    tsmAdd.Enabled = true;
                    sql = string.Format(@"select 
                              nvs.item_name {0}, 
                              nvs.disease_name {1}, 
                              nvs.units {2}, 
                              nvs.normal_low_value {3}, 
                              nvs.normal_high_value {4}, 
                              nvs.weak_positive_low_value {5}, 
                              nvs.weak_positive_high_value {6}, 
                              nvs.positive_low_value {7}, 
                              nvs.positive_high_value {8}
                            from nb_standard_values nvs;",
                            "\"项目\"", "\"疾病名称\"", "\"检验值单位\"",
                            "\"正常值低限\"", "\"正常值高限\"",
                            "\"弱阳性低限\"", "\"弱阳性高限\"",
                            "\"阳性低限\"", "\"阳性高限\"");
                    dt = _sqlhelp.GetDataTable(sql);
                    showTableInfo(dt);
                    this.gcParams.DataSource = dt;
                    break;
                case "参数表":
                    tsmUpdate.Enabled = false;
                    tsmAdd.Enabled = true;
                    sql = string.Format(@"select 
                                          gps.id {0},
                                          gps.object_name {1},
                                          gps.type_value {2},
                                          gps.types {3},
                                          gps.remark {4}
                                        from gm_params gps 
                                        where
                                          gps.types <> 'MAC'
                                          order by types,type_value;",
                            "\"序号\"", "\"项目名称\"", "\"数据\"",
                            "\"项目类型\"", "\"说明\""
                           );
                    dt = _sqlhelp.GetDataTable(sql);
                    showTableInfo(dt);
                    this.gcParams.DataSource = dt;
                    gvParams.Columns[0].Visible = false;
                    break;
            }
            switch (_type)
            {
                case "USER":
                    tsmAdd.Enabled = false;
                    tsmUpdate.Enabled = true;
                    object[] paramUser = { _tmp };
                    sql = string.Format(@"select
                                gur.USER_CODE as {0},
                                gur.USER_NAME as {1},
                                case gur.USER_TYPE 
                                    when 1 then '{2}'
                                    when 2 then '{3}'
                                end as {4} 
                                from gm_user gur where user_id='{5}'", "\"工号\"", "\"姓名\"", "管理员", "操作员", "\"人员类别\"", _tmp);
                    dt = _sqlhelp.GetDataTable(sql);
                    this.gcParams.DataSource = showTableInfo(dt, new string[] { "名称", "数据" });
                    break;

                case "STANDARD":
                    tsmAdd.Enabled = false;
                    tsmUpdate.Enabled = true;
                    object[] paramStandard = { _tmp };
                    sql = string.Format(@"select 
                              nvs.item_name {0}, 
                              nvs.disease_name {1}, 
                              nvs.units {2}, 
                              nvs.normal_low_value {3}, 
                              nvs.normal_high_value {4}, 
                              nvs.weak_positive_low_value {5}, 
                              nvs.weak_positive_high_value {6}, 
                              nvs.positive_low_value {7}, 
                              nvs.positive_high_value {8}
                            from nb_standard_values nvs
                              where nvs.STANDARD_VALUES_ID = {9};",
                            "\"项目\"", "\"疾病名称\"", "\"检验值单位\"",
                            "\"正常值低限\"", "\"正常值高限\"",
                            "\"弱阳性低限\"", "\"弱阳性高限\"",
                            "\"阳性低限\"", "\"阳性高限\"", _tmp);
                    dt = _sqlhelp.GetDataTable(sql);
                    this.gcParams.DataSource = showTableInfo(dt, new string[] { "名称", "数据" });
                    break;
                case "PARAMS":
                    tsmAdd.Enabled = false;
                    tsmUpdate.Enabled = true;
                    object[] paramParams = { _tmp };
                    sql = string.Format(@"select 
                                          gps.object_name {0},
                                          gps.type_value {1},
                                          gps.types {2},
                                          gps.remark {3}
                                        from gm_params gps 
                                        where
                                          gps.types <> 'MAC'
                                          and id ={4}",
                            "\"项目名称\"", "\"数据\"",
                            "\"项目类型\"", "\"说明\"", _tmp);
                    dt = _sqlhelp.GetDataTable(sql);
                    this.gcParams.DataSource = showTableInfo(dt, new string[] { "名称", "数据" });
                    break;

            }
        }

        private void tlParams_CustomDrawNodeIndicator(object sender, CustomDrawNodeIndicatorEventArgs e)
        {
            //TreeList tree = sender as DevExpress.XtraTreeList.TreeList;

            //IndicatorObjectInfoArgs args = e.ObjectArgs as IndicatorObjectInfoArgs;

            //args.DisplayText = (this.tlParams.GetVisibleIndexByNode(e.Node) + 1).ToString();
        }

        private void showTableInfo(DataTable dt)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                GridColumn gc = new GridColumn();
                // gc1.Caption = "gridColumn1";
                gc.Name = dt.Columns[i].ColumnName;
                gc.Visible = true;
                gc.VisibleIndex = i;
                gc.FieldName = dt.Columns[i].ColumnName;
                gc.OptionsColumn.AllowEdit = false;
                gc.OptionsColumn.ReadOnly = true;
                gvParams.Columns.Add(gc);
            }
        }

        private DataTable showTableInfo(DataTable dt, string[] param)
        {
            DataTable dtuser = new DataTable();
            int count = param.Length;
            for (int i = 0; i < count; i++)
            {
                dtuser.Columns.Add(param[i]);
            }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                List<string> Row = new List<string>();

                for (int j = 0; j < count; j++)
                {
                    if (j < 1)
                    {
                        Row.Add(dt.Columns[i].ColumnName);
                        ;
                    }
                    else
                    {
                        Row.Add(dt.Rows[0][i].ToString());
                    }

                }

                dtuser.Rows.Add(Row.ToArray());
            }
            return dtuser;
        }

        private void tsmUpdate_Click(object sender, EventArgs e)
        {
            switch (_type)
            {
                case "USER":
                    FormUpdateUser updateUser = new FormUpdateUser("update", _tmp);
                    updateUser.ShowDialog();
                    if (updateUser.DialogResult == DialogResult.OK)
                    {
                        tlParams.MoveFirst();
                    }
                    break;
                case "STANDARD":
                    FormUpdateStandard updateStandard = new FormUpdateStandard("update", _tmp);
                    updateStandard.ShowDialog();

                    if (updateStandard.DialogResult == DialogResult.OK)
                    {
                        tlParams.MoveFirst();
                    }
                    break;
                case "PARAMS":
                    FormUpdateParams updateParams = new FormUpdateParams("update", _tmp);
                    updateParams.ShowDialog();
                    //DialogResult drParams = updateParams.DialogResult;
                    if (updateParams.DialogResult == DialogResult.OK)
                    {
                        tlParams.MoveFirst();
                    }
                    break;
            }

        }

        private void tsmAdd_Click(object sender, EventArgs e)
        {
            switch (_table)
            {
                case "医疗保健机构人员表":
                    FormUpdateUser addUser = new FormUpdateUser("add", _tmp);
                    addUser.ShowDialog();
                    if (addUser.DialogResult == DialogResult.OK)
                    {
                        showInfo();
                    }
                    break;
                case "检验值标准表":
                    FormUpdateStandard addStandard = new FormUpdateStandard("add", _tmp);
                    addStandard.ShowDialog();

                    if (addStandard.DialogResult == DialogResult.OK)
                    {
                       showInfo();
                    }
                    break;
                case "参数表":
                    FormUpdateParams addParams = new FormUpdateParams("add", _tmp);
                    addParams.ShowDialog();
                    //DialogResult drParams = addParams.DialogResult;
                    if (addParams.DialogResult == DialogResult.OK)
                    {
                       showInfo();
                    }
                    break;
            }
        }

        private void showInfo()
        {
            tlParams.Columns[0].Visible = false;
            gvParams.OptionsBehavior.Editable = false;
            tlParams.Nodes.Clear();
            _sql = "select * from gm_user where user_type <> 0";
            _dt = _sqlhelp.GetDataTable(_sql);
            TreeListNode ParentNode = tlParams.AppendNode(null, null);
            ParentNode.SetValue(tlParams.Columns[1], "医疗保健机构人员表");
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                TreeListNode node = tlParams.AppendNode("", ParentNode);
                node.SetValue(tlParams.Columns[0], _dt.Rows[i]["USER_id"].ToString());
                node.SetValue(tlParams.Columns[1], _dt.Rows[i]["USER_NAME"].ToString());
                node.SetValue(tlParams.Columns[2], "USER");
            }

            _sql = "select * from nb_standard_values";
            _dt = _sqlhelp.GetDataTable(_sql);
            TreeListNode ParentNode2 = tlParams.AppendNode(null, null);
            ParentNode2.SetValue(tlParams.Columns[1], "检验值标准表");
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                TreeListNode node = tlParams.AppendNode("", ParentNode2);
                node.SetValue(tlParams.Columns[0], _dt.Rows[i]["STANDARD_VALUES_ID"].ToString());
                node.SetValue(tlParams.Columns[1], _dt.Rows[i]["ITEM_NAME"].ToString());
                node.SetValue(tlParams.Columns[2], "STANDARD");
            }

            _sql = @"select 
                      gps.id,
                      gps.REMARK||':'||gps.OBJECT_NAME REMARK
                    from gm_params gps 
                    where
                      gps.types <> 'MAC'
                      order by types;
                    ";
            _dt = _sqlhelp.GetDataTable(_sql);
            TreeListNode ParentNode3 = tlParams.AppendNode(null, null);
            ParentNode3.SetValue(tlParams.Columns[1], "参数表");
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                TreeListNode node = tlParams.AppendNode("", ParentNode3);
                node.SetValue(tlParams.Columns[0], _dt.Rows[i]["ID"].ToString());
                node.SetValue(tlParams.Columns[1], _dt.Rows[i]["REMARK"].ToString());
                node.SetValue(tlParams.Columns[2], "PARAMS");
            }
            tlParams.MoveLast();
            tlParams.MoveFirst();
        }

    }
}
