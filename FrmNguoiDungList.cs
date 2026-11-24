using System;
using System.Data;
using System.Windows.Forms;
using QLVuonNhan.Data;

namespace QLVuonNhan
{
    public partial class FrmNguoiDungList : Form
    {
        private DataTable _dt;

        public FrmNguoiDungList()
        {
            InitializeComponent();

            // chống gán trùng event (nếu Designer có gán)
            this.Load -= FrmNguoiDungList_Load;
            this.Load += FrmNguoiDungList_Load;

            if (btnReload != null) { btnReload.Click -= btnReload_Click; btnReload.Click += btnReload_Click; }
            if (btnAdd != null) { btnAdd.Click -= btnAdd_Click; btnAdd.Click += btnAdd_Click; }
            if (btnEdit != null) { btnEdit.Click -= btnEdit_Click; btnEdit.Click += btnEdit_Click; }
            if (btnDelete != null) { btnDelete.Click -= btnDelete_Click; btnDelete.Click += btnDelete_Click; }
            if (btnClose != null) { btnClose.Click -= btnClose_Click; btnClose.Click += btnClose_Click; }

            if (txtSearch != null) { txtSearch.TextChanged -= txtSearch_TextChanged; txtSearch.TextChanged += txtSearch_TextChanged; }

            if (dgvNguoiDung != null)
            {
                dgvNguoiDung.ReadOnly = true;
                dgvNguoiDung.AllowUserToAddRows = false;
                dgvNguoiDung.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvNguoiDung.MultiSelect = false;
                dgvNguoiDung.AutoGenerateColumns = true;
            }
        }

        private void FrmNguoiDungList_Load(object sender, EventArgs e)
        {
            // Apply theme
            UiTheme.ApplyForm(this);
            UiTheme.ApplyGrid(dgvNguoiDung);
            UiTheme.ApplySearch(txtSearch);
            UiTheme.ApplyButtons(btnReload, btnAdd, btnEdit, btnDelete, btnClose);

            LoadData();

            dgvNguoiDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNguoiDung.RowHeadersVisible = false;

        }

        private void LoadData()
        {
            _dt = NguoiDungRepo.GetAll();

            if (dgvNguoiDung != null)
                dgvNguoiDung.DataSource = _dt.DefaultView;   // bind view để RowFilter ăn ngay

            ApplyHeaders();
            ApplySearch();
        }

        private void ApplyHeaders()
        {
            if (dgvNguoiDung == null) return;

            if (dgvNguoiDung.Columns["MaNguoiDung"] != null) dgvNguoiDung.Columns["MaNguoiDung"].HeaderText = "Mã ND";
            if (dgvNguoiDung.Columns["TenDangNhap"] != null) dgvNguoiDung.Columns["TenDangNhap"].HeaderText = "Tài khoản";
            if (dgvNguoiDung.Columns["HoTen"] != null) dgvNguoiDung.Columns["HoTen"].HeaderText = "Họ tên";
            if (dgvNguoiDung.Columns["SDT"] != null) dgvNguoiDung.Columns["SDT"].HeaderText = "SĐT";
            if (dgvNguoiDung.Columns["TrangThai"] != null) dgvNguoiDung.Columns["TrangThai"].HeaderText = "Trạng thái";
            if (dgvNguoiDung.Columns["TenVaiTro"] != null) dgvNguoiDung.Columns["TenVaiTro"].HeaderText = "Vai trò";

            // nếu có cột mật khẩu mà repo trả về lỡ tay -> ẩn
            if (dgvNguoiDung.Columns["MatKhau"] != null) dgvNguoiDung.Columns["MatKhau"].Visible = false;
        }

        private void ApplySearch()
        {
            if (_dt == null) return;

            string kw = (txtSearch != null) ? (txtSearch.Text ?? "").Trim() : "";
            kw = kw.Replace("'", "''");

            if (string.IsNullOrWhiteSpace(kw))
            {
                _dt.DefaultView.RowFilter = "";
                return;
            }

            _dt.DefaultView.RowFilter =
                "Convert(MaNguoiDung, 'System.String') LIKE '%" + kw + "%' OR " +
                "TenDangNhap LIKE '%" + kw + "%' OR " +
                "HoTen LIKE '%" + kw + "%' OR " +
                "ISNULL(SDT,'') LIKE '%" + kw + "%' OR " +
                "TrangThai LIKE '%" + kw + "%' OR " +
                "ISNULL(TenVaiTro,'') LIKE '%" + kw + "%'";
        }

        private int GetSelectedMaNguoiDung()
        {
            if (dgvNguoiDung == null || dgvNguoiDung.CurrentRow == null) return -1;

            object v = dgvNguoiDung.CurrentRow.Cells["MaNguoiDung"].Value;
            if (v == null || v == DBNull.Value) return -1;

            int id;
            return int.TryParse(v.ToString(), out id) ? id : -1;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (txtSearch != null) txtSearch.Text = "";
            LoadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplySearch();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new FrmNguoiDungEdit())
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = GetSelectedMaNguoiDung();
            if (id <= 0)
            {
                MessageBox.Show("Chọn 1 người dùng để sửa.");
                return;
            }

            using (var f = new FrmNguoiDungEdit(id))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = GetSelectedMaNguoiDung();
            if (id <= 0)
            {
                MessageBox.Show("Chọn 1 người dùng để xóa.");
                return;
            }

            if (MessageBox.Show("Xóa người dùng này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                NguoiDungRepo.Delete(id);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được.\n" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
