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
    public partial class frmThue2 : Form
    {
        private string idHD;
        Database db;
        public frmThue2(string idHD)
        {
            InitializeComponent();
            this.idHD = idHD;
        }

        private void frmThue2_Load(object sender, EventArgs e)
        {
            mtbNgayThue.Text = DateTime.Now.ToString("dd/MM/yyyy");
            mtbNgayTra.Text = DateTime.Now.ToString("dd/MM/yyyy");
            db = new Database();
            loadTTHD();
            var lstPara = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@idHopDong",
                    value = idHD
                }
            };
            var dt = db.SelectData("LoadThongTinHopDong", lstPara).Rows[0];
            cbbPhong.Text = dt["TenPhong"].ToString();
            cbbKhachHang.Text = dt["HoTen"].ToString();
            mtbNgayThue.Text = dt["NgayBatDau"].ToString();
            mtbNgayTra.Text = dt["NgayKetThuc"].ToString();
            txtDatCoc.Text = dt["DatCoc"].ToString();
        }
        private void loadTTHD()
        {
            var dt = db.SelectData("LoadKhach");

            cbbKhachHang.DataSource = dt;
            cbbKhachHang.DisplayMember = "HoTen";
            cbbKhachHang.ValueMember = "ID";
            


            var dr = db.SelectData("LoadPhong");
            cbbPhong.DataSource = dr;
            cbbPhong.DisplayMember = "HoTen";
            cbbPhong.ValueMember = "ID";
            
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (cbbPhong.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn phòng thuê", "Ràng buộc dữ liệu!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var idPhong = cbbPhong.SelectedValue.ToString();

            if (cbbKhachHang.SelectedIndex < 0)
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
                if (ngayTra <= ngayThue)
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
                    key = "@id",
                    value = idHD
                },
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



            if (db.ExeCute("capNhatHD", lsrPara) == 1)

            {
                MessageBox.Show("Cập nhật hợp đồng thành công!", "Successfully!!", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            this.Dispose();
        }
    }
}
