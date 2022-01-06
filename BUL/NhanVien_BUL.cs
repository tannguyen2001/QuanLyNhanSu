using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUL
{
    public class NhanVien_BUL
    {
        public static List<NhanVien_DTO> LoadNhanVien()
        {
            return NHANVIEN_DAL.LoadNhanVien();
        }
        public static bool ThemNhanVien(NhanVien_DTO NhanVien)
        {
            return NHANVIEN_DAL.ThemNhanVien(NhanVien);
        }
        public static bool SuaNhanVien(NhanVien_DTO NhanVien,string MaNVCu)
        {
            return NHANVIEN_DAL.SuaNhanVien(NhanVien,MaNVCu);
        }
        public static bool XoaNhanVien(string MaNV)
        {
            return NHANVIEN_DAL.XoaNhanVien(MaNV);
        }
        public static List<NhanVien_DTO> TimNhanVien(string TenNV,int MaBoPhan = -1)
        {
            return NHANVIEN_DAL.TimNhanVien(TenNV, MaBoPhan);
        }
    }
}
