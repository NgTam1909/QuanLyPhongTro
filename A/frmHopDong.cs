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
    public partial class frmHopDong : Form
    {
        Database db;
        private int rowIndex = -1;
        public frmHopDong()
        {
           
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            new frmThue().ShowDialog();
            LoadDsHopDong();

        }

        private void LoadDsHopDong()
        {
            db = new Database();
            List<CustomParameter> list = new List<CustomParameter>
            {
                new CustomParameter
                {
                    key = "@tuKhoa",
                    value = txtTuKhoa.Text
                }
            };
            dgvKhach.AutoGenerateColumns = false;
            dgvKhach.DataSource = db.SelectData("LoadDsHopDong", list);
           
            
        }

        private void frmHopDong_Load(object sender, EventArgs e)
        {
            db = new Database();
            LoadDsHopDong();
          

        }
        

       

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDsHopDong();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //kiểm tra xem rowIndex có <0 k
            //nếu <0 nghĩa là chưa chon
            if (rowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần xóa", "Chú ý!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa hợp đồng không?", "Xác nhận xóa phòng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //truyền giá trị id hợp đồng cần xóa vào proc 
                var lsrPara = new List<CustomParameter>
                {
                    new CustomParameter
                    {
                        key = "@idHopDong",
                        value = dgvKhach.Rows[rowIndex].Cells["ID"].Value.ToString()
                    }
                };
                var kq = db.ExeCute("xoaHopDong", lsrPara);
                if (kq == 1)
                {
                    MessageBox.Show("Xóa hợp đồng thành công!", "Successfully!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //sau khi xóa load lại ds hợp đồng
                    LoadDsHopDong();
                }
            }
        }

        private void dgvKhach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }
        
        private void frmHopDong_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmMain f = new frmMain();
            f.Show();
        }

        private void dgvKhach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var idHD = dgvKhach.Rows[e.RowIndex].Cells["ID"].Value.ToString();
           new frmThue2(idHD).ShowDialog();
            LoadDsHopDong();
        }
    }
}
