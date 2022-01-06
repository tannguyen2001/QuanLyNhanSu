using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUL;
using DTO;

namespace QuanLyNhanSu.ucNhanVien
{
    public partial class ucTaiKhoanVip : UserControl
    {
        public ucTaiKhoanVip()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            cbbPhanQuyen.DataSource = PhanQuyen_BUL.LoadPhanQuyen();
            cbbPhanQuyen.ValueMember = "MaPhanQuyen";
            cbbPhanQuyen.DisplayMember = "TenPhanQuyen";
            dgvTaiKhoan.DataSource = TaiKhoan_BUL.LoadTaiKhoan();
            dgvTaiKhoan.Columns[0].HeaderText = "Tài khoản";
            dgvTaiKhoan.Columns[1].HeaderText = "Mật khẩu";
            dgvTaiKhoan.Columns[2].HeaderText = "Họ tên";
            dgvTaiKhoan.Columns[3].HeaderText = "Điện thoại";
            dgvTaiKhoan.Columns[4].HeaderText = "Địa chỉ";
            dgvTaiKhoan.Columns[5].HeaderText = "Mã phân quyền";
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thêm tài khoản?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                TaiKhoan_DTO tk = new TaiKhoan_DTO();
                tk.TaiKhoan = txtTaiKhoan.Text;
                tk.MatKhau = txtMatKhau.Text;
                tk.HoTen = txtHoTen.Text;
                tk.DienThoai = txtDienThoai.Text;
                tk.DiaChi = txtDiaChi.Text;
                tk.MaPhanQuyen = cbbPhanQuyen.SelectedIndex + 1;
                TaiKhoan_BUL.ThemTaiKhoan(tk);
                dgvTaiKhoan.DataSource = TaiKhoan_BUL.LoadTaiKhoan();
            }

        }

        private void btnSuaTK_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn muốn sửa tài khoản?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                TaiKhoan_DTO tk = new TaiKhoan_DTO();
                tk.TaiKhoan = txtTaiKhoan.Text;
                tk.MatKhau = txtMatKhau.Text;
                tk.HoTen = txtHoTen.Text;
                tk.DienThoai = txtDienThoai.Text;
                tk.DiaChi = txtDiaChi.Text;
                tk.MaPhanQuyen = cbbPhanQuyen.SelectedIndex + 1;
                string TKCU = dgvTaiKhoan.SelectedRows[0].Cells["TaiKhoan"].Value.ToString();
                TaiKhoan_BUL.SuaTaiKhoan(tk,TKCU);
                dgvTaiKhoan.DataSource = TaiKhoan_BUL.LoadTaiKhoan();
            }
        }

        private void dgvTaiKhoan_Click(object sender, EventArgs e)
        {
            txtTaiKhoan.Text = dgvTaiKhoan.SelectedRows[0].Cells["TaiKhoan"].Value.ToString();
            txtMatKhau.Text = dgvTaiKhoan.SelectedRows[0].Cells["MatKhau"].Value.ToString();
            txtHoTen.Text = dgvTaiKhoan.SelectedRows[0].Cells["HoTen"].Value.ToString();
            txtDienThoai.Text = dgvTaiKhoan.SelectedRows[0].Cells["DienThoai"].Value.ToString();
            txtDiaChi.Text = dgvTaiKhoan.SelectedRows[0].Cells["DiaChi"].Value.ToString();
            cbbPhanQuyen.SelectedIndex = int.Parse(dgvTaiKhoan.SelectedRows[0].Cells["MaPhanQuyen"].Value.ToString())-1;
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn xóa tài khoản không?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                TaiKhoan_BUL.XoaTaiKhoan(dgvTaiKhoan.SelectedRows[0].Cells["TaiKhoan"].Value.ToString());
                txtTaiKhoan.Text = "";
                txtMatKhau.Text = "";
                txtHoTen.Text = "";
                txtDienThoai.Text = "";
                txtDiaChi.Text = "";
                dgvTaiKhoan.DataSource = TaiKhoan_BUL.LoadTaiKhoan();
            }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            dgvTaiKhoan.DataSource = TaiKhoan_BUL.TimTaiKhoan(txtTKHoTen.Text.Trim());
        }

        private void txtDienThoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= 65 || e.KeyChar == 8 || e.KeyChar == 32));
        }

        private void txtTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != 8 || e.KeyChar != 13))
                e.Handled = true;
            if (e.KeyChar == 8)
                e.Handled = false;
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
