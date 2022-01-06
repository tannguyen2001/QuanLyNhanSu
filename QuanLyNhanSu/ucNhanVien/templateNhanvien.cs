using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhanSu.ucHeThong;
using MetroFramework;
using MetroFramework.Controls;
using QuanLyNhanSu;
using QuanLyNhanSu.ucHeThong;

namespace QuanLyNhanSu.ucNhanVien
{
    public partial class templateNhanVien : UserControl
    {
        public templateNhanVien()
        {
            InitializeComponent();
        }
        private void Btn_click(object sender, EventArgs e)
        {
            
            MetroLabel lbl = (MetroLabel)sender;
            int tmp = int.Parse(lbl.Tag.ToString());
            if(tmp==1)
            {
                LblHoSoNhanVien.BackColor = Color.FromArgb(126, 158, 166);
                lblThemXoaNhanVien.BackColor = Color.FromArgb(0, 64, 80);
                lblNhanVienThoiViec.BackColor = Color.FromArgb(0, 64, 80);
                btnHoSoNhanVien.BackColor = Color.FromArgb(126, 158, 166);
                btnThemXoaNhanVien.BackColor = Color.FromArgb(0, 64, 80);
                btnNhanVienThoiViec.BackColor = Color.FromArgb(0, 64, 80);
                foreach (UserControl uc in mpanelContent.Controls.OfType<UserControl>())
                {
                    mpanelContent.Controls.Remove(uc);
                }
                ucHoSoNhanVien ucHoSoNhanVien = new ucHoSoNhanVien();
                ucHoSoNhanVien.Dock = DockStyle.Fill;
                mpanelContent.Controls.Add(ucHoSoNhanVien);
                mpanelContent.Controls["ucHoSoNhanVien"].BringToFront();
            }
            if (tmp == 2)
            {
                lblThemXoaNhanVien.BackColor = Color.FromArgb(126, 158, 166);
                LblHoSoNhanVien.BackColor = Color.FromArgb(0, 64, 80);
                lblNhanVienThoiViec.BackColor = Color.FromArgb(0, 64, 80);
                btnThemXoaNhanVien.BackColor = Color.FromArgb(126, 158, 166);
                btnHoSoNhanVien.BackColor = Color.FromArgb(0, 64, 80);
                btnNhanVienThoiViec.BackColor = Color.FromArgb(0, 64, 80);
                foreach (UserControl uc in mpanelContent.Controls.OfType<UserControl>())
                {
                    mpanelContent.Controls.Remove(uc);
                }
                if (ucDangNhap.taikhoan.MaPhanQuyen == 1)
                {
                    ucTaiKhoanThuong ucTaiKhoanThuong = new ucTaiKhoanThuong();
                    ucTaiKhoanThuong.Dock = DockStyle.Fill;
                    mpanelContent.Controls.Add(ucTaiKhoanThuong);
                    mpanelContent.Controls["ucTaiKhoanThuong"].BringToFront();
                }
                else
                {
                    ucTaiKhoanVip ucTaiKhoanVip = new ucTaiKhoanVip();
                    ucTaiKhoanVip.Dock = DockStyle.Fill;
                    mpanelContent.Controls.Add(ucTaiKhoanVip);
                    mpanelContent.Controls["ucTaiKhoanVip"].BringToFront();
                }
            }
            if (tmp == 3)
            {
                if (MessageBox.Show("Bạn có muốn đăng xuất không?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ucDangNhap NV = new ucDangNhap();
                    NV.Dock = DockStyle.Fill;
                    Main.frm1.mContainer.Controls.Add(NV);
                    Main.frm1.mContainer.Controls["ucDangNhap"].BringToFront();
                    foreach (templateNhanVien uc in Main.frm1.mContainer.Controls.OfType<templateNhanVien>())
                    {
                        Main.frm1.mContainer.Controls.Remove(uc);
                    }
                }
            }


        }

        private void Btn_click1(object sender, EventArgs e)
        {
            MetroPanel btn  = (MetroPanel)sender;
            int tmp = int.Parse(btn.Tag.ToString());
            if (tmp == 1)
            {
                LblHoSoNhanVien.BackColor = Color.FromArgb(126, 158, 166);
                lblThemXoaNhanVien.BackColor = Color.FromArgb(0, 64, 80);
                lblNhanVienThoiViec.BackColor = Color.FromArgb(0, 64, 80);
                btnHoSoNhanVien.BackColor = Color.FromArgb(126, 158, 166);
                btnThemXoaNhanVien.BackColor = Color.FromArgb(0, 64, 80);
                btnNhanVienThoiViec.BackColor = Color.FromArgb(0, 64, 80);
                foreach (UserControl uc in mpanelContent.Controls.OfType<UserControl>())
                {
                    mpanelContent.Controls.Remove(uc);
                }
                ucHoSoNhanVien ucHoSoNhanVien = new ucHoSoNhanVien();
                ucHoSoNhanVien.Dock = DockStyle.Fill;
                mpanelContent.Controls.Add(ucHoSoNhanVien);
                mpanelContent.Controls["ucHoSoNhanVien"].BringToFront();
            }
            if (tmp == 2)
            {
                lblThemXoaNhanVien.BackColor = Color.FromArgb(126, 158, 166);
                LblHoSoNhanVien.BackColor = Color.FromArgb(0, 64, 80);
                lblNhanVienThoiViec.BackColor = Color.FromArgb(0, 64, 80);
                btnThemXoaNhanVien.BackColor = Color.FromArgb(126, 158, 166);
                btnHoSoNhanVien.BackColor = Color.FromArgb(0, 64, 80);
                btnNhanVienThoiViec.BackColor = Color.FromArgb(0, 64, 80);
                foreach (UserControl uc in mpanelContent.Controls.OfType<UserControl>())
                {
                    mpanelContent.Controls.Remove(uc);
                }
                if (ucDangNhap.taikhoan.MaPhanQuyen==1)
                {
                    ucTaiKhoanThuong ucTaiKhoanThuong = new ucTaiKhoanThuong();
                    ucTaiKhoanThuong.Dock = DockStyle.Fill;
                    mpanelContent.Controls.Add(ucTaiKhoanThuong);
                    mpanelContent.Controls["ucTaiKhoanThuong"].BringToFront();
                }
                else
                {
                    ucTaiKhoanVip ucTaiKhoanVip = new ucTaiKhoanVip();
                    ucTaiKhoanVip.Dock = DockStyle.Fill;
                    mpanelContent.Controls.Add(ucTaiKhoanVip);
                    mpanelContent.Controls["ucTaiKhoanVip"].BringToFront();
                }
            }
            if (tmp == 3)
            {
                if (MessageBox.Show("Bạn có muốn đăng xuất không?","",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    ucDangNhap NV = new ucDangNhap();
                    NV.Dock = DockStyle.Fill;
                    Main.frm1.mContainer.Controls.Add(NV);
                    Main.frm1.mContainer.Controls["ucDangNhap"].BringToFront();
                    foreach (templateNhanVien uc in Main.frm1.mContainer.Controls.OfType<templateNhanVien>())
                    {
                        Main.frm1.mContainer.Controls.Remove(uc);
                    }
                }
            }


        }
        private void btnTroVe_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không?","Thông báo!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }
    }
}
