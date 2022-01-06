using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUL
{
    public class TrinhDo_BUL
    {
        public static List<TrinhDo_DTO> LoadTrinhDo()
        {
            return TrinhDo_DAL.LoadTrinhDo();
        }
    }
}
