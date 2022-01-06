using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLLinhKien.model;
namespace QLLinhKien
{
    public partial class FrmNhanVien : Form
    {
        private int maNV = 0;
        public FrmNhanVien()
        {
            InitializeComponent();
            TaiDanhSachNhanVien();
        }
        private void TaiDanhSachNhanVien()
        {
            List<NHANVIEN> danhSachNhanVien;
            using (var dbcontext = new DataQLLK())
            {
                danhSachNhanVien = dbcontext.NHANVIENs.ToList();
            }
            int STT = 1;
            dgvNhanVien.Rows.Clear();
            if (danhSachNhanVien.Count <= 0) return;
            foreach (var nv in danhSachNhanVien)
            {
                int indexRow = dgvNhanVien.Rows.Add();
                dgvNhanVien.Rows[indexRow].Cells[0].Value = STT++;
                dgvNhanVien.Rows[indexRow].Cells[1].Value = nv.MANV;
                dgvNhanVien.Rows[indexRow].Cells[2].Value = nv.HoTen;
                dgvNhanVien.Rows[indexRow].Cells[3].Value = nv.SDT;
                dgvNhanVien.Rows[indexRow].Cells[4].Value = nv.NamSinh;
                dgvNhanVien.Rows[indexRow].Cells[5].Value = nv.GioiTinh;
                dgvNhanVien.Rows[indexRow].Cells[6].Value = nv.DiaCHi;
                dgvNhanVien.Rows[indexRow].Cells[7].Value = nv.MaChucVu;
                dgvNhanVien.Rows[indexRow].Cells[8].Value = nv.TaiKhoan;
                dgvNhanVien.Rows[indexRow].Cells[9].Value = nv.MatKhau;
            }
            dgvNhanVien.Rows[0].Selected = false;

        }
        private void loadform()
        {
            txtMaNV.Clear();
            txtHoten.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtHoten.Focus();

        }
        private void loadDGV()
        {
            using (var context = new DataQLLK())
            {
                List<NHANVIEN> listkhachhang = context.NHANVIENs.ToList();
                TaiDanhSachNhanVien();
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var nv = new NHANVIEN();
            //nv.MANV = Convert.ToInt32(txtMaNV.Text);
            nv.HoTen = txtHoten.Text;
            nv.SDT = txtSDT.Text;
            nv.NamSinh = DateTime.Parse(dateTimePicker1.Text);
            nv.GioiTinh = cbbGioiTinh.Text;
            nv.DiaCHi = txtDiaChi.Text;
            nv.MaChucVu = cbbMaCV.Text;
            nv.TaiKhoan = txtTaiKhoan.Text;
            nv.MatKhau = txtMatKhau.Text;


            try
            {
                using (var dbcontext = new DataQLLK())
                {
                    dbcontext.NHANVIENs.Add(nv);
                    dbcontext.SaveChanges();// done
                }

                TaiDanhSachNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn thoát ???", " thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dbcontext = new DataQLLK())
                {
                    int manv = int.Parse(txtMaNV.Text);
                    var updatenv = dbcontext.NHANVIENs.Where(s => s.MANV == manv).SingleOrDefault();

                    if (updatenv == null)
                    {
                        MessageBox.Show("Không cập nhật được !!!!");
                        return;
                    }

                    var nv = dbcontext.NHANVIENs.Where(s => s.MANV == manv).SingleOrDefault();

                    nv.HoTen = txtHoten.Text;
                    nv.SDT = txtSDT.Text;
                    nv.NamSinh = DateTime.Parse(dateTimePicker1.Text);
                    nv.GioiTinh = cbbGioiTinh.Text;
                    nv.DiaCHi = txtDiaChi.Text;
                    nv.MaChucVu = cbbMaCV.Text;
                    nv.TaiKhoan = txtTaiKhoan.Text;
                    nv.MatKhau = txtMatKhau.Text;
                    dbcontext.SaveChanges();
                    MessageBox.Show("Cập nhật thành công !!!!");
                }

                TaiDanhSachNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (var context = new DataQLLK())
            {
                int manv = int.Parse(txtMaNV.Text);
                var deletenv = context.NHANVIENs.Where(s => s.MANV == manv).SingleOrDefault();

                if (deletenv != null)
                {
                    DialogResult result = MessageBox.Show($"Bạn có đồng ý xóa nhân viên {deletenv.MANV} không ?", "Thông báo cho bạn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        context.NHANVIENs.Remove(deletenv);
                        context.SaveChanges();

                        loadform();
                        loadDGV();

                        MessageBox.Show($"Xóa nhân viên {deletenv.MANV} thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show($"Xóa nhân viên không thành công", "Thông báo", MessageBoxButtons.OK);

                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            {
                if (e.RowIndex == -1) return;
                if (dgvNhanVien.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) return;

                dgvNhanVien.CurrentRow.Selected = true;

                txtMaNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txtHoten.Text = dgvNhanVien.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtSDT.Text = dgvNhanVien.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                cbbGioiTinh.Text = dgvNhanVien.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                dateTimePicker1.Text = dgvNhanVien.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                txtDiaChi.Text = dgvNhanVien.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                cbbMaCV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
                txtTaiKhoan.Text = dgvNhanVien.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();
                txtMatKhau.Text = dgvNhanVien.Rows[e.RowIndex].Cells[9].FormattedValue.ToString();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            FrmReportNhanVien frm = new FrmReportNhanVien();
            frm.ShowDialog();
        }
    }
}
