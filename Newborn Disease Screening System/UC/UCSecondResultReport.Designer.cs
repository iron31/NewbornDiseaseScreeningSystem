namespace Newborn_Disease_Screening_System.UC
{
    partial class UCSecondResultReport
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
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.gcFirstResultReport = new DevExpress.XtraGrid.GridControl();
            this.gvFirstResultReport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.print = new DevExpress.XtraGrid.Columns.GridColumn();
            this.print2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblReceiveDate = new DevExpress.XtraEditors.LabelControl();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl29 = new DevExpress.XtraEditors.LabelControl();
            this.lblG6PD1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl28 = new DevExpress.XtraEditors.LabelControl();
            this.lblSendDate = new DevExpress.XtraEditors.LabelControl();
            this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
            this.lblGender = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.lblPhe1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.lblTsh1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.lblOrganization = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.lblCardCode = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.lblHealthNo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lblMotherName = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.plReport = new System.Windows.Forms.Panel();
            this.ceCardNo = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtEndCardNo = new DevExpress.XtraEditors.TextEdit();
            this.btnGoBack = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintOne = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.txtBegCardNo = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFirstResultReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFirstResultReport)).BeginInit();
            this.plReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceCardNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndCardNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBegCardNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(392, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(203, 35);
            this.lblTitle.TabIndex = 169;
            this.lblTitle.Text = "复检筛查报告单";
            // 
            // gcFirstResultReport
            // 
            this.gcFirstResultReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcFirstResultReport.Location = new System.Drawing.Point(7, 67);
            this.gcFirstResultReport.MainView = this.gvFirstResultReport;
            this.gcFirstResultReport.Name = "gcFirstResultReport";
            this.gcFirstResultReport.Size = new System.Drawing.Size(981, 257);
            this.gcFirstResultReport.TabIndex = 136;
            this.gcFirstResultReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFirstResultReport});
            // 
            // gvFirstResultReport
            // 
            this.gvFirstResultReport.Appearance.FocusedRow.BackColor = System.Drawing.Color.Cyan;
            this.gvFirstResultReport.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvFirstResultReport.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.print,
            this.print2});
            this.gvFirstResultReport.GridControl = this.gcFirstResultReport;
            this.gvFirstResultReport.Name = "gvFirstResultReport";
            this.gvFirstResultReport.OptionsBehavior.Editable = false;
            this.gvFirstResultReport.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvFirstResultReport.OptionsView.ShowGroupPanel = false;
            this.gvFirstResultReport.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvFirstResultReport_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "卡号";
            this.gridColumn1.FieldName = "CARD_NO";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "TSH(uIU/ml)";
            this.gridColumn2.FieldName = "TSH";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "判断结果";
            this.gridColumn3.FieldName = "TSHRESULT";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Phe(mg/dl)";
            this.gridColumn4.FieldName = "PHE";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "判断结果";
            this.gridColumn5.FieldName = "PHERESULT";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "G6PD(U/gHb)";
            this.gridColumn6.FieldName = "G6PD";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "判断结果";
            this.gridColumn7.FieldName = "G6PDRESULT";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "采血时间";
            this.gridColumn8.FieldName = "GET_BLOOD_DATE";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // print
            // 
            this.print.Caption = "打印";
            this.print.FieldName = "PRINT";
            this.print.Name = "print";
            this.print.Visible = true;
            this.print.VisibleIndex = 8;
            // 
            // print2
            // 
            this.print2.Caption = "打印";
            this.print2.FieldName = "PRINT2";
            this.print2.Name = "print2";
            this.print2.Visible = true;
            this.print2.VisibleIndex = 9;
            // 
            // lblReceiveDate
            // 
            this.lblReceiveDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReceiveDate.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiveDate.Location = new System.Drawing.Point(123, 460);
            this.lblReceiveDate.Name = "lblReceiveDate";
            this.lblReceiveDate.Size = new System.Drawing.Size(0, 17);
            this.lblReceiveDate.TabIndex = 165;
            // 
            // labelControl21
            // 
            this.labelControl21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl21.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl21.Location = new System.Drawing.Point(25, 460);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(89, 17);
            this.labelControl21.TabIndex = 164;
            this.labelControl21.Text = "标本收到日期:";
            // 
            // labelControl29
            // 
            this.labelControl29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl29.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl29.Location = new System.Drawing.Point(440, 460);
            this.labelControl29.Name = "labelControl29";
            this.labelControl29.Size = new System.Drawing.Size(38, 17);
            this.labelControl29.TabIndex = 157;
            this.labelControl29.Text = "u/gHb";
            // 
            // lblG6PD1
            // 
            this.lblG6PD1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblG6PD1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblG6PD1.Location = new System.Drawing.Point(354, 460);
            this.lblG6PD1.Name = "lblG6PD1";
            this.lblG6PD1.Size = new System.Drawing.Size(0, 17);
            this.lblG6PD1.TabIndex = 156;
            // 
            // labelControl28
            // 
            this.labelControl28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl28.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl28.Location = new System.Drawing.Point(428, 418);
            this.labelControl28.Name = "labelControl28";
            this.labelControl28.Size = new System.Drawing.Size(40, 17);
            this.labelControl28.TabIndex = 155;
            this.labelControl28.Text = "uIU/ml";
            // 
            // lblSendDate
            // 
            this.lblSendDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSendDate.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSendDate.Location = new System.Drawing.Point(123, 424);
            this.lblSendDate.Name = "lblSendDate";
            this.lblSendDate.Size = new System.Drawing.Size(0, 17);
            this.lblSendDate.TabIndex = 154;
            // 
            // labelControl27
            // 
            this.labelControl27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl27.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl27.Location = new System.Drawing.Point(25, 424);
            this.labelControl27.Name = "labelControl27";
            this.labelControl27.Size = new System.Drawing.Size(89, 17);
            this.labelControl27.TabIndex = 153;
            this.labelControl27.Text = "标本寄出日期:";
            // 
            // lblGender
            // 
            this.lblGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGender.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(617, 388);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(0, 17);
            this.lblGender.TabIndex = 152;
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Location = new System.Drawing.Point(531, 388);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(75, 17);
            this.labelControl8.TabIndex = 151;
            this.labelControl8.Text = "新生儿性别:";
            // 
            // lblPhe1
            // 
            this.lblPhe1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPhe1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhe1.Location = new System.Drawing.Point(643, 418);
            this.lblPhe1.Name = "lblPhe1";
            this.lblPhe1.Size = new System.Drawing.Size(0, 17);
            this.lblPhe1.TabIndex = 150;
            // 
            // labelControl24
            // 
            this.labelControl24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl24.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl24.Location = new System.Drawing.Point(294, 460);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(48, 17);
            this.labelControl24.TabIndex = 149;
            this.labelControl24.Text = "G6PD1:";
            // 
            // labelControl14
            // 
            this.labelControl14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl14.Location = new System.Drawing.Point(691, 418);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(35, 17);
            this.labelControl14.TabIndex = 148;
            this.labelControl14.Text = "mg/dl";
            // 
            // labelControl15
            // 
            this.labelControl15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Location = new System.Drawing.Point(589, 418);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(36, 17);
            this.labelControl15.TabIndex = 147;
            this.labelControl15.Text = "Phe1:";
            // 
            // lblTsh1
            // 
            this.lblTsh1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTsh1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTsh1.Location = new System.Drawing.Point(365, 418);
            this.lblTsh1.Name = "lblTsh1";
            this.lblTsh1.Size = new System.Drawing.Size(0, 17);
            this.lblTsh1.TabIndex = 146;
            // 
            // labelControl11
            // 
            this.labelControl11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Location = new System.Drawing.Point(304, 418);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(38, 17);
            this.labelControl11.TabIndex = 145;
            this.labelControl11.Text = "TSH1:";
            // 
            // lblOrganization
            // 
            this.lblOrganization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrganization.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrganization.Location = new System.Drawing.Point(123, 388);
            this.lblOrganization.Name = "lblOrganization";
            this.lblOrganization.Size = new System.Drawing.Size(0, 17);
            this.lblOrganization.TabIndex = 144;
            // 
            // labelControl13
            // 
            this.labelControl13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Location = new System.Drawing.Point(53, 388);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(61, 17);
            this.labelControl13.TabIndex = 143;
            this.labelControl13.Text = "医疗机构:";
            // 
            // lblCardCode
            // 
            this.lblCardCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCardCode.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardCode.Location = new System.Drawing.Point(650, 460);
            this.lblCardCode.Name = "lblCardCode";
            this.lblCardCode.Size = new System.Drawing.Size(0, 17);
            this.lblCardCode.TabIndex = 142;
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Location = new System.Drawing.Point(564, 460);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(47, 17);
            this.labelControl9.TabIndex = 141;
            this.labelControl9.Text = "复检ID:";
            // 
            // lblHealthNo
            // 
            this.lblHealthNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHealthNo.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHealthNo.Location = new System.Drawing.Point(637, 352);
            this.lblHealthNo.Name = "lblHealthNo";
            this.lblHealthNo.Size = new System.Drawing.Size(0, 17);
            this.lblHealthNo.TabIndex = 140;
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Location = new System.Drawing.Point(559, 352);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(47, 17);
            this.labelControl7.TabIndex = 139;
            this.labelControl7.Text = "保健号:";
            // 
            // lblMotherName
            // 
            this.lblMotherName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMotherName.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotherName.Location = new System.Drawing.Point(123, 352);
            this.lblMotherName.Name = "lblMotherName";
            this.lblMotherName.Size = new System.Drawing.Size(0, 17);
            this.lblMotherName.TabIndex = 138;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(53, 352);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 17);
            this.labelControl4.TabIndex = 137;
            this.labelControl4.Text = "母亲姓名:";
            // 
            // plReport
            // 
            this.plReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.plReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plReport.Controls.Add(this.ceCardNo);
            this.plReport.Controls.Add(this.labelControl6);
            this.plReport.Controls.Add(this.txtEndCardNo);
            this.plReport.Controls.Add(this.btnGoBack);
            this.plReport.Controls.Add(this.btnPrintAll);
            this.plReport.Controls.Add(this.btnPrintOne);
            this.plReport.Controls.Add(this.btnQuery);
            this.plReport.Controls.Add(this.txtBegCardNo);
            this.plReport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plReport.Location = new System.Drawing.Point(0, 496);
            this.plReport.Name = "plReport";
            this.plReport.Size = new System.Drawing.Size(996, 90);
            this.plReport.TabIndex = 135;
            // 
            // ceCardNo
            // 
            this.ceCardNo.Location = new System.Drawing.Point(64, 39);
            this.ceCardNo.Name = "ceCardNo";
            this.ceCardNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ceCardNo.Properties.Appearance.Options.UseFont = true;
            this.ceCardNo.Properties.Caption = "卡号:";
            this.ceCardNo.Size = new System.Drawing.Size(58, 22);
            this.ceCardNo.TabIndex = 14;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Location = new System.Drawing.Point(262, 42);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(14, 17);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "至";
            // 
            // txtEndCardNo
            // 
            this.txtEndCardNo.Location = new System.Drawing.Point(296, 39);
            this.txtEndCardNo.Name = "txtEndCardNo";
            this.txtEndCardNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndCardNo.Properties.Appearance.Options.UseFont = true;
            this.txtEndCardNo.Size = new System.Drawing.Size(120, 23);
            this.txtEndCardNo.TabIndex = 11;
            // 
            // btnGoBack
            // 
            this.btnGoBack.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoBack.Appearance.Options.UseFont = true;
            this.btnGoBack.Location = new System.Drawing.Point(898, 35);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(85, 30);
            this.btnGoBack.TabIndex = 10;
            this.btnGoBack.Text = "返  回";
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintAll.Appearance.Options.UseFont = true;
            this.btnPrintAll.Location = new System.Drawing.Point(776, 35);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(85, 30);
            this.btnPrintAll.TabIndex = 9;
            this.btnPrintAll.Text = "全部打印";
            // 
            // btnPrintOne
            // 
            this.btnPrintOne.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintOne.Appearance.Options.UseFont = true;
            this.btnPrintOne.Location = new System.Drawing.Point(642, 35);
            this.btnPrintOne.Name = "btnPrintOne";
            this.btnPrintOne.Size = new System.Drawing.Size(85, 30);
            this.btnPrintOne.TabIndex = 8;
            this.btnPrintOne.Text = "单条打印";
            // 
            // btnQuery
            // 
            this.btnQuery.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuery.Appearance.Options.UseFont = true;
            this.btnQuery.Location = new System.Drawing.Point(492, 35);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(85, 30);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "查  询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtBegCardNo
            // 
            this.txtBegCardNo.Location = new System.Drawing.Point(122, 39);
            this.txtBegCardNo.Name = "txtBegCardNo";
            this.txtBegCardNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBegCardNo.Properties.Appearance.Options.UseFont = true;
            this.txtBegCardNo.Size = new System.Drawing.Size(120, 23);
            this.txtBegCardNo.TabIndex = 5;
            // 
            // UCSecondResultReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gcFirstResultReport);
            this.Controls.Add(this.lblReceiveDate);
            this.Controls.Add(this.labelControl21);
            this.Controls.Add(this.labelControl29);
            this.Controls.Add(this.lblG6PD1);
            this.Controls.Add(this.labelControl28);
            this.Controls.Add(this.lblSendDate);
            this.Controls.Add(this.labelControl27);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.lblPhe1);
            this.Controls.Add(this.labelControl24);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.lblTsh1);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.lblOrganization);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.lblCardCode);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.lblHealthNo);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.lblMotherName);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.plReport);
            this.Name = "UCSecondResultReport";
            this.Size = new System.Drawing.Size(996, 587);
            this.Load += new System.EventHandler(this.UCSecondResultReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcFirstResultReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFirstResultReport)).EndInit();
            this.plReport.ResumeLayout(false);
            this.plReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceCardNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndCardNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBegCardNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraGrid.GridControl gcFirstResultReport;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFirstResultReport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn print;
        private DevExpress.XtraGrid.Columns.GridColumn print2;
        private DevExpress.XtraEditors.LabelControl lblReceiveDate;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.LabelControl labelControl29;
        private DevExpress.XtraEditors.LabelControl lblG6PD1;
        private DevExpress.XtraEditors.LabelControl labelControl28;
        private DevExpress.XtraEditors.LabelControl lblSendDate;
        private DevExpress.XtraEditors.LabelControl labelControl27;
        private DevExpress.XtraEditors.LabelControl lblGender;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl lblPhe1;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl lblTsh1;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl lblOrganization;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl lblCardCode;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl lblHealthNo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl lblMotherName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.Panel plReport;
        private DevExpress.XtraEditors.CheckEdit ceCardNo;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtEndCardNo;
        private DevExpress.XtraEditors.SimpleButton btnGoBack;
        private DevExpress.XtraEditors.SimpleButton btnPrintAll;
        private DevExpress.XtraEditors.SimpleButton btnPrintOne;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.TextEdit txtBegCardNo;
    }
}
