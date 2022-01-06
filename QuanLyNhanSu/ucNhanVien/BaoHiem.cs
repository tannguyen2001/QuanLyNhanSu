using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace QuanLyNhanSu.ucNhanVien
{
    public partial class BaoHiem : MetroForm
    {
        public BaoHiem()
        {
            InitializeComponent();
        }
        public string MaNV
        {
            get { return txtMaNV.Text; }
            set { txtMaNV.Text = value; }
        }
        public string SoBH
        {
            get { return txtSoBH.Text; }
            set { txtSoBH.Text = value; }
        }
        public DateTime NgayCap
        {
            get { return dtpNgayCap.Value; }
            set { dtpNgayCap.Value = value; }
        }
        public string NoiCap
        {
            get { return txtNoiCap.Text; }
            set { txtNoiCap.Text = value; }
        }
        public string NoiKham
        {
            get { return txtNoiKham.Text; }
            set { txtNoiKham.Text = value; }
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != 8 || e.KeyChar != 13))
                e.Handled = true;
            if (e.KeyChar == 8)
                e.Handled = false;
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtSoBH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
