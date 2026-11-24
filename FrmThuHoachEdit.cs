using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using QLVuonNhan.Data;

namespace QLVuonNhan
{
    public partial class FrmThuHoachEdit : Form
    {
        private int _maNguoiDung;      // set khi chạy thật
        private int? _maThuHoach;      // null = thêm, có id = sửa

        // ====== Auto center ======
        private bool _centerInited = false;
        private readonly Dictionary<Control, Point> _basePos = new Dictionary<Control, Point>();
        private Rectangle _baseBounds;
        private Control[] _centerControls = Array.Empty<Control>();
        private Label _headerLabel;
        private Panel _pnlBody; // nếu mày tạo Panel tên pnlBody

        // ctor cho Designer
        public FrmThuHoachEdit()
        {
            InitializeComponent();
            WireEvents();
        }

        // ctor chạy thật
        public FrmThuHoachEdit(int maNguoiDung) : this()
        {
            _maNguoiDung = maNguoiDung;
            _maThuHoach = null;
        }

        public FrmThuHoachEdit(int maThuHoach, int maNguoiDung) : this(maNguoiDung)
        {
            _maThuHoach = maThuHoach;
        }

        private void WireEvents()
        {
            this.Load -= FrmThuHoachEdit_Load;
            this.Load += FrmThuHoachEdit_Load;

            this.Shown -= FrmThuHoachEdit_Shown;
            this.Shown += FrmThuHoachEdit_Shown;

            this.Resize -= FrmThuHoachEdit_Resize;
            this.Resize += FrmThuHoachEdit_Resize;

            if (btnSave != null)
            {
                btnSave.Click -= btnSave_Click;
                btnSave.Click += btnSave_Click;
            }

            if (btnCancel != null)
            {
                btnCancel.Click -= btnCancel_Click;
                btnCancel.Click += btnCancel_Click;
            }
        }

        private void FrmThuHoachEdit_Load(object sender, EventArgs e)
        {
            // Theme + vị trí
            EditTheme.Apply(this, btnSave, btnCancel);
            this.StartPosition = FormStartPosition.CenterParent;

            // title
            string title = (_maThuHoach == null) ? "Thêm thu hoạch" : "Sửa thu hoạch";
            this.Text = title;

            // tìm label tiêu đề (nếu có) để set text
            _headerLabel = FindHeaderLabelDeep(this);
            if (_headerLabel != null) _headerLabel.Text = title;

            // optional: nếu mày có panel chứa form fields đặt tên pnlBody thì center panel
            _pnlBody = FindControlByNameDeep(this, "pnlBody") as Panel;

            // set nút Enter/Esc
            if (btnSave != null) this.AcceptButton = btnSave;
            if (btnCancel != null) this.CancelButton = btnCancel;

            // Format date picker cho giống VN
            if (dtpNgay != null)
            {
                dtpNgay.Format = DateTimePickerFormat.Custom;
                dtpNgay.CustomFormat = "dd/MM/yyyy";
            }

            // load combo lô vườn
            LoadLoVuon();

            // load dữ liệu khi sửa
            if (_maThuHoach == null)
            {
                if (dtpNgay != null) dtpNgay.Value = DateTime.Today;
            }
            else
            {
                LoadOne(_maThuHoach.Value);
            }

            // init canh giữa
            InitCentering();
            CenterPanelOrGroup();


        }

        private void FrmThuHoachEdit_Shown(object sender, EventArgs e)
        {
            // gọi lại lần cuối sau khi form render xong (ăn chắc)
            EditTheme.Apply(this, btnSave, btnCancel);
            CenterPanelOrGroup();
        }

        private void FrmThuHoachEdit_Resize(object sender, EventArgs e)
        {
            CenterPanelOrGroup();
        }

        // ================== LOAD DATA ==================
        private void LoadLoVuon()
        {
            try
            {
                DataTable dt = ThuHoachRepo.GetLoVuonForCombo();

                if (cboLoVuon != null)
                {
                    cboLoVuon.DisplayMember = "TenLo";
                    cboLoVuon.ValueMember = "MaLo";
                    cboLoVuon.DataSource = dt;
                    cboLoVuon.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lô vườn:\n" + ex.Message);
            }
        }

        private void LoadOne(int maThuHoach)
        {
            DataRow r = ThuHoachRepo.GetById(maThuHoach);
            if (r == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu.");
                Close();
                return;
            }

            try
            {
                if (cboLoVuon != null && r["MaLo"] != DBNull.Value)
                    cboLoVuon.SelectedValue = Convert.ToInt32(r["MaLo"]);

                if (dtpNgay != null && r["NgayThuHoach"] != DBNull.Value)
                    dtpNgay.Value = Convert.ToDateTime(r["NgayThuHoach"]);

                if (txtSanLuong != null && r["SanLuong"] != DBNull.Value)
                    txtSanLuong.Text = Convert.ToDecimal(r["SanLuong"]).ToString("0.##", CultureInfo.InvariantCulture);

                if (txtPhanLoai != null)
                    txtPhanLoai.Text = r["PhanLoai"] == DBNull.Value ? "" : r["PhanLoai"].ToString();

                if (txtGhiChu != null)
                    txtGhiChu.Text = r["GhiChu"] == DBNull.Value ? "" : r["GhiChu"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp dữ liệu:\n" + ex.Message);
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
            if (cboLoVuon == null || cboLoVuon.SelectedValue == null)
            {
                MessageBox.Show("Chọn lô vườn.");
                return;
            }

            int maLo = Convert.ToInt32(cboLoVuon.SelectedValue);
            DateTime ngay = (dtpNgay != null) ? dtpNgay.Value.Date : DateTime.Today;

            // cho nhập 1.5 hoặc 1,5 đều được
            string slText = (txtSanLuong != null ? txtSanLuong.Text : "").Trim().Replace(',', '.');
            if (!decimal.TryParse(slText, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal sanLuong) || sanLuong <= 0)
            {
                MessageBox.Show("Sản lượng phải là số > 0.");
                if (txtSanLuong != null) txtSanLuong.Focus();
                return;
            }

            string phanLoai = (txtPhanLoai != null ? txtPhanLoai.Text : "").Trim();
            string ghiChu = (txtGhiChu != null ? txtGhiChu.Text : "").Trim();

            try
            {
                if (_maThuHoach == null)
                {
                    ThuHoachRepo.Insert(maLo, _maNguoiDung, ngay, sanLuong, phanLoai, ghiChu);
                }
                else
                {
                    ThuHoachRepo.Update(_maThuHoach.Value, maLo, ngay, sanLuong, phanLoai, ghiChu);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu:\n" + ex.Message);
            }
        }

        // ================== CENTERING (panel ưu tiên, không có panel thì center cụm controls) ==================
        private void InitCentering()
        {
            if (_centerInited) return;

            // nếu có pnlBody thì thôi khỏi tính nhóm controls
            if (_pnlBody != null)
            {
                _centerInited = true;
                return;
            }

            // center các control top-level, loại panel/groupbox để khỏi bị layout giữ
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

            // ưu tiên center pnlBody (nếu mày có tạo)
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

        // ================== FIND HEADER LABEL + FIND CONTROL BY NAME (deep) ==================
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
    }
}
