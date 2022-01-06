using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class BoPhan_DAL
    {
        public static List<BoPhan_DTO> LoadBoPhan()
        {
            string sTruyVan = @"select * from BoPhan";
            List<BoPhan_DTO> bophan = new List<BoPhan_DTO>();
            DataTable dt = DataProvider.TruyVanDataReader(sTruyVan);
            for(int i=0;i<dt.Rows.Count;i++)
            {
                BoPhan_DTO bp = new BoPhan_DTO();
                bp.MaBP = int.Parse(dt.Rows[i]["MaBP"].ToString());
                bp.TenBP = dt.Rows[i]["TenBP"].ToString();
                bophan.Add(bp);
            }
            return bophan;
        }
    }
}
