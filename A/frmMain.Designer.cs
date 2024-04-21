namespace QuanLyPhongTro.A
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dịchVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tácVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuâtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.grbContent = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.grbContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(121, 47);
            this.danhMụcToolStripMenuItem.Text = "Loại phòng";
            this.danhMụcToolStripMenuItem.Click += new System.EventHandler(this.danhMụcToolStripMenuItem_Click);
            // 
            // phòngToolStripMenuItem
            // 
            this.phòngToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.phòngToolStripMenuItem.Name = "phòngToolStripMenuItem";
            this.phòngToolStripMenuItem.Size = new System.Drawing.Size(81, 47);
            this.phòngToolStripMenuItem.Text = "Phòng";
            this.phòngToolStripMenuItem.Click += new System.EventHandler(this.phòngToolStripMenuItem_Click);
            // 
            // dịchVụToolStripMenuItem
            // 
            this.dịchVụToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dịchVụToolStripMenuItem.Name = "dịchVụToolStripMenuItem";
            this.dịchVụToolStripMenuItem.Size = new System.Drawing.Size(89, 47);
            this.dịchVụToolStripMenuItem.Text = "Dịch vụ";
            this.dịchVụToolStripMenuItem.Click += new System.EventHandler(this.dịchVụToolStripMenuItem_Click);
            // 
            // kháchToolStripMenuItem1
            // 
            this.kháchToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.kháchToolStripMenuItem1.Name = "kháchToolStripMenuItem1";
            this.kháchToolStripMenuItem1.Size = new System.Drawing.Size(78, 47);
            this.kháchToolStripMenuItem1.Text = "Khách";
            this.kháchToolStripMenuItem1.Click += new System.EventHandler(this.kháchToolStripMenuItem1_Click);
            // 
            // tácVụToolStripMenuItem
            // 
            this.tácVụToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tácVụToolStripMenuItem.Name = "tácVụToolStripMenuItem";
            this.tácVụToolStripMenuItem.Size = new System.Drawing.Size(110, 47);
            this.tácVụToolStripMenuItem.Text = "Hợp đồng";
            this.tácVụToolStripMenuItem.Click += new System.EventHandler(this.tácVụToolStripMenuItem_Click);
            // 
            // đăngXuâtToolStripMenuItem
            // 
            this.đăngXuâtToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.đăngXuâtToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.đăngXuâtToolStripMenuItem.Name = "đăngXuâtToolStripMenuItem";
            this.đăngXuâtToolStripMenuItem.Size = new System.Drawing.Size(112, 47);
            this.đăngXuâtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuâtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuâtToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhMụcToolStripMenuItem,
            this.phòngToolStripMenuItem,
            this.dịchVụToolStripMenuItem,
            this.kháchToolStripMenuItem1,
            this.tácVụToolStripMenuItem,
            this.đăngXuâtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1173, 51);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // grbContent
            // 
            this.grbContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbContent.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grbContent.Controls.Add(this.pictureBox1);
            this.grbContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.grbContent.Location = new System.Drawing.Point(0, 54);
            this.grbContent.Name = "grbContent";
            this.grbContent.Size = new System.Drawing.Size(1173, 522);
            this.grbContent.TabIndex = 4;
            this.grbContent.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::QuanLyPhongTro.Properties.Resources.z5362861026127_5dc39a2b6860f32b6f5caaaa8007ec6f;
            this.pictureBox1.Location = new System.Drawing.Point(0, -12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1173, 534);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1173, 577);
            this.Controls.Add(this.grbContent);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý phòng trọ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grbContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phòngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dịchVụToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tácVụToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuâtToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox grbContent;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}