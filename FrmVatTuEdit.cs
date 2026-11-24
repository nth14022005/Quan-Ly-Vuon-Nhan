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
    public partial class FrmVatTuEdit : Form
    {
        private int? _maVatTu;

        // ====== Auto center group ======
        private bool _centerInited = false;
        private readonly Dictionary<Control, Point> _basePos = new Dictionary<Control, Point>();
        private Rectangle _baseBounds;
        private Control[] _centerControls = Array.Empty<Control>();
        private Label _headerLabel;
        private Control _centerRoot;

        public FrmVatTuEdit()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmVatTuEdit(int maVatTu) : this()
        {
            _maVatTu = maVatTu;
        }

        private void WireEvents()
        {
            this.Load -= FrmVatTuEdit_Load;
            this.Load += FrmVatTuEdit_Load;

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

            this.Resize -= FrmVatTuEdit_Resize;
            this.Resize += FrmVatTuEdit_Resize;
        }

        private void FrmVatTuEdit_Load(object sender, EventArgs e)
        {
            // Theme giống các form edit khác
            EditTheme.Apply(this, btnSave, btnCancel);

            string title = (_maVatTu == null) ? "Thêm vật tư" : "Sửa vật tư";
            this.Text = title;

            // set label tiêu đề nếu có
            _headerLabel = FindHeaderLabelDeep(this);
            if (_headerLabel != null) _headerLabel.Text = title;

            if (_maVatTu == null)
            {
                // default số
                if (string.IsNullOrWhiteSpace(txtSoLuongTon?.Text)) txtSoLuongTon.Text = "0";
                if (string.IsNullOrWhiteSpace(txtDonGia?.Text)) txtDonGia.Text = "0";
            }
            else
            {
                LoadOne(_maVatTu.Value);
            }

            InitCentering();

            // Enter = Lưu, Esc = Quay
            if (btnSave != null) this.AcceptButton = btnSave;
            if (btnCancel != null) this.CancelButton = btnCancel;
        }

        private void LoadOne(int maVatTu)
        {
            DataRow r = VatTuRepo.GetById(maVatTu);
            if (r == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu.");
                Close();
                return;
            }

            txtTenVatTu.Text = r["TenVatTu"] == DBNull.Value ? "" : r["TenVatTu"].ToString();
            txtLoaiVatTu.Text = r["LoaiVatTu"] == DBNull.Value ? "" : r["LoaiVatTu"].ToString();
            txtDonViTinh.Text = r["DonViTinh"] == DBNull.Value ? "" : r["DonViTinh"].ToString();
            txtSoLuongTon.Text = r["SoLuongTon"] == DBNull.Value ? "0" : r["SoLuongTon"].ToString();
            txtDonGia.Text = r["DonGia"] == DBNull.Value ? "0" : r["DonGia"].ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private static bool TryParseDecimalVN(string input, out decimal value)
        {
            value = 0m;
            string raw = (input ?? "").Trim();
            if (raw.Length == 0) return true; // rỗng coi như 0

            // cho nhập 1.5 hoặc 1,5
            raw = raw.Replace(',', '.');

            return decimal.TryParse(raw, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string ten = (txtTenVatTu.Text ?? "").Trim();
            string loai = (txtLoaiVatTu.Text ?? "").Trim();
            string dvt = (txtDonViTinh.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Tên vật tư không được trống.");
                txtTenVatTu.Focus();
                return;
            }
            if (ten.Length > 100) { MessageBox.Show("Tên vật tư tối đa 100 ký tự."); return; }
            if (loai.Length > 50) { MessageBox.Show("Loại vật tư tối đa 50 ký tự."); return; }
            if (dvt.Length > 20) { MessageBox.Show("Đơn vị tính tối đa 20 ký tự."); return; }

            decimal ton, gia;

            if (!TryParseDecimalVN(txtSoLuongTon.Text, out ton))
            {
                MessageBox.Show("Số lượng tồn phải là số.");
                txtSoLuongTon.Focus();
                return;
            }

            if (!TryParseDecimalVN(txtDonGia.Text, out gia))
            {
                MessageBox.Show("Đơn giá phải là số.");
                txtDonGia.Focus();
                return;
            }

            if (ton < 0) { MessageBox.Show("Số lượng tồn không được âm."); return; }
            if (gia < 0) { MessageBox.Show("Đơn giá không được âm."); return; }

            try
            {
                if (_maVatTu == null)
                    VatTuRepo.Insert(ten, loai, dvt, ton, gia);
                else
                    VatTuRepo.Update(_maVatTu.Value, ten, loai, dvt, ton, gia);

                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu:\n" + ex.Message);
            }
        }

        // ================== AUTO CENTER (theo parent thật của textbox) ==================
        private void FrmVatTuEdit_Resize(object sender, EventArgs e) => CenterGroup();

        private Control ResolveCenterRoot()
        {
            // nếu mày đặt các textbox trong Panel/TableLayout -> center theo parent đó
            if (txtTenVatTu != null && txtTenVatTu.Parent != null && txtTenVatTu.Parent != this)
                return txtTenVatTu.Parent;

            return this;
        }

        private void InitCentering()
        {
            if (_centerInited) return;

            _centerRoot = ResolveCenterRoot();

            _centerControls = _centerRoot.Controls.Cast<Control>()
                .Where(c => c.Visible)
                .Where(c => c.Dock == DockStyle.None)
                .Where(c => !ReferenceEquals(c, _headerLabel))
                .ToArray();

            if (_centerControls.Length == 0) return;

            int minX = _centerControls.Min(c => c.Left);
            int minY = _centerControls.Min(c => c.Top);
            int maxX = _centerControls.Max(c => c.Right);
            int maxY = _centerControls.Max(c => c.Bottom);
            _baseBounds = Rectangle.FromLTRB(minX, minY, maxX, maxY);

            _basePos.Clear();
            foreach (var c in _centerControls) _basePos[c] = c.Location;

            _centerRoot.Resize -= CenterRoot_Resize;
            _centerRoot.Resize += CenterRoot_Resize;

            _centerInited = true;
            CenterGroup();
        }

        private void CenterRoot_Resize(object sender, EventArgs e) => CenterGroup();

        private void CenterGroup()
        {
            if (!_centerInited || _centerControls == null || _centerControls.Length == 0) return;

            var root = _centerRoot ?? this;

            int topReserved = 0;
            if (ReferenceEquals(root, this))
            {
                topReserved = this.Controls.Cast<Control>()
                    .Where(c => c.Dock == DockStyle.Top)
                    .Sum(c => c.Height);
            }

            int usableH = root.ClientSize.Height - topReserved;
            if (usableH < 1) usableH = root.ClientSize.Height;

            int offsetX = (root.ClientSize.Width - _baseBounds.Width) / 2 - _baseBounds.Left;
            int offsetY = topReserved + (usableH - _baseBounds.Height) / 2 - _baseBounds.Top;
            if (offsetY < topReserved + 10) offsetY = topReserved + 10;

            foreach (var c in _centerControls)
            {
                if (!_basePos.TryGetValue(c, out var baseP)) continue;
                c.Location = new Point(baseP.X + offsetX, baseP.Y + offsetY);
            }
        }

        // ================== FIND HEADER LABEL (không bắt nhầm label field) ==================
        private IEnumerable<Control> GetAllControls(Control root)
        {
            foreach (Control c in root.Controls)
            {
                yield return c;
                foreach (var cc in GetAllControls(c))
                    yield return cc;
            }
        }

        private bool IsFieldLabel(Label lb)
        {
            string t = (lb.Text ?? "").Trim();
            return t.EndsWith(":");
        }

        private Label FindHeaderLabelDeep(Control root)
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
                .Where(lb => lb.Top <= 180)
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
