using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class ChucVu_DAL
    {
        public static List<ChucVu_DTO> LoadChucVu()
        {
            string sTruyVan = @"select * from ChucVu";
            List<ChucVu_DTO> chucVu = new List<ChucVu_DTO>();
            DataTable dt = DataProvider.TruyVanDataReader(sTruyVan);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChucVu_DTO bp = new ChucVu_DTO();
                bp.MaChucVu = int.Parse(dt.Rows[i]["MaChucVu"].ToString());
                bp.TenChucVu = dt.Rows[i]["TenChucVu"].ToString();
                chucVu.Add(bp);
            }

            return chucVu;
        }
    }
}
