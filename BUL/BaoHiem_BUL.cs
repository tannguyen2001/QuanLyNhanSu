using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUL
{
    public class BaoHiem_BUL
    {
        public static List<BaoHiem_DTO> LoadBaoHiem(string MaNV)
        {
            return BaoHiem_DAL.LoadBaoHiem(MaNV);
        }
        public static bool ThemBaoHiem(BaoHiem_DTO bh)
        {
            return BaoHiem_DAL.ThemBaoHiem(bh);
        }
        public static bool SuaBaoHiem(BaoHiem_DTO bh,string SoBHCU)
        {
            return BaoHiem_DAL.SuaBaoHiem(bh,SoBHCU);
        }
        public static bool XoaBaoHiem(string SOBH)
        {
            return BaoHiem_DAL.XoaBaoHiem(SOBH);
        }
    }
}
