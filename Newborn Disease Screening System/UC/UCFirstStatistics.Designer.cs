namespace Newborn_Disease_Screening_System.UC
{
    partial class UCFirstStatistics
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
            this.deReceivedEndDate = new DevExpress.XtraEditors.DateEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.rdoType = new DevExpress.XtraEditors.RadioGroup();
            this.deReceivedBegDate = new DevExpress.XtraEditors.DateEdit();
            this.btnGoBack = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.deEndDate = new DevExpress.XtraEditors.DateEdit();
            this.rdoDate = new DevExpress.XtraEditors.RadioGroup();
            this.deBegDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deReceivedEndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReceivedEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReceivedBegDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReceivedBegDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBegDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBegDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.deReceivedEndDate);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Controls.Add(this.deReceivedBegDate);
            this.panelControl1.Controls.Add(this.btnGoBack);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.btnQuery);
            this.panelControl1.Controls.Add(this.deEndDate);
            this.panelControl1.Controls.Add(this.rdoDate);
            this.panelControl1.Controls.Add(this.deBegDate);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Location = new System.Drawing.Point(175, 105);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(637, 419);
            this.panelControl1.TabIndex = 2;
            // 
            // deReceivedEndDate
            // 
            this.deReceivedEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deReceivedEndDate.EditValue = new System.DateTime(2014, 11, 8, 10, 49, 2, 0);
            this.deReceivedEndDate.Location = new System.Drawing.Point(407, 303);
            this.deReceivedEndDate.Name = "deReceivedEndDate";
            this.deReceivedEndDate.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deReceivedEndDate.Properties.Appearance.Options.UseFont = true;
            this.deReceivedEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deReceivedEndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deReceivedEndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deReceivedEndDate.Size = new System.Drawing.Size(95, 25);
            this.deReceivedEndDate.TabIndex = 37;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.rdoType);
            this.groupControl1.Location = new System.Drawing.Point(103, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(442, 231);
            this.groupControl1.TabIndex = 21;
            this.groupControl1.Text = "统计因素";
            // 
            // rdoType
            // 
            this.rdoType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoType.Location = new System.Drawing.Point(2, 23);
            this.rdoType.Name = "rdoType";
            this.rdoType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("GENDER", "新生儿性别          (男，女，不详)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("WEIGHT", "出生体重          (<2.5 Kg,2.5-4.0Kg,>4.0Kg )"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("WEEKS", "孕周(<37周,37-42周,>42周)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("YIELD", "生产方式(顺产,剖宫产,产钳助产,胎吸,臀位助娩,其它)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("TSH", "TSH(阴性,弱阳性,阳性)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("PHE", "PHE(阴性,弱阳性,阳性)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("G6PD", "G6PD(阴性,弱阳性,阳性)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ANAMNESIS", "病史(无,甲亢,甲低,PKU,病理儿)")});
            this.rdoType.Size = new System.Drawing.Size(438, 206);
            this.rdoType.TabIndex = 20;
            // 
            // deReceivedBegDate
            // 
            this.deReceivedBegDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deReceivedBegDate.EditValue = new System.DateTime(2014, 11, 8, 10, 48, 54, 0);
            this.deReceivedBegDate.Location = new System.Drawing.Point(254, 303);
            this.deReceivedBegDate.Name = "deReceivedBegDate";
            this.deReceivedBegDate.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deReceivedBegDate.Properties.Appearance.Options.UseFont = true;
            this.deReceivedBegDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deReceivedBegDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deReceivedBegDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deReceivedBegDate.Size = new System.Drawing.Size(95, 25);
            this.deReceivedBegDate.TabIndex = 36;
            // 
            // btnGoBack
            // 
            this.btnGoBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoBack.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoBack.Appearance.Options.UseFont = true;
            this.btnGoBack.Location = new System.Drawing.Point(409, 356);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(85, 30);
            this.btnGoBack.TabIndex = 19;
            this.btnGoBack.Text = "返  回";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl3.Location = new System.Drawing.Point(370, 306);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(16, 16);
            this.labelControl3.TabIndex = 35;
            this.labelControl3.Text = "至";
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuery.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuery.Appearance.Options.UseFont = true;
            this.btnQuery.Location = new System.Drawing.Point(152, 356);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(85, 30);
            this.btnQuery.TabIndex = 18;
            this.btnQuery.Text = "查  询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // deEndDate
            // 
            this.deEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deEndDate.EditValue = new System.DateTime(2014, 11, 8, 10, 49, 2, 0);
            this.deEndDate.Location = new System.Drawing.Point(407, 263);
            this.deEndDate.Name = "deEndDate";
            this.deEndDate.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deEndDate.Properties.Appearance.Options.UseFont = true;
            this.deEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deEndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deEndDate.Size = new System.Drawing.Size(95, 25);
            this.deEndDate.TabIndex = 34;
            // 
            // rdoDate
            // 
            this.rdoDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoDate.Location = new System.Drawing.Point(103, 263);
            this.rdoDate.Name = "rdoDate";
            this.rdoDate.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoDate.Properties.Appearance.Options.UseFont = true;
            this.rdoDate.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "出生日期"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "标本收到日期")});
            this.rdoDate.Size = new System.Drawing.Size(134, 65);
            this.rdoDate.TabIndex = 31;
            // 
            // deBegDate
            // 
            this.deBegDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deBegDate.EditValue = new System.DateTime(2014, 11, 8, 10, 48, 54, 0);
            this.deBegDate.Location = new System.Drawing.Point(255, 263);
            this.deBegDate.Name = "deBegDate";
            this.deBegDate.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deBegDate.Properties.Appearance.Options.UseFont = true;
            this.deBegDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deBegDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deBegDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deBegDate.Size = new System.Drawing.Size(95, 25);
            this.deBegDate.TabIndex = 33;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl2.Location = new System.Drawing.Point(370, 266);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(16, 16);
            this.labelControl2.TabIndex = 32;
            this.labelControl2.Text = "至";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Location = new System.Drawing.Point(437, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(132, 39);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "初检统计";
            // 
            // UCFirstStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "UCFirstStatistics";
            this.Size = new System.Drawing.Size(996, 587);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deReceivedEndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReceivedEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdoType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReceivedBegDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReceivedBegDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBegDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBegDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGoBack;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.RadioGroup rdoType;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.DateEdit deReceivedEndDate;
        private DevExpress.XtraEditors.DateEdit deReceivedBegDate;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit deEndDate;
        private DevExpress.XtraEditors.RadioGroup rdoDate;
        private DevExpress.XtraEditors.DateEdit deBegDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
