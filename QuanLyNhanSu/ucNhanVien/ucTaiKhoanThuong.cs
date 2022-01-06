using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DTO;
using BUL;
using QuanLyNhanSu.ucHeThong;

namespace QuanLyNhanSu.ucNhanVien
{
    public partial class ucTaiKhoanThuong : UserControl
    {
        public ucTaiKhoanThuong()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            txtDiaChi.Text = ucDangNhap.taikhoan.DiaChi;
            txtDienThoai.Text = ucDangNhap.taikhoan.DienThoai;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string regex = @"^[a-zA-Z0-9]";
            if (!Regex.IsMatch(txtMatKhau1.Text,regex))
            {
                MessageBox.Show("Mật khẩu không được dùng kí tự đặc biệt!");
            }
            else
            {
                if (txtMatKhau1.Text == txtMatKhau2.Text)
                {
                    TaiKhoan_DTO tk = new TaiKhoan_DTO();
                    tk.MatKhau = txtMatKhau1.Text;
                    tk.DiaChi = txtDiaChi.Text;
                    tk.DienThoai = txtDienThoai.Text;
                    if (TaiKhoan_BUL.SuaTaiKhoanT(tk, ucDangNhap.taikhoan.TaiKhoan))
                    {
                        MessageBox.Show("Cập nhật thông tin thành công!");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn nhập sai mật khẩu");
                }
            }

            

        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        
    }
}
