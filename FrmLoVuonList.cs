using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLVuonNhan
{
    public partial class FrmLoVuonList : Form
    {
        public FrmLoVuonList()
        {
            InitializeComponent();

            // chống bị gán event 2 lần (nếu Designer có gán rồi)
            this.Load -= FrmLoVuonList_Load;
            this.Load += FrmLoVuonList_Load;

            if (btnReload != null)
            {
                btnReload.Click -= btnReload_Click;
                btnReload.Click += btnReload_Click;
            }

            if (btnSearch != null)
            {
                btnSearch.Click -= btnSearch_Click;
                btnSearch.Click += btnSearch_Click;
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

            if (dgvLoVuon != null)
            {
                dgvLoVuon.CellDoubleClick -= dgvLoVuon_CellDoubleClick;
                dgvLoVuon.CellDoubleClick += dgvLoVuon_CellDoubleClick;

                dgvLoVuon.CellContentClick -= dgvLoVuon_CellContentClick;
                dgvLoVuon.CellContentClick += dgvLoVuon_CellContentClick;
            }
        }

        private void FrmLoVuonList_Load(object sender, EventArgs e)
        {
            // Apply theme
            UiTheme.ApplyForm(this);
            UiTheme.ApplyGrid(dgvLoVuon);
            UiTheme.ApplySearch(txtSearch);
            UiTheme.ApplyButtons(btnReload, btnSearch, btnAdd, btnEdit, btnDelete, btnClose);

            LoadData(null);

            dgvLoVuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoVuon.RowHeadersVisible = false;

        }

        private void LoadData(string keyword)
        {
            try
            {
                using (SqlConnection con = Db.CreateConnection())
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT MaLo, TenLo, DienTich, ViTri, GhiChu
                    FROM dbo.LoVuon
                    WHERE (@kw IS NULL OR @kw = N'')
                       OR (TenLo LIKE N'%' + @kw + N'%')
                       OR (ViTri LIKE N'%' + @kw + N'%')
                    ORDER BY MaLo ASC
                ", con))
                {
                    object kw = string.IsNullOrWhiteSpace(keyword) ? (object)DBNull.Value : keyword.Trim();
                    cmd.Parameters.AddWithValue("@kw", kw);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLoVuon.DataSource = dt;
                    }
                }

                // đổi header cho đẹp (nếu cột tồn tại)
                if (dgvLoVuon.Columns["MaLo"] != null) dgvLoVuon.Columns["MaLo"].HeaderText = "Mã lô";
                if (dgvLoVuon.Columns["TenLo"] != null) dgvLoVuon.Columns["TenLo"].HeaderText = "Tên lô";
                if (dgvLoVuon.Columns["DienTich"] != null) dgvLoVuon.Columns["DienTich"].HeaderText = "Diện tích";
                if (dgvLoVuon.Columns["ViTri"] != null) dgvLoVuon.Columns["ViTri"].HeaderText = "Vị trí";
                if (dgvLoVuon.Columns["GhiChu"] != null) dgvLoVuon.Columns["GhiChu"].HeaderText = "Ghi chú";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Lô vườn:\n" + ex.Message);
            }
        }

        private int? GetSelectedMaLo()
        {
            if (dgvLoVuon == null || dgvLoVuon.CurrentRow == null) return null;
            object val = dgvLoVuon.CurrentRow.Cells["MaLo"].Value;
            if (val == null || val == DBNull.Value) return null;
            return Convert.ToInt32(val);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (txtSearch != null) txtSearch.Text = "";
            LoadData(null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData((txtSearch.Text ?? "").Trim());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (FrmLoVuonEdit f = new FrmLoVuonEdit(null))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData((txtSearch.Text ?? "").Trim());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int? maLo = GetSelectedMaLo();
            if (maLo == null)
            {
                MessageBox.Show("Chọn 1 lô vườn để sửa.");
                return;
            }

            using (FrmLoVuonEdit f = new FrmLoVuonEdit(maLo.Value))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData((txtSearch.Text ?? "").Trim());
            }
        }

        private void dgvLoVuon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnEdit_Click(sender, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int? maLo = GetSelectedMaLo();
            if (maLo == null)
            {
                MessageBox.Show("Chọn 1 lô vườn để xóa.");
                return;
            }

            if (MessageBox.Show("Xóa lô vườn này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection con = Db.CreateConnection())
                using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.LoVuon WHERE MaLo=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", maLo.Value);
                    con.Open();
                    int n = cmd.ExecuteNonQuery();
                    if (n == 0) MessageBox.Show("Không tìm thấy dữ liệu để xóa.");
                }

                LoadData((txtSearch.Text ?? "").Trim());
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không xóa được (có dữ liệu liên quan).\n" + ex.Message);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // lọc trực tiếp trên dgv
            DgvSearch.Apply(dgvLoVuon, txtSearch.Text, "MaLo", "TenLo", "DienTich", "ViTri", "GhiChu");
        }

        private void dgvLoVuon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var colName = dgvLoVuon.Columns[e.ColumnIndex].Name;

            if (colName == "colEdit")
            {
                // nếu mày dùng cột nút Edit thì xử lý ở đây
                // int maLo = Convert.ToInt32(dgvLoVuon.Rows[e.RowIndex].Cells["MaLo"].Value);
                // using (var f = new FrmLoVuonEdit(maLo)) { if (f.ShowDialog()==DialogResult.OK) LoadData(txtSearch.Text.Trim()); }
            }
            else if (colName == "colDelete")
            {
                // nếu mày dùng cột nút Delete thì xử lý ở đây
            }
        }
    }
}
