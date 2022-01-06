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
    public partial class FrmReportNhanVien : Form
    {
        public FrmReportNhanVien()
        {
            InitializeComponent();
        }

        private void FrmReportNhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataNhanVien.NHANVIEN' table. You can move, or remove it, as needed.
            this.NHANVIENTableAdapter.Fill(this.DataNhanVien.NHANVIEN);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
