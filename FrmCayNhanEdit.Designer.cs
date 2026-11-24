namespace QLVuonNhan
{
    partial class FrmCayNhanEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.tlpRoot = new System.Windows.Forms.TableLayoutPanel();
            this.panelCard = new System.Windows.Forms.Panel();
            this.tlpCard = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaSoCay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNamTrong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTinhTrang = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboLoVuon = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboGiongNhan = new System.Windows.Forms.ComboBox();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.tlpRoot.SuspendLayout();
            this.panelCard.SuspendLayout();
            this.tlpCard.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.panelHeader.Controls.Add(this.lblHeaderTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(18, 0, 18, 0);
            this.panelHeader.Size = new System.Drawing.Size(980, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(18, 0);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Padding = new System.Windows.Forms.Padding(0, 18, 0, 0);
            this.lblHeaderTitle.Size = new System.Drawing.Size(136, 39);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "QL VƯỜN NHÃN";
            // 
            // tlpRoot
            // 
            this.tlpRoot.ColumnCount = 3;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 560F));
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRoot.Controls.Add(this.panelCard, 1, 1);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(0, 60);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.RowCount = 3;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 430F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRoot.Size = new System.Drawing.Size(980, 590);
            this.tlpRoot.TabIndex = 1;
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard.Controls.Add(this.tlpCard);
            this.panelCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard.Location = new System.Drawing.Point(213, 83);
            this.panelCard.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.panelCard.Name = "panelCard";
            this.panelCard.Padding = new System.Windows.Forms.Padding(22);
            this.panelCard.Size = new System.Drawing.Size(554, 424);
            this.panelCard.TabIndex = 0;
            // 
            // tlpCard
            // 
            this.tlpCard.ColumnCount = 2;
            this.tlpCard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tlpCard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.tlpCard.Controls.Add(this.lblTitle, 0, 0);
            this.tlpCard.Controls.Add(this.label2, 0, 1);
            this.tlpCard.Controls.Add(this.txtMaSoCay, 1, 1);
            this.tlpCard.Controls.Add(this.label3, 0, 2);
            this.tlpCard.Controls.Add(this.txtNamTrong, 1, 2);
            this.tlpCard.Controls.Add(this.label1, 0, 3);
            this.tlpCard.Controls.Add(this.txtTinhTrang, 1, 3);
            this.tlpCard.Controls.Add(this.label4, 0, 4);
            this.tlpCard.Controls.Add(this.txtGhiChu, 1, 4);
            this.tlpCard.Controls.Add(this.label5, 0, 5);
            this.tlpCard.Controls.Add(this.cboLoVuon, 1, 5);
            this.tlpCard.Controls.Add(this.label6, 0, 6);
            this.tlpCard.Controls.Add(this.cboGiongNhan, 1, 6);
            this.tlpCard.Controls.Add(this.flpButtons, 0, 7);
            this.tlpCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCard.Location = new System.Drawing.Point(22, 22);
            this.tlpCard.Name = "tlpCard";
            this.tlpCard.RowCount = 8;
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpCard.Size = new System.Drawing.Size(508, 378);
            this.tlpCard.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.tlpCard.SetColumnSpan(this.lblTitle, 2);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(502, 46);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "THÊM / SỬA CÂY NHÃN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã số cây:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaSoCay
            // 
            this.txtMaSoCay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right))));
            this.txtMaSoCay.Location = new System.Drawing.Point(196, 54);
            this.txtMaSoCay.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtMaSoCay.Name = "txtMaSoCay";
            this.txtMaSoCay.Size = new System.Drawing.Size(309, 25);
            this.txtMaSoCay.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 42);
            this.label3.TabIndex = 1;
            this.label3.Text = "Năm trồng:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNamTrong
            // 
            this.txtNamTrong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right))));
            this.txtNamTrong.Location = new System.Drawing.Point(196, 96);
            this.txtNamTrong.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtNamTrong.Name = "txtNamTrong";
            this.txtNamTrong.Size = new System.Drawing.Size(309, 25);
            this.txtNamTrong.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tình trạng:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTinhTrang
            // 
            this.txtTinhTrang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right))));
            this.txtTinhTrang.Location = new System.Drawing.Point(196, 138);
            this.txtTinhTrang.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtTinhTrang.Name = "txtTinhTrang";
            this.txtTinhTrang.Size = new System.Drawing.Size(309, 25);
            this.txtTinhTrang.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 42);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ghi chú:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right))));
            this.txtGhiChu.Location = new System.Drawing.Point(196, 180);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(309, 25);
            this.txtGhiChu.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 42);
            this.label5.TabIndex = 4;
            this.label5.Text = "Lô vườn:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboLoVuon
            // 
            this.cboLoVuon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right))));
            this.cboLoVuon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoVuon.FormattingEnabled = true;
            this.cboLoVuon.Location = new System.Drawing.Point(196, 222);
            this.cboLoVuon.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.cboLoVuon.Name = "cboLoVuon";
            this.cboLoVuon.Size = new System.Drawing.Size(309, 25);
            this.cboLoVuon.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 42);
            this.label6.TabIndex = 5;
            this.label6.Text = "Giống nhãn:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboGiongNhan
            // 
            this.cboGiongNhan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right))));
            this.cboGiongNhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGiongNhan.FormattingEnabled = true;
            this.cboGiongNhan.Location = new System.Drawing.Point(196, 264);
            this.cboGiongNhan.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.cboGiongNhan.Name = "cboGiongNhan";
            this.cboGiongNhan.Size = new System.Drawing.Size(309, 25);
            this.cboGiongNhan.TabIndex = 5;
            // 
            // flpButtons
            // 
            this.tlpCard.SetColumnSpan(this.flpButtons, 2);
            this.flpButtons.Controls.Add(this.btnCancel);
            this.flpButtons.Controls.Add(this.btnSave);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Location = new System.Drawing.Point(3, 301);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(0, 14, 0, 0);
            this.flpButtons.Size = new System.Drawing.Size(502, 74);
            this.flpButtons.TabIndex = 9;
            this.flpButtons.WrapContents = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(379, 17);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(123, 40);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(248, 17);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0, 3, 8, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 40);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // FrmCayNhanEdit
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(242)))), ((int)(((byte)(236)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(980, 650);
            this.Controls.Add(this.tlpRoot);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCayNhanEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cây nhãn";
            this.Load += new System.EventHandler(this.FrmCayNhanEdit_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tlpRoot.ResumeLayout(false);
            this.panelCard.ResumeLayout(false);
            this.tlpCard.ResumeLayout(false);
            this.tlpCard.PerformLayout();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.TableLayoutPanel tlpCard;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;

        private System.Windows.Forms.TextBox txtMaSoCay;
        private System.Windows.Forms.TextBox txtNamTrong;
        private System.Windows.Forms.TextBox txtTinhTrang;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.ComboBox cboLoVuon;
        private System.Windows.Forms.ComboBox cboGiongNhan;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1; // Tình trạng
        private System.Windows.Forms.Label label2; // Mã số cây
        private System.Windows.Forms.Label label3; // Năm trồng
        private System.Windows.Forms.Label label4; // Ghi chú
        private System.Windows.Forms.Label label5; // Lô vườn
        private System.Windows.Forms.Label label6; // Giống nhãn
        private System.Windows.Forms.Label lblTitle;
    }
}
