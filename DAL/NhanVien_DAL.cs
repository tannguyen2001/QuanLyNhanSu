using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class NHANVIEN_DAL
    {
        //Phương thức xử lý load nhân viên
        public static List<NhanVien_DTO> LoadNhanVien()
        {
            string sChuoiTruyVan = "select MaNV as N'Mã NV',HoLot as N'Họ',Ten as N'Tên',CMND,GioiTinh as N'Giới tính',NgaySinh as N'Ngày sinh',HinhAnh as N'Hình ảnh',DiaChi as N'Địa chỉ',DienThoai as N'Điện thoại',DaThoiViec as N'Đã thôi việc',MaBP as N'Mã bộ phận',MaChucVu as N'Mã chức vụ',MaTrinhDo as N'Mã trình độ' from NhanVien";
            DataTable dt = DataProvider.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count>0) //Nếu datatable hợp lệ và có giá trị
            {
                List<NhanVien_DTO> lstNhanVienDTO = new List<NhanVien_DTO>();
                NhanVien_DTO nvDTO;
                for (int i = 0; i < dt.Rows.Count; i++) //Duyệt datatable và đưa vào list đối tượng NHANVIEN_DTO
                {
                    nvDTO = new NhanVien_DTO();
                    nvDTO.MaNV = dt.Rows[i]["Mã NV"].ToString();
                    nvDTO.CMND = dt.Rows[i]["CMND"].ToString();
                    nvDTO.HoLot = dt.Rows[i]["Họ"].ToString();
                    nvDTO.Ten = dt.Rows[i]["Tên"].ToString();
                    nvDTO.GioiTinh = dt.Rows[i]["Giới tính"].ToString()=="True"?"Nam":"Nữ";
                    nvDTO.NgaySinh = dt.Rows[i]["Ngày sinh"].ToString();
                    nvDTO.DienThoai = dt.Rows[i]["Điện thoại"].ToString();
                    nvDTO.DiaChi = dt.Rows[i]["Địa chỉ"].ToString();
                    nvDTO.MaTrinhDo = Convert.ToInt32(dt.Rows[i]["Mã trình độ"]);
                    nvDTO.DaThoiViec = dt.Rows[i]["Đã thôi việc"].ToString();
                    nvDTO.HinhAnh = dt.Rows[i]["Hình ảnh"].ToString();
                    nvDTO.MaChucVu = Convert.ToInt32(dt.Rows[i]["Mã chức vụ"]);
                    nvDTO.MaBP = Convert.ToInt32(dt.Rows[i]["Mã bộ phận"]);
                    //add nhân viên vào lstNhanVien_DTO
                    lstNhanVienDTO.Add(nvDTO);
                }
                return lstNhanVienDTO;
            }
            return null;
        }

        //Phương thức xử lý Thêm nhân viên
        public static bool ThemNhanVien(NhanVien_DTO nvDTO)
        {
            //Bước 4: Tạo truy vấn và gọi về phương thức xử lý của class Dataprovider.TruyVanExcuteNonQuery
            string sChuoiTruyVan = string.Format("INSERT INTO NHANVIEN(MaNV,HoLot,Ten,CMND,GioiTinh,NgaySinh,HinhAnh,DiaChi,DienThoai,DaThoiViec,MaBP,MaChucVu,MaTrinhDo) VALUES (N'{0}',N'{1}',N'{2}',N'{3}',{4},'{5}',N'{6}',N'{7}',N'{8}',{9},{10},{11},{12})",nvDTO.MaNV, nvDTO.HoLot,nvDTO.Ten,nvDTO.CMND,nvDTO.GioiTinh=="True"?1:0,DateTime.Parse(nvDTO.NgaySinh),nvDTO.HinhAnh,nvDTO.DiaChi,nvDTO.DienThoai,nvDTO.DaThoiViec=="True"?1:0,nvDTO.MaBP,nvDTO.MaChucVu,nvDTO.MaTrinhDo);
            bool ketQua = DataProvider.TruyVanExecuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }

        //Phương thức cập nhật dữ liệu nhân viên
        public static bool SuaNhanVien(NhanVien_DTO nvDTO,string MaNVCU)
        {
            string sChuoiTruyVan = string.Format("UPDATE NHANVIEN SET MaNV=N'{0}',HoLot=N'{1}',Ten=N'{2}',CMND=N'{3}',GioiTinh={4},NgaySinh='{5}',HinhAnh=N'{6}',DiaChi=N'{7}',DienThoai=N'{8}',DaThoiViec={9},MaBP={10},MaChucVu={11},MaTrinhDo={12} where MaNV =N'{13}'", nvDTO.MaNV, nvDTO.HoLot, nvDTO.Ten, nvDTO.CMND, nvDTO.GioiTinh == "True" ? 1 : 0, DateTime.Parse(nvDTO.NgaySinh), nvDTO.HinhAnh, nvDTO.DiaChi, nvDTO.DienThoai, nvDTO.DaThoiViec == "True" ? 1 : 0, nvDTO.MaBP, nvDTO.MaChucVu, nvDTO.MaTrinhDo,MaNVCU);
            bool ketQua = DataProvider.TruyVanExecuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        //Phương thức xóa nhân viên
        public static bool XoaNhanVien(string MaNV)
        {
            string sChuoiTruyVan = string.Format("DELETE FROM NHANVIEN WHERE MaNV=N'{0}'", MaNV);
            bool ketQua = DataProvider.TruyVanExecuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        //Phương thức xử lý tìm kiếm nhân viên
        public static List<NhanVien_DTO> TimNhanVien(string TenNV,int MaBoPhan=-1)
        {
            string sChuoiTruyVan = "";
            if(MaBoPhan == -1)
            {
                sChuoiTruyVan = string.Format(@"select * From NhanVien where Ten Like N'%{0}%'", TenNV);
            }
            else
            {
                sChuoiTruyVan = string.Format(@"select * From NhanVien where Ten Like N'%{0}%' and MaBP = {1}", TenNV,MaBoPhan);
            }
            DataTable dt = DataProvider.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0) //Nếu datatable hợp lệ và có giá trị
            {
                List<NhanVien_DTO> lstNhanVienDTO = new List<NhanVien_DTO>();
                NhanVien_DTO nvDTO;
                for (int i = 0; i < dt.Rows.Count; i++) //Duyệt datatable và đưa vào list đối tượng NHANVIEN_DTO
                {
                    nvDTO = new NhanVien_DTO();
                    nvDTO.MaNV = dt.Rows[i]["MaNV"].ToString();
                    nvDTO.CMND = dt.Rows[i]["CMND"].ToString();
                    nvDTO.HoLot = dt.Rows[i]["HoLot"].ToString();
                    nvDTO.Ten = dt.Rows[i]["Ten"].ToString();
                    nvDTO.GioiTinh = dt.Rows[i]["GioiTinh"].ToString() == "True" ? "Nam" : "Nữ";
                    nvDTO.NgaySinh = dt.Rows[i]["NgaySinh"].ToString();
                    nvDTO.DienThoai = dt.Rows[i]["DienThoai"].ToString();
                    nvDTO.DiaChi = dt.Rows[i]["DiaChi"].ToString();
                    nvDTO.MaTrinhDo = Convert.ToInt32(dt.Rows[i]["MaTrinhDo"]);
                    nvDTO.DaThoiViec = dt.Rows[i]["DaThoiViec"].ToString();
                    nvDTO.HinhAnh = dt.Rows[i]["HinhAnh"].ToString();
                    nvDTO.MaChucVu = Convert.ToInt32(dt.Rows[i]["MaChucVu"]);
                    nvDTO.MaBP = Convert.ToInt32(dt.Rows[i]["MaBP"]);
                    //add nhân viên vào lstNhanVien_DTO
                    lstNhanVienDTO.Add(nvDTO);
                }
                return lstNhanVienDTO;
            }
            return null;
        }
    }
}