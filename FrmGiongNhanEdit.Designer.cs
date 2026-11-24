namespace QLVuonNhan
{
    partial class FrmGiongNhanEdit
    {
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.tlpRoot = new System.Windows.Forms.TableLayoutPanel();
            this.panelCard = new System.Windows.Forms.Panel();
            this.tlpCard = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenGiong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
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
            this.panelHeader.Size = new System.Drawing.Size(720, 60);
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
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 520F));
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRoot.Controls.Add(this.panelCard, 1, 1);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(0, 60);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.RowCount = 3;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRoot.Size = new System.Drawing.Size(720, 440);
            this.tlpRoot.TabIndex = 1;
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard.Controls.Add(this.tlpCard);
            this.panelCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard.Location = new System.Drawing.Point(103, 43);
            this.panelCard.Name = "panelCard";
            this.panelCard.Padding = new System.Windows.Forms.Padding(22);
            this.panelCard.Size = new System.Drawing.Size(514, 354);
            this.panelCard.TabIndex = 0;
            // 
            // tlpCard
            // 
            this.tlpCard.ColumnCount = 2;
            this.tlpCard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tlpCard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.tlpCard.Controls.Add(this.lblTitle, 0, 0);
            this.tlpCard.Controls.Add(this.label1, 0, 1);
            this.tlpCard.Controls.Add(this.txtTenGiong, 1, 1);
            this.tlpCard.Controls.Add(this.label2, 0, 2);
            this.tlpCard.Controls.Add(this.txtMoTa, 1, 2);
            this.tlpCard.Controls.Add(this.flpButtons, 0, 3);
            this.tlpCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCard.Location = new System.Drawing.Point(22, 22);
            this.tlpCard.Name = "tlpCard";
            this.tlpCard.RowCount = 4;
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpCard.Size = new System.Drawing.Size(468, 308);
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
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(462, 50);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "THÊM / SỬA GIỐNG NHÃN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên giống:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTenGiong
            // 
            this.txtTenGiong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right))));
            this.txtTenGiong.Location = new System.Drawing.Point(180, 60);
            this.txtTenGiong.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtTenGiong.Name = "txtTenGiong";
            this.txtTenGiong.Size = new System.Drawing.Size(285, 25);
            this.txtTenGiong.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 140);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mô tả:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label2.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            // 
            // txtMoTa
            // 
            this.txtMoTa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMoTa.Location = new System.Drawing.Point(180, 100);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMoTa.Size = new System.Drawing.Size(285, 128);
            this.txtMoTa.TabIndex = 1;
            // 
            // flpButtons
            // 
            this.tlpCard.SetColumnSpan(this.flpButtons, 2);
            this.flpButtons.Controls.Add(this.btnCancel);
            this.flpButtons.Controls.Add(this.btnSave);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Location = new System.Drawing.Point(3, 237);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.flpButtons.Size = new System.Drawing.Size(462, 68);
            this.flpButtons.TabIndex = 50;
            this.flpButtons.WrapContents = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(339, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(123, 40);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Quay về";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(208, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0, 3, 8, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 40);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmGiongNhanEdit
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(242)))), ((int)(((byte)(236)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(720, 500);
            this.Controls.Add(this.tlpRoot);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGiongNhanEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Giống nhãn";
            this.Load += new System.EventHandler(this.FrmGiongNhanEdit_Load);
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

        private System.Windows.Forms.TextBox txtTenGiong;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle;
    }
}
