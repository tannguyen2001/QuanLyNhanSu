using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class BaoHiem_DAL
    {
        public static List<BaoHiem_DTO> LoadBaoHiem(string MaNV)
        {
            List<BaoHiem_DTO> Lbh = new List<BaoHiem_DTO>();
            string sTruyVan = string.Format("select * from baohiem where manv = N'{0}'", MaNV);
            DataTable dt = new DataTable();
            Console.WriteLine(MaNV);
            dt = DataProvider.TruyVanDataReader(sTruyVan);
            if(dt!=null && dt.Rows.Count>0){
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BaoHiem_DTO bh = new BaoHiem_DTO();
                    bh.MaNV = MaNV;
                    bh.NgayCap = DateTime.Parse(dt.Rows[i]["NgayCap"].ToString());
                    bh.NoiCap = dt.Rows[i]["NoiCap"].ToString();
                    bh.SoBH = dt.Rows[i]["SoBH"].ToString();
                    bh.NoiKhamBenh = dt.Rows[i]["NoiKhamBenh"].ToString();
                    Lbh.Add(bh);
                }
                return Lbh;
            }
            return null;

        }
        public static bool ThemBaoHiem(BaoHiem_DTO bh)
        {
            //Bước 4: Tạo truy vấn và gọi về phương thức xử lý của class Dataprovider.TruyVanExcuteNonQuery
            string sChuoiTruyVan = string.Format("INSERT INTO BaoHiem(SoBH,NgayCap,NoiCap,NoiKhamBenh,MaNV) VALUES (N'{0}','{1}',N'{2}',N'{3}',N'{4}')", bh.SoBH,bh.NgayCap.ToString("yyyy-MM-dd"),bh.NoiCap,bh.NoiKhamBenh,bh.MaNV);
            bool ketQua = DataProvider.TruyVanExecuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static bool SuaBaoHiem(BaoHiem_DTO bh,string SoBHCU)
        {
            string sTruyVan = string.Format("update baohiem set SoBH = N'{0}',NgayCap = '{1}',NoiCap=N'{2}',NoiKhamBenh=N'{3}' where SoBH = N'{4}'", bh.SoBH, bh.NgayCap, bh.NoiCap, bh.NoiKhamBenh, SoBHCU);
            bool ketQua = DataProvider.TruyVanExecuteNonQuery(sTruyVan);
            return ketQua;
        }
        public static bool XoaBaoHiem(string SOBH)
        {
            string sTruyVan = string.Format("delete from BaoHiem where SoBH = N'{0}'", SOBH);
            bool KetQua = DataProvider.TruyVanExecuteNonQuery(sTruyVan);
            return KetQua;
        }
    }
}
