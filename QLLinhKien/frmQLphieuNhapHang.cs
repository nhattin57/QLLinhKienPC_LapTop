using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLLinhKien
{
    public partial class frmQLphieuNhapHang : Form
    {
        public frmQLphieuNhapHang()
        {
            InitializeComponent();
        }
        LinhKien lk = new LinhKien();
        static bool themHoaDon;

        void setNut(bool e)
        {
            btnSua.Enabled = e;
            btnXoa.Enabled = e;
            btnNoSave.Enabled = !e;
            btnSave.Enabled = !e;
        }
        private bool CheckThongTinPNH()
        {
            if (txtMaPNH.Text == "" || cbbNhaCungCap.SelectedValue.ToString() == "" || cbbNhanVien.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Nhập thiếu thông tin !!! Vui lòng kiểm tra lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtMaPNH.Text.Length < 3)
            {
                MessageBox.Show("Mã hóa đơn không hợp lê", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void viewCTPNHTheoMa(string maPNH)
        {
            DataTable dt = lk.TimCTPNHTheoMaPNH(maPNH);
            lsvAccessories.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvAccessories.Items.Add(dt.Rows[i][0].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][1].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][2].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][3].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][5].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][4].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][6].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][7].ToString().Trim());
                // lvi.SubItems.Add(dt.Rows[i][8].ToString().Trim());
            }
        }

        private void loadDataPNH()
        {
            DataTable dt = lk.loadDataPNH();
            lsvReceipt.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvReceipt.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][2].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][3].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][4].ToString().Trim());

            }
        }
        private void loadDataNV()
        {
            DataTable dt = lk.layMaVaTenNV();
            cbbNhanVien.DataSource = dt;
            cbbNhanVien.DisplayMember = "HoTen";
            cbbNhanVien.ValueMember = "MANV";
        }

        private void loadDataNCC()
        {
            DataTable dt = lk.layMavaTenNCC();
            cbbNhaCungCap.DataSource = dt;
            cbbNhaCungCap.DisplayMember = "TenNCC";
            cbbNhaCungCap.ValueMember = "MaNCC";
        }

        private void LamMoiPNH()
        {
            txtMaPNH.Text = "";
            txtSDTNhaCungCap.Text = "";
            txtDiaChiNCC.Text = "";
            txtSDTNhanVien.Text = "";
            txtDiaChiNV.Text = "";
        }

        private void lamMoiCTPNH()
        {
            txtMaLK.Text = "";
            txtTenLK.Text = "";
            txtLoaiLK.Text = "";
            txtBaoHanh.Text = "";
            txtXuatXu.Text = "";
            txtGiaBan.Text = "";
            txtSL.Text = "";
            txtThanhTien.Text = "";
        }
        private void frmQLphieuNhapHang_Load(object sender, EventArgs e)
        {

            loadDataPNH();
            loadDataNCC();
            loadDataNV();
            setNut(true);
        }

        private void lsvReceipt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < lsvReceipt.SelectedItems.Count; i++)
                {
                    txtMaPNH.Text = lsvReceipt.SelectedItems[i].SubItems[0].Text;
                    cbbNhaCungCap.Text = lsvReceipt.SelectedItems[i].SubItems[1].Text;
                    cbbNhanVien.Text = lsvReceipt.SelectedItems[i].SubItems[2].Text;
                    dateLapPhieu.Text = lsvReceipt.SelectedItems[i].SubItems[3].Text;
                    txtTongTien.Text = lsvReceipt.SelectedItems[i].SubItems[4].Text;
                    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
                    string a = double.Parse(txtTongTien.Text).ToString("#,### VND", cul.NumberFormat);
                    txtTongTien.Text = a;
                    viewCTPNHTheoMa(txtMaPNH.Text);
                    lamMoiCTPNH();
                    // themHoaDon = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void lsvAccessories_SelectedIndexChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < lsvAccessories.SelectedItems.Count; i++)
            {
                txtMaLK.Text = lsvAccessories.SelectedItems[i].SubItems[0].Text;
                txtLoaiLK.Text = lsvAccessories.SelectedItems[i].SubItems[1].Text;
                txtTenLK.Text = lsvAccessories.SelectedItems[i].SubItems[2].Text;
                txtXuatXu.Text = lsvAccessories.SelectedItems[i].SubItems[3].Text;
                txtGiaBan.Text = lsvAccessories.SelectedItems[i].SubItems[5].Text;
                txtBaoHanh.Text = lsvAccessories.SelectedItems[i].SubItems[4].Text;
                txtSL.Text = lsvAccessories.SelectedItems[i].SubItems[6].Text;
                txtThanhTien.Text = lsvAccessories.SelectedItems[i].SubItems[7].Text;
                // themHoaDon = false;
            }
        }
        void HienThiDiaChiVaSDTnhanVien(string maNV)
        {
            DataTable dt = lk.layTTNhanVien();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == maNV)
                {
                    txtSDTNhanVien.Text = dt.Rows[i]["SDT"].ToString();
                    txtDiaChiNV.Text = dt.Rows[i]["DiaChi"].ToString();
                }
            }
        }

        void HienThiDiaChiVaSDTnhaCungCap(string maNCC)
        {
            DataTable dt = lk.layTTNhaCungCap();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == maNCC)
                {
                    txtSDTNhaCungCap.Text = dt.Rows[i]["SDT"].ToString();
                    txtDiaChiNCC.Text = dt.Rows[i]["DiaChi"].ToString();
                }
            }
        }

        private void cbbNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiDiaChiVaSDTnhaCungCap(cbbNhaCungCap.SelectedValue.ToString());
        }

        private void cbbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiDiaChiVaSDTnhanVien(cbbNhanVien.SelectedValue.ToString());
        }
        private double tinhTongTienCTPNH(string maPNH)
        {
            double tongtien = 0;
            DataTable dt = lk.layThanhTienTuCTPhieunhaphang(maPNH);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double thanhtien = double.Parse(dt.Rows[i][0].ToString());
                tongtien += thanhtien;
            }
            return tongtien;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (lsvReceipt.SelectedItems.Count < 1)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần sửa");
            }
            else
            {
                txtMaLK.ReadOnly = true;
                txtMaPNH.ReadOnly = true;
                setNut(false);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (lsvReceipt.SelectedIndices.Count < 1)
                MessageBox.Show("Vui Lòng chọn Phiếu Nhập Hàng Để Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (lsvAccessories.SelectedIndices.Count > 0)
                MessageBox.Show("Không thể xóa chi tiết hóa đơn bằng thao tác này, Muốn xóa chi tiết hóa đơn vui lòng nhấn đúp chuột vào bảng chi tiết phiếu nhập linh kiện",
                    "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DialogResult ret = MessageBox.Show("Bạn có chắn chắc muốn xóa hóa đơn này không?", "Thông Báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ret == DialogResult.Yes)
                {
                    string maPNH = txtMaPNH.Text.Trim();
                    lk.deleteCTPNH(maPNH);
                    lk.deletePhieuNH(maPNH);
                    MessageBox.Show("Xóa hóa đơn thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDataPNH();
                    lsvAccessories.Items.Clear();
                }

            }
        }

        private void lsvAccessories_DoubleClick(object sender, EventArgs e)
        {

            DialogResult ret = MessageBox.Show("Bạn có chắn chắc muốn xóa chi tiết hóa đơn này không?", "Thông Báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                string maPNH = txtMaPNH.Text;
                string maLK = lsvAccessories.SelectedItems[0].SubItems[0].Text.Trim();
                lk.deleteCTPNHwhenDoubleClickonListView(maPNH, maLK);
                double tongtien = tinhTongTienCTPNH(maPNH);
                lk.updatePNHwhendoubleClickonListView(maPNH, tongtien);
                MessageBox.Show("Xóa chi tiết hóa đơn thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
                string a = double.Parse(tongtien.ToString()).ToString("#,### VND", cul.NumberFormat);
                txtTongTien.Text = a;
                lamMoiCTPNH();
                viewCTPNHTheoMa(maPNH);
                loadDataPNH();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                txtThanhTien.ReadOnly = true;
                txtTongTien.ReadOnly = true;
                if (themHoaDon == true)
                {
                    string maPNH = txtMaPNH.Text.Trim();
                    int maNCC = int.Parse(cbbNhaCungCap.SelectedValue.ToString());
                    int maNV = int.Parse(cbbNhanVien.SelectedValue.ToString());
                    string ngayXuatHD = String.Format("{0:MM/dd/yyyy}", dateLapPhieu.Value);
                    lk.updatePhieuNhapHang(maPNH, maNCC, maNV, ngayXuatHD);
                    loadDataPNH();
                    LamMoiPNH();
                    lamMoiCTPNH();
                    MessageBox.Show("Chỉnh sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTongTien.Text = "0";
                    setNut(true);
                }
                else
                {
                    if (txtGiaBan.Text == "" || txtSL.Text == "")
                        MessageBox.Show("Vui Lòng Nhập Đủ Thông Tin Để Sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        string maPNH = txtMaPNH.Text.Trim();
                        int maNCC = int.Parse(cbbNhaCungCap.SelectedValue.ToString());
                        int maNV = int.Parse(cbbNhanVien.SelectedValue.ToString());
                        string ngayXuatHD = String.Format("{0:MM/dd/yyyy}", dateLapPhieu.Value);
                        string maLK = lsvAccessories.SelectedItems[0].SubItems[0].Text.Trim();
                        double giaban = double.Parse(txtGiaBan.Text);
                        int sl = int.Parse(txtSL.Text);

                        double thanhtien = sl * giaban;

                        string loailk = txtLoaiLK.Text;
                        string tenlk = txtTenLK.Text;
                        string baohanh = txtBaoHanh.Text;
                        string xuatxu = txtXuatXu.Text;
                        lk.updateCTPhieuNhapHang(maPNH, maLK, loailk, tenlk, xuatxu, giaban, baohanh, sl, thanhtien);

                        double tongtien = tinhTongTienCTPNH(maPNH);

                        txtTongTien.Text = tongtien.ToString();

                        lk.updateHOADONBeforeCTHDphieuNhaphang(maPNH, maNCC, maNV, ngayXuatHD, tongtien);

                        loadDataPNH();
                        viewCTPNHTheoMa(maPNH);
                        MessageBox.Show("Chỉnh sửa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LamMoiPNH();
                        lamMoiCTPNH();
                        txtTongTien.Text = "0";
                        setNut(true);
                    }

                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
                throw;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập thông tin tim kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSearch.Focus();
                }
                else
                {
                    DataTable dt = lk.timPNHtheoMa(txtSearch.Text);
                    lsvReceipt.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem lvi = lsvReceipt.Items.Add(dt.Rows[i][0].ToString());
                        lvi.SubItems.Add(dt.Rows[i][1].ToString());
                        lvi.SubItems.Add(dt.Rows[i][2].ToString());
                        lvi.SubItems.Add(dt.Rows[i][3].ToString());
                        lvi.SubItems.Add(dt.Rows[i][4].ToString());
                    }
                    MessageBox.Show($"Tìm thấy phiếu nhập hàng có mã:{txtSearch.Text}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }

        private void btnNoSave_Click(object sender, EventArgs e)
        {

            loadDataPNH();
            setNut(true);
            lamMoiCTPNH();
            LamMoiPNH();
            txtSearch.Focus();
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
            int i = 1;
            int i2 = 1;
            foreach (ListViewItem lvi in lsvReceipt.Items)
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
