namespace QLVuonNhan
{
    partial class FrmCayNhanList
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
            this.tlpRoot = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvCayNhan = new System.Windows.Forms.DataGridView();
            this.tlpRoot.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCayNhan)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpRoot
            // 
            this.tlpRoot.ColumnCount = 2;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpRoot.Controls.Add(this.pnlLeft, 0, 1);
            this.tlpRoot.Controls.Add(this.pnlMain, 1, 1);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(0, 0);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.RowCount = 2;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Size = new System.Drawing.Size(1200, 700);
            this.tlpRoot.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.tlpRoot.SetColumnSpan(this.pnlHeader, 2);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlHeader.Size = new System.Drawing.Size(1194, 64);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1170, 44);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DANH SÁCH CÂY NHÃN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.flpButtons);
            this.pnlLeft.Controls.Add(this.txtSearch);
            this.pnlLeft.Controls.Add(this.lblSearch);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(3, 73);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(14);
            this.pnlLeft.Size = new System.Drawing.Size(274, 624);
            this.pnlLeft.TabIndex = 1;
            // 
            // flpButtons
            // 
            this.flpButtons.Controls.Add(this.btnReload);
            this.flpButtons.Controls.Add(this.btnAdd);
            this.flpButtons.Controls.Add(this.btnEdit);
            this.flpButtons.Controls.Add(this.btnDelete);
            this.flpButtons.Controls.Add(this.btnClose);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpButtons.Location = new System.Drawing.Point(14, 66);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.flpButtons.Size = new System.Drawing.Size(246, 340);
            this.flpButtons.TabIndex = 2;
            this.flpButtons.WrapContents = false;
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(3, 15);
            this.btnReload.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(240, 38);
            this.btnReload.TabIndex = 0;
            this.btnReload.Text = "Tải lại";
            this.btnReload.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(3, 66);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(240, 38);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(3, 117);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(240, 38);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(3, 168);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(240, 38);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(3, 219);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(240, 38);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Location = new System.Drawing.Point(14, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(246, 26);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSearch.Location = new System.Drawing.Point(14, 14);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.lblSearch.Size = new System.Drawing.Size(71, 26);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm kiếm";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgvCayNhan);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(283, 73);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(12);
            this.pnlMain.Size = new System.Drawing.Size(914, 624);
            this.pnlMain.TabIndex = 2;
            // 
            // dgvCayNhan
            // 
            this.dgvCayNhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCayNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCayNhan.Location = new System.Drawing.Point(12, 12);
            this.dgvCayNhan.Name = "dgvCayNhan";
            this.dgvCayNhan.RowHeadersWidth = 62;
            this.dgvCayNhan.RowTemplate.Height = 28;
            this.dgvCayNhan.Size = new System.Drawing.Size(890, 600);
            this.dgvCayNhan.TabIndex = 0;
            // 
            // FrmCayNhanList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tlpRoot);
            this.Name = "FrmCayNhanList";
            this.Text = "FrmCayNhanList";
            this.Load += new System.EventHandler(this.FrmCayNhanList_Load);
            this.tlpRoot.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.flpButtons.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCayNhan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvCayNhan;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
    }
}
