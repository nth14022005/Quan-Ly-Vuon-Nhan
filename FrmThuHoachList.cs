using System;
using System.Data;
using System.Windows.Forms;
using QLVuonNhan.Data;

namespace QLVuonNhan
{
    public partial class FrmThuHoachList : Form
    {
        private readonly int _maNguoiDung;
        private DataTable _dt;
        private BindingSource _bs = new BindingSource();

        public FrmThuHoachList(int maNguoiDung)
        {
            InitializeComponent();
            _maNguoiDung = maNguoiDung;

            // chống gán trùng event
            this.Load -= FrmThuHoachList_Load;
            this.Load += FrmThuHoachList_Load;

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

        private void FrmThuHoachList_Load(object sender, EventArgs e)
        {
            // Apply theme
            UiTheme.ApplyForm(this);
            UiTheme.ApplyGrid(dgvThuHoach);
            UiTheme.ApplySearch(txtSearch);
            UiTheme.ApplyButtons(btnReload, btnAdd, btnEdit, btnDelete, btnClose);

            SetupGrid();
            LoadData();

            // nếu mày có ListTheme thì dùng, chưa có thì thôi
            // ListTheme.Apply(this, lblTitle, dgvThuHoach, btnReload, btnAdd, btnEdit, btnDelete, btnClose);

            dgvThuHoach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThuHoach.RowHeadersVisible = false;
            dgvThuHoach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThuHoach.MultiSelect = false;

        }

        private void SetupGrid()
        {
            dgvThuHoach.AutoGenerateColumns = true;
            dgvThuHoach.ReadOnly = true;
            dgvThuHoach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThuHoach.MultiSelect = false;
            dgvThuHoach.AllowUserToAddRows = false;
        }

        private void LoadData()
        {
            _dt = ThuHoachRepo.GetAll();

            _bs.DataSource = _dt;
            dgvThuHoach.DataSource = _bs;

            // chỉnh cột cho dễ nhìn
            if (dgvThuHoach.Columns["MaThuHoach"] != null) dgvThuHoach.Columns["MaThuHoach"].HeaderText = "Mã TH";
            if (dgvThuHoach.Columns["MaLo"] != null) dgvThuHoach.Columns["MaLo"].Visible = false;
            if (dgvThuHoach.Columns["MaNguoiDung"] != null) dgvThuHoach.Columns["MaNguoiDung"].Visible = false;

            if (dgvThuHoach.Columns["TenLo"] != null) dgvThuHoach.Columns["TenLo"].HeaderText = "Lô vườn";
            if (dgvThuHoach.Columns["NguoiGhiNhan"] != null) dgvThuHoach.Columns["NguoiGhiNhan"].HeaderText = "Người ghi nhận";

            if (dgvThuHoach.Columns["NgayThuHoach"] != null)
            {
                dgvThuHoach.Columns["NgayThuHoach"].HeaderText = "Ngày";
                dgvThuHoach.Columns["NgayThuHoach"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvThuHoach.Columns["SanLuong"] != null)
            {
                dgvThuHoach.Columns["SanLuong"].HeaderText = "Sản lượng";
                dgvThuHoach.Columns["SanLuong"].DefaultCellStyle.Format = "N2";
            }

            if (dgvThuHoach.Columns["PhanLoai"] != null) dgvThuHoach.Columns["PhanLoai"].HeaderText = "Phân loại";
            if (dgvThuHoach.Columns["GhiChu"] != null) dgvThuHoach.Columns["GhiChu"].HeaderText = "Ghi chú";

            ApplyFilter();
        }

        private int GetSelectedId()
        {
            if (dgvThuHoach.CurrentRow == null) return -1;
            object v = dgvThuHoach.CurrentRow.Cells["MaThuHoach"].Value;
            if (v == null || v == DBNull.Value) return -1;
            return Convert.ToInt32(v);
        }

        private void ApplyFilter()
        {
            if (_dt == null) return;

            string kw = (txtSearch.Text ?? "").Trim().Replace("'", "''");
            if (string.IsNullOrWhiteSpace(kw))
            {
                _bs.DataSource = _dt;
                return;
            }

            DataView dv = _dt.DefaultView;
            dv.RowFilter =
                "TenLo LIKE '%" + kw + "%' " +
                "OR PhanLoai LIKE '%" + kw + "%' " +
                "OR GhiChu LIKE '%" + kw + "%' " +
                "OR NguoiGhiNhan LIKE '%" + kw + "%'";

            _bs.DataSource = dv;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (txtSearch != null) txtSearch.Text = "";
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (FrmThuHoachEdit f = new FrmThuHoachEdit(_maNguoiDung))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id <= 0)
            {
                MessageBox.Show("Chọn 1 dòng để sửa.");
                return;
            }

            using (FrmThuHoachEdit f = new FrmThuHoachEdit(id, _maNguoiDung))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id <= 0)
            {
                MessageBox.Show("Chọn 1 dòng để xóa.");
                return;
            }

            if (MessageBox.Show("Xóa thu hoạch này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                ThuHoachRepo.Delete(id);
                LoadData();
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
    }
}
