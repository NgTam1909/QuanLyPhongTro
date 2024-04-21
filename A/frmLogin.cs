using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongTro.A;

namespace QuanLyPhongTro
{
    public partial class frmLogin : Form
    {
        

        public frmLogin()
        {
            InitializeComponent();
        }
        private string tk="admin", mk="123";
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //if (txtTenDN.Text.Trim() == tk && txtMatKhau.Text.Trim() == mk)
            //{
                this.Hide();
                frmMain f = new frmMain();
                f.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác","Chú ý!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //    txtTenDN.Focus();
            //    return;
            //}
           
        }

        private void btnThoát_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Enter(object sender, EventArgs e)
        {
            if (txtTenDN.Text.Trim() == tk && txtMatKhau.Text.Trim() == mk)
            {
                this.Hide();
                frmMain f = new frmMain();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenDN.Focus();
                return;
            }
        }
    }
}
