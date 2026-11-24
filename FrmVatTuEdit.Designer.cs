namespace QLVuonNhan
{
    partial class FrmVatTuEdit
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlpCenter = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenVatTu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLoaiVatTu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoLuongTon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.tlpRoot.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tlpCenter.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.tlpForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRoot
            // 
            this.tlpRoot.ColumnCount = 1;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpRoot.Controls.Add(this.tlpCenter, 0, 1);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(0, 0);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.RowCount = 2;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Size = new System.Drawing.Size(860, 520);
            this.tlpRoot.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlHeader.Size = new System.Drawing.Size(854, 64);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(830, 44);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "VẬT TƯ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpCenter
            // 
            this.tlpCenter.ColumnCount = 3;
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 560F));
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCenter.Controls.Add(this.pnlCard, 1, 0);
            this.tlpCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCenter.Location = new System.Drawing.Point(3, 73);
            this.tlpCenter.Name = "tlpCenter";
            this.tlpCenter.RowCount = 1;
            this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCenter.Size = new System.Drawing.Size(854, 444);
            this.tlpCenter.TabIndex = 1;
            // 
            // pnlCard
            // 
            this.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard.Controls.Add(this.flpButtons);
            this.pnlCard.Controls.Add(this.tlpForm);
            this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard.Location = new System.Drawing.Point(150, 18);
            this.pnlCard.Margin = new System.Windows.Forms.Padding(3, 18, 3, 18);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new System.Windows.Forms.Padding(18);
            this.pnlCard.Size = new System.Drawing.Size(554, 408);
            this.pnlCard.TabIndex = 0;
            // 
            // flpButtons
            // 
            this.flpButtons.Controls.Add(this.btnCancel);
            this.flpButtons.Controls.Add(this.btnSave);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Location = new System.Drawing.Point(18, 338);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.flpButtons.Size = new System.Drawing.Size(516, 50);
            this.flpButtons.TabIndex = 1;
            this.flpButtons.WrapContents = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(396, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 36);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Quay lại";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(268, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 36);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // tlpForm
            // 
            this.tlpForm.ColumnCount = 2;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.Controls.Add(this.label1, 0, 0);
            this.tlpForm.Controls.Add(this.txtTenVatTu, 1, 0);
            this.tlpForm.Controls.Add(this.label2, 0, 1);
            this.tlpForm.Controls.Add(this.txtLoaiVatTu, 1, 1);
            this.tlpForm.Controls.Add(this.label3, 0, 2);
            this.tlpForm.Controls.Add(this.txtDonViTinh, 1, 2);
            this.tlpForm.Controls.Add(this.label4, 0, 3);
            this.tlpForm.Controls.Add(this.txtSoLuongTon, 1, 3);
            this.tlpForm.Controls.Add(this.label5, 0, 4);
            this.tlpForm.Controls.Add(this.txtDonGia, 1, 4);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpForm.Location = new System.Drawing.Point(18, 18);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 5;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpForm.Size = new System.Drawing.Size(516, 230);
            this.tlpForm.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên vật tư:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenVatTu
            // 
            this.txtTenVatTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenVatTu.Location = new System.Drawing.Point(163, 7);
            this.txtTenVatTu.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtTenVatTu.Name = "txtTenVatTu";
            this.txtTenVatTu.Size = new System.Drawing.Size(350, 26);
            this.txtTenVatTu.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 44);
            this.label2.TabIndex = 2;
            this.label2.Text = "Loại vật tư:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLoaiVatTu
            // 
            this.txtLoaiVatTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLoaiVatTu.Location = new System.Drawing.Point(163, 51);
            this.txtLoaiVatTu.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtLoaiVatTu.Name = "txtLoaiVatTu";
            this.txtLoaiVatTu.Size = new System.Drawing.Size(350, 26);
            this.txtLoaiVatTu.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 44);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đơn vị tính:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDonViTinh.Location = new System.Drawing.Point(163, 95);
            this.txtDonViTinh.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.Size = new System.Drawing.Size(350, 26);
            this.txtDonViTinh.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 44);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số lượng tồn:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSoLuongTon
            // 
            this.txtSoLuongTon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoLuongTon.Location = new System.Drawing.Point(163, 139);
            this.txtSoLuongTon.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtSoLuongTon.Name = "txtSoLuongTon";
            this.txtSoLuongTon.Size = new System.Drawing.Size(350, 26);
            this.txtSoLuongTon.TabIndex = 4;
            this.txtSoLuongTon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 44);
            this.label5.TabIndex = 8;
            this.label5.Text = "Đơn giá:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDonGia.Location = new System.Drawing.Point(163, 183);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(350, 26);
            this.txtDonGia.TabIndex = 5;
            this.txtDonGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FrmVatTuEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 520);
            this.Controls.Add(this.tlpRoot);
            this.Name = "FrmVatTuEdit";
            this.Text = "FrmVatTuEdit";
            this.Load += new System.EventHandler(this.FrmVatTuEdit_Load);
            this.tlpRoot.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.tlpCenter.ResumeLayout(false);
            this.pnlCard.ResumeLayout(false);
            this.flpButtons.ResumeLayout(false);
            this.tlpForm.ResumeLayout(false);
            this.tlpForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.TableLayoutPanel tlpCenter;
        private System.Windows.Forms.Panel pnlCard;

        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;

        private System.Windows.Forms.TextBox txtTenVatTu;
        private System.Windows.Forms.TextBox txtLoaiVatTu;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.TextBox txtSoLuongTon;
        private System.Windows.Forms.TextBox txtDonGia;

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
