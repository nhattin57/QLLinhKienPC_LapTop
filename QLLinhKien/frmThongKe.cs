using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
namespace QLLinhKien
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }
        LinhKien lk = new LinhKien();
        long tongDoanhThu;
        private void lsvHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public long TongDoanhThuHomNay()
        {
            tongDoanhThu = 0;
            long tongtien = 0;
            DataTable dt = lk.LayDSHoaDonChoDoanhThuHomNay();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tongtien = long.Parse(dt.Rows[i][4].ToString());
                tongDoanhThu += tongtien;
            }
            return tongDoanhThu;
        }

        void HienThiListViewHomNay()
        {
            lsvDoanhThu.Items.Clear();
            DataTable dt = lk.LayDSHoaDonChoDoanhThuHomNay();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi =

                lsvDoanhThu.Items.Add(dt.Rows[i][0].ToString());

                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
            }
        }

        private void btnDoanhthuHN_Click(object sender, EventArgs e)
        {
            HienThiListViewHomNay();
            long totalDoanhThuHomNay = TongDoanhThuHomNay();
            txtTongDoanhThu.Text = totalDoanhThuHomNay.ToString();
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            string a = double.Parse(txtTongDoanhThu.Text).ToString("#,### VND", cul.NumberFormat);
            txtTongDoanhThu.Text = a;
        }

        void HienThiListViewTungayDenNgay()
        {
            string tuNgay = String.Format("{0:MM/dd/yyyy}", dtpTuNgay.Value);
            string denNgay = String.Format("{0:MM/dd/yyyy}", dtpDenNgay.Value);
            lsvDoanhThu.Items.Clear();
            DataTable dt = lk.LayDSHoaDonChoDoanhThuTuNgayDenNgay(tuNgay, denNgay);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi =

                lsvDoanhThu.Items.Add(dt.Rows[i][0].ToString());

                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
            }
        }

        public long TongDoanhThuTungayDenNgay()
        {
            string tuNgay = String.Format("{0:MM/dd/yyyy}", dtpTuNgay.Value);
            string denNgay = String.Format("{0:MM/dd/yyyy}", dtpDenNgay.Value);
            tongDoanhThu = 0;
            long tongtien = 0;
            DataTable dt = lk.LayDSHoaDonChoDoanhThuTuNgayDenNgay(tuNgay, denNgay);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tongtien = long.Parse(dt.Rows[i][4].ToString());
                tongDoanhThu += tongtien;
            }
            return tongDoanhThu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HienThiListViewTungayDenNgay();
            long totalDoanhThu = TongDoanhThuTungayDenNgay();
            txtTongDoanhThu.Text = totalDoanhThu.ToString();
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            string a = double.Parse(txtTongDoanhThu.Text).ToString("#,### VND", cul.NumberFormat);
            txtTongDoanhThu.Text = a;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
            int i = 1;
            int i2 = 1;
            foreach (ListViewItem lvi in lsvDoanhThu.Items)
            {
                i = 1;
                foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                {
                    ws.Cells[i2, i] = lvs.Text;
                    i++;
                }
                i2++;
            }
        }
    }
}
