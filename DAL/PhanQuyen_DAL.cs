using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class PhanQuyen_DAL
    {
        public static List<PhanQuyen_DTO> LoadPhanQuyen()
        {
            string sTruyVan = "select * from phanquyen";
            DataTable dt = new DataTable();
            dt = DataProvider.TruyVanDataReader(sTruyVan);
            List<PhanQuyen_DTO> LPhanQuyen = new List<PhanQuyen_DTO>();
            for(int i = 0; i < dt.Rows.Count;i++)
            {
                PhanQuyen_DTO phanquyen = new PhanQuyen_DTO();
                phanquyen.MaPhanQuyen = int.Parse(dt.Rows[i]["MaPhanQuyen"].ToString());
                phanquyen.TenPhanQuyen = dt.Rows[i]["TenPhanQuyen"].ToString();
                LPhanQuyen.Add(phanquyen);
            }
            return LPhanQuyen;
        }
    }
}
