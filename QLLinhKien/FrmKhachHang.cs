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
    public partial class FrmKhachHang : Form
    {
        private int maKH = 0;
        public FrmKhachHang()
        {
            InitializeComponent();
            TaiDanhSachKhachHang();
        }
        private void TaiDanhSachKhachHang()
        {
            List<KHACHHANG> danhSachKhachHang;
            using (var dbcontext = new DataQLLK())
            {
                danhSachKhachHang = dbcontext.KHACHHANGs.ToList();
            }
            int STT = 1;
            dgvkhachhang.Rows.Clear();
            if (danhSachKhachHang.Count <= 0) return;
            foreach (var nv in danhSachKhachHang)
            {
                int indexRow = dgvkhachhang.Rows.Add();
                dgvkhachhang.Rows[indexRow].Cells[0].Value = STT++;
                dgvkhachhang.Rows[indexRow].Cells[1].Value = nv.MaKhachHang;
                dgvkhachhang.Rows[indexRow].Cells[2].Value = nv.Hoten;
                dgvkhachhang.Rows[indexRow].Cells[3].Value = nv.SDT;
                dgvkhachhang.Rows[indexRow].Cells[4].Value = nv.GioiTinh;

            }
            dgvkhachhang.Rows[0].Selected = false;

        }
        private void loadform()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtHoTen.Focus();
        }
        private void loadDGV()
        {
            using (var context = new DataQLLK())
            {
                List<KHACHHANG> listkhachhang = context.KHACHHANGs.ToList();
                TaiDanhSachKhachHang();
            }

        }

        private void dgvkhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex == -1) return;
                if (dgvkhachhang.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) return;

                dgvkhachhang.CurrentRow.Selected = true;

                txtMaKH.Text = dgvkhachhang.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txtHoTen.Text = dgvkhachhang.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtSDT.Text = dgvkhachhang.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                cbbGioiTinh.Text = dgvkhachhang.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var kh = new KHACHHANG();
            //nv.MANV = Convert.ToInt32(txtMaNV.Text);
            kh.Hoten = txtHoTen.Text;
            kh.SDT = txtSDT.Text;
            kh.GioiTinh = cbbGioiTinh.Text;


            try
            {
                using (var dbcontext = new DataQLLK())
                {
                    dbcontext.KHACHHANGs.Add(kh);
                    dbcontext.SaveChanges();// done
                }

                TaiDanhSachKhachHang();
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
                int maKH = int.Parse(txtMaKH.Text);
                var deletekh = context.KHACHHANGs.Where(s => s.MaKhachHang == maKH).SingleOrDefault();

                if (deletekh != null)
                {
                    DialogResult result = MessageBox.Show($"Bạn có đồng ý xóa nhân viên {deletekh.MaKhachHang} không ?", "Thông báo cho bạn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        context.KHACHHANGs.Remove(deletekh);
                        context.SaveChanges();

                        loadform();
                        loadDGV();

                        MessageBox.Show($"Xóa nhân viên {deletekh.MaKhachHang} thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show($"Xóa nhân viên không thành công", "Thông báo", MessageBoxButtons.OK);

                }
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dbcontext = new DataQLLK())
                {
                    int maKH = int.Parse(txtMaKH.Text);
                    var updateKH = dbcontext.KHACHHANGs.Where(s => s.MaKhachHang == maKH).SingleOrDefault();

                    if (updateKH == null)
                    {
                        MessageBox.Show("Không cập nhật được !!!!");
                        return;
                    }

                    var kh = dbcontext.KHACHHANGs.Where(s => s.MaKhachHang == maKH).SingleOrDefault();

                    kh.Hoten = txtHoTen.Text;
                    kh.SDT = txtSDT.Text;
                    kh.GioiTinh = cbbGioiTinh.Text;
                    dbcontext.SaveChanges();
                    MessageBox.Show("Cập nhật thành công !!!!");
                }

                TaiDanhSachKhachHang();
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            FrmReportKhachHang frm = new FrmReportKhachHang();
            frm.ShowDialog();
        }
    }
}
