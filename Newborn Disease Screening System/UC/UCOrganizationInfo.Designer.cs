namespace Newborn_Disease_Screening_System
{
    partial class UCOrganizationInfo
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
            this.gcOrganization = new DevExpress.XtraGrid.GridControl();
            this.gvOrganization = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.orgcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.orgname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.level = new DevExpress.XtraGrid.Columns.GridColumn();
            this.belong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.orgid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.orglevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ORGBELONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.btnGoBack = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOrganization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrganization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcOrganization
            // 
            this.gcOrganization.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcOrganization.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gcOrganization.Location = new System.Drawing.Point(36, 61);
            this.gcOrganization.MainView = this.gvOrganization;
            this.gcOrganization.Name = "gcOrganization";
            this.gcOrganization.Size = new System.Drawing.Size(931, 348);
            this.gcOrganization.TabIndex = 0;
            this.gcOrganization.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOrganization});
            // 
            // gvOrganization
            // 
            this.gvOrganization.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.orgcode,
            this.orgname,
            this.level,
            this.belong,
            this.orgid,
            this.orglevel,
            this.ORGBELONG});
            this.gvOrganization.GridControl = this.gcOrganization;
            this.gvOrganization.Name = "gvOrganization";
            this.gvOrganization.OptionsView.ShowGroupPanel = false;
            // 
            // orgcode
            // 
            this.orgcode.Caption = "单位代码";
            this.orgcode.FieldName = "ORG_CODE";
            this.orgcode.Name = "orgcode";
            this.orgcode.OptionsColumn.AllowEdit = false;
            this.orgcode.Visible = true;
            this.orgcode.VisibleIndex = 0;
            // 
            // orgname
            // 
            this.orgname.Caption = "单位名称";
            this.orgname.FieldName = "ORG_NAME";
            this.orgname.Name = "orgname";
            this.orgname.OptionsColumn.AllowEdit = false;
            this.orgname.Visible = true;
            this.orgname.VisibleIndex = 1;
            // 
            // level
            // 
            this.level.Caption = "单位级别";
            this.level.FieldName = "LEVEL";
            this.level.Name = "level";
            this.level.OptionsColumn.AllowEdit = false;
            this.level.Visible = true;
            this.level.VisibleIndex = 2;
            // 
            // belong
            // 
            this.belong.Caption = "归属单位";
            this.belong.FieldName = "BELONG";
            this.belong.Name = "belong";
            this.belong.OptionsColumn.AllowEdit = false;
            this.belong.Visible = true;
            this.belong.VisibleIndex = 3;
            // 
            // orgid
            // 
            this.orgid.Caption = "gridColumn1";
            this.orgid.FieldName = "ORG_ID";
            this.orgid.Name = "orgid";
            // 
            // orglevel
            // 
            this.orglevel.Caption = "gridColumn1";
            this.orglevel.FieldName = "ORG_LEVEL";
            this.orglevel.Name = "orglevel";
            // 
            // ORGBELONG
            // 
            this.ORGBELONG.Caption = "gridColumn1";
            this.ORGBELONG.FieldName = "ORG_BELONG";
            this.ORGBELONG.Name = "ORGBELONG";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.btnQuery);
            this.panelControl1.Controls.Add(this.btnGoBack);
            this.panelControl1.Controls.Add(this.btnUpdate);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtCode);
            this.panelControl1.Location = new System.Drawing.Point(36, 449);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(931, 70);
            this.panelControl1.TabIndex = 1;
            // 
            // btnQuery
            // 
            this.btnQuery.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuery.Appearance.Options.UseFont = true;
            this.btnQuery.Location = new System.Drawing.Point(393, 26);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "查  询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnGoBack
            // 
            this.btnGoBack.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoBack.Appearance.Options.UseFont = true;
            this.btnGoBack.Location = new System.Drawing.Point(689, 26);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(75, 23);
            this.btnGoBack.TabIndex = 5;
            this.btnGoBack.Text = "返  回";
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.Location = new System.Drawing.Point(593, 26);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "修  改";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Location = new System.Drawing.Point(494, 26);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "增  加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Location = new System.Drawing.Point(302, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "定  位";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(18, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 19);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "快速定位:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(102, 27);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Properties.Appearance.Options.UseFont = true;
            this.txtCode.Size = new System.Drawing.Size(132, 26);
            this.txtCode.TabIndex = 0;
            // 
            // UCOrganizationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gcOrganization);
            this.Name = "UCOrganizationInfo";
            this.Size = new System.Drawing.Size(996, 587);
            this.Load += new System.EventHandler(this.UCOrganizationInfo_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.UCOrganizationInfo_Layout);
            ((System.ComponentModel.ISupportInitialize)(this.gcOrganization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrganization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcOrganization;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOrganization;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGoBack;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraGrid.Columns.GridColumn orgcode;
        private DevExpress.XtraGrid.Columns.GridColumn orgname;
        private DevExpress.XtraGrid.Columns.GridColumn level;
        private DevExpress.XtraGrid.Columns.GridColumn belong;
        private DevExpress.XtraGrid.Columns.GridColumn orgid;
        private DevExpress.XtraGrid.Columns.GridColumn orglevel;
        private DevExpress.XtraGrid.Columns.GridColumn ORGBELONG;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
    }
}
