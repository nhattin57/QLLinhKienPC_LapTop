
namespace QLLinhKien
{
    partial class FrmReportNhanVien
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
            this.DataNhanVien = new QLLinhKien.DataNhanVien();
            this.NHANVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NHANVIENTableAdapter = new QLLinhKien.DataNhanVienTableAdapters.NHANVIENTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NHANVIENBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataNhanVien";
            reportDataSource1.Value = this.NHANVIENBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLLinhKien.ReportNhanVien.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1114, 575);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // DataNhanVien
            // 
            this.DataNhanVien.DataSetName = "DataNhanVien";
            this.DataNhanVien.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // NHANVIENBindingSource
            // 
            this.NHANVIENBindingSource.DataMember = "NHANVIEN";
            this.NHANVIENBindingSource.DataSource = this.DataNhanVien;
            // 
            // NHANVIENTableAdapter
            // 
            this.NHANVIENTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReportNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 575);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReportNhanVien";
            this.Text = "FrmReportNhanVien";
            this.Load += new System.EventHandler(this.FrmReportNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NHANVIENBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource NHANVIENBindingSource;
        private DataNhanVien DataNhanVien;
        private DataNhanVienTableAdapters.NHANVIENTableAdapter NHANVIENTableAdapter;
    }
}