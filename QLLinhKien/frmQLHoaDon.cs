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
    public partial class frmQLHoaDon : Form
    {
        public frmQLHoaDon()
        {
            InitializeComponent();
        }
        LinhKien lk = new LinhKien();
         static bool themHoaDon;
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        void hienThiHoaDon()
        {
            DataTable dt = lk.layDSHoaDon();
            lsvHoaDon.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvHoaDon.Items.Add(dt.Rows[i][0].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][1].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][2].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][3].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][4].ToString().Trim());
            }
        }
        void hienThiCTHD()
        {
            DataTable dt = lk.layDSCTHD();
            lsvCTHD.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvCTHD.Items.Add(dt.Rows[i][0].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][1].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][2].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][3].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][4].ToString().Trim());
            }
        }
        void hienThiCBBNhanVien()
        {
            DataTable dt = lk.layMaVaTenNV();
            cboNhanVien.DataSource = dt;
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MANV";
        }
        void hienThiCBBKhachHang()
        {
            DataTable dt = lk.layMaVaTenKH();
            cboKhachHang.DataSource = dt;
            cboKhachHang.DisplayMember = "Hoten";
            cboKhachHang.ValueMember = "MaKhachHang";
        }
        
        void closeTextBox_CBB(bool e)
        {
            txtThanhTien.Enabled = !e;
            txtSoLuong.Enabled = !e;
            txtGiaBan.Enabled = !e;
            txtTongTien.Enabled = !e;
            cboKhachHang.Enabled = !e;
            txtTenLK.Enabled = !e;
            cboNhanVien.Enabled = !e;
            dtpNgayXuatHD.Enabled = !e;
        }
        void setNut(bool e)
        {
            btnSua.Enabled = e;
            btnXoa.Enabled = e;
            btnLuu.Enabled = !e;
            btnkoLuu.Enabled = !e;
        }
        private void frmQLHoaDon_Load(object sender, EventArgs e)
        {
            hienThiHoaDon();
           // hienThiCTHD();
            closeTextBox_CBB(true);
            setNut(true);
        }
        void hienThiCTHDTheoHoaDon(string maHD)
        {
            DataTable dt = lk.TimCTHDTheoMa(maHD);
            lsvCTHD.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvCTHD.Items.Add(dt.Rows[i][1].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][2].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][3].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][4].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][5].ToString().Trim());
            }
        }
        private void lsvHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvHoaDon.SelectedItems.Count; i++)
            {
                txtMaHoaDon.Text = lsvHoaDon.SelectedItems[i].SubItems[0].Text;
                cboKhachHang.Text= lsvHoaDon.SelectedItems[i].SubItems[1].Text;
                cboNhanVien.Text= lsvHoaDon.SelectedItems[i].SubItems[2].Text;
                dtpNgayXuatHD.Text= lsvHoaDon.SelectedItems[i].SubItems[3].Text;
                txtTongTien.Text= lsvHoaDon.SelectedItems[i].SubItems[4].Text;
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
                string a = double.Parse(txtTongTien.Text).ToString("#,### VND", cul.NumberFormat);
                txtTongTien.Text = a;
                hienThiCTHDTheoHoaDon(txtMaHoaDon.Text);
                txtThanhTien.Text = "";
                txtSoLuong.Text = "";
                txtGiaBan.Text = "";
                txtTenLK.Text = "";
                themHoaDon = true;
            }
        }

        private void lsvCTHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvCTHD.SelectedItems.Count; i++)
            {
                txtTenLK.Text = lsvCTHD.SelectedItems[i].SubItems[0].Text;
                txtGiaBan.Text = lsvCTHD.SelectedItems[i].SubItems[2].Text;
                txtSoLuong.Text= lsvCTHD.SelectedItems[i].SubItems[3].Text;
                txtThanhTien.Text= lsvCTHD.SelectedItems[i].SubItems[4].Text;
                themHoaDon = false;
            }
        }
        public bool kiemTraNhanVienHopLe(string tenNV)
        {
            DataTable dt = lk.layMaVaTenNV();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tenNVtemp = dt.Rows[i][1].ToString().Trim();
                if (tenNV.Equals(tenNVtemp))
                    return true;
            }
            return false;
        }
        public bool kiemTraKhachHangHopLe(string tenKH)
        {
            DataTable dt = lk.layMaVaTenKH();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tenKHtemp = dt.Rows[i][1].ToString().Trim();
                if (tenKH.Equals(tenKHtemp))
                    return true;
            }
            return false;
        }
        public bool kiemTraKHVaNVHopLe()
        {

            if (kiemTraKhachHangHopLe(cboKhachHang.Text) == true && kiemTraNhanVienHopLe(cboNhanVien.Text) == true)
                return true;
            return false;
        }
        bool kiemTraTenLinhKienHopLe(string tenLK)
        {
            DataTable dt = lk.layTenLK();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tenLKtem = dt.Rows[i][0].ToString().Trim();
                if (tenLK.Trim().Equals(tenLKtem))
                    return true;
            }
            return false;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lsvHoaDon.SelectedItems.Count < 1)
                MessageBox.Show("Vui Lòng Chọn Hóa Đơn Để Sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                hienThiCBBKhachHang();
                hienThiCBBNhanVien();
                setNut(false);
                closeTextBox_CBB(false);
            }
           
        }
        void hienThiHoaDonTheoMa(string maHD)
        {
            DataTable dt = lk.timHoaDonTheoMa(maHD);
            lsvHoaDon.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvHoaDon.Items.Add(dt.Rows[i][0].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][1].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][2].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][3].ToString().Trim());
                lvi.SubItems.Add(dt.Rows[i][4].ToString().Trim());
            }

        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            hienThiHoaDonTheoMa(txtTimKiem.Text);
        }
        void resetTextBox()
        {
            txtThanhTien.Text = "";
            txtSoLuong.Text = "";
            txtGiaBan.Text = "";
            txtTongTien.Text = "";
            cboKhachHang.Text = "";
            txtTenLK.Text = "";
            cboNhanVien.Text = "";
            dtpNgayXuatHD.Text = "";
        }
        private void btnkoLuu_Click(object sender, EventArgs e)
        {
            hienThiHoaDon();
            
            closeTextBox_CBB(true);
            setNut(true);
            resetTextBox();
        }
        double tongTienTuCTHD(string maHD)
        {
            double tongtien = 0;
            DataTable dt = lk.layThanhTienTuCTHD(maHD);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double thanhtien = double.Parse(dt.Rows[i][0].ToString());
                tongtien += thanhtien;
            }
            return tongtien;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kiemTraKHVaNVHopLe() == false)
                MessageBox.Show("Vui Lòng Chọn Khách Hàng Và Nhân Viên Hợp Lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (themHoaDon==true)
            {
                string maHD = txtMaHoaDon.Text.Trim();
                int maKH = int.Parse(cboKhachHang.SelectedValue.ToString());
                int maNV = int.Parse(cboNhanVien.SelectedValue.ToString());
                string ngayXuatHD = String.Format("{0:MM/dd/yyyy}", dtpNgayXuatHD.Value);
                lk.updateHOADON(maHD, maKH, maNV, ngayXuatHD);
                hienThiHoaDon();
                MessageBox.Show("Chỉnh sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (txtGiaBan.Text == "" || txtSoLuong.Text == "" || txtThanhTien.Text == "")
                    MessageBox.Show("Vui Lòng Nhập Đủ Thông Tin Để Sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    string maHD = txtMaHoaDon.Text.Trim();
                    string tenlk;
                    string maLK = lsvCTHD.SelectedItems[0].SubItems[1].Text.Trim();
                    int maKH = int.Parse(cboKhachHang.SelectedValue.ToString());
                    int maNV = int.Parse(cboNhanVien.SelectedValue.ToString());
                    string ngayXuatHD = String.Format("{0:MM/dd/yyyy}", dtpNgayXuatHD.Value);
                    double giaban = double.Parse(txtGiaBan.Text);
                    int sl = int.Parse(txtSoLuong.Text);
                    double thanhtien = double.Parse(txtThanhTien.Text);
                    lk.updateCTHD(maHD, maLK, giaban, sl, thanhtien);
                    double tongtien = tongTienTuCTHD(maHD);
                    lk.updateHOADONBeforeCTHD(maHD, maKH, maNV, ngayXuatHD, tongtien);
                    hienThiHoaDon();
                    hienThiCTHDTheoHoaDon(maHD);
                    MessageBox.Show("Chỉnh sửa Thành Công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtThanhTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvHoaDon.SelectedIndices.Count < 1)
                MessageBox.Show("Vui Lòng chọn Hóa Đơn Để Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if(lsvCTHD.SelectedIndices.Count>0)
                MessageBox.Show("Không thể xóa chi tiết hóa đơn bằng thao tác này, Muốn xóa chi tiết hóa đơn vui lòng nhấn đúp chuột vào bảng chi tiết hóa đơn",
                    "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DialogResult ret = MessageBox.Show("Bạn có chắn chắc muốn xóa hóa đơn này không?", "Thông Báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ret == DialogResult.Yes)
                {
                    string maHD = txtMaHoaDon.Text.Trim();
                    lk.deleteCTHD(maHD);
                    lk.deleteHoaDon(maHD);
                    MessageBox.Show("Xóa hóa đơn thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienThiHoaDon();
                    lsvCTHD.Items.Clear();
                }
                
            }
        }

        private void lsvCTHD_DoubleClick(object sender, EventArgs e)
        {
            DialogResult ret= MessageBox.Show("Bạn có chắn chắc muốn xóa chi tiết hóa đơn này không?", "Thông Báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                string maHD = txtMaHoaDon.Text;
                string maLK = lsvCTHD.SelectedItems[0].SubItems[1].Text.Trim();
                lk.deleteCTHDwhenDoubleClickonListView(maHD, maLK);
                double tongtien = tongTienTuCTHD(maHD);
                lk.updateHOADONwhendoubleClickonListView(maHD, tongtien);
                MessageBox.Show("Xóa chi tiết hóa đơn thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
                string a = double.Parse(tongtien.ToString()).ToString("#,### VND", cul.NumberFormat);
                txtTongTien.Text = a;
                hienThiCTHDTheoHoaDon(maHD);
                hienThiHoaDon();
            }
        }
    }
}
