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
    public partial class frmKhachMoi : Form
    {
        private string idkhach;
        Database db;

        public frmKhachMoi(string idKhach)
        {
            this.idkhach = idKhach;
            InitializeComponent();
        }

       
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            #region set
            var ho = txtHo.Text.Trim();
          
            var ten = txtTen.Text.Trim();
            var cmnd = txtCMND.Text.Trim();
            var sdt = txtSDT.Text.Trim();
            var que = txtQueQuan.Text.Trim();
            var hk = txtHKTT.Text.Trim();
           
            //Ràng buộc dữ liệu
            if (string.IsNullOrEmpty(ho) || string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(cmnd) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(que) || string.IsNullOrEmpty(hk))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng", "Ràng buộc thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;//Dừng ctring ngang
            }

            if (txtCMND.Text.Length != 12)
            {
                MessageBox.Show("Vui lòng nhập lại CCCD ", "Chú ý - CCCD phải có đủ 12 số ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(txtSDT.Text.Length != 10)
            {
                MessageBox.Show("Vui lòng nhập lại SĐT ", "Chú ý - SĐT phải có đủ 10 số ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var prList = new List<CustomParameter>();

            
            #endregion set

            if (string.IsNullOrEmpty(idkhach))
            {
                prList.Add(new CustomParameter
                {
                    key = "@ho",
                    value = ho
                });

                prList.Add(new CustomParameter
                {
                    key = "@ten",
                    value = ten
                });
                prList.Add(new CustomParameter
                {
                    key = "@canCuoc",
                    value = cmnd
                });
                prList.Add(new CustomParameter
                {
                    key = "@sdt",
                    value = sdt
                });
                prList.Add(new CustomParameter
                {
                    key = "@queQuan",
                    value = que
                });
                prList.Add(new CustomParameter
                {
                    key = "@hktt",
                    value = hk
                });
                var rs = db.ExeCute("ThemKH", prList);
                if (rs == 1)
                {
                    MessageBox.Show("Thêm mới khách hàng thành công!", "Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else if (rs == -1)
                {
                    MessageBox.Show("CCCD hoặc SĐT đã tồn tại", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

               
            }
            else
            {
                prList.Add(new CustomParameter
                {
                    key = "@id",
                    value = idkhach
                });
                prList.Add(new CustomParameter
                {
                    key = "@ho",
                    value = ho
                });
                prList.Add(new CustomParameter
                {
                    key = "@ten",
                    value = ten
                });
                prList.Add(new CustomParameter
                {
                    key = "@canCuoc",
                    value = cmnd
                });
                prList.Add(new CustomParameter
                {
                    key = "@sdt",
                    value = sdt
                });
                prList.Add(new CustomParameter
                {
                    key = "@queQuan",
                    value = que
                });
                prList.Add(new CustomParameter
                {
                    key = "@hktt",
                    value = hk
                });
                var kq = db.ExeCute("updateKhach", prList);
                if (kq == 1)
                {
                   
                    MessageBox.Show("Cập nhật khách hàng thành công!!!", "Successfully!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else if (kq == -1)
                {
                    MessageBox.Show("CCCD hoặc SĐT đã tồn tại", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           

        }

        private void frmKhachMoi_Load(object sender, EventArgs e)
        {
            db= new Database();
            if (string.IsNullOrEmpty(idkhach))
            {
                lblTitle.Text = "Thêm khách mới";
            }
            else
            {
                lblTitle.Text = "Cập nhật thông tin khách";
                //vì phòng xác định qua id phòng nên ta truyền vào tham số là giá trị của idphong
                var lstPara = new List<CustomParameter>()
                {
                    new CustomParameter()
                    {
                        key ="@idKhach",
                        value = idkhach
                    }
                };
                //sử dụng hàm select để lấy dữ liệu

                //kết quả trả về là 1 datatable chỉ gồm 1 hàng chính và hàng có chỉ số là 0
                var khach = db.SelectData("selectKhach", lstPara).Rows[0];
                txtHo.Text = khach["Ho"].ToString();
                txtTen.Text = khach["Ten"].ToString();
                txtCMND.Text = khach["CMND_CanCuoc"].ToString();
                txtSDT.Text = khach["DienThoai"].ToString();
                txtQueQuan.Text = khach["QueQuan"].ToString();
                txtHKTT.Text = khach["HKTT"].ToString();

            }

        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là số hay không.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Ngăn chặn việc nhập ký tự đó.
                e.Handled = true;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là số hay không.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Ngăn chặn việc nhập ký tự đó.
                e.Handled = true;
            }
        }
    }
}