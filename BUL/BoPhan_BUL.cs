using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUL
{
    public class BoPhan_BUL
    {
        public static List<BoPhan_DTO> LoadBoPhan()
        {
            return BoPhan_DAL.LoadBoPhan();
        }
    }
}
