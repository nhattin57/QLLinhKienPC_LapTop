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
        bool kiemTraNhanVienHopLe(string tennv)
        {
            DataTable dt = lk.layMaVaTenNV();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tenNVtemp = dt.Rows[i][1].ToString().Trim();
                if (tenNVtemp.Equals(tennv))
                    return true;
            }
            return false;
        }
        bool kiemTraKhachHangHopLe(string maKH)
        {
            DataTable dt = lk.layMaVaTenNV();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string maKHtemp = dt.Rows[i][1].ToString().Trim();
                if (maKHtemp.Equals(maKH))
                    return true;
            }
            return false;
        }
        bool kiemTraBanHang()
        {
    
            if(kiemTraKhachHangHopLe(cboKhachHang.Text)==true && kiemTraNhanVienHopLe(cboNhanVien.Text)==true)
                return true;
            return false;
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (lvSPDuocChon.Items.Count < 0 || cboKhachHang.Text == "" || cboNhanVien.Text == "" || txtMaHD.Text == "")
                MessageBox.Show("Vui Lòng chọn sản phẩm và Nhập đủ thông tin","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            else if (kiemTraBanHang() == false)
            {
                MessageBox.Show("Vui Lòng Chọn Khách Hàng Và Nhân Viên Hợp Lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

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
    }
}
