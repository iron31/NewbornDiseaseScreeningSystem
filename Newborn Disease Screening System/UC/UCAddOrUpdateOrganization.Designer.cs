namespace Newborn_Disease_Screening_System.UC
{
    partial class UCAddOrUpdateOrganization
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cbOrgBelong = new System.Windows.Forms.ComboBox();
            this.cbOrgLevel = new System.Windows.Forms.ComboBox();
            this.txtOrgName = new DevExpress.XtraEditors.TextEdit();
            this.txtOrgCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnGoBack = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrgName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrgCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.cbOrgBelong);
            this.panelControl1.Controls.Add(this.cbOrgLevel);
            this.panelControl1.Controls.Add(this.txtOrgName);
            this.panelControl1.Controls.Add(this.txtOrgCode);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnGoBack);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Location = new System.Drawing.Point(44, 30);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(904, 510);
            this.panelControl1.TabIndex = 0;
            // 
            // cbOrgBelong
            // 
            this.cbOrgBelong.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbOrgBelong.FormattingEnabled = true;
            this.cbOrgBelong.Location = new System.Drawing.Point(559, 268);
            this.cbOrgBelong.Name = "cbOrgBelong";
            this.cbOrgBelong.Size = new System.Drawing.Size(149, 24);
            this.cbOrgBelong.TabIndex = 4;
            // 
            // cbOrgLevel
            // 
            this.cbOrgLevel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbOrgLevel.FormattingEnabled = true;
            this.cbOrgLevel.Location = new System.Drawing.Point(260, 268);
            this.cbOrgLevel.Name = "cbOrgLevel";
            this.cbOrgLevel.Size = new System.Drawing.Size(153, 24);
            this.cbOrgLevel.TabIndex = 3;
            this.cbOrgLevel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbOrgLevel_KeyUp);
            // 
            // txtOrgName
            // 
            this.txtOrgName.Location = new System.Drawing.Point(559, 163);
            this.txtOrgName.Name = "txtOrgName";
            this.txtOrgName.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrgName.Properties.Appearance.Options.UseFont = true;
            this.txtOrgName.Size = new System.Drawing.Size(149, 25);
            this.txtOrgName.TabIndex = 2;
            this.txtOrgName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOrgName_KeyUp);
            // 
            // txtOrgCode
            // 
            this.txtOrgCode.Location = new System.Drawing.Point(260, 163);
            this.txtOrgCode.Name = "txtOrgCode";
            this.txtOrgCode.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrgCode.Properties.Appearance.Options.UseFont = true;
            this.txtOrgCode.Size = new System.Drawing.Size(153, 25);
            this.txtOrgCode.TabIndex = 1;
            this.txtOrgCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOrgCode_KeyUp);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl4.Location = new System.Drawing.Point(470, 270);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 16);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "归属单位:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl3.Location = new System.Drawing.Point(450, 166);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(96, 16);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "医疗单位名称";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl2.Location = new System.Drawing.Point(175, 270);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 16);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "单位级别:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Location = new System.Drawing.Point(175, 166);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 16);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "单位代码:";
            // 
            // btnGoBack
            // 
            this.btnGoBack.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGoBack.Appearance.Options.UseFont = true;
            this.btnGoBack.Location = new System.Drawing.Point(631, 336);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(75, 23);
            this.btnGoBack.TabIndex = 6;
            this.btnGoBack.Text = "返  回";
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(516, 336);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保  存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // UCAddOrUpdateOrganization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "UCAddOrUpdateOrganization";
            this.Size = new System.Drawing.Size(996, 587);
            this.Load += new System.EventHandler(this.UCAddOrUpdateOrganization_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.UCAddOrUpdateOrganization_Layout);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrgName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrgCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtOrgName;
        private DevExpress.XtraEditors.TextEdit txtOrgCode;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGoBack;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.ComboBox cbOrgBelong;
        private System.Windows.Forms.ComboBox cbOrgLevel;
    }
}
