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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void AddForm(Form f)
        {
            this.grbContent.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.grbContent.Controls.Add(f);
            f.Show();
        }
     

        private void đăngXuâtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin f = new frmLogin();    
            f.Show();
        }

      
     

  

        private void tácVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grbContent.Text = "Quản lý hợp đồng";
            frmHopDong f = new frmHopDong();
            AddForm(f);

        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grbContent.Text = "Quản lý loại phòng";
            frmLoaiPhong f = new frmLoaiPhong();
            AddForm(f);
        }

        private void phòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grbContent.Text = "Quản lý phòng";
            frmPhong f = new frmPhong();
            AddForm(f);
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grbContent.Text = "Quản lý dịch vụ";
            frmDichVu f = new frmDichVu();
            AddForm(f);
        }

        private void kháchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            grbContent.Text = "Quản lý khách";
            frmKhach f = new frmKhach();
            AddForm(f);
        }
    }
}
