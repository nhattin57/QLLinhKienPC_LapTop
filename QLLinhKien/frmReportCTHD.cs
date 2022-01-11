using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLLinhKien
{
    public partial class frmReportCTHD : Form
    {
        public frmReportCTHD()
        {
            InitializeComponent();
        }
        string maHD = frmBanHang.maHDToReport;
        private void frmReportCTHD_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetCTHD.TIMCTHDTheoMaHD' table. You can move, or remove it, as needed.
            this.TIMCTHDTheoMaHDTableAdapter.Fill(this.DataSetCTHD.TIMCTHDTheoMaHD,maHD);
           
            this.reportViewer1.RefreshReport();
        }
    }
}
