namespace QLVuonNhan
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tlpRoot = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.tlpCenter = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.lblHint = new System.Windows.Forms.Label();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.chkShowPass = new System.Windows.Forms.CheckBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlpRoot.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tlpCenter.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.tlpBottom.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.tlpForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRoot
            // 
            this.tlpRoot.ColumnCount = 1;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Controls.Add(this.pnlTop, 0, 0);
            this.tlpRoot.Controls.Add(this.tlpCenter, 0, 1);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(0, 0);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.RowCount = 2;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Size = new System.Drawing.Size(1100, 650);
            this.tlpRoot.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblAppName);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(22, 0, 22, 0);
            this.pnlTop.Size = new System.Drawing.Size(1100, 72);
            this.pnlTop.TabIndex = 0;
            // 
            // lblAppName
            // 
            this.lblAppName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(22, 0);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(1056, 72);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "QL VƯỜN NHÃN";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpCenter
            // 
            this.tlpCenter.ColumnCount = 3;
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 640F));
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCenter.Controls.Add(this.pnlCard, 1, 0);
            this.tlpCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCenter.Location = new System.Drawing.Point(0, 72);
            this.tlpCenter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCenter.Name = "tlpCenter";
            this.tlpCenter.Padding = new System.Windows.Forms.Padding(0, 26, 0, 26);
            this.tlpCenter.RowCount = 1;
            this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCenter.Size = new System.Drawing.Size(1100, 578);
            this.tlpCenter.TabIndex = 1;
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard.Controls.Add(this.tlpBottom);
            this.pnlCard.Controls.Add(this.tlpForm);
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Location = new System.Drawing.Point(230, 26);
            this.pnlCard.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new System.Windows.Forms.Padding(28);
            this.pnlCard.Size = new System.Drawing.Size(640, 420);
            this.pnlCard.TabIndex = 0;
            // 
            // tlpBottom
            // 
            this.tlpBottom.ColumnCount = 2;
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 310F));
            this.tlpBottom.Controls.Add(this.lblHint, 0, 0);
            this.tlpBottom.Controls.Add(this.flpButtons, 1, 0);
            this.tlpBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpBottom.Location = new System.Drawing.Point(28, 340);
            this.tlpBottom.Name = "tlpBottom";
            this.tlpBottom.RowCount = 1;
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.Size = new System.Drawing.Size(582, 50);
            this.tlpBottom.TabIndex = 2;
            // 
            // lblHint
            // 
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHint.ForeColor = System.Drawing.Color.DimGray;
            this.lblHint.Location = new System.Drawing.Point(3, 0);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(266, 50);
            this.lblHint.TabIndex = 0;
            this.lblHint.Text = "Enter: Đăng nhập   •   Esc: Thoát";
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flpButtons
            // 
            this.flpButtons.Controls.Add(this.btnExit);
            this.flpButtons.Controls.Add(this.btnLogin);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Location = new System.Drawing.Point(272, 0);
            this.flpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.flpButtons.Size = new System.Drawing.Size(310, 50);
            this.flpButtons.TabIndex = 1;
            this.flpButtons.WrapContents = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(195, 6);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(115, 36);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(72, 6);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(115, 36);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tlpForm
            // 
            this.tlpForm.ColumnCount = 2;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.Controls.Add(this.lblUser, 0, 0);
            this.tlpForm.Controls.Add(this.txtUser, 1, 0);
            this.tlpForm.Controls.Add(this.lblPass, 0, 1);
            this.tlpForm.Controls.Add(this.txtPass, 1, 1);
            this.tlpForm.Controls.Add(this.chkShowPass, 1, 2);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpForm.Location = new System.Drawing.Point(28, 92);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 3;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpForm.Size = new System.Drawing.Size(582, 160);
            this.tlpForm.TabIndex = 1;
            // 
            // lblUser
            // 
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUser.Location = new System.Drawing.Point(3, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblUser.Size = new System.Drawing.Size(124, 54);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Tài khoản:";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUser
            // 
            this.txtUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUser.Location = new System.Drawing.Point(133, 14);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 14, 3, 3);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(446, 26);
            this.txtUser.TabIndex = 0;
            // 
            // lblPass
            // 
            this.lblPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPass.Location = new System.Drawing.Point(3, 54);
            this.lblPass.Name = "lblPass";
            this.lblPass.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblPass.Size = new System.Drawing.Size(124, 54);
            this.lblPass.TabIndex = 2;
            this.lblPass.Text = "Mật khẩu:";
            this.lblPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPass
            // 
            this.txtPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPass.Location = new System.Drawing.Point(133, 68);
            this.txtPass.Margin = new System.Windows.Forms.Padding(3, 14, 3, 3);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(446, 26);
            this.txtPass.TabIndex = 1;
            // 
            // chkShowPass
            // 
            this.chkShowPass.AutoSize = true;
            this.chkShowPass.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkShowPass.Location = new System.Drawing.Point(133, 115);
            this.chkShowPass.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.chkShowPass.Name = "chkShowPass";
            this.chkShowPass.Size = new System.Drawing.Size(138, 42);
            this.chkShowPass.TabIndex = 2;
            this.chkShowPass.Text = "Hiện mật khẩu";
            this.chkShowPass.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(28, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(582, 64);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐĂNG NHẬP";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.tlpRoot);
            this.Name = "FrmLogin";
            this.Text = "Đăng nhập - QL Vườn Nhãn";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.tlpRoot.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.tlpCenter.ResumeLayout(false);
            this.pnlCard.ResumeLayout(false);
            this.tlpBottom.ResumeLayout(false);
            this.flpButtons.ResumeLayout(false);
            this.tlpForm.ResumeLayout(false);
            this.tlpForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblAppName;

        private System.Windows.Forms.TableLayoutPanel tlpCenter;
        private System.Windows.Forms.Panel pnlCard;

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.CheckBox chkShowPass;

        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
    }
}
