using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhanSu.ucNhanVien;
using MetroFramework;
using MetroFramework.Controls;
using BUL;
using DTO;

namespace QuanLyNhanSu.ucHeThong
{
    public partial class ucDangNhap : UserControl
    {
        public ucDangNhap()
        {
            InitializeComponent();
        }
        public static TaiKhoan_DTO taikhoan = new TaiKhoan_DTO();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (TaiKhoan_BUL.CheckTK(txtTaiKhoan.Text,txtMatKhau.Text,out taikhoan))
            {
                templateNhanVien NV = new templateNhanVien();
                NV.Dock = DockStyle.Fill;
                Main.frm1.mContainer.Controls.Add(NV);
                Main.frm1.mContainer.Controls["templateNhanVien"].BringToFront();
                foreach (ucDangNhap uc in Main.frm1.mContainer.Controls.OfType<ucDangNhap>())
                {
                    Main.frm1.mContainer.Controls.Remove(uc);
                }
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }

        private void txtTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void txtTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.KeyChar)&&(e.KeyChar != 8 ))
                e.Handled = true;
            
        }
    }
}
