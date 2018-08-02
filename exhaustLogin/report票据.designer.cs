namespace exhaustLogin
{
    partial class report票据
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
            this.components = new System.ComponentModel.Container();
            this.已检车辆信息BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NEIMENG_VMASDataSet = new exhaustLogin.NEIMENG_VMASDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.已检车辆信息TableAdapter = new exhaustLogin.NEIMENG_VMASDataSetTableAdapters.已检车辆信息TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.已检车辆信息BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NEIMENG_VMASDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // 已检车辆信息BindingSource
            // 
            this.已检车辆信息BindingSource.DataMember = "已检车辆信息";
            this.已检车辆信息BindingSource.DataSource = this.NEIMENG_VMASDataSet;
            // 
            // NEIMENG_VMASDataSet
            // 
            this.NEIMENG_VMASDataSet.DataSetName = "NEIMENG_VMASDataSet";
            this.NEIMENG_VMASDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "exhaustLogin.票据.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(839, 466);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // 已检车辆信息TableAdapter
            // 
            this.已检车辆信息TableAdapter.ClearBeforeFill = true;
            // 
            // report票据
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 466);
            this.Controls.Add(this.reportViewer1);
            this.Name = "report票据";
            this.Text = "统计查询";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.reportView_panelFormClosing);
            this.Load += new System.EventHandler(this.reportView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.已检车辆信息BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NEIMENG_VMASDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource 已检车辆信息BindingSource;
        private NEIMENG_VMASDataSet NEIMENG_VMASDataSet;
        private NEIMENG_VMASDataSetTableAdapters.已检车辆信息TableAdapter 已检车辆信息TableAdapter;
    }
}