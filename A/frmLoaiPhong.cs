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
    public partial class frmLoaiPhong : Form
    {
        Database db = new Database();
        private int maLoaiPhong;
        private int xacNhan = 0;
        public frmLoaiPhong()
        {
            InitializeComponent();
        }
        public void LoadDSLoaiPhong()
        {
           
            dgvDsLoaiPhong.DataSource = db.SelectData("loadDsLoaiPhong");
        }
        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            btnSua.Enabled = btnThem.Enabled = true;
            btnXacNhan.Enabled = false;

            LoadDSLoaiPhong();
            dgvDsLoaiPhong.Columns[0].Width = 100;
            dgvDsLoaiPhong.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDsLoaiPhong.Columns[0].HeaderText = "Mã loại";
            dgvDsLoaiPhong.Columns[0].Visible = false;

            dgvDsLoaiPhong.Columns[2].Width = 200;
            dgvDsLoaiPhong.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDsLoaiPhong.Columns[2].DefaultCellStyle.Format = "N0";
            dgvDsLoaiPhong.Columns[2].HeaderText = "Đơn giá";

            dgvDsLoaiPhong.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDsLoaiPhong.Columns[1].HeaderText = "Tên loại phòng";

            txtDonGia.ReadOnly = true;
            txtTenLoaiPhong.ReadOnly = true;
        }

        private void frmLoaiPhong_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmLoaiPhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xacNhan = 1;
            txtDonGia.ReadOnly = false;
            txtTenLoaiPhong.ReadOnly = false;

            txtTenLoaiPhong.Text = null;
            txtDonGia.Text = "0";

            btnSua.Enabled = btnThem.Enabled = false;
            btnXacNhan.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xacNhan = -1;
            txtDonGia.ReadOnly = false;
            txtTenLoaiPhong.ReadOnly = false;

            btnSua.Enabled = btnThem.Enabled = false;
            btnXacNhan.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xacNhan = -1;
            if (maLoaiPhong == 0)
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần xóa", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa không??", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var lstPara = new List<CustomParameter>()
                {
                    new CustomParameter()
                    {
                        key = "idLoaiPhong",
                        value = maLoaiPhong.ToString()
                    }
                };
                var rs = db.ExeCute("xoaLoaiPhong", lstPara);
                if (rs == 1)
                {
                    MessageBox.Show("Xóa loại phòng thành công!", "Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDSLoaiPhong();
                    maLoaiPhong = 0;//reset mã loại phòng về gtri mặc định
                }
            }
        }

        private void dgvDsLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maLoaiPhong = int.Parse(dgvDsLoaiPhong.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtTenLoaiPhong.Text = dgvDsLoaiPhong.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDonGia.Text = dgvDsLoaiPhong.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            var tenLoaiPhong = txtTenLoaiPhong.Text.Trim();
            
            //Ràng buộc dữ liệu
            if (string.IsNullOrEmpty(tenLoaiPhong))
            {
                MessageBox.Show("Vui lòng nhập tên loại phòng", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;//Dừng ctring ngang
            }

            
            if(txtDonGia.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đơn giá", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;//Dừng ctring ngang
            }


            var prList = new List<CustomParameter>();
           
            if (xacNhan == 1)//thêm mới 
            {
                prList.Add(new CustomParameter
                {
                    key = "@tenLoaiPhong",
                    value = tenLoaiPhong
                });
                prList.Add(new CustomParameter
                {
                    key = "@donGia",
                    value = int.Parse(txtDonGia.Text).ToString()
                });

                var rs = db.ExeCute("themLoaiPhong", prList);
                if (rs == 1)
                {
                    MessageBox.Show("Thêm mới loại phòng thành công!", "Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (rs == -1)
                {
                    MessageBox.Show("Tên loại phòng đã tồn tại!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if(xacNhan == -1)
            {
                prList.Add(new CustomParameter
                {
                    key = "@idLoaiPhong",
                    value = maLoaiPhong.ToString()
                });
                prList.Add(new CustomParameter
                {
                    key = "@tenLoaiPhong",
                    value = tenLoaiPhong
                });
                prList.Add(new CustomParameter
                {
                    key = "@donGia",
                    value = int.Parse(txtDonGia.Text).ToString()
                });

                var rs = db.ExeCute("capNhatLoaiPhong", prList);
                if (rs == 1)
                {
                    MessageBox.Show("Cập nhật loại phòng thành công!", "Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                else
                {
                    MessageBox.Show("Tên loại phòng đã tồn tại!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            LoadDSLoaiPhong();
            txtDonGia.Text = "0";
            txtTenLoaiPhong.Text = null;
            maLoaiPhong = 0;

            txtDonGia.ReadOnly = true;
            txtTenLoaiPhong.ReadOnly= true;

            btnSua.Enabled = btnThem.Enabled = true;
            btnXacNhan.Enabled = false;
        }

        private void frmLoaiPhong_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmMain f = new frmMain();
            f.Show();
        }
    }
}
