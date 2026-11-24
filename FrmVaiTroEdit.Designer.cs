namespace QLVuonNhan
{
    partial class FrmVaiTroEdit
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
            this.labelMaVaiTro = new System.Windows.Forms.Label();
            this.lblMaVaiTro = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenVaiTro = new System.Windows.Forms.TextBox();
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
            this.tlpRoot.Size = new System.Drawing.Size(760, 420);
            this.tlpRoot.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlHeader.Size = new System.Drawing.Size(754, 64);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(730, 44);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "VAI TRÒ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpCenter
            // 
            this.tlpCenter.ColumnCount = 3;
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 520F));
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCenter.Controls.Add(this.pnlCard, 1, 0);
            this.tlpCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCenter.Location = new System.Drawing.Point(3, 73);
            this.tlpCenter.Name = "tlpCenter";
            this.tlpCenter.RowCount = 1;
            this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCenter.Size = new System.Drawing.Size(754, 344);
            this.tlpCenter.TabIndex = 1;
            // 
            // pnlCard
            // 
            this.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard.Controls.Add(this.flpButtons);
            this.pnlCard.Controls.Add(this.tlpForm);
            this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard.Location = new System.Drawing.Point(120, 16);
            this.pnlCard.Margin = new System.Windows.Forms.Padding(3, 16, 3, 16);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new System.Windows.Forms.Padding(18);
            this.pnlCard.Size = new System.Drawing.Size(514, 312);
            this.pnlCard.TabIndex = 0;
            // 
            // flpButtons
            // 
            this.flpButtons.Controls.Add(this.btnCancel);
            this.flpButtons.Controls.Add(this.btnSave);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;

            // ✅ FIX: đừng để Height=34 + PaddingTop=10 (bị cắt)
            this.flpButtons.Location = new System.Drawing.Point(18, 244);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.flpButtons.Size = new System.Drawing.Size(476, 50);
            this.flpButtons.TabIndex = 1;
            this.flpButtons.WrapContents = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(356, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 36);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(228, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 36);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // tlpForm
            // 
            this.tlpForm.ColumnCount = 2;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.Controls.Add(this.labelMaVaiTro, 0, 0);
            this.tlpForm.Controls.Add(this.lblMaVaiTro, 1, 0);
            this.tlpForm.Controls.Add(this.label1, 0, 1);
            this.tlpForm.Controls.Add(this.txtTenVaiTro, 1, 1);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpForm.Location = new System.Drawing.Point(18, 18);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 2;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpForm.Size = new System.Drawing.Size(476, 110);
            this.tlpForm.TabIndex = 0;
            // 
            // labelMaVaiTro
            // 
            this.labelMaVaiTro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMaVaiTro.Location = new System.Drawing.Point(3, 0);
            this.labelMaVaiTro.Name = "labelMaVaiTro";
            this.labelMaVaiTro.Size = new System.Drawing.Size(154, 44);
            this.labelMaVaiTro.TabIndex = 0;
            this.labelMaVaiTro.Text = "Mã vai trò:";
            this.labelMaVaiTro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMaVaiTro
            // 
            this.lblMaVaiTro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaVaiTro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaVaiTro.Location = new System.Drawing.Point(163, 0);
            this.lblMaVaiTro.Name = "lblMaVaiTro";
            this.lblMaVaiTro.Size = new System.Drawing.Size(310, 44);
            this.lblMaVaiTro.TabIndex = 1;
            this.lblMaVaiTro.Text = "(tự tăng)";
            this.lblMaVaiTro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 44);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên vai trò:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenVaiTro
            // 
            this.txtTenVaiTro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenVaiTro.Location = new System.Drawing.Point(163, 51);
            this.txtTenVaiTro.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtTenVaiTro.Name = "txtTenVaiTro";
            this.txtTenVaiTro.Size = new System.Drawing.Size(310, 26);
            this.txtTenVaiTro.TabIndex = 4;
            // 
            // FrmVaiTroEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 420);
            this.Controls.Add(this.tlpRoot);
            this.Name = "FrmVaiTroEdit";
            this.Text = "FrmVaiTroEdit";
            this.Load += new System.EventHandler(this.FrmVaiTroEdit_Load);
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

        private System.Windows.Forms.Label labelMaVaiTro;
        private System.Windows.Forms.Label lblMaVaiTro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenVaiTro;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
