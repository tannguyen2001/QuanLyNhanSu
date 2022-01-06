using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using QuanLyNhanSu.ucNhanVien;
using QuanLyNhanSu.ucHeThong;
using MetroFramework.Controls;

namespace QuanLyNhanSu
{

    public partial class Main : MetroForm
    {
        private static Main _frm1;
        public static Main frm1
        {
            get
            {
                if (_frm1 == null)
                {
                    Main _frm1 = new Main();
                }
                return _frm1;
            }
            set
            {
                _frm1 = value;
            }
        }

        public MetroPanel mContainer
        {
            get { return this.mpanelChinh; }
            set { mpanelChinh = value; }
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _frm1 = this;
            ucDangNhap ucDN = new ucDangNhap();
            ucDN.Dock = DockStyle.Fill;
            frm1.mContainer.Controls.Add(ucDN);
            frm1.mContainer.Controls["ucDangNhap"].BringToFront();
        }
    }
}
