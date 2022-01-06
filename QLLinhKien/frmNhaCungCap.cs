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
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        LinhKien lk = new LinhKien();
        public bool check;
        void setNut(bool e)
        {
            btnAdd.Enabled = e;
            btnEdit.Enabled = e;
            btnSave.Enabled = !e;
            btnExcel.Enabled = e;
            btnExit.Enabled = e;
            btnNoSave.Enabled = !e;
        }
        void closeTextBoxCBB(bool e)
        {
            txtAdderssSupplier.Enabled = !e;
            txtIdSupplier.Enabled = !e;
            txtNameSupplier.Enabled = !e;
            txtNumberPhone.Enabled = !e;
        }

        private void refresh()
        {
            txtAdderssSupplier.Text = "";
            txtIdSupplier.Text = "";
            txtNameSupplier.Text = "";
            txtNumberPhone.Text = "";
            txtSearch.Text = "";
            txtNameSupplier.Focus();
        }

        private void viewSupplierSearch(string name)
        {
            DataTable dt = lk.viewSupplierSearch(name);
            lsvSupplier.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvSupplier.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }
        bool checkNumberPhoneSupplier(string numberPhoneSupplier)
        {
            DataTable dt = lk.getNumberPhoneSupplier();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (numberPhoneSupplier == dt.Rows[i]["SDT"].ToString())
                    return true;
            }
            return false;
        }

        bool checkNameSupplier(string nameSupplier)
        {
            DataTable dt = lk.getNameSupplier();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (nameSupplier == dt.Rows[i]["TenNCC"].ToString())
                    return false;
            }
            return true;
        }

        private void loadDataSupplier()
        {
            DataTable dt = lk.loadDataSupplier();
            lsvSupplier.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvSupplier.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            try
            {
                loadDataSupplier();
                setNut(true);
                closeTextBoxCBB(true);
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void lsvSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lsvSupplier.SelectedIndices.Count > 0)
                {
                    txtIdSupplier.Text = lsvSupplier.SelectedItems[0].SubItems[0].Text;
                    txtNameSupplier.Text = lsvSupplier.SelectedItems[0].SubItems[1].Text;
                    txtNumberPhone.Text = lsvSupplier.SelectedItems[0].SubItems[2].Text;
                    txtAdderssSupplier.Text = lsvSupplier.SelectedItems[0].SubItems[3].Text;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            txtIdSupplier.ReadOnly = true;
            check = true;
            setNut(false);
            closeTextBoxCBB(false);
            refresh();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lsvSupplier.SelectedIndices.Count <= 0)
                MessageBox.Show("Mời chọn nhà cung cấp để sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                txtIdSupplier.ReadOnly = true;
                setNut(false);
                check = false;
                closeTextBoxCBB(false);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnNoSave_Click(object sender, EventArgs e)
        {
            refresh();
            setNut(true);
            closeTextBoxCBB(true);
            loadDataSupplier();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên nhà cung cấp cần tìm kiếm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSearch.Focus();
                }
                else
                {
                    viewSupplierSearch(txtSearch.Text);
                    refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi");
                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (check == true)
                {
                    if (txtAdderssSupplier.Text == "" || txtNameSupplier.Text == "" || txtNumberPhone.Text == "")
                    {
                        MessageBox.Show("Bạn đã nhập thiếu thông tin !!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (checkNameSupplier(txtNameSupplier.Text) == false)
                        {
                            MessageBox.Show($"Nhà cung cấp có tên: {txtNameSupplier.Text} đã tồn tại. Vui lòng chọn tên nhà cung cấp mới!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNameSupplier.Focus();
                        }
                        else if (checkNumberPhoneSupplier(txtNumberPhone.Text) == false)
                        {
                            MessageBox.Show($"Nhà cung cấp có số điện thoại: {txtNumberPhone.Text.Trim()} đã tồn tại. Vui lòng chọn số điện thoại mới!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNumberPhone.Focus();
                        }
                        else if (txtNumberPhone.Text.Length < 10)
                        {
                            MessageBox.Show($"Số điện thoại chưa hợp lệ: {txtNumberPhone.Text.Trim()}. Vui lòng kiểm tra lại!!! (Số điện thoại phải >= 10 ký tự)", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNumberPhone.Focus();
                        }
                        else
                        {
                            lk.insertSupplier(txtNameSupplier.Text, txtNumberPhone.Text, txtAdderssSupplier.Text);
                            MessageBox.Show("Thêm nhà cung cấp thành công");
                            loadDataSupplier();
                            refresh();
                            setNut(true);
                            closeTextBoxCBB(true);
                        }
                    }
                }
                else
                {

                    if (txtAdderssSupplier.Text == "" || txtNameSupplier.Text == "" || txtNumberPhone.Text == "")
                    {
                        MessageBox.Show("Bạn đã nhập thiếu thông tin !!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtNumberPhone.Text.Length < 10)
                    {
                        MessageBox.Show($"Số điện thoại chưa hợp lệ:{txtNumberPhone.Text}. Vui lòng kiểm tra lại!!! (Số điện thoại phải >= 10 ký tự)", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNumberPhone.Focus();
                    }
                    else
                    {
                        int id = int.Parse(txtIdSupplier.Text);
                        lk.updateSupplier(txtNameSupplier.Text, txtAdderssSupplier.Text, txtNumberPhone.Text, id);
                        MessageBox.Show("Cập nhật nhà cung cấp thành công");
                        loadDataSupplier();
                        refresh();
                        setNut(true);
                        closeTextBoxCBB(true);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi");
                throw;
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
            foreach (ListViewItem lvi in lsvSupplier.Items)
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

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNumberPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
