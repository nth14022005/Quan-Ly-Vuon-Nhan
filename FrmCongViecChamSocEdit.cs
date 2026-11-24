using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLVuonNhan.Data;

namespace QLVuonNhan
{
    public partial class FrmCongViecChamSocEdit : Form
    {
        private int _maVaiTro;      // 1 = Chủ vườn, 2 = Nhân công
        private int _maNguoiDung;   // user đang đăng nhập
        private int? _maCV;         // null=thêm, có= sửa

        // ====== Auto center ======
        private bool _centerInited = false;
        private readonly Dictionary<Control, Point> _basePos = new Dictionary<Control, Point>();
        private Rectangle _baseBounds;
        private Control[] _centerControls = Array.Empty<Control>();
        private Label _headerLabel;
        private Panel _pnlBody; // nếu mày có panel chứa form fields đặt tên pnlBody

        // ctor cho Designer
        public FrmCongViecChamSocEdit()
        {
            InitializeComponent();
            HookEvents();
        }

        // ctor chạy thật (đúng thứ tự: maNguoiDung, maVaiTro)
        public FrmCongViecChamSocEdit(int maNguoiDung, int maVaiTro) : this()
        {
            _maNguoiDung = maNguoiDung;
            _maVaiTro = maVaiTro;
        }

        public FrmCongViecChamSocEdit(int maNguoiDung, int maVaiTro, int maCV) : this(maNguoiDung, maVaiTro)
        {
            _maCV = maCV;
        }

        private void HookEvents()
        {
            this.Load -= FrmCongViecChamSocEdit_Load;
            this.Load += FrmCongViecChamSocEdit_Load;

            this.Shown -= FrmCongViecChamSocEdit_Shown;
            this.Shown += FrmCongViecChamSocEdit_Shown;

            this.Resize -= FrmCongViecChamSocEdit_Resize;
            this.Resize += FrmCongViecChamSocEdit_Resize;

            if (cboLo != null)
            {
                cboLo.SelectedIndexChanged -= cboLo_SelectedIndexChanged;
                cboLo.SelectedIndexChanged += cboLo_SelectedIndexChanged;
            }

            if (btnSave != null) { btnSave.Click -= btnSave_Click; btnSave.Click += btnSave_Click; }
            if (btnCancel != null) { btnCancel.Click -= btnCancel_Click; btnCancel.Click += btnCancel_Click; }
        }

        private void FrmCongViecChamSocEdit_Load(object sender, EventArgs e)
        {
            // Theme + vị trí
            EditTheme.Apply(this, btnSave, btnCancel);
            this.StartPosition = FormStartPosition.CenterParent;

            // optional: nếu có pnlBody thì center panel cho chuẩn
            _pnlBody = FindControlByNameDeep(this, "pnlBody") as Panel;

            // set Enter/Esc
            if (btnSave != null) this.AcceptButton = btnSave;
            if (btnCancel != null) this.CancelButton = btnCancel;

            // format ngày
            if (dtNgay != null)
            {
                dtNgay.Format = DateTimePickerFormat.Custom;
                dtNgay.CustomFormat = "dd/MM/yyyy";
            }

            // Trạng thái
            if (cboTrangThai != null)
            {
                cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
                if (cboTrangThai.Items.Count == 0)
                {
                    cboTrangThai.Items.Add("ChuaLam");
                    cboTrangThai.Items.Add("DangLam");
                    cboTrangThai.Items.Add("HoanThanh");
                    cboTrangThai.Items.Add("Huy");
                }
            }

            // Load lookup
            LoadLookup();

            // Title + load data
            string title = (_maCV == null) ? "Thêm công việc chăm sóc" : "Sửa công việc chăm sóc";
            this.Text = title;

            _headerLabel = FindHeaderLabelDeep(this);
            if (_headerLabel != null) _headerLabel.Text = title;

            if (_maCV == null)
            {
                if (dtNgay != null) dtNgay.Value = DateTime.Today;
                if (cboTrangThai != null) cboTrangThai.SelectedIndex = 0;
                ApplyRoleToNguoiDung();
            }
            else
            {
                LoadEditData(_maCV.Value);
                ApplyRoleToNguoiDung();
            }

            InitCentering();
            CenterPanelOrGroup();
        }

        private void FrmCongViecChamSocEdit_Shown(object sender, EventArgs e)
        {
            // ăn chắc: sau khi render xong
            EditTheme.Apply(this, btnSave, btnCancel);
            CenterPanelOrGroup();
        }

        private void FrmCongViecChamSocEdit_Resize(object sender, EventArgs e)
        {
            CenterPanelOrGroup();
        }

        // ================== LOOKUP ==================
        private void LoadLookup()
        {
            // Lô
            if (cboLo != null)
            {
                DataTable dtLo = CongViecChamSocRepo.GetLoVuonLookup();
                cboLo.DisplayMember = "TenLo";
                cboLo.ValueMember = "MaLo";
                cboLo.DropDownStyle = ComboBoxStyle.DropDownList;
                cboLo.DataSource = dtLo;
            }

            // Người dùng (nhân công)
            if (cboNguoiDung != null)
            {
                DataTable dtNd = CongViecChamSocRepo.GetNguoiDungNhanCongLookup();

                // thêm "(Chưa gán)" cho chủ vườn
                DataRow r0 = dtNd.NewRow();
                r0["MaNguoiDung"] = DBNull.Value;
                r0["HoTen"] = "(Chưa gán)";
                dtNd.Rows.InsertAt(r0, 0);

                cboNguoiDung.DisplayMember = "HoTen";
                cboNguoiDung.ValueMember = "MaNguoiDung";
                cboNguoiDung.DropDownStyle = ComboBoxStyle.DropDownList;
                cboNguoiDung.DataSource = dtNd;
            }

            // Cây theo lô
            LoadCayTheoLoDangChon();
        }

        private void cboLo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCayTheoLoDangChon();
        }

        private void LoadCayTheoLoDangChon()
        {
            if (cboLo == null || cboCay == null) return;
            if (cboLo.SelectedValue == null || cboLo.SelectedValue == DBNull.Value) return;

            int maLo;
            try { maLo = Convert.ToInt32(cboLo.SelectedValue); }
            catch { return; }

            DataTable dtCay = CongViecChamSocRepo.GetCayNhanByLo(maLo);

            // thêm "(Không chọn)"
            DataRow r0 = dtCay.NewRow();
            r0["MaCay"] = DBNull.Value;
            r0["MaSoCay"] = "(Không chọn)";
            dtCay.Rows.InsertAt(r0, 0);

            cboCay.DisplayMember = "MaSoCay";
            cboCay.ValueMember = "MaCay";
            cboCay.DropDownStyle = ComboBoxStyle.DropDownList;

            // set datasource lại (tránh giữ selectedvalue cũ bị lỗi)
            cboCay.DataSource = dtCay;
            cboCay.SelectedIndex = 0;
        }

        private void ApplyRoleToNguoiDung()
        {
            // Nhân công: khóa + auto chọn đúng người đang đăng nhập
            if (_maVaiTro != 1)
            {
                if (cboNguoiDung != null)
                {
                    cboNguoiDung.Enabled = false;

                    // dùng BeginInvoke để chắc chắn datasource đã bind xong
                    this.BeginInvoke(new Action(() =>
                    {
                        try { cboNguoiDung.SelectedValue = _maNguoiDung; }
                        catch { }
                    }));
                }
            }
            else
            {
                if (cboNguoiDung != null) cboNguoiDung.Enabled = true;
            }
        }

        // ================== LOAD EDIT ==================
        private void LoadEditData(int maCV)
        {
            DataRow r = CongViecChamSocRepo.GetById(maCV);
            if (r == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu.");
                this.Close();
                return;
            }

            if (dtNgay != null && r["NgayThucHien"] != DBNull.Value)
                dtNgay.Value = Convert.ToDateTime(r["NgayThucHien"]);

            if (txtLoai != null)
                txtLoai.Text = r["LoaiCongViec"] == DBNull.Value ? "" : r["LoaiCongViec"].ToString();

            if (txtNoiDung != null)
                txtNoiDung.Text = r["NoiDung"] == DBNull.Value ? "" : r["NoiDung"].ToString();

            if (cboTrangThai != null)
                cboTrangThai.Text = r["TrangThai"] == DBNull.Value ? "" : r["TrangThai"].ToString();

            if (txtGhiChu != null)
                txtGhiChu.Text = r["GhiChu"] == DBNull.Value ? "" : r["GhiChu"].ToString();

            // set lô trước
            if (cboLo != null && r["MaLo"] != DBNull.Value)
                cboLo.SelectedValue = Convert.ToInt32(r["MaLo"]);

            // load cây theo lô rồi set cây
            LoadCayTheoLoDangChon();
            if (cboCay != null)
            {
                if (r["MaCay"] == DBNull.Value) cboCay.SelectedIndex = 0;
                else cboCay.SelectedValue = Convert.ToInt32(r["MaCay"]);
            }

            // set người làm
            if (cboNguoiDung != null)
            {
                if (r["MaNguoiDung"] == DBNull.Value) cboNguoiDung.SelectedIndex = 0;
                else cboNguoiDung.SelectedValue = Convert.ToInt32(r["MaNguoiDung"]);
            }
        }

        // ================== SAVE/CANCEL ==================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboLo == null || cboLo.SelectedValue == null || cboLo.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Chọn lô vườn.");
                return;
            }

            string loai = (txtLoai == null ? "" : txtLoai.Text).Trim();
            string noiDung = (txtNoiDung == null ? "" : txtNoiDung.Text).Trim();
            string trangThai = (cboTrangThai == null ? "" : (cboTrangThai.Text ?? "")).Trim();
            string ghiChu = (txtGhiChu == null ? "" : txtGhiChu.Text).Trim();

            if (string.IsNullOrWhiteSpace(loai))
            {
                MessageBox.Show("Loại công việc không được trống.");
                if (txtLoai != null) txtLoai.Focus();
                return;
            }
            if (loai.Length > 50) { MessageBox.Show("Loại công việc tối đa 50 ký tự."); return; }
            if (noiDung.Length > 200) { MessageBox.Show("Nội dung tối đa 200 ký tự."); return; }
            if (string.IsNullOrWhiteSpace(trangThai)) { MessageBox.Show("Chọn trạng thái."); return; }
            if (trangThai.Length > 20) { MessageBox.Show("Trạng thái tối đa 20 ký tự."); return; }
            if (ghiChu.Length > 200) { MessageBox.Show("Ghi chú tối đa 200 ký tự."); return; }

            int maLo = Convert.ToInt32(cboLo.SelectedValue);

            int? maCay = null;
            if (cboCay != null && cboCay.SelectedValue != null && cboCay.SelectedValue != DBNull.Value)
                maCay = Convert.ToInt32(cboCay.SelectedValue);

            int? maNguoiDung = null;
            if (_maVaiTro != 1)
            {
                maNguoiDung = _maNguoiDung; // nhân công auto là nó
            }
            else
            {
                if (cboNguoiDung != null && cboNguoiDung.SelectedValue != null && cboNguoiDung.SelectedValue != DBNull.Value)
                    maNguoiDung = Convert.ToInt32(cboNguoiDung.SelectedValue);
            }

            DateTime ngay = (dtNgay != null) ? dtNgay.Value.Date : DateTime.Today;

            try
            {
                if (_maCV == null)
                {
                    CongViecChamSocRepo.Insert(ngay, loai, noiDung, trangThai, ghiChu, maLo, maCay, maNguoiDung);
                }
                else
                {
                    CongViecChamSocRepo.Update(_maCV.Value, ngay, loai, noiDung, trangThai, ghiChu, maLo, maCay, maNguoiDung);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu:\n" + ex.Message);
            }
        }

        // ================== CENTERING ==================
        private void InitCentering()
        {
            if (_centerInited) return;

            if (_pnlBody != null)
            {
                _centerInited = true;
                return;
            }

            _centerControls = this.Controls.Cast<Control>()
                .Where(c => c.Visible)
                .Where(c => c.Dock == DockStyle.None)
                .Where(c => !(c is Panel) && !(c is GroupBox))
                .Where(c => !ReferenceEquals(c, _headerLabel))
                .ToArray();

            if (_centerControls.Length == 0)
            {
                _centerInited = true;
                return;
            }

            int minX = _centerControls.Min(c => c.Left);
            int minY = _centerControls.Min(c => c.Top);
            int maxX = _centerControls.Max(c => c.Right);
            int maxY = _centerControls.Max(c => c.Bottom);
            _baseBounds = Rectangle.FromLTRB(minX, minY, maxX, maxY);

            _basePos.Clear();
            foreach (var c in _centerControls) _basePos[c] = c.Location;

            _centerInited = true;
        }

        private void CenterPanelOrGroup()
        {
            if (!_centerInited) return;

            if (_pnlBody != null)
            {
                _pnlBody.Left = (ClientSize.Width - _pnlBody.Width) / 2;
                _pnlBody.Top = (ClientSize.Height - _pnlBody.Height) / 2;
                if (_pnlBody.Top < 20) _pnlBody.Top = 20;
                return;
            }

            if (_centerControls == null || _centerControls.Length == 0) return;

            int topReserved = this.Controls.Cast<Control>()
                .Where(c => c.Dock == DockStyle.Top)
                .Sum(c => c.Height);

            int usableH = this.ClientSize.Height - topReserved;
            if (usableH < 1) usableH = this.ClientSize.Height;

            int offsetX = (this.ClientSize.Width - _baseBounds.Width) / 2 - _baseBounds.Left;
            int offsetY = topReserved + (usableH - _baseBounds.Height) / 2 - _baseBounds.Top;
            if (offsetY < topReserved + 10) offsetY = topReserved + 10;

            foreach (var c in _centerControls)
            {
                if (!_basePos.TryGetValue(c, out Point baseP)) continue;
                c.Location = new Point(baseP.X + offsetX, baseP.Y + offsetY);
            }
        }

        // ================== FIND HELPERS ==================
        private static IEnumerable<Control> GetAllControls(Control root)
        {
            foreach (Control c in root.Controls)
            {
                yield return c;
                foreach (var cc in GetAllControls(c))
                    yield return cc;
            }
        }

        private static Control FindControlByNameDeep(Control root, string name)
        {
            return GetAllControls(root)
                .FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        private static bool IsFieldLabel(Label lb)
        {
            string t = (lb.Text ?? "").Trim();
            return t.EndsWith(":");
        }

        private static Label FindHeaderLabelDeep(Control root)
        {
            var labels = GetAllControls(root).OfType<Label>().ToList();
            if (labels.Count == 0) return null;

            string[] preferNames = { "lblTitle", "lblHeader", "lblTieuDe", "lblTieuDeForm" };
            foreach (string n in preferNames)
            {
                var lb = labels.FirstOrDefault(x => string.Equals(x.Name, n, StringComparison.OrdinalIgnoreCase));
                if (lb != null) return lb;
            }

            var candidates = labels
                .Where(lb => lb.Visible)
                .Where(lb => !IsFieldLabel(lb))
                .Where(lb => lb.Top <= 160)
                .ToList();

            if (candidates.Count == 0)
                candidates = labels.Where(lb => lb.Visible && !IsFieldLabel(lb)).ToList();

            if (candidates.Count == 0) return null;

            return candidates
                .OrderByDescending(lb => lb.Font != null ? lb.Font.Size : 0f)
                .ThenByDescending(lb => lb.Width)
                .ThenBy(lb => lb.Top)
                .FirstOrDefault();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
