using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro.A
{
   
    public partial class frmPhong : Form
    {
        Database db;
        private int rowIndex = -1;
        public frmPhong()
        {
            
            InitializeComponent();
        }
        
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
           new frmXuLyPhong(null).ShowDialog();
            LoadDsPhong();
        }

        private void LoadDsPhong()
        {
            db = new Database();
            var timKiem = txtTimKiem.Text.Trim();
            var lstPara = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@timKiem",
                    value = timKiem
                }
            };

            var dt = db.SelectData("LoadDsPhong", lstPara);

            dgvPhong.DataSource = dt;
        }

        private void frmPhong_Load(object sender, EventArgs e)
        {
            LoadDsPhong();
            //Đặt lạt tên cột
            dgvPhong.Columns["id"].HeaderText = "ID";
            dgvPhong.Columns["tenloaiphong"].HeaderText = "Loại phòng";
            dgvPhong.Columns["tenphong"].HeaderText = "Phòng";
            dgvPhong.Columns["dongia"].HeaderText = "Đơn giá";
            dgvPhong.Columns["trangthai"].HeaderText = "Trạng thái";

            //set kích thước các cột

            dgvPhong.Columns["id"].Width = 150;
            dgvPhong.Columns["id"].Visible = false;
            dgvPhong.Columns["tenloaiphong"].Width = 250;
            dgvPhong.Columns["dongia"].Width = 250;
            dgvPhong.Columns["trangthai"].Width = 300;

            dgvPhong.Columns["tenphong"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;//cho cột tên phòng tự động co dãn theo form

            //Căn chỉnh vị trí các cột
            dgvPhong.Columns["dongia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;//Căn phải vho cột đơn giá

            //Định dạng phần nghìn cho cột đơn giá phòng
            dgvPhong.Columns["dongia"].DefaultCellStyle.Format = "N0";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //kiểm tra xem rowIndex có <0 k
            //nếu <0 nghĩa là chưa chon
            if (rowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa", "Chú ý!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa " + dgvPhong.Rows[rowIndex].Cells["tenphong"].Value.ToString() + " không?", "Xác nhân xóa phòng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //truyền giá trị id phòng cần xóa vào proc 
                var lsrPara = new List<CustomParameter>
                {
                    new CustomParameter
                    {
                        key = "idPhong",
                        value = dgvPhong.Rows[rowIndex].Cells["ID"].Value.ToString()
                    }
                };
                var kq = db.ExeCute("deletePhong", lsrPara);
                if (kq == 1)
                {
                    MessageBox.Show("Xóa phòng thành công!", "Successfully!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //sau khi xóa load lại ds phòng
                    LoadDsPhong();
                }
            }
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // laays id phongf caanf xoas trong sk cell ckick cuar datagridview
            rowIndex = e.RowIndex;
        }


        private void dgvPhong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var idPhong = dgvPhong.Rows[e.RowIndex].Cells["id"].Value.ToString();
            new frmXuLyPhong(idPhong).ShowDialog();
            LoadDsPhong();

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDsPhong();
        }

        private void frmPhong_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmMain f = new frmMain();
            f.Show();
        }
    }
}
