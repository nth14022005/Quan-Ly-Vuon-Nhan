using System;
using System.Data;
using System.Windows.Forms;
using QLVuonNhan.Data;

namespace QLVuonNhan
{
    public partial class FrmVaiTroList : Form
    {
        private DataTable _dt;

        public FrmVaiTroList()
        {
            InitializeComponent();

            // chống gán event trùng (nếu Designer có gán rồi)
            this.Load -= FrmVaiTroList_Load;
            this.Load += FrmVaiTroList_Load;

            if (btnReload != null) { btnReload.Click -= btnReload_Click; btnReload.Click += btnReload_Click; }
            if (btnAdd != null) { btnAdd.Click -= btnAdd_Click; btnAdd.Click += btnAdd_Click; }
            if (btnEdit != null) { btnEdit.Click -= btnEdit_Click; btnEdit.Click += btnEdit_Click; }
            if (btnDelete != null) { btnDelete.Click -= btnDelete_Click; btnDelete.Click += btnDelete_Click; }
            if (btnClose != null) { btnClose.Click -= btnClose_Click; btnClose.Click += btnClose_Click; }

            if (txtSearch != null) { txtSearch.TextChanged -= txtSearch_TextChanged; txtSearch.TextChanged += txtSearch_TextChanged; }
        }

        private void FrmVaiTroList_Load(object sender, EventArgs e)
        {
            // Apply theme
            UiTheme.ApplyForm(this);
            UiTheme.ApplyGrid(dgvVaiTro);
            UiTheme.ApplySearch(txtSearch);
            UiTheme.ApplyButtons(btnReload, btnAdd, btnEdit, btnDelete, btnClose);

            SetupGrid();
            LoadData();
        }

        private void SetupGrid()
        {
            dgvVaiTro.AutoGenerateColumns = true;
            dgvVaiTro.AllowUserToAddRows = false;
            dgvVaiTro.ReadOnly = true;
            dgvVaiTro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVaiTro.MultiSelect = false;

            // cho đồng đều giống các form trước (nếu theme chưa set)
            dgvVaiTro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVaiTro.RowHeadersVisible = false;
        }

        private void LoadData()
        {
            _dt = VaiTroRepo.GetAll();

            // gán DefaultView để filter luôn
            dgvVaiTro.DataSource = _dt.DefaultView;

            // Đổi header cho đẹp
            if (dgvVaiTro.Columns["MaVaiTro"] != null) dgvVaiTro.Columns["MaVaiTro"].HeaderText = "Mã vai trò";
            if (dgvVaiTro.Columns["TenVaiTro"] != null) dgvVaiTro.Columns["TenVaiTro"].HeaderText = "Tên vai trò";

            ApplyFilter();
        }

        private int? GetSelectedId()
        {
            if (dgvVaiTro == null) return null;

            DataGridViewRow row = null;
            if (dgvVaiTro.SelectedRows != null && dgvVaiTro.SelectedRows.Count > 0)
                row = dgvVaiTro.SelectedRows[0];
            else
                row = dgvVaiTro.CurrentRow;

            if (row == null) return null;

            object v = null;

            // ưu tiên theo tên cột
            if (row.Cells.Contains("MaVaiTro"))
                v = row.Cells["MaVaiTro"].Value;
            else
            {
                // fallback: lấy cột đầu tiên
                if (row.Cells.Count > 0) v = row.Cells[0].Value;
            }

            if (v == null || v == DBNull.Value) return null;

            try { return Convert.ToInt32(v); }
            catch { return null; }
        }

        private void ApplyFilter()
        {
            if (_dt == null) return;

            string kw = (txtSearch?.Text ?? "").Trim().Replace("'", "''");
            DataView dv = _dt.DefaultView;

            if (string.IsNullOrWhiteSpace(kw))
            {
                dv.RowFilter = "";
            }
            else
            {
                dv.RowFilter =
                    "Convert(MaVaiTro,'System.String') LIKE '%" + kw + "%' " +
                    "OR TenVaiTro LIKE '%" + kw + "%'";
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (txtSearch != null) txtSearch.Text = "";
            LoadData();
        }

        // ===== FIX CHÍNH: owner đúng để form Edit không bị “chớp/ẩn sau” khi chạy MDI =====
        private IWin32Window GetDialogOwner()
        {
            // nếu đang trong MDI: owner = form cha (Main)
            return (this.MdiParent != null) ? (IWin32Window)this.MdiParent : this;
        }

        private void OpenEdit(int? id)
        {
            using (FrmVaiTroEdit f = (id == null) ? new FrmVaiTroEdit() : new FrmVaiTroEdit(id.Value))
            {
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowInTaskbar = false;

                if (f.ShowDialog(GetDialogOwner()) == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenEdit(null);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedId();
            if (id == null)
            {
                MessageBox.Show("Chọn 1 dòng để sửa.");
                return;
            }

            OpenEdit(id);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedId();
            if (id == null)
            {
                MessageBox.Show("Chọn 1 dòng để xóa.");
                return;
            }

            if (MessageBox.Show("Xóa vai trò này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                VaiTroRepo.Delete(id.Value);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được (có thể đang được dùng bởi Người Dùng).\n\nChi tiết:\n" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // helper nhỏ: kiểm tra cell theo tên (tránh lỗi nếu không tồn tại)
    internal static class DgvCellExt
    {
        public static bool Contains(this DataGridViewCellCollection cells, string columnName)
        {
            try
            {
                var _ = cells[columnName];
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
