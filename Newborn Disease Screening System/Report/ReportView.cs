using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraReports.UI;

namespace Newborn_Disease_Screening_System.Report
{
    public partial class ReportView : UserControl
    {
        /// <summary>
        /// 报表查看器
        /// </summary>
        public ReportView()
        {
            InitializeComponent();

            System.Drawing.Printing.PrinterSettings ps = new System.Drawing.Printing.PrinterSettings();
            foreach (System.Drawing.Printing.PaperSize pSize in ps.PaperSizes)
            {
                DevExpress.XtraEditors.Controls.ImageComboBoxItem icb = new DevExpress.XtraEditors.Controls.ImageComboBoxItem();
                icb.Description = pSize.PaperName;
                icb.Value = pSize;
                boxPaperSize.Items.Add(icb);
            }
        }

        private XtraReport report = new XtraReport();
        /// <summary>
        /// 要显示的报表
        /// </summary>
        [Category("报表"), Description("要显示的报表")]
        public XtraReport Report
        {
            get { return report; }
            set
            {
                report = value;
                if (report == null) return;

                ReportControl.PrintingSystem = report.PrintingSystem;
                ReportControl.PrintingSystem.ShowMarginsWarning = false;
                report.CreateDocument();
            }
        }

        /// <summary>
        /// 预览工具栏
        /// </summary>
        [Category("报表"), Description("预览工具栏")]
        public bool PreviewBarVisible
        {
            get { return this.previewBarTool.Visible; }
            set
            {
                this.previewBarTool.Visible = value;
            }
        }
        /// <summary>
        /// 显示报表
        /// </summary>
        /// <param name="xReport"></param>
        public void ShowReport(XtraReport xReport)
        {
            ShowReport(xReport, null);
        }
        /// <summary>
        /// 显示报表
        /// </summary>
        /// <param name="xReport">报表</param>
        /// <param name="pSize">纸张大小</param>
        public void ShowReport(XtraReport xReport, System.Drawing.Printing.PaperSize pSize)
        {
            using (System.Windows.Forms.Form frmBase = new System.Windows.Forms.Form())
            {
                frmBase.Text = "报表预览";
                frmBase.StartPosition = FormStartPosition.CenterScreen;
                frmBase.WindowState = FormWindowState.Maximized;
                this.PreviewBarVisible = true;
                SetPaperSize(xReport, pSize);
                this.Report = xReport;
                this.Parent = frmBase;
                this.Dock = DockStyle.Fill;
                frmBase.ShowDialog();
            }
        }

        private void boxPaper_EditValueChanged(object sender, EventArgs e)
        {
            if (this.report == null) return;
            System.Drawing.Printing.PaperSize ps = boxPaper.EditValue as System.Drawing.Printing.PaperSize;
            SetPaperSize(this.report, ps);
            report.CreateDocument();
        }

        private void SetPaperSize(XtraReport xReport, System.Drawing.Printing.PaperSize ps)
        {
            if (ps == null) return;
            xReport.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            xReport.PageWidth = ps.Width;
            xReport.PageHeight = ps.Height;
        }

        private void ReportControl_SelectedPageChanged(object sender, PageEventArgs e)
        {
            staticItemCurrentPageNo.Caption = String.Format("第  {0}  页", (this.ReportControl.SelectedPageIndex + 1).ToString());
            staticItemTotalPageNo.Caption = String.Format("共  {0}  页", this.report.Pages.Count.ToString());
        }
    }
}
