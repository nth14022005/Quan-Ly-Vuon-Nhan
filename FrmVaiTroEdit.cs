using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QLVuonNhan.Data;

namespace QLVuonNhan
{
    public partial class FrmVaiTroEdit : Form
    {
        private readonly int? _maVaiTro;

        public FrmVaiTroEdit()
        {
            InitializeComponent();

            // gắn event (tránh trùng)
            btnSave.Click -= btnSave_Click;
            btnSave.Click += btnSave_Click;

            btnCancel.Click -= btnCancel_Click;
            btnCancel.Click += btnCancel_Click;

            this.Load -= FrmVaiTroEdit_Load;
            this.Load += FrmVaiTroEdit_Load;

            // nếu designer lỡ gắn click label thì cho handler rỗng để khỏi lỗi
            if (lblMaVaiTro != null)
            {
                lblMaVaiTro.Click -= lblMaVaiTro_Click;
                lblMaVaiTro.Click += lblMaVaiTro_Click;
            }

            // Enter = Lưu, Esc = Hủy
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
        }

        public FrmVaiTroEdit(int maVaiTro) : this()
        {
            _maVaiTro = maVaiTro;
        }

        private void FrmVaiTroEdit_Load(object sender, EventArgs e)
        {
            ApplyDialogTheme();   // ✅ không maximize
            StyleButtons();       // ✅ nút đẹp hơn

            string title = (_maVaiTro == null) ? "Thêm vai trò" : "Sửa vai trò";
            this.Text = title;

            // nếu designer mới có lblTitle thì set luôn
            var header = FindControlDeep<Label>(this, "lblTitle");
            if (header != null) header.Text = title;

            if (_maVaiTro == null)
            {
                if (lblMaVaiTro != null) lblMaVaiTro.Text = "(tự tăng)";
                txtTenVaiTro?.Focus();
            }
            else
            {
                LoadOne(_maVaiTro.Value);
            }

            // btnCancel đóng form
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void LoadOne(int maVaiTro)
        {
            DataRow r = VaiTroRepo.GetById(maVaiTro);
            if (r == null)
            {
                MessageBox.Show("Không tìm thấy vai trò.");
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            if (lblMaVaiTro != null) lblMaVaiTro.Text = r["MaVaiTro"].ToString();
            if (txtTenVaiTro != null)
                txtTenVaiTro.Text = r["TenVaiTro"] == DBNull.Value ? "" : r["TenVaiTro"].ToString();

            txtTenVaiTro?.Focus();
            txtTenVaiTro?.SelectAll();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string ten = (txtTenVaiTro?.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Tên vai trò không được trống.");
                txtTenVaiTro?.Focus();
                return;
            }

            if (ten.Length > 50)
            {
                MessageBox.Show("Tên vai trò tối đa 50 ký tự.");
                txtTenVaiTro?.Focus();
                return;
            }

            try
            {
                if (_maVaiTro == null)
                    VaiTroRepo.Insert(ten);
                else
                    VaiTroRepo.Update(_maVaiTro.Value, ten);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu:\n" + ex.Message);
            }
        }

        // ===== Theme / Style =====

        private void ApplyDialogTheme()
        {
            // ✅ tránh bị phóng to (maximize) như ảnh
            this.StartPosition = FormStartPosition.CenterParent;
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;

            // tone giống hệ thống
            this.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            this.BackColor = Color.FromArgb(245, 242, 236);
        }

        private void StyleButtons()
        {
            // nút Lưu (xanh)
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.BackColor = Color.FromArgb(46, 125, 50);
            btnSave.ForeColor = Color.White;
            btnSave.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btnSave.Width = 110;
            btnSave.Height = 32;

            // nút Hủy (xám)
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.BackColor = Color.Gainsboro;
            btnCancel.ForeColor = Color.Black;
            btnCancel.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            btnCancel.Width = 110;
            btnCancel.Height = 32;
        }

        // ===== Helpers =====

        private static T FindControlDeep<T>(Control root, string name) where T : Control
        {
            if (root == null) return null;

            foreach (Control c in root.Controls)
            {
                if (c is T t && string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase))
                    return t;

                var child = FindControlDeep<T>(c, name);
                if (child != null) return child;
            }
            return null;
        }

        // handler rỗng để khỏi lỗi nếu designer lỡ gắn event
        private void lblMaVaiTro_Click(object sender, EventArgs e) { }
    }
}
