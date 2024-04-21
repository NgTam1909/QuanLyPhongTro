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
    public partial class frmDichVu : Form
    {
        Database db;
        private int xacNhan;
        public frmDichVu()
        {
            InitializeComponent();
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            LoadDsDV();
            
            dgvDichVu.Columns[1].HeaderText = "Tên dịch vụ";
            dgvDichVu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDichVu.Columns[2].HeaderText = "Giá";
            dgvDichVu.Columns[0].Visible = false;
            dgvDichVu.Columns[2].Width = 500;

        }
        private void LoadDsDV()
        {
            db = new Database();
            

            var dt = db.SelectData("LoadDsDv");

            dgvDichVu.DataSource = dt;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDsDV();
         

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xacNhan = 1;
            txtGia.Text = "0";
            txtTenDV.Text = null;

            txtTenDV.ReadOnly = false;
            txtGia.ReadOnly = false;

            btnCapNhat.Enabled = btnThem.Enabled = false;
            btnXacNhan.Enabled = true;


        }
        int id = -1;

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = int.Parse(dgvDichVu.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtTenDV.Text = dgvDichVu.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            xacNhan = -1;
            if (id < 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần cập nhật!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtTenDV.ReadOnly = false;
            txtGia.ReadOnly = false;

            btnCapNhat.Enabled = btnThem.Enabled = false;
            btnXacNhan.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (id < 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var lstPara = new List<CustomParameter>()
                 {
                 new CustomParameter()
                    {
                    key = "@id",
                    value = id.ToString(),
                    }
                 };
                if (db.ExeCute("XoaDV", lstPara) == 1)
                {
                    MessageBox.Show("Xóa dịch vụ thành công", "Successfully!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDsDV();
                    txtTenDV.Text = null;
                    id = -1;

                }
               LoadDsDV() ;
            }

        }

        private void frmDichVu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmMain f = new frmMain();
            f.Show();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
           
            var tendv = txtTenDV.Text.Trim();
            var gia = int.Parse(txtGia.Text.Trim());
            if (string.IsNullOrEmpty(tendv))
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập giá dịch vụ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (xacNhan == 1)//Thêm mới
            {
                var lstPara = new List<CustomParameter>()
                {
                new CustomParameter()
                    {
                    key = "@tenDV",
                    value = txtTenDV.Text

                    },
                new CustomParameter()
                    {
                    key = "@gia",
                    value = txtGia.Text
                    }
                };
                if (db.ExeCute("ThemDV", lstPara) == 1)
                {
                    MessageBox.Show("Thêm mới dịch vụ thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tên dịch vụ đã tồn tại!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if(xacNhan == -1)//Xác nhận
            {
                var lstPara = new List<CustomParameter>()
            {
                 new CustomParameter()
                {
                    key = "@id",
                    value = id.ToString(),
                },
                new CustomParameter()
                {
                    key = "@tenDV",
                    value = txtTenDV.Text,
                },
                 new CustomParameter()
                {
                    key = "@gia",
                    value = txtGia.Text
                }
            };
                if (db.ExeCute("CapNhatDV", lstPara) == 1)
                {
                    MessageBox.Show("Cập nhật dịch vụ thành công", "Successfully!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (db.ExeCute("CapNhatDV", lstPara) == -1)
                {
                    MessageBox.Show("Cập nhật dịch vụ thất bại", "Chú ý!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
            }
            LoadDsDV();
            id = -1;
            txtGia.Text = "0";
            txtTenDV.Text = null;

            txtTenDV.ReadOnly = true;
            txtGia.ReadOnly = true;

            btnCapNhat.Enabled = btnThem.Enabled = true;
            btnXacNhan.Enabled = false;
        }
    }
}
