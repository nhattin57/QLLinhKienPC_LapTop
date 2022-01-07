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
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }
        LinhKien lk = new LinhKien();
        private void lsvHoaDon_SelectedIndexChanged(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            hienThiHoaDon();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
            int i = 1;
            int i2 = 1;
            foreach (ListViewItem lvi in lsvHoaDon.Items)
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
    }
}
