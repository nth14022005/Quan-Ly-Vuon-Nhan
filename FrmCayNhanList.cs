using System;
using System.Data;
using System.Windows.Forms;
using QLVuonNhan.Data;

namespace QLVuonNhan
{
    public partial class FrmCayNhanList : Form
    {
        private DataTable _dt;

        public FrmCayNhanList()
        {
            InitializeComponent();

            // chống gán trùng event (nếu Designer có gán)
            this.Load -= FrmCayNhanList_Load;
            this.Load += FrmCayNhanList_Load;

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

            if (txtSearch != null)
            {
                txtSearch.TextChanged -= txtSearch_TextChanged;
                txtSearch.TextChanged += txtSearch_TextChanged;
            }
        }

        private void FrmCayNhanList_Load(object sender, EventArgs e)
        {
            // Apply theme
            UiTheme.ApplyForm(this);
            UiTheme.ApplyGrid(dgvCayNhan);
            UiTheme.ApplySearch(txtSearch);
            UiTheme.ApplyButtons(btnReload, btnAdd, btnEdit, btnDelete, btnClose);

            SetupGrid();
            LoadGrid();

            dgvCayNhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCayNhan.RowHeadersVisible = false;
            dgvCayNhan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCayNhan.MultiSelect = false;


        }

        private void SetupGrid()
        {
            dgvCayNhan.AutoGenerateColumns = true;
            dgvCayNhan.ReadOnly = true;
            dgvCayNhan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCayNhan.MultiSelect = false;
            dgvCayNhan.AllowUserToAddRows = false;

            // header đẹp hơn (nếu có các cột này)
            // (tùy Repo trả về column nào)
            // if (dgvCayNhan.Columns["MaCay"] != null) dgvCayNhan.Columns["MaCay"].HeaderText = "Mã cây";
        }

        private void LoadGrid()
        {
            _dt = CayNhanRepo.GetAll();
            dgvCayNhan.DataSource = _dt;
        }

        private void LoadGridSearch()
        {
            string kw = (txtSearch.Text ?? "").Trim();
            dgvCayNhan.DataSource = string.IsNullOrWhiteSpace(kw) ? CayNhanRepo.GetAll() : CayNhanRepo.Search(kw);
        }

        private int? GetSelectedId()
        {
            if (dgvCayNhan.CurrentRow == null) return null;
            object v = dgvCayNhan.CurrentRow.Cells["MaCay"].Value;
            if (v == null || v == DBNull.Value) return null;
            return Convert.ToInt32(v);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadGridSearch();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (txtSearch != null) txtSearch.Clear();
            LoadGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new FrmCayNhanEdit())
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadGridSearch();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedId();
            if (id == null)
            {
                MessageBox.Show("Chọn 1 dòng để sửa.");
                return;
            }

            using (var f = new FrmCayNhanEdit(id.Value))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadGridSearch();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedId();
            if (id == null)
            {
                MessageBox.Show("Chọn 1 dòng để xóa.");
                return;
            }

            if (MessageBox.Show("Xóa cây nhãn này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                CayNhanRepo.Delete(id.Value);
                LoadGridSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa:\n" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
