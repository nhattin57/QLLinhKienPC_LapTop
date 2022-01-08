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
    public partial class frmLinhKien : Form
    {
        public frmLinhKien()
        {
            InitializeComponent();
        }
        LinhKien lk = new LinhKien();
        
        public bool themmoi;
        void setNut(bool e)
        {
            btnThem.Enabled = e;
            btnSua.Enabled = e;

            btnLuu.Enabled = !e;
            btnHuy.Enabled = !e;
            btnXuatExcel.Enabled = e;
            btnDong.Enabled = e;
            btnKoLuu.Enabled = !e;
        }
        void closeTextBoxCBB(bool e)
        {
            txtBaoHanh.Enabled = !e;
            txtGiaBan.Enabled = !e;
            txtMaLK.Enabled = !e;
            txtSLTon.Enabled = !e;
            txtTenLK.Enabled = !e;
            txtLoaiLK.Enabled = !e;
            cboTenNCC.Enabled = !e;
            txtXuatSu.Enabled = !e;
        }
        void hienThiLstViewLinhKien()
        {
            DataTable dt = lk.layTTchoLstViewLinhkien();
            lsvLinhKien.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi =

                lsvLinhKien.Items.Add(dt.Rows[i][0].ToString());

                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
                lvi.SubItems.Add(dt.Rows[i][6].ToString());
                lvi.SubItems.Add(dt.Rows[i][7].ToString());
                lvi.SubItems.Add(dt.Rows[i][8].ToString());
            }
        }
        void hienThiNhaCungCap()
        {
            DataTable dt = lk.layDSNhaCC();
            cboTenNCC.DataSource = dt;
            cboTenNCC.DisplayMember = "TenNCC";
            cboTenNCC.ValueMember = "MaNCC";
        }
        private void frmLinhKien_Load(object sender, EventArgs e)
        {
            hienThiLstViewLinhKien();
            hienThiNhaCungCap();
            setNut(true);
            closeTextBoxCBB(true);
        }

        private void lsvLinhKien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvLinhKien.SelectedIndices.Count > 0)
            {

                txtMaLK.Text = lsvLinhKien.SelectedItems[0].SubItems[1].Text;
                txtLoaiLK.Text = lsvLinhKien.SelectedItems[0].SubItems[2].Text;
                txtTenLK.Text = lsvLinhKien.SelectedItems[0].SubItems[3].Text;
                txtXuatSu.Text = lsvLinhKien.SelectedItems[0].SubItems[4].Text;
                txtGiaBan.Text = lsvLinhKien.SelectedItems[0].SubItems[5].Text;
                txtBaoHanh.Text = lsvLinhKien.SelectedItems[0].SubItems[6].Text;
                txtSLTon.Text = lsvLinhKien.SelectedItems[0].SubItems[7].Text;
                cboTenNCC.Text = lsvLinhKien.SelectedItems[0].SubItems[8].Text;
            }
        }

        private void txtSLTon_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            closeTextBoxCBB(false);
            themmoi = true;
            setNut(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lsvLinhKien.SelectedIndices.Count <= 0)
                MessageBox.Show("Mời chọn linh kiện để sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                closeTextBoxCBB(false);
                txtMaLK.ReadOnly = true;
                setNut(false);
                themmoi = false;
            }
        }
        void huyNDtextbox()
        {
            txtLoaiLK.Text = "";
            txtMaLK.Text = "";
            txtTenLK.Text = "";
            txtBaoHanh.Text = "";
            txtXuatSu.Text = "";
            txtSLTon.Text = "";
            txtGiaBan.Text = "";
            txtMaLK.Focus();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            huyNDtextbox();
        }

        private void btnKoLuu_Click(object sender, EventArgs e)
        {
            setNut(true);
            huyNDtextbox();
            closeTextBoxCBB(true);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
        int demKyTu(string chuoi)
        {
            int dem = chuoi.Length;
            return dem;
        }
        bool kiemTraTrungMaLK(string maLK)
        {
            DataTable dt = lk.layMaLK();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string maLKtemp = dt.Rows[i][0].ToString().Trim();
                if (maLK.Equals(maLK))
                    return false;
            }
            return true;
        }
        bool kiemTraTenNCC(string tenNCC)
        {
            DataTable dt = lk.layTenNCC();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tenNCCtemp = dt.Rows[i][0].ToString().Trim();
                if (tenNCCtemp.Equals(tenNCC.Trim()))
                    return true;
            }
            return false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (themmoi == true)
            {
                if (txtBaoHanh.Text == "" || txtGiaBan.Text == "" || txtLoaiLK.Text == "" || txtMaLK.Text == "" || txtSLTon.Text == "" || txtTenLK.Text == "")
                    MessageBox.Show("Vui Lòng Nhập đủ thông tin");
                else if(demKyTu(txtMaLK.Text)>10)
                {
                    MessageBox.Show("Mã Linh kiện ko quá 10 ký tự");
                }
                else if(kiemTraTrungMaLK(txtMaLK.Text)==true)
                {
                    MessageBox.Show("Mã Linh Kiện Đã Tồn Tại Vui Lòng Nhập Mã Khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (kiemTraTenNCC(cboTenNCC.Text)==false)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp trong danh sách", "Thông Báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    double giaban = double.Parse(txtGiaBan.Text);
                    int sl = int.Parse(txtSLTon.Text);
                    int mancc = int.Parse(cboTenNCC.SelectedValue.ToString());
                    lk.themLinhKien(txtMaLK.Text, txtLoaiLK.Text, txtTenLK.Text, txtXuatSu.Text, giaban, txtBaoHanh.Text, sl, mancc);
                    MessageBox.Show("Thêm Linh Kiện Thành Công");
                    hienThiLstViewLinhKien();
                    setNut(true);
                    closeTextBoxCBB(true);
                }
            }
            else
            {
                if (txtBaoHanh.Text == "" || txtGiaBan.Text == "" || txtLoaiLK.Text == "" || txtSLTon.Text == "" || txtTenLK.Text == "")
                    MessageBox.Show("Vui Lòng Nhập đủ thông tin");
                else
                {
                    double giaban = double.Parse(txtGiaBan.Text);
                    int sl = int.Parse(txtSLTon.Text);
                    int mancc = int.Parse(cboTenNCC.SelectedValue.ToString());
                    lk.SuaLinhKien(txtMaLK.Text, txtLoaiLK.Text, txtTenLK.Text, txtXuatSu.Text, giaban, txtBaoHanh.Text, sl, mancc);
                    MessageBox.Show("Sửa Linh Kiện Thành Công");
                    hienThiLstViewLinhKien();
                    setNut(true);
                    closeTextBoxCBB(true);
                }
            }
        }
        private void viewLinhKienTheoTimKiem(string tenlk)
        {
            DataTable dt = lk.timKiemLKTheoTen(tenlk);
            lsvLinhKien.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi =

                lsvLinhKien.Items.Add(dt.Rows[i][0].ToString());

                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
                lvi.SubItems.Add(dt.Rows[i][6].ToString());
                lvi.SubItems.Add(dt.Rows[i][7].ToString());
                lvi.SubItems.Add(dt.Rows[i][8].ToString());
            }

        }
        private void txtTimKiemLK_TextChanged(object sender, EventArgs e)
        {
            viewLinhKienTheoTimKiem(txtTimKiemLK.Text);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
        
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
            int i = 1;
            int i2 = 1;
            foreach (ListViewItem lvi in lsvLinhKien.Items)
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

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSLTon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
