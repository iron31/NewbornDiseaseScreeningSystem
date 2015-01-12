namespace Newborn_Disease_Screening_System.Forms
{
    partial class FormEditCardNo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtBegCardNo = new DevExpress.XtraEditors.TextEdit();
            this.txtCurrentCardNo = new DevExpress.XtraEditors.TextEdit();
            this.txtEndCardNo = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtBegCardNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentCardNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndCardNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(54, 47);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "起始号码:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(54, 96);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "当前号码:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(54, 145);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "结束号码:";
            // 
            // txtBegCardNo
            // 
            this.txtBegCardNo.Location = new System.Drawing.Point(135, 44);
            this.txtBegCardNo.Name = "txtBegCardNo";
            this.txtBegCardNo.Size = new System.Drawing.Size(120, 21);
            this.txtBegCardNo.TabIndex = 3;
            this.txtBegCardNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBegCardNo_KeyPress);
            // 
            // txtCurrentCardNo
            // 
            this.txtCurrentCardNo.Location = new System.Drawing.Point(135, 93);
            this.txtCurrentCardNo.Name = "txtCurrentCardNo";
            this.txtCurrentCardNo.Size = new System.Drawing.Size(120, 21);
            this.txtCurrentCardNo.TabIndex = 4;
            this.txtCurrentCardNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurrentCardNo_KeyPress);
            // 
            // txtEndCardNo
            // 
            this.txtEndCardNo.Location = new System.Drawing.Point(135, 142);
            this.txtEndCardNo.Name = "txtEndCardNo";
            this.txtEndCardNo.Size = new System.Drawing.Size(120, 21);
            this.txtEndCardNo.TabIndex = 5;
            this.txtEndCardNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEndCardNo_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(54, 202);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保  存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(180, 202);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "退  出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormEditCardNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 273);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtEndCardNo);
            this.Controls.Add(this.txtCurrentCardNo);
            this.Controls.Add(this.txtBegCardNo);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditCardNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "卡号段设置";
            this.Load += new System.EventHandler(this.FormEditCardNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtBegCardNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentCardNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndCardNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtBegCardNo;
        private DevExpress.XtraEditors.TextEdit txtCurrentCardNo;
        private DevExpress.XtraEditors.TextEdit txtEndCardNo;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnExit;
    }
}