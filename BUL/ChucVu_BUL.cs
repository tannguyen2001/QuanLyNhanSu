using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUL
{
    public class ChucVu_BUL
    {
        public static List<ChucVu_DTO> LoadChucVu()
        {
            return ChucVu_DAL.LoadChucVu();
        }
    }
}
