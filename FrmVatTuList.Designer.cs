namespace QLVuonNhan
{
    partial class FrmVatTuList
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
            this.pnlGridWrap = new System.Windows.Forms.Panel();
            this.dgvVatTu = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tlpRoot.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlGridWrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVatTu)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.tlpBottom.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRoot
            // 
            this.tlpRoot.ColumnCount = 1;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpRoot.Controls.Add(this.pnlGridWrap, 0, 1);
            this.tlpRoot.Controls.Add(this.pnlBottom, 0, 2);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(0, 0);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.Padding = new System.Windows.Forms.Padding(18);
            this.tlpRoot.RowCount = 3;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tlpRoot.Size = new System.Drawing.Size(1318, 989);
            this.tlpRoot.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(21, 21);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlHeader.Size = new System.Drawing.Size(1276, 64);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1252, 44);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DANH SÁCH VẬT TƯ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlGridWrap
            // 
            this.pnlGridWrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGridWrap.Controls.Add(this.dgvVatTu);
            this.pnlGridWrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridWrap.Location = new System.Drawing.Point(21, 91);
            this.pnlGridWrap.Name = "pnlGridWrap";
            this.pnlGridWrap.Size = new System.Drawing.Size(1276, 789);
            this.pnlGridWrap.TabIndex = 1;
            // 
            // dgvVatTu
            // 
            this.dgvVatTu.AllowUserToAddRows = false;
            this.dgvVatTu.AllowUserToDeleteRows = false;
            this.dgvVatTu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVatTu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVatTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVatTu.Location = new System.Drawing.Point(0, 0);
            this.dgvVatTu.MultiSelect = false;
            this.dgvVatTu.Name = "dgvVatTu";
            this.dgvVatTu.ReadOnly = true;
            this.dgvVatTu.RowHeadersVisible = false;
            this.dgvVatTu.RowTemplate.Height = 28;
            this.dgvVatTu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVatTu.Size = new System.Drawing.Size(1274, 787);
            this.dgvVatTu.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.tlpBottom);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(21, 886);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlBottom.Size = new System.Drawing.Size(1276, 82);
            this.pnlBottom.TabIndex = 2;
            // 
            // tlpBottom
            // 
            this.tlpBottom.ColumnCount = 4;
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 620F));
            this.tlpBottom.Controls.Add(this.label1, 0, 0);
            this.tlpBottom.Controls.Add(this.txtSearch, 1, 0);
            this.tlpBottom.Controls.Add(this.flpButtons, 3, 0);
            this.tlpBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBottom.Location = new System.Drawing.Point(0, 10);
            this.tlpBottom.Name = "tlpBottom";
            this.tlpBottom.RowCount = 1;
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.Size = new System.Drawing.Size(1276, 72);
            this.tlpBottom.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 72);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(93, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(334, 26);
            this.txtSearch.TabIndex = 1;
            // 
            // flpButtons
            // 
            this.flpButtons.Controls.Add(this.btnReload);
            this.flpButtons.Controls.Add(this.btnAdd);
            this.flpButtons.Controls.Add(this.btnEdit);
            this.flpButtons.Controls.Add(this.btnDelete);
            this.flpButtons.Controls.Add(this.btnClose);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flpButtons.Location = new System.Drawing.Point(659, 3);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(0, 14, 0, 0);
            this.flpButtons.Size = new System.Drawing.Size(614, 66);
            this.flpButtons.TabIndex = 2;
            this.flpButtons.WrapContents = false;
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(0, 14);
            this.btnReload.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(110, 38);
            this.btnReload.TabIndex = 2;
            this.btnReload.Text = "Tải lại";
            this.btnReload.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(120, 14);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 38);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(240, 14);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(110, 38);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(360, 14);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 38);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(480, 14);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 38);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Quay lại";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // FrmVatTuList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 989);
            this.Controls.Add(this.tlpRoot);
            this.Name = "FrmVatTuList";
            this.Text = "FrmVatTuList";
            this.Load += new System.EventHandler(this.FrmVatTuList_Load);
            this.tlpRoot.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlGridWrap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVatTu)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.tlpBottom.ResumeLayout(false);
            this.tlpBottom.PerformLayout();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRoot;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Panel pnlGridWrap;
        private System.Windows.Forms.DataGridView dgvVatTu;

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;

        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
    }
}
