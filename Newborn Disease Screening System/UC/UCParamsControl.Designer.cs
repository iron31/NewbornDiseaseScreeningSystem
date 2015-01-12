namespace Newborn_Disease_Screening_System.UC
{
    partial class UCParamsControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tlParams = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.gcParams = new DevExpress.XtraGrid.GridControl();
            this.tsmGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.gvParams = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcParams)).BeginInit();
            this.tsmGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvParams)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panelControl1.Controls.Add(this.tlParams);
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(235, 546);
            this.panelControl1.TabIndex = 0;
            // 
            // tlParams
            // 
            this.tlParams.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3});
            this.tlParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlParams.Location = new System.Drawing.Point(2, 2);
            this.tlParams.Name = "tlParams";
            this.tlParams.OptionsView.ShowColumns = false;
            this.tlParams.OptionsView.ShowHorzLines = false;
            this.tlParams.OptionsView.ShowIndicator = false;
            this.tlParams.OptionsView.ShowVertLines = false;
            this.tlParams.Size = new System.Drawing.Size(231, 542);
            this.tlParams.TabIndex = 0;
            this.tlParams.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.tlParams.CustomDrawNodeIndicator += new DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventHandler(this.tlParams_CustomDrawNodeIndicator);
            this.tlParams.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeList1_CustomDrawNodeCell);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.ReadOnly = true;
            this.treeListColumn1.Width = 89;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "treeListColumn2";
            this.treeListColumn2.FieldName = "treeListColumn2";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.OptionsColumn.ReadOnly = true;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 0;
            this.treeListColumn2.Width = 140;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "treeListColumn3";
            this.treeListColumn3.FieldName = "treeListColumn3";
            this.treeListColumn3.Name = "treeListColumn3";
            // 
            // gcParams
            // 
            this.gcParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcParams.ContextMenuStrip = this.tsmGrid;
            this.gcParams.Location = new System.Drawing.Point(239, 0);
            this.gcParams.MainView = this.gvParams;
            this.gcParams.Name = "gcParams";
            this.gcParams.Size = new System.Drawing.Size(817, 546);
            this.gcParams.TabIndex = 1;
            this.gcParams.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvParams});
            // 
            // tsmGrid
            // 
            this.tsmGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAdd,
            this.tsmUpdate});
            this.tsmGrid.Name = "contextMenuStrip1";
            this.tsmGrid.ShowCheckMargin = true;
            this.tsmGrid.Size = new System.Drawing.Size(175, 70);
            // 
            // tsmAdd
            // 
            this.tsmAdd.Name = "tsmAdd";
            this.tsmAdd.Size = new System.Drawing.Size(174, 22);
            this.tsmAdd.Text = "新增";
            this.tsmAdd.Click += new System.EventHandler(this.tsmAdd_Click);
            // 
            // tsmUpdate
            // 
            this.tsmUpdate.Name = "tsmUpdate";
            this.tsmUpdate.Size = new System.Drawing.Size(174, 22);
            this.tsmUpdate.Text = "修改";
            this.tsmUpdate.Click += new System.EventHandler(this.tsmUpdate_Click);
            // 
            // gvParams
            // 
            this.gvParams.GridControl = this.gcParams;
            this.gvParams.Name = "gvParams";
            this.gvParams.OptionsView.ShowGroupPanel = false;
            // 
            // UCParamsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcParams);
            this.Controls.Add(this.panelControl1);
            this.Name = "UCParamsControl";
            this.Size = new System.Drawing.Size(1056, 546);
            this.Load += new System.EventHandler(this.UCParamsControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcParams)).EndInit();
            this.tsmGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvParams)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTreeList.TreeList tlParams;
        private DevExpress.XtraGrid.GridControl gcParams;
        private DevExpress.XtraGrid.Views.Grid.GridView gvParams;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private System.Windows.Forms.ContextMenuStrip tsmGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmUpdate;
    }
}
