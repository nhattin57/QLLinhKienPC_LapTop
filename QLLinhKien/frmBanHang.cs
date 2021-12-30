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
    public partial class frmBanHang : Form
    {
        public frmBanHang()
        {
            InitializeComponent();
        }
        LinhKien lk = new LinhKien();
        public string TenLKCoSLKoDu;
        public int SL_LK;
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        void hienThiCBBKhachHang()
        {
            DataTable dt = lk.layMaVaTenKH();
            cboKhachHang.DataSource = dt;
            cboKhachHang.DisplayMember = "Hoten";
            cboKhachHang.ValueMember = "MaKhachHang";
        }
        void hienThiCBBNhanVien()
        {
            DataTable dt = lk.layMaVaTenNV();
            cboNhanVien.DataSource = dt;
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MANV";
        }
        void hienThiCBBLinhKien()
        {
            DataTable dt = lk.layMa_Ten_Gia_CuaLK();
            cboLinhKien.DataSource = dt;
            cboLinhKien.DisplayMember = "TenLinhKien";
            cboLinhKien.ValueMember = "TenLinhKien";
        }
        private void frmBanHang_Load(object sender, EventArgs e)
        {
            hienThiCBBKhachHang();
            hienThiCBBNhanVien();
            hienThiCBBLinhKien();
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        double tinhTongTienTrongLV()
        {
            double tongtien = 0;
            for (int i = 0; i < lvSPDuocChon.Items.Count; i++)
            {
                double thanhtien = double.Parse(lvSPDuocChon.Items[i].SubItems[4].Text);
                tongtien += thanhtien;
            }
            return tongtien;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
           
            if (txtSoLuong.Text == "" || txtGiaBan.Text == "" || cboLinhKien.Text == "")
            {
                MessageBox.Show("Vui Lòng Nhập đủ thông tin", "Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ListViewItem lvi = lvSPDuocChon.Items.Add(cboLinhKien.Text);
                lvi.SubItems.Add(txtMaLK.Text);
                lvi.SubItems.Add(txtGiaBan.Text);
                lvi.SubItems.Add(txtSoLuong.Text);
                int sl = int.Parse(txtSoLuong.Text);
                double giaban = double.Parse(txtGiaBan.Text);
                double thanhtien = sl * giaban;
                lvi.SubItems.Add(thanhtien.ToString());
                double tongtien = tinhTongTienTrongLV();
                txtTongTien.Text = tongtien.ToString();
               
            }
        }
        void hienThiThongTinLKKhiChon(string tenlk)
        {
            DataTable dt = lk.layMa_Ten_Gia_CuaLK();
            string tenlktemp;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tenlktemp = dt.Rows[i][1].ToString().Trim();
                if (tenlk.Equals(tenlktemp))
                {
                    txtMaLK.Text = dt.Rows[i][0].ToString();
                    txtGiaBan.Text = dt.Rows[i][2].ToString();
                }
            }
        }
        private void cboLinhKien_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienThiThongTinLKKhiChon(cboLinhKien.Text);
        }
        
        private void lvSPDuocChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSPDuocChon.SelectedIndices.Count > 0)
            {
                cboLinhKien.Text= lvSPDuocChon.SelectedItems[0].SubItems[0].Text;
                txtMaLK.Text = lvSPDuocChon.SelectedItems[0].SubItems[1].Text;
                txtGiaBan.Text= lvSPDuocChon.SelectedItems[0].SubItems[2].Text;
                txtSoLuong.Text= lvSPDuocChon.SelectedItems[0].SubItems[3].Text;
                txtThanhTien.Text= lvSPDuocChon.SelectedItems[0].SubItems[4].Text;
                
            }
        }

        private void lvSPDuocChon_DoubleClick(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có chắc chắn muốn xóa không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ret==DialogResult.Yes)
                lvSPDuocChon.Items.Remove(lvSPDuocChon.SelectedItems[0]); 
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            cboLinhKien.Text = "";
            txtGiaBan.Text = "";
            txtSoLuong.Text = "";
            txtMaLK.Text = "";
            cboLinhKien.Focus();
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
        public bool kiemTraBanHang()
        {
            
            if(kiemTraKhachHangHopLe(cboKhachHang.Text)==true && kiemTraNhanVienHopLe(cboNhanVien.Text)==true)
                return true;
            return false;
        }
        public bool kiemTraSoLuongLKDu()
        {
            DataTable dt = lk.layMa_Va_soLuongLK();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int SoLuongTon = int.Parse(dt.Rows[i][1].ToString());
                string maLK = dt.Rows[i][0].ToString().Trim();
                for (int j = 0; j < lvSPDuocChon.Items.Count; j++)
                {
                    string malkDuocChon = lvSPDuocChon.Items[j].SubItems[1].Text.Trim();
                    int SoLuongBan = int.Parse(lvSPDuocChon.Items[j].SubItems[3].Text);
                    if (maLK.Equals(malkDuocChon) && SoLuongBan > SoLuongTon)
                        { 
                            TenLKCoSLKoDu= lvSPDuocChon.Items[j].SubItems[0].Text;
                            SL_LK = SoLuongTon;
                            return false;
                        } 
                }
            }
            return true;
        }
        public bool kiemTraTrungMAHD(string maHD)
        {
            DataTable dt = lk.layMaHD();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string maHDtemp = dt.Rows[i][0].ToString().Trim();
                if (maHD.Equals(maHDtemp))
                    return false;
            }
            return true;
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (lvSPDuocChon.Items.Count <= 0 || cboKhachHang.Text == "" || cboNhanVien.Text == "" || txtMaHD.Text == "")
                MessageBox.Show("Vui Lòng chọn sản phẩm và Nhập đủ thông tin","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            else if (kiemTraBanHang() == false)
            {
                MessageBox.Show("Vui Lòng Chọn Khách Hàng Và Nhân Viên Hợp Lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(kiemTraSoLuongLKDu()==false)
            {
                MessageBox.Show(TenLKCoSLKoDu + " Có Số Lượng Tồn = " + SL_LK + " Không đủ bản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(kiemTraTrungMAHD(txtMaHD.Text)==false)
            {
                MessageBox.Show("Mã Hóa Đơn Đã Tồn Tại Vui Lòng Nhập Mã Hóa Đơn Khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int manv = int.Parse(cboNhanVien.SelectedValue.ToString());
                int maKH = int.Parse(cboKhachHang.SelectedValue.ToString());
                double tongtien = double.Parse(txtTongTien.Text);
                string ngayXuatHD = String.Format("{0:MM/dd/yyyy}", dtpNgayXuatHD.Value);
                string maHD = txtMaHD.Text.ToUpper().Trim();
                lk.themHoaDon(maHD, maKH, manv, ngayXuatHD, tongtien);
                for (int i = 0; i < lvSPDuocChon.Items.Count; i++)
                {
                    string maLK = lvSPDuocChon.Items[i].SubItems[1].Text.Trim();
                    string tenLK = lvSPDuocChon.Items[i].SubItems[0].Text;
                    double giaban= double.Parse(lvSPDuocChon.Items[i].SubItems[2].Text);
                    int soluong = int.Parse(lvSPDuocChon.Items[i].SubItems[3].Text);
                    double thanhTien = double.Parse(lvSPDuocChon.Items[i].SubItems[4].Text);
                    lk.themCTHD(maHD, maLK, tenLK, giaban, soluong, thanhTien);
                    lk.upDateSLLinhKien(soluong, maLK);
                }
                lvSPDuocChon.Items.Clear();
                txtMaHD.Text = "";
                txtSoLuong.Text = "";
                MessageBox.Show("Thanh Toán Thánh Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (lvSPDuocChon.SelectedIndices.Count > 0)
            {
               DialogResult ret= MessageBox.Show("Bạn có chắn chắn xóa ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(ret==DialogResult.Yes)
                lvSPDuocChon.Items.Remove(lvSPDuocChon.Items[0]);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtMaHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMaHD.Text.Length >9 && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
