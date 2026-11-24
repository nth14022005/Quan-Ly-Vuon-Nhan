using System;
using System.Data;
using System.Windows.Forms;
using QLVuonNhan.Data;

namespace QLVuonNhan
{
    public partial class FrmVatTuList : Form
    {
        private DataTable _dt;

        public FrmVatTuList()
        {
            InitializeComponent();

            // chống gán event trùng
            this.Load -= FrmVatTuList_Load;
            this.Load += FrmVatTuList_Load;

            if (btnReload != null) { btnReload.Click -= btnReload_Click; btnReload.Click += btnReload_Click; }
            if (btnAdd != null) { btnAdd.Click -= btnAdd_Click; btnAdd.Click += btnAdd_Click; }
            if (btnEdit != null) { btnEdit.Click -= btnEdit_Click; btnEdit.Click += btnEdit_Click; }
            if (btnDelete != null) { btnDelete.Click -= btnDelete_Click; btnDelete.Click += btnDelete_Click; }
            if (btnClose != null) { btnClose.Click -= btnClose_Click; btnClose.Click += btnClose_Click; }

            if (txtSearch != null) { txtSearch.TextChanged -= txtSearch_TextChanged; txtSearch.TextChanged += txtSearch_TextChanged; }
        }

        private void FrmVatTuList_Load(object sender, EventArgs e)
        {
            // Apply theme (nếu project mày đang dùng UiTheme như VaiTroList)
            UiTheme.ApplyForm(this);
            UiTheme.ApplyGrid(dgvVatTu);
            UiTheme.ApplySearch(txtSearch);
            UiTheme.ApplyButtons(btnReload, btnAdd, btnEdit, btnDelete, btnClose);

            SetupGrid();
            LoadData();
        }

        private void SetupGrid()
        {
            dgvVatTu.AutoGenerateColumns = true;
            dgvVatTu.AllowUserToAddRows = false;
            dgvVatTu.ReadOnly = true;
            dgvVatTu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVatTu.MultiSelect = false;
        }

        private void LoadData()
        {
            // Repo này mày đang có rồi (nếu tên khác thì đổi lại)
            _dt = VatTuRepo.GetAll();

            dgvVatTu.DataSource = _dt.DefaultView;

            // header cho đẹp (tự dò vài tên cột thường gặp)
            TrySetHeader("MaVatTu", "Mã VT");
            TrySetHeader("TenVatTu", "Tên vật tư");
            TrySetHeader("LoaiVatTu", "Loại");
            TrySetHeader("DonViTinh", "ĐVT");
            TrySetHeader("SoLuongTon", "Tồn");
            TrySetHeader("DonGia", "Đơn giá");

            // format số (nếu có)
            TryFormatRight("SoLuongTon", "N2");
            TryFormatRight("DonGia", "N0");

            ApplyFilter();
        }

        private void TrySetHeader(string colName, string header)
        {
            if (dgvVatTu.Columns[colName] != null)
                dgvVatTu.Columns[colName].HeaderText = header;
        }

        private void TryFormatRight(string colName, string fmt)
        {
            if (dgvVatTu.Columns[colName] != null)
            {
                dgvVatTu.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvVatTu.Columns[colName].DefaultCellStyle.Format = fmt;
            }
        }

        private string PickIdColumn()
        {
            if (dgvVatTu.Columns["MaVatTu"] != null) return "MaVatTu";
            if (dgvVatTu.Columns["MaVT"] != null) return "MaVT";
            return null;
        }

        private int GetSelectedId()
        {
            if (dgvVatTu.CurrentRow == null) return -1;

            string idCol = PickIdColumn();
            if (string.IsNullOrWhiteSpace(idCol)) return -1;

            object v = dgvVatTu.CurrentRow.Cells[idCol].Value;
            if (v == null || v == DBNull.Value) return -1;

            return Convert.ToInt32(v);
        }

        private void ApplyFilter()
        {
            if (_dt == null) return;

            string kw = (txtSearch.Text ?? "").Trim().Replace("'", "''");
            var dv = _dt.DefaultView;

            if (string.IsNullOrWhiteSpace(kw))
            {
                dv.RowFilter = "";
                return;
            }

            // lọc theo nhiều cột (cột nào không tồn tại thì RowFilter vẫn OK nếu tên đúng)
            // nếu mày dùng tên cột khác -> đổi lại cho khớp DB
            dv.RowFilter =
                "Convert(MaVatTu,'System.String') LIKE '%" + kw + "%' " +
                "OR TenVatTu LIKE '%" + kw + "%' " +
                "OR LoaiVatTu LIKE '%" + kw + "%' " +
                "OR DonViTinh LIKE '%" + kw + "%' " +
                "OR Convert(SoLuongTon,'System.String') LIKE '%" + kw + "%' " +
                "OR Convert(DonGia,'System.String') LIKE '%" + kw + "%'";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (txtSearch != null) txtSearch.Text = "";
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (FrmVatTuEdit f = new FrmVatTuEdit())
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id < 0)
            {
                MessageBox.Show("Chọn 1 dòng để sửa.");
                return;
            }

            using (FrmVatTuEdit f = new FrmVatTuEdit(id))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id < 0)
            {
                MessageBox.Show("Chọn 1 dòng để xóa.");
                return;
            }

            if (MessageBox.Show("Xóa vật tư này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                VatTuRepo.Delete(id);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được.\n\nChi tiết:\n" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
