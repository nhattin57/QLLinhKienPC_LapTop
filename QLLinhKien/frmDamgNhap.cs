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

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frmLinhKien frm = new frmLinhKien();
            frm.Show();
            
        }
    }
}
