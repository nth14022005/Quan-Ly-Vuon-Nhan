using System;
using System.Data;
using System.Windows.Forms;
using QLVuonNhan.Data;

namespace QLVuonNhan
{
    public partial class FrmNguoiDungEdit : Form
    {
        private int? _maNguoiDung;

        public FrmNguoiDungEdit()
        {
            InitializeComponent();

            // gắn event chắc chắn 1 lần
            this.Load -= FrmNguoiDungEdit_Load;
            this.Load += FrmNguoiDungEdit_Load;

            if (btnSave != null) { btnSave.Click -= btnSave_Click; btnSave.Click += btnSave_Click; }
            if (btnCancel != null) { btnCancel.Click -= btnCancel_Click; btnCancel.Click += btnCancel_Click; }
        }

        public FrmNguoiDungEdit(int maNguoiDung) : this()
        {
            _maNguoiDung = maNguoiDung;
        }

        private void FrmNguoiDungEdit_Load(object sender, EventArgs e)
        {
            string title = (_maNguoiDung == null) ? "Thêm người dùng" : "Sửa người dùng";

            // ✅ GỌI 3 THAM SỐ để không lỗi "Apply takes 4 arguments"
            EditTheme.Apply(this, btnSave, btnCancel);

            // set title cho form + nếu có label tiêu đề thì set luôn
            this.Text = title;
            var header = FindHeaderLabel();
            if (header != null) header.Text = title;

            // ẩn mật khẩu
            if (txtMatKhau != null) txtMatKhau.UseSystemPasswordChar = true;

            // load combo
            LoadVaiTro();
            LoadTrangThai();

            if (cboVaiTro != null) cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cboTrangThai != null) cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;

            // thêm mới
            if (_maNguoiDung == null)
            {
                // thêm mới thì pass bắt buộc
                txtTenDangNhap?.Focus();
                return;
            }

            // sửa
            DataRow r = NguoiDungRepo.GetById(_maNguoiDung.Value);
            if (r == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu.");
                Close();
                return;
            }

            if (txtTenDangNhap != null) txtTenDangNhap.Text = r["TenDangNhap"]?.ToString() ?? "";
            if (txtHoTen != null) txtHoTen.Text = r["HoTen"]?.ToString() ?? "";
            if (txtSDT != null) txtSDT.Text = (r["SDT"] == DBNull.Value) ? "" : r["SDT"].ToString();

            // Mật khẩu: KHÔNG fill ra. Sửa để trống = giữ mật khẩu cũ
            if (txtMatKhau != null) txtMatKhau.Text = "";

            if (cboTrangThai != null)
            {
                string tt = r["TrangThai"]?.ToString() ?? "HoatDong";
                cboTrangThai.SelectedItem = tt;
                if (cboTrangThai.SelectedIndex < 0 && cboTrangThai.Items.Count > 0)
                    cboTrangThai.SelectedIndex = 0;
            }

            if (cboVaiTro != null)
            {
                int maVaiTro = Convert.ToInt32(r["MaVaiTro"]);
                cboVaiTro.SelectedValue = maVaiTro;
            }
        }

        private void LoadVaiTro()
        {
            if (cboVaiTro == null) return;

            DataTable dt = NguoiDungRepo.GetVaiTroLookup();
            cboVaiTro.DisplayMember = "TenVaiTro";
            cboVaiTro.ValueMember = "MaVaiTro";
            cboVaiTro.DataSource = dt;
        }

        private void LoadTrangThai()
        {
            if (cboTrangThai == null) return;

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("HoatDong");
            cboTrangThai.Items.Add("Khoa");
            cboTrangThai.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string user = (txtTenDangNhap?.Text ?? "").Trim();
            string pass = (txtMatKhau?.Text ?? "").Trim();
            string name = (txtHoTen?.Text ?? "").Trim();
            string sdt = (txtSDT?.Text ?? "").Trim();

            string trangThai = (cboTrangThai?.SelectedItem != null)
                ? cboTrangThai.SelectedItem.ToString()
                : "HoatDong";

            int maVaiTro = (cboVaiTro?.SelectedValue != null)
                ? Convert.ToInt32(cboVaiTro.SelectedValue)
                : 2;

            // validate
            if (user.Length == 0)
            {
                MessageBox.Show("Tên đăng nhập không được trống.");
                txtTenDangNhap?.Focus();
                return;
            }
            if (user.Length > 50)
            {
                MessageBox.Show("Tên đăng nhập tối đa 50 ký tự.");
                return;
            }

            if (name.Length == 0)
            {
                MessageBox.Show("Họ tên không được trống.");
                txtHoTen?.Focus();
                return;
            }
            if (name.Length > 100)
            {
                MessageBox.Show("Họ tên tối đa 100 ký tự.");
                return;
            }

            if (sdt.Length > 15)
            {
                MessageBox.Show("SĐT tối đa 15 ký tự.");
                return;
            }

            // thêm mới: bắt buộc pass
            if (_maNguoiDung == null && pass.Length == 0)
            {
                MessageBox.Show("Mật khẩu không được trống khi thêm mới.");
                txtMatKhau?.Focus();
                return;
            }
            if (pass.Length > 255)
            {
                MessageBox.Show("Mật khẩu tối đa 255 ký tự.");
                return;
            }

            // check trùng username
            if (NguoiDungRepo.ExistsTenDangNhap(user, _maNguoiDung))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại.");
                txtTenDangNhap?.Focus();
                return;
            }

            object sdtOrDbNull = string.IsNullOrWhiteSpace(sdt) ? (object)DBNull.Value : sdt;

            try
            {
                if (_maNguoiDung == null)
                {
                    // thêm
                    NguoiDungRepo.Insert(user, pass, name, sdtOrDbNull, trangThai, maVaiTro);
                }
                else
                {
                    // sửa: pass trống => giữ pass cũ
                    if (pass.Length == 0)
                        NguoiDungRepo.UpdateNoPassword(_maNguoiDung.Value, user, name, sdtOrDbNull, trangThai, maVaiTro);
                    else
                        NguoiDungRepo.UpdateWithPassword(_maNguoiDung.Value, user, pass, name, sdtOrDbNull, trangThai, maVaiTro);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu:\n" + ex.Message);
            }
        }

        // ===== helper: tìm label tiêu đề (nếu có) =====
        private Label FindHeaderLabel()
        {
            // ưu tiên theo Name nếu mày có đặt tên
            string[] prefer = { "lblTitle", "lblHeader", "lblTieuDe", "lblTieuDeForm" };
            foreach (var n in prefer)
            {
                var found = this.Controls.Find(n, true);
                if (found != null && found.Length > 0 && found[0] is Label lb) return lb;
            }

            // không có name: lấy label chữ to nhất nhưng không phải label dạng "Tên:"
            Label best = null;
            float bestSize = 0;
            foreach (Control c in this.Controls)
            {
                if (c is Label lb)
                {
                    string t = (lb.Text ?? "").Trim();
                    if (t.EndsWith(":")) continue;
                    if (lb.Font != null && lb.Font.Size > bestSize)
                    {
                        bestSize = lb.Font.Size;
                        best = lb;
                    }
                }
            }
            return best;
        }
    }
}
