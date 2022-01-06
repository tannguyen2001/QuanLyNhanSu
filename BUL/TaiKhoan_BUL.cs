using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUL
{
    public class TaiKhoan_BUL
    {
        public static bool CheckTK(string TenTK,string MatKhau,out TaiKhoan_DTO taikhoan)
        {
            return TaiKhoan_DAL.CheckTK(TenTK, MatKhau,out taikhoan);
        }
        public static bool SuaTaiKhoanT(TaiKhoan_DTO tk, string TaiKhoan)
        {
            return TaiKhoan_DAL.SuaTaiKhoanT(tk,TaiKhoan);
        }
        public static List<TaiKhoan_DTO> LoadTaiKhoan()
        {
            return TaiKhoan_DAL.LoadTaiKhoan();
        }
        public static bool ThemTaiKhoan(TaiKhoan_DTO tk)
        {
            return TaiKhoan_DAL.ThemTaiKhoan(tk);
        }
        public static bool XoaTaiKhoan(string tk)
        {
            return TaiKhoan_DAL.XoaTaiKhoan(tk);
        }
        public static bool SuaTaiKhoan(TaiKhoan_DTO tk,string TKCU)
        {
            return TaiKhoan_DAL.SuaTaiKhoan(tk,TKCU);
        }
        public static List<TaiKhoan_DTO> TimTaiKhoan(string HoTen)
        {
            return TaiKhoan_DAL.TimTaiKhoan(HoTen);
        }
    }
    
}
