using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLVuonNhan.Data;

namespace QLVuonNhan
{
    public partial class FrmCayNhanEdit : Form
    {
        private readonly int? _maCay;

        // ====== Auto center group ======
        private bool _centerInited = false;
        private readonly Dictionary<Control, Point> _basePos = new Dictionary<Control, Point>();
        private Rectangle _baseBounds;
        private Control[] _centerControls = new Control[0];
        private Label _headerLabel;

        public FrmCayNhanEdit()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmCayNhanEdit(int maCay) : this()
        {
            _maCay = maCay;
        }

        private void WireEvents()
        {
            this.Load -= FrmCayNhanEdit_Load;
            this.Load += FrmCayNhanEdit_Load;

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

            this.Resize -= FrmCayNhanEdit_Resize;
            this.Resize += FrmCayNhanEdit_Resize;
        }

        private void FrmCayNhanEdit_Load(object sender, EventArgs e)
        {
            // Theme giống các form edit khác
            EditTheme.Apply(this, btnSave, btnCancel);

            string title = (_maCay == null) ? "Thêm cây nhãn" : "Sửa cây nhãn";
            this.Text = title;

            // set label tiêu đề (không bắt nhầm label field)
            _headerLabel = FindHeaderLabelDeep(this);
            if (_headerLabel != null) _headerLabel.Text = title;

            // load combobox
            LoadCombos();

            // load dữ liệu khi sửa
            if (_maCay != null)
                LoadOne(_maCay.Value);

            InitCentering();

            // tiện dùng
            if (btnSave != null) this.AcceptButton = btnSave;
            if (btnCancel != null) this.CancelButton = btnCancel;
        }

        private void LoadCombos()
        {
            try
            {
                if (cboLoVuon != null)
                {
                    cboLoVuon.DisplayMember = "TenLo";
                    cboLoVuon.ValueMember = "MaLo";
                    cboLoVuon.DataSource = CayNhanRepo.GetLoVuonCombo();
                    cboLoVuon.DropDownStyle = ComboBoxStyle.DropDownList;
                }

                if (cboGiongNhan != null)
                {
                    cboGiongNhan.DisplayMember = "TenGiong";
                    cboGiongNhan.ValueMember = "MaGiong";
                    cboGiongNhan.DataSource = CayNhanRepo.GetGiongNhanCombo();
                    cboGiongNhan.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải combobox:\n" + ex.Message);
            }
        }

        private void LoadOne(int maCay)
        {
            DataRow r = CayNhanRepo.GetById(maCay);
            if (r == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu.");
                Close();
                return;
            }

            if (txtMaSoCay != null) txtMaSoCay.Text = r["MaSoCay"].ToString();
            if (txtNamTrong != null) txtNamTrong.Text = r["NamTrong"] == DBNull.Value ? "" : r["NamTrong"].ToString();
            if (txtTinhTrang != null) txtTinhTrang.Text = r["TinhTrang"] == DBNull.Value ? "" : r["TinhTrang"].ToString();
            if (txtGhiChu != null) txtGhiChu.Text = r["GhiChu"] == DBNull.Value ? "" : r["GhiChu"].ToString();

            // set selected
            if (cboLoVuon != null && r["MaLo"] != DBNull.Value)
                cboLoVuon.SelectedValue = Convert.ToInt32(r["MaLo"]);

            if (cboGiongNhan != null && r["MaGiong"] != DBNull.Value)
                cboGiongNhan.SelectedValue = Convert.ToInt32(r["MaGiong"]);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string maSo = (txtMaSoCay != null ? txtMaSoCay.Text : "").Trim();
            string tinhTrang = (txtTinhTrang != null ? txtTinhTrang.Text : "").Trim();
            string ghiChu = (txtGhiChu != null ? txtGhiChu.Text : "").Trim();

            if (string.IsNullOrWhiteSpace(maSo))
            {
                MessageBox.Show("Mã số cây không được trống.");
                if (txtMaSoCay != null) txtMaSoCay.Focus();
                return;
            }
            if (maSo.Length > 30)
            {
                MessageBox.Show("Mã số cây tối đa 30 ký tự.");
                return;
            }
            if (tinhTrang.Length > 30)
            {
                MessageBox.Show("Tình trạng tối đa 30 ký tự.");
                return;
            }
            if (ghiChu.Length > 200)
            {
                MessageBox.Show("Ghi chú tối đa 200 ký tự.");
                return;
            }

            short? namTrong = null;
            string namText = (txtNamTrong != null ? txtNamTrong.Text : "").Trim();
            if (!string.IsNullOrWhiteSpace(namText))
            {
                short tmp;
                if (!short.TryParse(namText, out tmp))
                {
                    MessageBox.Show("Năm trồng phải là số (smallint).");
                    return;
                }
                namTrong = tmp;
            }

            if (cboLoVuon == null || cboGiongNhan == null || cboLoVuon.SelectedValue == null || cboGiongNhan.SelectedValue == null)
            {
                MessageBox.Show("Chọn lô vườn và giống nhãn.");
                return;
            }

            int maLo = Convert.ToInt32(cboLoVuon.SelectedValue);
            int maGiong = Convert.ToInt32(cboGiongNhan.SelectedValue);

            try
            {
                if (_maCay == null)
                    CayNhanRepo.Insert(maSo, namTrong, tinhTrang, ghiChu, maLo, maGiong);
                else
                    CayNhanRepo.Update(_maCay.Value, maSo, namTrong, tinhTrang, ghiChu, maLo, maGiong);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu:\n" + ex.Message);
            }
        }

        // ================== AUTO CENTER ==================
        private void FrmCayNhanEdit_Resize(object sender, EventArgs e)
        {
            CenterGroup();
        }

        private void InitCentering()
        {
            if (_centerInited) return;

            // center các control top-level (tránh Panel/GroupBox để khỏi lệch)
            _centerControls = this.Controls.Cast<Control>()
                .Where(c => c.Visible)
                .Where(c => c.Dock == DockStyle.None)
                .Where(c => !(c is Panel) && !(c is GroupBox))
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

            _centerInited = true;
            CenterGroup();
        }

        private void CenterGroup()
        {
            if (!_centerInited || _centerControls == null || _centerControls.Length == 0) return;

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
                Point baseP;
                if (!_basePos.TryGetValue(c, out baseP)) continue;
                c.Location = new Point(baseP.X + offsetX, baseP.Y + offsetY);
            }
        }

        // ================== FIND HEADER LABEL (TRÁNH BẮT NHẦM LABEL FIELD) ==================
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

            // ưu tiên theo Name nếu mày đặt lblTitle
            string[] preferNames = { "lblTitle", "lblHeader", "lblTieuDe", "lblTieuDeForm" };
            foreach (string n in preferNames)
            {
                var lb = labels.FirstOrDefault(x => string.Equals(x.Name, n, StringComparison.OrdinalIgnoreCase));
                if (lb != null) return lb;
            }

            // ưu tiên tiêu đề: chữ to + ở trên
            var candidates = labels
                .Where(lb => lb.Visible)
                .Where(lb => !IsFieldLabel(lb))
                .Where(lb => lb.Top <= 160)
                .ToList();

            if (candidates.Count == 0) candidates = labels.Where(lb => lb.Visible && !IsFieldLabel(lb)).ToList();
            if (candidates.Count == 0) return null;

            return candidates
                .OrderByDescending(lb => lb.Font != null ? lb.Font.Size : 0f)
                .ThenByDescending(lb => lb.Width)
                .ThenBy(lb => lb.Top)
                .FirstOrDefault();
        }
    }
}
