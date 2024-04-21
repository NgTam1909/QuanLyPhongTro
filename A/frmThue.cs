using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro.A
{
    public partial class frmThue : Form
    {
        Database db;
        public frmThue()
        {
            InitializeComponent();
        }

        private void LoadDSKH()
        {
            db = new Database();
            

            var dt = db.SelectData("LoadKhach");

            cbbKhachHang.DataSource = dt;
            cbbKhachHang.DisplayMember = "HoTen";
            cbbKhachHang.ValueMember = "ID";
            cbbKhachHang.SelectedIndex = -1;


            var dr = db.SelectData("LoadPhong");
            cbbPhong.DataSource = dr;
            cbbPhong.DisplayMember = "HoTen";
            cbbPhong.ValueMember = "ID";
            cbbPhong.SelectedIndex = -1;

          

        }
        private void button3_Click(object sender, EventArgs e)
        {
            new frmKhachMoi(null).Show();
            LoadDSKH();
        }
       

        private void frmThue_Load(object sender, EventArgs e)
        {
            LoadDSKH();

            mtbNgayThue.Text = DateTime.Now.ToString("dd/MM/yyyy");
            mtbNgayTra.Text = DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(cbbPhong.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn phòng thuê","Ràng buộc dữ liệu!!!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var idPhong = cbbPhong.SelectedValue.ToString();

            if(cbbKhachHang.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn khách", "Ràng buộc dữ liệu!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idKhach = cbbKhachHang.SelectedValue.ToString();
            

            DateTime ngayThue, ngayTra;
            try
            {
                 ngayThue = DateTime.ParseExact(mtbNgayThue.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                 ngayTra = DateTime.ParseExact(mtbNgayTra.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if(ngayTra <= ngayThue)
                {
                    MessageBox.Show("Ngày thuê không được nhỏ hơn hoặc bằng ngày trả", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Ngày thuê hoặc ngày trả không hợp lệ");
                return;
            }
            var datCoc = int.Parse(txtDatCoc.Text);



            var lsrPara = new List<CustomParameter>
            {
                new CustomParameter
                {
                    key = "@idPhong",
                    value = idPhong
                },
                 new CustomParameter
                {
                    key = "@idkhach",
                    value = idKhach
                },
                  new CustomParameter
                {
                    key = "@ngayBatDau",
                    value = ngayThue.ToString()
                },
                new CustomParameter
                {
                    key = "@ngayKetThuc",
                    value = ngayTra.ToString()
                },
                new CustomParameter()
                {
                    key = "@datCoc",
                    value = datCoc.ToString()
                }
            };
         

           
            if ( db.ExeCute("TaoMoiHD", lsrPara) == 1)

            {
                MessageBox.Show("Tạo mới hợp đồng thành công!","Successfully!!",MessageBoxButtons.OK, MessageBoxIcon.Information);
               
              
            }
            this.Dispose();
        }

        private void txtDatCoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
