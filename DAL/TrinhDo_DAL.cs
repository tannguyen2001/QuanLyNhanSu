using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class TrinhDo_DAL
    {
        public static List<TrinhDo_DTO> LoadTrinhDo()
        {
            string sTruyVan = @"select * from TrinhDo";
            List<TrinhDo_DTO> trinhDo = new List<TrinhDo_DTO>();
            DataTable dt = DataProvider.TruyVanDataReader(sTruyVan);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TrinhDo_DTO bp = new TrinhDo_DTO();
                bp.MaTrinhDo = int.Parse(dt.Rows[i]["MaTrinhDo"].ToString());
                bp.TenTrinhDo = dt.Rows[i]["TenTrinhDo"].ToString();
                trinhDo.Add(bp);
            }

            return trinhDo;
        }
    }
}
