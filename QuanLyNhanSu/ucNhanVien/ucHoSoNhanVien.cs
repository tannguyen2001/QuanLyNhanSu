using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhanSu;
using BUL;
using DTO;

namespace QuanLyNhanSu.ucNhanVien
{
    public partial class ucHoSoNhanVien : UserControl
    {
        public OpenFileDialog openFile = new OpenFileDialog();
        public string sFile = "";
        public string dFile = "";
        public string imageName="";
        public ucHoSoNhanVien()
        {
            InitializeComponent();
        }
        private void LoadNhanVien(List<NhanVien_DTO> nv)
        {

            if(nv!=null)
            {
                dgvNhanVien.DataSource = nv;
                dgvNhanVien.Columns[0].HeaderText = "Mã nhân viên";
                dgvNhanVien.Columns[1].HeaderText = "Họ";
                dgvNhanVien.Columns[2].HeaderText = "Tên";
                dgvNhanVien.Columns[3].HeaderText = "CMND";
                dgvNhanVien.Columns[4].HeaderText = "Giới tính";
                dgvNhanVien.Columns[5].HeaderText = "Ngày sinh";
                dgvNhanVien.Columns[6].HeaderText = "Hình ảnh";
                dgvNhanVien.Columns[7].HeaderText = "Địa chỉ";
                dgvNhanVien.Columns[8].HeaderText = "Điện thoại";
                dgvNhanVien.Columns[9].HeaderText = "Đã thôi việc";
                dgvNhanVien.Columns[10].HeaderText = "Mã bộ phận";
                dgvNhanVien.Columns[11].HeaderText = "Mã chức vụ";
                dgvNhanVien.Columns[12].HeaderText = "Mã trình độ";
            }   
        }
        private void LoadBaoHiem(List<BaoHiem_DTO> bh)
        {
            if (bh != null)
            {
                dgvBaoHiem.DataSource = bh;
                dgvBaoHiem.Columns[0].HeaderText = "Số bảo hiểm";
                dgvBaoHiem.Columns[1].HeaderText = "Ngày cấp";
                dgvBaoHiem.Columns[2].HeaderText = "Nơi cấp";
                dgvBaoHiem.Columns[3].HeaderText = "Nơi khám bệnh";
                dgvBaoHiem.Columns[4].HeaderText = "Mã nhân viên";
            }
        }
        private void ToExcel(DataGridView dvg, string fileName)
        {
            //khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            try
            {
                //Tạo đối tượng COM.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //tạo mới một Workbooks bằng phương thức add()
                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                //đặt tên cho sheet
                worksheet.Name = "Quản lý nhân sự";

                // export header trong DataGridView
                for (int i = 0; i < dvg.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dvg.Columns[i].HeaderText;
                }
                // export nội dung trong DataGridView
                for (int i = 0; i < dvg.RowCount; i++)
                {
                    for (int j = 0; j < dvg.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dvg.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // sử dụng phương thức SaveAs() để lưu workbook với filename
                workbook.SaveAs(fileName);
                //đóng workbook
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }
        protected override void OnLoad(EventArgs e)
        {

            LoadNhanVien(NhanVien_BUL.LoadNhanVien());
            cbbChucVu.DataSource = ChucVu_BUL.LoadChucVu();
            cbbChucVu.ValueMember = "MaChucVu";
            cbbChucVu.DisplayMember = "TenChucVu";
            cbbBoPhan.DataSource = BoPhan_BUL.LoadBoPhan();
            cbbBoPhan.DisplayMember = "TenBP";
            cbbBoPhan.ValueMember = "MaBP";
            cbbTrinhDo.DataSource = TrinhDo_BUL.LoadTrinhDo();
            cbbTrinhDo.ValueMember = "MaTrinhDo";
            cbbTrinhDo.DisplayMember = "TenTrinhDo";
            cbbTKBoPhan.DataSource = BoPhan_BUL.LoadBoPhan();
            cbbTKBoPhan.DisplayMember = "TenBP";
            cbbTKBoPhan.ValueMember = "MaBP";
            
        }

        private void btnSYLLThem_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "" || txtHo.Text.Trim() == "" || txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống thông tin quan trọng");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn thêm nhân viên?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    NhanVien_DTO nv = new NhanVien_DTO();
                    nv.MaNV = txtMaNV.Text;
                    nv.HoLot = txtHo.Text;
                    nv.Ten = txtTen.Text;
                    nv.GioiTinh = rbNam.Checked ? "True" : "False";
                    nv.HinhAnh = imageName;
                    nv.CMND = txtCMND.Text;
                    nv.DiaChi = txtDiaChi.Text;
                    nv.DienThoai = txtDienThoai.Text;
                    nv.DaThoiViec = "False";
                    nv.MaChucVu = cbbChucVu.SelectedIndex + 1;
                    nv.MaTrinhDo = cbbTrinhDo.SelectedIndex + 1;
                    nv.NgaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
                    nv.MaBP = cbbBoPhan.SelectedIndex + 1;
                    if (NhanVien_BUL.ThemNhanVien(nv) == false)
                    {
                        MessageBox.Show("Mã nhân viên này đã tồn tại", "Lỗi");
                    }
                    LoadNhanVien(NhanVien_BUL.LoadNhanVien());
                    if (sFile != "" && dFile != "")
                    {
                        System.IO.File.Copy(sFile, dFile, true);
                    }
                    this.loadTrang();
                }
            }
            
        }
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            
            openFile.Title = "Chọn ảnh";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ptbNhanVien.Image = Image.FromFile(openFile.FileName);
                string fileName = openFile.FileName;
                sFile = fileName;
                
                int i = fileName.Length;
                i--;
                int count = 0;
                while (fileName[i] != '\\')
                {
                    i--;
                    count++;
                }
                imageName = fileName.Substring(i+1, count);
                dFile = "..\\..\\bin\\Debug\\Anh\\" + imageName;
            }    
            else
                MessageBox.Show("You clicked Cancel", "Open Dialog",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSYLLSua_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "" || txtHo.Text.Trim() == "" || txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống thông tin quan trọng");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn câp nhật lại thông tin nhân viên này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    NhanVien_DTO nv = new NhanVien_DTO();
                    nv.MaNV = txtMaNV.Text;
                    nv.HoLot = txtHo.Text;
                    nv.Ten = txtTen.Text;
                    nv.GioiTinh = rbNam.Checked ? "True" : "False";
                    nv.HinhAnh = imageName;
                    nv.CMND = txtCMND.Text;
                    nv.DiaChi = txtDiaChi.Text;
                    nv.DienThoai = txtDienThoai.Text;
                    nv.DaThoiViec = "False";
                    nv.MaChucVu = cbbChucVu.SelectedIndex + 1;
                    nv.MaTrinhDo = cbbTrinhDo.SelectedIndex + 1;
                    nv.NgaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
                    nv.MaBP = cbbBoPhan.SelectedIndex + 1;
                    if (NhanVien_BUL.SuaNhanVien(nv, lblMaNVSYLL.Text) == false)
                    {
                        MessageBox.Show("Mã nhân viên này đã tồn tại", "Lỗi");
                    }
                    LoadNhanVien(NhanVien_BUL.LoadNhanVien());
                    if (sFile != "" && dFile != "" && sFile != dFile)
                    {
                        System.IO.File.Copy(sFile, dFile, true);
                    }
                    this.loadTrang();
                }
            }
            
        }

        private void btnSYLLXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn xóa nhân viên này?","Thông báo", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                NhanVien_BUL.XoaNhanVien(lblMaNVSYLL.Text);
                if(dgvNhanVien.Rows.Count>1)
                {
                    LoadNhanVien(NhanVien_BUL.LoadNhanVien());
                }
                else
                {
                    dgvNhanVien.DataSource = null;
                }
                this.loadTrang();
            }
        }
        private void loadTrang()
        {
            ptbNhanVien.Image = null;
            ptbNhanVien2.Image = null;
            lblMaNVSYLL.Text = "";
            lblTTNVMaNV.Text = "";
            txtMaNV.Text="";
            txtHo.Text="";
            txtTen.Text="";
            rbNam.Checked = true;
            txtCMND.Text="";
            txtDiaChi.Text="";
            txtDienThoai.Text="";
            cbbChucVu.SelectedIndex = 0;
            cbbTrinhDo.SelectedIndex = 0;
            cbbBoPhan.SelectedIndex = 0;
        }

        private void btnThemBH_Click(object sender, EventArgs e)
        {
            BaoHiem bh = new BaoHiem();
            if (bh.ShowDialog() == DialogResult.OK)
            {
                BaoHiem_DTO bhDTO = new BaoHiem_DTO();
                bhDTO.MaNV = bh.MaNV;
                bhDTO.NoiCap = bh.NoiCap;
                bhDTO.NgayCap = bh.NgayCap;
                bhDTO.SoBH = bh.SoBH;
                bhDTO.NoiKhamBenh = bh.NoiKham;
                BaoHiem_BUL.ThemBaoHiem(bhDTO);
                LoadBaoHiem(BaoHiem_BUL.LoadBaoHiem(bh.MaNV));
                if (dgvBaoHiem.Rows.Count == 0)
                {
                    btnXoaBH.Enabled = false;
                    btnSuaBH.Enabled = false;
                    btnXoaBH.ForeColor = Color.White;
                    btnXoaBH.BackColor = Color.Silver;
                    btnSuaBH.ForeColor = Color.White;
                    btnSuaBH.BackColor = Color.Silver;
                }
            }

        }

        private void btnSuaBH_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Bạn có muốn sửa bảo hiểm?","Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BaoHiem bh = new BaoHiem();
                bh.txtMaNV.Enabled = false;
                bh.MaNV = dgvBaoHiem.SelectedRows[0].Cells["MaNV"].Value.ToString();
                bh.NoiCap = dgvBaoHiem.SelectedRows[0].Cells["NoiCap"].Value.ToString();
                bh.NgayCap = DateTime.Parse(dgvBaoHiem.SelectedRows[0].Cells["NgayCap"].Value.ToString());
                bh.SoBH = dgvBaoHiem.SelectedRows[0].Cells["SoBH"].Value.ToString();
                string SoBHCU = bh.SoBH;
                bh.NoiKham = dgvBaoHiem.SelectedRows[0].Cells["NoiKhamBenh"].Value.ToString();
                if (bh.ShowDialog() == DialogResult.OK)
                {
                    BaoHiem_DTO bhDTO = new BaoHiem_DTO();
                    bhDTO.MaNV = bh.MaNV;
                    bhDTO.NoiCap = bh.NoiCap;
                    bhDTO.NgayCap = bh.NgayCap;
                    bhDTO.SoBH = bh.SoBH;
                    bhDTO.NoiKhamBenh = bh.NoiKham;
                    BaoHiem_BUL.SuaBaoHiem(bhDTO, SoBHCU);
                    LoadBaoHiem(BaoHiem_BUL.LoadBaoHiem(bh.MaNV));
                    if (dgvBaoHiem.Rows.Count == 0)
                    {
                        btnXoaBH.Enabled = false;
                        btnSuaBH.Enabled = false;
                        btnXoaBH.ForeColor = Color.White;
                        btnXoaBH.BackColor = Color.Silver;
                        btnSuaBH.ForeColor = Color.White;
                        btnSuaBH.BackColor = Color.Silver;
                    }
                }
            }
            
        }

        private void btnXoaBH_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("Bạn có muốn xóa bảo hiểm?","Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string SOBH = dgvBaoHiem.SelectedRows[0].Cells["SoBH"].Value.ToString();
                string MANV = dgvBaoHiem.SelectedRows[0].Cells["MaNV"].Value.ToString();
                BaoHiem_BUL.XoaBaoHiem(SOBH);
                if(dgvBaoHiem.Rows.Count>1)
                {
                    LoadBaoHiem(BaoHiem_BUL.LoadBaoHiem(MANV));
                }
                else
                {
                    dgvBaoHiem.DataSource = null;
                }

                if (dgvBaoHiem.Rows.Count == 0)
                {
                    btnXoaBH.Enabled = false;
                    btnSuaBH.Enabled = false;
                    btnXoaBH.BackColor = Color.Silver;
                    btnSuaBH.BackColor = Color.Silver;
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (checkBoPhan.Checked)
            {
                LoadNhanVien(NhanVien_BUL.TimNhanVien(textBox1.Text.Trim(), cbbTKBoPhan.SelectedIndex + 1));
            }
            else
            {
                LoadNhanVien(NhanVien_BUL.TimNhanVien(textBox1.Text.Trim()));
            }
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtHo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= 65 || e.KeyChar == 8 || e.KeyChar == 32));
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

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= 65 || e.KeyChar == 8 || e.KeyChar == 32));
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel|*.xls;*.xlsx";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                ToExcel(dgvNhanVien, dialog.FileName);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblTTNVMaNV.Text = dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value.ToString();
            txtMaNV.Text = dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value.ToString();
            txtHo.Text = dgvNhanVien.SelectedRows[0].Cells["HoLot"].Value.ToString();
            txtTen.Text = dgvNhanVien.SelectedRows[0].Cells["Ten"].Value.ToString();
            txtCMND.Text = dgvNhanVien.SelectedRows[0].Cells["CMND"].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.SelectedRows[0].Cells["DiaChi"].Value.ToString();
            txtDienThoai.Text = dgvNhanVien.SelectedRows[0].Cells["DienThoai"].Value.ToString();
            dtpNgaySinh.Value = DateTime.Parse(dgvNhanVien.SelectedRows[0].Cells["NgaySinh"].Value.ToString());
            string anhName = dgvNhanVien.SelectedRows[0].Cells["HinhAnh"].Value.ToString();
            imageName = anhName;
            lblMaNVSYLL.Text = dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value.ToString();
            cbbBoPhan.SelectedIndex = int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaBP"].Value.ToString()) - 1;
            cbbChucVu.SelectedIndex = int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaChucVu"].Value.ToString()) - 1;
            cbbTrinhDo.SelectedIndex = int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaTrinhDo"].Value.ToString()) - 1;
            if (anhName != "")
            {
                Image img = Image.FromFile("..\\..\\bin\\Debug\\Anh\\" + anhName);
                ptbNhanVien.Image = img;
                ptbNhanVien2.Image = img;
            }
            else
            {
                ptbNhanVien.Image = null;
                ptbNhanVien2.Image = null;
            }

            if (dgvNhanVien.SelectedRows[0].Cells["GioiTinh"].Value.ToString() == "Nam")
            {
                rbNam.Checked = true;
            }
            else
            {
                rbNu.Checked = true;
            }
            LoadBaoHiem(BaoHiem_BUL.LoadBaoHiem(lblTTNVMaNV.Text));

            if (dgvBaoHiem.Rows.Count == 0)
            {
                btnXoaBH.Enabled = false;
                btnSuaBH.Enabled = false;
                btnXoaBH.ForeColor = Color.White;
                btnXoaBH.BackColor = Color.Silver;
                btnSuaBH.ForeColor = Color.White;
                btnSuaBH.BackColor = Color.Silver;

            }
        }

        private void dgvBaoHiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnXoaBH.Enabled = true;
            btnSuaBH.Enabled = true;
            btnXoaBH.BackColor = Color.FromArgb(0, 64, 80);
            btnSuaBH.BackColor = Color.FromArgb(0, 64, 80);
        }
    }
    
}
