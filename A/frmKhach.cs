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
    public partial class frmKhach : Form
    {
        Database db = new Database();
        public frmKhach()
        {
            InitializeComponent();
        }
        private void LoadDSKhach()
        {

            

            db = new Database();
            var timKiem = txtTenKH.Text.Trim();
            var lstPara = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@timKiem",
                    value = timKiem
                }
            };

            var dt = db.SelectData("LoadDsKhach", lstPara);

            dgvKhach.DataSource = dt;

        }

        private void frmKhach_Load(object sender, EventArgs e)
        {
            LoadDSKhach();
            dgvKhach.Columns[1].HeaderText = "Họ";
            dgvKhach.Columns[2].HeaderText = "Tên";
           
            dgvKhach.Columns[3].HeaderText = "CCCD";
            dgvKhach.Columns[4].HeaderText = "SĐT";
            dgvKhach.Columns[5].HeaderText = "Quê quán";

            dgvKhach.Columns[0].Visible = false;

            dgvKhach.Columns[1].Width = 150;
            dgvKhach.Columns[2].Width = 150;
            dgvKhach.Columns[3].Width = 250;
            dgvKhach.Columns[4].Width = 250;
            dgvKhach.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvKhach.Columns[6].Width = 200;

            
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            new frmKhachMoi(null).ShowDialog();
            LoadDSKhach();
        }

        private int makhach;
        private void dgvKhach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            makhach = e.RowIndex;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDSKhach();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if( makhach < 0)
            {
                MessageBox.Show("Vui lòng chọn khách cần xóa", "Chú ý!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa " + dgvKhach.Rows[makhach].Cells["Ho"].Value.ToString() + " " + dgvKhach.Rows[makhach].Cells["Ten"].Value.ToString() + " không?", "Xác nhận xóa phòng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //truyền giá trị idkhach cần xóa vào proc 
                var lsrPara = new List<CustomParameter>
                {
                    new CustomParameter
                    {
                        key = "@idKhach",
                        value = dgvKhach.Rows[makhach].Cells[0].Value.ToString()
                    }
                };
                var kq = db.ExeCute("xoaKhach", lsrPara);
                if (kq == 1)
                {
                    MessageBox.Show("Xóa khách thành công!", "Successfully!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //sau khi xóa load lại ds khach
                    LoadDSKhach();
                }
            }
        }

        private void dgvKhach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var idkhach = dgvKhach.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            new frmKhachMoi(idkhach).ShowDialog();
            LoadDSKhach();
        }

        private void frmKhach_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmMain f = new frmMain();
            f.Show();
        }
    }
}
