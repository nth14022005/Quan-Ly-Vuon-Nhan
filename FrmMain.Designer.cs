namespace QLVuonNhan
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.mnuQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoVuon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCayNhan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGiongNhan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVatTu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThuHoach = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCongViec = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNguoiDung = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVaiTro = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAccount = new System.Windows.Forms.Button();
            this.cmsAccount = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAccInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAccLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAccExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.cmsAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuQuanLy,
            this.mnuCongViec,
            this.mnuHeThong});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1200, 36);
            this.menuMain.TabIndex = 3;
            this.menuMain.Text = "MenuStrip";
            // 
            // mnuQuanLy
            // 
            this.mnuQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLoVuon,
            this.mnuCayNhan,
            this.mnuGiongNhan,
            this.mnuVatTu,
            this.mnuThuHoach});
            this.mnuQuanLy.Name = "mnuQuanLy";
            this.mnuQuanLy.Size = new System.Drawing.Size(89, 32);
            this.mnuQuanLy.Text = "Quản lý";
            // 
            // mnuLoVuon
            // 
            this.mnuLoVuon.Name = "mnuLoVuon";
            this.mnuLoVuon.Size = new System.Drawing.Size(206, 34);
            this.mnuLoVuon.Text = "Lô vườn";
            this.mnuLoVuon.Click += new System.EventHandler(this.mnuLoVuon_Click);
            // 
            // mnuCayNhan
            // 
            this.mnuCayNhan.Name = "mnuCayNhan";
            this.mnuCayNhan.Size = new System.Drawing.Size(206, 34);
            this.mnuCayNhan.Text = "Cây nhãn";
            this.mnuCayNhan.Click += new System.EventHandler(this.mnuCayNhan_Click);
            // 
            // mnuGiongNhan
            // 
            this.mnuGiongNhan.Name = "mnuGiongNhan";
            this.mnuGiongNhan.Size = new System.Drawing.Size(206, 34);
            this.mnuGiongNhan.Text = "Giống nhãn";
            this.mnuGiongNhan.Click += new System.EventHandler(this.mnuGiongNhan_Click);
            // 
            // mnuVatTu
            // 
            this.mnuVatTu.Name = "mnuVatTu";
            this.mnuVatTu.Size = new System.Drawing.Size(206, 34);
            this.mnuVatTu.Text = "Vật tư";
            this.mnuVatTu.Click += new System.EventHandler(this.mnuVatTu_Click);
            // 
            // mnuThuHoach
            // 
            this.mnuThuHoach.Name = "mnuThuHoach";
            this.mnuThuHoach.Size = new System.Drawing.Size(206, 34);
            this.mnuThuHoach.Text = "Thu hoạch";
            // 
            // mnuCongViec
            // 
            this.mnuCongViec.Name = "mnuCongViec";
            this.mnuCongViec.Size = new System.Drawing.Size(186, 32);
            this.mnuCongViec.Text = "Công việc chăm sóc";
            this.mnuCongViec.Click += new System.EventHandler(this.mnuCongViecChamSoc_Click);
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNguoiDung,
            this.mnuVaiTro});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(106, 32);
            this.mnuHeThong.Text = "Hệ Thống";
            // 
            // mnuNguoiDung
            // 
            this.mnuNguoiDung.Name = "mnuNguoiDung";
            this.mnuNguoiDung.Size = new System.Drawing.Size(213, 34);
            this.mnuNguoiDung.Text = "Người Dùng";
            this.mnuNguoiDung.Click += new System.EventHandler(this.mnuNguoiDung_Click);
            // 
            // mnuVaiTro
            // 
            this.mnuVaiTro.Name = "mnuVaiTro";
            this.mnuVaiTro.Size = new System.Drawing.Size(213, 34);
            this.mnuVaiTro.Text = "Vai Trò";
            // 
            // btnAccount
            // 
            this.btnAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccount.Location = new System.Drawing.Point(828, 0);
            this.btnAccount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(212, 33);
            this.btnAccount.TabIndex = 1;
            this.btnAccount.Text = "Đăng nhập... ▼";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // cmsAccount
            // 
            this.cmsAccount.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsAccount.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAccInfo,
            this.mnuAccLogout,
            this.mnuAccExit});
            this.cmsAccount.Name = "cmsAccount";
            this.cmsAccount.Size = new System.Drawing.Size(194, 100);
            // 
            // mnuAccInfo
            // 
            this.mnuAccInfo.Enabled = false;
            this.mnuAccInfo.Name = "mnuAccInfo";
            this.mnuAccInfo.Size = new System.Drawing.Size(193, 32);
            this.mnuAccInfo.Text = "Đăng nhập: ...";
            // 
            // mnuAccLogout
            // 
            this.mnuAccLogout.Name = "mnuAccLogout";
            this.mnuAccLogout.Size = new System.Drawing.Size(193, 32);
            this.mnuAccLogout.Text = "Đăng xuất";
            // 
            // mnuAccExit
            // 
            this.mnuAccExit.Name = "mnuAccExit";
            this.mnuAccExit.Size = new System.Drawing.Size(193, 32);
            this.mnuAccExit.Text = "Thoát";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.btnAccount);
            this.Controls.Add(this.menuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMain;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QL Vườn Nhãn";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.cmsAccount.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanLy;
        private System.Windows.Forms.ToolStripMenuItem mnuLoVuon;
        private System.Windows.Forms.ToolStripMenuItem mnuCayNhan;
        private System.Windows.Forms.ToolStripMenuItem mnuGiongNhan;
        private System.Windows.Forms.ToolStripMenuItem mnuVatTu;
        private System.Windows.Forms.ToolStripMenuItem mnuThuHoach;
        private System.Windows.Forms.ToolStripMenuItem mnuCongViec;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuNguoiDung;
        private System.Windows.Forms.ToolStripMenuItem mnuVaiTro;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.ContextMenuStrip cmsAccount;
        private System.Windows.Forms.ToolStripMenuItem mnuAccInfo;
        private System.Windows.Forms.ToolStripMenuItem mnuAccLogout;
        private System.Windows.Forms.ToolStripMenuItem mnuAccExit;
    }
}
