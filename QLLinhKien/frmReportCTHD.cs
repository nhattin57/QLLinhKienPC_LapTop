using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace QLLinhKien
{
    public partial class frmReportCTHD : Form
    {
        public frmReportCTHD()
        {
            InitializeComponent();
        }
        string maHD = frmBanHang.maHDToReport;
        string TenKH = frmBanHang.tenKHToReport;
        string TenNV = frmBanHang.tenNVToReport;
        private void frmReportCTHD_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetCTHD.TIMCTHDTheoMaHD' table. You can move, or remove it, as needed.
            this.TIMCTHDTheoMaHDTableAdapter.Fill(this.DataSetCTHD.TIMCTHDTheoMaHD,maHD);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("tenNV", TenNV));
            reportParameters.Add(new ReportParameter("tenKH", TenKH));
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
