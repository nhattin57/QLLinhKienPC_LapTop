
namespace QLLinhKien
{
    partial class FrmReportKhachHang
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataKhachHang = new QLLinhKien.DataKhachHang();
            this.KHACHHANGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.KHACHHANGTableAdapter = new QLLinhKien.DataKhachHangTableAdapters.KHACHHANGTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KHACHHANGBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataKhachHang";
            reportDataSource1.Value = this.KHACHHANGBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLLinhKien.ReportKhachHang.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataKhachHang
            // 
            this.DataKhachHang.DataSetName = "DataKhachHang";
            this.DataKhachHang.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // KHACHHANGBindingSource
            // 
            this.KHACHHANGBindingSource.DataMember = "KHACHHANG";
            this.KHACHHANGBindingSource.DataSource = this.DataKhachHang;
            // 
            // KHACHHANGTableAdapter
            // 
            this.KHACHHANGTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReportKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReportKhachHang";
            this.Text = "FrmReportKhachHang";
            this.Load += new System.EventHandler(this.FrmReportKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KHACHHANGBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource KHACHHANGBindingSource;
        private DataKhachHang DataKhachHang;
        private DataKhachHangTableAdapters.KHACHHANGTableAdapter KHACHHANGTableAdapter;
    }
}