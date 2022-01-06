using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUL
{
    public class PhanQuyen_BUL
    {
        public static List<PhanQuyen_DTO> LoadPhanQuyen()
        {
            return PhanQuyen_DAL.LoadPhanQuyen();
        }
    }
}
