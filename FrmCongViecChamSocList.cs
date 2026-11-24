using System;
using System.Data;
using System.Windows.Forms;
using QLVuonNhan.Data;

namespace QLVuonNhan
{
    public partial class FrmCongViecChamSocList : Form
    {
        private int _maNguoiDung;
        private int _maVaiTro;

        private bool _columnsInited = false;

        // ctor cho Designer
        public FrmCongViecChamSocList()
        {
            InitializeComponent();
            WireEvents();
        }

        // ctor chạy thật (FrmMain nên gọi ctor này)
        public FrmCongViecChamSocList(int maNguoiDung, int maVaiTro) : this()
        {
            _maNguoiDung = maNguoiDung;
            _maVaiTro = maVaiTro;
        }

        private void WireEvents()
        {
            this.Load -= FrmCongViecChamSocList_Load;
            this.Load += FrmCongViecChamSocList_Load;

            if (btnReload != null) { btnReload.Click -= btnReload_Click; btnReload.Click += btnReload_Click; }
            if (btnAdd != null) { btnAdd.Click -= btnAdd_Click; btnAdd.Click += btnAdd_Click; }
            if (btnEdit != null) { btnEdit.Click -= btnEdit_Click; btnEdit.Click += btnEdit_Click; }
            if (btnDelete != null) { btnDelete.Click -= btnDelete_Click; btnDelete.Click += btnDelete_Click; }
            if (btnClose != null) { btnClose.Click -= btnClose_Click; btnClose.Click += btnClose_Click; }

            if (txtSearch != null) { txtSearch.TextChanged -= txtSearch_TextChanged; txtSearch.TextChanged += txtSearch_TextChanged; }

            if (dgvCongViec != null)
            {
                dgvCongViec.CellContentClick -= dgvCongViec_CellContentClick;
                dgvCongViec.CellContentClick += dgvCongViec_CellContentClick;

                dgvCongViec.CellDoubleClick -= dgvCongViec_CellDoubleClick;
                dgvCongViec.CellDoubleClick += dgvCongViec_CellDoubleClick;

                dgvCongViec.KeyDown -= dgvCongViec_KeyDown;
                dgvCongViec.KeyDown += dgvCongViec_KeyDown;
            }
        }

        private void FrmCongViecChamSocList_Load(object sender, EventArgs e)
        {
            // Apply theme
            UiTheme.ApplyForm(this);
            UiTheme.ApplyGrid(dgvCongViec);
            UiTheme.ApplySearch(txtSearch);
            UiTheme.ApplyButtons(btnReload, btnAdd, btnEdit, btnDelete, btnClose);

            ApplyRoleUI();
            LoadData();

            dgvCongViec.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCongViec.RowHeadersVisible = false;

        }

        private void ApplyRoleUI()
        {
            bool isChuVuon = (_maVaiTro == 1);

            // Nhân công: chỉ xem + tìm
            if (!isChuVuon)
            {
                if (btnAdd != null) btnAdd.Visible = false;
                if (btnEdit != null) btnEdit.Visible = false;
                if (btnDelete != null) btnDelete.Visible = false;

                if (dgvCongViec != null)
                {
                    dgvCongViec.ReadOnly = true;
                    dgvCongViec.AllowUserToAddRows = false;
                    dgvCongViec.AllowUserToDeleteRows = false;
                }
            }
        }

        private void LoadData()
        {
            string kw = (txtSearch == null) ? "" : (txtSearch.Text ?? "").Trim();

            DataTable dt = CongViecChamSocRepo.GetList(kw, _maVaiTro, _maNguoiDung);

            if (dgvCongViec != null)
            {
                dgvCongViec.AutoGenerateColumns = true;
                dgvCongViec.DataSource = dt;

                if (!_columnsInited)
                {
                    InitColumns();
                    _columnsInited = true;
                }
            }
        }

        private void InitColumns()
        {
            if (dgvCongViec == null) return;

            // set header cho đẹp đúng ảnh của mày
            SetHeader("MaCV", "Mã CV");
            SetHeader("NgayThucHien", "Ngày");
            SetHeader("LoVuon", "Lô vườn");
            SetHeader("LoaiCongViec", "Loại CV");
            SetHeader("NoiDung", "Nội dung");
            SetHeader("TrangThai", "Trạng thái");
            SetHeader("MaCay", "Mã cây");
            SetHeader("NguoiLam", "Người làm");

            // format ngày nếu có
            if (dgvCongViec.Columns["NgayThucHien"] != null)
                dgvCongViec.Columns["NgayThucHien"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvCongViec.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCongViec.MultiSelect = false;
            dgvCongViec.AllowUserToResizeRows = false;
            dgvCongViec.RowHeadersVisible = false;
            dgvCongViec.AllowUserToAddRows = false;
            dgvCongViec.ReadOnly = true; // list luôn readonly cho chắc
        }

        private void SetHeader(string colName, string header)
        {
            if (dgvCongViec.Columns[colName] != null)
                dgvCongViec.Columns[colName].HeaderText = header;
        }

        private int GetSelectedMaCV()
        {
            if (dgvCongViec == null) return -1;
            if (dgvCongViec.CurrentRow == null) return -1;
            if (dgvCongViec.CurrentRow.Cells["MaCV"] == null) return -1;

            object v = dgvCongViec.CurrentRow.Cells["MaCV"].Value;
            if (v == null || v == DBNull.Value) return -1;

            int id;
            return int.TryParse(v.ToString(), out id) ? id : -1;
        }

        // ===== EVENTS =====
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // gõ tới đâu lọc tới đó
            LoadData();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (txtSearch != null) txtSearch.Text = "";
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_maVaiTro != 1) return; // nhân công: cấm

            using (FrmCongViecChamSocEdit f = new FrmCongViecChamSocEdit(_maNguoiDung, _maVaiTro))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_maVaiTro != 1) return; // nhân công: cấm

            int maCV = GetSelectedMaCV();
            if (maCV <= 0)
            {
                MessageBox.Show("Chọn 1 dòng để sửa.");
                return;
            }

            using (FrmCongViecChamSocEdit f = new FrmCongViecChamSocEdit(_maNguoiDung, _maVaiTro, maCV))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_maVaiTro != 1) return; // nhân công: cấm

            int maCV = GetSelectedMaCV();
            if (maCV <= 0)
            {
                MessageBox.Show("Chọn 1 dòng để xóa.");
                return;
            }

            if (MessageBox.Show("Xóa công việc này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                CongViecChamSocRepo.Delete(maCV);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa:\n" + ex.Message);
            }
        }

        private void dgvCongViec_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // nhân công: không cho double click mở sửa
            if (_maVaiTro != 1) return;

            if (e.RowIndex >= 0)
                btnEdit_Click(null, null);
        }

        private void dgvCongViec_KeyDown(object sender, KeyEventArgs e)
        {
            // nhân công: chặn phím Delete
            if (_maVaiTro != 1 && e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // giữ để Designer không báo thiếu event
        private void dgvCongViec_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
