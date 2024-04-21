using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public class Database
    {
        //private SqlConnection conn = new SqlConnection(@"Data Source=THANH\SQLEXPRESS;Initial Catalog=QLPhongTro;Integrated Security=True;");
        private SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\QLPhongTro.mdf;Integrated Security=True;User Instance=True");
        
        private DataTable dt;
        private SqlCommand cmd;
        
        public DataTable SelectData(string sql, List<CustomParameter> lstPara = null)
        {
            try
            {
                
                conn.Open();//mở kết nối
                cmd = new SqlCommand(sql, conn);//nội dung sql đc truyền vào
                cmd.CommandType = CommandType.StoredProcedure;//set command type cho cmd
                if (lstPara != null)
                {
                    foreach (var para in lstPara)//gán các tham số cho cmd
                    {
                        cmd.Parameters.AddWithValue(para.key, para.value);
                    }

                }

                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi câu lệnh: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();//cuối cùng đóng kết nối
            }

        }

        

        public int ExeCute(string sql, List<CustomParameter> lstPara = null)
        {
            try
            {
                conn.Open();//mở kết nối
                cmd = new SqlCommand(sql, conn);//thực thi câu lệnh sql
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var p in lstPara)//gán các tham số cho cmd
                {
                    cmd.Parameters.AddWithValue(p.key, p.value);
                }
                var rs = cmd.ExecuteNonQuery();//lấy kết quả thực thi truy vấn
                return (int)rs;//trả về kết quả
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi câu lệnh: " + ex.Message);
                return -1;
            }
            finally
            {
                conn.Close();//cuối cùng đóng kết nối
            }
        }

        public DataRow Select(string sql)
        {
            try
            {
                conn.Open();//mở kết nối
                cmd = new SqlCommand(sql,   conn);//truyền giá trị vào cmd
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());//thực thi câu lệnh
                return dt.Rows[0];//trả về kết quả
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load thông tin chi tiết: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();//cuối cùng đóng kết nối
            }
        }
    }
    public class CustomParameter
    {
        public string key { get; set; }
        public string value { get; set; }
    }
}
