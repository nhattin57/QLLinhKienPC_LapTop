
namespace QLLinhKien
{
    partial class frmReportCTHD
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
            this.DataSetCTHD = new QLLinhKien.DataSetCTHD();
            this.TIMCTHDTheoMaHDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TIMCTHDTheoMaHDTableAdapter = new QLLinhKien.DataSetCTHDTableAdapters.TIMCTHDTheoMaHDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetCTHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIMCTHDTheoMaHDBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetCTHD";
            reportDataSource1.Value = this.TIMCTHDTheoMaHDBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLLinhKien.ReportCTHD.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1002, 504);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSetCTHD
            // 
            this.DataSetCTHD.DataSetName = "DataSetCTHD";
            this.DataSetCTHD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TIMCTHDTheoMaHDBindingSource
            // 
            this.TIMCTHDTheoMaHDBindingSource.DataMember = "TIMCTHDTheoMaHD";
            this.TIMCTHDTheoMaHDBindingSource.DataSource = this.DataSetCTHD;
            // 
            // TIMCTHDTheoMaHDTableAdapter
            // 
            this.TIMCTHDTheoMaHDTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportCTHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 504);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReportCTHD";
            this.Text = "frmReportCTHD";
            this.Load += new System.EventHandler(this.frmReportCTHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetCTHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIMCTHDTheoMaHDBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource TIMCTHDTheoMaHDBindingSource;
        private DataSetCTHD DataSetCTHD;
        private DataSetCTHDTableAdapters.TIMCTHDTheoMaHDTableAdapter TIMCTHDTheoMaHDTableAdapter;
    }
}