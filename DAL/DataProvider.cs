using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataProvider
    {
        //Phương thức dùng để mở kết nối đến csdl 
        public static SqlConnection KetNoi()
        {
            string sChuoiKetNoi = "Data Source=DESKTOP-R3A7ROH\\VANTAN;Initial Catalog=QuanLyNhanSu;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sChuoiKetNoi);
            conn.Open();
            return conn;
        }
        //Phương thức ngắt kết nối

        public static void  NgatKetNoi(SqlConnection conn)
        {
            conn.Close();
        }
        //Phương thức truy vấn đến cơ sở dữ liệu trả về kết quả là datatable ("thường ứng với câu lệnh select")
        public static DataTable TruyVanDataReader(string sChuoiTruyVan)
        {
            SqlConnection conn = KetNoi();
            try
            {
               // SqlCommand cmd = new SqlCommand(sChuoiTruyVan, conn);
                SqlDataAdapter da = new SqlDataAdapter(sChuoiTruyVan, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                NgatKetNoi(conn);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                NgatKetNoi(conn);
                return null;
            }
        }
        //Phương thức thực hiện các câu lệnh truy vấn như insert, update, delete
        public static bool TruyVanExecuteNonQuery(string sChuoiTruyVan)
        {
            SqlConnection conn = KetNoi();
            try
            {
                SqlCommand cmd = new SqlCommand(sChuoiTruyVan, conn);
                int iCMD = cmd.ExecuteNonQuery();
                NgatKetNoi(conn);
                if (iCMD > 0)
                {
                    return true; //Truy vấn thành công
                }
                else
                {
                    return false; //Thất bại
                }
            }
            catch (Exception ex)
            {
                NgatKetNoi(conn);
                return false;
            }
        }
        //Phương thức trả về 1 giá trị 
        public static string TruyVanExecuteScalar(string sChuoiTruyVan)
        {
            SqlConnection conn = KetNoi();
            try
            {
                SqlCommand cmd = new SqlCommand(sChuoiTruyVan,conn);
                string sKQ = cmd.ExecuteScalar().ToString();
                NgatKetNoi(conn);
                return sKQ;
            }
            catch (Exception ex)
            {
                NgatKetNoi(conn);
                return null;
            }
        }
    }
}
