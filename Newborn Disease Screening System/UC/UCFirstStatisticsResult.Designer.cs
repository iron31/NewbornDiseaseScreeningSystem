namespace Newborn_Disease_Screening_System.UC
{
    partial class UCFirstStatisticsResult
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel2 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel3 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.btnGoBack = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ccFirstStatistics = new DevExpress.XtraCharts.ChartControl();
            this.gcFirstStatistics = new DevExpress.XtraGrid.GridControl();
            this.gvFirstStatistics = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ccFirstStatistics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFirstStatistics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFirstStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGoBack
            // 
            this.btnGoBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoBack.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoBack.Appearance.Options.UseFont = true;
            this.btnGoBack.Location = new System.Drawing.Point(827, 508);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(85, 30);
            this.btnGoBack.TabIndex = 13;
            this.btnGoBack.Text = "返  回";
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.ccFirstStatistics);
            this.panelControl1.Controls.Add(this.gcFirstStatistics);
            this.panelControl1.Location = new System.Drawing.Point(3, 49);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(990, 429);
            this.panelControl1.TabIndex = 12;
            // 
            // ccFirstStatistics
            // 
            this.ccFirstStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            xyDiagram1.AxisX.Range.ScrollingRange.SideMarginsEnabled = true;
            xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Range.ScrollingRange.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.ccFirstStatistics.Diagram = xyDiagram1;
            this.ccFirstStatistics.Location = new System.Drawing.Point(541, 0);
            this.ccFirstStatistics.Name = "ccFirstStatistics";
            sideBySideBarSeriesLabel1.LineVisible = true;
            series1.Label = sideBySideBarSeriesLabel1;
            series1.Name = "Series 1";
            sideBySideBarSeriesLabel2.LineVisible = true;
            series2.Label = sideBySideBarSeriesLabel2;
            series2.Name = "Series 2";
            this.ccFirstStatistics.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            sideBySideBarSeriesLabel3.LineVisible = true;
            this.ccFirstStatistics.SeriesTemplate.Label = sideBySideBarSeriesLabel3;
            this.ccFirstStatistics.Size = new System.Drawing.Size(449, 429);
            this.ccFirstStatistics.TabIndex = 1;
            // 
            // gcFirstStatistics
            // 
            this.gcFirstStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode1.RelationName = "Level1";
            this.gcFirstStatistics.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcFirstStatistics.Location = new System.Drawing.Point(0, 0);
            this.gcFirstStatistics.MainView = this.gvFirstStatistics;
            this.gcFirstStatistics.Name = "gcFirstStatistics";
            this.gcFirstStatistics.Size = new System.Drawing.Size(542, 429);
            this.gcFirstStatistics.TabIndex = 0;
            this.gcFirstStatistics.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFirstStatistics});
            // 
            // gvFirstStatistics
            // 
            this.gvFirstStatistics.GridControl = this.gcFirstStatistics;
            this.gvFirstStatistics.Name = "gvFirstStatistics";
            this.gvFirstStatistics.OptionsView.ShowGroupPanel = false;
            this.gvFirstStatistics.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            this.gvFirstStatistics.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvFirstStatistics_FocusedRowChanged);
            // 
            // UCFirstStatisticsResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.panelControl1);
            this.Name = "UCFirstStatisticsResult";
            this.Size = new System.Drawing.Size(996, 587);
            this.Load += new System.EventHandler(this.UCFirstStatisticsResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccFirstStatistics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFirstStatistics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFirstStatistics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnGoBack;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraCharts.ChartControl ccFirstStatistics;
        private DevExpress.XtraGrid.GridControl gcFirstStatistics;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFirstStatistics;
    }
}
