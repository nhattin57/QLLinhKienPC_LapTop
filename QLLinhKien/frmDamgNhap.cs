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
    public partial class frmDamgNhap : Form
    {
        public frmDamgNhap()
        {
            InitializeComponent();
        }
        LinhKien lk = new LinhKien();
        public bool kiemtra = false;
        bool kiemTraTkMk(string tk, string mk)
        {
            DataTable dt = lk.layDSTKMK();
            string tktemp, mktemp;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tktemp = dt.Rows[i][0].ToString().Trim();
                mktemp = dt.Rows[i][1].ToString().Trim();
                if (tk.Equals(tktemp)&& mk.Equals(mktemp)==true)
                {
                    kiemtra = true;
                    break;
                }
            }
            return kiemtra;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
            if (txtMatKhau.Text == "" || txtTaiKhoan.Text == "")
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            else if (kiemTraTkMk(txtTaiKhoan.Text,txtMatKhau.Text) == true)
            {
                this.Hide();
                frmBanHang frm = new frmBanHang();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Nhập sai tài khoản hoặc mật khẩu");
            }
        }

        private void frmDamgNhap_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMatKhau.Text = "";
            txtTaiKhoan.Text = "";
            txtTaiKhoan.Focus();
        }

        private void chkHienThiMK_CheckedChanged(object sender, EventArgs e)
        {
            if(chkHienThiMK.Checked==true)
                txtMatKhau.PasswordChar= '\0'; 
        }
    }
}
