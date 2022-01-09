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
    public partial class frmPhieuNhapHang: Form
    {
        public frmPhieuNhapHang()
        {
            InitializeComponent();
        }
        LinhKien lk = new LinhKien();
        public string maLKTrungTrongListView;

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
            txtMaLK.Focus();
        }
        private void LamMoiPNH()
        {
            txtMaPNH.Text = "";
            cbbNhaCungCap.Text = "";
            txtSDTNhaCungCap.Text = "";
            txtDiaChiNCC.Text = "";
            cbbNhanVien.Text = "";
            txtSDTNhanVien.Text = "";
            txtDiaChiNV.Text = "";
            txtTongTien.Text = "";
            txtMaPNH.Focus();
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

        private void frmPhieuNhapHang_Load(object sender, EventArgs e)
        {
            btnXoaSP.Enabled = false;
            btnThanhToan.Enabled = false;
            loadDataNV();
            loadDataNCC();
        }
        double tinhTongTienTrongLV()
        {
            double tongtien = 0;
            for (int i = 0; i < lsvAccessories.Items.Count; i++)
            {
                double thanhtien = double.Parse(lsvAccessories.Items[i].SubItems[7].Text);
                tongtien += thanhtien;
            }
            return tongtien;
        }

        bool kiemTraTrungSPTrongListView(string maLK)
        {
            for (int i = 0; i < lsvAccessories.Items.Count; i++)
            {
                string maLKtem = lsvAccessories.Items[i].SubItems[0].Text.Trim();
                if (maLK.Trim().Equals(maLKtem))
                {
                    maLKTrungTrongListView = maLKtem;
                    return true;
                }
            }
            return false;
        }
        public bool kiemTraTrungMAPNH(string maHD)
        {
            DataTable dt = lk.LaymaPNH();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string maHDtemp = dt.Rows[i][0].ToString().Trim();
                if (maHD.Equals(maHDtemp))
                    return false;
            }
            return true;
        }

        bool kiemTraTTnhap()
        {
            if (txtMaLK.Text.Length < 3)
            {
                MessageBox.Show("Mã linh kiện không hợp lệ vui lòng kiểm tra lại!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLK.Focus();
                return false;
            }
            else if (txtMaPNH.Text.Length < 3)
            {
                MessageBox.Show("Mã phiếu nhập hàng không hợp lệ vui lòng kiểm tra lại!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLK.Focus();
                return false;
            }
            else if (txtMaLK.Text == "" || txtMaPNH.Text == "" || txtTenLK.Text == "" || txtLoaiLK.Text == "" || txtXuatXu.Text == "" || txtGiaBan.Text == "" || txtSL.Text == "" || txtBaoHanh.Text == "")
            {
                MessageBox.Show("Nhập thiếu thông tin vui lòng kiểm tra lại!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void cbbNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiDiaChiVaSDTnhaCungCap(cbbNhaCungCap.SelectedValue.ToString());
        }

        private void cbbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiDiaChiVaSDTnhanVien(cbbNhanVien.SelectedValue.ToString());
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lamMoiCTPNH();
            txtMaPNH.Text = "";
            txtTongTien.Text = "";
            txtMaPNH.Focus();
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {

            if (lsvAccessories.SelectedIndices.Count > 0)
            {
                DialogResult ret = MessageBox.Show("Bạn có chắn chắn xóa ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ret == DialogResult.Yes)
                    lsvAccessories.Items.Remove(lsvAccessories.Items[0]);
            }
            lamMoiCTPNH();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            btnXoaSP.Enabled = true;
            btnThanhToan.Enabled = true;
            txtThanhTien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            if (kiemTraTTnhap() == false)
            {
                return;
            }
            if (kiemTraTrungSPTrongListView(txtMaLK.Text) == true)
            {
                MessageBox.Show("Mã linh kiện đã tồn tại! Vui lòng chọn mã linh kiện mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLK.Focus();
            }
            else
            {
                int sl = int.Parse(txtSL.Text);
                double giaban = double.Parse(txtGiaBan.Text);
                double thanhtien = sl * giaban;

                ListViewItem lvi = lsvAccessories.Items.Add(txtMaLK.Text);
                lvi.SubItems.Add(txtLoaiLK.Text);
                lvi.SubItems.Add(txtTenLK.Text);
                lvi.SubItems.Add(txtXuatXu.Text);
                lvi.SubItems.Add(giaban.ToString());
                lvi.SubItems.Add(txtBaoHanh.Text);
                lvi.SubItems.Add(sl.ToString());
                lvi.SubItems.Add(thanhtien.ToString());
                double tongtien = tinhTongTienTrongLV();
                txtTongTien.Text = tongtien.ToString();
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
                string a = double.Parse(txtTongTien.Text).ToString("#,### VND", cul.NumberFormat);
                txtTongTien.Text = a;
                MessageBox.Show("Thêm mới thành công");
                lamMoiCTPNH();
            }
        }

        private void lsvAccessories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvAccessories.SelectedIndices.Count > 0)
            {
                txtMaLK.Text = lsvAccessories.SelectedItems[0].SubItems[0].Text;
                txtLoaiLK.Text = lsvAccessories.SelectedItems[0].SubItems[1].Text;
                txtTenLK.Text = lsvAccessories.SelectedItems[0].SubItems[2].Text;
                txtXuatXu.Text = lsvAccessories.SelectedItems[0].SubItems[3].Text;
                txtGiaBan.Text = lsvAccessories.SelectedItems[0].SubItems[4].Text;
                txtBaoHanh.Text = lsvAccessories.SelectedItems[0].SubItems[5].Text;
                txtSL.Text = lsvAccessories.SelectedItems[0].SubItems[6].Text;
                txtThanhTien.Text = lsvAccessories.SelectedItems[0].SubItems[7].Text;
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txtMaPNH.Text.Length < 3)
            {
                MessageBox.Show("Mã phiếu nhập hàng không hợp lệ vui lòng kiểm tra lại!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPNH.Focus();
            }
            else if (lsvAccessories.Items.Count <= 0 || txtMaLK.Text == "" || txtMaPNH.Text == "" || txtTenLK.Text == "" || txtLoaiLK.Text == "" || txtXuatXu.Text == "" || txtGiaBan.Text == "" || txtSL.Text == "" || txtBaoHanh.Text == "")
            {
                MessageBox.Show("Nhập thiếu thông tin vui lòng kiểm tra lại!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (kiemTraTrungMAPNH(txtMaPNH.Text) == false)
            {
                MessageBox.Show("Mã phiếu nhập hàng đã tồn tại !! Vui lòng chọn mã phiếu nhập hàng mới", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPNH.Focus();
            }
            else
            {
                int maNV = int.Parse(cbbNhanVien.SelectedValue.ToString());
                int maNCC = int.Parse(cbbNhaCungCap.SelectedValue.ToString());
                double tongtien = tinhTongTienTrongLV();
                string ngayXuatHD = String.Format("{0:MM/dd/yyyy}", dateLapPhieu.Value);
                string maPNH = txtMaPNH.Text.ToUpper().Trim();
                lk.themMoiPNH(maPNH, maNV, maNCC, ngayXuatHD, tongtien);
                for (int i = 0; i < lsvAccessories.Items.Count; i++)
                {
                    string maLK = lsvAccessories.Items[i].SubItems[0].Text.Trim();
                    string loaiLK = lsvAccessories.Items[i].SubItems[1].Text.Trim();
                    string tenLK = lsvAccessories.Items[i].SubItems[2].Text.Trim();
                    string xuatxu = lsvAccessories.Items[i].SubItems[3].Text.Trim();
                    double giaban = double.Parse(lsvAccessories.Items[i].SubItems[4].Text);
                    string baohanh = lsvAccessories.Items[i].SubItems[5].Text.Trim();
                    int soluong = int.Parse(lsvAccessories.Items[i].SubItems[6].Text);
                    double thanhTien = double.Parse(lsvAccessories.Items[i].SubItems[7].Text);
                    lk.themCTHDPhieuNH(maPNH, maLK, loaiLK, tenLK, xuatxu, giaban, baohanh, soluong, thanhTien);
                }
                lsvAccessories.Items.Clear();
                MessageBox.Show("Thanh Toán Thánh Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiPNH();
                lamMoiCTPNH();
                txtMaPNH.Focus();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            frmReportQuanlyLK s = new frmReportQuanlyLK();
            s.Show();
        }
    }
}
