using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace QuanLyPhongTro.A
{

    public partial class frmXuLyPhong : Form
    {
        private string idPhong;
        public frmXuLyPhong(string idPhong)
        {
            this.idPhong = idPhong;
            InitializeComponent();
           
        }
        Database db;
        private void frmXuLyPhong_Load(object sender, EventArgs e)
        {
            db = new Database();
            LoadLoaiPhong();
            if (string.IsNullOrEmpty(idPhong))
            {
                lblTitle.Text = "Thêm mới phòng";
            }
            else
            {
                lblTitle.Text = "Cập nhật thông tin phòng";
                //vì phòng xác định qua id phòng nên ta truyền vào tham số là giá trị của idphong
                var lstPara = new List<CustomParameter>()
                {
                    new CustomParameter()
                    {
                        key ="@idPhong",
                        value = idPhong
                    }
                };
                //sử dụng hàm select để lấy dữ liệu

                //kết quả trả về là 1 datatable chỉ gồm 1 hàng chính và hàng có chỉ số là 0
                var phong = db.SelectData("selectPhong", lstPara).Rows[0];
                // set các dữ liệu lấy đc cho các component trên form frmXuLyPhong 

                cbbLoaiPhong.SelectedValue = phong["IDLoaiPhong"].ToString();//set idphong cho combobox
                txtTenPhong.Text = phong["TenPhong"].ToString();//set giá trị trên phòng cho textbox txtTenPhong
                if (phong["trangthai"].ToString() == "1")//set trạng thái hoạt động cho checkbox ckbHoatDong 
                {
                    ckbHoatDong.Checked = true;
                }
                else
                {
                    ckbHoatDong.Checked = false;
                }
            }
        }

        private void LoadLoaiPhong()
        {
            var dt = db.SelectData("loadDsLoaiPhong");
            cbbLoaiPhong.DataSource = dt;
            cbbLoaiPhong.DisplayMember = "TenLoaiPhong";
            cbbLoaiPhong.ValueMember = "ID";
            cbbLoaiPhong.SelectedIndex = -1;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (cbbLoaiPhong.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại phòng", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;//DỪng ctring ngang
            }

            var idLoaiPhong = cbbLoaiPhong.SelectedValue.ToString();
            var tenPhong = txtTenPhong.Text;
            var trangThai = ckbHoatDong.Checked ? 1 : 0;

            if (string.IsNullOrEmpty(tenPhong))
            {
                MessageBox.Show("Vui lòng nhập tên phòng", "Ràng buộc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPhong.Select();
                return;
            }

            if (string.IsNullOrEmpty(idPhong))//Trường hợp thêm mới phòng không có id phòng <=> null
            {
               
                var lstPara = new List<CustomParameter>(){
                new CustomParameter()
                {
                    key = "@idLoaiPhong",
                    value = idLoaiPhong
                },
                new CustomParameter()
                {
                    key = "@tenPhong",
                    value = tenPhong
                },
               
                new CustomParameter()
                {
                    key = "@trangThai",
                    value = trangThai.ToString()
                }
            };
                var rs = db.ExeCute("[themMoiPhong]", lstPara);
                if (rs == 1)
                {
                    MessageBox.Show("Thêm mới phòng thành công!!!", "Successfully!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //reset lại giá trị của các compoment sau khi thêm mới thành công
                    txtTenPhong.Text = null;
                    cbbLoaiPhong.SelectedIndex = 0;
                }
                if (rs == -1)
                {
                    MessageBox.Show("Tên phòng đã tồn tại!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //reset lại giá trị của các compoment sau khi thêm mới thành công
                    txtTenPhong.Text = null;
                    cbbLoaiPhong.SelectedIndex = 0;
                }
            }
            else//cập nhật thông tin loại phòng 
            {
                //xử lý trường hợp cập nhật khi clixk vào Xác nhận
                //bên proc có 4 tham số đầu vào
                //vì vậy ở đây của ta cũng phải truyền vào 4 tham số thương ứng
                var lstpara = new List<CustomParameter>()
                {
                    new CustomParameter()
                    {
                        key = "@idPhong",
                        value = idPhong
                    },
                    new CustomParameter()
                    {
                        key ="@tenPhong",
                        value = txtTenPhong.Text
                    },
                    new CustomParameter()
                    {
                        key = "@idLoaiPhong",
                        value = cbbLoaiPhong.SelectedValue.ToString()
                    },
                    new CustomParameter()
                    {
                        key = "@trangThai",
                        value = trangThai.ToString()    
                    }
                };
                var kq = db.ExeCute("updatePhong", lstpara);
                if (kq == 1)
                {
                    MessageBox.Show("Cập nhật phòng thành công!!!", "Successfully!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Tên phòng đã tồn tại!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }

            }


        }





    }
}
