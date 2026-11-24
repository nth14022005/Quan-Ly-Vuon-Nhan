using System;
using System.Data;
using System.Windows.Forms;
using QLVuonNhan.Data;

namespace QLVuonNhan
{
    public partial class FrmGiongNhanList : Form
    {
        private DataTable _dt;

        public FrmGiongNhanList()
        {
            InitializeComponent();

            // chống gán trùng event (nếu Designer có gán rồi)
            this.Load -= FrmGiongNhanList_Load;
            this.Load += FrmGiongNhanList_Load;

            if (txtSearch != null)
            {
                txtSearch.TextChanged -= txtSearch_TextChanged;
                txtSearch.TextChanged += txtSearch_TextChanged;
            }

            if (btnReload != null)
            {
                btnReload.Click -= btnReload_Click;
                btnReload.Click += btnReload_Click;
            }

            if (btnAdd != null)
            {
                btnAdd.Click -= btnAdd_Click;
                btnAdd.Click += btnAdd_Click;
            }

            if (btnEdit != null)
            {
                btnEdit.Click -= btnEdit_Click;
                btnEdit.Click += btnEdit_Click;
            }

            if (btnDelete != null)
            {
                btnDelete.Click -= btnDelete_Click;
                btnDelete.Click += btnDelete_Click;
            }

            if (btnClose != null)
            {
                btnClose.Click -= btnClose_Click;
                btnClose.Click += btnClose_Click;
            }

            if (dgvGiongNhan != null)
            {
                dgvGiongNhan.CellDoubleClick -= dgvGiongNhan_CellDoubleClick;
                dgvGiongNhan.CellDoubleClick += dgvGiongNhan_CellDoubleClick;

                dgvGiongNhan.CellContentClick -= dgvGiongNhan_CellContentClick;
                dgvGiongNhan.CellContentClick += dgvGiongNhan_CellContentClick;
            }
        }

        private void FrmGiongNhanList_Load(object sender, EventArgs e)
        {
            // Apply theme
            UiTheme.ApplyForm(this);
            UiTheme.ApplyGrid(dgvGiongNhan);
            UiTheme.ApplySearch(txtSearch);
            UiTheme.ApplyButtons(btnReload, btnAdd, btnEdit, btnDelete, btnClose);

            ReloadData();

            dgvGiongNhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGiongNhan.RowHeadersVisible = false;

        }

        private void ReloadData()
        {
            _dt = GiongNhanRepo.GetAll();

            dgvGiongNhan.AutoGenerateColumns = true;
            dgvGiongNhan.DataSource = _dt;

            // tiêu đề cột cho đẹp
            if (dgvGiongNhan.Columns["MaGiong"] != null) dgvGiongNhan.Columns["MaGiong"].HeaderText = "Mã giống";
            if (dgvGiongNhan.Columns["TenGiong"] != null) dgvGiongNhan.Columns["TenGiong"].HeaderText = "Tên giống";
            if (dgvGiongNhan.Columns["MoTa"] != null) dgvGiongNhan.Columns["MoTa"].HeaderText = "Mô tả";

            // gõ là có gợi ý (optional)
            var ac = new AutoCompleteStringCollection();
            foreach (DataRow r in _dt.Rows)
            {
                var ten = r["TenGiong"] == DBNull.Value ? "" : r["TenGiong"].ToString();
                if (!string.IsNullOrWhiteSpace(ten)) ac.Add(ten);
            }
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSearch.AutoCompleteCustomSource = ac;

            ApplyFilter();
        }

        private void ApplyFilter()
        {
            if (_dt == null) return;

            string kw = (txtSearch.Text ?? "").Trim().Replace("'", "''");
            if (string.IsNullOrWhiteSpace(kw))
            {
                _dt.DefaultView.RowFilter = "";
                return;
            }

            _dt.DefaultView.RowFilter = string.Format(
                "Convert(MaGiong, 'System.String') LIKE '%{0}%' OR TenGiong LIKE '%{0}%' OR MoTa LIKE '%{0}%'",
                kw);
        }

        private int? GetSelectedId()
        {
            if (dgvGiongNhan.CurrentRow == null) return null;
            object v = dgvGiongNhan.CurrentRow.Cells["MaGiong"].Value;
            if (v == null || v == DBNull.Value) return null;
            return Convert.ToInt32(v);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (txtSearch != null) txtSearch.Text = "";
            ReloadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new FrmGiongNhanEdit())
            {
                if (f.ShowDialog() == DialogResult.OK)
                    ReloadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var id = GetSelectedId();
            if (id == null)
            {
                MessageBox.Show("Chọn 1 dòng để sửa.");
                return;
            }

            using (var f = new FrmGiongNhanEdit(id.Value))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    ReloadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = GetSelectedId();
            if (id == null)
            {
                MessageBox.Show("Chọn 1 dòng để xóa.");
                return;
            }

            if (MessageBox.Show("Xóa giống nhãn này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                int rows = GiongNhanRepo.Delete(id.Value);
                if (rows == 0) MessageBox.Show("Không xóa được (không tìm thấy).");
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được (có thể đang được dùng ở bảng Cây Nhãn).\n\nChi tiết: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        // giữ để tránh lỗi nếu designer trỏ event vào
        private void dgvGiongNhan_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void dgvGiongNhan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnEdit.PerformClick();
        }
    }
}
