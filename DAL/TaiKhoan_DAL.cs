using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class TaiKhoan_DAL
    {
        public static bool CheckTK(string TenTK,string MK,out TaiKhoan_DTO taikhoan)
        {
            taikhoan = new TaiKhoan_DTO();
            string sTruyVan = String.Format("select * from TaiKhoan where TaiKhoan = '{0}' and MatKhau = '{1}'", TenTK, MK);
            DataTable dt = new DataTable();
            dt = DataProvider.TruyVanDataReader(sTruyVan);
            if(dt!=null && dt.Rows.Count>0)
            {
                taikhoan.DiaChi = dt.Rows[0]["DiaChi"].ToString();
                taikhoan.HoTen = dt.Rows[0]["HoTen"].ToString();
                taikhoan.MaPhanQuyen = int.Parse(dt.Rows[0]["MaPhanQuyen"].ToString());
                taikhoan.TaiKhoan = dt.Rows[0]["TaiKhoan"].ToString();
                taikhoan.MatKhau = dt.Rows[0]["MatKhau"].ToString();
                taikhoan.DienThoai = dt.Rows[0]["DienThoai"].ToString();
                return true;
            }
            else
            {
                taikhoan = null;
                return false;
            }
        }
        public static bool SuaTaiKhoanT(TaiKhoan_DTO tk,string TaiKhoan)
        {
            string sTruyVan = String.Format("update taikhoan set MatKhau = '{0}',DienThoai = N'{1}',DiaChi=N'{2}' where TaiKhoan = '{3}'",tk.MatKhau,tk.DienThoai,tk.DiaChi,TaiKhoan);
            bool ketQua = DataProvider.TruyVanExecuteNonQuery(sTruyVan);
            return ketQua;
        }
        public static List<TaiKhoan_DTO> LoadTaiKhoan()
        {
            string sChuoiTruyVan = "select * from TaiKhoan";
            DataTable dt = DataProvider.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null) //Nếu datatable hợp lệ và có giá trị
            {
                List<TaiKhoan_DTO> LTaiKhoan = new List<TaiKhoan_DTO>();
                for (int i = 0; i < dt.Rows.Count; i++) //Duyệt datatable và đưa vào list đối tượng NHANVIEN_DTO
                {
                    TaiKhoan_DTO tk = new TaiKhoan_DTO();
                    tk.TaiKhoan = dt.Rows[i]["TaiKhoan"].ToString();
                    tk.MatKhau = dt.Rows[i]["MatKhau"].ToString();
                    tk.HoTen = dt.Rows[i]["HoTen"].ToString();
                    tk.DienThoai = dt.Rows[i]["DienThoai"].ToString();
                    tk.DiaChi = dt.Rows[i]["DiaChi"].ToString();
                    tk.MaPhanQuyen = int.Parse(dt.Rows[i]["MaPhanQuyen"].ToString());
                    LTaiKhoan.Add(tk);
                }
                return LTaiKhoan;
            }
            return null;
        }

        //Phương thức xử lý Thêm nhân viên
        public static bool ThemTaiKhoan(TaiKhoan_DTO tkDTO)
        {
            //Bước 4: Tạo truy vấn và gọi về phương thức xử lý của class Dataprovider.TruyVanExcuteNonQuery
            string sChuoiTruyVan = string.Format("insert into TaiKhoan (TaiKhoan,MatKhau,HoTen,DienThoai,DiaChi,MaPhanQuyen) values ('{0}','{1}',N'{2}','N{3}',N'{4}',{5})",tkDTO.TaiKhoan,tkDTO.MatKhau,tkDTO.HoTen,tkDTO.DienThoai,tkDTO.DiaChi,tkDTO.MaPhanQuyen);
            bool ketQua = DataProvider.TruyVanExecuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }

        //Phương thức cập nhật dữ liệu nhân viên
        public static bool SuaTaiKhoan(TaiKhoan_DTO TK, string TKCU)
        {
            string sChuoiTruyVan = string.Format("update TaiKhoan set TaiKhoan = '{0}',MatKhau = '{1}',HoTen = N'{2}',DienThoai = N'{3}',DiaChi = N'{4}',MaPhanQuyen = {5} where TaiKhoan = '{6}'",TK.TaiKhoan,TK.MatKhau,TK.HoTen,TK.DienThoai,TK.DiaChi,TK.MaPhanQuyen,TKCU);
            bool ketQua = DataProvider.TruyVanExecuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        //Phương thức xóa nhân viên
        public static bool XoaTaiKhoan(string TK)
        {
            string sChuoiTruyVan = string.Format("DELETE FROM TaiKhoan WHERE TaiKhoan='{0}'", TK);
            bool ketQua = DataProvider.TruyVanExecuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        //Phương thức xử lý tìm kiếm nhân viên
        public static List<TaiKhoan_DTO> TimTaiKhoan(string HoTen)
        {
            string sChuoiTruyVan = string.Format(@"select * From TaiKhoan where HoTen Like N'%{0}%'", HoTen);
            DataTable dt = DataProvider.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0) //Nếu datatable hợp lệ và có giá trị
            {
                List<TaiKhoan_DTO> LTaiKhoan = new List<TaiKhoan_DTO>();
                for (int i = 0; i < dt.Rows.Count; i++) //Duyệt datatable và đưa vào list đối tượng NHANVIEN_DTO
                {
                    TaiKhoan_DTO tk = new TaiKhoan_DTO();
                    tk.TaiKhoan = dt.Rows[i]["TaiKhoan"].ToString();
                    tk.MatKhau = dt.Rows[i]["MatKhau"].ToString();
                    tk.HoTen = dt.Rows[i]["HoTen"].ToString();
                    tk.DienThoai = dt.Rows[i]["DienThoai"].ToString();
                    tk.DiaChi = dt.Rows[i]["DiaChi"].ToString();
                    tk.MaPhanQuyen = int.Parse(dt.Rows[i]["MaPhanQuyen"].ToString());
                    LTaiKhoan.Add(tk);
                }
                return LTaiKhoan;
            }
            return null;
        }
    }
}
